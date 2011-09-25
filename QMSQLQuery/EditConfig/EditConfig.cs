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
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public SQLQueryConfig SqlQueryConfig { get; set; }

        #region Form events
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        } 
        #endregion

        #region List view events
        private void lvwQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            timerCheckButtonEnabled.Enabled = true;      
        }
        private void lvwQueries_Resize(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            columnResizeTimer.Enabled = true;
        }
        private void lvwQueries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editToolStripButton_Click(null, null);
            else if (e.KeyCode == Keys.Delete)
                removeToolStripButton_Click(null, null);
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (SqlQueryConfig != null)
            {
                lvwQueries.Items.Clear();

                foreach (QueryInstance queryInstance in SqlQueryConfig.Queries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.SubItems.Add(queryInstance.SqlServer + "\\" + queryInstance.Database);
                    lvi.SubItems.Add(queryInstance.WarningValue);
                    lvi.SubItems.Add(queryInstance.ErrorValue);
                    lvi.Tag = queryInstance;
                    lvwQueries.Items.Add(lvi);
                }
                CheckOKEnabled();
            }
        }
        private bool CheckOKEnabled()
        {
            cmdOK.Enabled = (lvwQueries.Items.Count > 0);
            return cmdOK.Enabled;
        }
        private void CheckButtonsEnable()
        {
            addWithSameConnectionDetailsToolStripMenuItem.Enabled = lvwQueries.SelectedItems.Count > 0;
            editToolStripButton.Enabled = lvwQueries.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = lvwQueries.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwQueries.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwQueries.SelectedItems.Count > 0;
        }
        #endregion

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwQueries.Columns[0].Width = lvwQueries.ClientSize.Width - lvwQueries.Columns[1].Width - lvwQueries.Columns[2].Width - lvwQueries.Columns[3].Width;
        }
        private void timerCheckButtonEnabled_Tick(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            CheckButtonsEnable();
        } 
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKEnabled())
            {
                SqlQueryConfig = new SQLQueryConfig();
                foreach (ListViewItem lvi in lvwQueries.Items)
                {
                    QueryInstance queryInstance = (QueryInstance)lvi.Tag;
                    SqlQueryConfig.Queries.Add(queryInstance);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        } 
        #endregion

        #region Toolbar button and context menu events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditSqlQueryInstance editSqlQueryInstance = new EditSqlQueryInstance();
            editSqlQueryInstance.SelectedQueryInstance = new QueryInstance();
            if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSqlQueryInstance.SelectedQueryInstance.Name);
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.SqlServer + "\\" + editSqlQueryInstance.SelectedQueryInstance.Database);
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.WarningValue);
                lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ErrorValue);
                lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                lvwQueries.Items.Add(lvi);
                CheckOKEnabled();
                CheckButtonsEnable();
            }
        }
        private void addWithSameConnectionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwQueries.SelectedItems.Count > 0 && lvwQueries.SelectedItems[0].Tag is QueryInstance)
            {
                EditSqlQueryInstance editSqlQueryInstance = new EditSqlQueryInstance();
                QueryInstance masterToCopy = (QueryInstance)lvwQueries.SelectedItems[0].Tag;
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
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.SqlServer + "\\" + editSqlQueryInstance.SelectedQueryInstance.Database);
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.WarningValue);
                    lvi.SubItems.Add(editSqlQueryInstance.SelectedQueryInstance.ErrorValue);
                    lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                    lvwQueries.Items.Add(lvi);
                    CheckOKEnabled();
                    CheckButtonsEnable();
                }
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwQueries.SelectedItems.Count > 0 && lvwQueries.SelectedItems[0].Tag is QueryInstance)
            {
                EditSqlQueryInstance editSqlQueryInstance = new EditSqlQueryInstance();
                editSqlQueryInstance.SelectedQueryInstance = (QueryInstance)lvwQueries.SelectedItems[0].Tag;
                if (editSqlQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem lvi = lvwQueries.SelectedItems[0];
                    lvi.Text = editSqlQueryInstance.SelectedQueryInstance.Name;
                    lvi.SubItems[1].Text = editSqlQueryInstance.SelectedQueryInstance.SqlServer + "\\" + editSqlQueryInstance.SelectedQueryInstance.Database;
                    lvi.SubItems[2].Text = editSqlQueryInstance.SelectedQueryInstance.WarningValue;
                    lvi.SubItems[3].Text = editSqlQueryInstance.SelectedQueryInstance.ErrorValue;
                    lvi.Tag = editSqlQueryInstance.SelectedQueryInstance;
                }
            }
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwQueries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwQueries.SelectedItems)
                    {
                        lvwQueries.Items.Remove(lvi);
                    }
                    CheckOKEnabled();
                }
            }
        } 
        #endregion

        
    }
}
