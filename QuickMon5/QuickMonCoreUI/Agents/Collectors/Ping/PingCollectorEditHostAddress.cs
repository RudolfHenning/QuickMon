using QuickMon.Collectors;
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
    public partial class PingCollectorEditHostAddress : CollectorConfigEntryEditWindowBase //Form, ICollectorConfigEntryEditWindow
    {
        public PingCollectorEditHostAddress()
        {
            InitializeComponent();
        }

        //#region IEditConfigEntryWindow Members
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    if (SelectedEntry == null)
        //        SelectedEntry = new PingCollectorHostEntry();
        //    HostEntry = (PingCollectorHostEntry)SelectedEntry;
        //    switch (HostEntry.PingType)
        //    {
        //        case PingCollectorType.HTTP:
        //            cboPingType.SelectedIndex = 1;
        //            break;
        //        case PingCollectorType.Socket:
        //            cboPingType.SelectedIndex = 2;
        //            break;
        //        default:
        //            cboPingType.SelectedIndex = 0;
        //            break;
        //    }
        //    txtAddress.Text = HostEntry.Address;
        //    txtDescription.Text = HostEntry.DescriptionLocal;
        //    nudExpextedTime.Value = HostEntry.MaxTimeMS;
        //    nudTimeOut.Value = HostEntry.TimeOutMS;
        //    txtHTTPHeaderUsername.Text = HostEntry.HttpHeaderUserName;
        //    txtHTTPHeaderPassword.Text = HostEntry.HttpHeaderPassword;
        //    txtHttpProxy.Text = HostEntry.HttpProxyServer;
        //    txtProxyUsername.Text = HostEntry.HttpProxyUserName;
        //    txtProxyPassword.Text = HostEntry.HttpProxyPassword;
        //    txtHTMLContent.Text = HostEntry.HTMLContentContain;
        //    nudPortNumber.Value = HostEntry.SocketPort;
        //    nudReceiveTimeout.Value = HostEntry.ReceiveTimeOutMS;
        //    nudSendTimeout.Value = HostEntry.SendTimeOutMS;
        //    chkUseTelNetLogin.Checked = HostEntry.UseTelnetLogin;
        //    txtUserName.Text = HostEntry.TelnetUserName;
        //    txtPassword.Text = HostEntry.TelnetPassword;
        //    return (QuickMonDialogResult)ShowDialog();
        //}
        //public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        //#endregion

        private PingCollectorHostEntry HostEntry { get; set; }

        //public DialogResult ShowHostAddress()
        //{
        //    switch (HostEntry.PingType)
        //    {
        //        case PingCollectorType.HTTP:
        //            cboPingType.SelectedIndex = 1;
        //            break;
        //        case PingCollectorType.Socket:
        //            cboPingType.SelectedIndex = 2;
        //            break;
        //        default:
        //            cboPingType.SelectedIndex = 0;
        //            break;
        //    }
        //    txtAddress.Text = HostEntry.Address;
        //    txtDescription.Text = HostEntry.DescriptionLocal;
        //    nudExpextedTime.Value = HostEntry.MaxTimeMS;
        //    nudTimeOut.Value = HostEntry.TimeOutMS;
        //    txtHTTPHeaderUsername.Text = HostEntry.HttpHeaderUserName;
        //    txtHTTPHeaderPassword.Text = HostEntry.HttpHeaderPassword;
        //    txtHttpProxy.Text = HostEntry.HttpProxyServer;
        //    txtProxyUsername.Text = HostEntry.HttpProxyUserName;
        //    txtProxyPassword.Text = HostEntry.HttpProxyPassword;
        //    txtHTMLContent.Text = HostEntry.HTMLContentContain;
        //    chkIgnoreInvalidHTTPSCerts.Checked = HostEntry.IgnoreInvalidHTTPSCerts;
        //    nudPortNumber.Value = HostEntry.SocketPort;
        //    nudReceiveTimeout.Value = HostEntry.ReceiveTimeOutMS;
        //    nudSendTimeout.Value = HostEntry.SendTimeOutMS;
        //    chkUseTelNetLogin.Checked = HostEntry.UseTelnetLogin;
        //    txtUserName.Text = HostEntry.TelnetUserName;
        //    txtPassword.Text = HostEntry.TelnetPassword;
        //    txtSocketPingMsgBody.Text = HostEntry.SocketPingMsgBody;
        //    CheckOkEnabled();
        //    return ShowDialog();
        //}
        private void PingCollectorEditHostAddress_Load(object sender, EventArgs e)
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
            txtHTTPHeaderUsername.Text = HostEntry.HttpHeaderUserName;
            txtHTTPHeaderPassword.Text = HostEntry.HttpHeaderPassword;
            txtHttpProxy.Text = HostEntry.HttpProxyServer;
            txtProxyUsername.Text = HostEntry.HttpProxyUserName;
            txtProxyPassword.Text = HostEntry.HttpProxyPassword;
            txtHTMLContent.Text = HostEntry.HTMLContentContain;
            nudPortNumber.Value = HostEntry.SocketPort;
            nudReceiveTimeout.Value = HostEntry.ReceiveTimeOutMS;
            nudSendTimeout.Value = HostEntry.SendTimeOutMS;
            chkUseTelNetLogin.Checked = HostEntry.UseTelnetLogin;
            txtUserName.Text = HostEntry.TelnetUserName;
            txtPassword.Text = HostEntry.TelnetPassword;
            cboHttpsProtocol.SelectedIndex = 0;
            chkIgnoreInvalidHTTPSCerts.Checked = HostEntry.IgnoreInvalidHTTPSCerts;
            chkAllowHTTP3xx.Checked = HostEntry.AllowHTTP3xx;
            if (HostEntry.HttpsSecurityProtocol != null)
            {
                if (HostEntry.HttpsSecurityProtocol == "Tls")
                    cboHttpsProtocol.SelectedIndex = 1;
                else if (HostEntry.HttpsSecurityProtocol == "Tls11")
                    cboHttpsProtocol.SelectedIndex = 2;
                else if (HostEntry.HttpsSecurityProtocol == "Tls12")
                    cboHttpsProtocol.SelectedIndex = 3;
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (chkVerifyOnOK.Checked && txtAddress.Text.Length == 0)
            {
                txtAddress.Focus();
            }
            else if (!chkVerifyOnOK.Checked || RunPingTestWithPrompt().State == CollectorState.Good)
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
                HostEntry.HttpHeaderUserName = txtHTTPHeaderUsername.Text;
                HostEntry.HttpHeaderPassword = txtHTTPHeaderPassword.Text;
                HostEntry.HttpProxyServer = txtHttpProxy.Text;
                HostEntry.HttpProxyUserName = txtProxyUsername.Text;
                HostEntry.HttpProxyPassword = txtProxyPassword.Text;
                HostEntry.HTMLContentContain = txtHTMLContent.Text;
                HostEntry.IgnoreInvalidHTTPSCerts = chkIgnoreInvalidHTTPSCerts.Checked;
                HostEntry.AllowHTTP3xx = chkAllowHTTP3xx.Checked;
                HostEntry.SocketPort = (int)nudPortNumber.Value;
                HostEntry.ReceiveTimeOutMS = (int)nudReceiveTimeout.Value;
                HostEntry.SendTimeOutMS = (int)nudSendTimeout.Value;
                HostEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
                HostEntry.TelnetUserName = txtUserName.Text;
                HostEntry.TelnetPassword = txtPassword.Text;
                HostEntry.SocketPingMsgBody = txtSocketPingMsgBody.Text;
                HostEntry.HttpsSecurityProtocol = cboHttpsProtocol.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private MonitorState RunPingTest()
        {
            MonitorState result;

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

            string address = ApplyConfigVarsOnField(txtAddress.Text);
            string description = ApplyConfigVarsOnField(txtDescription.Text);
            string httpHeaderUserName = ApplyConfigVarsOnField(txtHTTPHeaderUsername.Text);
            string httpHeaderPassword = ApplyConfigVarsOnField(txtHTTPHeaderPassword.Text);
            string httpProxyServer = ApplyConfigVarsOnField(txtHttpProxy.Text);
            string httpProxyUserName = ApplyConfigVarsOnField(txtProxyUsername.Text);
            string httpProxyPassword = ApplyConfigVarsOnField(txtProxyPassword.Text);
            string htmlContentContain = ApplyConfigVarsOnField(txtHTMLContent.Text);
            string telnetUserName = ApplyConfigVarsOnField(txtUserName.Text);
            string telnetPassword = ApplyConfigVarsOnField(txtPassword.Text);
            string socketPingMsgBody = ApplyConfigVarsOnField(txtSocketPingMsgBody.Text);

            tmpPingCollectorHostEntry.Address = address;
            tmpPingCollectorHostEntry.DescriptionLocal = description;
            tmpPingCollectorHostEntry.MaxTimeMS = Convert.ToInt32(nudExpextedTime.Value);
            tmpPingCollectorHostEntry.TimeOutMS = Convert.ToInt32(nudTimeOut.Value);
            tmpPingCollectorHostEntry.HttpHeaderUserName = httpHeaderUserName;
            tmpPingCollectorHostEntry.HttpHeaderPassword = httpHeaderPassword;
            tmpPingCollectorHostEntry.HttpProxyServer = httpProxyServer;
            tmpPingCollectorHostEntry.HttpProxyUserName = httpProxyUserName;
            tmpPingCollectorHostEntry.HttpProxyPassword = httpProxyPassword;
            tmpPingCollectorHostEntry.HTMLContentContain = htmlContentContain;
            tmpPingCollectorHostEntry.IgnoreInvalidHTTPSCerts = chkIgnoreInvalidHTTPSCerts.Checked;
            tmpPingCollectorHostEntry.SocketPort = (int)nudPortNumber.Value;
            tmpPingCollectorHostEntry.ReceiveTimeOutMS = (int)nudReceiveTimeout.Value;
            tmpPingCollectorHostEntry.SendTimeOutMS = (int)nudSendTimeout.Value;
            tmpPingCollectorHostEntry.UseTelnetLogin = chkUseTelNetLogin.Checked;
            tmpPingCollectorHostEntry.TelnetUserName = telnetUserName;
            tmpPingCollectorHostEntry.TelnetPassword = telnetPassword;
            tmpPingCollectorHostEntry.SocketPingMsgBody = socketPingMsgBody;
            tmpPingCollectorHostEntry.HttpsSecurityProtocol = cboHttpsProtocol.Text;
            tmpPingCollectorHostEntry.AllowHTTP3xx = chkAllowHTTP3xx.Checked;

            result = tmpPingCollectorHostEntry.GetCurrentState();            
            return result;
        }

        private MonitorState RunPingTestWithPrompt()
        {
            MonitorState result = new MonitorState();
            try
            {
                result = RunPingTest();
                if (result.State != CollectorState.Good)
                {
                    throw new Exception(result.ReadAllRawDetails());
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Format("Test failed!\r\nResult: {0}\r\nAccept anyway?", ex.Message), "Ping test", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    result.State = CollectorState.Good;
                }
            }
            return result;
        }

        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorState result = RunPingTest();
                if (result.State == CollectorState.Good)
                {
                    if (cboPingType.SelectedIndex == 1)
                    {
                        try
                        {
                            string tempFileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
                            System.IO.File.WriteAllText(tempFileName, result.ReadAllRawDetails());
                            System.Diagnostics.Process p = new System.Diagnostics.Process();
                            p.StartInfo = new System.Diagnostics.ProcessStartInfo("notepad.exe", tempFileName);
                            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                            p.Start();
                            System.Threading.Thread.Sleep(1000);
                            System.IO.File.Delete(tempFileName);
                        }
                        catch { }

                    }
                    MessageBox.Show(string.Format("Test was successful\r\n{0}", result.ReadAllRawDetails()), "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Test failed!\r\nResult: " + result.ReadAllRawDetails(), "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




    }
}
