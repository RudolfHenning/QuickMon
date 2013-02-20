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

        public SoapWebServicePingConfig SelectedSoapWebServicePingConfig { get; set; }

        #region Shown
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            LoadList();
            columnResizeTimer.Enabled = true;
        } 
        #endregion

        #region Button events
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            EditSoapWebServicePingConfigEntry editSoapWebServicePingConfigEntry = new EditSoapWebServicePingConfigEntry();

            if (editSoapWebServicePingConfigEntry.ShowDialog() == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem(editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ServiceBaseURL);
                lvi.SubItems.Add(editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ServiceName);
                lvi.SubItems.Add(editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.MethodName);
                lvi.SubItems.Add(editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ToStringFromParameters());
                lvi.Tag = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry;
                lvwEntries.Items.Add(lvi);
                CheckOKButtonEnable();
            }
        }
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                EditSoapWebServicePingConfigEntry editSoapWebServicePingConfigEntry = new EditSoapWebServicePingConfigEntry();
                editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry = (SoapWebServicePingConfigEntry)lvwEntries.SelectedItems[0].Tag;
                if (editSoapWebServicePingConfigEntry.ShowDialog() == DialogResult.OK)
                {
                    lvwEntries.SelectedItems[0].Text = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ServiceBaseURL;
                    lvwEntries.SelectedItems[0].SubItems[1].Text = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ServiceName;
                    lvwEntries.SelectedItems[0].SubItems[2].Text = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.MethodName;
                    lvwEntries.SelectedItems[0].SubItems[3].Text = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry.ToStringFromParameters();
                    lvwEntries.SelectedItems[0].Tag = editSoapWebServicePingConfigEntry.SelectedSoapWebServicePingConfigEntry;
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
                SelectedSoapWebServicePingConfig.Entries.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    SoapWebServicePingConfigEntry soapWebServicePingConfigEntry = (SoapWebServicePingConfigEntry)lvi.Tag;
                    SelectedSoapWebServicePingConfig.Entries.Add(soapWebServicePingConfigEntry);
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
            if (SelectedSoapWebServicePingConfig != null)
            {
                lvwEntries.BeginUpdate();
                lvwEntries.Items.Clear();
                try
                {
                    foreach (SoapWebServicePingConfigEntry entry in SelectedSoapWebServicePingConfig.Entries)
                    {
                        ListViewItem lvi = new ListViewItem(entry.ServiceBaseURL);
                        lvi.SubItems.Add(entry.ServiceName);
                        lvi.SubItems.Add(entry.MethodName);
                        lvi.SubItems.Add(entry.ToStringFromParameters());
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
