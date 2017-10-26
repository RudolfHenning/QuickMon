using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.SSH;

namespace QuickMon.Collectors
{
    public partial class EditSSHConnection : Form
    {
        public EditSSHConnection()
        {
            InitializeComponent();
        }

        private bool changed = false;
        public SSHConnectionDetails SSHConnectionDetails { get; set; }        

        private void EditSSHConnection_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            if (SSHConnectionDetails.ConnectionString != null && !SSHConnectionDetails.ConnectionString.Contains(';'))
            {
                txtConnectionString.Text = SSHConnectionDetails.ConnectionString;
                SSHConnectionDetails = SSHConnectionDetails.FromConnectionString(txtConnectionString.Text);
            }

            txtMachineName.Text = SSHConnectionDetails.ComputerName;
            sshPortNumericUpDown.SaveValueSet(SSHConnectionDetails.SSHPort);
            optPrivateKey.Checked = SSHConnectionDetails.SSHSecurityOption == SSHSecurityOption.PrivateKey;
            optKeyboardInteractive.Checked = SSHConnectionDetails.SSHSecurityOption == SSHSecurityOption.KeyboardInteractive;
            txtUsername.Text = SSHConnectionDetails.UserName;
            txtPassword.Text = SSHConnectionDetails.Password;
            txtPrivateKeyFile.Text = SSHConnectionDetails.PrivateKeyFile;
            txtPassPhrase.Text = SSHConnectionDetails.PassPhrase;
            chkPersistent.Checked = SSHConnectionDetails.Persistent;

            changed = false;
        }
        #endregion

        #region Security options
        private void optPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdBrowsePrivateKeyFile.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = !optPrivateKey.Checked;
            changed = true;
        }
        private void optPrivateKey_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdBrowsePrivateKeyFile.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = !optPrivateKey.Checked;
            changed = true;
        }
        private void optKeyboardInteractive_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = optPrivateKey.Checked;
            txtPrivateKeyFile.ReadOnly = !optPrivateKey.Checked;
            cmdBrowsePrivateKeyFile.Enabled = optPrivateKey.Checked;
            txtPassPhrase.ReadOnly = !optPrivateKey.Checked;
            changed = true;
        }
        #endregion

        #region Button events
        private void cmdBrowsePrivateKeyFile_Click(object sender, EventArgs e)
        {
            if (txtPrivateKeyFile.Text.Length > 0 && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtPrivateKeyFile.Text)))
            {
                privateKeyOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtPrivateKeyFile.Text);
            }
            if (privateKeyOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtPrivateKeyFile.Text = privateKeyOpenFileDialog.FileName;
                changed = true;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SSHConnectionDetails.ComputerName = txtMachineName.Text;
            SSHConnectionDetails.SSHPort = (int)sshPortNumericUpDown.Value;
            SSHConnectionDetails.SSHSecurityOption = optPrivateKey.Checked ? SSHSecurityOption.PrivateKey : optPassword.Checked ? SSHSecurityOption.Password : SSHSecurityOption.KeyboardInteractive;
            SSHConnectionDetails.UserName = txtUsername.Text;
            SSHConnectionDetails.Password = txtPassword.Text;
            SSHConnectionDetails.PrivateKeyFile = txtPrivateKeyFile.Text;
            SSHConnectionDetails.PassPhrase = txtPassPhrase.Text;
            SSHConnectionDetails.Persistent = chkPersistent.Checked;
            SSHConnectionDetails.ConnectionString = "";
            SSHConnectionDetails.ConnectionString = SSHConnectionDetails.FormatSSHConnection(SSHConnectionDetails);
            if (txtConnectionString.Text.Trim().Length > 0)
            {
                if (changed)
                {
                    try
                    {
                        DialogResult overwriteChoice = DialogResult.Yes;

                        if (System.IO.File.Exists(txtConnectionString.Text))
                        {
                            overwriteChoice = MessageBox.Show("Overwrite the connection file?", "Connection file", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (overwriteChoice == DialogResult.Cancel)
                                return;
                        }
                        if (overwriteChoice == DialogResult.Yes)
                            System.IO.File.WriteAllText(txtConnectionString.Text, SSHConnectionDetails.ConnectionString);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Saving connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                SSHConnectionDetails.ConnectionString = txtConnectionString.Text;
            }
            
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(optPrivateKey.Checked ? SSHSecurityOption.PrivateKey : optPassword.Checked ? SSHSecurityOption.Password : SSHSecurityOption.KeyboardInteractive, txtMachineName.Text, (int)sshPortNumericUpDown.Value, txtUsername.Text, txtPassword.Text, txtPrivateKeyFile.Text, txtPassPhrase.Text))
                {
                    if (sshClient.IsConnected)
                    {
                        MessageBox.Show(string.Format("Success\r\n{0}", sshClient.RunCommand("cat /proc/version").Result), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    sshClient.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Fail!\r\n{0}", ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void cmdOpenConnectionStringFile_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text.Trim().Length > 0)
            {
                connectionStringFileOpenFileDialog.FileName = txtConnectionString.Text;
                connectionStringFileOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtConnectionString.Text);
            }

            if (connectionStringFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                SSHConnectionDetails = SSHConnectionDetails.FromConnectionString(connectionStringFileOpenFileDialog.FileName);
                LoadEntryDetails();
            }
        }
        private void cmdSaveToFile_Click(object sender, EventArgs e)
        {
            if (connectionStringSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtConnectionString.Text = connectionStringSaveFileDialog.FileName;
                System.IO.File.WriteAllText(txtConnectionString.Text, SSHConnectionDetails.ConnectionString);
            }
        }

        private void txtConnectionString_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtMachineName.Text.Length == 0 && System.IO.File.Exists(txtConnectionString.Text))
                {
                    SSHConnectionDetails = SSHConnectionDetails.FromConnectionString(txtConnectionString.Text);
                    LoadEntryDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtMachineName_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
        private void txtPassPhrase_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            changed = true;
        }
        private void chkPersistent_CheckedChanged(object sender, EventArgs e)
        {
            changed = true;
        }


    }
}
