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
    public partial class SSHCommandCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public SSHCommandCollectorEditEntry()
        {
            InitializeComponent();
        }

        private SSHConnectionDetails sshConnectionDetails = new SSHConnectionDetails();

        private void SSHCommandCollectorEditEntry_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            SSHCommandCollectorConfigEntry currentEntry;
            if (SelectedEntry != null)
            {
                currentEntry = (SSHCommandCollectorConfigEntry)SelectedEntry;
                sshConnectionDetails = currentEntry.SSHConnection;
                txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

                txtName.Text = currentEntry.Name;
                txtCommandText.Text = currentEntry.CommandString;
                cboReturnType.SelectedIndex = (int)currentEntry.ValueReturnType;
                cboReturnCheckSequence.SelectedIndex = (int)currentEntry.ReturnCheckSequence;
                txtSuccess.Text = currentEntry.GoodValue;
                cboSuccessMatchType.SelectedIndex = (int)currentEntry.GoodResultMatchType;
                if (currentEntry.WarningValue != null && currentEntry.WarningValue.Length > 0)
                    txtWarning.Text = currentEntry.WarningValue;
                cboWarningMatchType.SelectedIndex = (int)currentEntry.WarningResultMatchType;
                if (currentEntry.ErrorValue != null && currentEntry.ErrorValue.Length > 0)
                    txtError.Text = currentEntry.ErrorValue;
                cboErrorMatchType.SelectedIndex = (int)currentEntry.ErrorResultMatchType;
                cboOutputValueUnit.Text = currentEntry.OutputValueUnit;
            }
            else
                currentEntry = new SSHCommandCollectorConfigEntry();            
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
            if (editor.ShowDialog() == DialogResult.OK)
            {
                sshConnectionDetails = editor.SSHConnectionDetails;
                txtSSHConnection.Text = SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = ApplyConfigVarsOnField(txtCommandText.Text);
                string successText = ApplyConfigVarsOnField(txtSuccess.Text);
                string warningText = ApplyConfigVarsOnField(txtWarning.Text);
                string errorText = ApplyConfigVarsOnField(txtError.Text);
                string connectionString = ApplyConfigVarsOnField(sshConnectionDetails.ConnectionString);
                SSHConnectionDetails sshConnection;
                if (connectionString.Length > 0)
                    sshConnection = SSHConnectionDetails.FromConnectionString(connectionString);
                else
                {
                    sshConnection = sshConnectionDetails.Clone();
                    sshConnection.ComputerName = ApplyConfigVarsOnField(sshConnection.ComputerName);
                    sshConnection.UserName = ApplyConfigVarsOnField(sshConnection.UserName);
                    sshConnection.Password = ApplyConfigVarsOnField(sshConnection.Password);
                    sshConnection.PrivateKeyFile = ApplyConfigVarsOnField(sshConnection.PrivateKeyFile);
                    sshConnection.PassPhrase = ApplyConfigVarsOnField(sshConnection.PassPhrase);
                    sshConnection.ConnectionName = ApplyConfigVarsOnField(sshConnection.ConnectionName);
                }                

                SSHCommandCollectorConfigEntry testEntry = new SSHCommandCollectorConfigEntry() { SSHConnection = sshConnection };

                testEntry.CommandString = commandText;
                testEntry.ValueReturnType = (SSHCommandValueReturnType)cboReturnType.SelectedIndex;
                testEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                testEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                testEntry.GoodValue = successText;
                testEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.WarningValue = warningText;
                testEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                testEntry.ErrorValue = errorText;
                testEntry.OutputValueUnit = cboOutputValueUnit.Text;

                string value = testEntry.ExecuteCommand();
                CollectorState currentState = CollectorAgentReturnValueCompareEngine.GetState(testEntry.ReturnCheckSequence, 
                        testEntry.GoodResultMatchType, testEntry.GoodValue,
                        testEntry.WarningResultMatchType, testEntry.WarningValue, 
                        testEntry.ErrorResultMatchType, testEntry.ErrorValue, value);

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
                SSHCommandCollectorConfigEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new SSHCommandCollectorConfigEntry();
                selectedEntry = (SSHCommandCollectorConfigEntry)SelectedEntry;
                selectedEntry.SSHConnection = sshConnectionDetails;
                selectedEntry.Name = txtName.Text;
                selectedEntry.CommandString = txtCommandText.Text;
                selectedEntry.ValueReturnType = (SSHCommandValueReturnType)cboReturnType.SelectedIndex;
                selectedEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                selectedEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                selectedEntry.GoodValue = txtSuccess.Text;
                selectedEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                selectedEntry.WarningValue = txtWarning.Text;
                selectedEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                selectedEntry.ErrorValue = txtError.Text;
                selectedEntry.OutputValueUnit = cboOutputValueUnit.Text;

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
