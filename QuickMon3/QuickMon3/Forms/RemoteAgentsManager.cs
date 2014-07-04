using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HenIT.Security;

namespace QuickMon.Forms
{
    public partial class RemoteAgentsManager : Form
    {
        internal class RemoteAgentInfo
        {
            public RemoteAgentInfo()
            {
                PortNumber = 8181;
            }
            public string Computer { get; set; }
            public int PortNumber { get; set; }
            public static RemoteAgentInfo FromString(string remoteAgentStr)
            {
                RemoteAgentInfo newRemoteAgentInfo = new RemoteAgentInfo();
                if (remoteAgentStr.Contains(":"))
                {
                    newRemoteAgentInfo.Computer = remoteAgentStr.Substring(0, remoteAgentStr.IndexOf(":"));
                    if (remoteAgentStr.Substring(newRemoteAgentInfo.Computer.Length + 1).IsNumber())
                        newRemoteAgentInfo.PortNumber = int.Parse(remoteAgentStr.Substring(newRemoteAgentInfo.Computer.Length + 1));
                    else
                        newRemoteAgentInfo.PortNumber = 8181;
                }
                else
                {
                    newRemoteAgentInfo.Computer = remoteAgentStr;
                    newRemoteAgentInfo.PortNumber = 8181;
                }
                return newRemoteAgentInfo;
            }
            public override string ToString()
            {
                return Computer + ":" + PortNumber.ToString();
            }
        }

        public RemoteAgentsManager()
        {
            InitializeComponent();
            lvwRemoteHosts.AutoResizeColumnIndex = 2;
            lvwRemoteHosts.AutoResizeColumnEnabled = true;
        }

        #region Form events
        private void RemoteHostsManager_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            try
            {
                ServiceController[] allServices = ServiceController.GetServices();
                ServiceController qm3srvc = (from s in allServices
                                             where s.DisplayName == "QuickMon 3 Service"
                                             select s).FirstOrDefault();
                if (qm3srvc == null)
                {
                    llblLocalServiceRegistered.Visible = true;
                }
                else
                {
                    llblLocalServiceRegistered.Visible = false;
                }

                try
                {
                    llblFirewallRule.Visible = true;
                    Microsoft.Win32.RegistryKey fwrules = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\SharedAccess\Parameters\FirewallPolicy\FirewallRules");
                    string quickMonRule = fwrules.GetValue("{F811AB2E-286C-4DB6-8512-4C991A8A54E9}").ToString();
                    if (quickMonRule.Length > 0)
                        llblFirewallRule.Visible = false;   
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Properties.Settings.Default.KnownRemoteHosts == null)
                Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            else
            {

                foreach (string rh in (from string s in Properties.Settings.Default.KnownRemoteHosts
                                       orderby s
                                       select s))
                {
                    try
                    {

                        RemoteAgentInfo ri = RemoteAgentInfo.FromString(rh);

                        lvi = new ListViewItem(ri.Computer);
                        lvi.SubItems.Add(ri.PortNumber.ToString());
                        string computerNameOnly = rh;

                        lvi.SubItems.Add(""); //Version info to be added afterwards
                        lvi.Tag = ri;
                        lvi.ImageIndex = 3;
                        lvwRemoteHosts.Items.Add(lvi);
                    }
                    catch { }
                }
            }
        } 
        private void RemoteAgentsManager_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            RefreshServiceStates();
        }
        #endregion

