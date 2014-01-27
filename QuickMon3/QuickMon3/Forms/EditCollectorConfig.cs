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

        public CollectorEntry SelectedEntry { get; set; }
        public bool LaunchAddEntry { get; set; }

        public DialogResult ShowDialog(MonitorPack monitorPack)
        {            
            if (SelectedEntry != null)
            {
                this.monitorPack = monitorPack;
                currentEditingEntry = CollectorEntry.FromConfig(SelectedEntry.ToConfig());
                if (monitorPack != null && currentEditingEntry != null)
                    monitorPack.ApplyCollectorConfig(currentEditingEntry);
                ApplyConfig();

                txtName.Text = currentEditingEntry.Name;
                chkEnabled.Checked = currentEditingEntry.Enabled;
                lblId.Text = currentEditingEntry.UniqueId;
                llblCollectorType.Text = currentEditingEntry.CollectorRegistrationDisplayName;
                chkRemoteAgentEnabled.Checked = currentEditingEntry.EnableRemoteExecute;
                txtRemoteAgentServer.Text = currentEditingEntry.RemoteAgentHostAddress;
                remoteportNumericUpDown.Value = currentEditingEntry.RemoteAgentHostPort;

                numericUpDownRepeatAlertInXMin.Value = currentEditingEntry.RepeatAlertInXMin;
                AlertOnceInXMinNumericUpDown.Value = currentEditingEntry.AlertOnceInXMin;
                delayAlertSecNumericUpDown.Value = currentEditingEntry.DelayErrWarnAlertForXSec;

                chkCollectOnParentWarning.Checked = currentEditingEntry.CollectOnParentWarning;

                chkCorrectiveScriptDisabled.Checked = currentEditingEntry.CorrectiveScriptDisabled;
                txtCorrectiveScriptOnWarning.Text = currentEditingEntry.CorrectiveScriptOnWarningPath;
                txtCorrectiveScriptOnError.Text = currentEditingEntry.CorrectiveScriptOnErrorPath;
                linkLabelServiceWindows.Text = currentEditingEntry.ServiceWindows.ToString();                 
                
                LoadParentCollectorList();
                CheckOkEnabled();
                return ShowDialog();
            }
            else
                return System.Windows.Forms.DialogResult.Cancel;
        }

        #region Form events
        private void EditCollectorConfig_Load(object sender, EventArgs e)
        {
            lvwEntries.AutoResizeColumnIndex = 1;
            lvwEntries.AutoResizeColumnEnabled = true;
            if (LaunchAddEntry && SelectedEntry != null && SelectedEntry.Collector != null && SelectedEntry.Collector.AgentConfig != null)
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
                txtRemoteAgentServer.AutoCompleteCustomSource.AddRange((from string s in Properties.Settings.Default.KnownRemoteHosts
                                                                        select s).ToArray());
            }
            catch { }
        }
        #endregion

        #region Private methods
        private void ApplyConfig()
        {
            if (currentEditingEntry != null)
            {   
                if (currentEditingEntry.IsFolder)
                {
                    collectorEditToolStrip.Enabled = false;
                    lvwEntries.Enabled = false;
                    lvwEntries.Dock = DockStyle.Fill;
                    llblRawEdit.Enabled = false;
                    lvwEntries.Items.Clear();
                    tvwEntries.Visible = false;
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
            cmdOK.Enabled = collectorEntriesCheck && (txtName.Text.Length > 0) && cboParentCollector.SelectedIndex > -1;

            cmdRemoteAgentTest.Enabled = chkRemoteAgentEnabled.Checked && collectorEntriesCheck;
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
            txtRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked;
            remoteportNumericUpDown.Enabled = chkRemoteAgentEnabled.Checked;
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
                AgentTypeSelect agentTypeSelect = new AgentTypeSelect();
                if (agentTypeSelect.ShowCollectorSelection(currentEditingEntry.CollectorRegistrationName) == System.Windows.Forms.DialogResult.OK)
                {
                    RegisteredAgent ar = agentTypeSelect.SelectedAgent;
                    currentEditingEntry.CollectorRegistrationDisplayName = ar.DisplayName;
                    currentEditingEntry.CollectorRegistrationName = ar.Name;
                    currentEditingEntry.IsFolder = ar.Name == "Folder";
                    llblCollectorType.Text = currentEditingEntry.CollectorRegistrationDisplayName;

                    ApplyConfig();
                }

            }
        }
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (currentEditingEntry.Collector != null && currentEditingEntry.Collector.AgentConfig != null)
                {
                    EditRAWMarkup editRaw = new EditRAWMarkup();
                    editRaw.SelectedMarkup = XmlFormattingUtils.NormalizeXML(currentEditingEntry.Collector.AgentConfig.ToConfig());
                    editRaw.AgentType = currentEditingEntry.CollectorRegistrationName;
                    editRaw.CurrentMonitorPack = monitorPack;
                    if (editRaw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        currentEditingEntry.Collector.SetConfigurationFromXmlString(editRaw.SelectedMarkup);
                        ApplyConfig();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error setting configuration\r\n{0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            CheckOkEnabled();
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
                    ApplyConfig();
                }
            }
        }
        private void editCollectorConfigEntryToolStripButton_Click(object sender, EventArgs e)
        {
            ICollectorConfigEntry entry = null;
            if (lvwEntries.Visible && lvwEntries.SelectedItems.Count == 1)
                entry = (ICollectorConfigEntry)lvwEntries.SelectedItems[0].Tag;
            else if (tvwEntries.SelectedNode != null)
                entry = (ICollectorConfigEntry)tvwEntries.SelectedNode.Tag;

            //ICollectorConfig cc = (ICollectorConfig)currentEditingEntry.Collector.AgentConfig;
            //ICollectorConfigEntry entry2 = (from ce in cc.Entries
            //         where ce.Description == entry.Description && ce.TriggerSummary == entry.TriggerSummary
            //         select ce).FirstOrDefault();

            if (entry != null)
            {
                if (SelectedEntry.ShowEditConfigEntry(ref entry))
                {
                    //entry2 = entry;
                    //currentEditingEntry.Collector.AgentConfig = cc;

                    //ICollectorConfig cnf = ((ICollectorConfig)currentEditingEntry.Collector.AgentConfig);
                    //cnf.ReadConfiguration(cnf.ToConfig());
                    ApplyConfig();
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
                        ICollectorConfigSubEntry subEntry = (from ent in entry.SubItems //   (ICollectorConfigSubEntry)tvwEntries.SelectedNode.Tag;
                                                             where ent.Description == tvwEntries.SelectedNode.Text
                                                             select ent).FirstOrDefault();
                        if (subEntry != null)
                            entry.SubItems.Remove(subEntry);
                    }
                    tvwEntries.Nodes.Remove(tvwEntries.SelectedNode);
                }
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
            SelectedEntry.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            SelectedEntry.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
            if (SelectedEntry.RemoteAgentHostAddress.Length > 0)
            {
                if ((from string rh in Properties.Settings.Default.KnownRemoteHosts
                         where rh.ToLower() == SelectedEntry.RemoteAgentHostAddress.ToLower() + ":" + SelectedEntry.RemoteAgentHostPort.ToString()
                         select rh).Count() == 0
                         )
                {
                    Properties.Settings.Default.KnownRemoteHosts.Add(SelectedEntry.RemoteAgentHostAddress + ":" + SelectedEntry.RemoteAgentHostPort.ToString());
                }
            }

            //Alert suppresion
            SelectedEntry.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            SelectedEntry.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            SelectedEntry.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            //Corrective scripts
            SelectedEntry.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            SelectedEntry.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            SelectedEntry.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            //Service windows
            SelectedEntry.ServiceWindows.CreateFromConfig(currentEditingEntry.ServiceWindows.ToConfig());

            if (SelectedEntry.IsFolder)
            {
                SelectedEntry.Collector = null;
            }
            else
            {
                SelectedEntry.InitialConfiguration = currentEditingEntry.Collector.AgentConfig.ToConfig();
                RegisteredAgent currentRA = null;
                currentRA = (from r in RegisteredAgentCache.Agents
                             where r.IsCollector && r.ClassName.EndsWith("." + SelectedEntry.CollectorRegistrationName)
                             select r).FirstOrDefault();
                if (currentRA != null)
                {
                    try
                    {
                        SelectedEntry.Collector = CollectorEntry.CreateCollectorEntry(currentRA);
                        SelectedEntry.Collector.SetConfigurationFromXmlString(SelectedEntry.InitialConfiguration);
                        SelectedEntry.CollectorRegistrationDisplayName = currentRA.DisplayName;
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
        }
        private void cmdRemoteAgentTest_Click(object sender, EventArgs e)
        {
            CollectorEntry textCollector = new CollectorEntry();
            textCollector.UniqueId = lblId.Text;
            textCollector.Name = txtName.Text.Trim();
            textCollector.Enabled = chkEnabled.Checked;
            textCollector.IsFolder = currentEditingEntry.IsFolder;

            if (cboParentCollector.SelectedIndex > 0)
            {
                CollectorEntryDisplay ced = (CollectorEntryDisplay)cboParentCollector.SelectedItem;
                SelectedEntry.ParentCollectorId = ced.CE.UniqueId;
            }
            else
                SelectedEntry.ParentCollectorId = "";

            if (currentEditingEntry.IsFolder)
                textCollector.CollectorRegistrationName = "Folder";
            else
            {
                //Collector type
                textCollector.CollectorRegistrationName = currentEditingEntry.CollectorRegistrationName;
                textCollector.CollectorRegistrationDisplayName = currentEditingEntry.CollectorRegistrationDisplayName;

                textCollector.InitialConfiguration = currentEditingEntry.Collector.AgentConfig.ToConfig();
            }
            textCollector.CollectOnParentWarning = chkCollectOnParentWarning.Checked && !currentEditingEntry.IsFolder;
            textCollector.RepeatAlertInXMin = (int)numericUpDownRepeatAlertInXMin.Value;
            textCollector.AlertOnceInXMin = (int)AlertOnceInXMinNumericUpDown.Value;
            textCollector.DelayErrWarnAlertForXSec = (int)delayAlertSecNumericUpDown.Value;
            textCollector.CorrectiveScriptDisabled = chkCorrectiveScriptDisabled.Checked;
            textCollector.CorrectiveScriptOnWarningPath = txtCorrectiveScriptOnWarning.Text;
            textCollector.CorrectiveScriptOnErrorPath = txtCorrectiveScriptOnError.Text;
            textCollector.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
            textCollector.RemoteAgentHostAddress = txtRemoteAgentServer.Text;
            textCollector.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;

            try
            {
                MonitorState testState = CollectorEntryRelay.GetRemoteAgentState(textCollector);
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
        #endregion

        #region Corrective scripts
        private void chkCorrectiveScriptDisabled_CheckedChanged(object sender, EventArgs e)
        {
            txtCorrectiveScriptOnWarning.Enabled = !chkCorrectiveScriptDisabled.Checked;
            txtCorrectiveScriptOnError.Enabled = !chkCorrectiveScriptDisabled.Checked;
            cmdBrowseForWarningCorrectiveScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
            cmdBrowseForErrorCorrectiveScript.Enabled = !chkCorrectiveScriptDisabled.Checked;
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
        #endregion

    }
}
