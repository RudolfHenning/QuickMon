using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class LinuxMemoryCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxMemoryCollectorEditEntry()
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

        private void LinuxMemoryCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxMemoryEntry currentEntry = (LinuxMemoryEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxMemoryEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            warningNumericUpDown.SaveValueSet((decimal)currentEntry.WarningValue);
            errorNumericUpDown.SaveValueSet((decimal)currentEntry.ErrorValue);
        }
        #endregion
        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxMemoryEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxMemoryEntry();
            selectedEntry = (LinuxMemoryEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.WarningValue = (double)warningNumericUpDown.Value;
            selectedEntry.ErrorValue = (double)errorNumericUpDown.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lblEditSSHConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void txtSSHConnection_DoubleClick(object sender, EventArgs e)
        {
            EditSSHConnection();
        }
    }
}
