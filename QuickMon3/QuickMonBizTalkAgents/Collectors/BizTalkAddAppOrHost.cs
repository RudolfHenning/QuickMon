using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.BizTalk;

namespace QuickMon.Collectors
{
    public partial class BizTalkAddAppOrHost : Form
    {
        public BizTalkAddAppOrHost()
        {
            InitializeComponent();
        }

        public List<string> GetApplicationNames(string sqlServer, string database)
        {
            try
            {
                this.Text = "Add Application(s)";
                lblListType.Text = "Applications";
                BizTalkGroupBase bizTalkGroup = new BizTalkGroupBase();
                bizTalkGroup.SqlServer = sqlServer;
                bizTalkGroup.MgmtDBName = database;
                foreach (string appName in bizTalkGroup.GetApplicationList())
                {
                    lvwItems.Items.Add(new ListViewItem(appName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ShowDialog() == DialogResult.OK)
            {
                List<string> list = new List<string>();
                foreach (ListViewItem lvi in lvwItems.SelectedItems)
                {
                    list.Add(lvi.Text);
                }
                return list;
            }
            else
                return new List<string>();
        }
        public List<string> GetHostNames(string sqlServer, string database)
        {
            try
            {
                this.Text = "Add Host(s)";
                lblListType.Text = "Hosts";
                BizTalkGroupBase bizTalkGroup = new BizTalkGroupBase();
                bizTalkGroup.SqlServer = sqlServer;
                bizTalkGroup.MgmtDBName = database;
                foreach (string host in bizTalkGroup.GetHostList())
                {
                    lvwItems.Items.Add(new ListViewItem(host));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ShowDialog() == DialogResult.OK)
            {
                List<string> list = new List<string>();
                foreach (ListViewItem lvi in lvwItems.SelectedItems)
                {
                    list.Add(lvi.Text);
                }
                return list;
            }
            else
                return new List<string>();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwItems.SelectedItems.Count > 0;
        }
    }
}