        #region Button events
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtComputer.Text.Length > 0)
            {
                try
                {
                    if ((from ListViewItem lvi in lvwRemoteHosts.Items
                         where lvi.Text.ToLower() == txtComputer.Text.ToLower() &&
                         lvi.SubItems[1].Text == remoteportNumericUpDown.Value.ToString()
                         select lvi).Count() > 0)
                    {
                        MessageBox.Show("Remote agent is already in the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        System.Net.IPAddress[] aa = System.Net.Dns.GetHostAddresses(txtComputer.Text);
                        if (aa.Length == 0)
                        {
                            MessageBox.Show("Computer not found or not available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            RemoteAgentInfo ri = new RemoteAgentInfo();
                            ri.Computer = txtComputer.Text;
                            ri.PortNumber = (int)remoteportNumericUpDown.Value;
                            ListViewItem lvi = new ListViewItem(txtComputer.Text);
                            lvi.SubItems.Add(remoteportNumericUpDown.Value.ToString());
                            lvi.SubItems.Add(""); //Version info to be added afterwards
                            lvi.Tag = ri;
                            lvi.ImageIndex = 3;
                            lvwRemoteHosts.Items.Add(lvi);
                            RefreshServiceStates();
                            txtComputer.Text = "";
                            txtComputer.Focus();
                        }
                    }
                }
                catch (Exception ex) 
                {
                    if (ex.Message.Contains("The requested name is valid, but no data of the requested type was found"))
                        MessageBox.Show("Computer inaccessible or name invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            foreach (ListViewItem lvi in lvwRemoteHosts.Items)
            {
                if (lvi.Tag is RemoteAgentInfo)
                {

                    Properties.Settings.Default.KnownRemoteHosts.Add(((RemoteAgentInfo)lvi.Tag).ToString());
                }
            }
            Properties.Settings.Default.Save();
            Close();
        }
        #endregion

        #region Other control events
        private void lblComputer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtComputer.Text.Length > 0)
                {
                    string versionInfo = CollectorEntryRelay.GetRemoteAgentHostVersion(txtComputer.Text, (int)remoteportNumericUpDown.Value);
                    MessageBox.Show("Version Info: " + versionInfo, "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Version", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtComputer_TextChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = txtComputer.Text.Length > 0;
        }
        private void txtComputer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdAdd_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Registering local service and firewall rule
        private void llblLocalServiceRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string localPath = Environment.CurrentDirectory;
            string serviceEXE = System.IO.Path.Combine(localPath, "QuickMonService.exe");
            openFileDialog1.FileName = serviceEXE;
            openFileDialog1.InitialDirectory = localPath;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = openFileDialog1.FileName;
                p.StartInfo.Arguments = "-install";
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            }
        } 
        private void llblFirewallRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string regfile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon3FirewallRule.reg");
            try
            {
                if (System.IO.File.Exists(regfile))
                    System.IO.File.Delete(regfile);
                System.IO.File.WriteAllText(regfile, Properties.Resources.FireWallRule);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = "REGEDIT.EXE";
                p.StartInfo.Arguments = "/S " + regfile;
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             
        }
        #endregion

        #region Context menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshServiceStates();
        } 
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (int index in (from int i in lvwRemoteHosts.SelectedIndices
                                       orderby i descending
                                       select i))
                {
                    lvwRemoteHosts.Items.RemoveAt(index);
                }
            }
        }
        private void attemptToStartAgentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwRemoteHosts.SelectedItems.Count > 0)
                {
                    RemoteAgentInfo ri = (RemoteAgentInfo)lvwRemoteHosts.SelectedItems[0].Tag;
                    ServiceController srvc = new ServiceController("QuickMon 3 Service", ri.Computer);
                    srvc.Start();
                    lvwRemoteHosts.SelectedItems[0].ImageIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Private methods
        private void RefreshServiceStates()
        {
            refreshTimer.Enabled = false;
            refreshTimer.Enabled = true;
        }
        private void RefreshItem(object o)
        {
            int imageIndex = 0;
            ListViewItem lvi = (ListViewItem)o;
            try
            {
                lvwRemoteHosts.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        bool hostExists = false;
                        RemoteAgentInfo ri = (RemoteAgentInfo)lvi.Tag;
                        CollectorEntry ce = new CollectorEntry();
                        ce.EnableRemoteExecute = true;
                        ce.RemoteAgentHostAddress = ri.Computer;
                        ce.RemoteAgentHostPort = ri.PortNumber;
                        ce.CollectorRegistrationName = "PingCollector";
                        ce.CollectorRegistrationDisplayName = "Ping Collector";
                        ce.InitialConfiguration = "<config><hostAddress><entry pingMethod=\"Ping\" address=\"localhost\" description=\"\" maxTimeMS=\"1000\" timeOutMS=\"5000\" httpProxyServer=\"\" socketPort=\"23\" receiveTimeoutMS=\"30000\" sendTimeoutMS=\"30000\" useTelnetLogin=\"False\" userName=\"\" password=\"\" /></hostAddress></config>";
                    
                        lock (this)
                        {
                            hostExists = System.Net.Dns.GetHostAddresses(ri.Computer).Count() != 0;
                        }
                        if (!hostExists)
                        {
                            imageIndex = 3;
                            lvi.SubItems[2].Text = "N/A";
                        }
                        else
                        {

                            MonitorState testState = CollectorEntryRelay.GetRemoteAgentState(ce);

                            if (testState.State == CollectorState.Good)
                            {
                                imageIndex = 0;
                                try
                                {
                                    string versionInfo = CollectorEntryRelay.GetRemoteAgentHostVersion(ri.Computer, ri.PortNumber);
                                    lvi.SubItems[2].Text = versionInfo;
                                }
                                catch (Exception ex)
                                {
                                    if (ex.Message.Contains("ContractFilter"))
                                    {
                                        lvi.SubItems[2].Text = "Remote host does not support version info query! Check that QuickMon 3.13 or later is installed.";
                                    }
                                    else
                                        lvi.SubItems[2].Text = ex.Message;
                                }
                            }
                            else
                            {
                                imageIndex = 2;
                                lvi.SubItems[2].Text = "N/A";
                            }
                        }
                    }
                    catch (Exception delegateEx)
                    {
                        imageIndex = 3;
                        if (delegateEx.Message.Contains("The formatter threw an exception while trying to deserialize the message"))
                            lvi.SubItems[2].Text = "Old version of Remote agent host does not support query or format does not match! Please update remote agent host version.";
                        else
                            lvi.SubItems[2].Text = delegateEx.Message;
                    }
                });
            }
            catch (Exception riEx)
            {
                imageIndex = 1;
                System.Diagnostics.Trace.WriteLine(riEx.ToString());
            }
            SetListViewItemIcon(lvi, imageIndex);
        }
        #endregion

        #region ListView events
        private void lvwRemoteHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count > 0;
            attemptToStartAgentToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count > 0 && lvwRemoteHosts.SelectedItems[0].ImageIndex == 1;
        } 
        #endregion

        #region Refresh statusses
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<ListViewItem> items = new List<ListViewItem>();
                items.AddRange((from ListViewItem lvi in lvwRemoteHosts.Items
                                select lvi).ToArray());
                foreach (ListViewItem lvi in lvwRemoteHosts.Items)
                {
                    SetListViewItemIcon(lvi, 3);
                    System.Threading.ThreadPool.QueueUserWorkItem(RefreshItem, lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void SetListViewItemIcon(ListViewItem lvi, int imageIndex)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lvi.ImageIndex = imageIndex;
            });
        } 
        #endregion
    }
}
