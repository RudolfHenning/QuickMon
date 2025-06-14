﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SelectNewEntityType : Form
    {
        public SelectNewEntityType()
        {
            InitializeComponent();
            Templates = new List<QuickMonTemplate>();
        }

        private bool selectingMonitorPacks = false;
        private bool selectingCollectorAgents = false;
        private bool selectingCollectorHosts = false;
        private bool selectingNotifierHosts = false;
        private bool selectingNotifierAgents = false;

        #region Properties
        public IAgent SelectedAgent { get; set; }
        public MonitorPack SelectedMonitorPack { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        public NotifierHost SelectedNotifierHost { get; set; }
        public List<QuickMonTemplate> Templates { get; set; }
        public string InitialRegistrationName { get; set; }
        public bool ShowEditAfterCreation { get; set; } = false;
        public bool EditAfterCreation { get; set; } = false;
        public bool ShowRAWEditing { get; set; } = false;
        #endregion

        #region public methods
        public DialogResult ShowMonitorPackSelection()
        {
            this.Text = "Creating a new Monitor Pack";
            selectingMonitorPacks = true;
            LoadMonitorPackItems();
            return this.ShowDialog();
        }
        public DialogResult ShowCollectorHostSelection()
        {
            this.Text = "Creating a new Collector";
            selectingCollectorHosts = true;
            LoadCollectorHostItems();
            return this.ShowDialog();
        }
        public DialogResult ShowCollectorAgentSelection()
        {
            this.Text = "Select Collector Agent type";
            cmdSkip.Visible = false;
            selectingCollectorAgents = true;
            LoadCollectorAgents();           
            return ShowDialog();
        }
        public DialogResult ShowNotifierHostSelection()
        {
            this.Text = "Creating a new Notifier";
            selectingNotifierHosts = true;
            LoadNotifierHostItems();
            return this.ShowDialog();
        }
        public DialogResult ShowNotifierAgentSelection()
        {
            this.Text = "Creating a new Notifier Agent";
            cmdSkip.Visible = false;
            selectingNotifierAgents = true;
            LoadCollectorAgents();
            return this.ShowDialog();
        }
        #endregion

        #region Private methods
        private void LoadMonitorPackItems()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();
            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviEmptyMonitorPack = new ListViewItem("Empty monitor pack");
            lviEmptyMonitorPack.SubItems.Add("Creates a blank monitor pack with no collectors");
            lviEmptyMonitorPack.Group = generalGroup;
            lviEmptyMonitorPack.Tag = Properties.Resources.BlankTemplateMonitorPack;
            lvwAgentType.Items.Add(lviEmptyMonitorPack);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);
            foreach (QuickMonTemplate qt in QuickMonTemplate.GetAllTemplates().Where(t => t.TemplateType == TemplateType.MonitorPack))
            {
                ListViewItem lviTemplateCollector = new ListViewItem(qt.Name);
                lviTemplateCollector.SubItems.Add(qt.Description);
                lviTemplateCollector.Group = templatesGroup;
                lviTemplateCollector.Tag = qt;
                lvwAgentType.Items.Add(lviTemplateCollector);
            }
        }
        private void LoadCollectorHostItems()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviEmptyCollector = new ListViewItem("Folder/Blank collector");
            lviEmptyCollector.SubItems.Add("Creates a blank collector with no agents");
            lviEmptyCollector.Group = generalGroup;
            lviEmptyCollector.Tag = CollectorHost.FromXml("<collectorHost uniqueId=\"\" dependOnParentId=\"\" name=\"[[FolderName:]]\"><collectorAgents agentCheckSequence=\"All\"></collectorAgents></collectorHost>").Clone(true);
            lvwAgentType.Items.Add(lviEmptyCollector);

            ListViewItem lviPingCollector = new ListViewItem("Ping (ICMP)");
            lviPingCollector.SubItems.Add("Creates a collector with a Ping (ICMP) agent");
            lviPingCollector.Group = generalGroup;
            lviPingCollector.Tag = CollectorHost.FromXml(Properties.Resources.ICMPPingTemplate).Clone(true);
            lvwAgentType.Items.Add(lviPingCollector);

            lviPingCollector = new ListViewItem("Ping (http)");
            lviPingCollector.SubItems.Add("Creates a collector with a Ping (http) agent");
            lviPingCollector.Group = generalGroup;
            lviPingCollector.Tag = CollectorHost.FromXml(Properties.Resources.HTTPPingTemplate).Clone(true);
            lvwAgentType.Items.Add(lviPingCollector);

            ListViewItem lviCPUPercCollector = new ListViewItem("CPU %");
            lviCPUPercCollector.SubItems.Add("Creates a collector with a Performance counter agent for CPU %");
            lviCPUPercCollector.Group = generalGroup;
            lviCPUPercCollector.Tag = CollectorHost.FromXml(Properties.Resources.CPUPercentTemplate).Clone(true);
            lvwAgentType.Items.Add(lviCPUPercCollector);

            ListViewItem lviMemPercCollector = new ListViewItem("Memory usage %");
            lviMemPercCollector.SubItems.Add("Creates a collector with a Performance counter agent for Memory usage %");
            lviMemPercCollector.Group = generalGroup;
            lviMemPercCollector.Tag = CollectorHost.FromXml(Properties.Resources.MemoryPercTemplate).Clone(true);
            lvwAgentType.Items.Add(lviMemPercCollector);

            ListViewItem lviNetworkCollector = new ListViewItem("Network usage KB/s");
            lviNetworkCollector.SubItems.Add("Creates a collector with a Performance counter agent for Network usage KB/s");
            lviNetworkCollector.Group = generalGroup;
            lviNetworkCollector.Tag = CollectorHost.FromXml(Properties.Resources.NetworkUsageTemplate).Clone(true);
            lvwAgentType.Items.Add(lviNetworkCollector);

            ListViewItem lviDriveSpaceFreeCollector = new ListViewItem("Drive Space Free");
            lviDriveSpaceFreeCollector.SubItems.Add("Creates a collector with a Performance counter agent for Drive Space Free");
            lviDriveSpaceFreeCollector.Group = generalGroup;
            lviDriveSpaceFreeCollector.Tag = CollectorHost.FromXml(Properties.Resources.DriveSpaceFree).Clone(true);
            lvwAgentType.Items.Add(lviDriveSpaceFreeCollector);

            ListViewItem lviPingDefaultGatewayCollector = new ListViewItem("Ping default gateway");
            lviPingDefaultGatewayCollector.SubItems.Add("Creates a collector with a PowerShell script to ping default gateway");
            lviPingDefaultGatewayCollector.Group = generalGroup;
            lviPingDefaultGatewayCollector.Tag = CollectorHost.FromXml(Properties.Resources.PingDefaultGatewayTemplate).Clone(true);
            lvwAgentType.Items.Add(lviPingDefaultGatewayCollector);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

            foreach (QuickMonTemplate qt in QuickMonTemplate.GetAllTemplates().Where(t => t.TemplateType == TemplateType.CollectorHost))
            {
                ListViewItem lviTemplateCollector = new ListViewItem(qt.Name);
                lviTemplateCollector.SubItems.Add(qt.Description);
                lviTemplateCollector.Group = templatesGroup;
                lviTemplateCollector.Tag = qt;
                lvwAgentType.Items.Add(lviTemplateCollector);
            }
        }
        private void LoadCollectorAgents()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);

            foreach (string categoryName in (from a in RegisteredAgentCache.Agents
                                             where ((a.IsCollector && selectingCollectorAgents) || (selectingNotifierAgents && a.IsNotifier)) && a.CategoryName != "Test" && a.CategoryName != "General"
                                             group a by a.CategoryName into g
                                             orderby g.Key
                                             select g.Key))
            {
                lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            }
            ListViewGroup testGroup = new ListViewGroup("Test");
            lvwAgentType.Groups.Add(testGroup);

            ListViewItem lvi;
            foreach (RegisteredAgent ar in (from a in RegisteredAgentCache.Agents
                                            where (selectingCollectorAgents && a.IsCollector) || (selectingNotifierAgents && a.IsNotifier)
                                            orderby a.Name
                                            select a))
            {
                try
                {
                    ListViewGroup agentGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                                where gr.Header.ToLower() == ar.CategoryName.ToLower()
                                                select gr).FirstOrDefault();
                    if (agentGroup == null)
                        agentGroup = generalGroup;

                    lvi = new ListViewItem(ar.DisplayName);
                    string details = ar.ClassName;
                    System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(ar.AssemblyPath);
                    details += ", Version: " + a.GetName().Version.ToString();
                    details += ", Assembly: " + System.IO.Path.GetFileName(a.Location);

                    if (agentGroup == testGroup)
                        lvi.ImageIndex = 1;
                    else
                        lvi.ImageIndex = 0;
                    lvi.Group = agentGroup;
                    lvi.SubItems.Add(details);
                    lvi.Tag = ar;
                    lvwAgentType.Items.Add(lvi);
                    if (ar.Name == InitialRegistrationName)
                        lvi.Selected = true;
                }
                catch { }
            }

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

            foreach (QuickMonTemplate qt in QuickMonTemplate.GetAllTemplates().Where(t => (selectingCollectorAgents && t.TemplateType == TemplateType.CollectorAgent) || (selectingNotifierAgents && t.TemplateType == TemplateType.NotifierAgent)))
            {
                ListViewItem lviTemplateCollector = new ListViewItem(qt.Name);
                lviTemplateCollector.SubItems.Add(qt.Description);
                lviTemplateCollector.Group = templatesGroup;
                lviTemplateCollector.Tag = qt;
                lvwAgentType.Items.Add(lviTemplateCollector);
            }
        }
        private void LoadNotifierHostItems()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();
            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviDefaultNotifier = new ListViewItem("Default Notifier");
            lviDefaultNotifier.SubItems.Add("Creates a default notifier with 'In Memory' agent");
            lviDefaultNotifier.Group = generalGroup;
            lviDefaultNotifier.Tag = NotifierHost.FromXml("<notifierHost name=\"Default Notifier\" enabled=\"True\" alertLevel=\"Warning\" detailLevel=\"Detail\" attendedOptionOverride=\"OnlyAttended\"><notifierAgents><notifierAgent name=\"Memory agent\" type=\"QuickMon.Notifiers.InMemoryNotifier\" enabled=\"True\"><config><inMemory maxEntryCount=\"99999\" /></config></notifierAgent></notifierAgents></notifierHost>");
            lvwAgentType.Items.Add(lviDefaultNotifier);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

            foreach (QuickMonTemplate qt in QuickMonTemplate.GetAllTemplates().Where(t => t.TemplateType == TemplateType.NotifierHost))
            {
                ListViewItem lviTemplateCollector = new ListViewItem(qt.Name);
                lviTemplateCollector.SubItems.Add(qt.Description);
                lviTemplateCollector.Group = templatesGroup;
                lviTemplateCollector.Tag = qt;
                lvwAgentType.Items.Add(lviTemplateCollector);
            }
        }        
        #endregion

        #region Form events
        private void SelectNewEntityType_Load(object sender, EventArgs e)
        {
            lvwAgentType.AutoResizeColumnEnabled = true;
            lvwAgentType.BorderStyle = BorderStyle.None;
            chkEditAfterCreate.Enabled = ShowEditAfterCreation;
            chkShowCustomConfig.Visible = ShowRAWEditing;
        }
        #endregion

        #region ListView events
        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1 && lvwAgentType.SelectedItems[0].Tag != null;
        }
        private void lvwAgentType_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(null, null);
        }
        #endregion

        #region Button events
        private void cmdResetTemplates_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all templates? This cannot be undone.", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                QuickMonTemplate.ResetTemplates();
                if (selectingCollectorHosts)
                {
                    LoadCollectorHostItems();
                }
                else if (selectingCollectorAgents || selectingNotifierAgents)
                {
                    LoadCollectorAgents();
                }
                else if (selectingNotifierHosts)
                {
                    LoadNotifierHostItems();
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                string configToUse = "";
                if (selectingMonitorPacks)
                {
                    #region Monitor pack
                    if (lvwAgentType.SelectedItems[0].Tag is string)
                    {
                        configToUse = lvwAgentType.SelectedItems[0].Tag.ToString();
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate selectedTemplate = (QuickMonTemplate)(lvwAgentType.SelectedItems[0].Tag);
                        configToUse = selectedTemplate.Config;
                    }
                    if (chkShowCustomConfig.Checked)
                    {
                        RAWXmlEditor editor = new RAWXmlEditor();
                        editor.SelectedMarkup = configToUse;
                        if (editor.ShowDialog() == DialogResult.OK)
                        {
                            configToUse = editor.SelectedMarkup;
                        }
                    }
                    configToUse = FormatTemplateVariables(configToUse);
                    if (configToUse.Length == 0)
                        return;

                    MonitorPack mp = new MonitorPack();
                    mp.LoadXml(configToUse);
                    SelectedMonitorPack = mp; 
                    #endregion
                }
                else if (selectingCollectorHosts)
                {
                    #region Collector hosts
                    if (lvwAgentType.SelectedItems[0].Tag is CollectorHost)
                    {
                        CollectorHost newCH = (CollectorHost)lvwAgentType.SelectedItems[0].Tag;
                        newCH.UniqueId = "";
                        configToUse = newCH.ToXml();
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate selectedTemplate = (QuickMonTemplate)(lvwAgentType.SelectedItems[0].Tag);
                        configToUse = selectedTemplate.Config;
                    }
                    if (chkShowCustomConfig.Checked)
                    {
                        RAWXmlEditor editor = new RAWXmlEditor();
                        editor.SelectedMarkup = configToUse;
                        if (editor.ShowDialog() == DialogResult.OK)
                        {
                            configToUse = editor.SelectedMarkup;
                        }
                    }

                    configToUse = FormatTemplateVariables(configToUse);
                    if (configToUse.Length == 0)
                        return;

                    CollectorHost cls = CollectorHost.FromXml(configToUse);
                    if (cls != null)
                    {
                        SelectedCollectorHost = cls;
                    }
                    else
                    {
                        MessageBox.Show("The configuration for this template is invalid! Please correct and try again.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    #endregion
                }
                else if (selectingCollectorAgents || selectingNotifierAgents)
                {
                    #region Collector agents
                    RegisteredAgent ra = null;
                    if (lvwAgentType.SelectedItems[0].Tag is RegisteredAgent)
                    {
                        ra = (RegisteredAgent)lvwAgentType.SelectedItems[0].Tag;
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate template = (QuickMonTemplate)lvwAgentType.SelectedItems[0].Tag;
                        ra = RegisteredAgentCache.GetRegisteredAgentByClassName(template.ForClass, selectingCollectorAgents);
                        configToUse = template.Config;
                    }
                    if (ra != null)
                    {
                        if (System.IO.File.Exists(ra.AssemblyPath))
                        {
                            Assembly collectorEntryAssembly = Assembly.LoadFile(ra.AssemblyPath);
                            SelectedAgent = (IAgent)collectorEntryAssembly.CreateInstance(ra.ClassName);
                            SelectedAgent.AgentClassName = ra.ClassName;
                            SelectedAgent.AgentClassDisplayName = ra.DisplayName;
                            if (configToUse.Length == 0)
                            {
                                configToUse = SelectedAgent.AgentConfig.GetDefaultOrEmptyXml();
                            }
                            if (chkShowCustomConfig.Checked)
                            {
                                RAWXmlEditor editor = new RAWXmlEditor();
                                editor.SelectedMarkup = configToUse;
                                if (editor.ShowDialog() == DialogResult.OK)
                                {
                                    configToUse = editor.SelectedMarkup;
                                }
                            }
                            try
                            {
                                if ((selectingCollectorAgents && configToUse.StartsWith("<collectorAgent")) || (selectingNotifierAgents && configToUse.StartsWith("<notifierAgent")))
                                {
                                    System.Xml.XmlDocument collectorAgentDoc = new System.Xml.XmlDocument();
                                    collectorAgentDoc.LoadXml(configToUse);
                                    System.Xml.XmlNode configNode = collectorAgentDoc.DocumentElement.SelectSingleNode("config");
                                    if (configNode != null)
                                    {
                                        configToUse = configNode.OuterXml;
                                    }
                                }

                                configToUse = FormatTemplateVariables(configToUse);
                                if (configToUse.Length == 0)
                                    return;

                                SelectedAgent.AgentConfig.FromXml(configToUse);
                                DialogResult = DialogResult.OK;
                                Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    #endregion
                }
                else if (selectingNotifierHosts)
                {
                    #region Notifier hosts
                    if (lvwAgentType.SelectedItems[0].Tag is NotifierHost)
                    {
                        configToUse = ((NotifierHost)lvwAgentType.SelectedItems[0].Tag).ToXml();
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate selectedTemplate = (QuickMonTemplate)(lvwAgentType.SelectedItems[0].Tag);
                        configToUse = selectedTemplate.Config;
                    }

                    if (chkShowCustomConfig.Checked)
                    {
                        RAWXmlEditor editor = new RAWXmlEditor();
                        editor.SelectedMarkup = configToUse;
                        if (editor.ShowDialog() == DialogResult.OK)
                        {
                            configToUse = editor.SelectedMarkup;
                        }
                    }

                    configToUse = FormatTemplateVariables(configToUse);
                    if (configToUse.Length == 0)
                        return;

                    NotifierHost cls = NotifierHost.FromXml(configToUse);
                    if (cls != null)
                    {
                        SelectedNotifierHost = cls;
                    }
                    else
                    {
                        MessageBox.Show("The configuration for this template is invalid! Please correct and try again.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    #endregion
                }
                EditAfterCreation = chkEditAfterCreate.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private string FormatTemplateVariables(string config)
        {
            string outputStr = "";
            SetTemplateVariables sv = new SetTemplateVariables();
            sv.InputConfig = config;
            if (sv.ContainVariables())
            {
                if (sv.FormatVariables() == DialogResult.OK)
                {
                    outputStr = sv.FormattedConfig;
                    //MessageBox.Show($"Applied config\r\n{sv.FormattedConfig}", "Variables", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    outputStr = "";
                    //MessageBox.Show("Action cancelled", "Variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                outputStr = sv.InputConfig;
                //MessageBox.Show($"Config string contains no variables!\r\n{sv.InputConfig}", "Variables", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return outputStr;
        }
        private void cmdSkip_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
