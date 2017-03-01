using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Security
{
    public partial class LogonDialog : Form
    {
        public LogonDialog()
        {
            InitializeComponent();
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtPassword1_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void txtPassword2_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private bool CheckOKEnabled()
        {
            cmdOK.Enabled = (txtUserName.Text.Length > 0 && txtPassword1.Text.Length > 0 && txtPassword1.Text == txtPassword2.Text);
            return cmdOK.Enabled;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckOKEnabled())
            {
                UserName = txtUserName.Text;
                Password = txtPassword1.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void LogonDialog_Load(object sender, EventArgs e)
        {
            txtUserName.Text = UserName;
            if (txtUserName.Text.Length > 0)
                txtUserName.Enabled = false;
        }
    }
}
