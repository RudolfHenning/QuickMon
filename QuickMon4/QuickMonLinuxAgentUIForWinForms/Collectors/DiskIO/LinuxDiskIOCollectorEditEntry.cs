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
            txtMachineName.Text = currentEntry.MachineName;
            sshPortNumericUpDown.SaveValueSet(currentEntry.SSHPort);
            optPrivateKey.Checked = currentEntry.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = currentEntry.UserName;
            txtPassword.Text = currentEntry.Password;
            txtPrivateKeyFile.Text = currentEntry.PrivateKeyFile;
            txtPassPhrase.Text = currentEntry.PassPhrase;

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

        private void optPassword_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = !optPassword.Checked;
            txtPassword.ReadOnly = !optPassword.Checked;
            txtPrivateKeyFile.ReadOnly = optPassword.Checked;
            cmdBrowsePrivateKeyFile.Enabled = !optPassword.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void optPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = optPrivateKey.Checked;
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdBrowsePrivateKeyFile.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void cmdBrowsePrivateKeyFile_Click(object sender, EventArgs e)
        {
            if (txtPrivateKeyFile.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtPrivateKeyFile.Text)))
            {
                privateKeyOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtPrivateKeyFile.Text);
            }
            if (privateKeyOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPrivateKeyFile.Text = privateKeyOpenFileDialog.FileName;
            }
        }

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
            selectedEntry.MachineName = txtMachineName.Text;
            selectedEntry.SSHPort = (int)sshPortNumericUpDown.Value;
            selectedEntry.SSHSecurityOption = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            selectedEntry.UserName = txtUsername.Text;

            selectedEntry.PrivateKeyFile = txtPrivateKeyFile.Text;
            selectedEntry.PassPhrase = txtPassPhrase.Text;
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
                    lvwDisks.Items.Add(new ListViewItem("Querying " + txtMachineName.Text + "..."));
                    Application.DoEvents();
                }
                QuickMon.Linux.SSHSecurityOption sshSecOpt = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(sshSecOpt, txtMachineName.Text, (int)sshPortNumericUpDown.Value, txtUsername.Text, txtPassword.Text, txtPrivateKeyFile.Text, txtPassPhrase.Text);
                if (sshClient.IsConnected)
                {
                    lvwDisks.Items.Clear();
                    foreach (Linux.DiskIOInfo di in QuickMon.Linux.DiskIOInfo.GetCurrentDiskStats(sshClient))
                    {
                        LinuxDiskIOSubEntry dsse = new LinuxDiskIOSubEntry() { Disk = di.Name, WarningValue = 10, ErrorValue = 5 };
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


    }
}
