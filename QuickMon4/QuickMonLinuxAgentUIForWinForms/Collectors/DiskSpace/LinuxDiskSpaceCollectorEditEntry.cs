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
    public partial class LinuxDiskSpaceCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxDiskSpaceCollectorEditEntry()
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

        private void LinuxDiskSpaceCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwFileSystems.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxDiskSpaceEntry currentEntry = (LinuxDiskSpaceEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxDiskSpaceEntry();
            txtMachineName.Text = currentEntry.MachineName;
            sshPortNumericUpDown.SaveValueSet(currentEntry.SSHPort);
            optPrivateKey.Checked = currentEntry.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = currentEntry.UserName;
            txtPassword.Text = currentEntry.Password;
            txtPrivateKeyFile.Text = currentEntry.PrivateKeyFile;
            txtPassPhrase.Text = currentEntry.PassPhrase;

            foreach (LinuxDiskSpaceSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.FileSystemName };
                lvi.SubItems.Add(dsse.WarningValue.ToString());
                lvi.SubItems.Add(dsse.ErrorValue.ToString());
                lvi.Tag = dsse;
                lvwFileSystems.Items.Add(lvi);
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

        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
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
            if (lvwFileSystems.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                LinuxDiskSpaceSubEntry dsse =  (LinuxDiskSpaceSubEntry)lvwFileSystems.SelectedItems[0].Tag;                
                warningNumericUpDown.SaveValueSet((decimal)dsse.WarningValue);
                errorNumericUpDown.SaveValueSet((decimal)dsse.ErrorValue);
                txtFileSystem.Text = dsse.FileSystemName;
                fileSystemUpdated = false;
            }
            else if (lvwFileSystems.SelectedItems.Count == 0)
            {
                fileSystemUpdated = true;
                txtFileSystem.Text = "";
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
            if (txtFileSystem.Text.Trim().Length > 0 && !fileSystemUpdated)
            {
                if (lvwFileSystems.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwFileSystems.SelectedItems[0];
                    LinuxDiskSpaceSubEntry dsse = (LinuxDiskSpaceSubEntry)lvwFileSystems.SelectedItems[0].Tag;
                    dsse.FileSystemName = txtFileSystem.Text;
                    dsse.WarningValue = (double)warningNumericUpDown.Value;
                    dsse.ErrorValue = (double)errorNumericUpDown.Value;
                    lvi.Text = txtFileSystem.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    LinuxDiskSpaceSubEntry dsse = new LinuxDiskSpaceSubEntry() { FileSystemName = txtFileSystem.Text, WarningValue = (double)warningNumericUpDown.Value, ErrorValue = (double)errorNumericUpDown.Value };
                    ListViewItem lvi = new ListViewItem() { Text = dsse.FileSystemName };
                    lvi.SubItems.Add(dsse.WarningValue.ToString());
                    lvi.SubItems.Add(dsse.ErrorValue.ToString());
                    lvi.Tag = dsse;
                    lvwFileSystems.Items.Add(lvi);
                    lvwFileSystems.SelectedItems.Clear();                    
                    lvi.Selected = true;
                }
            }
        }

        private void lblAddFileSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvwFileSystems.SelectedItems.Clear();
            txtFileSystem.Text = "";
        }

        private void lvwFileSystems_DeleteKeyPressed()
        {
            if (lvwFileSystems.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach(ListViewItem lvi in lvwFileSystems.SelectedItems)
                    {
                        lvwFileSystems.Items.Remove(lvi);
                    }
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxDiskSpaceEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxDiskSpaceEntry();
            selectedEntry = (LinuxDiskSpaceEntry)SelectedEntry;
            selectedEntry.MachineName = txtMachineName.Text;
            selectedEntry.SSHPort = (int)sshPortNumericUpDown.Value;
            selectedEntry.SSHSecurityOption = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            selectedEntry.UserName = txtUsername.Text;

            selectedEntry.PrivateKeyFile = txtPrivateKeyFile.Text;
            selectedEntry.PassPhrase = txtPassPhrase.Text;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach(ListViewItem lvi in lvwFileSystems.Items)
            {
                LinuxDiskSpaceSubEntry dsse = (LinuxDiskSpaceSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lblAutoAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lvwFileSystems.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwFileSystems.Items.Clear();
                    lvwFileSystems.Items.Add(new ListViewItem("Querying " + txtMachineName.Text + "..."));
                    Application.DoEvents();
                }
                QuickMon.Linux.SSHSecurityOption sshSecOpt = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(sshSecOpt, txtMachineName.Text, (int)sshPortNumericUpDown.Value, txtUsername.Text, txtPassword.Text, txtPrivateKeyFile.Text, txtPassPhrase.Text);
                if (sshClient.IsConnected)
                {
                    lvwFileSystems.Items.Clear();
                    foreach (Linux.DiskInfo di in QuickMon.Linux.DiskInfo.FromDfTk(sshClient))
                    {
                        LinuxDiskSpaceSubEntry dsse = new LinuxDiskSpaceSubEntry() { FileSystemName = di.Name, WarningValue = 10, ErrorValue = 5 };
                        ListViewItem lvi = new ListViewItem() { Text = dsse.FileSystemName };
                        lvi.SubItems.Add(dsse.WarningValue.ToString());
                        lvi.SubItems.Add(dsse.ErrorValue.ToString());
                        lvi.Tag = dsse;
                        lvwFileSystems.Items.Add(lvi);
                    }
                }
                else
                {
                    lvwFileSystems.Items.Clear();
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
