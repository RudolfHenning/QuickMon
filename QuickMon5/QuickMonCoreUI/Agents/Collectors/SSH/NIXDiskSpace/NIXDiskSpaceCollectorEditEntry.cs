using QuickMon.Collectors;
using QuickMon.NIX;
using QuickMon.SSH;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class NIXDiskSpaceCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public NIXDiskSpaceCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        private void NIXDiskSpaceCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwFileSystems.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            NIXDiskSpaceEntry currentEntry = (NIXDiskSpaceEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new NIXDiskSpaceEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            foreach (NIXDiskSpaceSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.FileSystemName };
                lvi.SubItems.Add(dsse.WarningValue.ToString());
                lvi.SubItems.Add(dsse.ErrorValue.ToString());
                lvi.Tag = dsse;
                lvwFileSystems.Items.Add(lvi);
            }
        }
        #endregion

        private bool fileSystemUpdated = false;
        private void lvwFileSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwFileSystems.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                NIXDiskSpaceSubEntry dsse = (NIXDiskSpaceSubEntry)lvwFileSystems.SelectedItems[0].Tag;
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
                    NIXDiskSpaceSubEntry dsse = (NIXDiskSpaceSubEntry)lvwFileSystems.SelectedItems[0].Tag;
                    dsse.FileSystemName = txtFileSystem.Text;
                    dsse.WarningValue = (double)warningNumericUpDown.Value;
                    dsse.ErrorValue = (double)errorNumericUpDown.Value;
                    lvi.Text = txtFileSystem.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    NIXDiskSpaceSubEntry dsse = new NIXDiskSpaceSubEntry() { FileSystemName = txtFileSystem.Text, WarningValue = (double)warningNumericUpDown.Value, ErrorValue = (double)errorNumericUpDown.Value };
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

        private void lblAutoAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SSHConnectionDetails sshConnection = sshConnectionDetails.Clone();
                sshConnection.ComputerName = ApplyConfigVarsOnField(sshConnection.ComputerName);
                sshConnection.UserName = ApplyConfigVarsOnField(sshConnection.UserName);
                sshConnection.Password = ApplyConfigVarsOnField(sshConnection.Password);
                sshConnection.PrivateKeyFile = ApplyConfigVarsOnField(sshConnection.PrivateKeyFile);
                sshConnection.PassPhrase = ApplyConfigVarsOnField(sshConnection.PassPhrase);
                sshConnection.ConnectionName = ApplyConfigVarsOnField(sshConnection.ConnectionName);
                sshConnection.ConnectionString = ApplyConfigVarsOnField(sshConnection.ConnectionString);

                if (lvwFileSystems.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwFileSystems.Items.Clear();
                    lvwFileSystems.Items.Add(new ListViewItem("Querying " + sshConnection.ComputerName + "..."));
                    Application.DoEvents();
                }
                Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(sshConnection);
                if (sshClient.IsConnected)
                {
                    lvwFileSystems.Items.Clear();
                    foreach (DiskInfo di in DiskInfo.FromDfTk(sshClient))
                    {
                        NIXDiskSpaceSubEntry dsse = new NIXDiskSpaceSubEntry() { FileSystemName = di.Name, WarningValue = (double)warningNumericUpDown.Value, ErrorValue = (double)errorNumericUpDown.Value };
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

        private void lvwFileSystems_DeleteKeyPressed()
        {
            if (lvwFileSystems.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwFileSystems.SelectedItems)
                    {
                        lvwFileSystems.Items.Remove(lvi);
                    }
                }
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
            editor.ConfigVariables = ConfigVariables;
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            NIXDiskSpaceEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new NIXDiskSpaceEntry();
            selectedEntry = (NIXDiskSpaceEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach (ListViewItem lvi in lvwFileSystems.Items)
            {
                NIXDiskSpaceSubEntry dsse = (NIXDiskSpaceSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
