using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace HenIT.Services
{
    public partial class InstallerForm : Form
    {
        public InstallerForm()
        {
            InitializeComponent();
        }

        public ServiceStartMode StartType { get; set; }
        public ServiceAccount AccountType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool DelayedStart { get; set; }

        private void InstallerForm_Load(object sender, EventArgs e)
        {
            switch (StartType)
            {
                case ServiceStartMode.Automatic:
                    cboStartup.SelectedIndex = 0;
                    break;
                case ServiceStartMode.Manual:
                    cboStartup.SelectedIndex = 1;
                    break;
                case ServiceStartMode.Disabled:
                    cboStartup.SelectedIndex = 2;
                    break;
                default:
                    cboStartup.SelectedIndex = 0;
                    break;
            }
            switch (AccountType)
            {
                case ServiceAccount.LocalService:
                    cboUserAccountType.SelectedIndex = 0;
                    break;
                case ServiceAccount.NetworkService:
                    cboUserAccountType.SelectedIndex = 1;
                    break;
                case ServiceAccount.LocalSystem:
                    cboUserAccountType.SelectedIndex = 2;
                    break;
                case ServiceAccount.User:
                    cboUserAccountType.SelectedIndex = 3;
                    break;
                default:
                    cboUserAccountType.SelectedIndex = 3;
                    break;
            }
        }

        private void cboUserAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = cboUserAccountType.SelectedIndex == 3;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cboUserAccountType.SelectedIndex == 3 && txtUserAccount.Text.Length == 0)
            {
                MessageBox.Show("You must specify an user account!", "User account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (cboUserAccountType.SelectedIndex == 3 && txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("The passwords do no match!", "Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (cboUserAccountType.SelectedIndex == 3)
                {
                    UserName = txtUserAccount.Text;
                    Password = txtPassword.Text;
                }
                DelayedStart = chkDelayedStart.Checked;
                StartType = cboStartup.SelectedIndex == 0 ? ServiceStartMode.Automatic :
                    cboStartup.SelectedIndex == 1 ? ServiceStartMode.Manual : ServiceStartMode.Disabled;

                switch (cboUserAccountType.SelectedIndex)
                {
                    case 0:
                        AccountType = ServiceAccount.LocalService;
                        break;
                    case 1:
                        AccountType = ServiceAccount.NetworkService;
                        break;
                    case 2:
                        AccountType = ServiceAccount.LocalSystem;
                        break;
                    case 3:
                        AccountType = ServiceAccount.User;
                        break;
                    default:
                        AccountType = ServiceAccount.LocalSystem;
                        break;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                if (cboUserAccountType.SelectedIndex == 3 && (txtPassword.Text != txtPassword2.Text))
                    cmdOK_Click(sender, e);

            base.OnKeyPress(e);
        }
    }
}
