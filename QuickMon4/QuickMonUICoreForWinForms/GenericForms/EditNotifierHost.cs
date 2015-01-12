using QuickMon.Forms;
using QuickMon.UI;
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
    public partial class EditNotifierHost : Form
    {
        public EditNotifierHost()
        {
            InitializeComponent();
        }

        #region Properties
        public string SelectedConfig { get; set; }
        public MonitorPack HostingMonitorPack { get; set; }
        #endregion

        private NotifierHost editingNotifierHost = new NotifierHost();
        private int collectorImgIndex = 1;
        private int folderImgIndex = 0;
        private string indentationChars = "  ";
        private bool selfCheckingOn = false;
        private bool loading = false;

        public DialogResult ShowDialog(NotifierHost nh, MonitorPack hostingMonitorPack = null)
        {
            if (nh != null)
            {
                SelectedConfig = nh.ToXml();
                HostingMonitorPack = hostingMonitorPack;
                return ShowDialog();
            }
            else
                return System.Windows.Forms.DialogResult.Cancel;
        }

        #region Form events
        private void EditNotifierHost_Load(object sender, EventArgs e)
        {
            try
            {
                if (SelectedConfig != null && SelectedConfig.Length > 0 && SelectedConfig.StartsWith("<notifierHost", StringComparison.CurrentCultureIgnoreCase))
                {
                    editingNotifierHost = NotifierHost.FromXml(SelectedConfig, null, false);
                }
                else
                    editingNotifierHost = new NotifierHost();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditNotifierHost_Shown(object sender, EventArgs e)
        {
            try
            {
                LoadControlData();
                lvwEntries.AutoResizeColumnIndex = 2;
                lvwEntries.AutoResizeColumnEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region private methods
        private void LoadControlData()
        {
            if (editingNotifierHost != null)
            {
                txtName.Text = editingNotifierHost.Name;
                chkEnabled.Checked = editingNotifierHost.Enabled;

                if (editingNotifierHost.ServiceWindows != null)
                    linkLabelServiceWindows.Text = editingNotifierHost.ServiceWindows.ToString();
                else
                    linkLabelServiceWindows.Text = "None";
                
                LoadConfigVars();
                LoadAgents();
                LoadCollectorList();
                CheckOkEnabled();
            }
        }

        private void LoadCollectorList()
        {
            loading = true;
            lvwCollectors.Items.Clear();
            if (HostingMonitorPack != null)
            {
                try
                {
                    lvwCollectors.BeginUpdate();
                    List<CollectorHost> noDependantCollectors = (from c in HostingMonitorPack.CollectorHosts
                                                                  where c.ParentCollectorId.Length == 0
                                                                  select c).ToList();
                    foreach (CollectorHost col in noDependantCollectors)
                    {
                        ListViewItem lvi = new ListViewItem(col.Name);
                        lvi.SubItems.Add(col.CollectorAgents.Count().ToString());
                        lvi.Tag = col;
                        if (editingNotifierHost.AlertForCollectors.Contains(col.Name))
                            lvi.Checked = true;
                        if (col.CollectorAgents.Count() == 0)
                            lvi.ImageIndex = folderImgIndex;
                        else
                            lvi.ImageIndex = collectorImgIndex;
                        lvwCollectors.Items.Add(lvi);
                        LoadCollectors(col, indentationChars);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwCollectors.EndUpdate();
                }
            }
            loading = false;
        }
        private void LoadCollectors(CollectorHost collector, string indentation)
        {
            foreach (CollectorHost childCollector in (from c in HostingMonitorPack.CollectorHosts
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                ListViewItem lvi = new ListViewItem(indentation + childCollector.Name);
                lvi.SubItems.Add(collector.CollectorAgents.Count().ToString());
                lvi.Tag = childCollector;
                if (editingNotifierHost.AlertForCollectors.Contains(childCollector.Name))
                    lvi.Checked = true;
                if (childCollector.CollectorAgents.Count() == 0)
                    lvi.ImageIndex = folderImgIndex;
                else
                    lvi.ImageIndex = collectorImgIndex;
                lvwCollectors.Items.Add(lvi);
                LoadCollectors(childCollector, indentation + indentationChars);
            }
        }

        private void CheckOkEnabled()
        {
            bool isEnable = true;
            if (txtName.Text.Length == 0 || editingNotifierHost == null || editingNotifierHost.NotifierAgents == null || editingNotifierHost.NotifierAgents.Count == 0)
                isEnable = false;
            cmdOK.Enabled = isEnable;
        }
        #endregion

        #region Agents
        private void LoadAgents()
        {
            lvwEntries.Items.Clear();
            if (editingNotifierHost.NotifierAgents != null)
            {
                foreach (INotifier agent in editingNotifierHost.NotifierAgents)
                {
                    ListViewItem lvi = new ListViewItem(agent.Name);
                    if (agent.Enabled)
                        lvi.ImageIndex = 1;
                    else
                        lvi.ImageIndex = 0;
                    lvi.SubItems.Add(agent.AgentClassDisplayName);
                    lvi.SubItems.Add(agent.AgentConfig.ConfigSummary);
                    lvi.Tag = agent;
                    lvwEntries.Items.Add(lvi);
                }
            }
        }
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void lvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editCollectorAgentToolStripButton_Click(null, null);
        }
        private void lvwEntries_EnterKeyPressed()
        {
            editCollectorAgentToolStripButton_Click(null, null);
        }
        private void addCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            //Display a list of existing types of agents/by template...
            //Once type is selected load edit agent with default settings
            //CollectorHost.GetCollectorAgentFromString()
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            {
                INotifier agent = (INotifier)selectNewAgentType.SelectedAgent;
                IWinFormsUI agentEditor = RegisteredAgentUIMapper.GetUIClass(agent);
                if (agentEditor != null)
                {
                    agentEditor.AgentName = agent.Name;
                    agentEditor.AgentEnabled = true;
                    agentEditor.SelectedAgentConfig = agent.InitialConfiguration;
                    if (agentEditor.EditAgent())
                    {
                        agent.InitialConfiguration = agentEditor.SelectedAgentConfig;
                        agent.Name = agentEditor.AgentName;
                        agent.Enabled = agentEditor.AgentEnabled;
                        agent.AgentConfig.FromXml(agentEditor.SelectedAgentConfig);

                        ListViewItem lvi = new ListViewItem(agent.Name);
                        if (agent.Enabled)
                            lvi.ImageIndex = 1;
                        else
                            lvi.ImageIndex = 0;
                        lvi.SubItems.Add(agent.AgentClassDisplayName);
                        lvi.SubItems.Add(agent.AgentConfig.ConfigSummary);
                        lvi.Tag = agent;
                        lvwEntries.Items.Add(lvi);
                    }
                }
                else
                {
                    MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void editCollectorAgentToolStripButton_Click(object sender, EventArgs e)
        {
            //Call local (in this assembly) utility that match editor type for agent class.
            //  This assembly will search through all assemblies in local directory for classes that inherits IWinFormsUI
            //  each IWinFormsUI class must provide the name of the IAgent class it can edit
            //  thus each IAgent class name must be unique...
            //  each IWinFormsUI class must have a method to edit the IAgent class.  EditAgent(xmlConfigString) 
            //If no default editor can be found show raw xml editor...
            try
            {
                if (lvwEntries.SelectedItems.Count == 1)
                {
                    INotifier agent = (INotifier)lvwEntries.SelectedItems[0].Tag;
                    IWinFormsUI agentEditor = RegisteredAgentUIMapper.GetUIClass(agent);
                    if (agentEditor != null)
                    {
                        agentEditor.AgentName = agent.Name;
                        agentEditor.AgentEnabled = agent.Enabled;
                        agentEditor.SelectedAgentConfig = agent.InitialConfiguration;
                        if (agentEditor.EditAgent())
                        {

                            agent.InitialConfiguration = agentEditor.SelectedAgentConfig;
                            agent.Name = agentEditor.AgentName;
                            agent.Enabled = agentEditor.AgentEnabled;
                            agent.AgentConfig.FromXml(agentEditor.SelectedAgentConfig);
                            lvwEntries.SelectedItems[0].Text = agent.Name;
                            if (agent.Enabled)
                                lvwEntries.SelectedItems[0].ImageIndex = 1;
                            else
                                lvwEntries.SelectedItems[0].ImageIndex = 0;
                            lvwEntries.SelectedItems[0].SubItems[2].Text = agent.AgentConfig.ConfigSummary;
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lvwEntries_DeleteKeyPressed()
        {
            deleteCollectorAgentToolStripButton_Click(null, null);
        }
        private void deleteCollectorAgentToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                        lvwEntries.Items.Remove(lvi);
                }
            }
        }
        private void moveUpAgentToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index > 0)
            {
                ListViewItem moveItem = lvwEntries.SelectedItems[0];
                int index = moveItem.Index;
                lvwEntries.Items.Remove(moveItem);
                lvwEntries.Items.Insert(index - 1, moveItem);
                moveItem.Selected = true;
            }
        }
        private void moveDownAgentToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index < lvwEntries.Items.Count - 1)
            {
                ListViewItem moveItem = lvwEntries.SelectedItems[0];
                int index = moveItem.Index;
                lvwEntries.Items.Remove(moveItem);
                lvwEntries.Items.Insert(index + 1, moveItem);
                moveItem.Selected = true;
            }
        }
        private void enableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            {
                lvi.ImageIndex = 1;
                INotifier agent = (INotifier)lvi.Tag;
                agent.Enabled = true;
            }
        }
        private void disableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            {
                lvi.ImageIndex = 0;
                INotifier agent = (INotifier)lvi.Tag;
                agent.Enabled = false;
            }
        }
        #endregion

        #region Config Vars
        private bool loadConfigVarEntry = false;
        private void LoadConfigVars()
        {
            loadConfigVarEntry = true;
            lvwConfigVars.Items.Clear();
            if (editingNotifierHost.ConfigVariables != null && editingNotifierHost.ConfigVariables.Count > 0)
            {

                foreach (ConfigVariable cv in editingNotifierHost.ConfigVariables)
                {
                    ListViewItem lvi = new ListViewItem(cv.FindValue);
                    lvi.SubItems.Add(cv.ReplaceValue);
                    lvi.Tag = cv;
                    lvwConfigVars.Items.Add(lvi);
                }

            }
            loadConfigVarEntry = false;
        }
        private void lvwConfigVars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                loadConfigVarEntry = true;
                txtConfigVarSearchFor.Text = lvwConfigVars.SelectedItems[0].Text;
                txtConfigVarReplaceByValue.Text = lvwConfigVars.SelectedItems[0].SubItems[1].Text;
                loadConfigVarEntry = false;
            }
            else
            {
                loadConfigVarEntry = true;
                txtConfigVarSearchFor.Text = "";
                txtConfigVarReplaceByValue.Text = "";
                loadConfigVarEntry = false;
            }
            moveUpConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count == 1 && lvwConfigVars.SelectedItems[0].Index > 0;
            moveDownConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count == 1 && lvwConfigVars.SelectedItems[0].Index < lvwConfigVars.Items.Count - 1;
            deleteConfigVarToolStripButton.Enabled = lvwConfigVars.SelectedItems.Count > 0;
        }
        private void txtConfigVarSearchFor_TextChanged(object sender, EventArgs e)
        {
            UpdateConfigVarListFromText();
        }
        private void txtConfigVarReplaceByValue_TextChanged(object sender, EventArgs e)
        {
            UpdateConfigVarListFromText();

        }
        private void UpdateConfigVarListFromText()
        {
            if (!loadConfigVarEntry)
            {
                if (lvwConfigVars.SelectedItems.Count == 1)
                {
                    lvwConfigVars.SelectedItems[0].Text = txtConfigVarSearchFor.Text;
                    lvwConfigVars.SelectedItems[0].SubItems[1].Text = txtConfigVarReplaceByValue.Text;
                    ((ConfigVariable)lvwConfigVars.SelectedItems[0].Tag).FindValue = txtConfigVarSearchFor.Text;
                    ((ConfigVariable)lvwConfigVars.SelectedItems[0].Tag).ReplaceValue = txtConfigVarReplaceByValue.Text;
                }
                else if (lvwConfigVars.SelectedItems.Count == 0)
                {
                    ListViewItem lvi = new ListViewItem(txtConfigVarSearchFor.Text);
                    lvi.SubItems.Add(txtConfigVarReplaceByValue.Text);
                    lvi.Tag = new ConfigVariable() { FindValue = txtConfigVarSearchFor.Text, ReplaceValue = txtConfigVarReplaceByValue.Text };
                    lvwConfigVars.Items.Add(lvi);
                    lvi.Selected = true;
                }
            }
        }
        private void addConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            loadConfigVarEntry = true;
            lvwConfigVars.SelectedItems.Clear();
            txtConfigVarSearchFor.Text = "";
            txtConfigVarReplaceByValue.Text = "";
            loadConfigVarEntry = false;
            txtConfigVarSearchFor.Focus();
        }
        private void deleteConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count > 0)
            {
                loadConfigVarEntry = true;
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwConfigVars.SelectedItems)
                        lvwConfigVars.Items.Remove(lvi);
                }
                txtConfigVarSearchFor.Text = "";
                txtConfigVarReplaceByValue.Text = "";
                loadConfigVarEntry = false;
            }
        }
        private void moveUpConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                int index = lvwConfigVars.SelectedItems[0].Index;
                if (index > 0)
                {
                    loadConfigVarEntry = true;
                    ConfigVariable tmpBottom = (ConfigVariable)lvwConfigVars.Items[index].Tag;
                    ConfigVariable tmpTop = (ConfigVariable)lvwConfigVars.Items[index - 1].Tag;
                    lvwConfigVars.Items[index].Tag = tmpTop;
                    lvwConfigVars.Items[index].Text = tmpTop.FindValue;
                    lvwConfigVars.Items[index].SubItems[1].Text = tmpTop.ReplaceValue;
                    lvwConfigVars.Items[index - 1].Tag = tmpBottom;
                    lvwConfigVars.Items[index - 1].Text = tmpBottom.FindValue;
                    lvwConfigVars.Items[index - 1].SubItems[1].Text = tmpBottom.ReplaceValue;
                    lvwConfigVars.Items[index].Selected = false;
                    lvwConfigVars.Items[index].Focused = false;
                    lvwConfigVars.Items[index - 1].Selected = true;
                    lvwConfigVars.Items[index - 1].Focused = true;
                    lvwConfigVars.Items[index - 1].EnsureVisible();
                    loadConfigVarEntry = false;
                }
            }
        }
        private void moveDownConfigVarToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwConfigVars.SelectedItems.Count == 1)
            {
                int index = lvwConfigVars.SelectedItems[0].Index;
                if (index < lvwConfigVars.Items.Count - 1)
                {
                    loadConfigVarEntry = true;
                    ConfigVariable tmpBottom = (ConfigVariable)lvwConfigVars.Items[index + 1].Tag;
                    ConfigVariable tmpTop = (ConfigVariable)lvwConfigVars.Items[index].Tag;
                    lvwConfigVars.Items[index + 1].Tag = tmpTop;
                    lvwConfigVars.Items[index + 1].Text = tmpTop.FindValue;
                    lvwConfigVars.Items[index + 1].SubItems[1].Text = tmpTop.ReplaceValue;
                    lvwConfigVars.Items[index].Tag = tmpBottom;
                    lvwConfigVars.Items[index].Text = tmpBottom.FindValue;
                    lvwConfigVars.Items[index].SubItems[1].Text = tmpBottom.ReplaceValue;
                    lvwConfigVars.Items[index].Selected = false;
                    lvwConfigVars.Items[index].Focused = false;
                    lvwConfigVars.Items[index + 1].Selected = true;
                    lvwConfigVars.Items[index + 1].Focused = true;
                    lvwConfigVars.Items[index].EnsureVisible();
                    loadConfigVarEntry = false;
                }
            }
        }
        #endregion

        private void allLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selfCheckingOn = true;
            foreach (ListViewItem lvi in lvwCollectors.Items)
                lvi.Checked = false;
            selfCheckingOn = false;
        }
        private void lvwCollectors_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //if (selfCheckingOn || loading)
            //    return;
            //selfCheckingOn = true;
            //ListViewItem lvi = e.Item;
            //if (lvi.ImageIndex == folderImgIndex)
            //{
            //    string currentIndent = lvi.Text;
            //    if (!currentIndent.StartsWith(" "))
            //        currentIndent = indentationChars;
            //    else
            //    {
            //        foreach (char c in lvi.Text.TakeWhile(cr => cr == ' '))
            //        {
            //            currentIndent += c.ToString();
            //        }
            //        currentIndent += indentationChars;
            //    }
            //    int currentIndex = lvi.Index;
            //    //for (int i = currentIndex + 1; i < lvwCollectors.Items.Count && lvwCollectors.Items[i].Text.StartsWith(currentIndent); i++)
            //    //{
            //    //    lvwCollectors.Items[i].Checked = lvi.Checked;
            //   // }
            //}
            //selfCheckingOn = false;
        }

    }
}
