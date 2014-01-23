using System;
using System.Drawing;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class PerfCounterShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public PerfCounterShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public override void LoadDisplayData()
        {
            lvwEntries.Items.Clear();
            foreach (PerfCounterCollectorEntry pc in ((PerfCounterCollectorConfig)Collector.AgentConfig).Entries)
            {
                ListViewItem lvi = new ListViewItem(pc.ToString());
                lvi.ImageIndex = 0;
                lvi.SubItems.Add("-");
                lvi.SubItems.Add(pc.WarningValue.ToString("F1") + "/" + pc.ErrorValue.ToString("F1"));
                lvi.Tag = pc;
                lvwEntries.Items.Add(lvi);
            }
        }
        public override void RefreshDisplayData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                lvwEntries.BeginUpdate();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    try
                    {
                        PerfCounterCollectorEntry pc = (PerfCounterCollectorEntry)lvi.Tag;
                        float currentValue = pc.GetNextValue();
                        lvi.SubItems[1].Text = currentValue.ToString("F3");
                        CollectorState currentState = pc.GetState(currentValue);
                        if (currentState == CollectorState.Good)
                        {
                            lvi.ImageIndex = 0;
                            lvi.BackColor = SystemColors.Window;
                        }
                        else if (currentState == CollectorState.Warning)
                        {
                            lvi.ImageIndex = 1;
                            lvi.BackColor = Color.SandyBrown;
                        }
                        else
                        {
                            lvi.ImageIndex = 2;
                            lvi.BackColor = Color.Salmon;
                        }
                    }
                    catch (Exception ex)
                    {
                        lvi.SubItems[1].Text = ex.Message;
                    }
                }
                toolStripStatusLabelDetails.Text = "Last updated: " + DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lvwEntries.EndUpdate();
            Cursor.Current = Cursors.Default;
        }
        #endregion
    }
}
