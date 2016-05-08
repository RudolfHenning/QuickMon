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
    public partial class LinuxProcessCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxProcessCollectorEditEntry()
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

        private void LinuxProcessCollectorEdit_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
            lvwProcesses.AutoResizeColumnEnabled = true;
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxProcessEntry currentEntry = (LinuxProcessEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxProcessEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            txtName.Text = currentEntry.Name;
            //txtCommandText.Text = currentEntry.CommandString;
            //optEWG.Checked = currentEntry.ValueReturnCheckSequence == CollectorAgentReturnValueCheckSequence.EWG;
            //cboReturnType.SelectedIndex = (int)currentEntry.ValueReturnType;
            //cboSuccessMatchType.SelectedIndex = (int)currentEntry.SuccessMatchType;
            //txtGoodValueOrMacro.Text = currentEntry.SuccessValueOrMacro;
            //cboWarningMatchType.SelectedIndex = (int)currentEntry.WarningMatchType;
            //txtWarningValueOrMacro.Text = currentEntry.WarningValueOrMacro;
            //cboErrorMatchType.SelectedIndex = (int)currentEntry.ErrorMatchType;
            //txtErrorValueOrMacro.Text = currentEntry.ErrorValueOrMacro;
        }
        #endregion

    }
}
