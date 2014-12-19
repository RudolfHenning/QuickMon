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
    public partial class PingCollectorEditHostAddress : Form, IAgentConfigEntryEditWindow
    {
        public PingCollectorEditHostAddress()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            if (SelectedEntry == null)
                SelectedEntry = new PingCollectorHostEntry();
            HostEntry = (PingCollectorHostEntry)SelectedEntry;
            switch (HostEntry.PingType)
            {
                case PingCollectorType.HTTP:
                    cboPingType.SelectedIndex = 1;
                    break;
                case PingCollectorType.Socket:
                    cboPingType.SelectedIndex = 2;
                    break;
                default:
                    cboPingType.SelectedIndex = 0;
                    break;
            }
            txtAddress.Text = HostEntry.Address;
            txtDescription.Text = HostEntry.DescriptionLocal;
            nudExpextedTime.Value = HostEntry.MaxTimeMS;
            nudTimeOut.Value = HostEntry.TimeOutMS;
            txtHttpProxy.Text = HostEntry.HttpProxyServer;
            nudPortNumber.Value = HostEntry.SocketPort;
            nudReceiveTimeout.Value = HostEntry.ReceiveTimeOutMS;
            nudSendTimeout.Value = HostEntry.SendTimeOutMS;
            chkUseTelNetLogin.Checked = HostEntry.UseTelnetLogin;
            txtUserName.Text = HostEntry.TelnetUserName;
            txtPassword.Text = HostEntry.TelnetPassword;
            return (QuickMonDialogResult)ShowDialog();
        }

        #endregion

        private PingCollectorHostEntry HostEntry { get; set; }

        public DialogResult ShowHostAddress()
        {
            switch (HostEntry.PingType)
            {
                case PingCollectorType.HTTP:
                    cboPingType.SelectedIndex = 1;
                    break;
                case PingCollectorType.Socket:
                    cboPingType.SelectedIndex = 2;
                    break;
                default:
                    cboPingType.SelectedIndex = 0;
                    break;
            }
            txtAddress.Text = HostEntry.Address;
            txtDescription.Text = HostEntry.DescriptionLocal;
            nudExpextedTime.Value = HostEntry.MaxTimeMS;
            nudTimeOut.Value = HostEntry.TimeOutMS;
            txtHttpProxy.Text = HostEntry.HttpProxyServer;
            chkIgnoreInvalidHTTPSCerts.Checked = HostEntry.IgnoreInvalidHTTPSCerts;
            nudPortNumber.Value = HostEntry.SocketPort;
            nudReceiveTimeout.Value = HostEntry.ReceiveTimeOutMS;
            nudSendTimeout.Value = HostEntry.SendTimeOutMS;
            chkUseTelNetLogin.Checked = HostEntry.UseTelnetLogin;
            txtUserName.Text = HostEntry.TelnetUserName;
            txtPassword.Text = HostEntry.TelnetPassword;
            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length == 0)
            {
                txtAddress.Focus();
            }
            else if (RunPingTestWithPrompt().Success)
            {
                if (cboPingType.SelectedIndex == 1)
                    HostEntry.PingType = PingCollectorType.HTTP;
                else if (cboPingType.SelectedIndex == 2)
                    HostEntry.PingType = PingCollectorType.Socket;
                else
                    HostEntry.PingType = PingCollectorType.Ping;

                HostEntry.Address = txtAddress.Text;
                HostEntry.DescriptionLocal = txtDescription.Text;
                HostEntry.MaxTimeMS = Convert.ToInt32(nudExpextedTime.Value);
                HostEntry.TimeOutMS = Convert.ToInt32(nudTimeOut.Value);
                HostEntry.HttpProxyServer = txtHttpProxy.Text;
                HostEntry.IgnoreInvalidHTTPSCerts = chkIgnoreInvalidHTTPSCerts.Checked;
                HostEntry.SocketPort =(int) nudPortNumber.Value;
                HostEntry.ReceiveTimeOutMS = (int)nudReceiveTimeout.Value;
                HostEntry.SendTimeOutMS = (int)nudSendTimeout.Value;
                HostEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
                HostEntry.TelnetUserName = txtUserName.Text;
                HostEntry.TelnetPassword = txtPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private PingCollectorResult RunPingTest()
        {
            PingCollectorResult result;

            PingCollectorHostEntry tmpPingCollectorHostEntry = new PingCollectorHostEntry();
            if (cboPingType.SelectedIndex == 1)
            {
                tmpPingCollectorHostEntry.PingType = PingCollectorType.HTTP;
                if (!txtAddress.Text.ToUpper().StartsWith("HTTP"))
                    txtAddress.Text = "http://" + txtAddress.Text;
            }
            else if (cboPingType.SelectedIndex == 2)
                tmpPingCollectorHostEntry.PingType = PingCollectorType.Socket;
            else
                tmpPingCollectorHostEntry.PingType = PingCollectorType.Ping;

            tmpPingCollectorHostEntry.Address = txtAddress.Text;
            tmpPingCollectorHostEntry.DescriptionLocal = txtDescription.Text;
            tmpPingCollectorHostEntry.MaxTimeMS = Convert.ToInt32(nudExpextedTime.Value);
            tmpPingCollectorHostEntry.TimeOutMS = Convert.ToInt32(nudTimeOut.Value);
            tmpPingCollectorHostEntry.HttpProxyServer = txtHttpProxy.Text;
            tmpPingCollectorHostEntry.IgnoreInvalidHTTPSCerts = chkIgnoreInvalidHTTPSCerts.Checked;
            tmpPingCollectorHostEntry.SocketPort = (int)nudPortNumber.Value;
            tmpPingCollectorHostEntry.ReceiveTimeOutMS = (int)nudReceiveTimeout.Value;
            tmpPingCollectorHostEntry.SendTimeOutMS = (int)nudSendTimeout.Value;
            tmpPingCollectorHostEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
            tmpPingCollectorHostEntry.TelnetUserName = txtUserName.Text;
            tmpPingCollectorHostEntry.TelnetPassword = txtPassword.Text;

            result = tmpPingCollectorHostEntry.Ping();
            return result;
        }

        private PingCollectorResult RunPingTestWithPrompt()
        {
            PingCollectorResult result = new PingCollectorResult();
            try
            {
                result = RunPingTest();
                if (!result.Success )
                {
                    throw new Exception(result.ResponseDetails);
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Format("Test failed!\r\nResult: {0}\r\nAccept anyway?", ex.Message), "Ping test", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    result.Success = true;
                }
            }
            return result;
        }

        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            try
            {
                PingCollectorResult result = RunPingTest();
                if (result.Success)
                    MessageBox.Show(string.Format("Test was successful\r\nPing time: {0}ms", result.PingTime), "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Test failed!\r\nResult: " + result.ResponseDetails, "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test failed!\r\nResult: " + ex.Message, "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            httpGroupBox.Enabled = cboPingType.SelectedIndex == 1;
            socketPingGroupBox.Enabled = cboPingType.SelectedIndex == 2;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtAddress.Text.Length > 0 && (!chkUseTelNetLogin.Checked || txtUserName.Text.Length > 0);
            cmdTestAddress.Enabled = txtAddress.Text.Length > 0 && (!chkUseTelNetLogin.Checked || txtUserName.Text.Length > 0);
        }

        private void chkUseTelNetLogin_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
            txtUserName.Enabled = chkUseTelNetLogin.Checked;
            txtPassword.Enabled = chkUseTelNetLogin.Checked;
        }

        private void PingCollectorEditHostAddress_Load(object sender, EventArgs e)
        {

        }


    }
}
