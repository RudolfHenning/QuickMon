using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.UI;
using HenIT.Windows.Controls;

namespace QuickMon
{
    public partial class EditCollectorHost : Form
    {
        private class CollectorEntryDisplay
        {
            public int Ident { get; set; }
            public CollectorHost CH { get; set; }
            public override string ToString()
            {
                return new string(' ', Ident * 2) + CH.Name;
            }
        }

        public EditCollectorHost()
        {
            InitializeComponent();
        }

        #region Properties
        public string SelectedConfig { get; set; }
        public MonitorPack HostingMonitorPack { get; set; }
        public List<string> KnownRemoteHosts { get; set; }
        public bool ShowAddAgentsOnStart { get; set; }
        #endregion

        private CollectorHost editingCollectorHost = new CollectorHost();

        public DialogResult ShowDialog(CollectorHost ch, MonitorPack hostingMonitorPack = null)
        {
            if (ch != null)
            {
                SelectedConfig = ch.ToXml();
                HostingMonitorPack = hostingMonitorPack;
                return ShowDialog();
            }
            else
                return System.Windows.Forms.DialogResult.Cancel;
        }

        #region Form events
        private void EditCollectorHost_Load(object sender, EventArgs e)
        {
            try
            {
                cboExpandOnStartOption.SelectedIndex = 0;
                if (SelectedConfig != null && SelectedConfig.Length > 0 && SelectedConfig.StartsWith("<collectorHost", StringComparison.CurrentCultureIgnoreCase))
                {
                    editingCollectorHost = CollectorHost.FromXml(SelectedConfig, null, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditCollectorHost_Shown(object sender, EventArgs e)
        {
            try
            {
                if (editingCollectorHost.CurrentState.State == CollectorState.ConfigurationError)
                {
                    MessageBox.Show(string.Format("An error occured while loading the Collector Host config!\r\n{0}", editingCollectorHost.CurrentState.ReadAllRawDetails()), "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadControlData();
                agentsTreeListView.AutoResizeColumnIndex = 1;
                agentsTreeListView.AutoResizeColumnEnabled = true;
                if (ShowAddAgentsOnStart)
                    CreateAgent();
                else
                    txtName.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Loading error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region private methods
        private void LoadControlData()
        {
            if (editingCollectorHost != null)
            {
                txtName.Text = editingCollectorHost.Name;
                chkEnabled.Checked = editingCollectorHost.Enabled;
                cboExpandOnStartOption.SelectedIndex = (int)editingCollectorHost.ExpandOnStartOption;
                //chkExpandOnStart.Checked = editingCollectorHost.ExpandOnStart;
                agentCheckSequenceToolStripComboBox.SelectedIndex = (int)editingCollectorHost.AgentCheckSequence;
                lblId.Text = editingCollectorHost.UniqueId;
                cboChildCheckBehaviour.SelectedIndex = (int)editingCollectorHost.ChildCheckBehaviour;
                chkEnablePollingOverride.Checked = editingCollectorHost.EnabledPollingOverride;
                onlyAllowUpdateOncePerXSecNumericUpDown.SaveValueSet(editingCollectorHost.OnlyAllowUpdateOncePerXSec);
                chkEnablePollingFrequencySliding.Checked = editingCollectorHost.EnablePollFrequencySliding;
                pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.SaveValueSet(editingCollectorHost.PollSlideFrequencyAfterFirstRepeatSec);
                pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.SaveValueSet(editingCollectorHost.PollSlideFrequencyAfterSecondRepeatSec);
                pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.SaveValueSet(editingCollectorHost.PollSlideFrequencyAfterThirdRepeatSec);
                chkRemoteAgentEnabled.Checked = editingCollectorHost.EnableRemoteExecute;
                chkForceRemoteExcuteOnChildCollectors.Checked = editingCollectorHost.ForceRemoteExcuteOnChildCollectors;
                cboRemoteAgentServer.Text = editingCollectorHost.RemoteAgentHostAddress;
                cboRemoteAgentServer.Items.Clear();
                if (KnownRemoteHosts != null)
                {
                    cboRemoteAgentServer.Items.AddRange(KnownRemoteHosts.ToArray());
                }
                remoteportNumericUpDown.SaveValueSet(editingCollectorHost.RemoteAgentHostPort);
                chkBlockParentRHOverride.Checked = editingCollectorHost.BlockParentOverrideRemoteAgentHostSettings;
                chkRunLocalOnRemoteHostConnectionFailure.Checked = editingCollectorHost.RunLocalOnRemoteHostConnectionFailure;
                if (editingCollectorHost.ServiceWindows != null)
                    linkLabelServiceWindows.Text = editingCollectorHost.ServiceWindows.ToString();
                else
                    linkLabelServiceWindows.Text = "None";
                chkAlertsPaused.Checked = editingCollectorHost.AlertsPaused;
                numericUpDownRepeatAlertInXMin.SaveValueSet(editingCollectorHost.RepeatAlertInXMin); ;
                numericUpDownRepeatAlertInXPolls.SaveValueSet(editingCollectorHost.RepeatAlertInXPolls);
                AlertOnceInXMinNumericUpDown.SaveValueSet(editingCollectorHost.AlertOnceInXMin);
                AlertOnceInXPollsNumericUpDown.SaveValueSet(editingCollectorHost.AlertOnceInXPolls);
                delayAlertSecNumericUpDown.SaveValueSet(editingCollectorHost.DelayErrWarnAlertForXSec);
                delayAlertPollsNumericUpDown.SaveValueSet(editingCollectorHost.DelayErrWarnAlertForXPolls);

                chkCorrectiveScriptDisabled.Checked = editingCollectorHost.CorrectiveScriptDisabled;
                txtCorrectiveScriptOnWarning.Text = editingCollectorHost.CorrectiveScriptOnWarningPath;
                txtCorrectiveScriptOnError.Text = editingCollectorHost.CorrectiveScriptOnErrorPath;
                chkOnlyRunCorrectiveScriptsOnStateChange.Checked = editingCollectorHost.CorrectiveScriptsOnlyOnStateChange;
                txtRestorationScript.Text = editingCollectorHost.RestorationScriptPath;
                chkRunAsEnabled.Checked = editingCollectorHost.RunAsEnabled;
                txtRunAs.Text = editingCollectorHost.RunAs;
                //cmdTestRunAs.Enabled = HostingMonitorPack != null;

                StringBuilder categories = new StringBuilder();
                if (editingCollectorHost.Categories != null && editingCollectorHost.Categories.Count > 0)
                {
                    foreach (string category in editingCollectorHost.Categories)
                    {
                        categories.AppendLine(category);
                    }
                    txtCategories.Text = categories.ToString();
                }

                LoadConfigVars();
                LoadAgents();
                LoadParentCollectorList();
                CheckOkEnabled();
            }
        }
        private void LoadParentCollectorList(CollectorHost parentEntry = null, int indent = 0)
        {
            if (cboParentCollector.Items.Count == 0)
            {
                cboParentCollector.Items.Add("<None>");
                cboParentCollector.SelectedIndex = 0;
            }
            if (HostingMonitorPack != null)
            {
                txtMonitorPack.Text = string.Format("{0} ({1})", HostingMonitorPack.Name, HostingMonitorPack.MonitorPackPath);
                foreach (CollectorHost ce in (from c in HostingMonitorPack.CollectorHosts
                                              where (parentEntry == null && (c.ParentCollectorId == null || c.ParentCollectorId == "")) ||
                                                  (parentEntry != null && parentEntry.UniqueId == c.ParentCollectorId)
                                              select c))
                {
                    CollectorEntryDisplay ceDisplay = new CollectorEntryDisplay() { Ident = indent, CH = ce };
                    if (IsNotInCurrentDependantTree(editingCollectorHost.UniqueId, ce))
                    {
                        cboParentCollector.Items.Add(ceDisplay);
                    }
                    if (ce.UniqueId == editingCollectorHost.ParentCollectorId)
                        cboParentCollector.SelectedItem = ceDisplay;

                    LoadParentCollectorList(ce, indent + 1);
                    cboParentCollector.Enabled = true;
                }
            }
            else
            {
                txtMonitorPack.Text = "N/A";
                cboParentCollector.Enabled = false;
            }
        }
        private bool IsNotInCurrentDependantTree(string uniqueId, CollectorHost ce)
        {
            if (HostingMonitorPack != null)
            {
                if (ce.UniqueId != uniqueId)
                {
                    if (ce.ParentCollectorId != null)
                    {
                        CollectorHost parentCe = (from pce in HostingMonitorPack.CollectorHosts
                                                   where pce.UniqueId == ce.ParentCollectorId
                                                   select pce).FirstOrDefault();
                        if (parentCe != null)
                        {
                            return IsNotInCurrentDependantTree(uniqueId, parentCe);
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = (txtName.Text.Length > 0) && cboParentCollector.SelectedIndex > -1 &&
                    ((!chkRemoteAgentEnabled.Checked && !chkForceRemoteExcuteOnChildCollectors.Checked) || cboRemoteAgentServer.Text.Length > 0);
            cmdRemoteAgentTest.Enabled = (chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked) && cboRemoteAgentServer.Text.Length > 0;
        }
        #endregion

        #region Change tracking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtRemoteAgentServer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }  
        private void chkRemoteAgentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cboRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            remoteportNumericUpDown.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            chkBlockParentRHOverride.Enabled = !chkRemoteAgentEnabled.Checked;
            if (chkRemoteAgentEnabled.Checked)
                chkBlockParentRHOverride.Checked = false;
            CheckOkEnabled();            
        }
        private void chkForceRemoteExcuteOnChildCollectors_CheckedChanged(object sender, EventArgs e)
        {
            chkRemoteAgentEnabled_CheckedChanged(null, null);
        }
        private void cboRemoteAgentServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cboRemoteAgentServer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtRunAs_TextChanged(object sender, EventArgs e)
        {
            cmdTestRunAs.Enabled = txtRunAs.Text.Length > 0 && HostingMonitorPack != null;
        }
        #endregion

        #region Agents
        private void LoadAgents()
        {
            try
            {
                agentsTreeListView.BeginUpdate();
                agentsTreeListView.Items.Clear();
                if (editingCollectorHost.CollectorAgents != null)
                {
                    foreach (ICollector agent in editingCollectorHost.CollectorAgents)
                    {
                        agent.AgentConfig.FromXml(agent.InitialConfiguration);

                        TreeListViewItem tlvi = new TreeListViewItem(string.Format("{0}", agent.Name));
                        if (agent.Enabled)
                            tlvi.ImageIndex = 1;
                        else
                            tlvi.ImageIndex = 0;
                        tlvi.SubItems.Add(agent.AgentClassDisplayName);
                        tlvi.Tag = agent;
                        agentsTreeListView.Items.Add(tlvi);

                        ICollectorConfig entryConfig = (ICollectorConfig)agent.AgentConfig;
                        foreach (ICollectorConfigEntry entry in entryConfig.Entries)
                        {
                            TreeListViewItem tlvAgentEntry = new TreeListViewItem(entry.Description);
                            tlvAgentEntry.ImageIndex = 2;
                            tlvAgentEntry.SubItems.Add(entry.TriggerSummary);
                            tlvAgentEntry.Tag = entry;
                            tlvi.Items.Add(tlvAgentEntry);
                            tlvi.Expand();
                        }
                    }
                }
            }
            catch { }
            finally
            {
                agentsTreeListView.EndUpdate();
            }
        }
        private void CreateAgent()
        {

            //Display a list of existing types of agents/by template...
            //Once type is selected add new Agent to treelistview
            //  if from template use Name as specified in template
            //  else use collector agent type (without the word Collector)
            //    and show new agent entry dialog
            SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            {
                ICollector agent = (ICollector)selectNewAgentType.SelectedAgent;
                agent.Enabled = true;
                if (agent.Name == null || agent.Name.Trim().Length == 0)
                    agent.Name = agent.AgentClassDisplayName.Replace("Collector", "").Trim();

                TreeListViewItem tlvi = new TreeListViewItem(agent.Name);
                if (agent.Enabled)
                    tlvi.ImageIndex = 1;
                else
                    tlvi.ImageIndex = 0;
                tlvi.SubItems.Add(agent.AgentClassDisplayName);
                tlvi.Tag = agent;
                agentsTreeListView.Items.Add(tlvi);

                ICollectorConfig entryConfig = (ICollectorConfig)agent.AgentConfig;
                foreach (ICollectorConfigEntry entry in entryConfig.Entries)
                {
                    TreeListViewItem tlvAgentEntry = new TreeListViewItem(entry.Description);
                    tlvAgentEntry.ImageIndex = 2;
                    tlvAgentEntry.SubItems.Add(entry.TriggerSummary);
                    tlvAgentEntry.Tag = entry;
                    tlvi.Items.Add(tlvAgentEntry);
                    tlvi.Expand();
                }
                editingCollectorHost.CollectorAgents.Add(agent);
                agentsTreeListView.SelectedItems.Clear();
                tlvi.Selected = true;
                if (entryConfig.Entries.Count == 1)
                {
                    tlvi.Selected = false;
                    tlvi.Items[0].Selected = true;
                    EditAgent();
                }
                else if (entryConfig.Entries.Count == 0)
                {
                    CreateAgentEntry();
                }
            }
            ////Display a list of existing types of agents/by template...
            ////Once type is selected load edit agent with default settings
            //SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            //if (selectNewAgentType.ShowCollectorSelection() == System.Windows.Forms.DialogResult.OK)
            //{
            //    ICollector agent = (ICollector)selectNewAgentType.SelectedAgent;
            //    IWinFormsUI agentEditor = RegisteredAgentUIMapper.GetUIClass(agent);
            //    if (agentEditor != null)
            //    {
            //        agentEditor.AgentName = agent.Name;
            //        agentEditor.AgentEnabled = true;
            //        agentEditor.SelectedAgentConfig = agent.InitialConfiguration;
            //        if (agentEditor.EditAgent())
            //        {
            //            agent.InitialConfiguration = agentEditor.SelectedAgentConfig;
            //            agent.Name = agentEditor.AgentName;
            //            agent.Enabled = agentEditor.AgentEnabled;
            //            agent.AgentConfig.FromXml(agentEditor.SelectedAgentConfig);

            //            TreeListViewItem tlvi = new TreeListViewItem(agent.Name);
            //            if (agent.Enabled)
            //                tlvi.ImageIndex = 1;
            //            else
            //                tlvi.ImageIndex = 0;
            //            tlvi.SubItems.Add(agent.AgentClassDisplayName);
            //            tlvi.Tag = agent;
            //            agentsTreeListView.Items.Add(tlvi);

            //            ICollectorConfig entryConfig = (ICollectorConfig)agent.AgentConfig;
            //            foreach (ICollectorConfigEntry entry in entryConfig.Entries)
            //            {
            //                TreeListViewItem tlvAgentEntry = new TreeListViewItem(entry.Description);
            //                tlvAgentEntry.ImageIndex = 2;
            //                tlvAgentEntry.SubItems.Add(entry.TriggerSummary);
            //                tlvAgentEntry.Tag = entry;
            //                tlvi.Items.Add(tlvAgentEntry);
            //                tlvi.Expand();
            //            }
            //            editingCollectorHost.CollectorAgents.Add(agent);

            //            //ListViewItem lvi = new ListViewItem(agent.Name);
            //            //if (agent.Enabled)
            //            //    lvi.ImageIndex = 1;
            //            //else
            //            //    lvi.ImageIndex = 0;
            //            //lvi.SubItems.Add(agent.AgentClassDisplayName);
            //            //lvi.SubItems.Add(agent.AgentConfig.ConfigSummary);
            //            //lvi.Tag = agent;
            //            //lvwEntries.Items.Add(lvi);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
        }
        private void CreateAgentEntry()
        {
            if (agentsTreeListView.SelectedItems.Count == 1)
            {
                TreeListViewItem tlviCurrent = agentsTreeListView.SelectedItems[0];
                if (tlviCurrent.Tag is ICollector)
                {
                    ICollector agent = (ICollector)tlviCurrent.Tag;
                    ICollectorConfig entryConfig = (ICollectorConfig)agent.AgentConfig;
                    WinFormsUICollectorBase agentEditor = (WinFormsUICollectorBase)RegisteredAgentUIMapper.GetUIClass(agent);
                    if (agentEditor != null && agentEditor.DetailEditor != null)
                    {
                        ICollectorConfigEntryEditWindow DetailEditor = agentEditor.DetailEditor;
                        if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                        {
                            entryConfig.Entries.Add(DetailEditor.SelectedEntry);
                            LoadAgents();
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        } 
        private void EditAgent()
        {
            //Call local (in this assembly) utility that match editor type for agent class.
            //  This assembly will search through all assemblies in local directory for classes that inherits IWinFormsUI
            //  each IWinFormsUI class must provide the name of the IAgent class it can edit
            //  thus each IAgent class name must be unique...
            //  each IWinFormsUI class must have a method to edit the IAgent class.  EditAgent(xmlConfigString) 
            //If no default editor can be found show raw xml editor...
            try
            {
                if (agentsTreeListView.SelectedItems.Count == 1)
                {
                    TreeListViewItem tlviCurrent = agentsTreeListView.SelectedItems[0];
                    if (tlviCurrent.Tag is  ICollector)
                    {
                        tlviCurrent.BeginEdit(0);
                    }
                    else if (tlviCurrent.Tag is ICollectorConfigEntry && tlviCurrent.Parent != null && tlviCurrent.Parent.Tag is ICollector)
                    {
                        ICollector agent = (ICollector)tlviCurrent.Parent.Tag;
                        ICollectorConfigEntry entryConfig = (ICollectorConfigEntry)tlviCurrent.Tag;
                        WinFormsUICollectorBase agentEditor = (WinFormsUICollectorBase)RegisteredAgentUIMapper.GetUIClass(agent);
                        if (agentEditor != null && agentEditor.DetailEditor != null)
                        {
                            ICollectorConfigEntryEditWindow DetailEditor = agentEditor.DetailEditor;
                            DetailEditor.SelectedEntry = entryConfig;
                            if (DetailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                            {
                                tlviCurrent.Tag = DetailEditor.SelectedEntry;
                                tlviCurrent.Text = DetailEditor.SelectedEntry.Description;
                                tlviCurrent.SubItems[1].Text = DetailEditor.SelectedEntry.TriggerSummary;
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                //if (lvwEntries.SelectedItems.Count == 1)
                //{
                //    ICollector agent = (ICollector)lvwEntries.SelectedItems[0].Tag;
                //    IWinFormsUI agentEditor = RegisteredAgentUIMapper.GetUIClass(agent);
                //    if (agentEditor != null)
                //    {
                //        agentEditor.AgentName = agent.Name;
                //        agentEditor.AgentEnabled = agent.Enabled;
                //        agentEditor.SelectedAgentConfig = agent.InitialConfiguration;
                //        if (agentEditor.EditAgent())
                //        {

                //            agent.InitialConfiguration = agentEditor.SelectedAgentConfig;
                //            agent.Name = agentEditor.AgentName;
                //            agent.Enabled = agentEditor.AgentEnabled;
                //            agent.AgentConfig.FromXml(agentEditor.SelectedAgentConfig);
                //            lvwEntries.SelectedItems[0].Text = agent.Name;
                //            if (agent.Enabled)
                //                lvwEntries.SelectedItems[0].ImageIndex = 1;
                //            else
                //                lvwEntries.SelectedItems[0].ImageIndex = 0;
                //            lvwEntries.SelectedItems[0].SubItems[2].Text = agent.AgentConfig.ConfigSummary;
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteAgents()
        {
            if (agentsTreeListView.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (TreeListViewItem tlvi in agentsTreeListView.SelectedItems)
                    {
                        if (tlvi.Tag is ICollector)
                        {
                            ICollector agent = (ICollector)tlvi.Tag;
                            editingCollectorHost.CollectorAgents.Remove(agent);
                        }
                        else if (tlvi.Tag is ICollectorConfigEntry && tlvi.Parent != null && tlvi.Parent.Tag is ICollector)
                        {
                            ICollector agent = (ICollector)tlvi.Parent.Tag;
                            ICollectorConfig entryConfig = (ICollectorConfig)agent.AgentConfig;
                            ICollectorConfigEntry agentEntry = (ICollectorConfigEntry)tlvi.Tag;
                            entryConfig.Entries.Remove(agentEntry);
                        }
                    }
                    LoadAgents();
                }
            }

            //if (lvwEntries.SelectedItems.Count > 0)
            //{
            //    if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            //            lvwEntries.Items.Remove(lvi);
            //    }
            //}
        }
        private void EnableAgents()
        {
            if (agentsTreeListView.SelectedItems.Count > 0)
            {
                foreach (TreeListViewItem tlvi in agentsTreeListView.SelectedItems)
                {
                    if (tlvi.Tag is ICollector)
                    {
                        ICollector agent = (ICollector)tlvi.Tag;
                        agent.Enabled = true;
                        tlvi.ImageIndex = 1;
                    }
                }
                agentsTreeListView_SelectedIndexChanged(null, null);
            }
        }
        private void DisableAgents()
        {
            if (agentsTreeListView.SelectedItems.Count > 0)
            {
                foreach (TreeListViewItem tlvi in agentsTreeListView.SelectedItems)
                {
                    if (tlvi.Tag is ICollector)
                    {
                        ICollector agent = (ICollector)tlvi.Tag;
                        agent.Enabled = false;
                        tlvi.ImageIndex = 0;
                    }
                }
                agentsTreeListView_SelectedIndexChanged(null, null);
            }
        }

        private void addCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            CreateAgent();
        }
        private void addAgentEntryToolStripButton_Click(object sender, EventArgs e)
        {
            CreateAgentEntry();
        }        
        private void editCollectorAgentToolStripButton_Click(object sender, EventArgs e)
        {
            EditAgent();
        }
        private void deleteCollectorAgentToolStripButton_Click(object sender, EventArgs e)
        {
            DeleteAgents();
        }
        private void moveUpAgentToolStripButton_Click(object sender, EventArgs e)
        {
            //if (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index > 0)
            //{
            //    ListViewItem moveItem = lvwEntries.SelectedItems[0];
            //    int index = moveItem.Index;
            //    lvwEntries.Items.Remove(moveItem);
            //    lvwEntries.Items.Insert(index - 1, moveItem);
            //    moveItem.Selected = true;
            //}
            if (agentsTreeListView.SelectedItems.Count == 1)
            {
                TreeListViewItem moveItem = agentsTreeListView.SelectedItems[0];
                if (moveItem.Tag is ICollector)
                {
                    ICollector moveAgent = (ICollector)moveItem.Tag;
                    int index = editingCollectorHost.CollectorAgents.IndexOf(moveAgent);
                    if (index > 0)
                    {
                        editingCollectorHost.CollectorAgents.Remove(moveAgent);
                        editingCollectorHost.CollectorAgents.Insert(index - 1, moveAgent);

                        LoadAgents();
                        agentsTreeListView.Items[index - 1].Selected = true;
                    }
                }
                else if (moveItem.Tag is ICollectorConfigEntry && moveItem.Parent != null && moveItem.Parent.Tag is ICollector)
                {
                    ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                    ICollector moveAgent = (ICollector)moveItem.Parent.Tag;
                    ICollectorConfig entryConfig = (ICollectorConfig)moveAgent.AgentConfig;

                    int index = entryConfig.Entries.IndexOf(moveConfigEntry);
                    int agentIndex = editingCollectorHost.CollectorAgents.IndexOf(moveAgent);
                    if (index > 0)
                    {
                        entryConfig.Entries.Remove(moveConfigEntry);
                        entryConfig.Entries.Insert(index - 1, moveConfigEntry);

                        LoadAgents();
                        agentsTreeListView.Items[agentIndex].Items[index - 1].Selected = true;
                    }
                }
            }
        }
        private void moveDownAgentToolStripButton_Click(object sender, EventArgs e)
        {
            //if (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index < lvwEntries.Items.Count - 1)
            //{
            //    ListViewItem moveItem = lvwEntries.SelectedItems[0];
            //    int index = moveItem.Index;
            //    lvwEntries.Items.Remove(moveItem);
            //    lvwEntries.Items.Insert(index + 1, moveItem);
            //    moveItem.Selected = true;
            //}
            if (agentsTreeListView.SelectedItems.Count == 1)
            {
                TreeListViewItem moveItem = agentsTreeListView.SelectedItems[0];
                if (moveItem.Tag is ICollector)
                {
                    ICollector moveAgent = (ICollector)moveItem.Tag;
                    int index = editingCollectorHost.CollectorAgents.IndexOf(moveAgent);
                    if (index < editingCollectorHost.CollectorAgents.Count - 1)
                    {
                        editingCollectorHost.CollectorAgents.Remove(moveAgent);
                        editingCollectorHost.CollectorAgents.Insert(index + 1, moveAgent);

                        LoadAgents();
                        agentsTreeListView.Items[index + 1].Selected = true;
                    }
                }
                else if (moveItem.Tag is ICollectorConfigEntry && moveItem.Parent != null && moveItem.Parent.Tag is ICollector)
                {
                    ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                    ICollector moveAgent = (ICollector)moveItem.Parent.Tag;
                    ICollectorConfig entryConfig = (ICollectorConfig)moveAgent.AgentConfig;
                    int index = entryConfig.Entries.IndexOf(moveConfigEntry);
                    int agentIndex = editingCollectorHost.CollectorAgents.IndexOf(moveAgent);
                    if (index < entryConfig.Entries.Count - 1)
                    {
                        entryConfig.Entries.Remove(moveConfigEntry);
                        entryConfig.Entries.Insert(index + 1, moveConfigEntry);

                        LoadAgents();
                        agentsTreeListView.Items[agentIndex].Items[index + 1].Selected = true;
                    }
                }
            }
        }
        private void enableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            EnableAgents();
        }
        private void disableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            DisableAgents();
        }
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (agentsTreeListView.SelectedItems.Count > 0)
            {
                TreeListViewItem tlvi = agentsTreeListView.SelectedItems[0];
                if (tlvi.Tag is ICollector)
                {
                    ICollector agent = (ICollector)tlvi.Tag;
                    if (!agent.Enabled)
                    {
                        EnableAgents();
                    }
                    else
                    {
                        DisableAgents();
                    }
                }
            }
        }

        #region agentsTreeListView events
        private void agentsTreeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool addAgentEntry = false;
            bool moveUpEnabled = false;
            bool moveDownEnabled = false;
            bool agentEnabledEnabled = false;
            bool agentEDisabledEnabled = false;
            if (agentsTreeListView.SelectedItems.Count == 1)
            {
                TreeListViewItem moveItem = agentsTreeListView.SelectedItems[0];
                if (moveItem.Tag is ICollector)
                {
                    ICollector agent = (ICollector)moveItem.Tag;
                    ICollectorConfig currentCollectorConfig = (ICollectorConfig)agent.AgentConfig;

                    int index = editingCollectorHost.CollectorAgents.IndexOf(agent);
                    moveUpEnabled = index > 0;
                    moveDownEnabled = index < editingCollectorHost.CollectorAgents.Count - 1;

                    addAgentEntry = (!((ICollectorConfig)agent.AgentConfig).SingleEntryOnly) || currentCollectorConfig.Entries.Count == 0;
                    agentEnabledEnabled = !agent.Enabled;
                    agentEDisabledEnabled = agent.Enabled;
                }
                else if (moveItem.Tag is ICollectorConfigEntry)
                {
                    ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                    ICollector moveAgent = (ICollector)moveItem.Parent.Tag;
                    ICollectorConfig entryConfig = (ICollectorConfig)moveAgent.AgentConfig;
                    int index = entryConfig.Entries.IndexOf(moveConfigEntry);
                    moveUpEnabled = index > 0;
                    moveDownEnabled = index < entryConfig.Entries.Count - 1;
                    addAgentEntry = false;
                }
            }
            else
            {
                foreach (TreeListViewItem tlvi in agentsTreeListView.SelectedItems)
                {
                    if (tlvi.Tag is ICollector)
                    {
                        ICollector agent = (ICollector)tlvi.Tag;
                        if (!agent.Enabled)
                            agentEnabledEnabled = true;
                        else
                            agentEDisabledEnabled = true;
                    }
                    else
                    {
                        agentEnabledEnabled = false;
                        agentEDisabledEnabled = false;
                        break;
                    }
                }
            }
            addAgentEntryToolStripButton.Enabled = addAgentEntry;
            addAgentEntryToolStripMenuItem.Enabled = addAgentEntry;
            editCollectorAgentToolStripButton.Enabled = agentsTreeListView.SelectedItems.Count == 1;
            editToolStripMenuItem.Enabled = agentsTreeListView.SelectedItems.Count == 1;
            deleteCollectorAgentToolStripButton.Enabled = agentsTreeListView.SelectedItems.Count > 0;
            deleteToolStripMenuItem.Enabled = agentsTreeListView.SelectedItems.Count > 0;
            moveUpAgentToolStripButton.Enabled = moveUpEnabled;
            moveUpToolStripMenuItem.Enabled = moveUpEnabled;
            moveDownAgentToolStripButton.Enabled = moveDownEnabled;
            moveDownToolStripMenuItem.Enabled = moveDownEnabled;
            enableAgentToolStripButton.Enabled = agentEnabledEnabled;
            disableAgentToolStripButton.Enabled = agentEDisabledEnabled;
            enableToolStripMenuItem.Enabled = agentEnabledEnabled || agentEDisabledEnabled;
            this.enableToolStripMenuItem.Image = agentEnabledEnabled ? global::QuickMon.Properties.Resources._246_7 : global::QuickMon.Properties.Resources.NoGo;
            this.enableToolStripMenuItem.Text = agentEnabledEnabled ? "Enable" : "Disable";
        }
        private void agentsTreeListView_DoubleClick(object sender, EventArgs e)
        {
            EditAgent();
        }
        private void agentsTreeListView_BeforeLabelEdit(object sender, TreeListViewBeforeLabelEditEventArgs e)
        {
            if (!(e.Item.Tag is ICollector && e.ColumnIndex==0))
            {
                e.Cancel = true;
            }
        }
        private void agentsTreeListView_AfterLabelEdit(object sender, TreeListViewLabelEditEventArgs e)
        {
            if (e.ColumnIndex == 0 && agentsTreeListView.FocusedItem.Tag is ICollector)
            {
                ICollector agent = (ICollector)agentsTreeListView.FocusedItem.Tag;
                agent.Name = e.Label;
                agentsTreeListView.FocusedItem.Tag = agent;
            }            
        }
        #endregion

        #region Old Listview code
        //private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //editCollectorAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1;
        //    //deleteCollectorAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
            
        //    //enableAgentToolStripButton.Enabled = (lvwEntries.SelectedItems.Count > 1) || (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].ImageIndex == 0);
        //    //disableAgentToolStripButton.Enabled = (lvwEntries.SelectedItems.Count > 1) || (lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].ImageIndex == 1);
        //}
        //private void lvwEntries_DoubleClick(object sender, EventArgs e)
        //{
        //    editCollectorAgentToolStripButton_Click(null, null);
        //}
        //private void lvwEntries_EnterKeyPressed()
        //{
        //    editCollectorAgentToolStripButton_Click(null, null);
        //}
        //private void lvwEntries_DeleteKeyPressed()
        //{
        //    DeleteAgents();
        //}
        #endregion
        #endregion

        #region Config Vars
        private bool loadConfigVarEntry = false;
        private void LoadConfigVars()
        {
            loadConfigVarEntry = true;
            lvwConfigVars.Items.Clear();
            if (editingCollectorHost.ConfigVariables != null && editingCollectorHost.ConfigVariables.Count > 0)
            {

                foreach (ConfigVariable cv in editingCollectorHost.ConfigVariables)
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
        private void lvwConfigVars_DeleteKeyPressed()
        {
            deleteConfigVarToolStripButton_Click(null, null);
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

        #region Polling overrides
        private void PollingOverrideControlsEnable()
        {
            chkEnablePollingFrequencySliding.Enabled = chkEnablePollingOverride.Checked;
            onlyAllowUpdateOncePerXSecNumericUpDown.Enabled = chkEnablePollingOverride.Checked;
            pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Enabled = chkEnablePollingOverride.Checked && chkEnablePollingFrequencySliding.Checked;
            pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Enabled = chkEnablePollingOverride.Checked && chkEnablePollingFrequencySliding.Checked;
            pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Enabled = chkEnablePollingOverride.Checked && chkEnablePollingFrequencySliding.Checked;
        }
        private void chkEnablePollingOverride_CheckedChanged(object sender, EventArgs e)
        {
            PollingOverrideControlsEnable();
        }
        private void chkEnablePollingFrequencySliding_CheckedChanged(object sender, EventArgs e)
        {
            PollingOverrideControlsEnable();
        }
        #endregion

        #region Corrective scripts
        private void chkCorrectiveScriptDisabled_CheckedChanged(object sender, EventArgs e)
        {
            txtCorrectiveScriptOnWarning.Enabled = !chkCorrectiveScriptDisabled.Checked;
            txtCorrectiveScriptOnError.Enabled = !chkCorrectiveScriptDisabled.Checked;
            txtRestorationScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
            cmdBrowseForWarningCorrectiveScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
            cmdBrowseForErrorCorrectiveScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
            cmdBrowseForRestorationScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
        }
        private void cmdBrowseForWarningCorrectiveScript_Click(object sender, EventArgs e)
        {
            correctiveScriptOpenFileDialog.Title = "Corrective script for Warning Alert";
            if (System.IO.File.Exists(txtCorrectiveScriptOnWarning.Text))
            {
                correctiveScriptOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtCorrectiveScriptOnWarning.Text);
                correctiveScriptOpenFileDialog.FileName = txtCorrectiveScriptOnWarning.Text;
            }
            if (correctiveScriptOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCorrectiveScriptOnWarning.Text = correctiveScriptOpenFileDialog.FileName;
            }
        }
        private void cmdBrowseForErrorCorrectiveScript_Click(object sender, EventArgs e)
        {
            correctiveScriptOpenFileDialog.Title = "Corrective script for Error Alert";
            if (System.IO.File.Exists(txtCorrectiveScriptOnError.Text))
            {
                correctiveScriptOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtCorrectiveScriptOnError.Text);
                correctiveScriptOpenFileDialog.FileName = txtCorrectiveScriptOnError.Text;
            }
            if (correctiveScriptOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtCorrectiveScriptOnError.Text = correctiveScriptOpenFileDialog.FileName;
            }
        }
        private void cmdBrowseForRestorationScript_Click(object sender, EventArgs e)
        {
            correctiveScriptOpenFileDialog.Title = "Restoration script";
            if (System.IO.File.Exists(txtRestorationScript.Text))
            {
                correctiveScriptOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(txtRestorationScript.Text);
                correctiveScriptOpenFileDialog.FileName = txtRestorationScript.Text;
            }
            if (correctiveScriptOpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRestorationScript.Text = correctiveScriptOpenFileDialog.FileName;
            }
        }
        #endregion

        #region Service Windows
        private void linkLabelServiceWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditServiceWindows editServiceWindows = new EditServiceWindows();
            editServiceWindows.SelectedServiceWindows = editingCollectorHost.ServiceWindows;
            if (editServiceWindows.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editingCollectorHost.ServiceWindows = editServiceWindows.SelectedServiceWindows;
                linkLabelServiceWindows.Text = editServiceWindows.SelectedServiceWindows.ToString();
                toolTip1.SetToolTip(linkLabelServiceWindows, "Only operate within specified times. Return 'disabled' status otherwise\r\n" + editingCollectorHost.ServiceWindows.ToString());
                CheckOkEnabled();
            }
        } 
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetEditingCollectorHost())
                {
                    SelectedConfig = editingCollectorHost.ToXml();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool SetEditingCollectorHost()
        {
            bool success = false;
            try
            {
                editingCollectorHost.Name = txtName.Text;
                editingCollectorHost.Enabled = chkEnabled.Checked;
                editingCollectorHost.ExpandOnStartOption = (ExpandOnStartOption)cboExpandOnStartOption.SelectedIndex;// chkExpandOnStart.Checked;
                editingCollectorHost.AgentCheckSequence = (AgentCheckSequence)agentCheckSequenceToolStripComboBox.SelectedIndex;

                if (cboParentCollector.SelectedIndex > 0)
                {
                    CollectorEntryDisplay ced = (CollectorEntryDisplay)cboParentCollector.SelectedItem;
                    editingCollectorHost.ParentCollectorId = ced.CH.UniqueId;
                }
                else
                    editingCollectorHost.ParentCollectorId = "";
                editingCollectorHost.ChildCheckBehaviour = (ChildCheckBehaviour)cboChildCheckBehaviour.SelectedIndex;

                //Remote agents
                editingCollectorHost.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
                editingCollectorHost.ForceRemoteExcuteOnChildCollectors = chkForceRemoteExcuteOnChildCollectors.Checked;
                editingCollectorHost.RemoteAgentHostAddress = cboRemoteAgentServer.Text;
                editingCollectorHost.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
                editingCollectorHost.BlockParentOverrideRemoteAgentHostSettings = chkBlockParentRHOverride.Checked && !chkRemoteAgentEnabled.Checked;
                editingCollectorHost.RunLocalOnRemoteHostConnectionFailure = chkRunLocalOnRemoteHostConnectionFailure.Checked;
                if (chkRemoteAgentEnabled.Checked && editingCollectorHost.RemoteAgentHostAddress.Length > 0)
                {
                    if (KnownRemoteHosts == null)
                        KnownRemoteHosts = new List<string>();
                    if ((from string rh in KnownRemoteHosts
                         where rh.ToLower() == editingCollectorHost.RemoteAgentHostAddress.ToLower() + ":" + editingCollectorHost.RemoteAgentHostPort.ToString()
                         select rh).Count() == 0
                             )
                    {
                        KnownRemoteHosts.Add(editingCollectorHost.RemoteAgentHostAddress + ":" + editingCollectorHost.RemoteAgentHostPort.ToString());
                    }
                }

                //Polling overrides
                if (onlyAllowUpdateOncePerXSecNumericUpDown.Value >= pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value)
                    pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = onlyAllowUpdateOncePerXSecNumericUpDown.Value + 1;
                if (pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value >= pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value)
                    pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value = pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value + 1;
                if (pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value >= pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value)
                    pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value = pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value + 1;

                editingCollectorHost.EnabledPollingOverride = chkEnablePollingOverride.Checked;
                editingCollectorHost.OnlyAllowUpdateOncePerXSec = (int)onlyAllowUpdateOncePerXSecNumericUpDown.Value;
                editingCollectorHost.EnablePollFrequencySliding = chkEnablePollingFrequencySliding.Checked;
                editingCollectorHost.PollSlideFrequencyAfterFirstRepeatSec = (int)pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value;
                editingCollectorHost.PollSlideFrequencyAfterSecondRepeatSec = (int)pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value;
                editingCollectorHost.PollSlideFrequencyAfterThirdRepeatSec = (int)pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value;

                //Alert suppresion
                editingCollectorHost.AlertsPaused = chkAlertsPaused.Checked;
                editingCollectorHost.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
                editingCollectorHost.RepeatAlertInXPolls = (int)numericUpDownRepeatAlertInXPolls.Value;
                editingCollectorHost.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
                editingCollectorHost.AlertOnceInXPolls = (int)AlertOnceInXPollsNumericUpDown.Value;
                editingCollectorHost.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
                editingCollectorHost.DelayErrWarnAlertForXPolls = (int)delayAlertPollsNumericUpDown.Value;
                //Corrective scripts
                editingCollectorHost.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
                editingCollectorHost.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
                editingCollectorHost.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
                editingCollectorHost.RestorationScriptPath = txtRestorationScript.Text;
                editingCollectorHost.CorrectiveScriptsOnlyOnStateChange = chkOnlyRunCorrectiveScriptsOnStateChange.Checked;

                //impersonation
                editingCollectorHost.RunAsEnabled = chkRunAsEnabled.Checked;
                editingCollectorHost.RunAs = txtRunAs.Text;

                //Service windows - Done already            
                editingCollectorHost.ConfigVariables = new List<ConfigVariable>();
                foreach (ListViewItem lvi in lvwConfigVars.Items)
                {
                    editingCollectorHost.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());
                }
                //Categories
                editingCollectorHost.Categories = new List<string>();
                if (txtCategories.Text.Length > 0)
                {
                    foreach(string line in  txtCategories.Lines)
                    {
                        if (line.Length > 0)
                        {
                            editingCollectorHost.Categories.Add(line);
                        }
                    }
                }

                editingCollectorHost.CollectorAgents.Clear();
                foreach(TreeListViewItem tlvi in agentsTreeListView.Items)
                {
                    ICollector agent = (ICollector)tlvi.Tag;
                    ICollectorConfig agentConfig = (ICollectorConfig)agent.AgentConfig;
                    agentConfig.Entries.Clear();
                    foreach (TreeListViewItem tlviEntries in tlvi.Items)
                    {
                        ICollectorConfigEntry entry = (ICollectorConfigEntry)tlviEntries.Tag;
                        agentConfig.Entries.Add(entry);
                    }
                    string agentConfigString = agentConfig.ToXml();
                    agent.AgentConfig.FromXml(agentConfigString);
                    agent.InitialConfiguration = agentConfigString;
                    editingCollectorHost.CollectorAgents.Add(agent);
                }
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return success;
        }
        private void cmdRemoteAgentTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboRemoteAgentServer.Text.Length > 0)
                {
                    string versionInfo = RemoteCollectorHostService.GetRemoteAgentHostVersion(cboRemoteAgentServer.Text, (int)remoteportNumericUpDown.Value);
                    MessageBox.Show("Success\r\nVersion Info: " + versionInfo, "Remote server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remote server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdTestRunAs_Click(object sender, EventArgs e)
        {
            string errorString = "";
            if (HostingMonitorPack != null && txtRunAs.Text.Length > 0)
            {
                if (HostingMonitorPack.UserNameCacheFilePath != null && System.IO.File.Exists(HostingMonitorPack.UserNameCacheFilePath) &&
                    HostingMonitorPack.UserNameCacheMasterKey != null && HostingMonitorPack.UserNameCacheMasterKey.Length > 0
                    )
                {
                    QuickMon.Security.CredentialManager credMan = new Security.CredentialManager();
                    try
                    {
                        credMan.MasterKey = HostingMonitorPack.UserNameCacheMasterKey;
                        credMan.OpenCache(HostingMonitorPack.UserNameCacheFilePath);
                        if (credMan.IsAccountPersisted(txtRunAs.Text))
                        {
                            if (credMan.IsAccountDecryptable(txtRunAs.Text))
                            {
                                string password = credMan.GetAccountPassword(txtRunAs.Text);
                                string userName = txtRunAs.Text;
                                string domainName = System.Net.Dns.GetHostName();
                                if (userName.Contains('\\'))
                                {
                                    domainName = userName.Substring(0, userName.IndexOf('\\'));
                                    userName = userName.Substring(domainName.Length + 1);
                                }
                                if (!QuickMon.Security.Impersonator.Impersonate(userName, password, domainName))
                                {
                                    MessageBox.Show("The specified 'Run as' user name was found in the credential cache but the password is incorrect or cannot be authenticated!", "Credential cache", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("The specified 'Run as' user name was found in the credential cache and can be authenticated!\r\n" +
                                        System.Security.Principal.WindowsIdentity.GetCurrent().Name, "Credential cache", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    QuickMon.Security.Impersonator.UnImpersonate();
                                }
                                return;
                            }
                            else
                            {
                                errorString = "The specified 'Run as' user name could not be decrypted!\r\nPlease check the specified 'Master key' value!";
                            }
                        }
                        else
                        {
                            errorString = "The specified 'Run as' user name was not found in the credential cache!";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (HostingMonitorPack.ApplicationUserNameCacheFilePath != null && System.IO.File.Exists(HostingMonitorPack.ApplicationUserNameCacheFilePath) &&
                    HostingMonitorPack.ApplicationUserNameCacheMasterKey != null && HostingMonitorPack.ApplicationUserNameCacheMasterKey.Length > 0
                    )
                {
                    QuickMon.Security.CredentialManager credMan = new Security.CredentialManager();
                    try
                    {
                        credMan.MasterKey = HostingMonitorPack.ApplicationUserNameCacheMasterKey;
                        credMan.OpenCache(HostingMonitorPack.ApplicationUserNameCacheFilePath);
                        if (credMan.IsAccountPersisted(txtRunAs.Text))
                        {
                            if (credMan.IsAccountDecryptable(txtRunAs.Text))
                            {
                                string password = credMan.GetAccountPassword(txtRunAs.Text);
                                string userName = txtRunAs.Text;
                                string domainName = System.Net.Dns.GetHostName();
                                if (userName.Contains('\\'))
                                {
                                    domainName = userName.Substring(0, userName.IndexOf('\\'));
                                    userName = userName.Substring(domainName.Length + 1);
                                }
                                if (!QuickMon.Security.Impersonator.Impersonate(userName, password, domainName))
                                {
                                    MessageBox.Show("The specified 'Run as' user name was found in the credential cache but the password is incorrect or cannot be authenticated!", "Credential cache", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show("The specified 'Run as' user name was found in the credential cache and can be authenticated!\r\n" +
                                        System.Security.Principal.WindowsIdentity.GetCurrent().Name, "Credential cache", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    QuickMon.Security.Impersonator.UnImpersonate();
                                }
                                return;
                            }
                            else
                            {
                                errorString = "The specified 'Run as' user name could not be decrypted!\r\nPlease check the specified 'Master key' value!";
                            }
                        }
                        else
                        {
                            errorString = "The specified 'Run as' user name was not found in the credential cache!";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (errorString.Length > 0)
                    MessageBox.Show(errorString, "Credential cache", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Raw editing of config
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SetEditingCollectorHost())
            {
                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = editingCollectorHost.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        editingCollectorHost = CollectorHost.FromXml(editor.SelectedMarkup, null, false);

                        if (editor.SelectedMarkup != null && editor.SelectedMarkup.Length > 0 && editingCollectorHost.CurrentState.State == CollectorState.ConfigurationError)
                        {
                            if (MessageBox.Show("Editing the raw config resulted in a configuration error!\r\nDo you want to accept this?", "Configuration error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                            {
                                editingCollectorHost = CollectorHost.FromXml(oldMarkUp, null, false);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while processing the config!\r\n" + ex.Message, "Edit config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    LoadControlData();
                }
            }
        } 
        #endregion

        private void llblExportConfigAsTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Templates have not yet been implemented!", "Templates", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboRemoteAgentServer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboRemoteAgentServer.SelectedItem.ToString().Contains(":"))
            {
                string port = cboRemoteAgentServer.SelectedItem.ToString().Split(':')[1];
                cboRemoteAgentServer.Text = cboRemoteAgentServer.SelectedItem.ToString().Split(':')[0];
                if (port.IsIntegerTypeNumber())
                    remoteportNumericUpDown.SaveValueSet(decimal.Parse(port));
            }
        }

        private void cboRemoteAgentServer_Leave(object sender, EventArgs e)
        {
            if (cboRemoteAgentServer.Text.Contains(":"))
            {
                string port = cboRemoteAgentServer.Text.Split(':')[1];
                cboRemoteAgentServer.Text = cboRemoteAgentServer.Text.Split(':')[0];
                if (port.IsIntegerTypeNumber())
                    remoteportNumericUpDown.SaveValueSet(decimal.Parse(port));
            }
        }
             
    }
}