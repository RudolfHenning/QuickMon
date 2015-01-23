﻿using HenIT.RTF;
using QuickMon.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public partial class CollectorStatusViewer : Form
    {
        public CollectorStatusViewer()
        {
            InitializeComponent();
        }

        public CollectorHost SelectedCollectorHost { get; set; }

        private CollectorAgentsDetailViewer detailViewer = null;

        private void CollectorStatusViewer_Load(object sender, EventArgs e)
        {
            lvwProperties.AutoResizeColumnIndex = 1;
            lvwProperties.AutoResizeColumnEnabled = true;
            lvwStatistics.AutoResizeColumnIndex = 1;
            lvwStatistics.AutoResizeColumnEnabled = true;
            splitContainer1.Panel2Collapsed = true;
        }

        public void RefreshStats()
        {
            if (SelectedCollectorHost != null)
            {
                txtName.Text = SelectedCollectorHost.Name;
                Text = "Collector Status Viewer - " + SelectedCollectorHost.Name;
                cmdCollectorHostDetailViewer.Enabled = SelectedCollectorHost.CollectorAgents.Count > 0;

                if (SelectedCollectorHost.IsEnabledNow())
                {
                    if (SelectedCollectorHost.CurrentState == null)
                    {
                        lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.helpbwy16x16;
                        lblCollectorHostStatusText.Text = "N/A";
                    }
                    else
                    {
                        lblCollectorHostStatusText.Text = SelectedCollectorHost.CurrentState.State.ToString();
                        if (SelectedCollectorHost.CurrentState.State == CollectorState.Good)
                            lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.ok16x16;
                        else if (SelectedCollectorHost.CurrentState.State == CollectorState.Warning)
                            lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.triang_yellow16x16;
                        else if (SelectedCollectorHost.CurrentState.State == CollectorState.Error)
                            lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.stop16x16;
                        else
                            lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.helpbwy16x16;
                    }
                    if (SelectedCollectorHost.AgentCheckSequence != AgentCheckSequence.All)
                    {
                        lblCollectorHostStatusText.Text += " (" + SelectedCollectorHost.AgentCheckSequence.ToString() + ")";
                    }
                }
                else
                {
                    lblCollectorHostStatus.Image = global::QuickMon.Properties.Resources.ForbiddenGray16x16;
                    lblCollectorHostStatusText.Text = "Disabled";
                }

                LoadAgentStates();

                AddUpdateListViewItem(lvwProperties, "General", "Enabled", (SelectedCollectorHost.Enabled ? "Yes" : "No") + (SelectedCollectorHost.ServiceWindows.IsInTimeWindow() ? "" : " (Out of service window)"));
                AddUpdateListViewItem(lvwProperties, "General", "Agent count", SelectedCollectorHost.CollectorAgents.Count.ToString());
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state", SelectedCollectorHost.CurrentState.State.ToString());
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state time", FormatDate(SelectedCollectorHost.CurrentState.Timestamp));
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state check duration (ms)", SelectedCollectorHost.CurrentState.CallDurationMS.ToString());
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state details", SelectedCollectorHost.CurrentState.ReadAllRawDetails());
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state Executed on", SelectedCollectorHost.CurrentState.ExecutedOnHostComputer);
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state Alerts raised", SelectedCollectorHost.CurrentState.AlertsRaised.Count > 0 ? "Yes" : "No");
                AddUpdateListViewItem(lvwProperties, "Current state", "Current state Alerts details", SelectedCollectorHost.CurrentState.AlertsRaised, SelectedCollectorHost.CurrentState.AlertsRaised.Count > 0);

                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.State.ToString());
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state time", SelectedCollectorHost.PreviousState == null ? "N/A" : FormatDate(SelectedCollectorHost.PreviousState.Timestamp));
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state check duration (ms)", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.CallDurationMS.ToString());
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state details", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.ReadAllRawDetails());
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state Executed on", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.ExecutedOnHostComputer);
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state Alerts raised", SelectedCollectorHost.PreviousState == null ? "N/A" : SelectedCollectorHost.PreviousState.AlertsRaised.Count > 0 ? "Yes" : "No");
                AddUpdateListViewItem(lvwProperties, "Previous state", "Previous state Alerts details", SelectedCollectorHost.PreviousState == null ? new List<string>() : SelectedCollectorHost.PreviousState.AlertsRaised, SelectedCollectorHost.PreviousState != null);

                bool remoteHostEnabled = SelectedCollectorHost.EnableRemoteExecute || (SelectedCollectorHost.OverrideRemoteAgentHost && !SelectedCollectorHost.BlockParentOverrideRemoteAgentHostSettings);
                AddUpdateListViewItem(lvwProperties, "Remote agent host", "Enabled", remoteHostEnabled ? "Yes" : "No");
                AddUpdateListViewItem(lvwProperties, "Remote agent host", "Address", SelectedCollectorHost.ToRemoteHostName(),remoteHostEnabled);

                #region Polling metrics
                //AddUpdateListViewItem(lvwStatistics, "Polling metrics", "# of times polled", SelectedCollectorHost.PollCount.ToString());
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "# of times refreshed", SelectedCollectorHost.RefreshCount.ToString());
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Polling override enabled", SelectedCollectorHost.EnabledPollingOverride ? "Yes" : "No");
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Poll frequency sliding enabled", SelectedCollectorHost.EnablePollFrequencySliding ? "Yes" : "No", SelectedCollectorHost.EnabledPollingOverride);
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
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Current poll frequency (Sec)", currentPollFreq.ToString(), SelectedCollectorHost.EnabledPollingOverride);
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "First polled time", FormatDate(SelectedCollectorHost.FirstStateUpdate));
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "# of times good states", SelectedCollectorHost.GoodStateCount.ToString());
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "# of times warning states", SelectedCollectorHost.WarningStateCount.ToString());
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "# of times error states", SelectedCollectorHost.ErrorStateCount.ToString());
                AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last attempted polling time", FormatDate(SelectedCollectorHost.LastStateCheckAttemptBegin));

                if (SelectedCollectorHost.LastGoodState != null)
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last good state time", FormatDate(SelectedCollectorHost.LastGoodState.Timestamp));
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last good state details", SelectedCollectorHost.LastGoodState.ReadAllRawDetails());
                }
                else
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last good state time", "N/A");
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last good state details", "N/A");
                }
                if (SelectedCollectorHost.LastWarningState != null)
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last warning state time", FormatDate(SelectedCollectorHost.LastWarningState.Timestamp));
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last warning state details", SelectedCollectorHost.LastWarningState.ReadAllRawDetails());
                }
                else
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last warning state time", "N/A");
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last warning state details", "N/A");
                }
                if (SelectedCollectorHost.LastErrorState != null)
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last error state time", FormatDate(SelectedCollectorHost.LastErrorState.Timestamp));
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last error state details", SelectedCollectorHost.LastErrorState.ReadAllRawDetails());
                }
                else
                {
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last error state time", "N/A");
                    AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Last error state details", "N/A");
                } 
                #endregion

                #region History
                LoadCollectorStateHistory();                
                #endregion

                if (tabControl1.SelectedTab == currentStatusTabPage)
                    UpdateAgentsDetailView();
                if (tabControl1.SelectedTab == currentStatusTabPage2)
                    UpdateDetailView(lvwProperties);
                else if (tabControl1.SelectedTab == statisticsTabPage)
                    UpdateDetailView(lvwStatistics);
            }
        }

        private void LoadAgentStates()
        {
            lvwAgents.Items.Clear();
            if (SelectedCollectorHost != null && SelectedCollectorHost.CollectorAgents.Count > 0)
            {
                foreach (ICollector ca in SelectedCollectorHost.CollectorAgents)
                {
                    ListViewItem lvi = new ListViewItem(ca.Name);
                    lvi.SubItems.Add(ca.AgentClassDisplayName);
                    if (ca.CurrentState == null)
                        lvi.ImageIndex = 0;
                    else if (!ca.Enabled || ca.CurrentState == null)
                        lvi.ImageIndex = 4;
                    else if (ca.CurrentState.State == CollectorState.Good)
                        lvi.ImageIndex = 1;
                    else if (ca.CurrentState.State == CollectorState.Warning)
                        lvi.ImageIndex = 2;
                    else if (ca.CurrentState.State == CollectorState.Error)
                        lvi.ImageIndex = 3;
                    else if (ca.CurrentState.State == CollectorState.Disabled)
                        lvi.ImageIndex = 4;
                    else
                        lvi.ImageIndex = 0;

                    lvi.Tag = ca;
                    lvwAgents.Items.Add(lvi);
                }
            }
        }

        private void LoadCollectorStateHistory()
        {
            ListViewItem lvi;
            int totalAlertsRaised = 0;
            lvwHistory.Items.Clear();
            lvwHistory.BeginUpdate();
            try
            {
                foreach (MonitorState historyItem in (from h in SelectedCollectorHost.StateHistory
                                                      orderby h.Timestamp descending
                                                      select h))
                {

                    if (historyItem.State != CollectorState.NotAvailable)
                    {
                        lvi = new ListViewItem(FormatDate(historyItem.Timestamp));
                        lvi.SubItems.Add(historyItem.State.ToString());
                        lvi.SubItems.Add(historyItem.CallDurationMS.ToString());
                        lvi.SubItems.Add(historyItem.ReadAllRawDetails());
                        lvi.SubItems.Add(historyItem.ExecutedOnHostComputer);
                        lvi.SubItems.Add(historyItem.AlertsRaised.Count.ToString());
                        totalAlertsRaised += historyItem.AlertsRaised.Count;
                        if (historyItem.State == CollectorState.Good)
                            lvi.ImageIndex = 1;
                        else if (historyItem.State == CollectorState.Warning)
                            lvi.ImageIndex = 2;
                        else if (historyItem.State == CollectorState.Error)
                            lvi.ImageIndex = 3;
                        else
                            lvi.ImageIndex = 0;
                        lvi.Tag = historyItem;
                        lvwHistory.Items.Add(lvi);
                    }
                }
            }
            catch { }
            lvwHistory.EndUpdate();
            AddUpdateListViewItem(lvwStatistics, "Polling metrics", "Total alert count", totalAlertsRaised.ToString());
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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshStats();
        }

        #region Button events
        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            cmdViewDetails.Text = splitContainer1.Panel2Collapsed ? "ttt" : "uuu";
            splitContainer1.SplitterWidth = 8;
        }
        #endregion

        private void UpdateDetailView(ListView currentListView)
        {
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();
                if (currentListView.SelectedItems.Count > 0)
                {
                    int maxlen = 35;
                    foreach (ListViewItem lvi in currentListView.Items)
                    {
                        if (lvi.Text.Length + 2 > maxlen)
                            maxlen = lvi.Text.Length + 2;
                    }

                    foreach (ListViewItem lvi in currentListView.SelectedItems)
                    {
                        rtfBuilder.FontStyle(FontStyle.Bold).Append((lvi.Text + ":").PadRight(maxlen));
                        if (lvi.SubItems[1].Text.Contains("\r"))
                        {
                            rtfBuilder.AppendLine("");
                        }
                        else
                            rtfBuilder.Append("\t");
                        rtfBuilder.AppendLine(lvi.SubItems[1].Text.Trim('\r', '\n'));
                    }
                }
                rtxDetails.Rtf = rtfBuilder.ToString();
                rtxDetails.SelectionStart = 0;
                rtxDetails.SelectionLength = 0;
                rtxDetails.ScrollToCaret();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdateDetailViewHistory()
        {
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();
                ListViewEx currentListView;
                currentListView = lvwHistory;
                if (currentListView.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in currentListView.SelectedItems)
                    {
                        if (lvi.Tag is MonitorState)
                        {
                            MonitorState historyItem = (MonitorState)lvi.Tag;
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ");
                            rtfBuilder.AppendLine(lvi.Text);
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("State: ");
                            rtfBuilder.AppendLine(lvi.SubItems[1].Text);
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Duration: ");
                            rtfBuilder.AppendLine(lvi.SubItems[2].Text + " ms");
                            rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Details: ");
                            rtfBuilder.AppendLine(lvi.SubItems[3].Text.TrimEnd('\r', '\n'));
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Executed by: ");
                            rtfBuilder.AppendLine(lvi.SubItems[4].Text);
                            if (historyItem.AlertsRaised.Count > 0)
                            {
                                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Alerts: ");
                                foreach (string alertEntry in historyItem.AlertsRaised)
                                {
                                    rtfBuilder.AppendLine("  " + alertEntry);
                                }
                            }
                            rtfBuilder.AppendLine(new string('-', 80));
                        }
                    }
                }
                rtxDetails.Rtf = rtfBuilder.ToString();
                rtxDetails.SelectionStart = 0;
                rtxDetails.SelectionLength = 0;
                rtxDetails.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateAgentsDetailView()
        {
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();
                ListViewEx currentListView;
                currentListView = lvwAgents;
                if (currentListView.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem lvi in currentListView.SelectedItems)
                    {
                        if (lvi.Tag is ICollector)
                        {
                            ICollector ca = (ICollector)lvi.Tag;
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Agent name: ");
                            rtfBuilder.AppendLine(lvi.Text);
                            if (ca != null && ca.CurrentState != null)
                            {
                                rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ");
                                rtfBuilder.AppendLine(FormatDate(ca.CurrentState.Timestamp));
                                rtfBuilder.FontStyle(FontStyle.Bold).Append("State: ");
                                rtfBuilder.AppendLine(ca.CurrentState.State.ToString());
                                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Details: ");
                                rtfBuilder.AppendLine(ca.CurrentState.ReadAllRawDetails());
                            }
                            
                            rtfBuilder.AppendLine(new string('-', 80));
                        }
                    }
                }
                rtxDetails.Rtf = rtfBuilder.ToString();
                rtxDetails.SelectionStart = 0;
                rtxDetails.SelectionLength = 0;
                rtxDetails.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvwProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetailView(lvwProperties);
        }
        private void lvwStatistics_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetailView(lvwStatistics);
        }
        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDetailViewHistory();
        }
        private void lvwAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAgentsDetailView();
        }
        private void lvwAgents_DoubleClick(object sender, EventArgs e)
        {
            //Agent detail views
            // 1. Display window/tool that shows the details of the same resource query type 
            // 2. This calling window must retain some handle to the detail window so (1) only one instance is displayed and (2) it is closed when this window closes
            // 3. The displayed window/view must be able to make use of the remote host functionality as well...

            if (SelectedCollectorHost!= null && lvwAgents.SelectedItems.Count == 1)
            {
                ICollector agent = (ICollector)lvwAgents.SelectedItems[0].Tag;
                IWinFormsUI agentUI = RegisteredAgentUIMapper.GetUIClass(agent);
                bool remoteAgentHostEnabled = SelectedCollectorHost.EnableRemoteExecute || (SelectedCollectorHost.OverrideRemoteAgentHost && !SelectedCollectorHost.BlockParentOverrideRemoteAgentHostSettings);
                string remoteAgentHostAddress = SelectedCollectorHost.RemoteAgentHostAddress;
                int remoteAgentHostPort = SelectedCollectorHost.RemoteAgentHostPort;
                if (agentUI != null)
                {
                    agentUI.ShowAgentDetails(agent, remoteAgentHostEnabled, remoteAgentHostAddress, remoteAgentHostPort);
                }
                else
                {
                    MessageBox.Show("There is no registered viewer for this type of agent yet! Please contact the creator of the agent type.", "Agent type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void cmdCollectorHostDetailViewer_Click(object sender, EventArgs e)
        {
            if (detailViewer == null || !detailViewer.IsStillVisible())
            {
                detailViewer = new CollectorAgentsDetailViewer();
                detailViewer.SelectedCollectorHost = SelectedCollectorHost;
                detailViewer.Show();
            }
            else
            {
                if (detailViewer.WindowState == FormWindowState.Minimized)
                    detailViewer.WindowState = FormWindowState.Normal;
                detailViewer.Show();
                detailViewer.TopMost = true;
                detailViewer.TopMost = false;
            }
            detailViewer.RefreshViewer();
        }

        private void CollectorStatusViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (detailViewer != null)
                {
                    detailViewer.Close();
                    detailViewer = null;
                }
            }
            catch { }
        }
    }
}
