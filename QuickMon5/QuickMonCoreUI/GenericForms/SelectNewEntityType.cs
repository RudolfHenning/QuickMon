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
        }

        private bool selectingCollectors = false;
        private bool selectingCollectorHosts = false;

        #region Properties
        public IAgent SelectedAgent { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        #endregion

        public DialogResult ShowCollectorHostSelection()
        {
            this.Text = "Select Collector Host type";
            selectingCollectorHosts = true;
            //SetDetailColumnSizing();
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

            ListViewItem lviPerfCounterCollector = new ListViewItem("Performance Counter");
            lviPerfCounterCollector.SubItems.Add("Creates a collector with a Performance Counter agent");
            lviPerfCounterCollector.Group = generalGroup;
            lviPerfCounterCollector.Tag = CollectorHost.FromXml("<collectorHost uniqueId=\"\" dependOnParentId=\"\" name=\"Performance Counter\"><collectorAgents agentCheckSequence=\"All\"><collectorAgent name=\"PerfCounter\" type=\"QuickMon.Collectors.PerfCounterCollector\" enabled=\"True\"><config><performanceCounters><performanceCounter computer=\".\" category=\"Processor\" counter=\"% Processor Time\" instance=\"_Total\" warningValue=\"90\" errorValue=\"95\" numberOfSamples=\"3\" multiSampleWaitMS=\"100\" outputValueUnit=\"%\" /></performanceCounters></config></collectorAgent></collectorAgents></collectorHost>").Clone(true);
            lvwAgentType.Items.Add(lviPerfCounterCollector);

            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);


            foreach (RegisteredAgent registeredAgent in RegisteredAgentCache.Agents.Where(a => a.IsCollector).OrderBy(a => a.CategoryName))
            {
                ListViewGroup rawAgentTypesGroup = (from ListViewGroup g in lvwAgentType.Groups
                                                    where g.Header == ("RAW Agent type:" + registeredAgent.CategoryName)
                                                    select g).FirstOrDefault();
                if (rawAgentTypesGroup == null)
                {
                    rawAgentTypesGroup = new ListViewGroup("RAW Agent type:" + registeredAgent.CategoryName);
                    lvwAgentType.Groups.Add(rawAgentTypesGroup);
                }
            }


            //ListViewGroup rawAgentTypesGroup = new ListViewGroup("RAW Agent type");
            //
            foreach (RegisteredAgent registeredAgent in RegisteredAgentCache.Agents.Where(a => a.IsCollector).OrderBy(a => a.DisplayName))
            {
                ListViewGroup rawAgentTypesGroup = (from ListViewGroup g in lvwAgentType.Groups
                                                    where g.Header == ("RAW Agent type:" + registeredAgent.CategoryName)
                                                    select g).FirstOrDefault();

                #region Create Collector instance
                ICollector currentAgent = null;
                Assembly collectorEntryAssembly = Assembly.LoadFile(registeredAgent.AssemblyPath);
                currentAgent = (ICollector)collectorEntryAssembly.CreateInstance(registeredAgent.ClassName);
                currentAgent.AgentClassName = registeredAgent.ClassName;
                currentAgent.AgentClassDisplayName = registeredAgent.DisplayName;
                CollectorHost ch = new CollectorHost() { Name = registeredAgent.DisplayName };
                currentAgent.InitialConfiguration = currentAgent.AgentConfig.GetDefaultOrEmptyXml();
                currentAgent.Name = registeredAgent.DisplayName;
                currentAgent.Enabled = true;
                ch.CollectorAgents.Add(currentAgent);
                #endregion Create Collector instance

                ListViewItem lviAgentType = new ListViewItem(registeredAgent.DisplayName);
                lviAgentType.SubItems.Add(registeredAgent.Name);
                lviAgentType.Group = rawAgentTypesGroup;
                lviAgentType.Tag = ch;
                lvwAgentType.Items.Add(lviAgentType);
            }

            //foreach (string categoryName in (from a in RegisteredAgentCache.Agents
            //                                 where a.IsCollector && a.CategoryName != "Test" && a.CategoryName != "General"
            //                                 group a by a.CategoryName into g
            //                                 orderby g.Key
            //                                 select g.Key))
            //{
            //    lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            //}
            //ListViewGroup testGroup = new ListViewGroup("Test");
            //lvwAgentType.Groups.Add(testGroup);
            //LoadTemplates();
            return this.ShowDialog();
        }

        public DialogResult ShowCollectorSelection()
        {
            this.Text = "Select Collector type";
            selectingCollectors = true;
            //SetDetailColumnSizing();
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
                        


            ListViewGroup templatesGroup = new ListViewGroup("Templates");
            lvwAgentType.Groups.Add(templatesGroup);

            //foreach (string categoryName in (from a in RegisteredAgentCache.Agents
            //                                 where a.IsCollector && a.CategoryName != "Test" && a.CategoryName != "General"
            //                                 group a by a.CategoryName into g
            //                                 orderby g.Key
            //                                 select g.Key))
            //{
            //    lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            //}
            //ListViewGroup testGroup = new ListViewGroup("Test");
            //lvwAgentType.Groups.Add(testGroup);
            //LoadTemplates();
            return this.ShowDialog();
        }

        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1 && lvwAgentType.SelectedItems[0].Tag != null;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                if (lvwAgentType.SelectedItems[0].Tag is CollectorHost)
                {
                    SelectedCollectorHost = (CollectorHost)lvwAgentType.SelectedItems[0].Tag;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lvwAgentType_DoubleClick(object sender, EventArgs e)
        {
            cmdOK_Click(null, null);
        }

        private void SelectNewEntityType_Load(object sender, EventArgs e)
        {
            lvwAgentType.AutoResizeColumnEnabled = true;
        }
    }
}
