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
    public partial class SqlDatabaseSizeCollectorEditConfig : SimpleListEditConfig
    {
        public SqlDatabaseSizeCollectorEditConfig()
        {
            InitializeComponent();
        }

        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                SqlDatabaseSizeCollectorConfig sqlDbSizeConfig = (SqlDatabaseSizeCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (SqlDatabaseSizeEntry sqlDBSizeEntry in sqlDbSizeConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(sqlDBSizeEntry.ToString());
                    lvi.SubItems.Add(sqlDBSizeEntry.WarningSizeMB.ToString());
                    lvi.SubItems.Add(sqlDBSizeEntry.ErrorSizeMB.ToString());
                    lvi.Tag = sqlDBSizeEntry;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadList();
        }

        public override void AddItem()
        {
            SqlDatabaseSizeCollectorEditEntry editSqlQueryInstance = new SqlDatabaseSizeCollectorEditEntry();
            editSqlQueryInstance.SelectedSqlDatabaseSizeEntry = new SqlDatabaseSizeEntry();
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.ToString());
                lvi.SubItems.Add(editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.WarningSizeMB.ToString());
                lvi.SubItems.Add(editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.ErrorSizeMB.ToString());
                lvi.Tag = editSqlQueryInstance.SelectedSqlDatabaseSizeEntry;
                lvwEntries.Items.Add(lvi);
                CheckOKEnabled();
                CheckEnableButtons();
            }
        }
        public override void EditItem()
        {
            SqlDatabaseSizeCollectorEditEntry editSqlQueryInstance = new SqlDatabaseSizeCollectorEditEntry();
            editSqlQueryInstance.SelectedSqlDatabaseSizeEntry = (SqlDatabaseSizeEntry)lvwEntries.SelectedItems[0].Tag;
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = lvwEntries.SelectedItems[0];
                lvi.Text = editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.ToString();
                lvi.SubItems[1].Text = editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.WarningSizeMB.ToString();
                lvi.SubItems[2].Text = editSqlQueryInstance.SelectedSqlDatabaseSizeEntry.ErrorSizeMB.ToString();
                lvi.Tag = editSqlQueryInstance.SelectedSqlDatabaseSizeEntry;
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
                SelectedConfig = new SqlDatabaseSizeCollectorConfig();
            SqlDatabaseSizeCollectorConfig sqlDbSizeConfig = (SqlDatabaseSizeCollectorConfig)SelectedConfig;
            sqlDbSizeConfig.Entries.Clear();
            foreach (ListViewItem lvi in lvwEntries.Items)
            {
                SqlDatabaseSizeEntry sqlDBSizeEntry = (SqlDatabaseSizeEntry)lvi.Tag;
                sqlDbSizeConfig.Entries.Add(sqlDBSizeEntry);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
