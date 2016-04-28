using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class EditSSHConnection : Form
    {
        public EditSSHConnection()
        {
            InitializeComponent();
        }

        public QuickMon.Linux.SSHConnectionDetails SSHConnectionDetails { get; set; }        

        private void EditSSHConnection_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            txtMachineName.Text = SSHConnectionDetails.ComputerName;
            sshPortNumericUpDown.SaveValueSet(SSHConnectionDetails.SSHPort);
            optPrivateKey.Checked = SSHConnectionDetails.SSHSecurityOption == Linux.SSHSecurityOption.PrivateKey;
            txtUsername.Text = SSHConnectionDetails.UserName;
            txtPassword.Text = SSHConnectionDetails.Password;
            txtPrivateKeyFile.Text = SSHConnectionDetails.PrivateKeyFile;
            txtPassPhrase.Text = SSHConnectionDetails.PassPhrase;            
        }
        #endregion

        private void optPassword_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = !optPassword.Checked;
            txtPassword.ReadOnly = !optPassword.Checked;
            txtPrivateKeyFile.ReadOnly = optPassword.Checked;
            cmdBrowsePrivateKeyFile.Enabled = !optPassword.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void optPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            //txtUsername.ReadOnly = optPrivateKey.Checked;
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdBrowsePrivateKeyFile.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = optPassword.Checked;
        }

        private void cmdBrowsePrivateKeyFile_Click(object sender, EventArgs e)
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
            SSHConnectionDetails.ComputerName = txtMachineName.Text;
            SSHConnectionDetails.SSHPort = (int)sshPortNumericUpDown.Value;
            SSHConnectionDetails.SSHSecurityOption = optPrivateKey.Checked ? Linux.SSHSecurityOption.PrivateKey : Linux.SSHSecurityOption.Password;
            SSHConnectionDetails.UserName = txtUsername.Text;
            SSHConnectionDetails.Password = txtPassword.Text;
            SSHConnectionDetails.PrivateKeyFile = txtPrivateKeyFile.Text;
            SSHConnectionDetails.PassPhrase = txtPassPhrase.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {

        }
    }
}
