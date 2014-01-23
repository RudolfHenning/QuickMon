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
    public partial class SqlQueryCollectorEditConfig : SimpleListEditConfig
    {
        public SqlQueryCollectorEditConfig()
        {
            InitializeComponent();
            this.editingContextMenuStrip.Items.Clear();
            this.editingContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addWithSameConnectionDetailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.removeToolStripMenuItem});
        }

        public override void LoadList()
        {
            if (SelectedConfig != null)
            {
                SqlQueryCollectorConfig sqlQueryConfig = (SqlQueryCollectorConfig)SelectedConfig;
                lvwEntries.Items.Clear();
                foreach (QueryInstance queryInstance in sqlQueryConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.SubItems.Add(queryInstance.ToServerDBName());
                    lvi.SubItems.Add(queryInstance.WarningValue);
                    lvi.SubItems.Add(queryInstance.ErrorValue);
                    lvi.Tag = queryInstance;
                    lvwEntries.Items.Add(lvi);
                }
            }
            base.LoadList();
        }
        public override void AddItem() 
        {
            SqlQueryCollectorEditEntry editSqlQueryInstance = new SqlQueryCollectorEditEntry();
            editSqlQueryInstance.SelectedQueryInstance = new QueryInstance();
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSqlQueryInstance.SelectedQueryInstance.Name);
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ToServerDBName());
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.WarningValue);
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ErrorValue);
                lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                lvwEntries.Items.Add(lvi);
                CheckOKEnabled();
                CheckEnableButtons();
            }
        }
        public void AddWithSameConnection()
        {
            if (lvwEntries.SelectedItems.Count > 0 && lvwEntries.SelectedItems[0].Tag is QueryInstance)
            {
                SqlQueryCollectorEditEntry editSqlQueryInstance = new SqlQueryCollectorEditEntry();
                QueryInstance masterToCopy = (QueryInstance)lvwEntries.SelectedItems[0].Tag;
                QueryInstance sqlQueryInstanceCopy = new QueryInstance()
                {
                    SqlServer = masterToCopy.SqlServer,
                    Database = masterToCopy.Database,
                    IntegratedSecurity = masterToCopy.IntegratedSecurity,
                    UserName = masterToCopy.UserName,
                    Password = masterToCopy.Password,
                    CmndTimeOut = masterToCopy.CmndTimeOut
                };
                editSqlQueryInstance.SelectedQueryInstance = sqlQueryInstanceCopy;
                if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem lvi = new ListViewItem(editSqlQueryInstance.SelectedQueryInstance.Name);
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ToServerDBName());
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.WarningValue);
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ErrorValue);
                    lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                    lvwEntries.Items.Add(lvi);
                    CheckOKEnabled();
                    CheckEnableButtons();
                }
            }
        }
        public override void EditItem() 
        {
            if (lvwEntries.SelectedItems.Count > 0 && lvwEntries.SelectedItems[0].Tag is QueryInstance)
            {
                SqlQueryCollectorEditEntry editSqlQueryInstance = new SqlQueryCollectorEditEntry();
                editSqlQueryInstance.SelectedQueryInstance = (QueryInstance)lvwEntries.SelectedItems[0].Tag;
                if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem lvi = lvwEntries.SelectedItems[0];
                    lvi.Text = editSqlQueryInstance.SelectedQueryInstance.Name;
                    lvi.SubItems[1].Text = editSqlQueryInstance.SelectedQueryInstance.ToServerDBName();
                    lvi.SubItems[2].Text = editSqlQueryInstance.SelectedQueryInstance.WarningValue;
                    lvi.SubItems[3].Text = editSqlQueryInstance.SelectedQueryInstance.ErrorValue;
                    lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                }
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
                SelectedConfig = new SqlQueryCollectorConfig();
            SqlQueryCollectorConfig sqlQueryConfig = (SqlQueryCollectorConfig)SelectedConfig;
            sqlQueryConfig.Entries.Clear();
            foreach (ListViewItem lvi in lvwEntries.Items)
            {
                QueryInstance queryInstance = (QueryInstance)lvi.Tag;
                sqlQueryConfig.Entries.Add(queryInstance);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        public override void CheckEnableButtons()
        {
            addWithSameConnectionDetailsToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1;
            base.CheckEnableButtons();
        }
    }
}
