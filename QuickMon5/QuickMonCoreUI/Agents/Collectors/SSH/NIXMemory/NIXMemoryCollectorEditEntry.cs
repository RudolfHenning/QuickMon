using QuickMon.Collectors;
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
    public partial class NIXMemoryCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public NIXMemoryCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        #region Private methods
        private void LoadEntryDetails()
        {
            NixMemoryEntry currentEntry = (NixMemoryEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new NixMemoryEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            cboLinuxMemoryType.SelectedIndex = (int)currentEntry.MemoryType;
            warningNumericUpDown.SaveValueSet((decimal)currentEntry.WarningValue);
            errorNumericUpDown.SaveValueSet((decimal)currentEntry.ErrorValue);
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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            NixMemoryEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new NixMemoryEntry();
            selectedEntry = (NixMemoryEntry)SelectedEntry;
            selectedEntry.MemoryType = (LinuxMemoryType)cboLinuxMemoryType.SelectedIndex;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.WarningValue = (double)warningNumericUpDown.Value;
            selectedEntry.ErrorValue = (double)errorNumericUpDown.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void NIXMemoryCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        private void EditSSHConnection()
        {
            EditSSHConnection editor = new Collectors.EditSSHConnection();
            editor.SSHConnectionDetails = sshConnectionDetails;
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }
    }
}
