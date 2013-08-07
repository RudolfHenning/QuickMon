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

        public SocketPingConfig SelectedSocketPingConfig { get; set; }

        #region Form events
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        }
        #endregion

        #region Button events
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            EditSocketPingEntry editSocketPingEntry = new EditSocketPingEntry();

            if (editSocketPingEntry.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSocketPingEntry.SelectedSocketPingEntry.HostName);
                lvi.SubItems.Add(editSocketPingEntry.SelectedSocketPingEntry.PortNumber.ToString());
                lvi.SubItems.Add(editSocketPingEntry.SelectedSocketPingEntry.PingTimeOutMS.ToString());
                lvi.Tag = editSocketPingEntry.SelectedSocketPingEntry;
                lvwEntries.Items.Add(lvi);
                CheckOKButtonEnable();
            }
        }
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                EditSocketPingEntry editSocketPingEntry = new EditSocketPingEntry();
                editSocketPingEntry.SelectedSocketPingEntry = (SocketPingEntry)lvwEntries.SelectedItems[0].Tag;
                if (editSocketPingEntry.ShowDialog() == DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = editSocketPingEntry.SelectedSocketPingEntry.HostName;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = editSocketPingEntry.SelectedSocketPingEntry.PortNumber.ToString();
                    lvwEntries.SelectedItems[0].SubItems[2].Text = editSocketPingEntry.SelectedSocketPingEntry.PingTimeOutMS.ToString();
                    lvwEntries.SelectedItems[0].Tag = editSocketPingEntry.SelectedSocketPingEntry;
                }
                CheckOKButtonEnable();
            }
        }
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to remove this entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                    {
                        lvwEntries.Items.Remove(lvi);
                    }
                    CheckOKButtonEnable();
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKButtonEnable())
            {
                SelectedSocketPingConfig.Entries.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    SocketPingEntry socketPingEntry = (SocketPingEntry)lvi.Tag;
                    SelectedSocketPingConfig.Entries.Add(socketPingEntry);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region ListView events
        private void lvwEntries_Resize(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            columnResizeTimer.Enabled = true;
        }
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdEdit.Enabled = (lvwEntries.SelectedItems.Count > 0);
            cmdRemove.Enabled = (lvwEntries.SelectedItems.Count > 0);
        }
        private void lvwEntries_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdEdit_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                cmdRemove_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Timer events
        private void columnResizeTimer_Tick(object sender, EventArgs e)
        {
            columnResizeTimer.Enabled = false;
            lvwEntries.Columns[0].Width = lvwEntries.ClientSize.Width - lvwEntries.Columns[2].Width - lvwEntries.Columns[1].Width;
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (SelectedSocketPingConfig != null)
            {
                lvwEntries.BeginUpdate();
                lvwEntries.Items.Clear();
                try
                {
                    foreach (SocketPingEntry entry in SelectedSocketPingConfig.Entries)
                    {
                        ListViewItem lvi = new ListViewItem(entry.HostName);
                        lvi.SubItems.Add(entry.PortNumber.ToString());
                        lvi.SubItems.Add(entry.PingTimeOutMS.ToString());
                        lvi.Tag = entry;
                        lvwEntries.Items.Add(lvi);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwEntries.EndUpdate();
                    CheckOKButtonEnable();
                }
            }
        }
        private bool CheckOKButtonEnable()
        {
            cmdOK.Enabled = lvwEntries.Items.Count > 0;
            return cmdOK.Enabled;
        }
        #endregion
    }
}
