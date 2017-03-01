using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class CollectorHostEditor : Form
    {
        public CollectorHostEditor()
        {
            InitializeComponent();
        }

        public CollectorHost SelectedCollectorHost { get; set; }

        private int panelGeneralSettingsHeight = 0;
        private int panelAgentsHeight = 0;
        private int panelPollingHeight = 0;
        private int panelRemoteAgentHeight = 0;
        private int panelRunAsHeight = 0;
        private int panelServiceWindowsHeight = 0;
        private int panelAlertingHeight = 0;
        private int panelVariablesHeight = 0;
        private int panelActionScriptsHeight = 0;

        private void flowLayoutPanelSettings_Resize(object sender, EventArgs e)
        {
            int clientSize = flowLayoutPanelSettings.ClientSize.Width - flowLayoutPanelSettings.Margin.Left - flowLayoutPanelSettings.Margin.Right - 1;
            foreach (Control c in flowLayoutPanelSettings.Controls)
            {
                if (c is Panel)
                {
                    c.Width = clientSize;
                }
            }
        }

        #region PanelToggles
        private void TogglePanel(Button toggleButton, Panel togglePanel, Panel contentPanel, int expandedheight)
        {
            if (toggleButton.Height == togglePanel.Height)
            {
                togglePanel.Height = expandedheight;
                contentPanel.Visible = true;
                toggleButton.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
            }
            else
            {
                togglePanel.Height = toggleButton.Height;
                contentPanel.Visible = false;
                toggleButton.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
        }
        private void cmdGeneralSettingsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdGeneralSettingsToggle, panelGeneralSettings, panelGeneralSettingsContent, panelGeneralSettingsHeight);
        }
        private void cmdAgentsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdAgentsToggle, panelAgents, panelAgentsContent, panelAgentsHeight);
        }
        private void cmdPollingToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdPollingToggle, panelPolling, panelPollingContent, panelPollingHeight);
        }
        private void cmdRemoteAgentToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdRemoteAgentToggle, panelRemoteAgent, panelRemoteAgentContent, panelRemoteAgentHeight);
        }
        private void cmdRunAsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdRunAsToggle, panelRunAs, panelRunAsContent, panelRunAsHeight);
        }
        private void cmdServiceWindowsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdServiceWindowsToggle, panelServiceWindows, panelServiceWindowsContent, panelServiceWindowsHeight);
        }
        private void cmdAlertingToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdAlertingToggle, panelAlerting, panelAlertingContent, panelAlertingHeight);
        }
        private void cmdVariablesToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdVariablesToggle, panelVariables, panelVariablesContent, panelVariablesHeight);
        }
        private void cmdActionScriptsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdActionScriptsToggle, panelActionScripts, panelActionScriptsContent, panelActionScriptsHeight);
        }
        #endregion

        private void CollectorHostEditor_Load(object sender, EventArgs e)
        {
            panelGeneralSettingsHeight = panelGeneralSettings.Height;
            panelAgentsHeight = panelAgents.Height;
            panelPollingHeight = panelPolling.Height;
            panelRemoteAgentHeight = panelRemoteAgent.Height;
            panelRunAsHeight = panelRunAs.Height;
            panelServiceWindowsHeight = panelServiceWindows.Height;
            panelAlertingHeight = panelAlerting.Height;
            panelVariablesHeight = panelVariables.Height;
            panelActionScriptsHeight = panelActionScripts.Height;

            cmdAgentsToggle_Click(null, null);
            cmdPollingToggle_Click(null, null);
            cmdRemoteAgentToggle_Click(null, null);
            cmdRunAsToggle_Click(null, null);
            cmdServiceWindowsToggle_Click(null, null);
            cmdAlertingToggle_Click(null, null);
            cmdVariablesToggle_Click(null, null);
            cmdActionScriptsToggle_Click(null, null);

            if (SelectedCollectorHost == null)
                SelectedCollectorHost = new CollectorHost();
        }

        private void CollectorHostEditor_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
