using System;
using System.Drawing;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class PingCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public PingCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                PingCollectorConfig pc = (PingCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (PingCollectorHostEntry hostEntry in pc.Entries)
                {
                    ListViewItem lvi = new ListViewItem(hostEntry.ToString());
                    lvi.ImageIndex = 0;
                    lvi.SubItems.Add("-");
                    lvi.SubItems.Add("-");
                    lvi.Tag = hostEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
        }
        public override void RefreshDisplayData()
        {        
            try
            {
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                lvwEntries.BeginUpdate();
                foreach (ListViewItem itmX in lvwEntries.Items)
                {
                    PingCollectorHostEntry host = (PingCollectorHostEntry)itmX.Tag;
                    try
                    {
                        PingCollectorResult pingResult = host.Ping();
                        CollectorState result = host.GetState(pingResult);
                        if (pingResult.Success)
                        {
                            itmX.SubItems[1].Text = pingResult.PingTime.ToString() + " ms";
                            itmX.SubItems[2].Text = pingResult.ResponseDetails;
                            if (result == CollectorState.Good)
                            {
                                itmX.ImageIndex = 0;
                                itmX.BackColor = SystemColors.Window;
                            }
                            else if (result == CollectorState.Warning)
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
                            if (pingResult.PingTime < 0)
                                itmX.SubItems[1].Text = "Err";
                            itmX.SubItems[2].Text = pingResult.ResponseDetails;
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
                lvwEntries.EndUpdate();
                System.Windows.Forms.Cursor.Current = Cursors.Default;
                toolStripStatusLabelDetails.Text = "Last updated " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            finally
            {
                
            }
        }
        #endregion

    }
}
