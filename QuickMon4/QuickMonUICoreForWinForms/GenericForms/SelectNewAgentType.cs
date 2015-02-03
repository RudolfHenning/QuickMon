using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private bool firstChoice = true;

        #region Properties
        public string InitialRegistrationName { get; set; }
        public IAgent SelectedAgent { get; set; }
        #endregion

        public DialogResult ShowNotifierSelection()
        {
            this.Text = "Select Notifier type";
            selectingCollectors = false;
            SetDetailColumnSizing();
            lvwAgentType.Items.Clear();
            lvwAgentType.Groups.Clear();
            LoadTemplates();
            return this.ShowDialog();
        }
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
                                             orderby g.Key
                                             select g.Key))
            {
                lvwAgentType.Groups.Add(new ListViewGroup(categoryName));
            }
            ListViewGroup testGroup = new ListViewGroup("Test");
            lvwAgentType.Groups.Add(testGroup);
            LoadTemplates();
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
                LoadTemplates();
            else
                LoadRawAgents();
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1;
            firstChoice = false;
        }
        private void LoadTemplates()
        {
            lvwAgentType.Items.Clear();
            ListViewItem lvi;
            ListViewGroup generalGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                          where gr.Header.ToLower() == "general"
                                          select gr).FirstOrDefault();

            List<QuickMonTemplate> allTemplates;
            if (selectingCollectors)
                allTemplates = (from p in QuickMonTemplate.GetCollectorAgentTemplates()
                                orderby p.Name
                                select p).ToList();
            else
                allTemplates = (from p in QuickMonTemplate.GetNotifierAgentTemplates()
                                orderby p.Name
                                select p).ToList();            
            
            

            if (allTemplates == null || allTemplates.Count == 0)
            {
                if (!firstChoice)
                    /**************************/
                    MessageBox.Show("No templates found for the selected agent type!", "Templates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    /**************************/
                optShowConfigEditor.Checked = true;
            }
            else
            {
                foreach (QuickMonTemplate template in allTemplates)
                {
                    try
                    {
                        RegisteredAgent ar = (from a in RegisteredAgentCache.Agents
                                              where ((selectingCollectors && a.IsCollector) || (!selectingCollectors && a.IsNotifier)) &&
                                                a.ClassName.EndsWith(template.ForClass)
                                              orderby a.Name
                                              select a).FirstOrDefault();
                        if (ar != null)
                        {
                            ListViewGroup agentGroup = (from ListViewGroup gr in lvwAgentType.Groups
                                                        where gr.Header.ToLower() == ar.CategoryName.ToLower()
                                                        select gr).FirstOrDefault();
                            if (agentGroup == null)
                                agentGroup = generalGroup;

                            lvi = new ListViewItem(template.Name);
                            string details = template.Description.Trim().Length == 0 ? template.Config : template.Description;
                            lvi.ImageIndex = 0;
                            lvi.Group = agentGroup;
                            lvi.SubItems.Add(details);
                            lvi.Tag = template;
                            lvwAgentType.Items.Add(lvi);
                        }
                    }
                    catch { }
                }
                if (lvwAgentType.Items.Count == 0)
                {
                    if (!firstChoice)
                        /**************************/
                        MessageBox.Show("No templates found for the selected agent type!", "Templates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /**************************/
                    optShowConfigEditor.Checked = true;
                }
            }
        }
        private void LoadRawAgents()
        {
            lvwAgentType.Items.Clear();
            ListViewItem lvi;
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

        #region Form events
        private void SelectNewAgentType_Load(object sender, EventArgs e)
        {
            //optSelectPreset.Checked = AgentHelper.LastCreateAgentOption == 0;
            //optShowConfigEditor.Checked = AgentHelper.LastCreateAgentOption == 1;
        } 
        #endregion

        #region Control events
        private void optShowConfigEditor_CheckedChanged(object sender, EventArgs e)
        {
            LoadAgents();
        }
        private void optSelectPreset_CheckedChanged(object sender, EventArgs e)
        {
            LoadAgents();            
        }
        private void chkShowDetails_CheckedChanged(object sender, EventArgs e)
        {
            SetDetailColumnSizing();
        }
        #endregion

        #region ListView events
        private void lvwAgentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgentType.SelectedItems.Count == 1;
        }
        private void lvwAgentType_EnterKeyPressed()
        {
            cmdOK_Click(null, null);
        } 
        #endregion

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgentType.SelectedItems.Count == 1)
            {
                RegisteredAgent ra = null;
                string configToUse = "";
                if (lvwAgentType.SelectedItems[0].Tag is RegisteredAgent)
                {
                    ra = (RegisteredAgent)lvwAgentType.SelectedItems[0].Tag;                   

                }
                else if (lvwAgentType.SelectedItems[0].Tag is QuickMonTemplate)
                {
                    QuickMonTemplate template = (QuickMonTemplate)lvwAgentType.SelectedItems[0].Tag;
                    ra = RegisteredAgentCache.GetRegisteredAgentByClassName(template.ForClass, selectingCollectors);
                    configToUse = template.Config;
                }
                if (ra != null)
                {
                    if (System.IO.File.Exists(ra.AssemblyPath))
                    {
                        Assembly collectorEntryAssembly = Assembly.LoadFile(ra.AssemblyPath);
                        SelectedAgent = (IAgent)collectorEntryAssembly.CreateInstance(ra.ClassName);                        
                        SelectedAgent.AgentClassName = ra.ClassName.Replace("QuickMon.Collectors.", "").Replace("QuickMon.Notifiers.", "");                        
                        SelectedAgent.AgentClassDisplayName = ra.DisplayName;
                        if (configToUse.Length == 0)
                        {
                            configToUse = SelectedAgent.AgentConfig.GetDefaultOrEmptyXml();
                        }
                        if (chkShowCustomConfig.Checked)
                        {
                            RAWXmlEditor editor = new RAWXmlEditor();
                            editor.SelectedMarkup = configToUse;
                            if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                configToUse = editor.SelectedMarkup;
                            }
                        }
                        try
                        {
                            if (selectingCollectors && configToUse.StartsWith("<collectorAgent"))
                            {
                                SelectedAgent = CollectorHost.GetCollectorAgentFromString(configToUse);                                    
                            }
                            else if (!selectingCollectors && configToUse.StartsWith("<notifierAgent"))
                            {
                                SelectedAgent = NotifierHost.GetNotifierAgentFromString(configToUse);
                            }
                            else 
                                SelectedAgent.AgentConfig.FromXml(configToUse);
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }                
            }
        }

        #region More agents link
        private void llblExtraAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://quickmon.codeplex.com/";
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(url);
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion
 
    }
}
