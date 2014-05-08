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
    public partial class AddApp : Form
    {
        public AddApp()
        {
            InitializeComponent();
        }

        public string GetApplicationName(string sqlServer, string database)
        {
            try
            {
                BizTalkGroup bizTalkGroup = new BizTalkGroup();
                bizTalkGroup.SqlServer = sqlServer;
                bizTalkGroup.MgmtDBName = database;
                foreach (string host in bizTalkGroup.GetApplicationList())
                {
                    lstApps.Items.Add(host);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ShowDialog() == DialogResult.OK)
            {
                return txtApp.Text;
            }
            else
                return "";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtApp.Text.Length > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lstApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtApp.Text = lstApps.SelectedItem.ToString();
        }
    }
}
