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
    public partial class LinuxNICCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxNICCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region ICollectorConfigEntryEditWindow
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        private QuickMon.Linux.SSHConnectionDetails sshConnectionDetails = new Linux.SSHConnectionDetails();

        private void LinuxNICCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwNICs.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxNICEntry currentEntry = (LinuxNICEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxNICEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            foreach (LinuxNICSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.NICName };
                lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
                lvi.Tag = dsse;
                lvwNICs.Items.Add(lvi);
            }
        }
        #endregion

        private bool fileSystemUpdated = false;
        private void lvwFileSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwNICs.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                LinuxNICSubEntry dsse = (LinuxNICSubEntry)lvwNICs.SelectedItems[0].Tag;
                warningNumericUpDown.SaveValueSet((decimal)dsse.WarningValueKB);
                errorNumericUpDown.SaveValueSet((decimal)dsse.ErrorValueKB);
                txtNIC.Text = dsse.NICName;
                fileSystemUpdated = false;
            }
            else if (lvwNICs.SelectedItems.Count == 0)
            {
                fileSystemUpdated = true;
                txtNIC.Text = "";
                fileSystemUpdated = false;
            }
        }

        private void txtFileSystem_TextChanged(object sender, EventArgs e)
        {
            UpdateFileSystem();
        }

        private void warningNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateFileSystem();
        }

        private void errorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateFileSystem();
        }

        private void UpdateFileSystem()
        {
            if (txtNIC.Text.Trim().Length > 0 && !fileSystemUpdated)
            {
                if (lvwNICs.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwNICs.SelectedItems[0];
                    LinuxNICSubEntry dsse = (LinuxNICSubEntry)lvwNICs.SelectedItems[0].Tag;
                    dsse.NICName = txtNIC.Text;
                    dsse.WarningValueKB = (long)warningNumericUpDown.Value;
                    dsse.ErrorValueKB = (long)errorNumericUpDown.Value;
                    lvi.Text = txtNIC.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    LinuxNICSubEntry dsse = new LinuxNICSubEntry() { NICName = txtNIC.Text, WarningValueKB = (long)warningNumericUpDown.Value, ErrorValueKB = (long)errorNumericUpDown.Value };
                    ListViewItem lvi = new ListViewItem() { Text = dsse.NICName };
                    lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                    lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
                    lvi.Tag = dsse;
                    lvwNICs.Items.Add(lvi);
                    lvwNICs.SelectedItems.Clear();
                    lvi.Selected = true;
                }
            }
        }

        private void lblAddFileSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvwNICs.SelectedItems.Clear();
            txtNIC.Text = "";
        }

        private void lvwFileSystems_DeleteKeyPressed()
        {
            if (lvwNICs.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwNICs.SelectedItems)
                    {
                        lvwNICs.Items.Remove(lvi);
                    }
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxNICEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxNICEntry();
            selectedEntry = (LinuxNICEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach (ListViewItem lvi in lvwNICs.Items)
            {
                LinuxNICSubEntry dsse = (LinuxNICSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lblAutoAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lvwNICs.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwNICs.Items.Clear();
                    lvwNICs.Items.Add(new ListViewItem("Querying " + sshConnectionDetails.ComputerName + "..."));
                    Application.DoEvents();
                }                

                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(sshConnectionDetails);
                if (sshClient.IsConnected)
                {
                    lvwNICs.Items.Clear();
                    foreach (Linux.NicInfo di in QuickMon.Linux.NicInfo.GetCurrentNicStats(sshClient))
                    {
                        LinuxNICSubEntry dsse = new LinuxNICSubEntry() { NICName = di.Name, WarningValueKB = (long)warningNumericUpDown.Value, ErrorValueKB = (long)errorNumericUpDown.Value };
                        ListViewItem lvi = new ListViewItem() { Text = dsse.NICName };
                        lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                        lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
                        lvi.Tag = dsse;
                        lvwNICs.Items.Add(lvi);
                    }
                }
                else
                {
                    lvwNICs.Items.Clear();
                    MessageBox.Show("Could not connect to computer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblEditSSHConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditSSHConnection();
        }

        private void txtSSHConnection_DoubleClick(object sender, EventArgs e)
        {
            EditSSHConnection();
        }

        private void EditSSHConnection()
        {
            EditSSHConnection editor = new Collectors.EditSSHConnection();
            editor.SSHConnectionDetails = sshConnectionDetails;
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }
    }
}
