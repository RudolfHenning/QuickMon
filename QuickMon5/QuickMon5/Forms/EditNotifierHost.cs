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

namespace QuickMon.UI
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

        public string Identifier
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IParentWindow ParentWindow
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool AutoRefreshEnabled
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        private NotifierHost editingNotifierHost = new NotifierHost();
        private int collectorImgIndex = 1;
        //private int folderImgIndex = 0;
        private string indentationChars = "  ";
        private bool selfCheckingOn = false;
        //private bool loading = false;

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
                llblRawEdit.Visible = Properties.Settings.Default.EnableRawEditing;
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
                cboAlertLevel.SelectedIndex = (int)editingNotifierHost.AlertLevel;
                cboDetailLevel.SelectedIndex = (int)editingNotifierHost.DetailLevel;
                cboAttendedOptionOverride.SelectedIndex = (int)editingNotifierHost.AttendedOptionOverride;

                txtOnlyRecordAlertOnHosts.Text = "";
                if (editingNotifierHost.OnlyRecordAlertOnHosts != null)
                {
                    foreach (string host in editingNotifierHost.OnlyRecordAlertOnHosts)
                        txtOnlyRecordAlertOnHosts.Text += host + "\r\n";
                }

                if (editingNotifierHost.ServiceWindows != null)
                    linkLabelServiceWindows.Text = editingNotifierHost.ServiceWindows.ToString();
                else
                    linkLabelServiceWindows.Text = "None";

                StringBuilder categories = new StringBuilder();
                if (editingNotifierHost.Categories != null && editingNotifierHost.Categories.Count > 0)
                {
                    foreach (string category in editingNotifierHost.Categories)
                    {
                        categories.AppendLine(category);
                    }
                    txtCategories.Text = categories.ToString();
                }
                if (txtCategories.Text == "")
                    txtCategories.Text = "*";

                LoadConfigVars();
                LoadAgents();
                LoadCollectorList();
                CheckOkEnabled();
            }
        }

        private void LoadCollectorList()
        {
            //loading = true;
            TreeNode root = tvwCollectors.Nodes[0];
            root.Nodes.Clear();
            if (HostingMonitorPack != null)
            {
                try
                {
                    txtMonitorPack.Text = string.Format("{0} ({1})", HostingMonitorPack.Name, HostingMonitorPack.MonitorPackPath);
                    tvwCollectors.BeginUpdate();
                    List<CollectorHost> noDependantCollectors = (from c in HostingMonitorPack.CollectorHosts
                                                                  where c.ParentCollectorId.Length == 0
                                                                  select c).ToList();
                    foreach (CollectorHost col in noDependantCollectors)
                    {
                        TreeNode tnode = new TreeNode(col.Name);
                        tnode.Tag = col;
                        if (editingNotifierHost.AlertForCollectors.Contains(col.Name))
                            tnode.Checked = true;

                        //if (col.CollectorAgents.Count() == 0)
                        //    tnode.ImageIndex = folderImgIndex;
                        //else
                            tnode.ImageIndex = collectorImgIndex;
                        root.Nodes.Add(tnode);
                        LoadCollectors(tnode, col, indentationChars);
                    }
                    if (editingNotifierHost.AlertForCollectors != null && editingNotifierHost.AlertForCollectors.Count == 0)
                        allLinkLabel_LinkClicked(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    tvwCollectors.EndUpdate();
                    root.ExpandAll();
                }
            }
            //loading = false;
        }
        private void LoadCollectors(TreeNode parent, CollectorHost collector, string indentation)
        {
            foreach (CollectorHost childCollector in (from c in HostingMonitorPack.CollectorHosts
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                TreeNode tnode = new TreeNode(indentation + childCollector.Name);
                tnode.Tag = childCollector;
                if (editingNotifierHost.AlertForCollectors.Contains(childCollector.Name))
                    tnode.Checked = true;
                //if (childCollector.CollectorAgents.Count() == 0)
                //    lvi.ImageIndex = folderImgIndex;
                //else
                tnode.ImageIndex = collectorImgIndex;
                parent.Nodes.Add(tnode);
                LoadCollectors(tnode, childCollector, indentation + indentationChars);
            }
        }
        private void CheckOkEnabled()
        {
            bool isEnable = true;
            if (txtName.Text.Length == 0 || lvwEntries.Items.Count == 0)
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
        private void NewAgent()
        {
            //Display a list of existing types of agents/by template...
            //Once type is selected load edit agent with default settings
            //CollectorHost.GetCollectorAgentFromString()
            try
            {
                SelectNewEntityType newType = new SelectNewEntityType();
                if (newType.ShowNotifierAgentSelection() == DialogResult.OK)
                {
                    IAgent agent = newType.SelectedAgent;
                    if (agent != null)
                    {
                        agent.Enabled = true;
                        if (agent.Name == null || agent.Name.Trim().Length == 0)
                            agent.Name = agent.AgentClassDisplayName;

                        ListViewItem lvi = new ListViewItem(agent.Name);
                        if (agent.Enabled)
                            lvi.ImageIndex = 1;
                        else
                            lvi.ImageIndex = 0;
                        lvi.SubItems.Add(agent.AgentClassDisplayName);
                        lvi.SubItems.Add(agent.AgentConfig.ConfigSummary);
                        lvi.Tag = agent;
                        lvwEntries.Items.Add(lvi);
                        lvwEntries.SelectedItems.Clear();
                        lvi.Selected = true;
                        EditAgent();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckOkEnabled();
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
                if (lvwEntries.SelectedItems.Count == 1)
                {
                    INotifier agent = (INotifier)lvwEntries.SelectedItems[0].Tag;
                    WinFormsUINotifierBase agentEditor = (WinFormsUINotifierBase)RegisteredAgentUIMapper.GetUIClass(agent);
                    if (agentEditor != null)
                    {
                        IAgentConfigEntryEditWindow detailEditor = agentEditor.DetailEditor;
                        detailEditor.SelectedEntry = agent.AgentConfig;
                        if (detailEditor.ShowEditEntry() == QuickMonDialogResult.Ok)
                        {
                            agent.AgentConfig = detailEditor.SelectedEntry;                            
                            lvwEntries.SelectedItems[0].Tag = agent; ;
                            lvwEntries.SelectedItems[0].SubItems[2].Text = detailEditor.SelectedEntry.ConfigSummary;
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
            CheckOkEnabled();
        }
        private void EnableAgents()
        {
            foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            {
                lvi.ImageIndex = 1;
                INotifier agent = (INotifier)lvi.Tag;
                agent.Enabled = true;
            }
        }
        private void DisableAgents()
        {
            foreach (ListViewItem lvi in lvwEntries.SelectedItems)
            {
                lvi.ImageIndex = 0;
                INotifier agent = (INotifier)lvi.Tag;
                agent.Enabled = false;
            }
        }
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            editAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1;
            editToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1;
            deleteAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count > 0;
            deleteToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count > 0;
            moveUpAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index > 0;
            moveUpToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index > 0;
            moveDownAgentToolStripButton.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index < lvwEntries.Items.Count - 1;
            moveDownToolStripMenuItem.Enabled = lvwEntries.SelectedItems.Count == 1 && lvwEntries.SelectedItems[0].Index < lvwEntries.Items.Count - 1;            

            bool agentEnabledEnabled = false;
            bool agentEDisabledEnabled = false;
            if (lvwEntries.SelectedItems.Count == 1)
            {
                ListViewItem lvi = lvwEntries.SelectedItems[0];
                if (lvi.Tag is INotifier )
                {
                    INotifier agent = (INotifier)lvi.Tag;
                    agentEnabledEnabled = !agent.Enabled;
                    agentEDisabledEnabled = agent.Enabled;
                }
            }
            else
            {
                foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                {
                    if (lvi.Tag is INotifier)
                    {
                        INotifier agent = (INotifier)lvi.Tag;
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
            enableAgentToolStripButton.Enabled = agentEnabledEnabled;
            disableAgentToolStripButton.Enabled = agentEDisabledEnabled;
            enableToolStripMenuItem.Enabled = agentEnabledEnabled || agentEDisabledEnabled;
            this.enableToolStripMenuItem.Image = agentEnabledEnabled ? global::QuickMon.Properties.Resources._246_7 : global::QuickMon.Properties.Resources.NoGo;
            this.enableToolStripMenuItem.Text = agentEnabledEnabled ? "Enable" : "Disable";
        }
        private void lvwEntries_DoubleClick(object sender, EventArgs e)
        {
            editAgentToolStripButton_Click(null, null);
        }
        private void lvwEntries_EnterKeyPressed()
        {
            editAgentToolStripButton_Click(null, null);
        }
        private void lvwEntries_DeleteKeyPressed()
        {
            deleteAgentToolStripButton_Click(null, null);
        }
        private void addAgentToolStripButton_Click(object sender, EventArgs e)
        {
            NewAgent();

            ////Display a list of existing types of agents/by template...
            ////Once type is selected load edit agent with default settings
            ////CollectorHost.GetCollectorAgentFromString()
            //SelectNewAgentType selectNewAgentType = new SelectNewAgentType();
            //if (selectNewAgentType.ShowNotifierSelection() == System.Windows.Forms.DialogResult.OK)
            //{
            //    INotifier agent = (INotifier)selectNewAgentType.SelectedAgent;
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

            //            ListViewItem lvi = new ListViewItem(agent.Name);
            //            if (agent.Enabled)
            //                lvi.ImageIndex = 1;
            //            else
            //                lvi.ImageIndex = 0;
            //            lvi.SubItems.Add(agent.AgentClassDisplayName);
            //            lvi.SubItems.Add(agent.AgentConfig.ConfigSummary);
            //            lvi.Tag = agent;
            //            lvwEntries.Items.Add(lvi);
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("There is no registered UI editor for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
            //CheckOkEnabled();
        }
        private void editAgentToolStripButton_Click(object sender, EventArgs e)
        {
            EditAgent();
        }
        private void deleteAgentToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the seleted entry(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                        lvwEntries.Items.Remove(lvi);
                }
                CheckOkEnabled();
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
            EnableAgents();
        }
        private void disableAgentToolStripButton_Click(object sender, EventArgs e)
        {
            DisableAgents();
        }
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwEntries.SelectedItems.Count > 0)
            {
                ListViewItem tlvi = lvwEntries.SelectedItems[0];
                if (tlvi.Tag is INotifier)
                {
                    INotifier agent = (INotifier)tlvi.Tag;
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

        #region Notifier Collectors
        private void allLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selfCheckingOn = true;
            TreeNode root = tvwCollectors.Nodes[0];
            root.Checked = false;

            tvwCollectors.CheckBoxEnhancements = true;
            root.Checked = true;
            tvwCollectors.CheckBoxEnhancements = false;
            selfCheckingOn = false;
        }
        private void tvwCollectors_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!selfCheckingOn && e.Node == tvwCollectors.Nodes[0] && tvwCollectors.Nodes[0].Checked)
            {
                selfCheckingOn = true;
                TreeNode root = tvwCollectors.Nodes[0];
                bool rootChecked = root.Checked;
                root.Checked = !rootChecked;
                tvwCollectors.CheckBoxEnhancements = true;
                root.Checked = rootChecked;
                tvwCollectors.CheckBoxEnhancements = false;
                selfCheckingOn = false;
            }
        }         
        #endregion

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetEditingNotifierHost())
                {
                    SelectedConfig = editingNotifierHost.ToXml();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool SetEditingNotifierHost()
        {
            bool success = false;
            try
            {
                editingNotifierHost.Name = txtName.Text;
                editingNotifierHost.Enabled = chkEnabled.Checked;
                editingNotifierHost.AlertLevel = (AlertLevel)cboAlertLevel.SelectedIndex;
                editingNotifierHost.DetailLevel = (DetailLevel)cboDetailLevel.SelectedIndex;
                editingNotifierHost.AttendedOptionOverride = (AttendedOption)cboAttendedOptionOverride.SelectedIndex;

                editingNotifierHost.OnlyRecordAlertOnHosts = new List<string>();
                foreach (string host in txtOnlyRecordAlertOnHosts.Lines)
                {
                    if (host.Trim().Length > 0)
                        editingNotifierHost.OnlyRecordAlertOnHosts.Add(host);
                }               

                //Service windows - Done already            
                editingNotifierHost.ConfigVariables = new List<ConfigVariable>();
                foreach (ListViewItem lvi in lvwConfigVars.Items)
                {
                    editingNotifierHost.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());
                }

                editingNotifierHost.NotifierAgents.Clear();
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    INotifier agent = (INotifier)lvi.Tag;
                    agent.Name = lvi.Text;
                    editingNotifierHost.NotifierAgents.Add(agent);
                }
                editingNotifierHost.AlertForCollectors.Clear();
                if (!tvwCollectors.Nodes[0].Checked)
                {
                    SetAlertForCollectors(editingNotifierHost);
                }
                //Categories
                editingNotifierHost.Categories = new List<string>();
                if (txtCategories.Text.Length > 0)
                {
                    foreach (string line in txtCategories.Lines)
                    {
                        if (line.Length > 0)
                        {
                            editingNotifierHost.Categories.Add(line);
                        }
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return success;
        }
        private void SetAlertForCollectors(NotifierHost editingNotifierHost, TreeNode parent = null)
        {
            if (parent == null)
                parent = tvwCollectors.Nodes[0];
            foreach(TreeNode child in parent.Nodes)
            {
                if (child.Checked && child.Tag is CollectorHost)
                {
                    CollectorHost ch = (CollectorHost)child.Tag;
                    editingNotifierHost.AlertForCollectors.Add(ch.Name);
                }
                SetAlertForCollectors(editingNotifierHost, child);
            }
        }
        #endregion

        #region Raw editing of config
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SetEditingNotifierHost())
            {

                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = editingNotifierHost.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        editingNotifierHost = NotifierHost.FromXml(editor.SelectedMarkup, null, false);

                        if (editor.SelectedMarkup == null || editor.SelectedMarkup.Length == 0)
                        {
                            if (MessageBox.Show("Editing the raw config resulted in a configuration error!\r\nDo you want to accept this?", "Configuration error", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.No)
                            {
                                editingNotifierHost = NotifierHost.FromXml(oldMarkUp, null, false);
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

        #region Service Windows
        private void linkLabelServiceWindows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditServiceWindows editServiceWindows = new EditServiceWindows();
            editServiceWindows.SelectedServiceWindows = editingNotifierHost.ServiceWindows;
            if (editServiceWindows.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                editingNotifierHost.ServiceWindows = editServiceWindows.SelectedServiceWindows;
                linkLabelServiceWindows.Text = editServiceWindows.SelectedServiceWindows.ToString();
                toolTip1.SetToolTip(linkLabelServiceWindows, "Only operate within specified times. Return 'disabled' status otherwise\r\n" + editingNotifierHost.ServiceWindows.ToString());
                CheckOkEnabled();
            }
        }
        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }


    }
}
