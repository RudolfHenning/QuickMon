using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.RTF;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class SqlQueryCollectorShowDetails : MiniDetailView, ICollectorDetailView
    {
        public SqlQueryCollectorShowDetails()
        {
            InitializeComponent();
            refreshContextMenuStrip.Items.AddRange(new ToolStripItem[] {
                toolStripMenuItem1,
                editSQLQuerylocalCopyToolStripMenuItem
            });
        }

        private const int MAXPREVIEWDISPLAYCOUNT = 100;

        #region Form events
        private void SqlQueryCollectorShowDetails_Load(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = true;
            ExportButtonVisible = false;
        }
        #endregion

        #region Overrides
        public override void RunExport()
        {
            try
            {
                if (lvwResults.SelectedItems.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(lvwDetails.Columns[0].Text);
                    for (int i = 1; i < lvwDetails.Columns.Count; i++)
                    {
                        ColumnHeader h = lvwDetails.Columns[i];
                        sb.Append("," + h.Text);
                    }
                    sb.AppendLine();
                    foreach (ListViewItem lvi in lvwDetails.Items)
                    {
                        sb.Append(lvi.Text);
                        for (int i = 1; i < lvwDetails.Columns.Count; i++)
                        {
                            if (lvi.SubItems[i].Text.Contains(','))
                                sb.Append(",\"" + lvi.SubItems[i].Text + "\"");
                            else
                                sb.Append("," + lvi.SubItems[i].Text);
                        }
                        sb.AppendLine();
                    }
                    if (saveFileDialogCSV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialogCSV.FileName, sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override void LoadDisplayData()
        {
            if (Collector != null && Collector.AgentConfig != null)
            {
                SqlQueryCollectorConfig sqlQueryConfig = (SqlQueryCollectorConfig)Collector.AgentConfig;
                lvwResults.Items.Clear();
                foreach (QueryInstance queryInstance in sqlQueryConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.SubItems.Add(GetQIValue(lvi, queryInstance));
                    lvi.Tag = queryInstance;
                    lvwResults.Items.Add(lvi);
                }
            }
            ExportButtonVisible = lvwResults.Items.Count > 0;
            base.LoadDisplayData();
        }
        public override void RefreshDisplayData()
        {
            try
            {
                lvwResults.BeginUpdate();
                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem lvi in lvwResults.Items)
                {
                    QueryInstance queryInstance = (QueryInstance)lvi.Tag;
                    lvi.SubItems[1].Text = GetQIValue(lvi, queryInstance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                lvwResults.EndUpdate();
            }
            LoadDetailView();
            base.RefreshDisplayData();
        }
        #endregion

        #region ListView events
        private void lvwResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            editSQLQuerylocalCopyToolStripMenuItem.Enabled = lvwResults.SelectedItems.Count == 1;
            LoadDetailView();
        }

        private void lvwDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            if (lvwDetails.SelectedItems.Count > 0)
                toolStripStatusLabelDetails.Text = lvwDetails.SelectedItems.Count.ToString() + " item(s) selected";
            else
                toolStripStatusLabelDetails.Text = "0 items selected";
            timerSelectItem.Enabled = true;
        }
        #endregion

        #region Timer events
        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails();
        }
        #endregion

        #region Button events
        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "ttt" : "uuu";
            splitContainerDetails.SplitterWidth = 8;
        }
        #endregion

        #region Private methods
        private void LoadDetailView()
        {
            lvwDetails.BeginUpdate();
            lvwDetails.Items.Clear();
            lvwDetails.Columns.Clear();
            if (lvwResults.SelectedItems.Count >= 1 && lvwResults.SelectedItems[0].Tag is QueryInstance)
            {
                QueryInstance queryInstance = (QueryInstance)lvwResults.SelectedItems[0].Tag;
                try
                {

                    Cursor.Current = Cursors.WaitCursor;
                    DataSet ds = queryInstance.RunDetailQuery();
                    foreach (DataColumn currentDataColumn in ds.Tables[0].Columns)
                    {
                        ColumnHeader newColumn = new ColumnHeader();
                        newColumn.Tag = currentDataColumn;
                        newColumn.Text = currentDataColumn.Caption;

                        if ((currentDataColumn.DataType == typeof(UInt64)) || (currentDataColumn.DataType == typeof(UInt32)) || (currentDataColumn.DataType == typeof(UInt16)) ||
                            (currentDataColumn.DataType == typeof(Int64)) || (currentDataColumn.DataType == typeof(Int32)) || (currentDataColumn.DataType == typeof(Int16)))
                        {
                            newColumn.TextAlign = HorizontalAlignment.Right;
                        }
                        else
                        {
                            newColumn.TextAlign = HorizontalAlignment.Left;
                        }
                        lvwDetails.Columns.Add(newColumn);
                    }
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        ListViewItem lvi = new ListViewItem(FormatUtils.N(r[0], "[Null]"));
                        for (int i = 1; i < lvwDetails.Columns.Count; i++)
                        {
                            lvi.SubItems.Add(FormatUtils.N(r[i], "[Null]"));
                        }
                        lvwDetails.Items.Add(lvi);
                    }
                    lvwDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "View details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            lvwDetails.EndUpdate();
            ExportButtonVisible = lvwResults.SelectedItems.Count > 0;
        }
        private void DisplaySelectedItemDetails()
        {
            string oldStatusText = toolStripStatusLabelDetails.Text;
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();

                //avoid cursor flickering when only a few items are selected
                Cursor.Current = Cursors.WaitCursor;
                //have to limit the maximum number of selected items
                foreach (ListViewItem lvi in (from ListViewItem l in lvwDetails.SelectedItems
                                              select l).Take(MAXPREVIEWDISPLAYCOUNT))
                {
                    for (int i = 0; i < lvwDetails.Columns.Count; i++)
                    {
                        rtfBuilder.FontStyle(FontStyle.Bold).Append(lvwDetails.Columns[i].Text + ": ").AppendLine(lvi.SubItems[i].Text);
                    }
                    rtfBuilder.FontStyle(FontStyle.Underline).AppendLine(new String(' ', 250));
                    rtfBuilder.AppendLine();
                }
                if (lvwDetails.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("Only first {0} entries shown...", MAXPREVIEWDISPLAYCOUNT));
                }
                else if (lvwDetails.SelectedItems.Count == 0)
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("No entries selected");
                else
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("{0} entry(s)", lvwDetails.SelectedItems.Count));
                }
                rtxDetails.Rtf = rtfBuilder.ToString();
                rtxDetails.SelectionStart = 0;
                rtxDetails.SelectionLength = 0;
                rtxDetails.ScrollToCaret();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                toolStripStatusLabelDetails.Text = oldStatusText;
            }

        }
        private string GetQIValue(ListViewItem lvi, QueryInstance queryInstance)
        {
            string results = "";
            try
            {
                object value = queryInstance.RunQuery();
                CollectorState currentstate = queryInstance.GetState(value);

                results = FormatUtils.N(value, "[null]");
                if (currentstate == CollectorState.Error)
                    lvi.ImageIndex = 3;
                else if (currentstate == CollectorState.Warning)
                    lvi.ImageIndex = 2;
                else
                    lvi.ImageIndex = 1;
            }
            catch (Exception ex)
            {
                results = ex.Message;
            }
            return results;
        }
        #endregion

        #region Context menu events
        private void editSQLQuerylocalCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwResults.SelectedItems.Count > 0)
            {
                bool autoRefreshTemp = refreshTimer.Enabled;
                refreshTimer.Enabled = false;
                QueryInstance queryInstance = (QueryInstance)lvwResults.SelectedItems[0].Tag;
                EditSqlQuery editDetailQuery = new EditSqlQuery();
                editDetailQuery.SelectedQueryInstance = queryInstance;
                if (editDetailQuery.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    lvwResults.SelectedItems[0].Tag = editDetailQuery.SelectedQueryInstance;
                refreshTimer.Enabled = autoRefreshTemp;
            }
        }
        #endregion

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.SelectAll();
        }
    }
}
