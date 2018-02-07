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
    public partial class NIXNICCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public NIXNICCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        private void NIXNICCollectorEditEntry_Load(object sender, EventArgs e)
        {
            lvwNICs.AutoResizeColumnEnabled = true;
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            NIXNICEntry currentEntry = (NIXNICEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new NIXNICEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            nudMeasuringDelayMS.Value = currentEntry.MeasuringDelayMS;

            foreach (NIXNICSubEntry dsse in currentEntry.SubItems)
            {
                ListViewItem lvi = new ListViewItem() { Text = dsse.NICName };
                lvi.SubItems.Add(dsse.WarningValueKB.ToString());
                lvi.SubItems.Add(dsse.ErrorValueKB.ToString());
                lvi.Tag = dsse;
                lvwNICs.Items.Add(lvi);
            }
        }
        #endregion

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

        private bool fileSystemUpdated = false;
        private void lvwNICs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwNICs.SelectedItems.Count == 1)
            {
                fileSystemUpdated = true;
                NIXNICSubEntry dsse = (NIXNICSubEntry)lvwNICs.SelectedItems[0].Tag;
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

        private void txtNIC_TextChanged(object sender, EventArgs e)
        {
            UpdateNICs();
        }

        private void warningNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateNICs();
        }

        private void errorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateNICs();
        }
        private void UpdateNICs()
        {
            if (txtNIC.Text.Trim().Length > 0 && !fileSystemUpdated)
            {
                if (lvwNICs.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwNICs.SelectedItems[0];
                    NIXNICSubEntry dsse = (NIXNICSubEntry)lvwNICs.SelectedItems[0].Tag;
                    dsse.NICName = txtNIC.Text;
                    dsse.WarningValueKB = (long)warningNumericUpDown.Value;
                    dsse.ErrorValueKB = (long)errorNumericUpDown.Value;
                    lvi.Text = txtNIC.Text;
                    lvi.SubItems[1].Text = warningNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = errorNumericUpDown.Value.ToString();
                }
                else
                {
                    NIXNICSubEntry dsse = new NIXNICSubEntry() { NICName = txtNIC.Text, WarningValueKB = (long)warningNumericUpDown.Value, ErrorValueKB = (long)errorNumericUpDown.Value };
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

        private void lvwNICs_DeleteKeyPressed()
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

                if (lvwNICs.Items.Count > 0 && (MessageBox.Show("Clear all existing entries?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No))
                {
                    return;
                }
                else
                {
                    lvwNICs.Items.Clear();
                    lvwNICs.Items.Add(new ListViewItem("Querying " + sshConnection.ComputerName + "..."));
                    Application.DoEvents();
                }

                Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(sshConnection);
                if (sshClient.IsConnected)
                {
                    lvwNICs.Items.Clear();
                    foreach (NicInfo di in NicInfo.GetCurrentNicStats(sshClient))
                    {
                        NIXNICSubEntry dsse = new NIXNICSubEntry() { NICName = di.Name, WarningValueKB = (long)warningNumericUpDown.Value, ErrorValueKB = (long)errorNumericUpDown.Value };
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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            NIXNICEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new NIXNICEntry();
            selectedEntry = (NIXNICEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.MeasuringDelayMS = (int)nudMeasuringDelayMS.Value;
            selectedEntry.SubItems = new List<ICollectorConfigSubEntry>();

            foreach (ListViewItem lvi in lvwNICs.Items)
            {
                NIXNICSubEntry dsse = (NIXNICSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
