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
        public RegistryQueryConfig SelectedRegistryQueryConfig { get; set; }

        public EditConfig()
        {
            InitializeComponent();
        }

        #region Form events
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        }
        #endregion

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwQueries.Columns[1].Width = lvwQueries.ClientSize.Width - lvwQueries.Columns[0].Width - lvwQueries.Columns[2].Width - lvwQueries.Columns[3].Width - lvwQueries.Columns[4].Width - lvwQueries.Columns[5].Width;
        }
        private void timerCheckButtonEnabled_Tick(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            CheckButtonsEnable();
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
            if (SelectedRegistryQueryConfig != null)
            {
                lvwQueries.Items.Clear();

                foreach (RegistryQueryInstance queryInstance in SelectedRegistryQueryConfig.Queries)
                {
                    ListViewItem lvi = new ListViewItem(queryInstance.Name);
                    lvi.SubItems.Add((queryInstance.UseRemoteServer ? queryInstance.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(queryInstance.RegistryHive.ToString()).ToString() + "\\" + queryInstance.Path);
                    lvi.SubItems.Add(queryInstance.KeyName);
                    lvi.SubItems.Add(queryInstance.SuccessValue);
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
            editToolStripButton.Enabled = lvwQueries.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = lvwQueries.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwQueries.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwQueries.SelectedItems.Count > 0;
        }
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKEnabled())
            {
                SelectedRegistryQueryConfig = new RegistryQueryConfig();
                foreach (ListViewItem lvi in lvwQueries.Items)
                {
                    RegistryQueryInstance queryInstance = (RegistryQueryInstance)lvi.Tag;
                    SelectedRegistryQueryConfig.Queries.Add(queryInstance);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Toolbar button and context menu events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditRegistryQueryInstance editQueryInstance = new EditRegistryQueryInstance();
            editQueryInstance.SelectedRegistryQueryInstance = new RegistryQueryInstance();
            if (editQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editQueryInstance.SelectedRegistryQueryInstance.Name);
                lvi.SubItems.Add((editQueryInstance.SelectedRegistryQueryInstance.UseRemoteServer ? editQueryInstance.SelectedRegistryQueryInstance.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(editQueryInstance.SelectedRegistryQueryInstance.RegistryHive.ToString()).ToString() + "\\" + editQueryInstance.SelectedRegistryQueryInstance.Path);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.KeyName);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.SuccessValue);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.WarningValue);
                lvi.SubItems.Add(editQueryInstance.SelectedRegistryQueryInstance.ErrorValue);
                lvi.Tag = editQueryInstance.SelectedRegistryQueryInstance;
                lvwQueries.Items.Add(lvi);
                CheckOKEnabled();
                CheckButtonsEnable();
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwQueries.SelectedItems.Count > 0 && lvwQueries.SelectedItems[0].Tag is RegistryQueryInstance)
            {
                EditRegistryQueryInstance editQueryInstance = new EditRegistryQueryInstance();
                editQueryInstance.SelectedRegistryQueryInstance = (RegistryQueryInstance)lvwQueries.SelectedItems[0].Tag;
                if (editQueryInstance.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem lvi = lvwQueries.SelectedItems[0];
                    lvi.Text = editQueryInstance.SelectedRegistryQueryInstance.Name;
                    lvi.SubItems[1].Text = (editQueryInstance.SelectedRegistryQueryInstance.UseRemoteServer ? editQueryInstance.SelectedRegistryQueryInstance.Server + "\\" : "") + RegistryQueryInstance.GetRegistryHiveFromString(editQueryInstance.SelectedRegistryQueryInstance.RegistryHive.ToString()).ToString() + "\\" + editQueryInstance.SelectedRegistryQueryInstance.Path;
                    lvi.SubItems[2].Text = editQueryInstance.SelectedRegistryQueryInstance.KeyName;
                    lvi.SubItems[3].Text = editQueryInstance.SelectedRegistryQueryInstance.SuccessValue;
                    lvi.SubItems[4].Text = editQueryInstance.SelectedRegistryQueryInstance.WarningValue;
                    lvi.SubItems[5].Text = editQueryInstance.SelectedRegistryQueryInstance.ErrorValue;
                    lvi.Tag = editQueryInstance.SelectedRegistryQueryInstance;
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
