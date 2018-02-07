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
    public partial class NIXDiskIOCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public NIXDiskIOCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        private void NIXDiskIOCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwDisks.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            NIXDiskIOEntry currentEntry = (NIXDiskIOEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new NIXDiskIOEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            foreach (NIXDiskIOSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.DiskName };
                lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
                lvi.Tag = dsse;
                lvwDisks.Items.Add(lvi);
            }
        }
        #endregion

        private bool fileSystemUpdated = false;
        private void lvwDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDisks.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                NIXDiskIOSubEntry dsse = (NIXDiskIOSubEntry)lvwDisks.SelectedItems[0].Tag;
                warningNumericUpDown.SaveValueSet((decimal)dsse.WarningValueKB);
                errorNumericUpDown.SaveValueSet((decimal)dsse.ErrorValueKB);
                txtDisk.Text = dsse.DiskName;
                fileSystemUpdated = false;
            }
            else if (lvwDisks.SelectedItems.Count == 0)
            {
                fileSystemUpdated = true;
                txtDisk.Text = "";
                fileSystemUpdated = false;
            }
        }

        private void txtDisk_TextChanged(object sender, EventArgs e)
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
                    NIXDiskIOSubEntry dsse = (NIXDiskIOSubEntry)lvwDisks.SelectedItems[0].Tag;
                    dsse.DiskName = txtDisk.Text;
                    dsse.WarningValueKB = (double)warningNumericUpDown.Value;
                    dsse.ErrorValueKB = (double)errorNumericUpDown.Value;
                    lvi.Text = txtDisk.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    NIXDiskIOSubEntry dsse = new NIXDiskIOSubEntry() { DiskName = txtDisk.Text, WarningValueKB = (double)warningNumericUpDown.Value, ErrorValueKB = (double)errorNumericUpDown.Value };
                    ListViewItem lvi = new ListViewItem() { Text = dsse.DiskName };
                    lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                    lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
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

                if (lvwDisks.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwDisks.Items.Clear();
                    lvwDisks.Items.Add(new ListViewItem("Querying " + sshConnection.ComputerName + "..."));
                    Application.DoEvents();
                }
                Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(sshConnection);
                if (sshClient.IsConnected)
                {
                    lvwDisks.Items.Clear();
                    foreach (DiskIOInfo di in DiskIOInfo.GetCurrentDiskStats(sshClient))
                    {
                        NIXDiskIOSubEntry dsse = new NIXDiskIOSubEntry() { DiskName = di.Name, WarningValueKB = (double)warningNumericUpDown.Value, ErrorValueKB = (double)errorNumericUpDown.Value };
                        ListViewItem lvi = new ListViewItem() { Text = dsse.DiskName };
                        lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                        lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
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

        private void lvwDisks_DeleteKeyPressed()
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
            NIXDiskIOEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new NIXDiskIOEntry();
            selectedEntry = (NIXDiskIOEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach (ListViewItem lvi in lvwDisks.Items)
            {
                NIXDiskIOSubEntry dsse = (NIXDiskIOSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }


            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
