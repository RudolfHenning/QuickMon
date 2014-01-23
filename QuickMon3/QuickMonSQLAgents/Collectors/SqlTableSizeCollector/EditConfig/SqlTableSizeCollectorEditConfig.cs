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
    public partial class SqlTableSizeCollectorEditConfig : SimpleListEditConfig
    {
        public SqlTableSizeCollectorEditConfig()
        {
            InitializeComponent();
        }

        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                SqlTableSizeCollectorConfig sqlDbSizeConfig = (SqlTableSizeCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (SqlTableSizeCollectorEntry sqlTableSizeEntry in sqlDbSizeConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(sqlTableSizeEntry.ToString());
                    lvi.SubItems.Add(sqlTableSizeEntry.Tables.Count().ToString());
                    lvi.Tag = sqlTableSizeEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadList();
        }
        public override void AddItem()
        {
            SqlTableSizeCollectorEditEntry editSqlQueryInstance = new SqlTableSizeCollectorEditEntry();
            editSqlQueryInstance.SelectedSqlTableSizeEntry = new SqlTableSizeCollectorEntry();
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSqlQueryInstance.SelectedSqlTableSizeEntry.ToString());
                lvi.SubItems.Add(editSqlQueryInstance.SelectedSqlTableSizeEntry.Tables.Count.ToString());
                lvi.Tag = editSqlQueryInstance.SelectedSqlTableSizeEntry;
                lvwEntries.Items.Add(lvi);
                CheckOKEnabled();
                CheckEnableButtons();
            }
        }
        public override void EditItem()
        {
            SqlTableSizeCollectorEditEntry editSqlQueryInstance = new SqlTableSizeCollectorEditEntry();
            editSqlQueryInstance.SelectedSqlTableSizeEntry = (SqlTableSizeCollectorEntry)lvwEntries.SelectedItems[0].Tag;
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = lvwEntries.SelectedItems[0];
                lvi.Text = editSqlQueryInstance.SelectedSqlTableSizeEntry.ToString();
                lvi.SubItems[1].Text = editSqlQueryInstance.SelectedSqlTableSizeEntry.Tables.Count().ToString();
                lvi.Tag = editSqlQueryInstance.SelectedSqlTableSizeEntry;
                CheckOKEnabled();
                CheckEnableButtons();
            }
        }
        public override void DeleteItems()
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                    {
                        lvwEntries.Items.Remove(lvi);
                    }
                    CheckOKEnabled();
                }
            }
        }
        public override void OKClicked()
        {
            if (SelectedConfig == null)
                SelectedConfig = new SqlTableSizeCollectorConfig();
            SqlTableSizeCollectorConfig sqlDbSizeConfig = (SqlTableSizeCollectorConfig)SelectedConfig;
            sqlDbSizeConfig.Entries.Clear();
            foreach (ListViewItem lvi in lvwEntries.Items)
            {
                SqlTableSizeCollectorEntry sqlTableSizeEntry = (SqlTableSizeCollectorEntry)lvi.Tag;
                sqlDbSizeConfig.Entries.Add(sqlTableSizeEntry);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
