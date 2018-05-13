using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.Collectors;

namespace QuickMon.UI
{
    public partial class EventLogCollectorEditEntry : CollectorConfigEntryEditWindowBase //Form, ICollectorConfigEntryEditWindow
    {
        public EventLogCollectorEditEntry()
        {
            InitializeComponent();
        }

        //#region IEditConfigEntryWindow Members
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    if (SelectedEntry == null)
        //        SelectedEntry = new EventLogCollectorEntry() { Computer = System.Net.Dns.GetHostName() };
        //    return (QuickMonDialogResult)ShowDialog();
        //}
        //public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        //#endregion

        internal EventLogCollectorEntry SelectedEventLogEntry { get; set; }

        #region Form events
        private void EditEventLogEntry_Load(object sender, EventArgs e)
        {
            pictureBoxSecWarning.Visible = !Security.UACTools.IsInAdminMode();
            lblSecWarning.Visible = !Security.UACTools.IsInAdminMode();

            EventLogCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (EventLogCollectorEntry)SelectedEntry;
            else
                selectedEntry = (EventLogCollectorEntry)SelectedEventLogEntry;
            if (selectedEntry != null)
            {
                /*
                if (selectedEntry.Computer.Length == 0 || selectedEntry.Computer == ".")
                    selectedEntry.Computer = System.Net.Dns.GetHostName();
                */

                txtComputer.Text = selectedEntry.Computer;
                LoadComputerEventsLogs();
                chkInfo.Checked = selectedEntry.TypeInfo;
                chkWarn.Checked = selectedEntry.TypeWarn;
                chkErr.Checked = selectedEntry.TypeErr;
                txtEventIds.Text = selectedEntry.EventIds.ToCSVString();
                optTextContains.Checked = selectedEntry.ContainsText;
                optUseRegEx.Checked = selectedEntry.UseRegEx;
                txtText.Text = selectedEntry.TextFilter;
                numericUpDownWithinLastXEntries.Value = selectedEntry.WithInLastXEntries;
                numericUpDownWithLastMinutes.Value = selectedEntry.WithInLastXMinutes;
                numericUpDownWarning.Value = selectedEntry.WarningValue > 0 ? selectedEntry.WarningValue : 1;
                numericUpDownError.Value = selectedEntry.ErrorValue > 0 ? selectedEntry.ErrorValue : 10;
                LoadSources();

                //selectedEntry.Sources.ForEach(s => CheckSource(s));
            }            
        }
        private void EditEventLogEntry_Shown(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region List view events
        private void lvwSources_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //try
            //{
            //    lblSourceCount.Text = "Chk:";
            //    if (lvwSources.CheckedItems != null && lvwSources.CheckedItems.Count > 0)
            //    {
            //        lblSourceCount.Text += lvwSources.CheckedItems.Count.ToString();
            //        StringBuilder sb = new StringBuilder();
            //        foreach(ListViewItem chked in lvwSources.CheckedItems)
            //        {
            //            sb.Append(chked.Text + ",");
            //        }
            //        lblChecked.Text = "Checked: " + sb.ToString().TrimEnd(',');
            //    }
            //    else
            //    {
            //        lblSourceCount.Text += "All";
            //        lblChecked.Text = "Checked: None/All";
            //    }
            //    if (!backgroundWorker1.IsBusy)
            //        backgroundWorker1.RunWorkerAsync();
            //}
            //catch(Exception ex)
            //{
            //    lblSourceCount.Text = "Err";
            //}
        }
        private void lvwSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            //timerSourcesSelected.Enabled = false;
            //timerSourcesSelected.Enabled = true;
        }
        #endregion

