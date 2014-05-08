using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditSocketPingEntry : Form
    {
        public EditSocketPingEntry()
        {
            InitializeComponent();
        }

        public SocketPingEntry SelectedSocketPingEntry { get; set; }

        #region Form events
        private void EditSocketPingEntry_Shown(object sender, EventArgs e)
        {
            if (SelectedSocketPingEntry != null)
            {
                txtAddress.Text = SelectedSocketPingEntry.HostName;
                nudPortNumber.Value = SelectedSocketPingEntry.PortNumber;
                nudTimeOut.Value = SelectedSocketPingEntry.PingTimeOutMS;
                nudReceiveTimeout.Value = SelectedSocketPingEntry.ReceiveTimeoutMS;
                nudSendTimeout.Value = SelectedSocketPingEntry.SendTimeoutMS;
                chkUseTelNetLogin.Checked = SelectedSocketPingEntry.UseTelnetLogin;
                txtUserName.Text = SelectedSocketPingEntry.UserName;
                txtPassword.Text = SelectedSocketPingEntry.Password;
            }
        }
        #endregion

        private void chkUseTelNetLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = chkUseTelNetLogin.Checked;
            txtPassword.Enabled = chkUseTelNetLogin.Checked;
        }

        #region Button events
        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            SocketPingEntry tmpSocketPingEntry = new SocketPingEntry();
            tmpSocketPingEntry.HostName = txtAddress.Text;
            tmpSocketPingEntry.PortNumber = (int)nudPortNumber.Value;
            tmpSocketPingEntry.PingTimeOutMS = (int)nudTimeOut.Value;
            tmpSocketPingEntry.ReceiveTimeoutMS = (int)nudReceiveTimeout.Value;
            tmpSocketPingEntry.SendTimeoutMS = (int)nudSendTimeout.Value;
            tmpSocketPingEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
            tmpSocketPingEntry.UserName = txtUserName.Text;
            tmpSocketPingEntry.Password = txtPassword.Text;
            try
            {
                int pingTime = tmpSocketPingEntry.Ping();
                if (pingTime == int.MaxValue)
                    throw new Exception("An error occured while trying to ping the URL\r\n" + tmpSocketPingEntry.LastError);

                MessageBox.Show(string.Format("Test success!\r\nTime: {0}ms", pingTime), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKButtonEnable())
            {
                SelectedSocketPingEntry = new SocketPingEntry();
                SelectedSocketPingEntry.HostName = txtAddress.Text;
                SelectedSocketPingEntry.PortNumber = (int)nudPortNumber.Value;
                SelectedSocketPingEntry.PingTimeOutMS = (int)nudTimeOut.Value;
                SelectedSocketPingEntry.ReceiveTimeoutMS = (int)nudReceiveTimeout.Value;
                SelectedSocketPingEntry.SendTimeoutMS = (int)nudSendTimeout.Value;
                SelectedSocketPingEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
                SelectedSocketPingEntry.UserName = txtUserName.Text;
                SelectedSocketPingEntry.Password = txtPassword.Text;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private bool CheckOKButtonEnable()
        {
            cmdOK.Enabled = txtAddress.Text.Length > 0;
            cmdTestAddress.Enabled = txtAddress.Text.Length > 0;
            return cmdOK.Enabled;
        }
        #endregion   

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOKButtonEnable();
        }

    
    }
}
