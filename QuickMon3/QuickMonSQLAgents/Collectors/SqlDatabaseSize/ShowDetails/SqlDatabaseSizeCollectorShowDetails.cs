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
    public partial class SqlDatabaseSizeCollectorShowDetails : SimpleDetailView, ICollectorDetailView
    {
        public SqlDatabaseSizeCollectorShowDetails()
        {
            InitializeComponent();
        }

        #region Overrides
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                SqlDatabaseSizeCollectorConfig sqlQueryConfig = (SqlDatabaseSizeCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (SqlDatabaseSizeEntry dbSizeEntry in sqlQueryConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(dbSizeEntry.ToString());
                    lvi.SubItems.Add("-");
                    lvi.Tag = dbSizeEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadDisplayData();
        }
        public override void RefreshDisplayData()
        {
            try
            {
                lvwEntries.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    SqlDatabaseSizeEntry dbSizeEntry = (SqlDatabaseSizeEntry)lvi.Tag;
                    long size = dbSizeEntry.GetDBSize();
                    lvi.SubItems[1].Text = size.ToString();
                    CollectorState currentState = dbSizeEntry.GetState(size);
                    if (currentState == CollectorState.Good)
                        lvi.ImageIndex = 0;
                    else if (currentState == CollectorState.Warning)
                        lvi.ImageIndex = 1;
                    else
                        lvi.ImageIndex = 2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                lvwEntries.EndUpdate();
            }
            base.RefreshDisplayData();
        }
        #endregion
    }
}
