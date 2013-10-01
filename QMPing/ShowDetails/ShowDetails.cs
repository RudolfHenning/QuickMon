using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace QuickMon
{
    public partial class ShowDetails : Form, ICollectorDetailView
    {
        public List<HostEntry> HostEntries { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            HostEntries = null;
            HostEntries = ((Ping)collector).HostEntries;
            LoadList();
            RefreshList();
            ShowDetails_Resize(null, null);
        }
        public void RefreshConfig(ICollector collector)
        {
            HostEntries = null;
            HostEntries = ((Ping)collector).HostEntries;
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
            base.Show();
            LoadList();
            RefreshList();
            ShowDetails_Resize(null, null);
        }        
        #endregion

        #region ListView events
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwHosts.Columns[0].Width = lvwHosts.ClientSize.Width - lvwHosts.Columns[1].Width - lvwHosts.Columns[2].Width;
        }
        #endregion

        #region Context menu events
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Toolbar events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region Local methods
        private void LoadList()
        {
            if (HostEntries != null)
            {
                lvwHosts.Items.Clear();
                foreach (var hostEntry in HostEntries)
                {
                    ListViewItem lvi = new ListViewItem(hostEntry.HostName);
                    lvi.ImageIndex = 0;
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.Tag = hostEntry;
                    lvwHosts.Items.Add(lvi);
                }
            }
        } 
        private void RefreshList()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwHosts.BeginUpdate();
            foreach (ListViewItem itmX in lvwHosts.Items)
            {
                HostEntry host = (HostEntry)itmX.Tag;
                try
                {
                    PingResult pingResult = host.Ping();
                    MonitorStates result = host.GetState(pingResult);
                    if (pingResult.Success)
                    {
                        itmX.SubItems[1].Text = pingResult.PingTime.ToString();
                        itmX.SubItems[2].Text = pingResult.LastErrorMsg;
                        if (result == MonitorStates.Good)
                        {
                            itmX.ImageIndex = 0;
                            itmX.BackColor = SystemColors.Window;
                        }
                        else if (result == MonitorStates.Warning)
                        {
                            itmX.ImageIndex = 1;
                            itmX.BackColor = Color.SandyBrown;
                        }
                        else
                        {
                            itmX.ImageIndex = 2;
                            itmX.BackColor = Color.Salmon;
                        }
                    }
                    else
                    {
                        itmX.ImageIndex = 2;
                        itmX.BackColor = Color.Salmon; 
                        itmX.SubItems[1].Text = "Err";
                        itmX.SubItems[2].Text = pingResult.LastErrorMsg;
                    }
                }
                catch (Exception ex)
                {
                    itmX.ImageIndex = 2;
                    itmX.SubItems[1].Text = "Err";
                    itmX.SubItems[2].Text = ex.Message;
                    itmX.BackColor = Color.Salmon; 
                }
            }
            lvwHosts.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region Auto refreshing
        private void autoRefreshtoolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripMenuItem.Checked = autoRefreshToolStripButton.Checked;
            if (autoRefreshToolStripButton.Checked)
            {
                refreshTimer.Enabled = false;
                refreshTimer.Enabled = true;
                autoRefreshToolStripButton.BackColor = Color.LightGreen;
            }
            else
            {
                refreshTimer.Enabled = false;
                autoRefreshToolStripButton.BackColor = SystemColors.Control;
            }
        }
        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void autoRefreshToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            autoRefreshToolStripButton.Checked = autoRefreshToolStripMenuItem.Checked;
        }
        #endregion        
    }
}
