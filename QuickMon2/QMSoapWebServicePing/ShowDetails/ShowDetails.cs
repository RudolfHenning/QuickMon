using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class ShowDetails : Form, ICollectorDetailView
    {
        public SoapWebServicePingConfig SoapWebServicePingConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            SoapWebServicePingConfig = null;
            SoapWebServicePingConfig = ((SoapWebServicePing)collector).SoapWebServicePingConfig;
            LoadList();
            RefreshList();
            ShowDetails_Resize(null, null);
        }
        public void RefreshConfig(ICollector collector)
        {
            SoapWebServicePingConfig = null;
            SoapWebServicePingConfig = ((SoapWebServicePing)collector).SoapWebServicePingConfig;
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

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            //LoadList();
            //ShowDetails_Resize(null, null);
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            //RefreshList();
        }
        private void ShowDetails_Resize(object sender, EventArgs e)
        {
            lvwHosts.Columns[0].Width = lvwHosts.ClientSize.Width - lvwHosts.Columns[1].Width;
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
            if (SoapWebServicePingConfig != null)
            {
                lvwHosts.Items.Clear();
                foreach (SoapWebServicePingConfigEntry soapWebServicePingConfigEntry in SoapWebServicePingConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(string.Format("{0}\\{1}", soapWebServicePingConfigEntry.ServiceBaseURL, soapWebServicePingConfigEntry.MethodName));
                    lvi.SubItems.Add("-");
                    lvi.Tag = soapWebServicePingConfigEntry;
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
                SoapWebServicePingConfigEntry soapWebServicePingConfigEntry = (SoapWebServicePingConfigEntry)itmX.Tag;
                try
                {
                    object obj = soapWebServicePingConfigEntry.ExecuteMethod();
                    string formattedVal = "";

                    bool success = soapWebServicePingConfigEntry.CheckResultMatch(obj, soapWebServicePingConfigEntry.ResultType,
                        soapWebServicePingConfigEntry.CustomValue1, soapWebServicePingConfigEntry.CustomValue2, out formattedVal);
                    itmX.SubItems[1].Text = formattedVal;
                    if (success)
                    {
                        itmX.ImageIndex = 0;
                        itmX.BackColor = SystemColors.Window;
                    }
                    else
                    {
                        itmX.ImageIndex = 2;
                        itmX.BackColor = Color.Salmon;
                    }                       
                }
                catch (Exception ex)
                {
                    itmX.SubItems[1].Text = ex.Message;
                    itmX.ImageIndex = 2;
                    itmX.BackColor = Color.Salmon;
                }
            }
            lvwHosts.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion 

        #region Auto refreshing
        private void autoRefreshToolStripButton_CheckStateChanged(object sender, EventArgs e)
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
