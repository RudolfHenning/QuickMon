using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public partial class DataTableViewerControl : UserControl
    {
        public DataTableViewerControl()
        {
            InitializeComponent();
            AutoResizeColumnIndex = 0;
            GroupByColumn = -1;
            lvwDataTable.KeyDown += lvwDataTableKeyDown;
            lvwDataTable.SelectedIndexChanged += lvwDataTable_SelectedIndexChanged;
        }

       

        public int GroupByColumn { get; set; }
        public DataTable SelectedData { get; set; }
        public int AutoResizeColumnIndex
        {
            get { return lvwDataTable.AutoResizeColumnIndex; }
            set
            {
                lvwDataTable.AutoResizeColumnIndex = value;
                lvwDataTable.TriggerAutoColumnResize();
            }
        }
        public ContextMenuStrip ListContextMenu
        {
            get { return lvwDataTable.ContextMenuStrip; }
            set { lvwDataTable.ContextMenuStrip = value; }
        }
        public string DefaultTabName { get; set; }

        public event EventHandler ListSelectedIndexChanged;
        private ListViewColumnSorter listViewColumnSorter = null;

        public void LoadColumns()
        {
            if (SelectedData != null)
            {
                List<SortColumnType> sortTypes = new List<SortColumnType>();
                lvwDataTable.ListViewItemSorter = null;
                lvwDataTable.Columns.Clear();
                for (int i = 0; i < SelectedData.Columns.Count; i++)
                {
                    if (GroupByColumn == -1 || GroupByColumn != i)
                    {
                        DataColumn dcol = SelectedData.Columns[i];
                        string columnName = dcol.ColumnName;
                        if (dcol.ExtendedProperties.ContainsKey("groupby"))
                        {
                            GroupByColumn = lvwDataTable.Columns.Count;
                        }                        
                        else
                        {
                            ColumnHeader lcol = lvwDataTable.Columns.Add(columnName);
                            if (dcol.DataType.Name == "Int32")
                            {
                                lcol.TextAlign = HorizontalAlignment.Right;
                                sortTypes.Add(SortColumnType.NumberType);
                            }
                            else if (dcol.DataType.Name == "DateTime")
                            {
                                sortTypes.Add(SortColumnType.DateType);
                            }
                            else
                                sortTypes.Add(SortColumnType.StringType);
                        }
                    }
                }
                listViewColumnSorter = new ListViewColumnSorter(lvwDataTable, true, sortTypes.ToArray());
                lvwDataTable.ListViewItemSorter = listViewColumnSorter;
            }
        }
        public void RefreshData(bool forceColumnResize = false)
        {
            if (SelectedData != null)
            {
                try
                {
                    listViewColumnSorter.Disable();
                    lvwDataTable.AutoResizeColumnEnabled = false;
                    lvwDataTable.BeginUpdate();
                    lvwDataTable.Items.Clear();
                    lvwDataTable.Groups.Clear();
                    if (GroupByColumn > -1 && GroupByColumn < SelectedData.Columns.Count)
                    {
                        lvwDataTable.ShowGroups = true;
                        lvwDataTable.Groups.AddRange((from DataRow r in SelectedData.Rows
                                                    group r by FormatField(r[GroupByColumn]) into g
                                                    orderby g.Key
                                                    select new ListViewGroup(g.Key)).ToArray());
                    }
                    else
                        lvwDataTable.ShowGroups = false;

                    Cursor.Current = Cursors.WaitCursor;
                    foreach (DataRow drow in SelectedData.Rows)
                    {
                        string firstValue;
                        if (GroupByColumn == -1 || GroupByColumn != 0)
                            firstValue = FormatField(drow[0]);
                        else
                            firstValue = FormatField(drow[1]);
                        ListViewItem lvi = new ListViewItem(firstValue);
                        for (int i = 1; i < SelectedData.Columns.Count; i++)
                        {
                            if (!(GroupByColumn == 0 && i == 1) && GroupByColumn != i) //first column is group by and second is already "firstvalue"
                            {
                                string colVal = FormatField(drow[i]);
                                lvi.SubItems.Add(colVal);
                            }
                        }
                        if (GroupByColumn > -1)
                        {
                            lvi.Group = (from ListViewGroup lg in lvwDataTable.Groups
                                         where lg.Header == FormatField(drow[GroupByColumn])
                                         select lg).FirstOrDefault();
                        }
                        lvi.Tag = drow;
                        lvwDataTable.Items.Add(lvi);
                    }
                    foreach (ListViewGroup lvg in lvwDataTable.Groups)
                    {
                        lvwDataTable.SetGroupState(lvg, ListViewGroupState.Collapsible);
                        lvwDataTable.SetGroupFooter(lvg, (from ListViewItem lvi in lvwDataTable.Items
                                                        where lvi.Group == lvg
                                                        select lvi).Count().ToString() + " item(s)");
                    }
                    if (forceColumnResize)
                        for (int i = 0; i < lvwDataTable.Columns.Count; i++)
                            //if (i != AutoResizeColumnIndex)
                                lvwDataTable.Columns[i].Width = -2;
                }
                catch { }
                finally
                {
                    lvwDataTable.EndUpdate();
                    if (AutoResizeColumnIndex > -1)
                        lvwDataTable.AutoResizeColumnIndex = AutoResizeColumnIndex;
                    else
                        lvwDataTable.AutoResizeColumnIndex = lvwDataTable.Columns.Count - 1;
                    lvwDataTable.AutoResizeColumnEnabled = true;
                    listViewColumnSorter.Enable();
                }
            }
        }
        public DataSet GetSelectedItems()
        {
            DataSet selectedStuff = new DataSet();
            DataTable tab = selectedStuff.Tables.Add("Test");
            tab.Columns.AddRange((from DataColumn dc in SelectedData.Columns
                                  select new DataColumn(dc.ColumnName, dc.DataType)).ToArray());

            if (lvwDataTable.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwDataTable.SelectedItems)
                {
                    if (lvi.Tag is DataRow)
                    {
                        DataRow oldRow = (DataRow)lvi.Tag;
                        object[] values = new object[SelectedData.Columns.Count];
                        for (int i = 0; i < values.Length; i++)
                            values[i] = oldRow[i];
                        tab.Rows.Add(values);
                    }
                }
            }
            return selectedStuff;
        }
        private string FormatField(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return "";
            }
            else if (value.GetType().IsArray)
            {
                StringBuilder sb = new StringBuilder();
                Array arr = (Array)value;
                foreach (object arrItem in arr)
                    sb.AppendFormat("{0},", arrItem);
                return sb.ToString().Trim(',');
            }
            else
            {
                return value.ToString();
            }
        }

        private void DataTableViewerControl_Load(object sender, EventArgs e)
        {
            //LoadColumns();
            //RefreshData(true);
            //lvwDataTable.AutoResizeColumnIndex = AutoResizeColumnIndex;
            //lvwDataTable.AutoResizeColumnEnabled = true;
        }

        private void lvwDataTableKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                lvwDataTable.BeginUpdate();
                lvwDataTable.SelectedItems.Clear();
                foreach (ListViewItem lvi in lvwDataTable.Items)
                    lvi.Selected = true;
                lvwDataTable.EndUpdate();
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (GroupByColumn > -1)
                {
                    lvwDataTable.BeginUpdate();
                    if (e.Control)
                    {
                        foreach (ListViewGroup lg in lvwDataTable.Groups)
                        {
                            lvwDataTable.SetGroupState(lg, ListViewGroupState.Collapsible | ListViewGroupState.Collapsed);
                        }
                    }
                    else
                    {
                        if (lvwDataTable.SelectedItems.Count > 0 && lvwDataTable.SelectedItems[0].Group != null)
                        {
                            lvwDataTable.SetGroupState(lvwDataTable.SelectedItems[0].Group, ListViewGroupState.Collapsible | ListViewGroupState.Collapsed);
                        }
                    }
                    lvwDataTable.EndUpdate();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (GroupByColumn > -1)
                {
                    lvwDataTable.BeginUpdate();
                    if (e.Control)
                    {
                        foreach (ListViewGroup lg in lvwDataTable.Groups)
                        {
                            lvwDataTable.SetGroupState(lg, ListViewGroupState.Collapsible | ListViewGroupState.Normal);
                        }
                    }
                    else
                    {
                        if (lvwDataTable.SelectedItems.Count > 0 && lvwDataTable.SelectedItems[0].Group != null)
                        {
                            ListViewItem lvi = lvwDataTable.SelectedItems[0];
                            lvwDataTable.SetGroupState(lvwDataTable.SelectedItems[0].Group, ListViewGroupState.Collapsible | ListViewGroupState.Normal);
                            lvwDataTable.SelectedItems.Clear();
                            lvi.Selected = true;
                            lvi.EnsureVisible();
                        }
                    }
                    lvwDataTable.EndUpdate();
                }
            }
        }
        private void lvwDataTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListSelectedIndexChanged != null)
            {
                ListSelectedIndexChanged(sender, e);
            }
        }
    }
}
