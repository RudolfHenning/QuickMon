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
    public partial class GlobalAgentHistory : Form, IChildWindowIdentity
    {
        public GlobalAgentHistory()
        {
            InitializeComponent();
        }

        public MonitorPack HostingMonitorPack { get; set; }

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

        #region State filters
        private readonly int stateFilterAll = 0;
        private readonly int stateFilterGood = 1;
        private readonly int stateFilterWarning = 2;
        private readonly int stateFilterError = 3;
        private readonly int stateFilterWarnErr = 4;
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
            if (HostingMonitorPack != null)
            {
                LoadControls();
            //    if (currentSelectedControl != "")
            //        UpdateRawView();
            }
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
            //tlvAgentStates.BorderStyle = BorderStyle.None;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            //Size = new Size(700, 500);
            Show();
        }
        #endregion

        #region Form events
        private void GlobalAgentHistory_Load(object sender, EventArgs e)
        {
            lvwHistory.AutoResizeColumnEnabled = true;
            cboStateFilter.SelectedIndex = 0;
            cbomaxResults.SelectedIndex = 2;
            agentStateSplitContainer.Panel2Collapsed = true;
        }
        private void GlobalAgentHistory_Shown(object sender, EventArgs e)
        {
            LoadControls();
        }
        private void GlobalAgentHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        } 
        #endregion

        private void LoadControls()
        {
            if (HostingMonitorPack != null)
            {
                //first make global list of all history items locally
                int maxResults = 100;
                int stateFilter = 0;
                try
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        maxResults = int.Parse(cbomaxResults.Text);
                        stateFilter = cboStateFilter.SelectedIndex;
                    });
                    
                }
                catch { }
                List<MonitorState> allMonitorStates = new List<MonitorState>();
                List<MonitorState> displayedMonitorStates = new List<MonitorState>();
                List<ListViewItem> listViewItems = new List<ListViewItem>();
                foreach (var collector in HostingMonitorPack.CollectorHosts)
                {
                    if (collector.CurrentState != null && collector.CollectorAgents.Count > 0 && IsInTextFilter(collector, txtFilter.Text))
                    {
                        if (IsInStateFilter(collector.CurrentState, stateFilter))
                            allMonitorStates.Add(FormatMonitorState(collector, collector.CurrentState));
                        foreach(MonitorState st in collector.StateHistory.OrderByDescending(st => st.Timestamp).Take(maxResults).ToList())
                        {
                            if (IsInStateFilter(st, stateFilter))
                                allMonitorStates.Add(FormatMonitorState(collector, st));
                        }
                        //collector.StateHistory.OrderByDescending(st=>st.Timestamp).Take(maxResults).ToList().ForEach(st => allMonitorStates.Add(FormatMonitorState(collector, st)));
                    }
                }

                displayedMonitorStates = allMonitorStates.OrderByDescending(st => st.Timestamp).Take(maxResults).ToList();
                foreach(MonitorState st in displayedMonitorStates)
                {
                    ListViewItem lvi = new ListViewItem(st.ForAgent) { Tag = st };
                    lvi.ImageIndex = GetNodeStateImageIndex(st.State);
                    lvi.SubItems.Add(st.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                    lvi.SubItems.Add(st.CurrentValue.ToString()); // ReadPrimaryOrFirstUIValue());
                    lvi.SubItems.Add(st.CallDurationMS.ToString());
                    lvi.SubItems.Add(st.AlertsRaised.Count.ToString());
                    listViewItems.Add(lvi);
                }

                this.Invoke((MethodInvoker)delegate ()
                {
                    this.Text = $"Global Collector History - {HostingMonitorPack.Name}";
                    
                    lvwHistory.Items.Clear();
                    lvwHistory.Items.AddRange(listViewItems.ToArray());
                    lastUpdateTimeToolStripStatusLabel.Text = "Updated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    countsToolStripStatusLabel.Text = lvwHistory.Items.Count.ToString() + " item(s)";
                });                
            }
        }

        private bool IsInTextFilter(CollectorHost collector, string textFilter)
        {
            if (textFilter.Trim().Length == 0)
                return true;
            else if (collector.Name.ToLower().Contains(textFilter.ToLower()))
                return true;
            else if (collector.CurrentState.ExecutedOnHostComputer != null && collector.CurrentState.ExecutedOnHostComputer.ToLower().Contains(textFilter.ToLower()))
                return true;
            else if (GetCollectorPath(collector).ToLower().Contains(textFilter.ToLower()))
                return true;
            else
                return false;
        }

        private bool IsInStateFilter(MonitorState mstate, int stateFilter)
        {
            if (stateFilter == 0)
                return true;
            else if (stateFilter == stateFilterGood && mstate.State == CollectorState.Good)
                return true;
            else if (stateFilter == stateFilterWarning && mstate.State == CollectorState.Warning)
                return true;
            else if (stateFilter == stateFilterError && (mstate.State == CollectorState.Error || mstate.State == CollectorState.ConfigurationError))
                return true;
            else if (stateFilter == stateFilterWarnErr && (mstate.State == CollectorState.Warning || mstate.State == CollectorState.Error || mstate.State == CollectorState.ConfigurationError))
                return true;
            else
                return false;            
        }

        private MonitorState FormatMonitorState(CollectorHost ch, MonitorState ms)
        {
            MonitorState displayMS = ms.Clone();
            string collectorPath = GetCollectorPath(ch);
            //foreach (CollectorHost pch in HostingMonitorPack.GetParentCollectorHostTree(ch))
            //{
            //    collectorPath = pch.Name + "/" + collectorPath;
            //}            
            //displayMS.ForAgent = collectorPath + ch.Name;
            displayMS.ForAgent = collectorPath;
            displayMS.CurrentValue = ms.ReadPrimaryOrFirstUIValue();
            displayMS.RawDetails = ms.ReadAllRawDetails();
            return displayMS;
        }
        private string GetCollectorPath(CollectorHost ch)
        {
            string collectorPath = "";
            foreach (CollectorHost pch in HostingMonitorPack.GetParentCollectorHostTree(ch))
            {
                collectorPath = pch.Name + "/" + collectorPath;
            }
            return collectorPath + ch.Name;
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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRawView();
        }

        private void UpdateRawView()
        {
            try
            {
                if (lvwHistory.SelectedItems.Count == 1)
                {
                    HenIT.RTF.RTFBuilder rtfBuilder = new HenIT.RTF.RTFBuilder();
                    object selectedObject = lvwHistory.SelectedItems[0].Tag;
                    if (selectedObject is MonitorState)
                    {
                        MonitorState ms = (MonitorState)selectedObject;
                        WriteMonitorState(rtfBuilder, ms);
                    }
                    rtxDetails.Rtf = rtfBuilder.ToString();
                    rtxDetails.SelectionStart = 0;
                    rtxDetails.SelectionLength = 0;
                    rtxDetails.ScrollToCaret();
                }

            }
            catch { }
        }
        private void WriteMonitorState(HenIT.RTF.RTFBuilder rtfBuilder, MonitorState ms)
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
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Value(s): ").FontStyle(FontStyle.Regular).AppendLine(ms.CurrentValue.ToString());
                if (ms.RawDetails != null && ms.RawDetails.Length > 0) //ms.State != CollectorState.Good && 
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

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = !agentStateSplitContainer.Panel2Collapsed;
        }

        private void rawViewCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void rawViewSelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.SelectAll();
        }

        private void txtFilter_EnterKeyPressed()
        {
            LoadControls();
        }
    }
}
