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
    public partial class ShowDetails : Form
    {
        public SoapWebServicePingConfig SoapWebServicePingConfig { get; set; }

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            LoadList();
            ShowDetails_Resize(null, null);
        }
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
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

                    soapWebServicePingConfigEntry.CheckResultMatch(obj, soapWebServicePingConfigEntry.ResultType,
                        soapWebServicePingConfigEntry.CustomValue1, soapWebServicePingConfigEntry.CustomValue2, out formattedVal);
                    itmX.SubItems[1].Text = formattedVal;

                    //if (obj == null)
                    //    itmX.SubItems[1].Text = "Null";
                    //else if (obj is string && (string)obj == "")
                    //    itmX.SubItems[1].Text = "Empty string";
                    //else if (obj is DataSet)
                    //    itmX.SubItems[1].Text = "DataSet";
                    //else
                        
                }
                catch (Exception ex)
                {
                    itmX.SubItems[1].Text = ex.Message;
                }
            }
            lvwHosts.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion 
    }


}
