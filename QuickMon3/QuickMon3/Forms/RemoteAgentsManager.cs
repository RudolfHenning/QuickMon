using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using HenIT.Security;

namespace QuickMon.Forms
{
    public partial class RemoteAgentsManager : Form
    {
        public RemoteAgentsManager()
        {
            InitializeComponent();
            lvwRemoteHosts.AutoResizeColumnIndex = 0;
            lvwRemoteHosts.AutoResizeColumnEnabled = true;
        }

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
                    lvi = new ListViewItem(rh);
                    string computerNameOnly = rh;
                    if (computerNameOnly.Contains(":"))
                        computerNameOnly = computerNameOnly.Substring(0, computerNameOnly.IndexOf(":"));
                    lvi.Tag = computerNameOnly;
                    lvi.ImageIndex = 3;
                    lvwRemoteHosts.Items.Add(lvi);
                }
            }
            
        }

        private void txtComputer_TextChanged(object sender, EventArgs e)
        {
            cmdAdd.Enabled = txtComputer.Text.Length > 0;
        }

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

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshServiceStates();
        }

        private void RefreshServiceStates()
        {
            try
            {
                foreach (ListViewItem lvi in lvwRemoteHosts.Items)
                {
                    string computerName = (string)lvi.Tag;
                    try
                    {
                        ServiceController srvc = new ServiceController("QuickMon 3 Service", computerName);
                        if (srvc.Status == ServiceControllerStatus.Running)
                        {
                            lvi.ImageIndex = 0;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Stopped)
                        {
                            lvi.ImageIndex = 1;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Paused)
                        {
                            lvi.ImageIndex = 4;
                        }
                        else if (srvc.Status == ServiceControllerStatus.StartPending || srvc.Status == ServiceControllerStatus.StopPending)
                        {
                            lvi.ImageIndex = 2;
                        }
                        else
                            lvi.ImageIndex = 3;
                    }
                    catch 
                    {
                        lvi.ImageIndex = 3;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoteAgentsManager_Shown(object sender, EventArgs e)
        {
            RefreshServiceStates();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtComputer.Text.Length > 0)
            {
                try
                {
                    if ((from ListViewItem lvi in lvwRemoteHosts.Items
                         where lvi.Text.ToLower() == (txtComputer.Text + ":" + remoteportNumericUpDown.Value.ToString()).ToLower()
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
                            ListViewItem lvi = new ListViewItem(txtComputer.Text + ":" + remoteportNumericUpDown.Value.ToString());
                            lvi.Tag = txtComputer.Text;
                            lvi.ImageIndex = 3;
                            lvwRemoteHosts.Items.Add(lvi);
                            RefreshServiceStates();
                        }
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            foreach (ListViewItem lvi in lvwRemoteHosts.Items)
            {
                Properties.Settings.Default.KnownRemoteHosts.Add(lvi.Text);
            }
            Properties.Settings.Default.Save();
            Close();
        }

        private void lvwRemoteHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeToolStripMenuItem.Enabled = lvwRemoteHosts.SelectedItems.Count > 0;
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
    }
}
