using HenIT.RTF;
using HenIT.Windows.Controls;
using QuickMon.Forms;
using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HenIT.Windows.Controls.Graphing;

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
        private string currentSelectedControl = "";
        private bool inEditMode = false;
        private static bool updateAgentsDetailViewBusy = false;
        private List<Color> seriesColors = new List<Color>();
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
        private readonly int collectorOutOfServiceWindowstateImage = 9;
        #endregion

        #region Public properties        
        public CollectorHost SelectedCollectorHost { get; set; }
        
        public MonitorPack HostingMonitorPack { get; set; }
        public bool StartWithEditMode { get; set; }
        #endregion

        #region IChildWindowIdentity
        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        public IParentWindow ParentWindow { get; set; }
        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public void RefreshDetails()
        {
            if (SelectedCollectorHost != null)
            {  
                LoadControls();
                if (currentSelectedControl != "")
                    UpdateRawView();                
            }
        }
        public void RefreshCollectorState()
        {
            AutoRefreshEnabled = true; //set automatically is not already
            ((MainForm)ParentWindow).RefreshCollector(SelectedCollectorHost);
        }

        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow(IParentWindow parentWindow = null)
        {
            if (parentWindow != null)
                ParentWindow = parentWindow;
            tlvAgentStates.BorderStyle = BorderStyle.None;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Size = new Size(700, 500);
            Show();
        }
        #endregion

        #region Form events
        private void CollectorDetails_Load(object sender, EventArgs e)
        {
            this.Size = new Size(700, 500);
            tlvAgentStates.AutoResizeColumnEnabled = true;
            agentsTreeListView.AutoResizeColumnEnabled = true;
            lvwActionScripts.AutoResizeColumnEnabled = true;
            lvwActionScriptsEdit.AutoResizeColumnEnabled = true;
            lvwHistory.AutoResizeColumnEnabled = true;
            lvwMetrics.AutoResizeColumnEnabled = true;
            lvwHistory.BorderStyle = BorderStyle.None;
            panelEditing.BorderStyle = BorderStyle.None;
            panelMetrics.BorderStyle = BorderStyle.None;
            txtName.BorderStyle = BorderStyle.None;
            collectorTimeGraph.Visible = false;
            collectorTimeGraph.Dock = DockStyle.Fill;
            panelEditing.Dock = DockStyle.Fill;
            panel4.Dock = DockStyle.Fill;
            //splitContainer2.IsSplitterFixed = false;

            graphTypeToolStripMenuItem.Visible = false;
            grapthColorsToolStripMenuItem.Visible = false;
            graphVisibilityToolStripMenuItem.Visible = false;
            cmdSave.Visible = false;

            agentStateSplitContainer.Panel2Collapsed = true;
            collectorDetailSplitContainer.Panel2Collapsed = true;
            llblRawEdit.Visible = Properties.Settings.Default.EnableRawEditing;

            if (SelectedCollectorHost == null)
            {
                SelectedCollectorHost = new CollectorHost();
            }
            else
            {
                HostingMonitorPack = SelectedCollectorHost.ParentMonitorPack; 
            }

            LoadDefaultGraphSettings();
            RefreshDetails();
            LoadEditControls();
            splitContainerMain.Panel2Collapsed = true;
            SetActivePanel(panelAgentStates);

            if (Properties.Settings.Default.EnableAutoRefreshCollectorDetailAutomatically)
            {
                AutoRefreshEnabled = true;              
            }
            UpdateStatusBar();
        }
        private void CollectorDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        }
        private void CollectorDetails_Shown(object sender, EventArgs e)
        {
            if (StartWithEditMode)
                StartEditMode();
        }
        #endregion

        #region Private methods
        private void LoadDefaultGraphSettings()
        {
            seriesColors = new List<Color>();
            seriesColors.AddRange((from string colorName in Properties.Settings.Default.GraphLineColors
                                   select HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorFromName(colorName)));

            collectorTimeGraph.GraphVerticalAxisType = (GraphVerticalAxisType)Properties.Settings.Default.GraphDefaultType;
            collectorTimeGraph.BackgroundGradientColor1 = Properties.Settings.Default.GraphBackgroundColor1;
            collectorTimeGraph.BackgroundGradientColor2 = Properties.Settings.Default.GraphBackgroundColor2;
            collectorTimeGraph.GridColor = Properties.Settings.Default.GraphGridColor;
            collectorTimeGraph.AxisLabelColor = Properties.Settings.Default.GraphAxisLabelsColor;
            collectorTimeGraph.TimeSelectionColor = Properties.Settings.Default.GraphSelectionBarColor;
            collectorTimeGraph.GradientDirection = (System.Drawing.Drawing2D.LinearGradientMode)Properties.Settings.Default.GraphGradientDirection;
            collectorTimeGraph.ClosestClickedValueColorType = (ClosestClickedValueColorType)Properties.Settings.Default.GraphClosestClickedValueType;
            collectorTimeGraph.ClosestClickedValueCustomColor = Properties.Settings.Default.GraphClosestClickedValueColor;
            collectorTimeGraph.ShowGraphHeader = Properties.Settings.Default.GraphHeaderVisible;
            collectorTimeGraph.ShowLegendText = Properties.Settings.Default.GraphLegendVisible;
            collectorTimeGraph.ShowHorisontalGridlines = Properties.Settings.Default.GraphHorisontalGridLinesVisible;
            collectorTimeGraph.ShowVerticalGridLines = Properties.Settings.Default.GraphVerticalGridLinesVisible;
            collectorTimeGraph.ShowSelectionBar = Properties.Settings.Default.GraphSelectionBarVisible;
            collectorTimeGraph.HighlightClickedSeries = Properties.Settings.Default.GraphHighlightClickedSeriesVisible;
            collectorTimeGraph.FillAreaBelowGraph = Properties.Settings.Default.GraphEnableFillAreaBelowSeries;
            collectorTimeGraph.FillAreaBelowGraphAlpha = Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha;
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
        public void StartEditMode()
        {
            inEditMode = true;
            if (this.Size.Height < 450)
            {
                this.Size = new Size(this.Size.Width, 450);
            }
            collectorDetailSplitContainer.Panel2Collapsed = true;
            chkRAWDetails.Checked = false;
            chkRAWDetails.Image = chkRAWDetails.Checked ? global::QuickMon.Properties.Resources._133 : global::QuickMon.Properties.Resources._131;
            optAgentStates.Enabled = false;
            optMetrics.Enabled = false;
            txtName.Text = SelectedCollectorHost.Name;
            txtName.ReadOnly = false;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            cboTextType.SelectedIndex = 0;
            cmdSave.Visible = true;
            SetActivePanel(panelEditing);
            EnableAgentContextMenuItems();
            
            CheckOkEnabled();            
        }
        private void StopEditMode()
        {
            optAgentStates.Enabled = true;
            optMetrics.Enabled = true;
            txtName.Text = SelectedCollectorHost.NameFormatted;
            txtName.ReadOnly = true;
            txtName.BorderStyle = BorderStyle.None;
            if (optAgentStates.Checked)
                optAgentStates_CheckedChanged(null, null);
            else if (optMetrics.Checked)
                optMetrics_CheckedChanged(null, null);
            cmdSave.Visible = false;
            inEditMode = false;
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
            else if (state == CollectorState.NotInServiceWindow)
                stateImageIndex = collectorOutOfServiceWindowstateImage;
            return stateImageIndex;
        }
        private void LoadControls()
        {
            SetWindowTitle();
            if (SelectedCollectorHost.CurrentState != null)
            {
                lastUpdateTimeToolStripStatusLabel.Text = SelectedCollectorHost.CurrentState.Timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                if (SelectedCollectorHost.CurrentState.State == CollectorState.Good)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.ok24x24;
                    panelTop.BackColor = Color.White;
                    txtName.BackColor = Color.White;
                }
                else if (SelectedCollectorHost.CurrentState.State == CollectorState.Warning)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.triang_yellow24x24;
                    panelTop.BackColor = Color.LightYellow;
                    txtName.BackColor = Color.LightYellow;
                }
                else if (SelectedCollectorHost.CurrentState.State == CollectorState.Error || SelectedCollectorHost.CurrentState.State == CollectorState.ConfigurationError)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.triang_red24x24; //.Error24x24;
                    panelTop.BackColor = Color.FromArgb(255, 240, 240);
                    txtName.BackColor = Color.FromArgb(255, 240, 240);
                }
                else if (SelectedCollectorHost.CurrentState.State == CollectorState.NotInServiceWindow)
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.clock1;
                    panelTop.BackColor = Color.White;
                    txtName.BackColor = Color.White;
                }
                else
                {
                    lblCollectorState.Image = global::QuickMon.Properties.Resources.helpbwy24x24;
                    panelTop.BackColor = Color.White;
                    txtName.BackColor = Color.White;
                }
            }
            
            if (!inEditMode)
                txtName.Text = SelectedCollectorHost.NameFormatted;
            else if (txtName.Text == "")
                txtName.Text = SelectedCollectorHost.Name;
            LoadMetrics();
            LoadHistory();
            LoadActionScripts();
            UpdateAgentStateTree();
            UpdateGraphView();          
        }

        private void UpdateGraphView()
        {
            if (optGraphView.Checked)
            {
                DateTime startDateTime = DateTime.Now.AddMinutes(-1);
                DateTime endDateTime = DateTime.Now;
                long maxValue = 1;
                List<string> seriesNames = new List<string>();
                List<HenIT.Windows.Controls.Graphing.GraphSeries> graphSeriesList = new List<HenIT.Windows.Controls.Graphing.GraphSeries>();
                foreach (MonitorState historyState in SelectedCollectorHost.StateHistory)
                {
                    foreach (MonitorState agentState in historyState.ChildStates)
                    {
                        if (agentState.ForAgent != null && agentState.ForAgent != "")
                        {
                            if (!seriesNames.Contains(agentState.ForAgent))
                            {
                                seriesNames.Add(agentState.ForAgent);
                            }
                        }
                        foreach (MonitorState subEntryState in agentState.ChildStates)
                        {
                            if (subEntryState.ForAgent != null && subEntryState.ForAgent != "")
                            {
                                if (!seriesNames.Contains(subEntryState.ForAgent))
                                {
                                    seriesNames.Add(subEntryState.ForAgent);
                                }
                            }
                        }
                    }
                }
                foreach(string seriesName in seriesNames)
                {
                    Color seriesColor = seriesColors[graphSeriesList.Count % seriesColors.Count];
                    HenIT.Windows.Controls.Graphing.GraphSeries series = new HenIT.Windows.Controls.Graphing.GraphSeries(seriesName, seriesColor);
                    foreach (MonitorState historyState in SelectedCollectorHost.StateHistory)
                    {
                        foreach (MonitorState agentState in historyState.ChildStates)
                        {
                            if (agentState.ForAgent == seriesName)
                            {
                                float v = 0;
                                if (agentState.CurrentValue != null && float.TryParse(agentState.CurrentValue.ToString(), out v))
                                {
                                    if (maxValue < v)
                                        maxValue = (long)v;
                                    if (startDateTime > agentState.Timestamp)
                                        startDateTime = agentState.Timestamp;                                    
                                    series.Values.Add(new HenIT.Windows.Controls.Graphing.TimeValue() { Time = agentState.Timestamp, Value = v });
                                }
                            }
                            foreach (MonitorState subEntryState in agentState.ChildStates)
                            {
                                if (subEntryState.ForAgent == seriesName)
                                {
                                    float v = 0;
                                    if (subEntryState.CurrentValue != null && float.TryParse(subEntryState.CurrentValue.ToString(), out v))
                                    {
                                        if (maxValue < v)
                                            maxValue = (long)v;
                                        if (startDateTime > agentState.Timestamp)
                                            startDateTime = agentState.Timestamp;
                                        series.Values.Add(new HenIT.Windows.Controls.Graphing.TimeValue() { Time = subEntryState.Timestamp, Value = v });
                                    }
                                }
                            }
                        }
                    }

                    foreach (MonitorState agentState in SelectedCollectorHost.CurrentState.ChildStates)
                    {
                        if (agentState.ForAgent == seriesName)
                        {
                            float v = 0;
                            if (agentState.CurrentValue != null && float.TryParse(agentState.CurrentValue.ToString(), out v))
                            {
                                if (maxValue < v)
                                    maxValue = (long)v;
                                if (startDateTime > agentState.Timestamp)
                                    startDateTime = agentState.Timestamp;
                                series.Values.Add(new HenIT.Windows.Controls.Graphing.TimeValue() { Time = agentState.Timestamp, Value = v });
                            }
                        }
                        foreach (MonitorState subEntryState in agentState.ChildStates)
                        {
                            if (subEntryState.ForAgent == seriesName)
                            {
                                float v = 0;
                                if (subEntryState.CurrentValue != null && float.TryParse(subEntryState.CurrentValue.ToString(), out v))
                                {
                                    if (maxValue < v)
                                        maxValue = (long)v;
                                    if (startDateTime > agentState.Timestamp)
                                        startDateTime = agentState.Timestamp;
                                    series.Values.Add(new HenIT.Windows.Controls.Graphing.TimeValue() { Time = subEntryState.Timestamp, Value = v });
                                }
                            }
                        }
                    }

                    if (series.Values.Count > 0)
                        graphSeriesList.Add(series);
                }


                //MonitorState selectedMonitorState;
                //SelectedCollectorHost.StateHistory
                //selectedMonitorState = SelectedCollectorHost.CurrentState;

                
                //HenIT.Windows.Controls.Graphing.GraphSeries series = new HenIT.Windows.Controls.Graphing.GraphSeries(selectedMonitorState.ForAgent, Color.Red);
                
                //foreach (MonitorState agentState in selectedMonitorState.ChildStates)
                //{ 
                //    foreach (MonitorState entryState in agentState.ChildStates)
                //    {
                //        foreach (MonitorState subEntryState in entryState.ChildStates)
                //        {
                //            if (subEntryState.CurrentValue.IsNumber())
                //            {
                //                float v = 0;
                //                if (float.TryParse(subEntryState.CurrentValue.ToString(), out v))
                //                {
                //                    if (maxValue < v)
                //                        maxValue = (long)v;
                //                    if (startDateTime > entryState.Timestamp)
                //                        startDateTime = entryState.Timestamp;
                //                    if (endDateTime < entryState.Timestamp)
                //                        endDateTime = entryState.Timestamp;
                //                    series.Values.Add(new HenIT.Windows.Controls.Graphing.TimeValue() { Time = subEntryState.Timestamp, Value = v });
                //                }
                //            }
                //        }
                            
                //    }
                    
                //}
                //graphSeriesList.Add(series);

                collectorTimeGraph.PauseUpdates();
                collectorTimeGraph.GraphHeaderText = $"'{SelectedCollectorHost.Path}'"; // $"{SelectedCollectorHost.Name} ({SelectedCollectorHost.PathWithoutMP})"; // SelectedCollectorHost.Name;
                collectorTimeGraph.Series = null;
                collectorTimeGraph.StartDateTime = startDateTime;
                collectorTimeGraph.EndDateTime = endDateTime;
                collectorTimeGraph.MaxGraphValue = maxValue;
                collectorTimeGraph.Series = graphSeriesList;
                collectorTimeGraph.SetAutoMinMaxDateTimes(true, true, true);

                this.Invoke((MethodInvoker)delegate
                {
                    collectorTimeGraph.RefreshGraph();
                });
            }
        }

        private void LoadActionScripts()
        {
            lvwActionScripts.Items.Clear();
            if (SelectedCollectorHost.ActionScripts != null)
            {
                foreach (var actionScript in SelectedCollectorHost.ActionScripts)
                {
                    ListViewItem lvi = new ListViewItem(actionScript.Name);
                    lvi.Tag = actionScript;
                    lvwActionScripts.Items.Add(lvi);
                }                
            }
        }
        private void LoadActionScriptsEditing()
        {
            lvwActionScriptsEdit.Items.Clear();
            if (SelectedCollectorHost.ActionScripts != null)
            {
                foreach (var actionScript in SelectedCollectorHost.ActionScripts)
                {
                    ListViewItem lvi = new ListViewItem(actionScript.Name);
                    lvi.SubItems.Add(actionScript.ScriptType.ToString());
                    lvi.SubItems.Add(actionScript.RunAdminMode ? "Yes" : "No");
                    lvi.SubItems.Add(actionScript.IsRestorationScript ? "Yes" : "No");
                    lvi.SubItems.Add(actionScript.IsWarningCorrectiveScript ? "Yes" : "No");
                    lvi.SubItems.Add(actionScript.IsErrorCorrectiveScript ? "Yes" : "No");
                    lvi.SubItems.Add(actionScript.Description);
                    lvi.Tag = actionScript;

                    lvwActionScriptsEdit.Items.Add(lvi);
                }
            }
        }
        private void LoadMetrics()
        {
            AddUpdateListViewItem(lvwMetrics, "General", "Notes", SelectedCollectorHost.Notes);
            AddUpdateListViewItem(lvwMetrics, "General", "Enabled", (SelectedCollectorHost.Enabled ? "Yes" : "No") + (SelectedCollectorHost.ServiceWindows.IsInTimeWindow() ? "" : " (Out of service window)"));
            AddUpdateListViewItem(lvwMetrics, "General", "Agent count", SelectedCollectorHost.CollectorAgents.Count.ToString());

            if (SelectedCollectorHost.Categories != null)
            {
                StringBuilder sbCats = new StringBuilder();
                foreach (string category in SelectedCollectorHost.Categories)
                {
                    sbCats.Append(category + ",");
                }
                if (sbCats.ToString().Length > 0)
                    AddUpdateListViewItem(lvwMetrics, "General", "Categories", sbCats.ToString().TrimEnd(','));
                else
                    AddUpdateListViewItem(lvwMetrics, "General", "Categories", "None");
            }

            #region Polling metrics
            //AddUpdateListViewItem(lvwMetrics, "Polling metrics", "# of times polled", SelectedCollectorHost.PollCount.ToString());
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "# of times refreshed", SelectedCollectorHost.RefreshCount.ToString());
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Polling override enabled", SelectedCollectorHost.EnabledPollingOverride ? "Yes" : "No");
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Poll frequency sliding enabled", SelectedCollectorHost.EnablePollFrequencySliding ? "Yes" : "No", SelectedCollectorHost.EnabledPollingOverride);
            int currentPollFreq = 0;
            if (SelectedCollectorHost.EnabledPollingOverride)
            {
                if (SelectedCollectorHost.EnablePollFrequencySliding)
                {
                    if (SelectedCollectorHost.StagnantStateThirdRepeat)
                        currentPollFreq = SelectedCollectorHost.PollSlideFrequencyAfterThirdRepeatSec;
                    else if (SelectedCollectorHost.StagnantStateSecondRepeat)
                        currentPollFreq = SelectedCollectorHost.PollSlideFrequencyAfterSecondRepeatSec;
                    else if (SelectedCollectorHost.StagnantStateFirstRepeat)
                        currentPollFreq = SelectedCollectorHost.PollSlideFrequencyAfterFirstRepeatSec;
                    else
                        currentPollFreq = SelectedCollectorHost.OnlyAllowUpdateOncePerXSec;
                }
                else
                    currentPollFreq = SelectedCollectorHost.OnlyAllowUpdateOncePerXSec;
            }
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Current poll frequency (Sec)", currentPollFreq.ToString(), SelectedCollectorHost.EnabledPollingOverride);
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "First polled time", FormatDate(SelectedCollectorHost.FirstStateUpdate));
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "# of unique times good states", SelectedCollectorHost.GoodStateCount.ToString());
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "# of unique times warning states", SelectedCollectorHost.WarningStateCount.ToString());
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "# of unique times error states", SelectedCollectorHost.ErrorStateCount.ToString());
            AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last attempted polling time", FormatDate(SelectedCollectorHost.LastStateCheckAttemptBegin));

            if (SelectedCollectorHost.LastGoodState != null)
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last good state time", FormatDate(SelectedCollectorHost.LastGoodState.Timestamp));
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last good state details", SelectedCollectorHost.LastGoodState.ReadAllRawDetails());
            }
            else
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last good state time", "N/A");
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last good state details", "N/A");
            }
            if (SelectedCollectorHost.LastWarningState != null)
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last warning state time", FormatDate(SelectedCollectorHost.LastWarningState.Timestamp));
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last warning state details", SelectedCollectorHost.LastWarningState.ReadAllRawDetails());
            }
            else
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last warning state time", "N/A");
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last warning state details", "N/A");
            }
            if (SelectedCollectorHost.LastErrorState != null)
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last error state time", FormatDate(SelectedCollectorHost.LastErrorState.Timestamp));
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last error state details", SelectedCollectorHost.LastErrorState.ReadAllRawDetails());
            }
            else
            {
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last error state time", "N/A");
                AddUpdateListViewItem(lvwMetrics, "Polling metrics", "Last error state details", "N/A");
            }
            #endregion

            #region Corrective scripts
            AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "Enabled", (SelectedCollectorHost.CorrectiveScriptDisabled ? "No" : "Yes"));
            if (!SelectedCollectorHost.CorrectiveScriptDisabled)
            {
                if (SelectedCollectorHost.LastWarningCorrectiveScriptRun.Year > 2000)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "Last time warning script ran", SelectedCollectorHost.LastWarningCorrectiveScriptRun.ToString());
                if (SelectedCollectorHost.TimesWarningCorrectiveScriptRan > 0)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "# of Times warning script ran", SelectedCollectorHost.TimesWarningCorrectiveScriptRan.ToString());
                if (SelectedCollectorHost.LastErrorCorrectiveScriptRun.Year > 2000)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "Last time error script ran", SelectedCollectorHost.LastErrorCorrectiveScriptRun.ToString());
                if (SelectedCollectorHost.TimesErrorCorrectiveScriptRan > 0)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "# of Times error script ran", SelectedCollectorHost.TimesErrorCorrectiveScriptRan.ToString());
                if (SelectedCollectorHost.LastRestorationScriptRun.Year > 2000)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "Last time restoration script ran", SelectedCollectorHost.LastRestorationScriptRun.ToString());
                if (SelectedCollectorHost.TimesRestorationScriptRan > 0)
                    AddUpdateListViewItem(lvwMetrics, "Corrective scripts", "# of Times restoration script ran", SelectedCollectorHost.TimesRestorationScriptRan.ToString());
            }
            #endregion

            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state", SelectedCollectorHost.CurrentState.State.ToString());
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state time", FormatDate(SelectedCollectorHost.CurrentState.Timestamp));
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state check duration (ms)", SelectedCollectorHost.CurrentState.CallDurationMS.ToString());
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state Executed on", SelectedCollectorHost.CurrentState.ExecutedOnHostComputer);
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state Ran as", SelectedCollectorHost.CurrentState.RanAs);
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state Alerts raised", SelectedCollectorHost.CurrentState.AlertsRaised.Count > 0 ? "Yes" : "No");
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state Alerts details", SelectedCollectorHost.CurrentState.AlertsRaised, SelectedCollectorHost.CurrentState.AlertsRaised.Count > 0);
            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state details", SelectedCollectorHost.CurrentState.ReadAllRawDetails());

            List<string> values = ReadValues(SelectedCollectorHost.CurrentState);
            if (values != null && values.Count > 0)
            {
                for (int i = 0; i < values.Count; i++)
                    AddUpdateListViewItem(lvwMetrics, "Current state", "Current state value:" + (i + 1).ToString(), values[i]);
            }
            //if (values != null && values.Count > 0)
            //{
            //    if (previousCurrentStateValueCount > 0 && values.Count < previousCurrentStateValueCount)
            //    {
            //        for (int i = values.Count; i < previousCurrentStateValueCount + 1; i++)
            //            AddUpdateListViewItem(lvwMetrics, "Current state", "Current state value:" + (i + 1).ToString(), "", false);
            //    }
            //    previousCurrentStateValueCount = values.Count;
            //}
            //else
            //{
            //    previousCurrentStateValueCount = 0;
            //}


            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.State.ToString());
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state time", SelectedCollectorHost.PreviousState == null ? "N/A" : FormatDate(SelectedCollectorHost.PreviousState.Timestamp));
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state check duration (ms)", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.CallDurationMS.ToString());
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state Executed on", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.ExecutedOnHostComputer);
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state Ran as", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.RanAs);
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state Alerts raised", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.AlertsRaised.Count > 0 ? "Yes" : "No");
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state Alerts details", SelectedCollectorHost.PreviousState == null ? new List<string>() : SelectedCollectorHost.PreviousState.AlertsRaised, SelectedCollectorHost.PreviousState != null);
            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state details", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.ReadAllRawDetails());
            if (SelectedCollectorHost.PreviousState != null)
            {
                values = ReadValues(SelectedCollectorHost.PreviousState);
                if (values != null && values.Count > 0)
                {
                    for (int i = 0; i < values.Count; i++)
                        AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state value:" + (i + 1).ToString(), values[i]);
                }
            }
            //if (values != null && values.Count > 0)
            //{
            //    if (previousPreviousStateValueCount > 0 && values.Count < previousPreviousStateValueCount)
            //    {
            //        for (int i = values.Count; i < previousPreviousStateValueCount + 1; i++)
            //            AddUpdateListViewItem(lvwMetrics, "Previous state", "Previous state value:" + (i + 1).ToString(), "", false);
            //    }
            //    previousPreviousStateValueCount = values.Count;
            //}
            //else
            //{
            //    previousPreviousStateValueCount = 0;
            //}

            bool remoteHostEnabled = SelectedCollectorHost.EnableRemoteExecute || (SelectedCollectorHost.OverrideRemoteAgentHost && !SelectedCollectorHost.BlockParentOverrideRemoteAgentHostSettings);
            AddUpdateListViewItem(lvwMetrics, "Remote agent host", "Enabled", remoteHostEnabled ? "Yes" : "No");
            AddUpdateListViewItem(lvwMetrics, "Remote agent host", "Address", SelectedCollectorHost.ToRemoteHostName(), remoteHostEnabled);
        }
        private void LoadEditControls()
        {
            #region Editing controls
            editingCollectorHost = SelectedCollectorHost.Clone();

            agentCheckSequenceToolStripComboBox.SelectedIndex = (int)editingCollectorHost.AgentCheckSequence;
            cboChildCheckBehaviour.SelectedIndex = (int)editingCollectorHost.ChildCheckBehaviour;
            cboExpandOnStartOption.SelectedIndex = (int)editingCollectorHost.ExpandOnStartOption;
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
            //chkOnlyRunCorrectiveScriptsOnStateChange.Checked = editingCollectorHost.CorrectiveScriptsOnlyOnStateChange;
            numericUpDownRestorationScriptMinimumRepeatTimeMin.SaveValueSet(editingCollectorHost.RestorationScriptMinimumRepeatTimeMin);
            chkRunAsEnabled.Checked = editingCollectorHost.RunAsEnabled;
            txtRunAs.Text = editingCollectorHost.RunAs;
            txtAdditionalNotes.Text = editingCollectorHost.Notes;
            cboTextType_SelectedIndexChanged(null, null);
            chkExcludeFromMetrics.Checked = editingCollectorHost.ExcludeFromMetrics;

            StringBuilder categories = new StringBuilder();
            if (editingCollectorHost.Categories != null && editingCollectorHost.Categories.Count > 0)
            {
                foreach (string category in editingCollectorHost.Categories)
                {
                    categories.AppendLine(category);
                }
                txtCategories.Text = categories.ToString();
            }
            LoadServiceWindows();
            LoadConfigVars();
            LoadAgents();
            LoadActionScriptsEditing();
            #endregion
        }
        private void LoadServiceWindows()
        {
            if (editingCollectorHost.ServiceWindows != null)
                linkLabelServiceWindows.Text = editingCollectorHost.ServiceWindows.ToString();
            else
                linkLabelServiceWindows.Text = "None";
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
                Text += $" - '{SelectedCollectorHost.Path}'"; // SelectedCollectorHost.Name;
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
                    icon = Properties.Resources.triang_red;
                }
                else if (state == CollectorState.Warning)
                {
                    icon = Properties.Resources.warn;
                }
                else if (state == CollectorState.Good)
                {
                    icon = Properties.Resources.ok;
                }
                else if (state == CollectorState.NotInServiceWindow)
                {
                    icon = Properties.Resources.CLOCK02;
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

            if (selectedMonitorState == null || selectedMonitorState.ChildStates == null || selectedMonitorState.ChildStates.Count == 0 || selectedMonitorState.State == CollectorState.UpdateInProgress || selectedMonitorState.State == CollectorState.NotAvailable)
            {
                int agentNodeStateIndex = GetNodeStateImageIndex(selectedMonitorState.State);
                foreach (ICollector agent in SelectedCollectorHost.CollectorAgents)
                {
                    string agentName = SelectedCollectorHost.ApplyConfigVarsOnString(agent.Name);
                    TreeListViewItem agentNode = new TreeListViewItem(agentName, agentNodeStateIndex);
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
                                TreeListViewItem subEntryNode = new TreeListViewItem(subEntry.Description, collectorNAstateImage);
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
                        entryNode.SubItems.Add(entryState.ReadPrimaryOrFirstUIValue()); //.FormatValue());
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
            bool currentStateSelected = false;
            DateTime selectedTimeStamp = new DateTime(1900, 1, 1);
            if (lvwHistory.SelectedItems.Count == 1 && lvwHistory.SelectedItems[0].Tag is MonitorState)
            {
                if (lvwHistory.SelectedItems[0].Index == 0)
                    currentStateSelected = true;
                else
                {
                    hi = (MonitorState)lvwHistory.SelectedItems[0].Tag;
                    selectedTimeStamp = hi.Timestamp;
                }
            }

            lvwHistory.Items.Clear();
            if (SelectedCollectorHost != null && SelectedCollectorHost.StateHistory != null && SelectedCollectorHost.CurrentState != null)
            {
                optHistoricStateView.Text = "History (" + SelectedCollectorHost.StateHistory.Count.ToString() + ")";
                hi = SelectedCollectorHost.CurrentState;
                ListViewItem lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                lvi.ImageIndex = GetNodeStateImageIndex(hi.State);
                lvi.SubItems.Add(hi.ReadPrimaryOrFirstUIValue());
                //lvi.SubItems.Add(hi.State.ToString());
                lvi.SubItems.Add(hi.CallDurationMS.ToString());
                lvi.SubItems.Add(hi.AlertsRaised.Count.ToString());
                //lvi.SubItems.Add(hi.ExecutedOnHostComputer);
                //lvi.SubItems.Add(hi.RanAs);
                
                lvi.Tag = hi;
                lvwHistory.Items.Add(lvi);
                if (selectedTimeStamp == hi.Timestamp || currentStateSelected)
                    lvi.Selected = true;

                for (int i = SelectedCollectorHost.StateHistory.Count - 1; i >= 0; i--)
                {
                    hi = SelectedCollectorHost.StateHistory[i];
                    lvi = new ListViewItem(hi.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.ImageIndex = GetNodeStateImageIndex(hi.State);
                    lvi.SubItems.Add(hi.ReadPrimaryOrFirstUIValue());
                    //lvi.SubItems.Add(hi.State.ToString());
                    lvi.SubItems.Add(hi.CallDurationMS.ToString());
                    lvi.SubItems.Add(hi.AlertsRaised.Count.ToString());
                    //lvi.SubItems.Add(hi.ExecutedOnHostComputer);
                    //lvi.SubItems.Add(hi.RanAs);
                    
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
                optHistoricStateView.Text = "History";
            }
        }
        private void AddUpdateListViewItem(ListView lvw, string groupName, string propName, List<string> values, bool visible = true)
        {
            StringBuilder sb = new StringBuilder();
            if (values != null)
            {
                values.ForEach(v => sb.AppendLine(v));
            }
            AddUpdateListViewItem(lvw, groupName, propName, sb.ToString(), visible);
        }
        private void AddUpdateListViewItem(ListView lvw, string groupName, string propName, string value, bool visible = true)
        {
            ListViewGroup lvg = (from ListViewGroup g in lvw.Groups
                                 where g.Header == groupName
                                 select g).FirstOrDefault();
            if (lvg == null)
            {
                lvg = new ListViewGroup(groupName);
                lvw.Groups.Add(lvg);
            }
            ListViewItem lvi = (from ListViewItem i in lvw.Items
                                where i.Text == propName &&
                                i.Group == lvg
                                select i).FirstOrDefault();
            if (lvi == null)
            {
                lvi = new ListViewItem(propName);
                lvi.SubItems.Add(value);
                lvi.Group = lvg;
                lvw.Items.Add(lvi);
            }
            lvi.SubItems[1].Text = value;
            if (!visible)
            {
                lvw.Items.Remove(lvi);
            }
        }
        private string FormatDate(DateTime date)
        {
            if (date == null || date <= (new DateTime(2000, 1, 1)))
                return "N/A";
            else
                return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private List<string> ReadValues(MonitorState monitorState)
        {
            List<string> values = new List<string>();
            if (monitorState.ChildStates != null) // && monitorState.ChildStates.Count(cs=>cs.CurrentValue != null) > 0)
            {
                foreach (MonitorState childEntry in monitorState.ChildStates)
                {
                    foreach (string v in ReadValues(childEntry))
                    {
                        values.Add(v);
                    }
                }
            }
            if (values.Count == 0 && monitorState.CurrentValue != null)
            {
                if (monitorState.ForAgent != null && monitorState.ForAgent.Length > 0)
                    values.Add(string.Format("{0}:{1}", monitorState.ForAgent, monitorState.CurrentValue));
                else
                    values.Add(string.Format("{0}", monitorState.CurrentValue));
            }
            return values;
        }
        private void UpdateRawView()
        {
            if (!updateAgentsDetailViewBusy)
            {
                updateAgentsDetailViewBusy = true;
                RTFBuilder rtfBuilder = new RTFBuilder();

                if (currentSelectedControl == "" || currentSelectedControl == "tlvAgentStates")
                {
                    if (tlvAgentStates.SelectedItems.Count == 0)
                    {                        
                        WriteMonitorState(rtfBuilder, SelectedCollectorHost.CurrentState);
                    }
                    else
                    {
                        object selectedObject = tlvAgentStates.SelectedItems[0].Tag;
                        if (selectedObject == null)
                        {
                            WriteMonitorState(rtfBuilder, SelectedCollectorHost.CurrentState);
                        }
                        else if (selectedObject is ICollector)
                        {
                            ICollector c = (ICollector)selectedObject;
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Name: ").FontStyle(FontStyle.Regular).AppendLine(c.Name);
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Type: ").FontStyle(FontStyle.Regular).AppendLine("Agent");
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ").FontStyle(FontStyle.Regular).AppendLine(c.CurrentState.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("State: ").FontStyle(FontStyle.Regular).AppendLine(c.CurrentState.State.ToString());
                            rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Value(s): ").FontStyle(FontStyle.Regular).AppendLine(c.CurrentState.ReadAgentValues());
                            if (c.CurrentState.RawDetails != null && c.CurrentState.RawDetails.Length > 0)
                            //if (c.CurrentState.State != CollectorState.Good && c.CurrentState.RawDetails != null && c.CurrentState.RawDetails.Length > 0)
                            {
                                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Raw details: ").FontStyle(FontStyle.Regular).AppendLine(c.CurrentState.RawDetails);
                            }
                        }
                        else if (selectedObject is ICollectorConfigEntry)
                        {
                            ICollectorConfigEntry c = (ICollectorConfigEntry)selectedObject;
                            
                        }
                        else if (selectedObject is ICollectorConfigSubEntry)
                        {

                        }
                        else if (selectedObject is MonitorState)
                        {
                            MonitorState ms = (MonitorState)selectedObject;
                            WriteMonitorState(rtfBuilder, ms);
                        }
                        else if (selectedObject is string)
                        {
                            rtfBuilder.AppendLine(selectedObject.ToString());
                        }

                    }
                }
                else if (currentSelectedControl == "lvwHistory")
                {
                    if (lvwHistory.SelectedItems.Count == 1)
                    {
                        object selectedObject = lvwHistory.SelectedItems[0].Tag;
                        if (selectedObject is MonitorState)
                        {
                            MonitorState ms = (MonitorState)selectedObject;
                            WriteMonitorState(rtfBuilder, ms);
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
        private void WriteMonitorState(RTFBuilder rtfBuilder, MonitorState ms)
        {
            if (ms != null)
            {
                if (FormatUtils.N(ms.ForAgent) != "")
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("For object: ").FontStyle(FontStyle.Regular).AppendLine(ms.ForAgent);
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ").FontStyle(FontStyle.Regular).AppendLine(ms.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                rtfBuilder.FontStyle(FontStyle.Bold).Append("State: ").FontStyle(FontStyle.Regular).AppendLine(ms.State.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Duration: ").FontStyle(FontStyle.Regular).AppendLine(ms.CallDurationMS.ToString() + " ms");
                if (ms.AlertsRaised != null)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Alert count: ").FontStyle(FontStyle.Regular).AppendLine(ms.AlertsRaised.Count.ToString());                 
                }
                
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Executed on: ").FontStyle(FontStyle.Regular).AppendLine(FormatUtils.N(ms.ExecutedOnHostComputer));
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Ran as: ").FontStyle(FontStyle.Regular).AppendLine(FormatUtils.N(ms.RanAs));
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Value(s): ").FontStyle(FontStyle.Regular).AppendLine(ms.ReadAgentValues());
                if (ms.RawDetails != null && ms.RawDetails.Length > 0)
                //if (ms.State != CollectorState.Good && ms.RawDetails != null && ms.RawDetails.Length > 0)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Raw details: ").FontStyle(FontStyle.Regular).AppendLine(ms.RawDetails);
                }
                if (ms.AlertsRaised != null)
                {
                    if (ms.AlertsRaised.Count > 0)
                    {
                        string alertSummary = "";
                        ms.AlertsRaised.ForEach(a => alertSummary += '\t' + a.TrimEnd('\r', '\n').Replace("\r\n", "\r\n\t") + "\r\n");
                        alertSummary = alertSummary.Trim('\r', '\n');
                        rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Alert details:").FontStyle(FontStyle.Regular).AppendLine(alertSummary.TrimEnd('\r', '\n'));
                    }
                }
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
                            if (entry.PrimaryUIValue)
                                tlvAgentEntry.Font = new Font(agentsTreeListView.Font, FontStyle.Bold);
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
            if (!inEditMode)
                StartEditMode();
            else
                StopEditMode();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            StopEditMode();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshCollectorState();
            //RefreshDetails();
        }
        #endregion

        #region Other control events
        private void optAgentStates_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelAgentStates);
        }
        private void optMetrics_CheckedChanged(object sender, EventArgs e)
        {
            SetActivePanel(panelMetrics);
            collectorDetailSplitContainer.Panel2Collapsed = true;
            chkRAWDetails.Image = global::QuickMon.Properties.Resources._131;
        }
        private void optCurrentStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = true;
            UpdateAgentStateTree();
        }
        private void optHistoricStateView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = false;
            lvwHistory.Visible = true;
            collectorTimeGraph.Visible = false;
            UpdateAgentStateTree();
        }
        private void optGraphView_CheckedChanged(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = false;
            lvwHistory.Visible = false;
            collectorTimeGraph.Visible = true;
            UpdateGraphView();
            UpdateAgentStateTree();
        }
        private void chkRAWDetails_CheckedChanged(object sender, EventArgs e)
        {
            collectorDetailSplitContainer.Panel2Collapsed = !chkRAWDetails.Checked;
            chkRAWDetails.Image = chkRAWDetails.Checked ? global::QuickMon.Properties.Resources._133 : global::QuickMon.Properties.Resources._131;

            if (collectorDetailSplitContainer.Panel2.Height < 200)
            {
                collectorDetailSplitContainer.SplitterDistance = collectorDetailSplitContainer.Height - 200;
            }
            UpdateRawView();
        }
        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwHistory.SelectedItems.Count == 1)
            {
                UpdateAgentStateTree();
                if (lvwHistory.Focused)
                    currentSelectedControl = "lvwHistory";
                UpdateRawView();
            }            
        }
        private void tlvAgentStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tlvAgentStates.Focused)
                currentSelectedControl = "tlvAgentStates";
            UpdateRawView();
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
                if (AutoRefreshEnabled)
                    RefreshDetails();
                UpdateStatusBar();
            }            
        }
        #endregion

        #region Editing
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetEditingCollectorHost())
                {
                    SelectedCollectorHost.ReconfigureFromXml(editingCollectorHost.ToXml());
                    LoadControls();

                    //((MainForm)ParentWindow).UpdateCollector(SelectedCollectorHost, true);
                    ((MainForm)ParentWindow).SetMonitorChanged();
                    ((MainForm)ParentWindow).UpdateCollectorDisplayText(SelectedCollectorHost);
                    StopEditMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }            
        }
        private void llblRawEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoRAWEdit();
        }
        private void DoRAWEdit()
        {
            if (SetEditingCollectorHost())
            {
                SelectedCollectorHost.ReconfigureFromXml(editingCollectorHost.ToXml());

                RAWXmlEditor editor = new RAWXmlEditor();
                string oldMarkUp = SelectedCollectorHost.ToXml();
                editor.SelectedMarkup = oldMarkUp;
                if (editor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedCollectorHost.ReconfigureFromXml(editor.SelectedMarkup);
                    txtName.Text = SelectedCollectorHost.Name;
                    LoadControls();
                    LoadEditControls();
                    ((MainForm)ParentWindow).UpdateCollector(SelectedCollectorHost, true);
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

        #region Agents edit
        private void CreateAgent()
        {
            //Display a list of existing types of agents/by template...
            //Once type is selected add new Agent to treelistview
            //  if from template use Name as specified in template
            //  else use collector agent type (without the word Collector)
            //    and show new agent entry dialog
            SelectNewEntityType selectNewAgentType = new SelectNewEntityType();
            if (selectNewAgentType.ShowCollectorAgentSelection() == System.Windows.Forms.DialogResult.OK)
            {
                ICollector agent = (ICollector)selectNewAgentType.SelectedAgent;
                agent.Enabled = true;
                if (agent.Name == null || agent.Name.Trim().Length == 0)
                    agent.Name = agent.AgentClassDisplayName;//.Replace("Collector", "").Trim();

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
                            TreeListViewItem tlvAgentEntry = new TreeListViewItem(DetailEditor.SelectedEntry.Description);
                            tlvAgentEntry.ImageIndex = 2;
                            tlvAgentEntry.SubItems.Add(DetailEditor.SelectedEntry.TriggerSummary);
                            tlvAgentEntry.Tag = DetailEditor.SelectedEntry;
                            tlviCurrent.Items.Add(tlvAgentEntry);
                            tlviCurrent.Expand();
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
                    if (tlviCurrent.Tag is ICollector)
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

                            foreach (ListViewItem lvi in lvwConfigVars.Items)
                            {
                                DetailEditor.ConfigVariables.Add(((ConfigVariable)lvi.Tag).Clone());
                            }
                            //if (HostingMonitorPack != null && HostingMonitorPack.ConfigVariables != null)
                            //    DetailEditor.ConfigVariables.AddRange(HostingMonitorPack.GetAllParentConfigVars().ToArray());
                            if (SelectedCollectorHost != null)
                                DetailEditor.ConfigVariables.AddRange(SelectedCollectorHost.GetAllParentConfigVars().ToArray());

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
                            agentsTreeListView.Items.Remove(tlvi);
                        }
                        else if (tlvi.Tag is ICollectorConfigEntry && tlvi.Parent != null && tlvi.Parent.Tag is ICollector)
                        {
                            tlvi.Parent.Items.Remove(tlvi);
                        }
                    }
                }
            }
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
        private void EnableAgentContextMenuItems()
        {
            bool addAgentEntry = false;
            bool moveUpEnabled = false;
            bool moveDownEnabled = false;
            bool agentEnabledEnabled = false;
            bool agentEDisabledEnabled = false;
            bool agentEntrySelected = false;
            bool isAgentPrimaryUI = false;
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
                    agentEntrySelected = true;
                    ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                    ICollector moveAgent = (ICollector)moveItem.Parent.Tag;
                    ICollectorConfig entryConfig = (ICollectorConfig)moveAgent.AgentConfig;
                    int index = entryConfig.Entries.IndexOf(moveConfigEntry);
                    moveUpEnabled = index > 0;
                    moveDownEnabled = index < entryConfig.Entries.Count - 1;
                    addAgentEntry = false;
                    isAgentPrimaryUI = moveConfigEntry.PrimaryUIValue;
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
                        isAgentPrimaryUI = true;
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
            setAsDisplayValueToolStripMenuItem.Enabled = agentEntrySelected && !isAgentPrimaryUI;
            enableAgentToolStripButton.Enabled = agentEnabledEnabled;
            disableAgentToolStripButton.Enabled = agentEDisabledEnabled;
            enableToolStripMenuItem.Enabled = agentEnabledEnabled || agentEDisabledEnabled;
            this.enableToolStripMenuItem.Image = agentEnabledEnabled ? Properties.Resources._131 : Properties.Resources._133;
            this.enableToolStripMenuItem.Text = agentEnabledEnabled ? "Enable" : "Disable";
        }
        private bool SetEditingCollectorHost()
        {
            bool success = false;
            try
            {
                editingCollectorHost.Name = txtName.Text;
                editingCollectorHost.Enabled = SelectedCollectorHost.Enabled; //current value
                editingCollectorHost.ExpandOnStartOption = (ExpandOnStartOption)cboExpandOnStartOption.SelectedIndex;
                editingCollectorHost.AgentCheckSequence = (AgentCheckSequence)agentCheckSequenceToolStripComboBox.SelectedIndex;
                editingCollectorHost.Notes = txtAdditionalNotes.Text;
                editingCollectorHost.ParentCollectorId = SelectedCollectorHost.ParentCollectorId;
                editingCollectorHost.ChildCheckBehaviour = (ChildCheckBehaviour)cboChildCheckBehaviour.SelectedIndex;

                //Remote agents
                editingCollectorHost.EnableRemoteExecute = chkRemoteAgentEnabled.Checked;
                editingCollectorHost.ForceRemoteExcuteOnChildCollectors = chkForceRemoteExcuteOnChildCollectors.Checked;
                editingCollectorHost.RemoteAgentHostAddress = cboRemoteAgentServer.Text;
                editingCollectorHost.RemoteAgentHostPort = (int)remoteportNumericUpDown.Value;
                editingCollectorHost.BlockParentOverrideRemoteAgentHostSettings = chkBlockParentRHOverride.Checked && !chkRemoteAgentEnabled.Checked;
                editingCollectorHost.RunLocalOnRemoteHostConnectionFailure = chkRunLocalOnRemoteHostConnectionFailure.Checked;

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
                editingCollectorHost.CorrectiveScriptOnWarningMinimumRepeatTimeMin = (int)numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Value;
                editingCollectorHost.CorrectiveScriptOnErrorMinimumRepeatTimeMin = (int)numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Value;
                editingCollectorHost.RestorationScriptMinimumRepeatTimeMin = (int)numericUpDownRestorationScriptMinimumRepeatTimeMin.Value;

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
                    foreach (string line in txtCategories.Lines)
                    {
                        if (line.Length > 0)
                        {
                            editingCollectorHost.Categories.Add(line);
                        }
                    }
                }
                editingCollectorHost.ExcludeFromMetrics = chkExcludeFromMetrics.Checked;
                SetEditingCollectorHostAgents();
                SetEditingActionScripts();

                if (cmdSetNoteText.Enabled)
                    cmdSetNoteText_Click(null, null);
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving the config!\r\n" + ex.Message, "Saving config", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return success;
        }
        private void SetEditingActionScripts()
        {
            editingCollectorHost.ActionScripts.Clear();
            foreach(ListViewItem lvi in lvwActionScriptsEdit.Items)
            {
                if (lvi.Tag is ActionScript)
                {
                    editingCollectorHost.ActionScripts.Add((ActionScript)lvi.Tag);
                }
            }
        }
        private void SetCurrentAgentEntryPrimaryUI()
        {
            if (agentsTreeListView.SelectedItems.Count == 1)
            {
                TreeListViewItem currentLviItem = agentsTreeListView.SelectedItems[0];
                if (currentLviItem.Tag is ICollectorConfigEntry)
                {
                    ICollectorConfigEntry currentConfigEntry = (ICollectorConfigEntry)currentLviItem.Tag;

                    //First reset all (including current) agent entries to No Primary UI 
                    foreach (TreeListViewItem tlvi in agentsTreeListView.Items)
                    {
                        foreach (TreeListViewItem tlviEntries in tlvi.Items)
                        {
                            ICollectorConfigEntry entry = (ICollectorConfigEntry)tlviEntries.Tag;
                            tlviEntries.Font = new Font(agentsTreeListView.Font, FontStyle.Regular);
                            entry.PrimaryUIValue = false;    
                        }                        
                    }
                    currentConfigEntry.PrimaryUIValue = true;
                    currentLviItem.Font = new Font(agentsTreeListView.Font, FontStyle.Bold);
                }
            }
        }

        private void SetEditingCollectorHostAgents()
        {
            editingCollectorHost.CollectorAgents.Clear();
            foreach (TreeListViewItem tlvi in agentsTreeListView.Items)
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
        private void agentsTreeListView_BeforeLabelEdit(object sender, TreeListViewBeforeLabelEditEventArgs e)
        {
            if (!(e.Item.Tag is ICollector && e.ColumnIndex == 0))
            {
                e.Cancel = true;
            }
        }
        private void agentsTreeListView_DoubleClick(object sender, EventArgs e)
        {
            EditAgent();
        }
        private void agentsTreeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableAgentContextMenuItems();
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
                    TreeListViewItem prevItem = moveItem.PrevVisibleItem;
                    if (prevItem != null)
                    {
                        ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                        ICollectorConfigEntry prevConfigEntry = (ICollectorConfigEntry)prevItem.Tag;
                        prevItem.Tag = null;
                        prevItem.Tag = moveConfigEntry;
                        moveItem.Tag = prevConfigEntry;
                        SetEditingCollectorHostAgents();

                        LoadAgents();
                    }
                }
            }
        }
        private void moveDownAgentToolStripButton_Click(object sender, EventArgs e)
        {
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
                    TreeListViewItem nextItem = moveItem.NextVisibleItem;
                    if (nextItem != null)
                    {
                        ICollectorConfigEntry moveConfigEntry = (ICollectorConfigEntry)moveItem.Tag;
                        ICollectorConfigEntry nextConfigEntry = (ICollectorConfigEntry)nextItem.Tag;
                        nextItem.Tag = null;
                        nextItem.Tag = moveConfigEntry;
                        moveItem.Tag = nextConfigEntry;
                        SetEditingCollectorHostAgents();

                        LoadAgents();
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
        private void setAsDisplayValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetCurrentAgentEntryPrimaryUI();
        }
        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableToolStripMenuItem.Text == "Enable")
            {
                enableAgentToolStripButton_Click(null, null);
            }
            else
            {
                disableAgentToolStripButton_Click(null, null);
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

        #region Change tracking
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = (txtName.Text.Length > 0) && 
                    ((!chkRemoteAgentEnabled.Checked && !chkForceRemoteExcuteOnChildCollectors.Checked) || cboRemoteAgentServer.Text.Length > 0);
            
        }
        private void chkRemoteAgentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            cboRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            remoteportNumericUpDown.Enabled = chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked;
            chkBlockParentRHOverride.Enabled = !chkRemoteAgentEnabled.Checked;
            chkRunLocalOnRemoteHostConnectionFailure.Enabled = chkRemoteAgentEnabled.Checked;
            if (chkRemoteAgentEnabled.Checked)
                chkBlockParentRHOverride.Checked = false;
            cmdRemoteAgentTest.Enabled = (chkRemoteAgentEnabled.Checked || chkForceRemoteExcuteOnChildCollectors.Checked) && cboRemoteAgentServer.Text.Length > 0;
            CheckOkEnabled();
        }
        private void chkForceRemoteExcuteOnChildCollectors_CheckedChanged(object sender, EventArgs e)
        {
            chkRemoteAgentEnabled_CheckedChanged(null, null);
        }
        private void cboRemoteAgentServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkRemoteAgentEnabled_CheckedChanged(null, null);
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
        private void cboRemoteAgentServer_TextChanged(object sender, EventArgs e)
        {
            chkRemoteAgentEnabled_CheckedChanged(null, null);
        }
        private void chkRunAsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtRunAs.Enabled = chkRunAsEnabled.Checked;
            cmdTestRunAs.Enabled = chkRunAsEnabled.Checked;
        }
        #endregion

        #region Remote hosts
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
        #endregion

        #region RunAs
        private void txtRunAs_TextChanged(object sender, EventArgs e)
        {
            cmdTestRunAs.Enabled = txtRunAs.Text.Length > 0 && HostingMonitorPack != null;
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

        #region Corrective scripts
        private void chkCorrectiveScriptDisabled_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownCorrectiveScriptOnWarningMinimumRepeatTimeMin.Enabled = !chkCorrectiveScriptDisabled.Checked;
            numericUpDownCorrectiveScriptOnErrorMinimumRepeatTimeMin.Enabled = !chkCorrectiveScriptDisabled.Checked;
            numericUpDownRestorationScriptMinimumRepeatTimeMin.Enabled = !chkCorrectiveScriptDisabled.Checked;
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
                LoadServiceWindows();                
            }
        }
        #endregion

        #region Alert texts
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
        private void txtNotesText_TextChanged(object sender, EventArgs e)
        {
            lblNoteTextChangeIndicator.Text = "Alert Texts*";
            cmdSetNoteText.Enabled = true;
        }
        private void cmdSetNoteText_Click(object sender, EventArgs e)
        {
            if (cboTextType.SelectedIndex == 0)
                editingCollectorHost.AlertHeaderText = txtNotesText.Text;
            else if (cboTextType.SelectedIndex == 1)
                editingCollectorHost.AlertFooterText = txtNotesText.Text;
            else if (cboTextType.SelectedIndex == 2)
                editingCollectorHost.ErrorAlertText = txtNotesText.Text;
            else if (cboTextType.SelectedIndex == 3)
                editingCollectorHost.WarningAlertText = txtNotesText.Text;
            else if (cboTextType.SelectedIndex == 4)
                editingCollectorHost.GoodAlertText = txtNotesText.Text;
            lblNoteTextChangeIndicator.Text = "Alert Texts";
            cmdSetNoteText.Enabled = false;
        }
        #endregion

        #endregion

        #region Context menus
        private void rawViewCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void rawViewSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.SelectAll();
        }
        private void clipboardExportAsCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedCollectorHost.ExportHistoryToCSV(true));
        }
        private void asXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(SelectedCollectorHost.ExportHistoryToXML());
        }
        #endregion

        #region Action scripts
        private void lvwActionScriptsEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            editActionScriptToolStripButton.Enabled = lvwActionScriptsEdit.SelectedItems.Count == 1;
            deleteActionScriptToolStripButton.Enabled = lvwActionScriptsEdit.SelectedItems.Count > 0;
            runToolStripButton.Enabled = lvwActionScriptsEdit.SelectedItems.Count > 0;
        }
        private void lvwActionScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdRunActionScript.Enabled = lvwActionScripts.SelectedItems.Count > 0;
        }
        private void addActionScriptToolStripButton_Click(object sender, EventArgs e)
        {
            EditActionScript editActionScript = new EditActionScript();
            if (editActionScript.ShowDialog() == DialogResult.OK)
            {
                SelectedCollectorHost.ActionScripts.Add(editActionScript.SelectedActionScript);
                ListViewItem lvi = new ListViewItem(editActionScript.SelectedActionScript.Name);
                lvi.SubItems.Add(editActionScript.SelectedActionScript.ScriptType.ToString());
                lvi.SubItems.Add(editActionScript.SelectedActionScript.RunAdminMode ? "Yes" : "No");
                lvi.SubItems.Add(editActionScript.SelectedActionScript.IsRestorationScript ? "Yes" : "No");
                lvi.SubItems.Add(editActionScript.SelectedActionScript.IsWarningCorrectiveScript ? "Yes" : "No");
                lvi.SubItems.Add(editActionScript.SelectedActionScript.IsErrorCorrectiveScript ? "Yes" : "No");
                lvi.SubItems.Add(editActionScript.SelectedActionScript.Description);
                lvi.Tag = editActionScript.SelectedActionScript;
                lvwActionScriptsEdit.Items.Add(lvi);
                LoadActionScripts();
            }
        }
        private void editActionScriptToolStripButton_Click(object sender, EventArgs e)
        {
            if (lvwActionScriptsEdit.SelectedItems.Count == 1 && lvwActionScriptsEdit.SelectedItems[0].Tag is ActionScript)
            {
                ListViewItem lvi = lvwActionScriptsEdit.SelectedItems[0];

                EditActionScript editActionScript = new EditActionScript();
                editActionScript.SelectedActionScript = (ActionScript)lvi.Tag;
                if (editActionScript.ShowDialog() == DialogResult.OK)
                {                    
                    lvi.Text = editActionScript.SelectedActionScript.Name;
                    lvi.SubItems[1].Text = editActionScript.SelectedActionScript.ScriptType.ToString();
                    lvi.SubItems[2].Text = editActionScript.SelectedActionScript.RunAdminMode ? "Yes" : "No";
                    lvi.SubItems[3].Text = editActionScript.SelectedActionScript.IsRestorationScript ? "Yes" : "No";
                    lvi.SubItems[4].Text = editActionScript.SelectedActionScript.IsWarningCorrectiveScript ? "Yes" : "No";
                    lvi.SubItems[5].Text = editActionScript.SelectedActionScript.IsErrorCorrectiveScript ? "Yes" : "No";
                    lvi.SubItems[6].Text = editActionScript.SelectedActionScript.Description;
                    lvi.Tag = editActionScript.SelectedActionScript;
                    LoadActionScripts();
                }
            }
        }
        private void deleteActionScriptToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the seleted action script(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvwActionScriptsEdit.SelectedItems)
                {
                    lvwActionScriptsEdit.Items.Remove(lvi);
                }
                LoadActionScripts();
            }
        }
        private void runToolStripButton_Click(object sender, EventArgs e)
        {
            RunSelectedActionScripts(lvwActionScriptsEdit);            
        }
        private void RunSelectedActionScripts(ListViewEx lvw, bool withPause = false)
        {
            try
            {
                if (lvw.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in lvw.SelectedItems)
                    {
                        ActionScript asc = (ActionScript)lvi.Tag;
                        asc.Run(withPause);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running script!\r\n" + ex.Message, "Run script", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmdRunActionScript_Click(object sender, EventArgs e)
        {
            RunSelectedActionScripts(lvwActionScripts);
        }
        private void lvwActionScriptsEdit_DoubleClick(object sender, EventArgs e)
        {
            RunSelectedActionScripts(lvwActionScriptsEdit);
        }

        private void lvwActionScripts_DoubleClick(object sender, EventArgs e)
        {
            RunSelectedActionScripts(lvwActionScripts);
        }

        private void runActionScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionScriptListContextSource != null && actionScriptListContextSource is ListViewEx)
            {
                if (((ListViewEx)actionScriptListContextSource).Name == "lvwActionScripts")
                {
                    RunSelectedActionScripts(lvwActionScripts);
                }
                else if (((ListViewEx)actionScriptListContextSource).Name == "lvwActionScriptsEdit")
                {
                    RunSelectedActionScripts(lvwActionScriptsEdit);
                }
            }
        }
        private void runActionScriptWithPauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionScriptListContextSource != null && actionScriptListContextSource is ListViewEx)
            {
                if (((ListViewEx)actionScriptListContextSource).Name == "lvwActionScripts")
                {
                    RunSelectedActionScripts(lvwActionScripts, true);
                }
                else if (((ListViewEx)actionScriptListContextSource).Name == "lvwActionScriptsEdit")
                {
                    RunSelectedActionScripts(lvwActionScriptsEdit, true);
                }
            }
        }
        private Control actionScriptListContextSource = null;
        private void actionScriptsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            actionScriptListContextSource = actionScriptsContextMenuStrip.SourceControl;
        }





        #endregion

        #region Graph events
        private void collectorTimeGraph_GraphClicked(object sender, EventArgs e)
        {
            ShowGraphSelection();
        }
        private void collectorTimeGraph_ClosestPointSelectedChanged(string seriesName, HenIT.Windows.Controls.Graphing.TimeValue tv)
        {
            ShowGraphSelection(seriesName, tv);
        } 
        #endregion

        private void ShowGraphSelection(string seriesName = "", TimeValue tv = null)
        {
            if (tv != null && collectorTimeGraph.LastClickedLocation == null)
            {
                collectorTimeGraph.LastClickedLocation = tv;
            }
        }
        private void SetAxisType()
        {
            if (linearGraphTypeToolStripMenuItem.Checked)
            {
                collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Standard;
                collectorTimeGraph.SetAutoMinMaxDateTimes();
            }
            else
            {
                collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            }
            collectorTimeGraph.RefreshGraph();
        }

        #region Graph Context menu events
        private void graphContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            linearGraphTypeToolStripMenuItem.Checked = collectorTimeGraph.GraphVerticalAxisType == HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Standard;
            logarithmicGraphTypeToolStripMenuItem.Checked = collectorTimeGraph.GraphVerticalAxisType == HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            graphHeaderVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowGraphHeader;
            legendVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowLegendText;
            graphSelectionbarVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowSelectionBar;
            graphHighlightClickedSeriesToolStripMenuItem.Checked = collectorTimeGraph.HighlightClickedSeries;
            graphFillAreaBelowSeriesEnabledToolStripMenuItem.Checked = collectorTimeGraph.FillAreaBelowGraph;
            graphHorisonalGridLinesVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowHorisontalGridlines;
            graphVerticalGridLinesVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowVerticalGridLines;
        }
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphColorSettings graphColorSettings = new GraphColorSettings();
            graphColorSettings.GraphSettings = collectorTimeGraph.GetGraphSettings();
            graphColorSettings.GraphSettings.SeriesColors.AddRange((from Color s in seriesColors select GraphSettings.ConvertColorToName(s)));

            //graphColorSettings.InitializeGraphSettings();
            //graphColorSettings.GraphSettings.SeriesColors.AddRange((from string s in Properties.Settings.Default.GraphLineColors select s));
            //graphColorSettings.GraphSettings.BackgroundColor1 = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphBackgroundColor1);
            //graphColorSettings.GraphSettings.BackgroundColor2 = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphBackgroundColor2);
            //graphColorSettings.GraphSettings.GridColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphGridColor);
            //graphColorSettings.GraphSettings.AxisLabelsColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphAxisLabelsColor);
            //graphColorSettings.GraphSettings.SelectionBarColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphSelectionBarColor);
            //graphColorSettings.GraphSettings.GraphType = Properties.Settings.Default.GraphDefaultType;
            //graphColorSettings.GraphSettings.GradientDirection = Properties.Settings.Default.GraphGradientDirection;
            //graphColorSettings.GraphSettings.ClosestClickedValueType = Properties.Settings.Default.GraphClosestClickedValueType;
            //graphColorSettings.GraphSettings.ClosestClickedValueColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphClosestClickedValueColor);
            //graphColorSettings.GraphSettings.HeaderVisible = Properties.Settings.Default.GraphHeaderVisible;
            //graphColorSettings.GraphSettings.FooterVisible = Properties.Settings.Default.GraphLegendVisible;
            //graphColorSettings.GraphSettings.HorisontalGridLinesVisible = Properties.Settings.Default.GraphHorisontalGridLinesVisible;
            //graphColorSettings.GraphSettings.VerticalGridLinesVisible = Properties.Settings.Default.GraphVerticalGridLinesVisible;
            //graphColorSettings.GraphSettings.SelectionBarVisible = Properties.Settings.Default.GraphSelectionBarVisible;
            //graphColorSettings.GraphSettings.HighlightClickedSeriesVisible = Properties.Settings.Default.GraphHighlightClickedSeriesVisible;
            //graphColorSettings.GraphSettings.EnableFillAreaBelowSeries = Properties.Settings.Default.GraphEnableFillAreaBelowSeries;
            //graphColorSettings.GraphSettings.FillAreaBelowSeriesAlpha = Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha;

            //graphColorSettings.GraphSettings.GridColor = Properties.Settings.Default.GraphGridColor.Name;
            if (graphColorSettings.ShowDialog() == DialogResult.OK)
            {
                collectorTimeGraph.SetFromGraphSettings(graphColorSettings.GraphSettings);
                seriesColors = new List<Color>();
                seriesColors.AddRange((from string colorName in graphColorSettings.GraphSettings.SeriesColors
                                       select GraphSettings.ConvertColorFromName(colorName)));

                //Properties.Settings.Default.GraphLineColors = new System.Collections.Specialized.StringCollection();
                //Properties.Settings.Default.GraphLineColors.AddRange(graphColorSettings.GraphSettings.SeriesColors.ToArray());
                //Properties.Settings.Default.GraphBackgroundColor1 = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.BackgroundColor1);
                //Properties.Settings.Default.GraphBackgroundColor2 = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.BackgroundColor2);
                //Properties.Settings.Default.GraphGridColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.GridColor);
                //Properties.Settings.Default.GraphAxisLabelsColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.AxisLabelsColor);
                //Properties.Settings.Default.GraphSelectionBarColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.SelectionBarColor);
                //Properties.Settings.Default.GraphDefaultType = graphColorSettings.GraphSettings.GraphType;
                //Properties.Settings.Default.GraphGradientDirection = graphColorSettings.GraphSettings.GradientDirection;
                //Properties.Settings.Default.GraphClosestClickedValueType = graphColorSettings.GraphSettings.ClosestClickedValueType;
                //Properties.Settings.Default.GraphClosestClickedValueColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.ClosestClickedValueColor);
                //Properties.Settings.Default.GraphHeaderVisible = graphColorSettings.GraphSettings.HeaderVisible;
                //Properties.Settings.Default.GraphLegendVisible = graphColorSettings.GraphSettings.FooterVisible;
                //Properties.Settings.Default.GraphHorisontalGridLinesVisible = graphColorSettings.GraphSettings.HorisontalGridLinesVisible;
                //Properties.Settings.Default.GraphVerticalGridLinesVisible = graphColorSettings.GraphSettings.VerticalGridLinesVisible;
                //Properties.Settings.Default.GraphSelectionBarVisible = graphColorSettings.GraphSettings.SelectionBarVisible;
                //Properties.Settings.Default.GraphHighlightClickedSeriesVisible = graphColorSettings.GraphSettings.HighlightClickedSeriesVisible;
                //Properties.Settings.Default.GraphEnableFillAreaBelowSeries = graphColorSettings.GraphSettings.EnableFillAreaBelowSeries;
                //Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha = graphColorSettings.GraphSettings.FillAreaBelowSeriesAlpha;

                //collectorTimeGraph.GraphVerticalAxisType = (GraphVerticalAxisType)Properties.Settings.Default.GraphDefaultType;
                //LoadGraphColors();
                LoadControls();
            }
        }
        private void linearGraphTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logarithmicGraphTypeToolStripMenuItem.Checked = !linearGraphTypeToolStripMenuItem.Checked;
            SetAxisType();
        }
        private void logarithmicGraphTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearGraphTypeToolStripMenuItem.Checked = !logarithmicGraphTypeToolStripMenuItem.Checked;            
            SetAxisType();
        }
        private void graphGradientColor1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.BackgroundGradientColor1;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.BackgroundGradientColor1 = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphGradientColor2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.BackgroundGradientColor2;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.BackgroundGradientColor2 = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void swapGraphGradientColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color backgroundGradientColor1 = collectorTimeGraph.BackgroundGradientColor1;
            Color backgroundGradientColor2 = collectorTimeGraph.BackgroundGradientColor2;
            collectorTimeGraph.BackgroundGradientColor1 = backgroundGradientColor2;
            collectorTimeGraph.BackgroundGradientColor2 = backgroundGradientColor1;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionForwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionBackwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.GridColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.GridColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphAxisLabelColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.AxisLabelColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.AxisLabelColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphSelectionBarColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.TimeSelectionColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.TimeSelectionColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphClosestClickedColorSameAsSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.SeriesColor;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphClosestClickedColorInvertedColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.InvertedColor;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphClosestClickedColorCustomColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.CustomColor;
            Color selectedColor = collectorTimeGraph.ClosestClickedValueCustomColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.ClosestClickedValueCustomColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphHeaderVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowGraphHeader = graphHeaderVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void legendVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowLegendText = legendVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphHorisonalGridLinesVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowHorisontalGridlines = graphHorisonalGridLinesVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphVerticalGridLinesVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowVerticalGridLines = graphVerticalGridLinesVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphSelectionbarVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowSelectionBar = graphSelectionbarVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphHighlightClickedSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.HighlightClickedSeries = graphHighlightClickedSeriesToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaBelowSeriesEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraph = graphFillAreaBelowSeriesEnabledToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 16;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 32;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha48ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 48;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 64;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha128ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 128;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha192ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 192;
            collectorTimeGraph.RefreshGraph();
        }
        private void exportGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG files|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap exportedGraph = collectorTimeGraph.SaveToBitmap();
                exportedGraph.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                exportedGraph.Dispose();
            }
            
        }

        #endregion


    }
}
