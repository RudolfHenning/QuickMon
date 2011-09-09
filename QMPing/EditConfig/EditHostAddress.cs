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

        private bool TestAddress()
        {
            bool success = false;
            try
            {
                System.Net.Dns.GetHostAddresses(txtAddress.Text);
                success = true;
            }
            catch (Exception ex) 
            {
                if (MessageBox.Show("Address not valid!\r\nAccept anyway?\r\n" + ex.ToString(), "Address not valid", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    success = true;
                }
            }

            return success;
        }

        private void cmdTestAddress_Click(object sender, EventArgs e)
        {
            if (TestAddress())
            {
                MessageBox.Show("Test success!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
