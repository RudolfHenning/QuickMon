﻿using System;
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
            txtMachineName.Text = currentEntry.MachineName;
            sshPortNumericUpDown.SaveValueSet(currentEntry.SSHPort);
            optPrivateKey.Checked = currentEntry.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = currentEntry.UserName;
            txtPassword.Text = currentEntry.Password;
            txtPrivateKeyFile.Text = currentEntry.PrivateKeyFile;
            txtPassPhrase.Text = currentEntry.PassPhrase;

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
            selectedEntry.MachineName = txtMachineName.Text;
            selectedEntry.SSHPort = (int)sshPortNumericUpDown.Value;
            selectedEntry.SSHSecurityOption = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            selectedEntry.UserName = txtUsername.Text;

            selectedEntry.PrivateKeyFile = txtPrivateKeyFile.Text;
            selectedEntry.PassPhrase = txtPassPhrase.Text;
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
                    lvwNICs.Items.Add(new ListViewItem("Querying " + txtMachineName.Text + "..."));
                    Application.DoEvents();
                }                

                QuickMon.Linux.SSHSecurityOption sshSecOpt = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(sshSecOpt, txtMachineName.Text, (int)sshPortNumericUpDown.Value, txtUsername.Text, txtPassword.Text, txtPrivateKeyFile.Text, txtPassPhrase.Text);
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


    }
}
