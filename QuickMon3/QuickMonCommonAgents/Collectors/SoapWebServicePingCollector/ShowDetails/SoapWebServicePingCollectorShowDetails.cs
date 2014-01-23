using System;
using System.Drawing;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class SoapWebServicePingCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public SoapWebServicePingCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null)
            {
                SoapWebServicePingCollectorConfig config = (SoapWebServicePingCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (SoapWebServicePingConfigEntry soapWebServicePingConfigEntry in config.Entries)
                {
                    ListViewItem lvi = new ListViewItem(string.Format("{0}\\{1}", soapWebServicePingConfigEntry.ServiceBaseURL, soapWebServicePingConfigEntry.MethodName));
                    lvi.SubItems.Add("-");
                    lvi.Tag = soapWebServicePingConfigEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
        }
        public override void RefreshDisplayData()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            lvwEntries.BeginUpdate();
            foreach (ListViewItem itmX in lvwEntries.Items)
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
            lvwEntries.EndUpdate();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion
    }
}
