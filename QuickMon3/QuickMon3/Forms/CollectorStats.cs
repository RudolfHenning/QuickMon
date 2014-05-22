using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.RTF;

namespace QuickMon
{
    public partial class CollectorStats : Form
    {
        public CollectorStats()
        {
            InitializeComponent();
        }

        public CollectorEntry SelectedEntry { get; set; }

        private void CollectorStats_Load(object sender, EventArgs e)
        {
            RefreshCollectorStats();
            lvwProperties.AutoResizeColumnIndex = 1;
            lvwProperties.AutoResizeColumnEnabled = true;
            lvwHistory.AutoResizeColumnIndex = 3;
            lvwHistory.AutoResizeColumnEnabled = true;
            splitContainer1.Panel2Collapsed = true;
        }

        private void CollectorStats_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshCollectorStats();
            }
        }

        private void RefreshCollectorStats()
        {
            try
            {
                lvwProperties.Items.Clear();
                lvwHistory.Items.Clear();
                lvwProperties.Groups.Clear();
                lvwProperties.BeginUpdate();
                lvwHistory.BeginUpdate();
                if (SelectedEntry != null)
                {
                    this.Text = "Collector statistics - " + SelectedEntry.Name;
                    ListViewGroup lvgGeneral = new ListViewGroup("General");
                    lvwProperties.Groups.Add(lvgGeneral);

                    ListViewItem lvi = new ListViewItem("Collector Name");
                    lvi.SubItems.Add(SelectedEntry.Name);
                    lvi.Group = lvgGeneral;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Enabled");
                    lvi.SubItems.Add(SelectedEntry.Enabled ? "Yes" : "No");
                    lvi.Group = lvgGeneral;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Agent type");
                    lvi.SubItems.Add(SelectedEntry.CollectorRegistrationDisplayName);
                    lvi.Group = lvgGeneral;
                    lvwProperties.Items.Add(lvi);

                    ListViewGroup lvgCurrent = new ListViewGroup("Current state");
                    lvwProperties.Groups.Add(lvgCurrent);

                    lvi = new ListViewItem("Current state");
                    lvi.SubItems.Add(SelectedEntry.CurrentState.State.ToString());
                    lvi.Group = lvgCurrent;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Current state details");
                    lvi.SubItems.Add(SelectedEntry.CurrentState.RawDetails);
                    lvi.Group = lvgCurrent;
                    lvwProperties.Items.Add(lvi);                    

                    lvi = new ListViewItem("Last state update");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastStateUpdate));
                    lvi.Group = lvgCurrent;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last state check duration (ms)");
                    lvi.SubItems.Add(SelectedEntry.LastStateCheckDurationMS.ToString());
                    lvi.Group = lvgCurrent;
                    lvwProperties.Items.Add(lvi);

                    ListViewGroup lvgPrevious = new ListViewGroup("Previous state");
                    lvwProperties.Groups.Add(lvgPrevious);

                    lvi = new ListViewItem("Previous state");
                    lvi.SubItems.Add(SelectedEntry.LastMonitorState.State.ToString());
                    lvi.Group = lvgPrevious;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Previous state details");
                    lvi.SubItems.Add(SelectedEntry.LastMonitorState.RawDetails);
                    lvi.Group = lvgPrevious;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Previous state check duration (ms)");
                    lvi.SubItems.Add(SelectedEntry.LastMonitorState.CallDurationMS.ToString());
                    lvi.Group = lvgPrevious;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Previous state time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastMonitorState.LastStateChangeTime));
                    lvi.Group = lvgPrevious;
                    lvwProperties.Items.Add(lvi);

                    ListViewGroup lvgRemoteHost = new ListViewGroup("Remote agent host");
                    lvwProperties.Groups.Add(lvgRemoteHost);
                    lvi = new ListViewItem("Remote agent host enabled");
                    if (SelectedEntry.EnableRemoteExecute || SelectedEntry.ForceRemoteExcuteOnChildCollectors || SelectedEntry.OverrideRemoteAgentHost)
                        lvi.SubItems.Add("Yes");
                    else
                        lvi.SubItems.Add("No");
                    lvi.Group = lvgRemoteHost;
                    lvwProperties.Items.Add(lvi);

                    if (SelectedEntry.EnableRemoteExecute || SelectedEntry.ForceRemoteExcuteOnChildCollectors || SelectedEntry.OverrideRemoteAgentHost)
                    {
                        lvi = new ListViewItem("Remote agent host");
                        lvi.SubItems.Add(SelectedEntry.ToRemoteHostName());
                        lvi.Group = lvgRemoteHost;
                        lvwProperties.Items.Add(lvi);
                    }

                    ListViewGroup lvgPolling = new ListViewGroup("Polling details");
                    lvwProperties.Groups.Add(lvgPolling);

                    lvi = new ListViewItem("# of times polled");
                    lvi.SubItems.Add(SelectedEntry.PollCount.ToString());
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("# of times refreshed");
                    lvi.SubItems.Add(SelectedEntry.RefreshCount.ToString());
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);
                    
                    lvi = new ListViewItem("Polling override enabled");
                    lvi.SubItems.Add(SelectedEntry.EnabledPollingOverride ? "Yes" : "No");
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    if (SelectedEntry.EnabledPollingOverride)
                    {
                        lvi = new ListViewItem("Poll frequency sliding enabled");
                        lvi.SubItems.Add(SelectedEntry.EnablePollFrequencySliding ? "Yes" : "No");
                        lvi.Group = lvgPolling;
                        lvwProperties.Items.Add(lvi);

                        lvi = new ListViewItem("Current poll frequency (Sec)");
                        if (SelectedEntry.EnablePollFrequencySliding)
                        {
                            if (SelectedEntry.StagnantStateThirdRepeat)
                            {
                                lvi.SubItems.Add(SelectedEntry.PollSlideFrequencyAfterThirdRepeatSec.ToString());
                            }
                            else if (SelectedEntry.StagnantStateSecondRepeat)
                            {
                                lvi.SubItems.Add(SelectedEntry.PollSlideFrequencyAfterSecondRepeatSec.ToString());
                            }
                            else if (SelectedEntry.StagnantStateFirstRepeat)
                            {
                                lvi.SubItems.Add(SelectedEntry.PollSlideFrequencyAfterFirstRepeatSec.ToString());
                            }
                            else
                                lvi.SubItems.Add(SelectedEntry.OnlyAllowUpdateOncePerXSec.ToString());
                        }
                        else
                        {
                            lvi.SubItems.Add(SelectedEntry.OnlyAllowUpdateOncePerXSec.ToString());
                        }

                        lvi.Group = lvgPolling;
                        lvwProperties.Items.Add(lvi);
                    }
                    

                    lvi = new ListViewItem("First polled time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.FirstStateUpdate));
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("# of times good states");
                    lvi.SubItems.Add(SelectedEntry.GoodStateCount.ToString());
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("# of times warning states");
                    lvi.SubItems.Add(SelectedEntry.WarningStateCount.ToString());
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("# of times error states");
                    lvi.SubItems.Add(SelectedEntry.ErrorStateCount.ToString());
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last attempted polling time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastStateCheckAttemptBegin));
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    ListViewGroup lvgAlerts = new ListViewGroup("Alerts");
                    lvwProperties.Groups.Add(lvgAlerts);

                    lvi = new ListViewItem("Last alert time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastAlertTime));
                    lvi.Group = lvgAlerts;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last warning alert time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastWarningAlertTime));
                    lvi.Group = lvgAlerts;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last error alert time");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastErrorAlertTime));
                    lvi.Group = lvgAlerts;
                    lvwProperties.Items.Add(lvi);                    

                    lvi = new ListViewItem("Last good state time:");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastGoodStateTime));
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last good state details");
                    if (SelectedEntry.LastGoodState != null && SelectedEntry.LastGoodState.RawDetails != null)
                        lvi.SubItems.Add(SelectedEntry.LastGoodState.RawDetails);
                    else
                        lvi.SubItems.Add("N/A");
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last warning state");
                    lvi.SubItems.Add(FormatDate(SelectedEntry.LastWarningStateTime));
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last warning state details");
                    if (SelectedEntry.LastWarningState != null && SelectedEntry.LastWarningState.RawDetails != null)
                        lvi.SubItems.Add(SelectedEntry.LastWarningState.RawDetails);
                    else
                        lvi.SubItems.Add("N/A");
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last error state");
                    lvi.SubItems.Add(FormatDate( SelectedEntry.LastErrorStateTime));
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    lvi = new ListViewItem("Last error state details");
                    if (SelectedEntry.LastErrorState != null && SelectedEntry.LastErrorState.RawDetails != null)
                        lvi.SubItems.Add(SelectedEntry.LastErrorState.RawDetails);
                    else
                        lvi.SubItems.Add("N/A");
                    lvi.Group = lvgPolling;
                    lvwProperties.Items.Add(lvi);

                    //ListViewGroup lvgHistory = new ListViewGroup("History");
                    //lvwProperties.Groups.Add(lvgHistory);
                    foreach (var historyItem in (from h in SelectedEntry.StateHistory
                                                 orderby h.LastStateChangeTime descending
                                                 select h))
                    {
                        lvi = new ListViewItem(FormatDate(historyItem.LastStateChangeTime));
                        lvi.SubItems.Add(historyItem.State.ToString());
                        lvi.SubItems.Add(historyItem.CallDurationMS.ToString());
                        lvi.SubItems.Add(historyItem.RawDetails);
                        if (historyItem.State == CollectorState.Folder)
                            lvi.ImageIndex = 0;
                        else if (historyItem.State == CollectorState.Good)
                            lvi.ImageIndex = 2;
                        else if (historyItem.State == CollectorState.Warning)
                            lvi.ImageIndex = 3;
                        else if (historyItem.State == CollectorState.Error)
                            lvi.ImageIndex = 4;
                        else 
                            lvi.ImageIndex = 1;
                        //lvi.Group = lvgHistory;
                        lvwHistory.Items.Add(lvi);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwProperties.EndUpdate();
                lvwHistory.EndUpdate();
            }
        }

        private void lvwProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RTFBuilder rtfBuilder = new RTFBuilder();
                ListViewEx currentListView;
                //if (tabControl1.SelectedIndex == 0)
                    currentListView = lvwProperties;
                //else
                //    currentListView = lvwHistory;
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
        private void lvwHistory_SelectedIndexChanged(object sender, EventArgs e)
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
                        rtfBuilder.FontStyle(FontStyle.Bold).Append("Time:");
                        rtfBuilder.AppendLine(lvi.Text);
                        rtfBuilder.FontStyle(FontStyle.Bold).Append("State:");
                        rtfBuilder.AppendLine(lvi.SubItems[1].Text);
                        rtfBuilder.FontStyle(FontStyle.Bold).Append("Duration:");
                        rtfBuilder.AppendLine(lvi.SubItems[2].Text + " ms");
                        rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Details:");
                        rtfBuilder.AppendLine(lvi.SubItems[3].Text);
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

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            cmdViewDetails.Text = splitContainer1.Panel2Collapsed ? "ttt" : "uuu";
            splitContainer1.SplitterWidth = 8;
        }

        private string FormatDate(DateTime date)
        {
            if (date == null || date <= (new DateTime(2000, 1, 1)))
                return "N/A";
            else
               return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshCollectorStats();
        }


    }
}
