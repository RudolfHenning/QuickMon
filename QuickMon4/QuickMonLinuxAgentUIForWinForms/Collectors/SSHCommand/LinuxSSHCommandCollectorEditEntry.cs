using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class LinuxSSHCommandCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxSSHCommandCollectorEditEntry()
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

        private void LinuxSSHCommandCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxSSHCommandEntry currentEntry = (LinuxSSHCommandEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxSSHCommandEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            txtName.Text = currentEntry.Name;
            txtCommandText.Text = currentEntry.CommandString;
            optEWG.Checked = currentEntry.ValueReturnCheckSequence == CollectorAgentReturnValueCheckSequence.EWG;
            cboReturnType.SelectedIndex = (int)currentEntry.ValueReturnType;
            cboSuccessMatchType.SelectedIndex = (int)currentEntry.SuccessMatchType;
            txtGoodValueOrMacro.Text = currentEntry.SuccessValueOrMacro;
            cboWarningMatchType.SelectedIndex = (int)currentEntry.WarningMatchType;
            txtWarningValueOrMacro.Text = currentEntry.WarningValueOrMacro;
            cboErrorMatchType.SelectedIndex = (int)currentEntry.ErrorMatchType;
            txtErrorValueOrMacro.Text = currentEntry.ErrorValueOrMacro;
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
            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                LinuxSSHCommandEntry testEntry = new LinuxSSHCommandEntry() { SSHConnection = sshConnectionDetails };
                testEntry.CommandString = txtCommandText.Text;

                testEntry.ValueReturnCheckSequence = optEWG.Checked ? CollectorAgentReturnValueCheckSequence.EWG : CollectorAgentReturnValueCheckSequence.GWE;
                testEntry.ValueReturnType = (SSHCommandValueReturnType)cboReturnType.SelectedIndex;
                testEntry.SuccessMatchType= (CollectorAgentReturnValueCompareMatchType )cboSuccessMatchType.SelectedIndex;
                testEntry.SuccessValueOrMacro = txtGoodValueOrMacro.Text;
                testEntry.WarningMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.WarningValueOrMacro = txtWarningValueOrMacro.Text;
                testEntry.ErrorMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                testEntry.ErrorValueOrMacro = txtErrorValueOrMacro.Text;

                string value = testEntry.ExecuteCommand();
                CollectorState currentState = CollectorAgentReturnValueCompareEngine.GetState(testEntry.ValueReturnCheckSequence, testEntry.SuccessMatchType, testEntry.SuccessValueOrMacro,
                    testEntry.WarningMatchType, testEntry.WarningValueOrMacro, testEntry.ErrorMatchType, testEntry.ErrorValueOrMacro, value);

                MessageBox.Show(string.Format("Returned state: {0}\r\nOutput: {1}", currentState, value), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                LinuxSSHCommandEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new LinuxSSHCommandEntry();
                selectedEntry = (LinuxSSHCommandEntry)SelectedEntry;
                selectedEntry.SSHConnection = sshConnectionDetails;
                selectedEntry.Name = txtName.Text;
                selectedEntry.CommandString = txtCommandText.Text;

                selectedEntry.ValueReturnCheckSequence = optEWG.Checked ? CollectorAgentReturnValueCheckSequence.EWG : CollectorAgentReturnValueCheckSequence.GWE;
                selectedEntry.ValueReturnType = (SSHCommandValueReturnType)cboReturnType.SelectedIndex;
                selectedEntry.SuccessMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                selectedEntry.SuccessValueOrMacro = txtGoodValueOrMacro.Text;
                selectedEntry.WarningMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                selectedEntry.WarningValueOrMacro = txtWarningValueOrMacro.Text;
                selectedEntry.ErrorMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                selectedEntry.ErrorValueOrMacro = txtErrorValueOrMacro.Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
