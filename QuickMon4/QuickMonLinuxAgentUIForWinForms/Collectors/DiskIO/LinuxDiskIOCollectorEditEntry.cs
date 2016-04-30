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
    public partial class LinuxDiskIOCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxDiskIOCollectorEditEntry()
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

        private void LinuxDiskIOCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwDisks.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxDiskIOEntry currentEntry = (LinuxDiskIOEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxDiskIOEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            foreach (LinuxDiskIOSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.Disk };
                lvi.SubItems.Add(dsse.WarningValue.ToString());
                lvi.SubItems.Add(dsse.ErrorValue.ToString());
                lvi.Tag = dsse;
                lvwDisks.Items.Add(lvi);
            }
        }
        #endregion
        
        private bool fileSystemUpdated = false;
        private void lvwFileSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDisks.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                LinuxDiskIOSubEntry dsse = (LinuxDiskIOSubEntry)lvwDisks.SelectedItems[0].Tag;
                warningNumericUpDown.SaveValueSet((decimal)dsse.WarningValue);
                errorNumericUpDown.SaveValueSet((decimal)dsse.ErrorValue);
                txtDisk.Text = dsse.Disk;
                fileSystemUpdated = false;
            }
            else if (lvwDisks.SelectedItems.Count == 0)
            {
                fileSystemUpdated = true;
                txtDisk.Text = "";
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
            if (txtDisk.Text.Trim().Length > 0 && !fileSystemUpdated)
            {
                if (lvwDisks.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwDisks.SelectedItems[0];
                    LinuxDiskIOSubEntry dsse = (LinuxDiskIOSubEntry)lvwDisks.SelectedItems[0].Tag;
                    dsse.Disk = txtDisk.Text;
                    dsse.WarningValue = (double)warningNumericUpDown.Value;
                    dsse.ErrorValue = (double)errorNumericUpDown.Value;
                    lvi.Text = txtDisk.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    LinuxDiskIOSubEntry dsse = new LinuxDiskIOSubEntry() { Disk = txtDisk.Text, WarningValue = (double)warningNumericUpDown.Value, ErrorValue = (double)errorNumericUpDown.Value };
                    ListViewItem lvi = new ListViewItem() { Text = dsse.Disk };
                    lvi.SubItems.Add(dsse.WarningValue.ToString());
                    lvi.SubItems.Add(dsse.ErrorValue.ToString());
                    lvi.Tag = dsse;
                    lvwDisks.Items.Add(lvi);
                    lvwDisks.SelectedItems.Clear();
                    lvi.Selected = true;
                }
            }
        }

        private void lblAddFileSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvwDisks.SelectedItems.Clear();
            txtDisk.Text = "";
        }

        private void lvwFileSystems_DeleteKeyPressed()
        {
            if (lvwDisks.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwDisks.SelectedItems)
                    {
                        lvwDisks.Items.Remove(lvi);
                    }
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxDiskIOEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxDiskIOEntry();
            selectedEntry = (LinuxDiskIOEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach (ListViewItem lvi in lvwDisks.Items)
            {
                LinuxDiskIOSubEntry dsse = (LinuxDiskIOSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lblAutoAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lvwDisks.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwDisks.Items.Clear();
                    lvwDisks.Items.Add(new ListViewItem("Querying " + sshConnectionDetails.ComputerName + "..."));
                    Application.DoEvents();
                }
                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(sshConnectionDetails);
                if (sshClient.IsConnected)
                {
                    lvwDisks.Items.Clear();
                    foreach (Linux.DiskIOInfo di in QuickMon.Linux.DiskIOInfo.GetCurrentDiskStats(sshClient))
                    {
                        LinuxDiskIOSubEntry dsse = new LinuxDiskIOSubEntry() { Disk = di.Name, WarningValue = (double)warningNumericUpDown.Value, ErrorValue = (double)errorNumericUpDown.Value };
                        ListViewItem lvi = new ListViewItem() { Text = dsse.Disk };
                        lvi.SubItems.Add(dsse.WarningValue.ToString());
                        lvi.SubItems.Add(dsse.ErrorValue.ToString());
                        lvi.Tag = dsse;
                        lvwDisks.Items.Add(lvi);
                    }
                }
                else
                {
                    lvwDisks.Items.Clear();
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
