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
    public partial class EditCollectorConfig : Form
    {
        private class CollectorEntryDisplay
        {
            public int Ident { get; set; }
            public CollectorEntry CE { get; set; }
            public override string ToString()
            {
                return new string(' ', Ident * 2) + CE.ToString();
            }
        }

        public EditCollectorConfig()
        {
            InitializeComponent();
        }

        #region Private
        private MonitorPack monitorPack;
        private CollectorEntry currentEditingEntry;
        #endregion

        #region Properties
        public CollectorEntry SelectedEntry { get; set; }
        public bool LaunchAddEntry { get; set; }
        public bool ShowRawEditOnStart { get; set; }
        public bool ShowSelectPresetOnStart { get; set; }
        public List<string> KnownRemoteHosts { get; set; } 
        #endregion

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {
            if (KnownRemoteHosts == null)
                KnownRemoteHosts = new List<string>();
            if (SelectedEntry == null)
            {
                return System.Windows.Forms.DialogResult.Cancel;
            }
            else
            {
                this.monitorPack = monitorPack;
                currentEditingEntry = CollectorEntry.FromConfig(SelectedEntry.ToConfig());
                try
                {
                    //Create Collector instance but do not apply Config Variables!
                    currentEditingEntry.CreateAndConfigureEntry(currentEditingEntry.CollectorRegistrationName, "", false, false);

                    ApplyConfigToControls();

                    txtName.Text = currentEditingEntry.Name;
                    chkEnabled.Checked = currentEditingEntry.Enabled;
                    chkExpandOnStart.Checked = currentEditingEntry.ExpandOnStart;
                    lblId.Text = currentEditingEntry.UniqueId;
                    llblCollectorType.Text = currentEditingEntry.CollectorRegistrationDisplayName;
                    chkRemoteAgentEnabled.Checked = currentEditingEntry.EnableRemoteExecute;
                    chkForceRemoteExcuteOnChildCollectors.Checked = currentEditingEntry.ForceRemoteExcuteOnChildCollectors;
                    txtRemoteAgentServer.Text = currentEditingEntry.RemoteAgentHostAddress;
                    remoteportNumericUpDown.SaveValueSet(currentEditingEntry.RemoteAgentHostPort);
                    chkBlockParentRHOverride.Checked = currentEditingEntry.BlockParentOverrideRemoteAgentHostSettings;
                    chkRunLocalOnRemoteHostConnectionFailure.Checked = currentEditingEntry.RunLocalOnRemoteHostConnectionFailure;

                    try
                    {
                        chkEnablePollingOverride.Checked = currentEditingEntry.EnabledPollingOverride;
                        onlyAllowUpdateOncePerXSecNumericUpDown.SaveValueSet(currentEditingEntry.OnlyAllowUpdateOncePerXSec);
                        chkEnablePollingFrequencySliding.Checked = currentEditingEntry.EnablePollFrequencySliding;
                        pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.SaveValueSet(currentEditingEntry.PollSlideFrequencyAfterThirdRepeatSec);
                        pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.SaveValueSet(currentEditingEntry.PollSlideFrequencyAfterSecondRepeatSec);
                        pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.SaveValueSet(currentEditingEntry.PollSlideFrequencyAfterFirstRepeatSec);
                    }
                    catch { }
                    PollingOverrideControlsEnable();

                    numericUpDownRepeatAlertInXMin.SaveValueSet(currentEditingEntry.RepeatAlertInXMin);
                    numericUpDownRepeatAlertInXPolls.SaveValueSet(currentEditingEntry.RepeatAlertInXPolls);
                    AlertOnceInXMinNumericUpDown.SaveValueSet(currentEditingEntry.AlertOnceInXMin);
                    AlertOnceInXPollsNumericUpDown.SaveValueSet(currentEditingEntry.AlertOnceInXPolls);
                    delayAlertSecNumericUpDown.SaveValueSet(currentEditingEntry.DelayErrWarnAlertForXSec);
                    delayAlertPollsNumericUpDown.SaveValueSet(currentEditingEntry.DelayErrWarnAlertForXPolls);

                    chkCollectOnParentWarning.Checked = currentEditingEntry.CollectOnParentWarning;

                    chkAlertsPaused.Checked = currentEditingEntry.AlertsPaused;
                    chkCorrectiveScriptDisabled.Checked = currentEditingEntry.CorrectiveScriptDisabled;
                    txtCorrectiveScriptOnWarning.Text = currentEditingEntry.CorrectiveScriptOnWarningPath;
                    txtCorrectiveScriptOnError.Text = currentEditingEntry.CorrectiveScriptOnErrorPath;
                    txtRestorationScript.Text = currentEditingEntry.RestorationScriptPath;
                    chkOnlyRunCorrectiveScriptsOnStateChange.Checked = currentEditingEntry.CorrectiveScriptsOnlyOnStateChange;
                    linkLabelServiceWindows.Text = currentEditingEntry.ServiceWindows.ToString();

                    LoadParentCollectorList();
                    CheckOkEnabled();
                    return ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return System.Windows.Forms.DialogResult.Cancel;
                }   
            }
        }

        #region Form events
        private void EditCollectorConfig_Load(object sender, EventArgs e)
        {
            lvwEntries.AutoResizeColumnIndex = 1;
            lvwEntries.AutoResizeColumnEnabled = true;
            //addPresetToolStripButton.Visible = false;
            if (ShowRawEditOnStart && SelectedEntry != null && SelectedEntry.InitialConfiguration != null)
            {
                llblRawEdit_LinkClicked(null, null);
            }
            else if (LaunchAddEntry && SelectedEntry != null && SelectedEntry.Collector != null && SelectedEntry.Collector.AgentConfig != null)
            {
                if (((ICollectorConfig)SelectedEntry.Collector.AgentConfig).Entries.Count == 0)
                    addCollectorConfigEntryToolStripButton_Click(null, null);
                else if (lvwEntries.Items.Count > 0)
                {
                    lvwEntries.Items[0].Selected = true;
                    editCollectorConfigEntryToolStripButton_Click(null, null);
                }
            }
            try
            {
                txtRemoteAgentServer.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                txtRemoteAgentServer.AutoCompleteCustomSource.AddRange((from string s in KnownRemoteHosts
                                                                        select s).ToArray());
            }
            catch { }
        }
        #endregion

        #region Private methods
        private void ApplyConfigToControls()
        {
            if (currentEditingEntry != null)
            {   
                if (currentEditingEntry.IsFolder)
                {
                    collectorEditToolStrip.Enabled = false;
                    lvwEntries.Enabled = false;
                    lvwEntries.Dock = DockStyle.Fill;
                    llblRawEdit.Enabled = false;
                    llblExportConfigAsTemplate.Enabled = false;
                    lvwEntries.Items.Clear();
                    tvwEntries.Visible = false;
                    llblEditConfigVars.Enabled = false;
                }
                else
                {
                    collectorEditToolStrip.Enabled = true;
                    addCollectorConfigEntryToolStripButton.Enabled = false;
                    addItemToolStripMenuItem.Enabled = false;
                    editCollectorConfigEntryToolStripButton.Enabled = false;
                    editItemToolStripMenuItem.Enabled = false;
                    deleteCollectorConfigEntryToolStripButton.Enabled = false;
                    deleteItemToolStripMenuItem.Enabled = false;

                    if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null && ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).ConfigEntryType == ConfigEntryType.Tree)
                    {
                        lvwEntries.Visible = false;                        
                        LoadCollectorEntriesTree();
                    }
                    else
                    {
                        tvwEntries.Visible = false;
                        lvwEntries.Enabled = !currentEditingEntry.IsFolder;
                        lvwEntries.Dock = DockStyle.Fill;
                        LoadCollectorEntriesList();
                    }
                    llblRawEdit.Enabled = true;
                    llblExportConfigAsTemplate.Enabled = true;
                    llblEditConfigVars.Enabled = true;
                }
                CheckOkEnabled();
            }
        }
        private void LoadParentCollectorList(CollectorEntry parentEntry = null, int indent = 0)
        {
            if (cboParentCollector.Items.Count == 0)
            {
                cboParentCollector.Items.Add("<None>");
                cboParentCollector.SelectedIndex = 0;
            }
            if (monitorPack != null)
            {
                foreach (CollectorEntry ce in (from c in monitorPack.Collectors
                                               where (parentEntry == null && (c.ParentCollectorId == null || c.ParentCollectorId == "")) ||
                                                   (parentEntry != null && parentEntry.UniqueId == c.ParentCollectorId)
                                               select c))
                {
                    CollectorEntryDisplay ceDisplay = new CollectorEntryDisplay() { Ident = indent, CE = ce };
                    if (IsNotInCurrentDependantTree(currentEditingEntry.UniqueId, ce))
                    {
                        cboParentCollector.Items.Add(ceDisplay);
                    }
                    if (ce.UniqueId == currentEditingEntry.ParentCollectorId)
                        cboParentCollector.SelectedItem = ceDisplay;

                    LoadParentCollectorList(ce, indent + 1);
                }
            }
        }
        private bool IsNotInCurrentDependantTree(string uniqueId, CollectorEntry ce)
        {
            if (monitorPack != null)
            {
                if (ce.UniqueId != uniqueId)
                {
                    if (ce.ParentCollectorId != null)
                    {
                        CollectorEntry parentCe = (from pce in monitorPack.Collectors
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
        private void LoadCollectorEntriesList()
        {
            lvwEntries.Items.Clear();
            if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
            {
                addCollectorConfigEntryToolStripButton.Enabled = ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).ConfigEntryType != ConfigEntryType.Single;
                addItemToolStripMenuItem.Enabled = ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).ConfigEntryType != ConfigEntryType.Single;
                foreach(ICollectorConfigEntry entry in  ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).Entries)
                {
                    ListViewItem lvi = new ListViewItem(entry.Description);
                    lvi.ImageIndex = 1;
                    lvi.SubItems.Add(entry.TriggerSummary);
                    lvi.Tag = entry;
                    lvwEntries.Items.Add(lvi);
                }
            }            
        }
        private void LoadCollectorEntriesTree()
        {
            tvwEntries.Nodes.Clear();
            addCollectorConfigEntryToolStripButton.Enabled = true;
            addItemToolStripMenuItem.Enabled = true;
            if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
            {
                foreach (ICollectorConfigEntry entry in ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).Entries)
                {
                    TreeNode tni = new TreeNode(entry.Description);
                    tni.ImageIndex = 0;
                    tni.SelectedImageIndex = 0;
                    tni.Tag = entry;
                    foreach(var subEntry in  entry.SubItems)
                    {
                        TreeNode tnisub = new TreeNode(subEntry.Description);
                        tnisub.ImageIndex = 1;
                        tnisub.SelectedImageIndex = 1;
                        tnisub.Tag = entry;
                        tni.Nodes.Add(tnisub);
                    }
                    tni.Expand();
                    tvwEntries.Nodes.Add(tni);
                }
            }
        }
        private void CheckOkEnabled()
        {
            bool collectorEntriesCheck = currentEditingEntry.IsFolder;
            if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
            {
                ICollectorConfig icc = (ICollectorConfig)currentEditingEntry.Collector.AgentConfig;
                collectorEntriesCheck = icc.Entries.Count > 0;
            }
            cmdOK.Enabled = collectorEntriesCheck && (txtName.Text.Length > 0) && cboParentCollector.SelectedIndex > -1 &&
                    ((!chkRemoteAgentEnabled.Checked && !chkForceRemoteExcuteOnChildCollectors.Checked) || txtRemoteAgentServer.Text.Length > 0);
            cmdRemoteAgentTest.Enabled = chkRemoteAgentEnabled.Checked && collectorEntriesCheck && txtRemoteAgentServer.Text.Length > 0;
        }
        #endregion

        #region List and Tree view events
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool editing = (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null) &&
                ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).CanEdit;
            bool isSingleEntry = (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null) &&
                    ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).ConfigEntryType != ConfigEntryType.Single;
            editCollectorConfigEntryToolStripButton.Enabled = editing && lvwEntries.SelectedItems.Count == 1;
            editItemToolStripMenuItem.Enabled = editing && lvwEntries.SelectedItems.Count == 1;
            deleteCollectorConfigEntryToolStripButton.Enabled = isSingleEntry && lvwEntries.SelectedItems.Count > 0;
            deleteItemToolStripMenuItem.Enabled = isSingleEntry && lvwEntries.SelectedItems.Count > 0;
        }
        private void tvwEntries_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool editing = (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null) &&
                    ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig).CanEdit;
            editCollectorConfigEntryToolStripButton.Enabled = editing && e.Node.ImageIndex > -1;
            editItemToolStripMenuItem.Enabled = editing && e.Node.ImageIndex > -1;
            deleteCollectorConfigEntryToolStripButton.Enabled = e.Node.ImageIndex > -1;
            deleteItemToolStripMenuItem.Enabled = e.Node.ImageIndex > -1;
        }
        private void lvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editCollectorConfigEntryToolStripButton_Click(sender, e);
        }
        private void tvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editCollectorConfigEntryToolStripButton_Click(sender, e);
        }
        private void lvwEntries_DeleteKeyPressed()
        {
            deleteCollectorConfigEntryToolStripButton_Click(null, null);
        }
        private void tvwEntries_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                deleteCollectorConfigEntryToolStripButton_Click(null, null);
        }
        private void lvwEntries_EnterKeyPressed()
        {
            editCollectorConfigEntryToolStripButton_Click(null,null);
        }
        #endregion

        #region Change tracking
        private void txtName_TextChanged(object sender, EventArgs e)
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
        private void chkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        #endregion

        #region Link label edits
        private void llblCollectorType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change the Collector type?\r\n\r\nIf you continue this will reset any existing configuration.", "Collector type", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                List<ConfigVariable> configVars = new List<ConfigVariable>();
                foreach (ConfigVariable cv in currentEditingEntry.ConfigVariables)
                    configVars.Add(cv.Clone());
                CollectorEntry newCollector = AgentHelper.CreateNewCollector((from c in monitorPack.Collectors
                                                                              where c.UniqueId == currentEditingEntry.ParentCollectorId
                                                                              select c).FirstOrDefault());
                if (newCollector != null)
                {
                    currentEditingEntry = null;
                    currentEditingEntry = newCollector;
                    currentEditingEntry.ConfigVariables = configVars;
                    llblCollectorType.Text = currentEditingEntry.CollectorRegistrationDisplayName;
                    ApplyConfigToControls();

                    if (AgentHelper.LastShowRawEditOnStartOption)
                        llblRawEdit_LinkClicked(sender, e);
                }
            }
        }
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (currentEditingEntry.InitialConfiguration != null)
                {
                    EditRAWMarkup editRaw = new EditRAWMarkup();
                    editRaw.SelectedMarkup = XmlFormattingUtils.NormalizeXML(currentEditingEntry.InitialConfiguration);
                    editRaw.AgentType = currentEditingEntry.CollectorRegistrationName;
                    editRaw.CurrentMonitorPack = monitorPack;
                    if (editRaw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        currentEditingEntry.CreateAndConfigureEntry(currentEditingEntry.CollectorRegistrationName, editRaw.SelectedMarkup, true, false);
                        ApplyConfigToControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error setting configuration\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            CheckOkEnabled();
        }
        private void llblExportConfigAsTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (currentEditingEntry != null && currentEditingEntry.Collector != null && txtName.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Are you sure you want to export the current config as a template?\r\nThe collector entry name will be used as name for the template.", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        AgentPresetConfig newPreset = new AgentPresetConfig();
                        newPreset.AgentClassName = currentEditingEntry.CollectorRegistrationName;
                        newPreset.Description = txtName.Text;
                        newPreset.Config = currentEditingEntry.InitialConfiguration;
                        List<AgentPresetConfig> allExistingPresets = AgentPresetConfig.GetAllPresets();

                        if ((from p in allExistingPresets
                             where p.AgentClassName == newPreset.AgentClassName && p.Description == newPreset.Description
                             select p).Count() > 0)
                        {
                            if (MessageBox.Show("A template with the name '" + newPreset.Description + "' already exist!\r\nDo you want to replace it?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                return;
                            }
                            else
                            {
                                AgentPresetConfig existingEntry = (from p in allExistingPresets
                                                                   where p.AgentClassName == newPreset.AgentClassName && p.Description == newPreset.Description
                                                                   select p).FirstOrDefault();
                                existingEntry.Config = newPreset.Config;
                            }
                        }
                        else
                            allExistingPresets.Add(newPreset);
                        AgentPresetConfig.SaveAllPresetsToFile(allExistingPresets);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void llblEditConfigVars_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (currentEditingEntry != null)
                {
                    EditConfigVariables editConfigVariables = new EditConfigVariables();
                    editConfigVariables.SelectedConfigVariables = currentEditingEntry.ConfigVariables;
                    if (editConfigVariables.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        currentEditingEntry.ConfigVariables = editConfigVariables.SelectedConfigVariables;
                    }                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void linkLabelServiceWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditServiceWindows editServiceWindows = new EditServiceWindows();
            editServiceWindows.SelectedServiceWindows = currentEditingEntry.ServiceWindows;
            if (editServiceWindows.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentEditingEntry.ServiceWindows = editServiceWindows.SelectedServiceWindows;
                linkLabelServiceWindows.Text = editServiceWindows.SelectedServiceWindows.ToString();
                toolTip1.SetToolTip(linkLabelServiceWindows, "Only operate within specified times. Return 'disabled' status otherwise\r\n" + currentEditingEntry.ServiceWindows.ToString());
                CheckOkEnabled();
            }
        } 
        #endregion

        #region Collector Config Entry editing
        private void addCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
            {
                ICollectorConfig currentConfig = (ICollectorConfig)currentEditingEntry.Collector.AgentConfig;
                ICollectorConfigEntry entry = null;
                if (SelectedEntry.ShowEditConfigEntry(ref entry))
                {
                    if (entry != null)  
                        currentConfig.Entries.Add(entry);
                    currentEditingEntry.InitialConfiguration = currentEditingEntry.Collector.AgentConfig.ToConfig();
                    ApplyConfigToControls();
                }
            }
        }
        //private void addPresetToolStripButton_Click(object sender, EventArgs e)
        //{
        //    if (currentEditingEntry != null && currentEditingEntry.Collector != null)
        //    {
        //        bool presetsAvailable = false;
        //        List<AgentPresetConfig> presets = null;
        //        try
        //        {
        //            presets = AgentPresetConfig.GetPresetsForClass(currentEditingEntry.Collector.GetType().Name);
        //            presetsAvailable = (presets != null && presets.Count > 0);
        //        }
        //        catch { }

        //        ICollectorConfig currentConfig = (ICollectorConfig)currentEditingEntry.Collector.AgentConfig;
        //        if (presetsAvailable && (currentConfig.Entries.Count == 0 ||  MessageBox.Show("Are you sure you want to replace existing configuration with a predefined config?", "Preset",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
        //        {
        //            AddFromCollectorPreset addFromCollectorPreset = new AddFromCollectorPreset();
        //            addFromCollectorPreset.AvailablePresets = presets;
        //            if (addFromCollectorPreset.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //            {
        //                if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
        //                {
        //                    txtName.Text = addFromCollectorPreset.SelectedPreset.Description;
        //                    currentEditingEntry.Name = addFromCollectorPreset.SelectedPreset.Description;
        //                    currentEditingEntry.Collector.AgentConfig.ReadConfiguration(MacroVariables.FormatVariables(addFromCollectorPreset.SelectedPreset.Config));
        //                    ApplyConfigToControls();
        //                }
        //            }
        //        }
        //    }
        //}
        private void editCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            ICollectorConfigEntry entry = null;
            if (lvwEntries.Visible && lvwEntries.SelectedItems.Count == 1)
                entry = (ICollectorConfigEntry)lvwEntries.SelectedItems[0].Tag;
            else if (tvwEntries.SelectedNode != null)
                entry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Tag;

            if (entry != null)
            {
                if (currentEditingEntry.ShowEditConfigEntry(ref entry))
                {
                    currentEditingEntry.InitialConfiguration = currentEditingEntry.Collector.AgentConfig.ToConfig();
                    ApplyConfigToControls();
                }
            }
        }
        private void deleteCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lvwEntries.Visible)
                {
                    foreach(int index in (from int i in lvwEntries.SelectedIndices
                                              orderby i descending
                                              select i))
                    {
                        ICollectorConfigEntry entry = (ICollectorConfigEntry)lvwEntries.Items[index].Tag;
                        ICollectorConfig cnf = ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig);
                        cnf.Entries.Remove(entry);
                        lvwEntries.Items.RemoveAt(index);
                    }
                }
                else
                {
                    ICollectorConfig cnf = ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig);
                    if (tvwEntries.SelectedNode.Nodes.Count > 0)
                    {
                        ICollectorConfigEntry entry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Tag;
                        cnf.Entries.Remove(entry);
                        tvwEntries.SelectedNode.Nodes.Clear();
                    }
                    else
                    {
                        ICollectorConfigEntry entry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Parent.Tag;
                        ICollectorConfigSubEntry subEntry = (from ent in entry.SubItems
                                                             where ent.Description == tvwEntries.SelectedNode.Text
                                                             select ent).FirstOrDefault();
                        if (subEntry != null)
                            entry.SubItems.Remove(subEntry);
                    }
                    tvwEntries.Nodes.Remove(tvwEntries.SelectedNode);
                }
                currentEditingEntry.InitialConfiguration = currentEditingEntry.Collector.AgentConfig.ToConfig();
                CheckOkEnabled(); 
            }
        } 
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new CollectorEntry();

            SelectedEntry.Name = txtName.Text;
            SelectedEntry.Enabled = chkEnabled.Checked;
            SelectedEntry.ExpandOnStart = chkExpandOnStart.Checked;
            SelectedEntry.IsFolder = currentEditingEntry.IsFolder;
            if (cboParentCollector.SelectedIndex > 0)
            {
                CollectorEntryDisplay ced = (CollectorEntryDisplay)cboParentCollector.SelectedItem;
                SelectedEntry.ParentCollectorId = ced.CE.UniqueId;
            }
            else
                SelectedEntry.ParentCollectorId = "";
            SelectedEntry.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !SelectedEntry.IsFolder;

            //Collector type
            SelectedEntry.CollectorRegistrationName = currentEditingEntry.CollectorRegistrationName;
            SelectedEntry.CollectorRegistrationDisplayName = currentEditingEntry.CollectorRegistrationDisplayName;
 
            //Remote agents
            SelectedEntry.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
            SelectedEntry.ForceRemoteExcuteOnChildCollectors = chkForceRemoteExcuteOnChildCollectors.Checked;
            SelectedEntry.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            SelectedEntry.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
            SelectedEntry.BlockParentOverrideRemoteAgentHostSettings = chkBlockParentRHOverride.Checked && !chkRemoteAgentEnabled.Checked;
            SelectedEntry.RunLocalOnRemoteHostConnectionFailure = chkRunLocalOnRemoteHostConnectionFailure.Checked;
            if (chkRemoteAgentEnabled.Checked && SelectedEntry.RemoteAgentHostAddress.Length > 0)
            {
                if (KnownRemoteHosts == null)
                    KnownRemoteHosts = new List<string>();
                if ((from string rh in KnownRemoteHosts
                         where rh.ToLower() == SelectedEntry.RemoteAgentHostAddress.ToLower() + ":" + SelectedEntry.RemoteAgentHostPort.ToString()
                         select rh).Count() == 0
                         )
                {
                    KnownRemoteHosts.Add(SelectedEntry.RemoteAgentHostAddress + ":" + SelectedEntry.RemoteAgentHostPort.ToString());
                }
            }

            //Polling overrides
            if (onlyAllowUpdateOncePerXSecNumericUpDown.Value >= pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value)
                pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = onlyAllowUpdateOncePerXSecNumericUpDown.Value + 1;
            if (pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value >= pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value)
                pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value = pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value + 1;
            if (pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value >= pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value)
                pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value = pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value + 1;

            SelectedEntry.EnabledPollingOverride = chkEnablePollingOverride.Checked;
            SelectedEntry.OnlyAllowUpdateOncePerXSec = (int)onlyAllowUpdateOncePerXSecNumericUpDown.Value;
            SelectedEntry.EnablePollFrequencySliding = chkEnablePollingFrequencySliding.Checked;
            SelectedEntry.PollSlideFrequencyAfterFirstRepeatSec = (int)pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value;
            SelectedEntry.PollSlideFrequencyAfterSecondRepeatSec = (int)pollSlideFrequencyAfterSecondRepeatSecNumericUpDown.Value;
            SelectedEntry.PollSlideFrequencyAfterThirdRepeatSec = (int)pollSlideFrequencyAfterThirdRepeatSecNumericUpDown.Value;

            //Alert suppresion
            SelectedEntry.AlertsPaused = chkAlertsPaused.Checked;
            SelectedEntry.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            SelectedEntry.RepeatAlertInXPolls = (int)numericUpDownRepeatAlertInXPolls.Value;
            SelectedEntry.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            SelectedEntry.AlertOnceInXPolls = (int)AlertOnceInXPollsNumericUpDown.Value;
            SelectedEntry.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            SelectedEntry.DelayErrWarnAlertForXPolls = (int)delayAlertPollsNumericUpDown.Value;
            //Corrective scripts
            SelectedEntry.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            SelectedEntry.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            SelectedEntry.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            SelectedEntry.RestorationScriptPath = txtRestorationScript.Text;
            SelectedEntry.CorrectiveScriptsOnlyOnStateChange = chkOnlyRunCorrectiveScriptsOnStateChange.Checked;
            //Service windows
            SelectedEntry.ServiceWindows.CreateFromConfig(currentEditingEntry.ServiceWindows.ToConfig());
            SelectedEntry.ConfigVariables = new List<ConfigVariable>();
            SelectedEntry.ConfigVariables.AddRange((from ConfigVariable cv in currentEditingEntry.ConfigVariables
                                                    select cv.Clone()).ToArray());

            if (SelectedEntry.IsFolder)
            {
                SelectedEntry.Collector = null;
            }
            else
            {
                SelectedEntry.InitialConfiguration = currentEditingEntry.InitialConfiguration;
                RegisteredAgent currentRA = null;
                currentRA = RegisteredAgentCache.GetRegisteredAgentByClassName("." + SelectedEntry.CollectorRegistrationName);                
                if (currentRA != null)
                {
                    try
                    {
                        SelectedEntry.CreateAndConfigureEntry(currentRA, monitorPack.ConfigVariables);
                    }
                    catch (Exception ex)
                    {
                        SelectedEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                        SelectedEntry.Enabled = false;
                        SelectedEntry.LastMonitorState.RawDetails = ex.Message;
                    }                
                }
                else
                {
                    SelectedEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                    SelectedEntry.Enabled = false;
                    SelectedEntry.LastMonitorState.RawDetails = string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", SelectedEntry.Name, SelectedEntry.CollectorRegistrationName);
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        } 
        #endregion

        #region Remote Agent
        private void txtRemoteAgentServer_Leave(object sender, EventArgs e)
        {
            if (txtRemoteAgentServer.Text.Contains(":"))
            {
                string computerName = txtRemoteAgentServer.Text.Substring(0, txtRemoteAgentServer.Text.IndexOf(":"));
                string portNo = txtRemoteAgentServer.Text.Substring(txtRemoteAgentServer.Text.IndexOf(":") + 1);
                if (portNo.IsNumber())
                {
                    txtRemoteAgentServer.Text = computerName;
                    remoteportNumericUpDown.Value = int.Parse(portNo);
                }
            }
            CheckOkEnabled();
        }
        private void cmdRemoteAgentTest_Click(object sender, EventArgs e)
        {
            CollectorEntry testCollector = new CollectorEntry();
            testCollector.UniqueId = lblId.Text;
            testCollector.Name = txtName.Text.Trim();
            testCollector.Enabled = chkEnabled.Checked;
            testCollector.IsFolder = currentEditingEntry.IsFolder;

            if (cboParentCollector.SelectedIndex > 0)
            {
                CollectorEntryDisplay ced = (CollectorEntryDisplay)cboParentCollector.SelectedItem;
                SelectedEntry.ParentCollectorId = ced.CE.UniqueId;
            }
            else
                SelectedEntry.ParentCollectorId = "";

            if (currentEditingEntry.IsFolder)
                testCollector.CollectorRegistrationName = "Folder";
            else
            {
                //Collector type
                testCollector.CollectorRegistrationName = currentEditingEntry.CollectorRegistrationName;
                testCollector.CollectorRegistrationDisplayName = currentEditingEntry.CollectorRegistrationDisplayName;

                testCollector.InitialConfiguration = currentEditingEntry.InitialConfiguration;
            }
            testCollector.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !currentEditingEntry.IsFolder;
            testCollector.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            testCollector.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            testCollector.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            testCollector.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            testCollector.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            testCollector.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            testCollector.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
            testCollector.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            testCollector.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
            testCollector.EnabledPollingOverride = false;

            try
            {
                MonitorState testState = CollectorEntryRelay.GetRemoteAgentState(testCollector);
                if (testState.State == CollectorState.Good)
                {
                    MessageBox.Show("Success", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(string.Format("State: {0}\r\nDetails: {1}", testState.State, testState.RawDetails), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        private void llblRemoteAgentInstallHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("To install the Remote Agent Host (Service) run the following command in 'Admin mode' on the remote computer:\r\n\r\n\t" +
                "QuickMonService.exe -install\r\n\r\nBy default the executable should be located in 'C:\\Program Files\\Hen IT\\QuickMon 3'", "Install Remote Agent host", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void onlyAllowUpdateOncePerXSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //if (onlyAllowUpdateOncePerXSecNumericUpDown.Value >= pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value)
            //    pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value = onlyAllowUpdateOncePerXSecNumericUpDown.Value + 1;
        }
        private void pollSlideFrequencyAfterFirstRepeatSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            //if (pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value <= onlyAllowUpdateOncePerXSecNumericUpDown.Value)
            //    onlyAllowUpdateOncePerXSecNumericUpDown.Value = pollSlideFrequencyAfterFirstRepeatSecNumericUpDown.Value - 1;
        }
        private void pollSlideFrequencyAfterSecondRepeatSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
        private void pollSlideFrequencyAfterThirdRepeatSecNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
