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
    public partial class AddHost : Form
    {
        public AddHost()
        {
            InitializeComponent();
        }

        public string GetHostName(string sqlServer, string database)
        {
            try
            {
                BizTalkGroup bizTalkGroup = new BizTalkGroup();
                bizTalkGroup.SqlServer = sqlServer;
                bizTalkGroup.MgmtDBName = database;
                foreach (string host in bizTalkGroup.GetHostList())
                {
                    lstHosts.Items.Add(host);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ShowDialog() == DialogResult.OK)
            {
                return txtHost.Text;
            }
            else
                return "";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtHost.Text.Length > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void AddHost_Load(object sender, EventArgs e)
        {

        }

        private void lstHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHost.Text = lstHosts.SelectedItem.ToString();
        }
    }
}
