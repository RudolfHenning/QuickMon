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
    public partial class WMIQueryCollectorShowDetails : MiniDetailView, ICollectorDetailView
    {
        private const int MAXPREVIEWDISPLAYCOUNT = 100; 

        public WMIQueryCollectorShowDetails()
        {
            InitializeComponent();
            toolStripButtonExportData.Enabled = false;
        }

        public override void LoadDisplayData()
        {
            if (Collector != null)
            {
                WMIQueryCollectorConfig wmiConfig = (WMIQueryCollectorConfig)Collector.AgentConfig;
                lvwResults.Items.Clear();
                foreach (WMIQueryEntry wmiConfigEntry in wmiConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(wmiConfigEntry.Name);
                    lvi.SubItems.Add("");
                    lvi.Tag = wmiConfigEntry;
                    lvwResults.Items.Add(lvi);
                }
            }
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
                    WMIQueryEntry wmiConfigEntry = (WMIQueryEntry)lvi.Tag;
                    lvi.SubItems[1].Text = GetQIValue(lvi, wmiConfigEntry);
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

        private string GetQIValue(ListViewItem lvi, WMIQueryEntry wmiConfigEntry)
        {
            string results = "";
            try
            {
                object value = wmiConfigEntry.RunQuery();
                CollectorState currentstate = wmiConfigEntry.GetState(value);

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
        private string AttemptFieldRead(DataRow r, string name)
        {
            string returnValue = "";
            try
            {
                returnValue = FormatUtils.N(r[name], "[Null]");
            }
            catch { }
            return returnValue;
        }
        private void LoadDetailView()
        {
            lvwDetails.BeginUpdate();
            lvwDetails.Items.Clear();
            lvwDetails.Columns.Clear();
            if (lvwResults.SelectedItems.Count == 1 && lvwResults.SelectedItems[0].Tag is WMIQueryEntry)
            {
                WMIQueryEntry wmiConfigEntry = (WMIQueryEntry)lvwResults.SelectedItems[0].Tag;
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DataSet ds = wmiConfigEntry.RunDetailQuery();
                    if (wmiConfigEntry.ColumnNames == null || wmiConfigEntry.ColumnNames.Count == 0)
                    {
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
                    }
                    else
                    {
                        foreach (string colname in wmiConfigEntry.ColumnNames)
                        {
                            ColumnHeader newColumn = new ColumnHeader();
                            newColumn.Text = colname;
                            lvwDetails.Columns.Add(newColumn);
                        }
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            string firstColumnName = wmiConfigEntry.ColumnNames[0];
                            ListViewItem lvi = new ListViewItem(AttemptFieldRead(r, firstColumnName));
                            for (int i = 1; i < wmiConfigEntry.ColumnNames.Count; i++)
                            {
                                lvi.SubItems.Add(AttemptFieldRead(r, wmiConfigEntry.ColumnNames[i]));
                            }
                            lvwDetails.Items.Add(lvi);
                        }
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
            toolStripButtonExportData.Enabled = lvwResults.SelectedItems.Count > 0;
        }

        private void lvwResults_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails();
        }

        private void DisplaySelectedItemDetails()
        {
            string oldStatusText = toolStripStatusLabelDetails.Text;
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();

                //avoid cursor flickering when only a few items are selected
                //if (lvwDetails.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
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
    }
}
