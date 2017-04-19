using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class RemoteAgentHostManagement : Form, IChildWindowIdentity
    {
        internal class RemoteAgentInfo
        {
            private const int defaultPortNo = 48191;
            public RemoteAgentInfo()
            {
                PortNumber = 48191;
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
                        newRemoteAgentInfo.PortNumber = defaultPortNo;
                }
                else
                {
                    newRemoteAgentInfo.Computer = remoteAgentStr;
                    newRemoteAgentInfo.PortNumber = defaultPortNo;
                }
                return newRemoteAgentInfo;
            }
            public override string ToString()
            {
                return Computer + ":" + PortNumber.ToString();
            }
        }
        public RemoteAgentHostManagement()
        {
            InitializeComponent();
        }

        #region IChildWindowIdentity

        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public IParentWindow ParentWindow { get; set; }
        public void RefreshDetails()
        {
            RefreshServiceStates();
        }
        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow(IParentWindow parentWindow = null)
        {
            if (parentWindow != null)
                ParentWindow = parentWindow;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion

        #region Form events
        private void RemoteAgentHostManagement_Load(object sender, EventArgs e)
        {
            try
            {
                LoadKnownRemoteHosts();
                //if (Security.UACTools.IsInAdminMode())
                //{
                //    llblStartLocalService.Visible = false;
                //    cmdEditMonitorPackList.Visible = true;
                //    try
                //    {
                //        llblLocalServiceRegistered.Visible = true;
                //        Microsoft.Win32.RegistryKey svcsInstalled = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\QuickMon 5 Service");
                //        if (svcsInstalled.GetValue("DisplayName").ToString() == "QuickMon 5 Service")
                //        {
                //            llblLocalServiceRegistered.Visible = false;
                //            System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                //            if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                //                llblStartLocalService.Visible = true;
                //        }
                //    }
                //    catch { }

                //    try
                //    {
                //        llblFirewallRule.Visible = true;
                //        Microsoft.Win32.RegistryKey fwrules = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\SharedAccess\Parameters\FirewallPolicy\FirewallRules");
                //        object regVal = fwrules.GetValue("{F811AB2E-286C-4DB6-8512-4C991A8A55EA}");
                //        if (regVal != null)
                //        {
                //            string quickMonRule = regVal.ToString();
                //            if (quickMonRule.Length > 0)
                //                llblFirewallRule.Visible = false;
                //        }
                //    }
                //    catch { }
                //}
                //else
                //{
                //    llblLocalServiceRegistered.Visible = false;
                //    llblFirewallRule.Visible = false;
                //    llblStartLocalService.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RemoteAgentHostManagement_Shown(object sender, EventArgs e)
        {
            lvwRemoteHosts.AutoResizeColumnEnabled = true;
        }
        private void RemoteAgentHostManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        }
        #endregion

        #region Private methods
        private void RefreshServiceStates()
        {
            refreshTimer.Enabled = false;
            refreshTimer.Enabled = true;
        }
        private void LoadKnownRemoteHosts()
        {
            ListViewItem lvi;
            if (Properties.Settings.Default.KnownRemoteHosts == null)
                Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            else
            {
                lvwRemoteHosts.Items.Clear();
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
                        lvi.SubItems.Add(""); //Packs info to be added afterwards
                        lvi.Tag = ri;
                        lvi.ImageIndex = 0;
                        lvwRemoteHosts.Items.Add(lvi);
                    }
                    catch { }
                }
            }
        }
        private void UpdateListViewItem(ListViewItem lvi, int imageIndex, string statusText, string packs = "")
        {
            try
            {
                lvwRemoteHosts.Invoke((MethodInvoker)delegate
                {
                    lvi.ImageIndex = imageIndex;
                    lvi.SubItems[2].Text = statusText;
                    lvi.SubItems[3].Text = packs;
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }
        private void RefreshItem(object o)
        {
            ListViewItem lvi = (ListViewItem)o;
            try
            {
                try
                {
                    bool hostExists = false;
                    RemoteAgentInfo ri = (RemoteAgentInfo)lvi.Tag;
                    string configXml = "<collectorHost uniqueId=\"Ping" + ri.Computer.EscapeXml() + "\" name=\"Ping " + ri.Computer.EscapeXml() + " tests\" enabled=\"True\" expandOnStart=\"True\" dependOnParentId=\"\" " +
                        "agentCheckSequence=\"All\" childCheckBehaviour=\"OnlyRunOnSuccess\" " +
                           "enableRemoteExecute=\"True\" " +
                           "forceRemoteExcuteOnChildCollectors=\"False\" remoteAgentHostAddress=\"" + ri.Computer.EscapeXml() + "\" remoteAgentHostPort=\"48191\" " +
                           "blockParentRemoteAgentHostSettings=\"False\" runLocalOnRemoteHostConnectionFailure=\"True\" >\r\n" +
                           "<collectorAgents>\r\n" +
                                "<collectorAgent type=\"PingCollector\">\r\n" +
                                    "<config>\r\n" +
                                        "<entries>\r\n" +
                                            "<entry pingMethod=\"Ping\" address=\"" + ri.Computer.EscapeXml() + "\" />\r\n" +
                                            "</entries>\r\n" +
                                    "</config>\r\n" +
                                "</collectorAgent>\r\n" +
                            "</collectorAgents>\r\n" +
                        "</collectorHost>\r\n";
                    CollectorHost ce = CollectorHost.FromXml(configXml);

                    ce.EnableRemoteExecute = true;
                    ce.RemoteAgentHostAddress = ri.Computer;
                    ce.RemoteAgentHostPort = ri.PortNumber;
                    try
                    {
                        hostExists = System.Net.Dns.GetHostAddresses(ri.Computer).Count() != 0;
                    }
                    catch { }
                    if (!hostExists)
                    {
                        UpdateListViewItem(lvi, 4, "", "Host not found");
                    }
                    else if (!CanPingHost(ri.Computer))
                    {
                        UpdateListViewItem(lvi, 4, "", "Host not pingable");
                    }
                    else
                    {
                        MonitorState testState = RemoteCollectorHostService.GetCollectorHostState(ce);
                        if (testState.State == CollectorState.Good)
                        {
                            try
                            {
                                string versionInfo = RemoteCollectorHostService.GetRemoteAgentHostVersion(ri.Computer, ri.PortNumber);
                                string packs = "0";

                                //Pack count
                                try
                                {
                                    packs = RemoteCollectorHostService.GetCurrentMonitorPacks(ri.Computer, ri.PortNumber).Count().ToString();
                                }
                                catch (Exception packsEx)
                                {
                                    packs = packsEx.Message;
                                    if (packsEx.Message.Contains("ContractFilter mismatch"))
                                        packs = "Check version!";
                                    else
                                        packs = packsEx.Message;
                                }

                                UpdateListViewItem(lvi, 1, versionInfo, packs);
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("ContractFilter"))
                                {
                                    UpdateListViewItem(lvi, 2, "", "Remote host does not support version info query! Check that QuickMon 4.x or later is installed.");
                                }
                                else
                                    UpdateListViewItem(lvi, 2, "", ex.Message);
                            }
                        }
                        else
                        {
                            UpdateListViewItem(lvi, 3, "N/A", "N/A");
                        }
                    }
                }
                catch (Exception delegateEx)
                {
                    if (delegateEx.Message.StartsWith("There was no endpoint listening"))
                    {
                        UpdateListViewItem(lvi, 3, "", "Service not running or inaccessible");
                    }
                    else if (delegateEx.Message.Contains("The formatter threw an exception while trying to deserialize the message"))
                        UpdateListViewItem(lvi, 3, "", "Old version of Remote agent host does not support query or format does not match! Please update remote agent host version.");
                    else
                        UpdateListViewItem(lvi, 3, "", delegateEx.Message);
                }
            }
            catch (Exception riEx)
            {
                UpdateListViewItem(lvi, 1, "", riEx.ToString());
            }
        }
        private bool CanPingHost(string hostName)
        {
            bool isPingable = false;
            try
            {
                using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
                {
                    System.Net.NetworkInformation.PingReply reply = ping.Send(hostName, 2000);
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                        isPingable = true;
                }
            }
            catch { }
            return isPingable;
        }
        private void SetListViewItemIcon(ListViewItem lvi, int imageIndex)
        {
            this.Invoke((MethodInvoker)delegate
            {
                lvi.ImageIndex = imageIndex;
            });
        } 
        #endregion

        #region Toolbar buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshServiceStates();
        }
        private void cmdEditMonitorPackList_Click(object sender, EventArgs e)
        {
            try
            {
                string monitorPackListPath = "";
                if (System.IO.File.Exists(@"C:\Program Files\Hen IT\QuickMon 5\MonitorPackList.txt"))
                    monitorPackListPath = @"C:\Program Files\Hen IT\QuickMon 5\MonitorPackList.txt";
                else if (System.IO.File.Exists(System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "MonitorPackList.txt")))
                {
                    monitorPackListPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "MonitorPackList.txt");
                }
                else
                {
                    OpenFileDialog fd = new OpenFileDialog();
                    fd.Title = "Edit MonitorPackList.txt";
                    fd.FileName = "MonitorPackList.txt";
                    fd.Filter = "MonitorPackList file|MonitorPackList.txt";
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        monitorPackListPath = fd.FileName;
                    }
                    else
                        return;
                }
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("notepad.exe", monitorPackListPath);
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit MonitorPackList.txt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Other Controls
        private void lblComputer_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtComputer.Text.Length > 0)
                {
                    string versionInfo = RemoteCollectorHostService.GetRemoteAgentHostVersion(txtComputer.Text, (int)remoteportNumericUpDown.Value);
                    MessageBox.Show("Version Info: " + versionInfo, "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Version", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void txtComputer_TextChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = txtComputer.Text.Length > 0;
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            bool accepted = false;
            if (txtComputer.Text.Length > 0)
            {
                try
                {
                    if ((from ListViewItem lvi in lvwRemoteHosts.Items
                         where lvi.Text.ToLower() == txtComputer.Text.ToLower() &&
                         lvi.SubItems[1].Text == remoteportNumericUpDown.Value.ToString()
                         select lvi).Count() > 0)
                    {
                        MessageBox.Show("Remote host is already in the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        accepted = false;
                    }
                    else
                    {
                        System.Net.IPAddress[] aa = System.Net.Dns.GetHostAddresses(txtComputer.Text);
                        if (aa.Length == 0)
                        {
                            if (MessageBox.Show("Computer not found or not available!\r\nAccept anyway?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                                accepted = true;
                        }
                        else
                        {
                            accepted = true;
                        }
                    }


                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The requested name is valid, but no data of the requested type was found"))
                    {
                        if (MessageBox.Show("Computer inaccessible or name invalid!\r\nAccept anyway?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                        {
                            accepted = true;
                        }
                    }
                    else
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (accepted)
                {
                    RemoteAgentInfo ri = new RemoteAgentInfo();
                    ri.Computer = txtComputer.Text;
                    ri.PortNumber = (int)remoteportNumericUpDown.Value;
                    ListViewItem lvi = new ListViewItem(txtComputer.Text);
                    lvi.SubItems.Add(remoteportNumericUpDown.Value.ToString());
                    lvi.SubItems.Add(""); //Version info to be added afterwards
                    lvi.SubItems.Add(""); //Packs
                    lvi.Tag = ri;
                    lvi.ImageIndex = 3;
                    lvwRemoteHosts.Items.Add(lvi);
                    RefreshServiceStates();
                    txtComputer.Text = "";
                    txtComputer.Focus();

                    Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
                    foreach (ListViewItem l in lvwRemoteHosts.Items)
                    {
                        if (l.Tag is RemoteAgentInfo)
                        {
                            Properties.Settings.Default.KnownRemoteHosts.Add(((RemoteAgentInfo)l.Tag).ToString());
                        }
                    }
                    Properties.Settings.Default.Save();
                }
            }
        }

        #endregion

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
                    SetListViewItemIcon(lvi, 0);
                    lvi.SubItems[3].Text = "Loading...";
                    System.Threading.ThreadPool.QueueUserWorkItem(RefreshItem, lvi);
                }

                //try
                //{
                //    llblStartLocalService.Visible = false;
                //    if (Security.UACTools.IsInAdminMode())
                //    {
                //        Microsoft.Win32.RegistryKey svcsInstalled = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\QuickMon 5 Service");
                //        if (svcsInstalled.GetValue("DisplayName").ToString() == "QuickMon 5 Service")
                //        {
                //            llblLocalServiceRegistered.Visible = false;
                //            System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                //            if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                //                llblStartLocalService.Visible = true;
                //        }
                //    }
                //}
                //catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        #region Registering local service and firewall rule
        private void llblLocalServiceRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string localPath = Environment.CurrentDirectory;
            string serviceEXE = System.IO.Path.Combine(localPath, "QuickMonService.exe");
            quickMonServiceOpenFileDialog.FileName = serviceEXE;
            quickMonServiceOpenFileDialog.InitialDirectory = localPath;
            if (quickMonServiceOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = quickMonServiceOpenFileDialog.FileName;
                p.StartInfo.Arguments = "-install";
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }

                try
                {
                    System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
                    if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
                    {
                        qsvrc.Start();
                        qsvrc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running);
                    }

                    RefreshServiceStates();                    
                }
                catch { }
            }
        }
        private void llblFirewallRule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string regfile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon5FirewallRule.reg");
            //try
            //{
            //    if (System.IO.File.Exists(regfile))
            //        System.IO.File.Delete(regfile);
            //    System.IO.File.WriteAllText(regfile, Properties.Resources.FireWallRule);
            //    System.Diagnostics.Process p = new System.Diagnostics.Process();
            //    p.StartInfo = new System.Diagnostics.ProcessStartInfo();
            //    p.StartInfo.FileName = "REGEDIT.EXE";
            //    p.StartInfo.Arguments = "/S " + regfile;
            //    p.StartInfo.Verb = "runas";
            //    try
            //    {
            //        p.Start();
            //        p.WaitForExit();
            //    }
            //    catch (System.ComponentModel.Win32Exception ex)
            //    {
            //        System.Diagnostics.Trace.WriteLine(ex.ToString());
            //    }

            //    try
            //    {
            //        System.ServiceProcess.ServiceController firewallSrvs = new System.ServiceProcess.ServiceController("Windows Firewall");
            //        if (firewallSrvs.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            //        {
            //            firewallSrvs.Stop();
            //            firewallSrvs.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
            //            firewallSrvs.Start();
            //            firewallSrvs.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
            //        }
            //        llblFirewallRule.Visible = false;
            //    }
            //    catch { }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void llblStartLocalService_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    System.ServiceProcess.ServiceController qsvrc = new System.ServiceProcess.ServiceController("QuickMon 5 Service");
            //    if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            //    {
            //        qsvrc.Start();
            //        qsvrc.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
            //        qsvrc.Refresh();
            //        if (qsvrc.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            //        {
            //            MessageBox.Show("Service started", "Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            llblStartLocalService.Visible = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

        #region ListView events
        private void lvwRemoteHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count > 0;
            monitorPacksToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count > 0;
            testToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count == 1;
        }

        private void lvwRemoteHosts_DoubleClick(object sender, EventArgs e)
        {
            if (lvwRemoteHosts.SelectedItems.Count == 1)
            {
                try
                {
                    ListViewItem lvi = lvwRemoteHosts.SelectedItems[0];
                    RemoteAgentInfo ri = (RemoteAgentInfo)lvi.Tag;
                    string remoteHostURL = string.Format("http://{0}:{1}/QuickMonRemoteHost", ri.Computer, ri.PortNumber);
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                    p.StartInfo.FileName = remoteHostURL;
                    try
                    {
                        p.Start();
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Context menu events
        private void monitorPacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwRemoteHosts.SelectedItems.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                bool anyErrors = false;
                foreach (ListViewItem lvi in lvwRemoteHosts.SelectedItems)
                {
                    RemoteAgentInfo ri = (RemoteAgentInfo)lvi.Tag;
                    try
                    {
                        int packCount = 0;
                        sb.AppendFormat("***{0}:{1}***\r\n", ri.Computer.ToUpper(), ri.PortNumber);
                        foreach (string mpFile in RemoteCollectorHostService.GetCurrentMonitorPacks(ri.Computer, ri.PortNumber))
                        {
                            sb.AppendLine("  " + mpFile.Replace(' ', ' ').TrimEnd());
                            packCount++;
                        }
                        if (packCount == 0)
                        {
                            sb.AppendLine("  No Monitor packs found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        anyErrors = true;
                        if (ex.Message.Contains("ContractFilter mismatch"))
                            sb.AppendFormat("  The service on {0}:{1} does not yet support this functionality.\r\n  Please check the version number!\r\n", ri.Computer, ri.PortNumber);
                        else
                            sb.AppendLine("  " + ex.Message);
                    }
                }
                MessageBox.Show(sb.ToString(), "Monitor packs", MessageBoxButtons.OK, anyErrors ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwRemoteHosts_DoubleClick(null, null);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshServiceStates();
        }
        #endregion
    }
}
