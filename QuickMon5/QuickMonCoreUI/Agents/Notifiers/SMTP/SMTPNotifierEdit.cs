using QuickMon.Notifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SMTPNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public SMTPNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }

        public QuickMonDialogResult ShowEditEntry()
        {
            LoadEditData();
            return (QuickMonDialogResult)ShowDialog();
        }
        private void LoadEditData()
        {
            SMTPNotifierConfig mailSettings;
            if (SelectedEntry == null)
                SelectedEntry = new SMTPNotifierConfig();
            mailSettings = (SMTPNotifierConfig)SelectedEntry;

            txtSMTPServer.Text = mailSettings.HostServer;
            chkUseDefaultCredentials.Checked = mailSettings.UseDefaultCredentials;
            txtDomain.Text = mailSettings.Domain;
            txtUserName.Text = mailSettings.UserName;
            txtPassword.Text = mailSettings.Password;
            txtFromAddress.Text = mailSettings.FromAddress;
            txtToAddress.Text = mailSettings.ToAddress;
            txtSender.Text = mailSettings.SenderAddress;
            txtReplyToAddress.Text = mailSettings.ReplyToAddress;
            if (mailSettings.MailPriority == 1)
                optPriorityLow.Checked = true;
            else if (mailSettings.MailPriority == 2)
                optPriorityHigh.Checked = true;
            else
                optPriorityNormal.Checked = true;
            txtSubject.Text = mailSettings.Subject;
            chkIsBodyHtml.Checked = mailSettings.IsBodyHtml;
            txtBody.Text = mailSettings.Body;
            chkTLS.Checked = mailSettings.UseTLS;
            portNumericUpDown.Value = mailSettings.Port;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                SMTPNotifierConfig mailSettings;
                mailSettings = (SMTPNotifierConfig)SelectedEntry;


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
                mailSettings.HostServer = txtSMTPServer.Text;
                mailSettings.UseDefaultCredentials = chkUseDefaultCredentials.Checked;
                mailSettings.Domain = txtDomain.Text;
                mailSettings.UserName = txtUserName.Text;
                mailSettings.Password = txtPassword.Text;
                mailSettings.FromAddress = txtFromAddress.Text;
                mailSettings.ToAddress = txtToAddress.Text;
                mailSettings.SenderAddress = txtSender.Text;
                mailSettings.ReplyToAddress = txtReplyToAddress.Text;
                if (optPriorityLow.Checked)
                    mailSettings.MailPriority = 1;
                else if (optPriorityHigh.Checked)
                    mailSettings.MailPriority = 2;
                else
                    mailSettings.MailPriority = 0;
                mailSettings.Subject = txtSubject.Text;
                mailSettings.IsBodyHtml = chkIsBodyHtml.Checked;
                mailSettings.Body = txtBody.Text;
                mailSettings.UseTLS = chkTLS.Checked;
                mailSettings.Port = (int)portNumericUpDown.Value;

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
                    smtpClient.UseDefaultCredentials = chkUseDefaultCredentials.Checked;
                    smtpClient.Port = (int)portNumericUpDown.Value; //465;// 587;

                    if (!chkUseDefaultCredentials.Checked)
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
                if (ex.InnerException != null)
                    MessageBox.Show(string.Format("Test failed\r\nLast step: {0}\r\n{1}", lastStep, ex.InnerException.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(string.Format("Test failed\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSMTPServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void chkUseDefaultCredentials_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxCredentials.Enabled = !chkUseDefaultCredentials.Checked;
        }

        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtSMTPServer.Text.Length > 0 && txtFromAddress.Text.Length > 0 &&
                       txtSender.Text.Length > 0 && txtReplyToAddress.Text.Length > 0 &&
                       txtToAddress.Text.Length > 0 && txtSubject.Text.Length > 0 &&
                       txtBody.Text.Length > 0;
        }

        private void txtFromAddress_Leave(object sender, EventArgs e)
        {
            if (txtSender.Text.Length == 0) txtSender.Text = txtFromAddress.Text;
            if (txtReplyToAddress.Text.Length == 0) txtReplyToAddress.Text = txtFromAddress.Text;
        }

        private void txtFromAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtSender_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtToAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtReplyToAddress_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
    }
}
