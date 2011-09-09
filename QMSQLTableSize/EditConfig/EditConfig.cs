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

        public TableSizeConfig TableSizeConfig { get; set; }

        #region Form events
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        } 
        #endregion

        #region Toolbar events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditTableSizeEntry editTableSizeEntry = new EditTableSizeEntry();
            if (editTableSizeEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sqlDBName = editTableSizeEntry.DatabaseEntry.SqlServer.ToUpper() + "\\" + editTableSizeEntry.DatabaseEntry.Name;
                ListViewItem lvi = new ListViewItem(sqlDBName);
                lvi.SubItems.Add(editTableSizeEntry.DatabaseEntry.TableSizeEntries.Count.ToString());
                lvi.Tag = editTableSizeEntry.DatabaseEntry;
                lvwTables.Items.Add(lvi);
                CheckOKEnabled();
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count > 0)
            {
                EditTableSizeEntry editTableSizeEntry = new EditTableSizeEntry();
                editTableSizeEntry.DatabaseEntry = (DatabaseEntry)lvwTables.SelectedItems[0].Tag;
                if (editTableSizeEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string sqlDBName = editTableSizeEntry.DatabaseEntry.SqlServer.ToUpper() + "\\" + editTableSizeEntry.DatabaseEntry.Name;
                    lvwTables.SelectedItems[0].Text = sqlDBName;
                    lvwTables.SelectedItems[0].SubItems[1].Text = editTableSizeEntry.DatabaseEntry.TableSizeEntries.Count.ToString();
                    lvwTables.SelectedItems[0].Tag = editTableSizeEntry.DatabaseEntry;
                }
            }
            CheckOKEnabled();
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwTables.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove the selected entries?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwTables.SelectedItems)
                    {
                        lvwTables.Items.Remove(lvi);
                    }
                    CheckOKEnabled();
                }
            }
        }
        #endregion

        #region ListView events
        private void lvwTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            timerCheckButtonEnabled.Enabled = true;        
        }
        private void lvwTables_Resize(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            columnResizeTimer.Enabled = true;
        }
        private void lvwTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editToolStripButton_Click(null, null);
            else if (e.KeyCode == Keys.Delete)
                removeToolStripButton_Click(null, null);
        }
        #endregion

        #region Timer events
        private void timerCheckButtonEnabled_Tick(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            CheckButtonsEnable();
        }
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwTables.Columns[0].Width = lvwTables.ClientSize.Width - lvwTables.Columns[1].Width;
        }
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKEnabled())
            {
                TableSizeConfig = new TableSizeConfig();
                foreach (ListViewItem lvi in lvwTables.Items)
                {
                    DatabaseEntry databaseEntry = (DatabaseEntry)lvi.Tag;
                    TableSizeConfig.DatabaseEntries.Add(databaseEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (TableSizeConfig != null)
            {
                lvwTables.Items.Clear();

                foreach (DatabaseEntry databaseEntry in TableSizeConfig.DatabaseEntries)
                {
                    string sqlDBName = databaseEntry.SqlServer.ToUpper() + "\\" + databaseEntry.Name;
                    ListViewItem lvi = new ListViewItem(sqlDBName);
                    lvi.SubItems.Add(databaseEntry.TableSizeEntries.Count.ToString());
                    lvi.Tag = databaseEntry;
                    lvwTables.Items.Add(lvi);                   
                }
                CheckOKEnabled();
            }
        }
        private void CheckButtonsEnable()
        {
            editToolStripButton.Enabled = lvwTables.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = lvwTables.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwTables.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwTables.SelectedItems.Count > 0;
        }
        private bool CheckOKEnabled()
        {
            cmdOK.Enabled = (lvwTables.Items.Count > 0);
            return cmdOK.Enabled;
        } 
        #endregion
        
    }
}
