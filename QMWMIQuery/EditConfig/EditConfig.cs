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

        public WMIConfig WmiConfig { get; set; }

        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }

        #region Form events 
        private void EditConfig_Load(object sender, EventArgs e)
        {

        }
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
        private void lvwQueries_DoubleClick(object sender, EventArgs e)
        {
            editToolStripButton_Click(null, null);
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (WmiConfig != null)
            {
                lvwQueries.Items.Clear();
                foreach (WMIConfigEntry wmiConfigEntry in WmiConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(wmiConfigEntry.Name);
                    lvi.SubItems.Add(wmiConfigEntry.Machinename);
                    lvi.SubItems.Add(wmiConfigEntry.Namespace);
                    lvi.SubItems.Add(wmiConfigEntry.DetailQuery);
                    lvi.Tag = wmiConfigEntry;
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

        #region Toolbar button and context menu events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditConfigEntry editConfigEntry = new EditConfigEntry();
            editConfigEntry.WmiIConfigEntry = new WMIConfigEntry();
            if (editConfigEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editConfigEntry.WmiIConfigEntry.Name);
                lvi.SubItems.Add(editConfigEntry.WmiIConfigEntry.Machinename);
                lvi.SubItems.Add(editConfigEntry.WmiIConfigEntry.Namespace);
                lvi.SubItems.Add(editConfigEntry.WmiIConfigEntry.DetailQuery);
                lvi.Tag = editConfigEntry.WmiIConfigEntry;
                lvwQueries.Items.Add(lvi);
                CheckOKEnabled();
                CheckButtonsEnable();
            }
        }        
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwQueries.SelectedItems.Count > 0 && lvwQueries.SelectedItems[0].Tag is WMIConfigEntry)
            {
                EditConfigEntry editConfigEntry = new EditConfigEntry();
                editConfigEntry.WmiIConfigEntry = (WMIConfigEntry)lvwQueries.SelectedItems[0].Tag;
                if (editConfigEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ListViewItem lvi = lvwQueries.SelectedItems[0];
                    lvi.Text = editConfigEntry.WmiIConfigEntry.Name;
                    lvi.SubItems[1].Text = editConfigEntry.WmiIConfigEntry.Machinename;
                    lvi.SubItems[2].Text = editConfigEntry.WmiIConfigEntry.Namespace;
                    lvi.SubItems[3].Text = editConfigEntry.WmiIConfigEntry.DetailQuery;
                    lvi.Tag = editConfigEntry.WmiIConfigEntry;
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

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwQueries.Columns[3].Width = lvwQueries.ClientSize.Width - lvwQueries.Columns[0].Width - lvwQueries.Columns[1].Width - lvwQueries.Columns[2].Width;
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
                WmiConfig = new WMIConfig();
                WmiConfig.Entries = new List<WMIConfigEntry>();
                foreach (ListViewItem lvi in lvwQueries.Items)
                {
                    WMIConfigEntry wmiConfigEntry = (WMIConfigEntry)lvi.Tag;
                    WmiConfig.Entries.Add(wmiConfigEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion




    }
}
