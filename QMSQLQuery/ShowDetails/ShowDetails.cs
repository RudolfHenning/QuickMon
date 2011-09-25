using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.RTF;

namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        private const int MAXPREVIEWDISPLAYCOUNT = 100;

        public SQLQueryConfig SQLQueryConfig { get; set; }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            lvwResults.Items.Clear();
            if (SQLQueryConfig != null)
            {
                foreach (QueryInstance queryInstance in SQLQueryConfig.Queries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.SubItems.Add(GetQIValue(lvi, queryInstance));
                    lvi.Tag = queryInstance;
                    lvwResults.Items.Add(lvi);
                }
            }
        }

        private void RefreshList()
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
        }

        private string GetQIValue(ListViewItem lvi, QueryInstance queryInstance)
        {
            string results = "";
            try
            {
                bool errorCondition = false;
                bool warningCondition = false;
                object value = null;

                if (!queryInstance.ReturnValueIsNumber)
                {
                    value = queryInstance.RunQueryWithSingleResult();
                }
                else
                {
                    if (queryInstance.UseRowCountAsValue)
                    {
                        value = queryInstance.RunQueryWithCountResult();
                    }
                    else
                    {
                        value = queryInstance.RunQueryWithSingleResult();
                    }
                }
                if (value == DBNull.Value)
                {
                    if (queryInstance.ErrorValue == "[null]")
                        errorCondition = true;
                    else if (queryInstance.WarningValue == "[null]")
                        warningCondition = true;
                }
                else //non null value
                {
                    if (!queryInstance.ReturnValueIsNumber)
                    {
                        if (value.ToString() == queryInstance.ErrorValue)
                            errorCondition = true;
                        else if (value.ToString() == queryInstance.WarningValue)
                            warningCondition = true;
                        else if (value.ToString() == queryInstance.SuccessValue || queryInstance.SuccessValue == "[any]")
                            warningCondition = false; //just to flag condition
                        else if (queryInstance.WarningValue == "[any]")
                            warningCondition = true;
                        else if (queryInstance.ErrorValue == "[any]")
                            errorCondition = true;
                    }
                    else //now we know the value is not null and must be in a range
                    {
                        if (!value.IsNumber()) //value must be a number!
                        {
                            errorCondition = true;
                        }
                        else if (queryInstance.ErrorValue != "[any]" && queryInstance.ErrorValue != "[null]" &&
                                (
                                 (!queryInstance.ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(queryInstance.ErrorValue)) ||
                                 (queryInstance.ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(queryInstance.ErrorValue))
                                )
                            )
                        {
                            errorCondition = true;
                        }
                        else if (queryInstance.WarningValue != "[any]" && queryInstance.WarningValue != "[null]" &&
                               (
                                (!queryInstance.ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(queryInstance.WarningValue)) ||
                                (queryInstance.ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(queryInstance.WarningValue))
                               )
                            )
                        {
                            warningCondition = true;
                        }
                    }
                }
                results = FormatUtils.N(value, "[null]");
                if (errorCondition)
                    lvi.ImageIndex = 3;
                else if (warningCondition)
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

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void lvwResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDetailView();
        }

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
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = true;
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "ttt" : "uuu";
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
            RTFBuilder rtfBuilder = new RTFBuilder();

            //avoid cursor flickering when only a few items are selected
            if (lvwDetails.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                Cursor.Current = Cursors.WaitCursor;
            //have to limit the maximum number of selected items
            foreach (ListViewItem lvi in (from ListViewItem l in lvwDetails.SelectedItems
                                          select l).Take(MAXPREVIEWDISPLAYCOUNT))
            {
                for (int i = 0; i < lvwDetails.Columns.Count;i++ )
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
            Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = oldStatusText;
        }

    }
}