        #region Button events
        private void cmdLoadEventLogs_Click(object sender, EventArgs e)
        {
            LoadComputerEventsLogs();
        }
        private void cmdEditEventIds_Click(object sender, EventArgs e)
        {
            CSVEditor csvEditor = new CSVEditor();
            csvEditor.Sorted = false;
            csvEditor.ClearTextOnUpdate = true;
            csvEditor.ValuesAreIntegers = true;
            csvEditor.CSVData = txtEventIds.Text;

            if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtEventIds.Text = csvEditor.CSVData;
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            EventLogCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (EventLogCollectorEntry)SelectedEntry;
            else
                selectedEntry = (EventLogCollectorEntry)SelectedEventLogEntry;
            selectedEntry.Computer = txtComputer.Text;
            selectedEntry.EventLog = cboLog.SelectedItem.ToString();
            selectedEntry.TypeInfo = chkInfo.Checked;
            selectedEntry.TypeWarn = chkWarn.Checked;
            selectedEntry.TypeErr = chkErr.Checked;
            selectedEntry.EventIds = (from n in txtEventIds.Text.ToListFromCSVString()
                                              where n.IsInteger()
                                              orderby int.Parse(n)
                                              select int.Parse(n)).ToList();
            //selectedEntry.Sources.Clear();
            //(from ListViewItem l in lvwSources.CheckedItems
            // select l.Text).ToList().ForEach(s => selectedEntry.Sources.Add(s));
            selectedEntry.ContainsText = optTextContains.Checked;
            selectedEntry.UseRegEx = optUseRegEx.Checked;
            selectedEntry.TextFilter = txtText.Text;
            selectedEntry.WithInLastXEntries = (int)numericUpDownWithinLastXEntries.Value;
            selectedEntry.WithInLastXMinutes = (int)numericUpDownWithLastMinutes.Value;
            selectedEntry.WarningValue = (int)numericUpDownWarning.Value;
            selectedEntry.ErrorValue = (int)numericUpDownError.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Context menu events
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerQuickFind.Enabled = false;
            timerQuickFind.Enabled = true;
        }
        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                lvwSources.BeginUpdate();
                foreach (ListViewItem lvi in lvwSources.Items)
                    lvi.Checked = false;
            }
            finally
            {
                lvwSources.EndUpdate();
            }
        }
        private void checkSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lvwSources.BeginUpdate();
                foreach (ListViewItem lvi in lvwSources.SelectedItems)
                    lvi.Checked = true;
            }
            finally
            {
                lvwSources.EndUpdate();
            }
        }
        private void uncheckSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lvwSources.BeginUpdate();
                foreach (ListViewItem lvi in lvwSources.SelectedItems)
                    lvi.Checked = false;
            }
            finally
            {
                lvwSources.EndUpdate();
            }
        }
        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerQuickFind.Enabled = false;
            timerQuickFind.Enabled = true;
        }
        #endregion

        #region Check changes
        private void cboLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSources();
        }
        private void txtSourceQuickFind_TextChanged(object sender, EventArgs e)
        {
            timerQuickFind.Enabled = false;
            timerQuickFind.Enabled = true;
        }
        private void txtComputer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        #endregion

        #region Private methods
        private void CheckSource(string s)
        {
            ListViewItem lvi = (from ListViewItem l in lvwSources.Items
                                where l.Text.Equals(s, StringComparison.CurrentCultureIgnoreCase)
                                select l).FirstOrDefault();
            if (lvi != null)
                lvi.Checked = true;
        }
        private void LoadComputerEventsLogs()
        {
            try
            {
                cboLog.Items.Clear();
                if (txtComputer.Text.Trim().Length == 0)
                {
                    txtComputer.Text = System.Net.Dns.GetHostName();
                }
                string hostName = txtComputer.Text;
                if (hostName == ".")
                {
                    hostName = System.Net.Dns.GetHostName();
                }
                hostName = ApplyConfigVarsOnField(hostName);

                if (System.Net.Dns.GetHostAddresses(hostName).Length == 0)
                    return;

                foreach (string eventLogName in EventLogUtil.GetEventLogNames(hostName))
                {
                    cboLog.Items.Add(eventLogName);
                }
                EventLogCollectorEntry selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (EventLogCollectorEntry)SelectedEntry;
                else
                    selectedEntry = SelectedEventLogEntry;

                if (selectedEntry.EventLog != null)
                    cboLog.SelectedItem = selectedEntry.EventLog;
                else
                    cboLog.SelectedItem = "Application";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Event logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckOkEnabled();
        }
        private void LoadSources()
        {
            EventLogCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (EventLogCollectorEntry)SelectedEntry;
            else
                selectedEntry = (EventLogCollectorEntry)SelectedEventLogEntry;
            try
            {
                lvwSources.BeginUpdate();
                lvwSources.Items.Clear();
                List<ListViewItem> sources = new List<ListViewItem>();
                foreach (string s in selectedEntry.Sources)
                {
                    ListViewItem lvi = new ListViewItem(s);
                    sources.Add(lvi);
                }
                lvwSources.Items.AddRange(sources.ToArray());
                if (lvwSources.Items.Count == 0)
                    lvwSources.Items.Add(new ListViewItem("All"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwSources.EndUpdate();
            }

            //if (cboLog.SelectedIndex > -1)
            //{
            //    try
            //    {


            //        string hostName = txtComputer.Text;
            //        if (hostName == ".")
            //        {
            //            hostName = System.Net.Dns.GetHostName();
            //        }
            //        hostName = ApplyConfigVarsOnField(hostName);

            //        List<ListViewItem> sources = new List<ListViewItem>();
            //        lvwSources.BeginUpdate();
            //        lvwSources.Items.Clear();
            //        foreach (string s in EventLogUtil.GetEventSources(hostName, cboLog.SelectedItem.ToString()))
            //        {
            //            ListViewItem lvi = new ListViewItem(s);
            //            if (selectedEntry.Sources.Contains(s))
            //                lvi.Checked = true;
            //            sources.Add(lvi);
            //        }
            //        lvwSources.Items.AddRange(sources.ToArray());
            //        updateCheckedSources();
            //    }
            //    catch (System.Security.SecurityException)
            //    {
            //        MessageBox.Show("This editor window requires that the application runs in Administrative mode to access all functionality!\r\nPlease restart the application in 'Administrative' mode if you need to access all functionality.", "Admin Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    finally
            //    {
            //        lvwSources.EndUpdate();
            //    }
            //}
        }
        private bool CheckOkEnabled()
        {
            try
            {
                cmdOK.Enabled = false;
                cmdTest.Enabled = false;
                if (txtComputer.Text.Trim().Length == 0)
                    return false;
                if (cboLog.SelectedIndex == -1)
                    return false;
                if (numericUpDownWarning.Value > numericUpDownError.Value)
                    return false;
                if (!chkInfo.Checked && !chkWarn.Checked && !chkErr.Checked)
                    return false;
            }
            catch { return false; }
            cmdOK.Enabled = true;
            cmdTest.Enabled = true;
            return true;
        }        
        #endregion

        #region Timer
        private void timerQuickFind_Tick(object sender, EventArgs e)
        {
            //timerQuickFind.Enabled = false;
            //if (txtSourceQuickFind.Text.Length > 0)
            //{
            //    lvwSources.SelectedItems.Clear();
            //    List<ListViewItem> matchedItems = (from ListViewItem l in lvwSources.Items
            //                                       where (containsToolStripMenuItem.Checked && l.Text.IndexOf(txtSourceQuickFind.Text, StringComparison.CurrentCultureIgnoreCase) > -1) ||
            //                                             (!containsToolStripMenuItem.Checked && l.Text.StartsWith(txtSourceQuickFind.Text, StringComparison.CurrentCultureIgnoreCase))
            //                                       select l).ToList();
            //    if (allToolStripMenuItem.Checked)
            //    {
            //        matchedItems.ForEach(l => l.Selected = true);
            //    }
            //    else if (matchedItems.Count > 0)
            //        matchedItems[0].Selected = true;
            //    if (lvwSources.SelectedItems.Count > 0)
            //        lvwSources.SelectedItems[0].EnsureVisible();



            //}
        }
        private void timerSourcesSelected_Tick(object sender, EventArgs e)
        {
            //timerSourcesSelected.Enabled = false;
            //try
            //{
            //    lvwSources.BeginUpdate();
            //    foreach (ListViewItem lvi in lvwSources.Items)
            //    {
            //        if (lvi.Selected)
            //            lvi.Font = new Font(lvi.Font, FontStyle.Bold);
            //        else
            //            lvi.Font = new Font(lvi.Font, FontStyle.Regular);
            //    }
            //    lblSrcSel.Text = "Sel:";
            //    if (lvwSources.SelectedItems != null && lvwSources.SelectedItems.Count > 0)
            //    {
            //        lblSrcSel.Text += lvwSources.SelectedItems.Count.ToString();
            //    }
            //    else
            //        lblSrcSel.Text += "None";
            //}
            //catch
            //{
            //    lblSrcSel.Text = "Err";
            //}
            //finally
            //{
            //    lvwSources.EndUpdate();
            //}
        }
        #endregion

        private void chkInfo_CheckedChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void numericUpDownWarning_ValueChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void numericUpDownError_ValueChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }

        private void updateCheckedSources()
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Checked:");
            //if (lvwSources.CheckedItems != null && lvwSources.CheckedItems.Count > 0)
            //{
            //    foreach(ListViewItem lvi in lvwSources.CheckedItems)
            //    {
            //        sb.AppendLine("  " + lvi.Text);
            //    }
            //}
            //else
            //    sb.AppendLine("  None");

            //toolTip1.SetToolTip(lblSourceCount, sb.ToString());
        }

        private DateTime lastCheckUpdate = DateTime.Now;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (DateTime.Now.Subtract(lastCheckUpdate).TotalMilliseconds > 200)
            {                
                this.Invoke((MethodInvoker)delegate
                {
                    System.Threading.Thread.Sleep(200);
                    lastCheckUpdate = DateTime.Now;
                    updateCheckedSources();
                });
            }
        }

        private void cmdSelectSources_Click(object sender, EventArgs e)
        {
            EventLogCollectorEntry selectedEntry;
            if (SelectedEntry != null)
                selectedEntry = (EventLogCollectorEntry)SelectedEntry;
            else
                selectedEntry = SelectedEventLogEntry;

            SelectEventSources selectEventSources = new SelectEventSources();
            selectEventSources.ComputerName = txtComputer.Text;
            selectEventSources.ConfigVariables = ConfigVariables;
            selectEventSources.LogName = cboLog.Text;
            selectEventSources.SelectedSources.AddRange(selectedEntry.Sources.ToArray());
            if (selectEventSources.ShowDialog()== DialogResult.OK)
            {
                selectedEntry.EventLog = selectEventSources.LogName;
                txtComputer.Text = selectEventSources.ComputerName;
                LoadComputerEventsLogs();
                selectedEntry.Sources.Clear();
                selectEventSources.SelectedSources.ForEach(s => selectedEntry.Sources.Add(s));
                LoadSources();
                
                //lblSourceCount.Text += lvwSources.CheckedItems.Count.ToString();
                //StringBuilder sb = new StringBuilder();
                //foreach (string src in selectedEntry.Sources)
                //{
                //    sb.Append(src + ",");
                //}
                //lblChecked.Text = "Checked: " + sb.ToString().TrimEnd(',');
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                EventLogCollectorEntry selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (EventLogCollectorEntry)SelectedEntry;
                else
                    selectedEntry = SelectedEventLogEntry;

                EventLogCollectorEntry testEntry = new EventLogCollectorEntry();
                testEntry.Computer = txtComputer.Text;
                testEntry.EventLog = cboLog.SelectedItem.ToString();
                testEntry.TypeInfo = chkInfo.Checked;
                testEntry.TypeWarn = chkWarn.Checked;
                testEntry.TypeErr = chkErr.Checked;
                testEntry.Sources.Clear();
                testEntry.Sources.AddRange(selectedEntry.Sources.ToArray());                
                testEntry.EventIds = (from n in txtEventIds.Text.ToListFromCSVString()
                                      where n.IsInteger()
                                      orderby int.Parse(n)
                                      select int.Parse(n)).ToList();
                testEntry.ContainsText = optTextContains.Checked;
                testEntry.UseRegEx = optUseRegEx.Checked;
                testEntry.TextFilter = txtText.Text;
                testEntry.WithInLastXEntries = (int)numericUpDownWithinLastXEntries.Value;
                testEntry.WithInLastXMinutes = (int)numericUpDownWithLastMinutes.Value;
                testEntry.WarningValue = (int)numericUpDownWarning.Value;
                testEntry.ErrorValue = (int)numericUpDownError.Value;

                MonitorState m = testEntry.GetCurrentState();
                string result = string.Format("State: {0}\r\nValue: {1}", m.State, m.FormatValue());

                MessageBox.Show(result, "Test", MessageBoxButtons.OK, m.State == CollectorState.Good ? MessageBoxIcon.Information : m.State == CollectorState.Warning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
