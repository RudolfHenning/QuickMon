using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class SelectNewAgentType : Form
    {
        public SelectNewAgentType()
        {
            InitializeComponent();
        }

        private bool selectingCollectors = true;

        #region Properties
        public string InitialRegistrationName { get; set; }
        public RegisteredAgent SelectedAgent { get; set; }
        public AgentPresetConfig SelectedPreset { get; set; }
        public bool ImportConfigAfterSelect { get; set; } 
        #endregion

        public DialogResult ShowCollectorSelection()
        {
            this.Text = "Select Collector type";
            selectingCollectors = true;
            SetDetailColumnSizing();
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();

            ListViewGroup generalGroup = new ListViewGroup("General");
            lvwAgentType.Groups.Add(generalGroup);
            foreach (string categoryName in (from a in RegisteredAgentCache.Agents
                                             where a.IsCollector && a.CategoryName != "Test" && a.CategoryName != "General"
                                             group a by a.CategoryName into g
                                             select g.Key))
            {
                lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            }
            ListViewGroup folderGroup = new ListViewGroup("Folder");
            lvwAgentType.Groups.Add(folderGroup);
            ListViewGroup testGroup = new ListViewGroup("Test");
            lvwAgentType.Groups.Add(testGroup);
            LoadPresetAgents();
            return this.ShowDialog();
        }        

        #region Private methods
        private void SetDetailColumnSizing()
        {
            try
            {
                lvwAgentType.AutoResizeColumnEnabled = false;
                if (chkShowDetails.Checked)
                {
                    lvwAgentType.AutoResizeColumnIndex = 1;
                    lvwAgentType.Columns[0].Width = (int)(lvwAgentType.Width / 3.0);
                }
                else
                {
                    lvwAgentType.AutoResizeColumnIndex = 0;
                    lvwAgentType.Columns[1].Width = 1;
                }
                this.Width -= 1;
                lvwAgentType.AutoResizeColumnEnabled = true;
                this.Width += 1;
            }
            catch { }
        }
        private void LoadAgents()
        {
            if (optSelectPreset.Checked)
                LoadPresetAgents();
            else
                LoadRawAgents();
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1;
        }
        private void LoadPresetAgents()
        {
            lvwAgentType.Items.Clear();
            ListViewItem lvi;
            ListViewGroup generalGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                          where gr.Header.ToLower() == "general"
                                          select gr).FirstOrDefault();

            foreach (AgentPresetConfig preset in (from p in AgentPresetConfig.GetAllPresets()
                                                      orderby p.Description
                                                      select p))
            {
                try
                {
                    RegisteredAgent ar = (from a in RegisteredAgentCache.Agents
                                          where ((selectingCollectors && a.IsCollector) || (!selectingCollectors && a.IsNotifier)) &&
                                            a.ClassName.EndsWith(preset.AgentClassName)
                                          orderby a.Name
                                          select a).FirstOrDefault();
                    if (ar != null)
                    {
                        ListViewGroup agentGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                                    where gr.Header.ToLower() == ar.CategoryName.ToLower()
                                                    select gr).FirstOrDefault();
                        if (agentGroup == null)
                            agentGroup = generalGroup;

                        lvi = new ListViewItem(preset.Description);
                        string details = preset.Config;
                        lvi.ImageIndex = 0;
                        lvi.Group = agentGroup;
                        lvi.SubItems.Add(details);
                        lvi.Tag = preset;
                        lvwAgentType.Items.Add(lvi);
                    }
                }
                catch { }
            }
        }
        private void LoadRawAgents()
        {
            lvwAgentType.Items.Clear();
            ListViewItem lvi;
            if (selectingCollectors)
            {
                RegisteredAgent folder = new RegisteredAgent() { ClassName = "QuickMon.Collectors.Folder", Name = "Folder", IsCollector = true, DisplayName = "Folder" };
                lvi = new ListViewItem("Folder");
                lvi.Group = (from ListViewGroup gr in lvwAgentType.Groups
                             where gr.Header.ToLower() == "folder"
                             select gr).FirstOrDefault();
                lvi.ImageIndex = 1;
                lvi.SubItems.Add("Container for child objects");
                lvi.Tag = folder;
                lvwAgentType.Items.Add(lvi);
                if (InitialRegistrationName == "Folder")
                    lvi.Selected = true;
            }

            ListViewGroup generalGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                          where gr.Header.ToLower() == "general"
                                          select gr).FirstOrDefault();
            ListViewGroup testGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                  where gr.Header.ToLower() == "test"
                                  select gr).FirstOrDefault();

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
                        lvi.ImageIndex = 2;
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
        #endregion

        private void optShowConfigEditor_CheckedChanged(object sender, EventArgs e)
        {
            LoadAgents();
        }

        private void optSelectPreset_CheckedChanged(object sender, EventArgs e)
        {
            //LoadAgents();
        }

        private void chkShowDetails_CheckedChanged(object sender, EventArgs e)
        {
            SetDetailColumnSizing();
        }

        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                if (lvwAgentType.SelectedItems[0].Tag is RegisteredAgent)
                    SelectedAgent = (RegisteredAgent)lvwAgentType.SelectedItems[0].Tag;
                else if (lvwAgentType.SelectedItems[0].Tag is AgentPresetConfig)
                    SelectedPreset = (AgentPresetConfig)lvwAgentType.SelectedItems[0].Tag;
                ImportConfigAfterSelect = chkShowCustomConfig.Checked;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
