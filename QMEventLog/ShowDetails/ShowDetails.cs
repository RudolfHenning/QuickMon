using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using HenIT.RTF;


namespace QuickMon
{
    public partial class ShowDetails : Form
    {
        public ShowDetails()
        {
            InitializeComponent();
        }

        private const int MAXPREVIEWDISPLAYCOUNT = 100;

        internal EventLogConfig SelectedEventLogConfig { get; set; }

        #region Form events
        private void ShowDetails_Shown(object sender, EventArgs e)
        {
            LoadEntries();
        }
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = true;
        } 
        #endregion

        #region List view events
        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void lvwDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            toolStripStatusLabelDetails.Text = string.Format("{0} item(s), {1} selected", lvwDetails.Items.Count, lvwDetails.SelectedItems.Count);
            timerSelectItem.Enabled = true;
        } 
        private void lvwDetails_Resize(object sender, EventArgs e)
        {
            lvwDetails.Columns[4].Width = lvwDetails.ClientSize.Width - lvwDetails.Columns[0].Width - lvwDetails.Columns[1].Width - lvwDetails.Columns[2].Width - lvwDetails.Columns[3].Width;
        }
        #endregion

        #region Private methods
        private void LoadEntries()
        {
            lvwEntries.Items.Clear();
            if (SelectedEventLogConfig != null)
            {
                foreach (QMEventLogEntry entry in SelectedEventLogConfig.Entries)
                {
                    ListViewItem lvi = new ListViewItem(entry.ComputerLogName);
                    lvi.SubItems.Add(entry.FilterSummary);
                    lvi.ImageIndex = 0;
                    lvi.Tag = entry;
                    lvwEntries.Items.Add(lvi);
                }
                while (backgroundWorkerMessages.IsBusy)
                {
                    Application.DoEvents();
                }
                backgroundWorkerMessages.RunWorkerAsync();
            }
        }
        private void RefreshList()
        {
            while (backgroundWorkerMessages.IsBusy)
            {
                Application.DoEvents();
            }
            backgroundWorkerMessages.RunWorkerAsync();
            toolStripStatusLabelDetails.Text = "Loading items...";
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;            
            lvwDetails.Items.Clear();
            if (lvwEntries.SelectedItems.Count > 0)
            {   
                List<ListViewItem> listItems = new List<ListViewItem>();
                QMEventLogEntry entry = (QMEventLogEntry)lvwEntries.SelectedItems[0].Tag;
                try
                {
                    lvwDetails.BeginUpdate();
                    foreach (EventLogEntryEx ev in entry.GetMatchingEventLogEntries())
                    {
                        ListViewItem lvi = new ListViewItem(ev.TimeGenerated.ToString("yyyy-MM-dd"));
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
                        lvi.SubItems.Add(ev.TimeGenerated.ToString("HH:mm:ss"));
                        lvi.SubItems.Add(ev.Source);
                        lvi.SubItems.Add(ev.EventId.ToString());
                        lvi.SubItems.Add(ev.MessageSummary);
                        lvi.Tag = ev;
                        listItems.Add(lvi);
                    }
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
                finally
                {
                    lvwDetails.EndUpdate();
                }

                lvwDetails.Items.AddRange(listItems.ToArray());
                
            }            
            Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = string.Format("{0} item(s) found", lvwDetails.Items.Count);
        }
        private void DisplaySelectedItemDetails()
        {
            string oldStatusText = toolStripStatusLabelDetails.Text;
            RTFBuilder rtfBuilder = new RTFBuilder();
            string logName = "";
            if (lvwEntries.SelectedItems.Count > 0 && lvwEntries.SelectedItems[0].Tag is QMEventLogEntry)
                logName = ((QMEventLogEntry)lvwEntries.SelectedItems[0].Tag).EventLog;

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

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "ttt" : "uuu";
        }
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            
            RefreshList();
        }
        private void cboEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails();
        }
        private void backgroundWorkerMessages_DoWork(object sender, DoWorkEventArgs e)
        {            
            this.Invoke((MethodInvoker)delegate
            {
                //lazyLoadMsgs = true;
                foreach (ListViewItem lvi in lvwEntries.Items)
                {
                    try
                    {
                        //if (!lazyLoadMsgs)
                        //    break;
                        if (lvi.Tag is QMEventLogEntry)
                        {
                            QMEventLogEntry entry = (QMEventLogEntry)lvi.Tag;
                            int count = entry.GetMatchingEventLogCount();
                            if (count >= entry.ErrorValue)
                                lvi.ImageIndex = 3;
                            else if (count >= entry.WarningValue)
                                lvi.ImageIndex = 2;
                            else
                                lvi.ImageIndex = 1;
                        }
                        Application.DoEvents();
                    }
                    catch { }
                }
            });
        }

    }
}
