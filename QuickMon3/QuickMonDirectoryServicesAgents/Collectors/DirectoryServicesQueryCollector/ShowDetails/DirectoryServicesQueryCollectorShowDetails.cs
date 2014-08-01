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
    public partial class DirectoryServicesQueryCollectorShowDetails : MiniDetailView, ICollectorDetailView
    {
        private const int MAXPREVIEWDISPLAYCOUNT = 100; 

        public DirectoryServicesQueryCollectorShowDetails()
        {
            InitializeComponent();
            toolStripButtonExportData.Enabled = false;
            toolStripButtonExportData.Visible = false;
        }

        public override void LoadDisplayData()
        {
            if (Collector != null)
            {
                DirectoryServicesQueryCollectorConfig wmiConfig = (DirectoryServicesQueryCollectorConfig)Collector.AgentConfig;
                lvwResults.Items.Clear();
                foreach (DirectoryServicesQueryCollectorConfigEntry dsQueryEntry in wmiConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(dsQueryEntry.Name);
                    lvi.SubItems.Add("");
                    lvi.Tag = dsQueryEntry;
                    lvwResults.Items.Add(lvi);
                }
                lvwResults.AutoResizeColumnIndex = 1;
                lvwResults.AutoResizeColumnEnabled = true;
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
                    DirectoryServicesQueryCollectorConfigEntry dsQueryEntry = (DirectoryServicesQueryCollectorConfigEntry)lvi.Tag;
                    lvi.SubItems[1].Text = GetQIValue(lvi, dsQueryEntry);
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
            //LoadDetailView();
            base.RefreshDisplayData();
        }
        private string GetQIValue(ListViewItem lvi, DirectoryServicesQueryCollectorConfigEntry dsQueryEntry)
        {
            string results = "";
            try
            {
                object value = dsQueryEntry.RunQuery();
                CollectorState currentstate = dsQueryEntry.GetState(value);

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
        private void LoadDetailView()
        {
            //lvwDetails.BeginUpdate();
            //lvwDetails.Items.Clear();
            //lvwDetails.Columns.Clear();
            if (lvwResults.SelectedItems.Count == 1 && lvwResults.SelectedItems[0].Tag is DirectoryServicesQueryCollectorConfigEntry)
            {
                DirectoryServicesQueryCollectorConfigEntry dsQueryEntry = (DirectoryServicesQueryCollectorConfigEntry)lvwResults.SelectedItems[0].Tag;
                try
                {
                    //Cursor.Current = Cursors.WaitCursor;
                    //DataSet ds = dsQueryEntry.RunDetailQuery();
                    //if (dsQueryEntry.ColumnNames == null || dsQueryEntry.ColumnNames.Count == 0)
                    //{
                    //    foreach (DataColumn currentDataColumn in ds.Tables[0].Columns)
                    //    {
                    //        ColumnHeader newColumn = new ColumnHeader();
                    //        newColumn.Tag = currentDataColumn;
                    //        newColumn.Text = currentDataColumn.Caption;

                    //        if ((currentDataColumn.DataType == typeof(UInt64)) || (currentDataColumn.DataType == typeof(UInt32)) || (currentDataColumn.DataType == typeof(UInt16)) ||
                    //            (currentDataColumn.DataType == typeof(Int64)) || (currentDataColumn.DataType == typeof(Int32)) || (currentDataColumn.DataType == typeof(Int16)))
                    //        {
                    //            newColumn.TextAlign = HorizontalAlignment.Right;
                    //        }
                    //        else
                    //        {
                    //            newColumn.TextAlign = HorizontalAlignment.Left;
                    //        }
                    //        lvwDetails.Columns.Add(newColumn);
                    //    }
                    //    foreach (DataRow r in ds.Tables[0].Rows)
                    //    {
                    //        ListViewItem lvi = new ListViewItem(FormatUtils.N(r[0], "[Null]"));
                    //        for (int i = 1; i < lvwDetails.Columns.Count; i++)
                    //        {
                    //            lvi.SubItems.Add(FormatUtils.N(r[i], "[Null]"));
                    //        }
                    //        lvwDetails.Items.Add(lvi);
                    //    }
                    //}
                    //else
                    //{
                    //    foreach (string colname in dsQueryEntry.ColumnNames)
                    //    {
                    //        ColumnHeader newColumn = new ColumnHeader();
                    //        newColumn.Text = colname;
                    //        lvwDetails.Columns.Add(newColumn);
                    //    }
                    //    foreach (DataRow r in ds.Tables[0].Rows)
                    //    {
                    //        string firstColumnName = dsQueryEntry.ColumnNames[0];
                    //        ListViewItem lvi = new ListViewItem(AttemptFieldRead(r, firstColumnName));
                    //        for (int i = 1; i < dsQueryEntry.ColumnNames.Count; i++)
                    //        {
                    //            lvi.SubItems.Add(AttemptFieldRead(r, dsQueryEntry.ColumnNames[i]));
                    //        }
                    //        lvwDetails.Items.Add(lvi);
                    //    }
                    //}
                    //lvwDetails.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
            //lvwDetails.EndUpdate();
            toolStripButtonExportData.Enabled = lvwResults.SelectedItems.Count > 0;
        }

        private void DirectoryServicesQueryCollectorShowDetails_Load(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = true;
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "uuu" : "ttt";
            splitContainerDetails.SplitterWidth = 6;
        }

        private void lvwResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
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
                Cursor.Current = Cursors.WaitCursor;
                foreach (ListViewItem lvi in (from ListViewItem l in lvwResults.SelectedItems
                                              select l).Take(MAXPREVIEWDISPLAYCOUNT))
                {
                    for (int i = 0; i < lvwResults.Columns.Count; i++)
                    {
                        rtfBuilder.FontStyle(FontStyle.Bold).Append(lvwResults.Columns[i].Text + ": ").AppendLine(lvi.SubItems[i].Text);
                    }
                    rtfBuilder.FontStyle(FontStyle.Underline).AppendLine(new String(' ', 250));
                    rtfBuilder.AppendLine();
                }
                if (lvwResults.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("Only first {0} entries shown...", MAXPREVIEWDISPLAYCOUNT));
                }
                else if (lvwResults.SelectedItems.Count == 0)
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("No entries selected");
                else
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("{0} entry(s)", lvwResults.SelectedItems.Count));
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
