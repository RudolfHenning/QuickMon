using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HenIT.RTF;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class EventLogCollectorViewDetails : SimpleDetailView, ICollectorDetailView
    {
        private const int MAXPREVIEWDISPLAYCOUNT = 100;
        private bool busyRefreshing = false;

        public EventLogCollectorViewDetails()
        {
            InitializeComponent();
        }

        #region Form events
        private void EventLogCollectorViewDetails_Load(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = true;
        }
        #endregion

        #region ICollectorDetailView Members    
        public override void LoadDisplayData()
        {
            lvwEntries2.Items.Clear();
            if (Collector != null && Collector.AgentConfig != null)
            {
                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)Collector.AgentConfig;
                foreach (EventLogCollectorEntry entry in currentConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(entry.ComputerLogName);
                    lvi.SubItems.Add(entry.FilterSummary);
                    lvi.SubItems.Add("0");
                    lvi.ImageIndex = 0;
                    lvi.Tag = entry;
                    lvwEntries2.Items.Add(lvi);
                }
            }
        }
        public override void RefreshDisplayData()
        {
            if (busyRefreshing)
                return;
            busyRefreshing = true;
            foreach (ListViewItem lvi in lvwEntries2.Items)
            {
                try
                {
                    if (lvi.Tag is EventLogCollectorEntry)
                    {
                        EventLogCollectorEntry entry = (EventLogCollectorEntry)lvi.Tag;
                        int count = entry.GetMatchingEventLogCount();
                        if (count >= entry.ErrorValue)
                            lvi.ImageIndex = 3;
                        else if (count >= entry.WarningValue)
                            lvi.ImageIndex = 2;
                        else
                            lvi.ImageIndex = 1;
                        lvi.SubItems[2].Text = count.ToString();
                    }
                    Application.DoEvents();
                }
                catch { }
            }
            busyRefreshing = false;
            RefreshSubList();
        }
        #endregion

        #region Private methods
        private void RefreshSubList()
        {
            if (busyRefreshing)
                return;
            busyRefreshing = true;

            toolStripStatusLabelDetails.Text = "Loading items...";
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            lvwDetails.Items.Clear();
            if (lvwEntries2.SelectedItems.Count > 0)
            {
                List<ListViewItem> listItems = new List<ListViewItem>();
                try
                {
                    foreach (ListViewItem lviEntry in lvwEntries2.SelectedItems)
                    {
                        EventLogCollectorEntry entry = (EventLogCollectorEntry)lviEntry.Tag;
                        foreach (EventLogEntryEx ev in entry.LastEntries) // entry.GetMatchingEventLogEntries())
                        {
                            ListViewItem lvi = new ListViewItem(entry.ComputerLogName);
                            if (ev.EntryType == EventLogEntryType.Information)
                                lvi.ImageIndex = 0;
                            else if (ev.EntryType == EventLogEntryType.Warning)
                                lvi.ImageIndex = 1;
                            else if (ev.EntryType == EventLogEntryType.Error)
                                lvi.ImageIndex = 2;
                            else if (ev.EntryType == EventLogEntryType.FailureAudit)
                                lvi.ImageIndex = 3;
                            else if (ev.EntryType == EventLogEntryType.SuccessAudit)
                                lvi.ImageIndex = 4;
                            else
                                lvi.ImageIndex = 1;
                            lvi.SubItems.Add(ev.TimeGenerated.ToString("yyyy-MM-dd"));
                            lvi.SubItems.Add(ev.TimeGenerated.ToString("HH:mm:ss"));
                            lvi.SubItems.Add(ev.Source);
                            lvi.SubItems.Add(ev.EventId.ToString());
                            lvi.SubItems.Add(ev.MessageSummary);
                            lvi.Tag = ev;
                            listItems.Add(lvi);
                        }
                    }
                    lvwDetails.Items.AddRange(listItems.ToArray());
                }
                catch (Exception ex)
                {
                    ListViewItem lvi = new ListViewItem("Error");
                    lvi.SubItems.Add("Error");
                    lvi.SubItems.Add("Error");
                    lvi.SubItems.Add("Error");
                    lvi.SubItems.Add(ex.Message);
                    listItems.Add(lvi);
                }

            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = string.Format("{0} item(s) found, Last update {1}", lvwDetails.Items.Count, DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss"));
            busyRefreshing = false;
        }
        private void DisplaySelectedItemDetails()
        {
            string oldStatusText = toolStripStatusLabelDetails.Text;
            RTFBuilder rtfBuilder = new RTFBuilder();
            string logName = "";
            if (lvwEntries2.SelectedItems.Count > 0 && lvwEntries2.SelectedItems[0].Tag is EventLogCollectorEntry)
                logName = ((EventLogCollectorEntry)lvwEntries2.SelectedItems[0].Tag).EventLog;

            if (lvwDetails.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                Cursor.Current = Cursors.WaitCursor;
            //have to limit the maximum number of selected items
            foreach (ListViewItem lvi in (from ListViewItem l in lvwDetails.SelectedItems
                                          select l).Take(MAXPREVIEWDISPLAYCOUNT))
            {
                if (lvi.Tag is EventLogEntryEx)
                {
                    EventLogEntryEx ev = (EventLogEntryEx)lvi.Tag;
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Date time: ").AppendLine(ev.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"));
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Type: ").AppendLine(ev.EntryType.ToString());
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Computer: ").AppendLine(ev.MachineName);
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Event log: ").AppendLine(ev.LogName);
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Source: ").AppendLine(ev.Source);
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Event ID: ").AppendLine(ev.EventId.ToString());
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Message: ").AppendLine();
                    rtfBuilder.Append(ev.Message.Replace("\r\n", "\r\n\t")).AppendLine();
                    rtfBuilder.FontStyle(FontStyle.Underline).AppendLine(new String(' ', 250));
                    rtfBuilder.AppendLine();
                }
            }
            if (lvwDetails.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
            {
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("Only first {0} entries shown...", MAXPREVIEWDISPLAYCOUNT));
            }
            else if (lvwDetails.SelectedItems.Count == 0)
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("No entries selected");
            else
            {
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("{0} entry(s)", lvwDetails.SelectedItems.Count));
            }
            rtxDetails.Rtf = rtfBuilder.ToString();
            rtxDetails.SelectionStart = 0;
            rtxDetails.SelectionLength = 0;
            rtxDetails.ScrollToCaret();
            Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = oldStatusText;
        } 
        #endregion

        #region List view events
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSubList();
        }
        private void lvwDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            toolStripStatusLabelDetails.Text = string.Format("{0} item(s), {1} selected", lvwDetails.Items.Count, lvwDetails.SelectedItems.Count);
            timerSelectItem.Enabled = true;
        }
        #endregion

        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails();
        }
        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "ttt" : "uuu";
        }
    }
}
