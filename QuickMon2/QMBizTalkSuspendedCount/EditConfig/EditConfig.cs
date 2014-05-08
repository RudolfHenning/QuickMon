using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public string CustomConfig { get; set; }

        public EditConfig()
        {
            InitializeComponent();
        }

        public DialogResult ShowConfig()
        {
            if (CustomConfig.Length > 0)
            {
                try
                {
                    XmlDocument config = new XmlDocument();
                    config.LoadXml(CustomConfig);
                    XmlNode btsSuspendedInstances = config.SelectSingleNode("config/bizTalkGroup");
                    txtSQLServer.Text = btsSuspendedInstances.Attributes.GetNamedItem("sqlServer").Value;
                    txtDatabase.Text = btsSuspendedInstances.Attributes.GetNamedItem("mgmtDb").Value;
                    nudMsgsWarning.Value = int.Parse(btsSuspendedInstances.ReadXmlElementAttr("instancesWarning", "1"));
                    nudMsgsError.Value = int.Parse(btsSuspendedInstances.ReadXmlElementAttr("instancesError", "10"));
                    if (btsSuspendedInstances.ReadXmlElementAttr("allHostsApps", "True") != "True")
                        chkAllHostsApps.Checked = false;
                    nudShowTopXEntries.Value = int.Parse(btsSuspendedInstances.ReadXmlElementAttr("showLastXDetails", "10"));

                    foreach (XmlElement host in btsSuspendedInstances.SelectNodes("hosts/host"))
                    {
                        string hostName = host.ReadXmlElementAttr("name");
                        if (hostName.Length > 0)
                            lstHosts.Items.Add(hostName);
                    }
                    foreach (XmlElement app in btsSuspendedInstances.SelectNodes("apps/app"))
                    {
                        string appName = app.ReadXmlElementAttr("name");
                        if (appName.Length > 0)
                            lstApps.Items.Add(appName);
                    }
                    //chkRaiseHtmlAlerts.Checked = bool.Parse(btsSuspendedInstances.ReadXmlElementAttr("raiseHtmlAlerts", "True"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return ShowDialog();
        }


        private void chkAllHostsApps_CheckedChanged(object sender, EventArgs e)
        {
            lstHosts.Enabled = !chkAllHostsApps.Checked;
            lstApps.Enabled = !chkAllHostsApps.Checked;
            cmdAddHost.Enabled = !chkAllHostsApps.Checked;
            cmdRemoveHost.Enabled = !chkAllHostsApps.Checked;
            cmdAddApp.Enabled = !chkAllHostsApps.Checked;
            cmdRemoveApp.Enabled = !chkAllHostsApps.Checked;
        }

        private void cmdRemoveHost_Click(object sender, EventArgs e)
        {
            if (lstHosts.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove this host?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lstHosts.Items.Remove(lstHosts.SelectedItem);
                }
            }
        }

        private void cmdRemoveApp_Click(object sender, EventArgs e)
        {
            if (lstApps.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure you want to remove this application?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lstApps.Items.Remove(lstApps.SelectedItem);
                }
            }
        }

        private void cmdAddHost_Click(object sender, EventArgs e)
        {
            AddHost addHost = new AddHost();
            string newHost = addHost.GetHostName(txtSQLServer.Text, txtDatabase.Text);
            if (newHost.Length > 0)
            {
                lstHosts.Items.Add(newHost);
            }
        }

        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            BizTalkGroup bizTalkGroup = new BizTalkGroup();
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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.BizTalkSuspendedCountEmptyConfig_xml);
            XmlNode btsSuspendedInstances = config.SelectSingleNode("config/bizTalkGroup");
            btsSuspendedInstances.Attributes.GetNamedItem("sqlServer").Value = txtSQLServer.Text;
            btsSuspendedInstances.Attributes.GetNamedItem("mgmtDb").Value = txtDatabase.Text;
            btsSuspendedInstances.Attributes.GetNamedItem("instancesWarning").Value = nudMsgsWarning.Value.ToString("0");
            btsSuspendedInstances.Attributes.GetNamedItem("instancesError").Value = nudMsgsError.Value.ToString("0");
            btsSuspendedInstances.Attributes.GetNamedItem("allHostsApps").Value = chkAllHostsApps.Checked ? "True" : "False";
            btsSuspendedInstances.Attributes.GetNamedItem("showLastXDetails").Value = nudShowTopXEntries.Value.ToString();
            btsSuspendedInstances.Attributes.GetNamedItem("raiseHtmlAlerts").Value = chkRaiseHtmlAlerts.Checked.ToString();            

            XmlNode hostsNode = config.SelectSingleNode("config/bizTalkGroup/hosts");
            for (int i = 0; i < lstHosts.Items.Count; i++)
            {
                XmlElement host = config.CreateElement("host");
                XmlAttribute hostName = config.CreateAttribute("name");
                hostName.Value = lstHosts.Items[i].ToString();
                host.Attributes.Append(hostName);
                hostsNode.AppendChild(host);
            }

            XmlNode appsNode = config.SelectSingleNode("config/bizTalkGroup/apps");
            for (int i = 0; i < lstApps.Items.Count; i++)
            {
                XmlElement app = config.CreateElement("app");
                XmlAttribute appName = config.CreateAttribute("name");
                appName.Value = lstApps.Items[i].ToString();
                app.Attributes.Append(appName);
                appsNode.AppendChild(app);
            }

            CustomConfig = config.OuterXml;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmdAddApp_Click(object sender, EventArgs e)
        {
            AddApp addApp = new AddApp();
            string newApp = addApp.GetApplicationName(txtSQLServer.Text, txtDatabase.Text);
            if (newApp.Length > 0)
            {
                lstApps.Items.Add(newApp);
            }
        }

        private void EditConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
