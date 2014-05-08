using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace QuickMon
{
    public partial class EditHostAddress : Form
    {
        public EditHostAddress()
        {
            InitializeComponent();
        }

        public HostEntry HostEntry { get; set; }

        public DialogResult ShowHostAddress()
        {
            txtAddress.Text = HostEntry.HostName;
            txtDescription.Text = HostEntry.Description;
            nudExpextedTime.Value = HostEntry.MaxTime;
            nudTimeOut.Value = HostEntry.TimeOut;
            return ShowDialog();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length == 0)
            {
                txtAddress.Focus();
            }
            else if (TestAddress())
            {
                HostEntry.HostName = txtAddress.Text;
                HostEntry.Description = txtDescription.Text;
                HostEntry.MaxTime = Convert.ToInt32(nudExpextedTime.Value);
                HostEntry.TimeOut = Convert.ToInt32(nudTimeOut.Value);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private int GetPingTime(string hostName)
        {
            int pingTime = 0;

            System.Net.Dns.GetHostAddresses(txtAddress.Text);

            using (System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping())
            {
                System.Net.NetworkInformation.PingReply reply = ping.Send(txtAddress.Text, 5000);
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    pingTime = Convert.ToInt32(reply.RoundtripTime);
                else // if (reply.Status == System.Net.NetworkInformation.IPStatus.TimedOut)
                    pingTime = int.MaxValue;
            }
            return pingTime;
        }

        private bool TestAddress(bool prompt = false)
        {
            bool success = false;
            try
            {
                GetPingTime(txtAddress.Text);
                success = true;
            }
            catch (Exception ex) 
            {
                if (MessageBox.Show("Test failed!\r\nAccept anyway?\r\n" + ex.Message, "Ping test", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    success = true;
                }
            }
            return success;
        }

        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            try
            {
                int pingTime = GetPingTime(txtAddress.Text);
                MessageBox.Show(string.Format("Test was successful\r\nPing time: {0}ms", pingTime), "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test failed!\r\n" + ex.Message, "Ping test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
