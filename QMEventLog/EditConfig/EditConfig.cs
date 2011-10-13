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

        internal EventLogConfig SelectedEventLogConfig { get; set; }

        #region Form events
        private void EditConfigEventLog_Load(object sender, EventArgs e)
        {
            if (SelectedEventLogConfig == null)
                SelectedEventLogConfig = new EventLogConfig();
        }
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion

        #region List view events
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableButtons();
        }
        private void lvwEntries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                editToolStripButton_Click(sender, e);
                e.Handled = true;
            }
        }
        private void lvwEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                removeToolStripButton_Click(null, null);
        }
        #endregion

        #region Toolbar events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            EditEventLogEntry editEventLogEntry = new EditEventLogEntry();
            if (editEventLogEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedEventLogConfig.Entries.Add(editEventLogEntry.SelectedEventLogEntry);
                LoadList();
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                EditEventLogEntry editEventLogEntry = new EditEventLogEntry();
                editEventLogEntry.SelectedEventLogEntry = (QMEventLogEntry)lvwEntries.SelectedItems[0].Tag;
                if (editEventLogEntry.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = editEventLogEntry.SelectedEventLogEntry.ComputerLogName;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = editEventLogEntry.SelectedEventLogEntry.FilterSummary;
                    lvwEntries.SelectedItems[0].SubItems[2].Text = editEventLogEntry.SelectedEventLogEntry.WarningValue.ToString();
                    lvwEntries.SelectedItems[0].SubItems[3].Text = editEventLogEntry.SelectedEventLogEntry.ErrorValue.ToString();
                    lvwEntries.SelectedItems[0].Tag = editEventLogEntry.SelectedEventLogEntry;
                    CheckOKEnabled();
                }
            }
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
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
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKEnabled())
            {
                SelectedEventLogConfig = new EventLogConfig();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    QMEventLogEntry eventLogEntry = (QMEventLogEntry)lvi.Tag;
                    SelectedEventLogConfig.Entries.Add(eventLogEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            lvwEntries.Items.Clear();
            foreach (var entry in SelectedEventLogConfig.Entries)
            {
                ListViewItem lvi = new ListViewItem(entry.ComputerLogName);
                lvi.SubItems.Add(entry.FilterSummary);
                lvi.SubItems.Add(entry.WarningValue.ToString());
                lvi.SubItems.Add(entry.ErrorValue.ToString());
                lvi.Tag = entry;
                lvwEntries.Items.Add(lvi);
            }
            CheckOKEnabled();
        }
        private void CheckEnableButtons()
        {
            editToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
        }
        private bool CheckOKEnabled()
        {
            cmdOK.Enabled = (lvwEntries.Items.Count > 0);
            return cmdOK.Enabled;
        } 
        #endregion

    }
}
