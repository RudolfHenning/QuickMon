using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        public WMIConfig WmiIConfig { get; set; }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            if (WmiIConfig != null)
            {
                try
                {
                    DataSet data = WmiIConfig.RunDetailQuery();

                    lvwResults.BeginUpdate();
                    lvwResults.Items.Clear();
                    if (data != null && data.Tables.Count > 0 && lvwResults.Columns.Count > 0)
                    {
                        foreach (DataRow r in data.Tables[0].Rows)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = r[lvwResults.Columns[0].Text].ToString();
                            for (int i = 1; i < lvwResults.Columns.Count; i++)
                            {
                                ColumnHeader columnHeader = lvwResults.Columns[i];
                                lvi.SubItems.Add(r[columnHeader.Text].ToString());
                            }
                            lvwResults.Items.Add(lvi);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwResults.EndUpdate();
                    
                }
            }
        }

        private void ShowDetails_Load(object sender, EventArgs e)
        {
            if (WmiIConfig != null)
            {
                lvwResults.Columns.Clear();
                List<string> columnNames = new List<string>();
                List<DataColumn> dataColumns = WmiIConfig.GetDetailQueryColumns();
                if (WmiIConfig.ColumnNames.Count > 0)
                {
                    if (!WmiIConfig.ColumnNames.Contains("Machine"))
                    {
                        columnNames.Add("Machine");
                    }
                    columnNames.AddRange(WmiIConfig.ColumnNames.ToArray());
                }
                else
                {
                    dataColumns.ForEach(c => columnNames.Add(c.ColumnName));
                }

                foreach (string columnName in columnNames)
                {
                    DataColumn currentDataColumn = (from dc in dataColumns
                                                    where dc.ColumnName == columnName
                                                    select dc).FirstOrDefault();
                    if (currentDataColumn != null)
                    {
                        ColumnHeader newColumn = new ColumnHeader();
                        newColumn.Tag = currentDataColumn;
                        newColumn.Text = columnName;

                        if ((currentDataColumn.DataType == typeof(UInt64)) || (currentDataColumn.DataType == typeof(UInt32)) || (currentDataColumn.DataType == typeof(UInt16)) ||
                            (currentDataColumn.DataType == typeof(Int64)) || (currentDataColumn.DataType == typeof(Int32)) || (currentDataColumn.DataType == typeof(Int16)) )
                        {
                            newColumn.TextAlign = HorizontalAlignment.Right;
                        }
                        else 
                        {
                            newColumn.TextAlign = HorizontalAlignment.Left;
                        }
                        lvwResults.Columns.Add(newColumn);
                    }                    
                }
            }
        }

        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            RefreshList();
            lvwResults.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
