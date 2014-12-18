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

        public string SelectedConfig { get; set; }
        public MonitorPack HostingMonitorPack { get; set; }
        public List<string> KnownRemoteHosts { get; set; }

        private CollectorHost editingCollectorHost = new CollectorHost();

        public DialogResult ShowDialog(CollectorHost ch, MonitorPack hostingMonitorPack = null)
        {
            if (ch != null)
            {
                SelectedConfig = ch.ToXml();
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
                if (SelectedConfig != null && SelectedConfig.Length > 0 && SelectedConfig.StartsWith("<collectorHost", StringComparison.CurrentCultureIgnoreCase))
                {
                    editingCollectorHost = CollectorHost.FromXml(SelectedConfig, false);
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
                lvwEntries.AutoResizeColumnIndex = 2;
                lvwEntries.AutoResizeColumnEnabled = true;
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
                chkExpandOnStart.Checked = editingCollectorHost.ExpandOnStart;
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
                txtRemoteAgentServer.Text = editingCollectorHost.RemoteAgentHostAddress;
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
                    ((!chkRemoteAgentEnabled.Checked && !chkForceRemoteExcuteOnChildCollectors.Checked) || txtRemoteAgentServer.Text.Length > 0);
            cmdRemoteAgentTest.Enabled = chkRemoteAgentEnabled.Checked && txtRemoteAgentServer.Text.Length > 0;
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
            txtRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
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
        #endregion

        #region Agents
        private void LoadAgents()
        {
            lvwEntries.Items.Clear();
            if (editingCollectorHost.CollectorAgents != null)
            {
                foreach (ICollector agent in editingCollectorHost.CollectorAgents)
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
            editCollectorAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1;
            deleteCollectorAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
            moveUpAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index > 0;
            moveDownAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index < lvwEntries.Items.Count - 1;
            enableAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
            disableAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
        }
        private void addCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            //Display a list of existing types of agents/by template...
            //Once type is selected load edit agent with default settings
        }
        private void editCollectorAgentToolStripButton_Click(object sender, EventArgs e)
        {
            //Call local (in this assembly) utility that match editor type for agent class.
            //  This assembly will search through all assemblies in local directory for classes that inherits IWinFormsUI
            //  each IWinFormsUI class must provide the name of the IAgent class it can edit
            //  thus each IAgent class name must be unique...
            //  each IWinFormsUI class must have a method to edit the IAgent class.  EditAgent(xmlConfigString) 
            //If no default editor can be found show raw xml editor...

            if (lvwEntries.SelectedItems.Count == 1)
            {
                IAgent agent = (IAgent)lvwEntries.SelectedItems[0].Tag;
                IWinFormsUI agentEditor = RegisteredAgentUIMapper.GetUIClass(agent);
                if (agentEditor != null)
                {
                    agentEditor.SelectedConfig = agent.InitialConfiguration;
                    if (agentEditor.EditAgent())
                    {
                        agent.InitialConfiguration = agentEditor.SelectedConfig;
                        agent.AgentConfig.FromXml(agentEditor.SelectedConfig);
                    }
                }
                else
                {
                    MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
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
                ICollector agent = (ICollector)lvi.Tag;
                agent.Enabled = true;
            }
        }
        private void disableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            {
                lvi.ImageIndex = 0;
                ICollector agent = (ICollector)lvi.Tag;
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

            editingCollectorHost.Name = txtName.Text;
            editingCollectorHost.Enabled = chkEnabled.Checked;
            editingCollectorHost.ExpandOnStart = chkExpandOnStart.Checked;

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
            editingCollectorHost.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
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
            //Service windows - Done already            
            editingCollectorHost.ConfigVariables = new List<ConfigVariable>();
            foreach (ListViewItem lvi in lvwConfigVars.Items)
            {
                editingCollectorHost.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());  
            }
            editingCollectorHost.CollectorAgents.Clear();
            foreach (ListViewItem lvi in lvwEntries.Items)
            {
                editingCollectorHost.CollectorAgents.Add((ICollector)lvi.Tag);
            }

            SelectedConfig = editingCollectorHost.ToXml();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion



    }
}