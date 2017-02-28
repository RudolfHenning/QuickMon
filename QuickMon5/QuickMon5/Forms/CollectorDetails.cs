using HenIT.RTF;
using HenIT.Windows.Controls;
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
    public partial class CollectorDetails : Form, IChildWindowIdentity
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

        public CollectorDetails()
        {
            InitializeComponent();
        }

        #region Private vars
        /// <summary>
        /// CollectorHost tyo temporarily store editing changes before it is saved
        /// </summary>
        private CollectorHost editingCollectorHost = null;
        private int previousSelectedAlertTextIndex = -1;

        private int agentsEditSplitContainerHeight = 0;
        private int hostSettingsSplitContainerHeight = 0;
        private int operationalSplitContainerHeight = 0;
        private int alertsSplitContainerHeight = 0;
        private int configVariSplitContainerHeight = 0;
        #endregion

        #region TreeNodeImage contants
        private readonly int collectorFolderImage = 0;
        private readonly int collectorNAstateImage = 1;
        private readonly int collectorGoodStateImage1 = 2;
        private readonly int collectorGoodStateImage2 = 5;
        private readonly int collectorWarningStateImage1 = 3;
        private readonly int collectorWarningStateImage2 = 6;
        private readonly int collectorErrorStateImage1 = 4;
        private readonly int collectorErrorStateImage2 = 7;
        private readonly int collectorDisabled = 8;
        #endregion

        #region Public properties
        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        public IParentWindow ParentWindow { get; set; } 
        public MonitorPack HostingMonitorPack { get; set; }
        #endregion

        #region IChildWindowIdentity
        public string Identifier { get; set; }
        public void RefreshDetails()
        {
            if (SelectedCollectorHost != null)
            {
                LoadControls();
            }
        }
        public void CloseChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow()
        {
            tlvAgentStates.BorderStyle = BorderStyle.None;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion

        #region Form events
        private void CollectorDetails_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 500);
            tlvAgentStates.AutoResizeColumnEnabled = true;
            agentsTreeListView.AutoResizeColumnEnabled = true;
            lvwHistory.AutoResizeColumnEnabled = true;
            lvwHistory.BorderStyle = BorderStyle.None;
            panelEditing.BorderStyle = BorderStyle.None;
            txtName.BorderStyle = BorderStyle.None;
            agentStateSplitContainer.Panel2Collapsed = true;
            collectorDetailSplitContainer.Panel2Collapsed = true;

            agentsEditSplitContainerHeight = agentsEditSplitContainer.Height;
            hostSettingsSplitContainerHeight = hostSettingsSplitContainer.Height;
            operationalSplitContainerHeight = operationalSplitContainer.Height;
            alertsSplitContainerHeight = alertsSplitContainer.Height;
            configVariSplitContainerHeight = configVariSplitContainer.Height;

            if (SelectedCollectorHost == null)
            {
                SelectedCollectorHost = new CollectorHost();
            }
            else
            {
                HostingMonitorPack = SelectedCollectorHost.ParentMonitorPack; 
            }
            RefreshDetails();
            splitContainerMain.Panel2Collapsed = true;
            SetActivePanel(panelAgentStates);
            UpdateStatusBar();
        }
        private void CollectorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseChildWindow();
        }
        private void CollectorDetails_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Private methods
        private void SetActivePanel(Panel panelAgentStates)
        {
            
            foreach (Control c in panelCollectorDetails.Controls)
            {
                if (c is Panel && panelAgentStates == (Panel)c)
                {
                    c.Visible = true;
                    c.Dock = DockStyle.Fill;
                }
                else
                {
                    c.Visible = false;
                    c.Dock = DockStyle.None;
                }

            }
        }
        private void StartEditMode()
        {
            agentsEditSplitContainer.Panel2Collapsed = false;
            hostSettingsSplitContainer.Panel2Collapsed = true;
            hostSettingsSplitContainer.Height = 25;
            cmdHostsToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            operationalSplitContainer.Panel2Collapsed = true;
            operationalSplitContainer.Height = 25;
            cmdOperationalToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            alertsSplitContainer.Panel2Collapsed = true;
            alertsSplitContainer.Height = 25;
            cmdAlertsToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            configVariSplitContainer.Panel2Collapsed = true;
            configVariSplitContainer.Height = 25;
            cmdConfigVarsToggle.Image = global::QuickMon.Properties.Resources.icon_expand16x16;

            if (this.Size.Height < 450)
            {
                this.Size = new Size(this.Size.Width, 450);
            }
            collectorDetailSplitContainer.Panel2Collapsed = true;
            optAgentStates.Enabled = false;
            optMetrics.Enabled = false;
            txtName.ReadOnly = false;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            SetActivePanel(panelEditing);
        }
        private void StopEditMode()
        {
            optAgentStates.Enabled = true;
            optMetrics.Enabled = true;
            txtName.ReadOnly = true;
            txtName.BorderStyle = BorderStyle.None;
            if (optAgentStates.Checked)
                optAgentStates_CheckedChanged(null, null);
            else if (optMetrics.Checked)
                optMetrics_CheckedChanged(null, null);
        }
        private int GetNodeStateImageIndex(CollectorState state)
        {
            int stateImageIndex = collectorNAstateImage;
            if (state == CollectorState.Good)
                stateImageIndex = collectorGoodStateImage1;
            else if (state == CollectorState.Warning)
                stateImageIndex = collectorWarningStateImage1;
            else if (state == CollectorState.Error || state == CollectorState.ConfigurationError)
                stateImageIndex = collectorErrorStateImage1;
            return stateImageIndex;
        }
        private void LoadControls()
        {
            SetWindowTitle();
            if (SelectedCollectorHost.CurrentState != null)
            {
                if (SelectedCollectorHost.CurrentState.State == CollectorState.Good)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.ok16x16;
                    txtName.BackColor = Color.White;
                }
                else if (SelectedCollectorHost.CurrentState.State == CollectorState.Warning)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.triang_yellow16x16;
                    txtName.BackColor = Color.LightYellow;
                }
                else if (SelectedCollectorHost.CurrentState.State == CollectorState.Error || SelectedCollectorHost.CurrentState.State == CollectorState.ConfigurationError)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.stop16x16;
                    txtName.BackColor = Color.FromArgb(255, 240, 240);
                }
                else
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.helpbwy16x16;
                    txtName.BackColor = Color.White;
                }
            }
            
            txtName.Text = SelectedCollectorHost.Name;
            LoadHistory();
            UpdateAgentStateTree();

            #region Editing controls
            editingCollectorHost = SelectedCollectorHost.Clone();

            agentCheckSequenceToolStripComboBox.SelectedIndex = (int)editingCollectorHost.AgentCheckSequence;
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

            if (Properties.Settings.Default.KnownRemoteHosts != null && Properties.Settings.Default.KnownRemoteHosts.Count > 0)
            {
                cboRemoteAgentServer.Items.AddRange((from string krh in Properties.Settings.Default.KnownRemoteHosts
                                                     select krh).ToArray());
            }            
            cboRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            remoteportNumericUpDown.SaveValueSet(editingCollectorHost.RemoteAgentHostPort);
            remoteportNumericUpDown.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            chkBlockParentRHOverride.Checked = editingCollectorHost.BlockParentOverrideRemoteAgentHostSettings;
            chkRunLocalOnRemoteHostConnectionFailure.Checked = editingCollectorHost.RunLocalOnRemoteHostConnectionFailure;
            chkRunLocalOnRemoteHostConnectionFailure.Enabled = chkRemoteAgentEnabled.Checked;
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
            numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.SaveValueSet(editingCollectorHost.CorrectiveScriptOnWarningMinimumRepeatTimeMin);
            numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.SaveValueSet(editingCollectorHost.CorrectiveScriptOnErrorMinimumRepeatTimeMin);
            chkOnlyRunCorrectiveScriptsOnStateChange.Checked = editingCollectorHost.CorrectiveScriptsOnlyOnStateChange;
            numericUpDownRestorationScriptMinimumRepeatTimeMin.SaveValueSet(editingCollectorHost.RestorationScriptMinimumRepeatTimeMin);
            chkRunAsEnabled.Checked = editingCollectorHost.RunAsEnabled;
            txtRunAs.Text = editingCollectorHost.RunAs;
            txtAdditionalNotes.Text = editingCollectorHost.Notes;
            cboTextType_SelectedIndexChanged(null, null);

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
            #endregion

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
                //txtMonitorPack.Text = string.Format("{0} ({1})", HostingMonitorPack.Name, HostingMonitorPack.MonitorPackPath);
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
                //txtMonitorPack.Text = "N/A";
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
        private void SetWindowTitle()
        {
            Text = "Collector Details";
            if (SelectedCollectorHost != null)
            {
                Text += " - " + SelectedCollectorHost.Name;
                SetAppIcon(SelectedCollectorHost.CurrentState.State);
            }
        }
        private void SetAppIcon(CollectorState state)
        {
            try
            {
                Icon icon;
                if (state == CollectorState.Error)
                {
                    icon = Properties.Resources.Err;
                }
                else if (state == CollectorState.Warning)
                {
                    icon = Properties.Resources.warn;
                }
                else if (state == CollectorState.Good)
                {
                    icon = Properties.Resources.ok;
                }
                else
                {
                    icon = Properties.Resources.QM4BlueStateNAA;
                }
                Icon oldIcon = this.Icon;
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.Icon = icon;
                    }
                    );
                }
                else
                {
                    this.Icon = icon;
                }
                oldIcon.Dispose();
            }
            catch (Exception)
            {
                //to be added
                this.Icon = Properties.Resources.QM4BlueStateNAA;
            }
        }
        private void UpdateStatusBar()
        {
            toolStripStatusLabelEnabled.Text = SelectedCollectorHost.Enabled ? "Enabled" : "Disabled";
            toolStripStatusLabelEnabled.Image = SelectedCollectorHost.Enabled ? global::QuickMon.Properties.Resources._131 : global::QuickMon.Properties.Resources._141;
            toolStripStatusLabelAutoRefresh.Text = AutoRefreshEnabled ? "Auto Refresh ON" : "Auto Refresh OFF";
            toolStripStatusLabelAutoRefresh.Image = AutoRefreshEnabled ? global::QuickMon.Properties.Resources._131 : global::QuickMon.Properties.Resources._141;
        }
        private void UpdateAgentStateTree()
        {
            MonitorState selectedMonitorState;
            tlvAgentStates.Items.Clear();

            if (optHistoricStateView.Checked && lvwHistory.SelectedItems.Count == 1 && lvwHistory.SelectedItems[0].Tag is MonitorState)
            {
                selectedMonitorState = (MonitorState)lvwHistory.SelectedItems[0].Tag;
            }
            else
            {
                selectedMonitorState = SelectedCollectorHost.CurrentState;
            }

            if (selectedMonitorState == null || selectedMonitorState.ChildStates== null || selectedMonitorState.ChildStates.Count == 0 || selectedMonitorState.State == CollectorState.UpdateInProgress || selectedMonitorState.State == CollectorState.NotAvailable)
            {
                int agentNodeStateIndex = GetNodeStateImageIndex(selectedMonitorState.State);
                foreach (ICollector agent in SelectedCollectorHost.CollectorAgents)
                {
                    HenIT.Windows.Controls.TreeListViewItem agentNode = new HenIT.Windows.Controls.TreeListViewItem(agent.Name, agentNodeStateIndex);
                    agentNode.SubItems.Add("");
                    agentNode.Tag = agent;

                    foreach (ICollectorConfigEntry entry in ((ICollectorConfig)agent.AgentConfig).Entries)
                    {
                        HenIT.Windows.Controls.TreeListViewItem entryNode = new HenIT.Windows.Controls.TreeListViewItem(entry.Description, collectorNAstateImage);
                        entryNode.SubItems.Add("");
                        agentNode.Items.Add(entryNode);
                        if (entry.SubItems != null)
                        {
                            foreach (ICollectorConfigSubEntry subEntry in entry.SubItems)
                            {
                                HenIT.Windows.Controls.TreeListViewItem subEntryNode = new HenIT.Windows.Controls.TreeListViewItem(subEntry.Description, collectorNAstateImage);
                                subEntryNode.SubItems.Add("");
                                entryNode.Items.Add(subEntryNode);
                            }
                        }
                    }
                    tlvAgentStates.Items.Add(agentNode);
                    agentNode.ExpandAll();
                }
            }
            else
            {
                foreach (MonitorState agentState in selectedMonitorState.ChildStates)
                {
                    int agentNodeStateIndex = GetNodeStateImageIndex(agentState.State);
                    HenIT.Windows.Controls.TreeListViewItem agentNode = new HenIT.Windows.Controls.TreeListViewItem(agentState.ForAgent, agentNodeStateIndex);
                    agentNode.SubItems.Add(agentState.FormatValue());
                    agentNode.Tag = agentState;
                    tlvAgentStates.Items.Add(agentNode);
                    foreach (MonitorState entryState in agentState.ChildStates)
                    {
                        int entryNodeStateIndex = GetNodeStateImageIndex(entryState.State);
                        HenIT.Windows.Controls.TreeListViewItem entryNode = new HenIT.Windows.Controls.TreeListViewItem(entryState.ForAgent, entryNodeStateIndex);
                        entryNode.SubItems.Add(entryState.FormatValue());
                        entryNode.Tag = entryState;
                        agentNode.Items.Add(entryNode);
                        foreach (MonitorState subEntryState in entryState.ChildStates)
                        {
                            int subEntryNodeStateIndex = GetNodeStateImageIndex(subEntryState.State);
                            HenIT.Windows.Controls.TreeListViewItem subEntryNode = new HenIT.Windows.Controls.TreeListViewItem(subEntryState.ForAgent, subEntryNodeStateIndex);
                            subEntryNode.SubItems.Add(subEntryState.FormatValue());
                            subEntryNode.Tag = subEntryState;
                            entryNode.Items.Add(subEntryNode);
                        }
                    }
                    agentNode.ExpandAll();
                }
            }    
        }
        private void LoadHistory()
        {
            MonitorState hi;
            DateTime selectedTimeStamp = new DateTime(1900, 1, 1);
            if (lvwHistory.SelectedItems.Count == 1 && lvwHistory.SelectedItems[0].Tag is MonitorState)
            {
                hi = (MonitorState)lvwHistory.SelectedItems[0].Tag;
                selectedTimeStamp = hi.Timestamp;
            }

            lvwHistory.Items.Clear();
            if (SelectedCollectorHost != null && SelectedCollectorHost.StateHistory != null && SelectedCollectorHost.CurrentState != null)
            {
                optHistoricStateView.Text = "Historic (" + SelectedCollectorHost.StateHistory.Count.ToString() + ")";
                hi = SelectedCollectorHost.CurrentState;
                ListViewItem lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.ImageIndex = GetNodeStateImageIndex(hi.State);
                lvi.SubItems.Add(hi.State.ToString());
                lvi.SubItems.Add(hi.CallDurationMS.ToString());
                lvi.SubItems.Add(hi.AlertsRaised.Count.ToString());
                lvi.SubItems.Add(hi.ExecutedOnHostComputer);
                lvi.SubItems.Add(hi.RanAs);
                lvi.SubItems.Add(hi.ReadFirstValue());
                lvi.Tag = hi;
                lvwHistory.Items.Add(lvi);
                if (selectedTimeStamp == hi.Timestamp)
                    lvi.Selected = true;

                for (int i = SelectedCollectorHost.StateHistory.Count - 1; i >= 0; i--)
                {
                    hi = SelectedCollectorHost.StateHistory[i];
                    lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.ImageIndex = GetNodeStateImageIndex(hi.State);
                    lvi.SubItems.Add(hi.State.ToString());
                    lvi.SubItems.Add(hi.CallDurationMS.ToString());
                    lvi.SubItems.Add(hi.AlertsRaised.Count.ToString());
                    lvi.SubItems.Add(hi.ExecutedOnHostComputer);
                    lvi.SubItems.Add(hi.RanAs);
                    lvi.SubItems.Add(hi.ReadFirstValue());
                    lvi.Tag = hi;
                    lvwHistory.Items.Add(lvi);
                    if (selectedTimeStamp == hi.Timestamp)
                        lvi.Selected = true;
                }
                if (lvwHistory.SelectedItems.Count == 1)
                    lvwHistory.SelectedItems[0].EnsureVisible();
            }
            else
            {
                optHistoricStateView.Text = "Historic";
            }
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

        #region Button events
        private void cmdActionScriptsVisible_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }
        private void cmdCollectorEdit_Click(object sender, EventArgs e)
        {
            StartEditMode();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            StopEditMode();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshDetails();
        }
        #endregion

        //private void flowLayoutPanelCollectorStuff_Resize(object sender, EventArgs e)
        //{
        //    int clientSizeWidth = flowLayoutPanelCollectorStuff.ClientSize.Width - flowLayoutPanelCollectorStuff.Margin.Left - flowLayoutPanelCollectorStuff.Margin.Right - 1;
        //    int clientSizeHeight = flowLayoutPanelCollectorStuff.ClientSize.Height - flowLayoutPanelCollectorStuff.Margin.Top - flowLayoutPanelCollectorStuff.Margin.Bottom - 1;
        //    foreach (Control c in flowLayoutPanelCollectorStuff.Controls)
        //    {
        //        if (c is Panel)
        //        {
        //            c.Width = clientSizeWidth;
        //            c.Height = clientSizeHeight;
        //        }
        //    }
        //}

        private void optAgentStates_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelAgentStates);
        }
        private void optMetrics_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelMetrics);
        }

        private void statusStripCollector_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "toolStripStatusLabelEnabled")
            {
                SelectedCollectorHost.Enabled = !SelectedCollectorHost.Enabled;
                UpdateStatusBar();

                ((MainForm)ParentWindow).UpdateCollector(SelectedCollectorHost, true);
            }
            else if (e.ClickedItem.Name == "toolStripStatusLabelAutoRefresh")
            {
                AutoRefreshEnabled = !AutoRefreshEnabled;
                UpdateStatusBar();
            }
            else if (e.ClickedItem.Name == "toolStripStatusLabelRawEdit")
            {
                DoRAWEdit();
            }
        }

        private void DoRAWEdit()
        {
            if (ValidateInput())
            {
                SelectedCollectorHost.Name = txtName.Text;
                SelectedCollectorHost.ToXml();

                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = SelectedCollectorHost.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedCollectorHost.ReconfigureFromXml(editor.SelectedMarkup);
                    LoadControls();
                    ((MainForm)ParentWindow).UpdateCollector(SelectedCollectorHost, true);
                    //TriggerMonitorPackReload = true;
                    //MonitorPack newMP = new MonitorPack();
                    //newMP.LoadXml(editor.SelectedMarkup);
                    //newMP.MonitorPackPath = SelectedMonitorPack.MonitorPackPath;
                    //SelectedMonitorPack = null;
                    //SelectedMonitorPack = newMP;
                    //LoadFormControls();
                }
            }
        }

        private bool ValidateInput()
        {
            bool success = true;
            if (txtName.Text.Length == 0)
                success = false;
            return success;
        }

        private void optCurrentStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = true;
            UpdateAgentStateTree();
        }
        private void optHistoricStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = false;
            //if (lvwHistory.SelectedItems.Count == 0 && lvwHistory.Items.Count > 0)
            //{
            //    lvwHistory.Items[0].Selected = true;
            //}
            UpdateAgentStateTree();
        }

        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwHistory.SelectedItems.Count == 1)
            {
                UpdateAgentStateTree();
                UpdateRawView();
            }            
        }

        private void tlvAgentStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRawView();
        }

        private static bool updateAgentsDetailViewBusy = false;
        private void UpdateRawView()
        {
            if (!updateAgentsDetailViewBusy)
            {
                updateAgentsDetailViewBusy = true;
                RTFBuilder rtfBuilder = new RTFBuilder();

                if (tlvAgentStates.Focused)
                {
                    if (tlvAgentStates.SelectedItems.Count == 0)
                    {                        
                        rtfBuilder.AppendLine(SelectedCollectorHost.CurrentState.ReadAllRawDetails());
                    }
                    else
                    {
                        object selectedObject = tlvAgentStates.SelectedItems[0].Tag;
                        if (selectedObject == null)
                        {

                        }
                        else if (selectedObject is ICollector)
                        {

                        }
                        else if (selectedObject is ICollectorConfigEntry)
                        {

                        }
                        else if (selectedObject is ICollectorConfigSubEntry)
                        {

                        }
                        else if (selectedObject is MonitorState)
                        {
                            rtfBuilder.AppendLine(((MonitorState)selectedObject).RawDetails);
                        }
                        else if (selectedObject is string)
                        {
                            rtfBuilder.AppendLine(selectedObject.ToString());
                        }

                    }
                }

                rtxDetails.Rtf = rtfBuilder.ToString();
                rtxDetails.SelectionStart = 0;
                rtxDetails.SelectionLength = 0;
                rtxDetails.ScrollToCaret();

                updateAgentsDetailViewBusy = false;
            }
        }

        private void chkRAWDetails_CheckedChanged(object sender, EventArgs e)
        {
            collectorDetailSplitContainer.Panel2Collapsed = !chkRAWDetails.Checked;
            chkRAWDetails.Image = chkRAWDetails.Checked ? global::QuickMon.Properties.Resources._133 : global::QuickMon.Properties.Resources._131;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            OKButtonCheck();
        }

        private void OKButtonCheck()
        {
            cmdOK.Enabled = ValidateInput();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedCollectorHost.Name = txtName.Text;
            ((MainForm)ParentWindow).UpdateCollector(SelectedCollectorHost, true);
            StopEditMode();
        }

        private void cboTextType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (previousSelectedAlertTextIndex >= 0)
            {
                if (previousSelectedAlertTextIndex == 0)
                    editingCollectorHost.AlertHeaderText = txtNotesText.Text;
                else if (previousSelectedAlertTextIndex == 1)
                    editingCollectorHost.AlertFooterText = txtNotesText.Text;
                else if (previousSelectedAlertTextIndex == 2)
                    editingCollectorHost.ErrorAlertText = txtNotesText.Text;
                else if (previousSelectedAlertTextIndex == 3)
                    editingCollectorHost.WarningAlertText = txtNotesText.Text;
                else if (previousSelectedAlertTextIndex == 4)
                    editingCollectorHost.GoodAlertText = txtNotesText.Text;
            }

            if (cboTextType.SelectedIndex == 0)
                txtNotesText.Text = editingCollectorHost.AlertHeaderText;
            else if (cboTextType.SelectedIndex == 1)
                txtNotesText.Text = editingCollectorHost.AlertFooterText;
            else if (cboTextType.SelectedIndex == 2)
                txtNotesText.Text = editingCollectorHost.ErrorAlertText;
            else if (cboTextType.SelectedIndex == 3)
                txtNotesText.Text = editingCollectorHost.WarningAlertText;
            else if (cboTextType.SelectedIndex == 4)
                txtNotesText.Text = editingCollectorHost.GoodAlertText;
            lblNoteTextChangeIndicator.Text = "Alert Texts";
            cmdSetNoteText.Enabled = false;
            previousSelectedAlertTextIndex = cboTextType.SelectedIndex;
        }

        private void agentsSplitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cmdAgentsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdAgentsToggle, agentsEditSplitContainer, agentsEditSplitContainerHeight);
        }
        private void cmdHostsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdHostsToggle, hostSettingsSplitContainer, hostSettingsSplitContainerHeight);
        }
        private void cmdOperationalToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdOperationalToggle, operationalSplitContainer, operationalSplitContainerHeight);
        }
        private void cmdAlertsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdAlertsToggle, alertsSplitContainer, alertsSplitContainerHeight);
        }
        private void cmdConfigVarsToggle_Click(object sender, EventArgs e)
        {
            TogglePanel(cmdConfigVarsToggle, configVariSplitContainer, configVariSplitContainerHeight);
        }

        private void TogglePanel(Button toggleButton, SplitContainer togglePanel, int expandedheight)
        {
            if (togglePanel.Panel2Collapsed)
            {
                togglePanel.Panel2Collapsed = false;
                togglePanel.Height = expandedheight;
                toggleButton.Image = global::QuickMon.Properties.Resources.icon_contract16x16;
                splitContainer2.Panel1.ScrollControlIntoView(togglePanel);
            }
            else
            {
                togglePanel.Panel2Collapsed = true;
                togglePanel.Height = 25;
                toggleButton.Image = global::QuickMon.Properties.Resources.icon_expand16x16;
            }
        }
    }
}
