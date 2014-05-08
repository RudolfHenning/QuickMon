using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        public MailSettings MailSettings { get; set; }

        private void chkUseDefultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCredentials.Enabled = !chkUseDefultCredentials.Checked;
        }

        public DialogResult ShowConfig()
        {
            txtSMTPServer.Text = MailSettings.HostServer;
            chkUseDefultCredentials.Checked = MailSettings.UseDefaultCredentials;
            txtDomain.Text = MailSettings.Domain;
            txtUserName.Text = MailSettings.UserName;
            txtPassword.Text = MailSettings.Password;
            txtFromAddress.Text = MailSettings.FromAddress;
            txtToAddress.Text = MailSettings.ToAddress;
            txtSender.Text = MailSettings.SenderAddress;
            txtReplyToAddress.Text = MailSettings.ReplyToAddress;
            if (MailSettings.MailPriority == 0)
                optPriorityLow.Checked = true;
            else if (MailSettings.MailPriority == 2)
                optPriorityHigh.Checked = true;
            else
                optPriorityNormal.Checked = true;
            txtSubject.Text = MailSettings.Subject;
            chkIsBodyHtml.Checked = MailSettings.IsBodyHtml;
            txtBody.Text = MailSettings.Body;
            chkTLS.Checked = MailSettings.UseTLS;
            portNumericUpDown.Value = MailSettings.Port;
            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSMTPServer.Text.Length == 0)
                {
                    throw new Exception("SMTP host server not specified!");
                }
                if (txtFromAddress.Text.Contains(',') || txtFromAddress.Text.Contains(';'))
                {
                    throw new Exception("From address may only contain a single address!");
                }
                if (txtSender.Text.Contains(',') || txtSender.Text.Contains(';'))
                {
                    throw new Exception("Sender address may only contain a single address!");
                }
                MailSettings.HostServer = txtSMTPServer.Text;
                MailSettings.UseDefaultCredentials = chkUseDefultCredentials.Checked;
                MailSettings.Domain = txtDomain.Text;
                MailSettings.UserName = txtUserName.Text;
                MailSettings.Password = txtPassword.Text;
                MailSettings.FromAddress = txtFromAddress.Text;
                MailSettings.ToAddress = txtToAddress.Text;
                MailSettings.SenderAddress = txtSender.Text;
                MailSettings.ReplyToAddress = txtReplyToAddress.Text;
                if (optPriorityLow.Checked)
                    MailSettings.MailPriority = 0;
                else if (optPriorityHigh.Checked)
                    MailSettings.MailPriority = 2;
                else
                    MailSettings.MailPriority = 1;
                MailSettings.Subject = txtSubject.Text;
                MailSettings.IsBodyHtml = chkIsBodyHtml.Checked;
                MailSettings.Body = txtBody.Text;
                MailSettings.UseTLS = chkTLS.Checked;
                MailSettings.Port = (int)portNumericUpDown.Value;

                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string lastStep = "";
            try
            {
                if (txtSMTPServer.Text.Length == 0)
                {
                    throw new Exception("SMTP host server not specified!");
                }
                if (txtFromAddress.Text.Contains(',') || txtFromAddress.Text.Contains(';'))
                {
                    throw new Exception("From address may only contain a single address!");
                }
                if (txtSender.Text.Contains(',') || txtSender.Text.Contains(';'))
                {
                    throw new Exception("Sender address may only contain a single address!");
                }
                lastStep = "Setting up SMTP client details";
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Host = txtSMTPServer.Text;
                    smtpClient.UseDefaultCredentials = chkUseDefultCredentials.Checked;
                    smtpClient.Port = (int)portNumericUpDown.Value; //465;// 587;

                    if (!chkUseDefultCredentials.Checked)
                    {
                        lastStep = "Setting up non default credentials";
                        System.Net.NetworkCredential cr = new System.Net.NetworkCredential();
                        cr.Domain = txtDomain.Text;
                        cr.UserName = txtUserName.Text;
                        cr.Password = txtPassword.Text;
                        smtpClient.Credentials = cr;
                    }

                    if (chkTLS.Checked)
                    {                        
                        smtpClient.EnableSsl = true;
                    }
                    MailMessage mailMessage = new MailMessage(txtFromAddress.Text, txtToAddress.Text);
                    if (optPriorityLow.Checked)
                        mailMessage.Priority = MailPriority.Low;
                    else if (optPriorityHigh.Checked)
                        mailMessage.Priority = MailPriority.High;
                    else
                        mailMessage.Priority = MailPriority.Normal;
                    if (txtSender.Text.Length > 0)
                        mailMessage.Sender = new MailAddress(txtSender.Text);
                    if (txtReplyToAddress.Text.Length > 0)
                    {
                        mailMessage.ReplyToList.Add(txtReplyToAddress.Text);
                    }
                    lastStep = "Setting up mail body";
                    if (chkIsBodyHtml.Checked)
                        mailMessage.Body = "<b>Test</b><br />Test was successful";
                    else
                        mailMessage.Body = "Test was successful";
                    mailMessage.IsBodyHtml = chkIsBodyHtml.Checked;
                    mailMessage.Subject = txtSubject.Text;
                    lastStep = "Sending SMTP mail";
                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Test completed successfully", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    MessageBox.Show(string.Format("Test failed\r\nLast step: {0}\r\n{1}", lastStep, ex.InnerException.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(string.Format("Test failed\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
