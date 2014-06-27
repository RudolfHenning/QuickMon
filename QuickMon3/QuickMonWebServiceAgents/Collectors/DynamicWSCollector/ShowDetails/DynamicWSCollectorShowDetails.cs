using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class DynamicWSCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public DynamicWSCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            if (Collector != null)
            {
                DynamicWSCollectorConfig config = (DynamicWSCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (DynamicWSCollectorConfigEntry entry in config.Entries)
                {
                    ListViewItem lvi = new ListViewItem(string.Format("{0}\\{1}", entry.ServiceBaseURL, entry.MethodName));
                    lvi.SubItems.Add("-");
                    lvi.Tag = entry;
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
                DynamicWSCollectorConfigEntry entry = (DynamicWSCollectorConfigEntry)itmX.Tag;
                try
                {
                    object obj = entry.RunMethod();

                    CollectorState state = entry.GetState(obj);
                    itmX.SubItems[1].Text = entry.LastFormattedValue;
                    if (state == CollectorState.Good)
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
