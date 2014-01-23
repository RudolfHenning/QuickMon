using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.BizTalk
{
    public partial class BizTalkEditList : Form
    {
        public BizTalkEditList()
        {
            InitializeComponent();
        }

        public int ValueColumn { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<string[]> Items { get; set; }
        public List<string> ExcludeItems { get; set; }
        public List<string> SelectedItems { get; set; }

        private void EditList_Load(object sender, EventArgs e)
        {
            if (ColumnNames == null || ColumnNames.Count == 0)
            {
                ColumnNames = new List<string>();
                ColumnNames.Add("Name");
            }
            lvwList.Columns.Clear();
            foreach (string columnName in ColumnNames)
            {
                lvwList.Columns.Add(new ColumnHeader() { Text = columnName, Name = columnName });
            }
            LoadItems();
        }

        private void LoadItems()
        {
            int columnCount = lvwList.Columns.Count;
            try
            {
                if (ValueColumn >= columnCount || (Items.Count > 0 && ValueColumn >= Items[0].Length))
                    ValueColumn = 0;
                lvwList.BeginUpdate();
                lvwList.Items.Clear();
                foreach (var item in Items)
                {
                    if (!ExcludeItems.Contains(item[ValueColumn]))
                    {
                        ListViewItem lvi = new ListViewItem(item[0]);
                        for (int i = 1; i < columnCount; i++)
                        {
                            lvi.SubItems.Add(item[i]);
                        }
                        lvwList.Items.Add(lvi);
                    }
                }
                for (int i = 0; i < columnCount; i++)
                {
                    lvwList.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwList.EndUpdate();
            }
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerIsOKEnabled.Enabled = false;
            timerIsOKEnabled.Enabled = true;
        }

        private void timerIsOKEnabled_Tick(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwList.SelectedItems.Count > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedItems = new List<string>();
            foreach (ListViewItem lvi in lvwList.SelectedItems)
            {
                SelectedItems.Add(lvi.SubItems[ValueColumn].Text);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
