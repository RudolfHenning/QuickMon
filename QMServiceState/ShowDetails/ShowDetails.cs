using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.ServiceProcess;

namespace QuickMon
{
    public partial class ShowDetails : Form, ICollectorDetailView
    {
        public List<ServiceStateDefinition> Services { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            Services = null;
            Services = ((ServiceState)collector).Services;
            LoadList();
            RefreshList();
            ShowDetails_Resize(null, null);
        }
        public void RefreshConfig(ICollector collector)
        {
            Services = ((ServiceState)collector).Services;
            LoadList();
            RefreshList();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        public bool IsStillVisible()
        {
            return (!(this.Disposing || this.IsDisposed)) && this.Visible;
        }
        #endregion

        #region Show detail
        public void ShowDetail()
        {
            //ReadConfiguration();
            base.Show();
            LoadList();
            RefreshList();
        }        
        #endregion

        #region Form events
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwServices.Columns[0].Width = lvwServices.ClientSize.Width;
        }
        #endregion

        #region List view events
        private void lvwServices_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            timerColumnWidthChanged.Enabled = false;
            timerColumnWidthChanged.Enabled = true;
        }
        private void lvwServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerItemSelected.Enabled = true;
        }
        #endregion

        #region toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region context menu events
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwServices.SelectedItems)
            {
                if (StartService(lvi.Group.Header, lvi.Text))
                {
                    lvi.ImageIndex = 0;
                }
                else
                {
                    lvi.ImageIndex = 3;
                }
            }
            timerItemSelected.Enabled = true;
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwServices.SelectedItems)
            {
                if (StopService(lvi.Group.Header, lvi.Text))
                {
                    lvi.ImageIndex = 1;
                }
                else
                {
                    lvi.ImageIndex = 3;
                }
            }
            timerItemSelected.Enabled = true;
        }
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwServices.SelectedItems)
            {
                if (StopService(lvi.Group.Header, lvi.Text))
                {
                    lvi.ImageIndex = 1;
                    Application.DoEvents();
                    if (StartService(lvi.Group.Header, lvi.Text))
                    {
                        lvi.ImageIndex = 0;
                    }
                    else
                    {
                        lvi.ImageIndex = 3;
                    }
                }
                else
                {
                    lvi.ImageIndex = 3;
                }
            }
            timerItemSelected.Enabled = true;
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (Services != null)
            {
                lvwServices.Items.Clear();
                foreach (ServiceStateDefinition serviceDefinition in (from s in Services
                                                                      orderby s.MachineName
                                                                      select s))
                {
                    ListViewGroup group = new ListViewGroup(serviceDefinition.MachineName);
                    lvwServices.Groups.Add(group);
                    foreach (string serviceName in (from s in serviceDefinition.Services
                                                    orderby s
                                                    select s))
                    {
                        ListViewItem lvi = new ListViewItem(serviceName);
                        lvi.Group = group;
                        lvi.ImageIndex = 3;
                        lvwServices.Items.Add(lvi);
                    }

                }
            }
        }
        //private void ReadConfiguration()
        //{
        //    XmlDocument config = new XmlDocument();
        //    config.LoadXml(CustomConfig);
        //    services = new List<ServiceStateDefinition>();
        //    XmlElement root = config.DocumentElement;
        //    foreach (XmlElement machine in root.SelectNodes("machine"))
        //    {
        //        ServiceStateDefinition serviceStateDefinition = new ServiceStateDefinition();
        //        serviceStateDefinition.MachineName = machine.Attributes.GetNamedItem("name").Value;
        //        serviceStateDefinition.Services = new List<string>();
        //        foreach (XmlElement service in machine.SelectNodes("service"))
        //        {
        //            serviceStateDefinition.Services.Add(service.Attributes.GetNamedItem("name").Value);

        //        }
        //        services.Add(serviceStateDefinition);
        //    }
        //}
        private void RefreshList()
        {
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                lvwServices.BeginUpdate();
                foreach (ListViewItem itmX in lvwServices.Items)
                {
                    string machineName = itmX.Group.Header;
                    string serviceName = itmX.Text;
                    try
                    {
                        ServiceController srvc = new ServiceController(serviceName, machineName);
                        if (srvc.Status == ServiceControllerStatus.Running)
                        {
                            itmX.ImageIndex = 0;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Stopped)
                        {
                            itmX.ImageIndex = 1;
                        }
                        else if (srvc.Status == ServiceControllerStatus.Paused)
                        {
                            itmX.ImageIndex = 4;
                        }
                        else if (srvc.Status == ServiceControllerStatus.StartPending || srvc.Status == ServiceControllerStatus.StopPending)
                        {
                            itmX.ImageIndex = 2;
                        }
                        else
                            itmX.ImageIndex = 3;
                    }
                    catch (Exception ex)
                    {
                        itmX.ImageIndex = 3;
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lvwServices.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private bool StartService(string machine, string serviceName)
        {
            bool success = false;
            ServiceController srvctrl;
            try
            {
                srvctrl = new ServiceController(serviceName, machine);
                if (srvctrl.Status == ServiceControllerStatus.Stopped)
                {
                    srvctrl.Start();
                    srvctrl.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));

                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }
        private bool StopService(string machine, string serviceName)
        {
            bool success = false;
            ServiceController srvctrl;
            try
            {
                srvctrl = new ServiceController(serviceName, machine);
                if (srvctrl.Status == ServiceControllerStatus.Running)
                {
                    srvctrl.Stop();
                    srvctrl.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));

                    success = true;
                }
            }
            catch
            {
                success = false;
            }
            return success;
        } 
        private bool IsAdmin()
        {
            string strIdentity;
            try
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal wp = new System.Security.Principal.WindowsPrincipal(wi);
                strIdentity = wp.Identity.Name;

                if (wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region Timer events
        private void timerColumnWidthChanged_Tick(object sender, EventArgs e)
        {
            timerColumnWidthChanged.Enabled = false;
            lvwServices.Columns[0].Width = lvwServices.ClientSize.Width;
        }
        private void timerItemSelected_Tick(object sender, EventArgs e)
        {
            timerItemSelected.Enabled = false;
            if (lvwServices.SelectedItems.Count > 0)
            {
                bool inAdminMode = IsAdmin();
                string machineName = lvwServices.SelectedItems[0].Group.Header;
                string serviceName = lvwServices.SelectedItems[0].Text;

                if (machineName.ToLower() == System.Environment.MachineName.ToLower() && !inAdminMode)
                {
                    startToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = false;
                    restartToolStripMenuItem.Enabled = false;
                }
                else
                {
                    startToolStripMenuItem.Enabled = (lvwServices.SelectedItems[0].ImageIndex != 0);
                    stopToolStripMenuItem.Enabled = (lvwServices.SelectedItems[0].ImageIndex != 1);
                    restartToolStripMenuItem.Enabled = (lvwServices.SelectedItems[0].ImageIndex != 1);
                }
            }
            else
            {
                startToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = false;
                restartToolStripMenuItem.Enabled = false;
            }
        } 
        #endregion

        #region Auto refreshing
        private void autoRefreshtoolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = autoRefreshtoolStripButton.Checked;
            if (autoRefreshtoolStripButton.Checked)
            {
                refreshTimer.Enabled = false;
                refreshTimer.Enabled = true;
                autoRefreshtoolStripButton.BackColor = Color.LightGreen;
            }
            else
            {
                refreshTimer.Enabled = false;
                autoRefreshtoolStripButton.BackColor = SystemColors.Control;
            }
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void autoRefreshToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshtoolStripButton.Checked = autoRefreshToolStripMenuItem.Checked;
        }
        #endregion

    }
}
