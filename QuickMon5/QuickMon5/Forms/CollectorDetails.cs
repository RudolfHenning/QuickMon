using HenIT.RTF;
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
            lvwHistory.AutoResizeColumnEnabled = true;
            lvwHistory.BorderStyle = BorderStyle.None;
            agentStateSplitContainer.Panel2Collapsed = true;
            collectorDetailSplitContainer.Panel2Collapsed = true;

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
    }
}
