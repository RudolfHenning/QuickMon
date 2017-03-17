using System;
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

        private bool selectingCollectors = false;
        private bool selectingCollectorHosts = false;

        #region Properties
        public IAgent SelectedAgent { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        public List<QuickMonTemplate> Templates { get; set; }
        public string InitialRegistrationName { get; set; }
        #endregion

        public DialogResult ShowCollectorHostSelection()
        {
            this.Text = "Creating a new Collector";
            selectingCollectorHosts = true;
            cmdResetTemplates.Visible = true;
            LoadCollectorItems();

            return this.ShowDialog();
        }

        private void LoadCollectorItems()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            ListViewItem lviEmptyCollector = new ListViewItem("Folder");
            lviEmptyCollector.SubItems.Add("Creates a blank collector with no agents");
            lviEmptyCollector.Group = generalGroup;
            lviEmptyCollector.Tag = new CollectorHost() { Name = "Folder" };
            lvwAgentType.Items.Add(lviEmptyCollector);

            ListViewItem lviPingCollector = new ListViewItem("Ping");
            lviPingCollector.SubItems.Add("Creates a collector with a Ping agent");
            lviPingCollector.Group = generalGroup;
            lviPingCollector.Tag = CollectorHost.FromXml("<collectorHost uniqueId=\"\" dependOnParentId=\"\" name=\"Ping\"><collectorAgents agentCheckSequence=\"All\"><collectorAgent name=\"Ping\" type=\"QuickMon.Collectors.PingCollector\" enabled=\"True\"><config><entries><entry pingMethod=\"Ping\" address=\"localhost\" /></entries></config></collectorAgent></collectorAgents></collectorHost>").Clone(true);
            lvwAgentType.Items.Add(lviPingCollector);

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

        public DialogResult ShowCollectorSelection()
        {
            this.Text = "Select Collector Agent type";
            selectingCollectors = true;
            cmdResetTemplates.Visible = false;

            LoadCollectorAgents();
           
            //LoadTemplates();
            return ShowDialog();
        }

        private void LoadCollectorAgents()
        {
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);

            foreach (string categoryName in (from a in RegisteredAgentCache.Agents
                                             where a.IsCollector && a.CategoryName != "Test" && a.CategoryName != "General"
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
                                            where (selectingCollectors && a.IsCollector) || (!selectingCollectors && a.IsNotifier)
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


        }

        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1 && lvwAgentType.SelectedItems[0].Tag != null;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                if (selectingCollectorHosts)
                {
                    if (lvwAgentType.SelectedItems[0].Tag is CollectorHost)
                    {
                        SelectedCollectorHost = (CollectorHost)lvwAgentType.SelectedItems[0].Tag;
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate selectedTemplate = (QuickMonTemplate)(lvwAgentType.SelectedItems[0].Tag);
                        CollectorHost cls = CollectorHost.FromXml(selectedTemplate.Config);
                        if (cls != null)
                        {
                            SelectedCollectorHost = cls;
                        }
                        else
                        {
                            MessageBox.Show("The configuration for this template is invalid! Please correct and try again.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (selectingCollectors)
                {
                    RegisteredAgent ra = null;
                    string configToUse = "";
                    if (lvwAgentType.SelectedItems[0].Tag is RegisteredAgent)
                    {
                        ra = (RegisteredAgent)lvwAgentType.SelectedItems[0].Tag;
                        //TemplateUsed = false;
                    }
                    else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                    {
                        QuickMonTemplate template = (QuickMonTemplate)lvwAgentType.SelectedItems[0].Tag;
                        ra = RegisteredAgentCache.GetRegisteredAgentByClassName(template.ForClass, selectingCollectors);
                        configToUse = template.Config;
                        //TemplateUsed = true;
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
                                SelectedAgent.AgentConfig.FromXml(configToUse);
                                //if (selectingCollectors && configToUse.StartsWith("<collectorAgent"))
                                //{
                                //    SelectedAgent.AgentConfig.FromXml(configToUse);
                                //}
                                //else if (!selectingCollectors && configToUse.StartsWith("<notifierAgent"))
                                //{
                                //    SelectedAgent = NotifierHost.GetNotifierAgentFromString(configToUse);
                                //}
                                //else
                                //    SelectedAgent.AgentConfig.FromXml(configToUse);
                                DialogResult = System.Windows.Forms.DialogResult.OK;
                                Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                

                    
            }
        }

        private void lvwAgentType_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(null, null);
        }

        private void SelectNewEntityType_Load(object sender, EventArgs e)
        {
            lvwAgentType.AutoResizeColumnEnabled = true;
            lvwAgentType.BorderStyle = BorderStyle.None;
        }

        private void cmdResetTemplates_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all templates? This cannot be undone.", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                QuickMonTemplate.ResetTemplates();
                if (selectingCollectorHosts)
                {
                    LoadCollectorItems();
                }
            }
        }
    }
}
