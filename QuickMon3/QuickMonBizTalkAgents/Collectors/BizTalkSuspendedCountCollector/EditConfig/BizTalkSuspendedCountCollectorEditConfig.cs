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
    public partial class BizTalkSuspendedCountCollectorEditConfig : Form, IEditConfigWindow, IEditConfigEntryWindow
    {
        public BizTalkSuspendedCountCollectorEditConfig()
        {
            InitializeComponent();
        }

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }
        public void SetTitle(string title)
        {
            this.Text = title;
        }
        #endregion

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get;set;}
        public DialogResult ShowEditEntry()
        {            
            return ShowDialog();
        }
        #endregion

        #region Form events
        private void BizTalkSuspendedCountCollectorEditConfig_Load(object sender, EventArgs e)
        {
            BizTalkSuspendedCountCollectorConfigEntry currentConfig;
            if (SelectedEntry != null)
            {
                currentConfig = (BizTalkSuspendedCountCollectorConfigEntry)SelectedEntry;
            }
            else
            {
                currentConfig = (BizTalkSuspendedCountCollectorConfigEntry)((ICollectorConfig)SelectedConfig).Entries[0];
            }
            txtSQLServer.Text = currentConfig.SqlServer;
            txtDatabase.Text = currentConfig.MgmtDBName;
            nudMsgsWarning.Value = currentConfig.InstancesWarning;
            nudMsgsError.Value = currentConfig.InstancesError;
            chkAllHostsApps.Checked = currentConfig.AllAppsHosts;
            nudShowTopXEntries.Value = currentConfig.ShowLastXDetails;

            foreach (string hostName in currentConfig.Hosts)
            {
                if (hostName.Length > 0)
                    lstHosts.Items.Add(hostName);
            }
            foreach (string appName in currentConfig.Apps)
            {
                if (appName.Length > 0)
                    lstApps.Items.Add(appName);
            }
        }
        #endregion

        #region Button events
        private void chkAllHostsApps_CheckedChanged(object sender, EventArgs e)
        {
            lstHosts.Enabled = !chkAllHostsApps.Checked;
            lstApps.Enabled = !chkAllHostsApps.Checked;
            cmdRemoveHost.Enabled = !chkAllHostsApps.Checked;
            cmdRemoveApp.Enabled = !chkAllHostsApps.Checked;
            CheckOKEnabled();
        }
        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            BizTalkAddAppOrHost addHost = new BizTalkAddAppOrHost();
            foreach(string newHost in  addHost.GetHostNames(txtSQLServer.Text, txtDatabase.Text))
            {
                if (!lstHosts.Items.Contains(newHost))
                    lstHosts.Items.Add(newHost);
            }
        }
        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            if (lstHosts.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove these host(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (int i in (from int x in lstHosts.SelectedIndices
                                       orderby x descending
                                       select x))
                    {
                        lstHosts.Items.RemoveAt(i);
                    }
                }
            }
        }
        private void cmdAddApp_Click(object sender, EventArgs e)
        {
            BizTalkAddAppOrHost addApp = new BizTalkAddAppOrHost();
            foreach (string newApp in addApp.GetApplicationNames(txtSQLServer.Text, txtDatabase.Text))
            {
                if (!lstApps.Items.Contains(newApp))
                    lstApps.Items.Add(newApp);
            }
        }
        private void cmdRemoveApp_Click(object sender, EventArgs e)
        {
            if (lstApps.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove these application(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (int i in (from int x in lstApps.SelectedIndices
                                       orderby x descending
                                       select x))
                    {
                        lstApps.Items.RemoveAt(i);
                    }
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            BizTalkSuspendedCountCollectorConfigEntry currentConfig;
            if (SelectedEntry != null)
                currentConfig = (BizTalkSuspendedCountCollectorConfigEntry)SelectedEntry;
            else if (SelectedConfig != null)
                currentConfig = (BizTalkSuspendedCountCollectorConfigEntry)((ICollectorConfig)SelectedConfig).Entries[0];
            else
                currentConfig = new BizTalkSuspendedCountCollectorConfigEntry();

            currentConfig.SqlServer = txtSQLServer.Text;
            currentConfig.MgmtDBName = txtDatabase.Text;
            currentConfig.InstancesWarning = (int)nudMsgsWarning.Value;
            currentConfig.InstancesError = (int)nudMsgsError.Value;
            currentConfig.AllAppsHosts = chkAllHostsApps.Checked;
            currentConfig.ShowLastXDetails = (int)nudShowTopXEntries.Value;
            currentConfig.Apps = new List<string>();
            foreach (string appName in lstApps.Items)
            {
                currentConfig.Apps.Add(appName);
            }
            currentConfig.Hosts = new List<string>();
            foreach (string hostName in lstHosts.Items)
            {
                currentConfig.Hosts.Add(hostName);
            }
            SelectedEntry = currentConfig;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            BizTalkGroupBase bizTalkGroup = new BizTalkGroupBase();
            bizTalkGroup.SqlServer = txtSQLServer.Text;
            bizTalkGroup.MgmtDBName = txtDatabase.Text;
            if (!bizTalkGroup.TestConnection())
            {
                MessageBox.Show(bizTalkGroup.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Success", "Connection test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion       

        #region Change checking
        private void txtSQLServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        } 
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtSQLServer.Text.Length > 0 && txtDatabase.Text.Length > 0;
            cmdTestDB.Enabled = txtSQLServer.Text.Length > 0 && txtDatabase.Text.Length > 0;
            cmdAddApp.Enabled = !chkAllHostsApps.Checked && txtSQLServer.Text.Length > 0 && txtDatabase.Text.Length > 0;
            cmdAddHost.Enabled = !chkAllHostsApps.Checked && txtSQLServer.Text.Length > 0 && txtDatabase.Text.Length > 0;
        }
        #endregion
    }
}
