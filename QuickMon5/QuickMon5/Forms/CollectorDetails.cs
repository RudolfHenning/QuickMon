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
        public CollectorDetails()
        {
            InitializeComponent();
        }

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

        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public CollectorHost SelectedCollectorHost { get; set; }
        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        public IParentWindow ParentWindow { get; set; }

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
            tvwAgentStates.BorderStyle = BorderStyle.None;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion

        private void CollectorDetails_Load(object sender, EventArgs e)
        {
            tlvAgentStates.AutoResizeColumnEnabled = true;
            agentStateSplitContainer.Panel2Collapsed = true;

            if (SelectedCollectorHost == null)
                SelectedCollectorHost = new CollectorHost();
            RefreshDetails();
            splitContainerMain.Panel2Collapsed = true;
            SetActivePanel(panelAgentStates);
            UpdateStatusBar();
        }
        private void CollectorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseChildWindow();
        }

        private void cmdActionScriptsVisible_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }

        private void cmdCollectorEdit_Click(object sender, EventArgs e)
        {
            StartEditMode();
        }

        private void StartEditMode()
        {
            optAgentStates.Enabled = false;
            optMetrics.Enabled = false;
            optHistory.Enabled = false;
            txtName.ReadOnly = false;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            SetActivePanel(panelEditing);
        }
        private void StopEditMode()
        {
            optAgentStates.Enabled = true;
            optMetrics.Enabled = true;
            optHistory.Enabled = true;
            txtName.ReadOnly = true;
            txtName.BorderStyle = BorderStyle.None;
            if (optAgentStates.Checked)
                optAgentStates_CheckedChanged(null, null);
            else if (optMetrics.Checked)
                optMetrics_CheckedChanged(null, null);
            else
                optHistory_CheckedChanged(null, null);
        }

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

        private void optMetrics_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelMetrics);
        }

        private void optHistory_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelHistory);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            StopEditMode();
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
        }

        private void CollectorDetails_Shown(object sender, EventArgs e)
        {
            
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

            tvwAgentStates.Nodes.Clear();

            if (SelectedCollectorHost.CurrentState == null || SelectedCollectorHost.CurrentState.State == CollectorState.UpdateInProgress || SelectedCollectorHost.CurrentState.State == CollectorState.NotAvailable)
            {
                foreach (ICollector agent in SelectedCollectorHost.CollectorAgents)
                {
                    TreeNodeEx agentNode = new TreeNodeEx(agent.Name, collectorNAstateImage, collectorNAstateImage);
                    agentNode.DisplayValue = "";
                    tvwAgentStates.Nodes.Add(agentNode);
                    foreach (ICollectorConfigEntry entry in ((ICollectorConfig)agent.AgentConfig).Entries)
                    {
                        TreeNodeEx entryNode = new TreeNodeEx(entry.Description, collectorNAstateImage, collectorNAstateImage);
                        entryNode.DisplayValue = "";
                        agentNode.Nodes.Add(entryNode);
                        if (entry.SubItems != null)
                        {
                            foreach (ICollectorConfigSubEntry subEntry in entry.SubItems)
                            {
                                TreeNodeEx subEntryNode = new TreeNodeEx(subEntry.Description, collectorNAstateImage, collectorNAstateImage);
                                subEntryNode.DisplayValue = "";
                                entryNode.Nodes.Add(subEntryNode);
                            }
                        }
                    }
                    agentNode.ExpandAll();
                }
            }
            else
            {
                foreach (MonitorState agentState in SelectedCollectorHost.CurrentState.ChildStates)
                {
                    int agentNodeStateIndex = GetNodeStateImageIndex(agentState.State);
                    TreeNodeEx agentNode = new TreeNodeEx(agentState.ForAgent, agentNodeStateIndex, agentNodeStateIndex);
                    agentNode.DisplayValue = agentState.FormatValue();
                    agentNode.Tag = agentState;
                    tvwAgentStates.Nodes.Add(agentNode);
                    foreach (MonitorState entryState in agentState.ChildStates)
                    {
                        int entryNodeStateIndex = GetNodeStateImageIndex(entryState.State);
                        TreeNodeEx entryNode = new TreeNodeEx(entryState.ForAgent, entryNodeStateIndex, entryNodeStateIndex);
                        entryNode.DisplayValue = entryState.FormatValue();
                        entryNode.Tag = entryNode;
                        agentNode.Nodes.Add(entryNode);
                        foreach (MonitorState subEntryState in entryState.ChildStates)
                        {
                            int subEntryNodeStateIndex = GetNodeStateImageIndex(subEntryState.State);
                            TreeNodeEx subEntryNode = new TreeNodeEx(subEntryState.ForAgent, subEntryNodeStateIndex, subEntryNodeStateIndex);
                            subEntryNode.DisplayValue = subEntryState.FormatValue();
                            subEntryNode.Tag = subEntryState;
                            entryNode.Nodes.Add(subEntryNode);
                        }
                    }
                    agentNode.ExpandAll();
                }
            }

            

            //trying to match up Agents/Entries to States
            //if (SelectedCollectorHost.CurrentState != null && SelectedCollectorHost.CurrentState.ChildStates.Count == SelectedCollectorHost.CollectorAgents.Count)
            //{
            //    for (int i = 0; i < tvwAgentStates.Nodes.Count; i++)
            //    {
            //        int stateImageIndex = collectorNAstateImage;
            //        if (SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.Good)
            //            stateImageIndex = collectorGoodStateImage1;
            //        else if (SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.Warning )
            //            stateImageIndex = collectorWarningStateImage1;
            //        else if (SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.Error || SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.ConfigurationError)
            //            stateImageIndex = collectorErrorStateImage1;

            //        tvwAgentStates.Nodes[i].ImageIndex = stateImageIndex;
            //        tvwAgentStates.Nodes[i].SelectedImageIndex = stateImageIndex;
            //        ((TreeNodeEx)tvwAgentStates.Nodes[i]).DisplayValue = SelectedCollectorHost.CurrentState.ChildStates[i].FormatValue();

            //        if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates.Count == tvwAgentStates.Nodes[i].Nodes.Count)
            //        {
            //            for (int j = 0; j < tvwAgentStates.Nodes[i].Nodes.Count; j++)
            //            {
            //                stateImageIndex = collectorNAstateImage;
            //                if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].State == CollectorState.Good)
            //                    stateImageIndex = collectorGoodStateImage1;
            //                else if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].State == CollectorState.Warning)
            //                    stateImageIndex = collectorWarningStateImage1;
            //                else if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].State == CollectorState.Error || SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.ConfigurationError)
            //                    stateImageIndex = collectorErrorStateImage1;

            //                tvwAgentStates.Nodes[i].Nodes[j].ImageIndex = stateImageIndex;
            //                tvwAgentStates.Nodes[i].Nodes[j].SelectedImageIndex = stateImageIndex;
            //                ((TreeNodeEx)tvwAgentStates.Nodes[i].Nodes[j]).DisplayValue = SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].FormatValue();

            //                if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].ChildStates.Count == tvwAgentStates.Nodes[i].Nodes[j].Nodes.Count)
            //                {
            //                    for (int k = 0; k < tvwAgentStates.Nodes[i].Nodes[j].Nodes.Count; k++)
            //                    {
            //                        stateImageIndex = collectorNAstateImage;
            //                        if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].ChildStates[k].State == CollectorState.Good)
            //                            stateImageIndex = collectorGoodStateImage1;
            //                        else if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].ChildStates[k].State == CollectorState.Warning)
            //                            stateImageIndex = collectorWarningStateImage1;
            //                        else if (SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].ChildStates[k].State == CollectorState.Error || SelectedCollectorHost.CurrentState.ChildStates[i].State == CollectorState.ConfigurationError)
            //                            stateImageIndex = collectorErrorStateImage1;

            //                        tvwAgentStates.Nodes[i].Nodes[j].Nodes[k].ImageIndex = stateImageIndex;
            //                        tvwAgentStates.Nodes[i].Nodes[j].Nodes[k].SelectedImageIndex = stateImageIndex;
            //                        ((TreeNodeEx)tvwAgentStates.Nodes[i].Nodes[j].Nodes[k]).DisplayValue = SelectedCollectorHost.CurrentState.ChildStates[i].ChildStates[j].ChildStates[k].FormatValue();
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            SetCollectorTreeViewProperties();
        }

        private void UpdateStatusBar()
        {
            toolStripStatusLabelEnabled.Text = SelectedCollectorHost.Enabled ? "Enabled" : "Disabled";
            toolStripStatusLabelEnabled.Image = SelectedCollectorHost.Enabled ? global::QuickMon.Properties.Resources._131 : global::QuickMon.Properties.Resources._141;
            toolStripStatusLabelAutoRefresh.Text = AutoRefreshEnabled ? "Auto Refresh ON" : "Auto Refresh OFF";
            toolStripStatusLabelAutoRefresh.Image = AutoRefreshEnabled ? global::QuickMon.Properties.Resources._131 : global::QuickMon.Properties.Resources._141;
        }
        private void SetCollectorTreeViewProperties()
        {
            if (Properties.Settings.Default.MainWindowTreeViewExtraColumnSize > 0)
                tvwAgentStates.ExtraColumnWidth = Properties.Settings.Default.MainWindowTreeViewExtraColumnSize;
            else
                tvwAgentStates.ExtraColumnWidth = 100;
            tvwAgentStates.ExtraColumnTextAlign = Properties.Settings.Default.MainWindowTreeViewExtraColumnTextAlign == 1 ? QuickMon.Controls.TreeViewExExtraColumnTextAlign.Right : QuickMon.Controls.TreeViewExExtraColumnTextAlign.Left;
            tvwAgentStates.Refresh();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        private void tvwAgentStates_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeViewHitTestInfo tvi = tvwAgentStates.HitTest(e.Location);
            if (tvi.Node != null && tvi.Location == TreeViewHitTestLocations.RightOfLabel)
                tvwAgentStates.SelectedNode = tvi.Node;
        }

        private void optCurrentStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = true;
        }

        private void optHistoricStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = false;
        }
    }
}
