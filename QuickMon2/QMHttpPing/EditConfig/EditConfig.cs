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

        public HttpPingConfig SelectedHttpPingConfig { get; set; }

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
            EditHttpPingEntry edithttpPingEntry = new EditHttpPingEntry();

            if (edithttpPingEntry.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(edithttpPingEntry.SelectedHttpPingEntry.Url);
                lvi.SubItems.Add(edithttpPingEntry.SelectedHttpPingEntry.MaxTime.ToString());
                lvi.SubItems.Add(edithttpPingEntry.SelectedHttpPingEntry.TimeOut.ToString());
                lvi.SubItems.Add(edithttpPingEntry.SelectedHttpPingEntry.ProxyServer);
                lvi.Tag = edithttpPingEntry.SelectedHttpPingEntry;
                lvwEntries.Items.Add(lvi);
                CheckOKButtonEnable();
            }
        }
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                EditHttpPingEntry edithttpPingEntry = new EditHttpPingEntry();
                edithttpPingEntry.SelectedHttpPingEntry = (HttpPingEntry)lvwEntries.SelectedItems[0].Tag;
                if (edithttpPingEntry.ShowDialog() == DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = edithttpPingEntry.SelectedHttpPingEntry.Url;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = edithttpPingEntry.SelectedHttpPingEntry.MaxTime.ToString();
                    lvwEntries.SelectedItems[0].SubItems[2].Text = edithttpPingEntry.SelectedHttpPingEntry.TimeOut.ToString();
                    lvwEntries.SelectedItems[0].SubItems[3].Text = edithttpPingEntry.SelectedHttpPingEntry.ProxyServer;
                    lvwEntries.SelectedItems[0].Tag = edithttpPingEntry.SelectedHttpPingEntry;
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
                SelectedHttpPingConfig.Entries.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    HttpPingEntry httpPingEntry = (HttpPingEntry)lvi.Tag;
                    SelectedHttpPingConfig.Entries.Add(httpPingEntry);
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
            lvwEntries.Columns[0].Width = lvwEntries.ClientSize.Width - lvwEntries.Columns[3].Width - lvwEntries.Columns[1].Width - lvwEntries.Columns[2].Width;
        }
        #endregion

        #region Private methods
        private void LoadList()
        {
            if (SelectedHttpPingConfig != null)
            {
                lvwEntries.BeginUpdate();
                lvwEntries.Items.Clear();
                try
                {
                    foreach (HttpPingEntry entry in SelectedHttpPingConfig.Entries)
                    {
                        ListViewItem lvi = new ListViewItem(entry.Url);
                        lvi.SubItems.Add(entry.MaxTime.ToString());
                        lvi.SubItems.Add(entry.TimeOut.ToString());
                        lvi.SubItems.Add(entry.ProxyServer);
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
