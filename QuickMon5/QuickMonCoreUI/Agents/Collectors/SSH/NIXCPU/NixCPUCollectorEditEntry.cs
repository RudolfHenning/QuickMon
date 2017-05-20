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
    public partial class NixCPUCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public NixCPUCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        private void NixCPUCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }
        #region Private methods
        private void LoadEntryDetails()
        {
            NixCPUEntry currentEntry = (NixCPUEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new NixCPUEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            chkUseOnlyTotalCPUvalue.Checked = currentEntry.UseOnlyTotalCPUvalue;
            nudMSSampleDelay.SaveValueSet(currentEntry.MSSampleDelay);
            warningNumericUpDown.SaveValueSet((decimal)currentEntry.WarningValue);
            errorNumericUpDown.SaveValueSet((decimal)currentEntry.ErrorValue);
        }
        #endregion

        private void cmdOK_Click(object sender, EventArgs e)
        {
            NixCPUEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new NixCPUEntry();
            selectedEntry = (NixCPUEntry)SelectedEntry;

            selectedEntry.SSHConnection = sshConnectionDetails;

            selectedEntry.UseOnlyTotalCPUvalue = chkUseOnlyTotalCPUvalue.Checked;
            selectedEntry.MSSampleDelay = (int)nudMSSampleDelay.Value;
            selectedEntry.WarningValue = (double)warningNumericUpDown.Value;
            selectedEntry.ErrorValue = (double)errorNumericUpDown.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void txtSSHConnection_DoubleClick(object sender, EventArgs e)
        {
            EditSSHConnection();
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
                txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }
    }
}
