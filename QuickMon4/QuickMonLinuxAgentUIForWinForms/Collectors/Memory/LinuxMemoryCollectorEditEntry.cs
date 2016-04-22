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
            txtMachineName.Text = currentEntry.MachineName;
            sshPortNumericUpDown.SaveValueSet(currentEntry.SSHPort);
            optPrivateKey.Checked = currentEntry.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = currentEntry.UserName;
            txtPassword.Text = currentEntry.Password;
            txtPrivateKeyFile.Text = currentEntry.PrivateKeyFile;
            txtPassPhrase.Text = currentEntry.PassPhrase;
            warningNumericUpDown.SaveValueSet((decimal)currentEntry.WarningValue);
            errorNumericUpDown.SaveValueSet((decimal)currentEntry.ErrorValue);
        }
        #endregion

        private void optPassword_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = !optPassword.Checked;
            txtPassword.ReadOnly = !optPassword.Checked;
            txtPrivateKeyFile.ReadOnly = optPassword.Checked;
            cmdEditPerfCounter.Enabled = !optPassword.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void optPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = optPrivateKey.Checked;
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdEditPerfCounter.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxMemoryEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxMemoryEntry();
            selectedEntry = (LinuxMemoryEntry)SelectedEntry;
            selectedEntry.MachineName = txtMachineName.Text;
            selectedEntry.SSHPort = (int)sshPortNumericUpDown.Value;
            selectedEntry.SSHSecurityOption = optPrivateKey.Checked ? QuickMon.Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            selectedEntry.UserName = txtUsername.Text;

            selectedEntry.PrivateKeyFile = txtPrivateKeyFile.Text;
            selectedEntry.PassPhrase = txtPassPhrase.Text;
            selectedEntry.WarningValue = (double)warningNumericUpDown.Value;
            selectedEntry.ErrorValue = (double)errorNumericUpDown.Value;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
