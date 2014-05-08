using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace QuickMon
{
    public partial class EditEventLogEntry : Form
    {
        public EditEventLogEntry()
        {
            InitializeComponent();
        }

        internal QMEventLogEntry SelectedEventLogEntry { get; set; }

        #region Form events
        private void EditEventLogEntry_Load(object sender, EventArgs e)
        {
            pictureBoxSecWarning.Visible = !IsAdmin();
            lblSecWarning.Visible = !IsAdmin();
            if (SelectedEventLogEntry == null)
            {
                SelectedEventLogEntry = new QMEventLogEntry();
                SelectedEventLogEntry.Computer = System.Net.Dns.GetHostName();
            }
        }
        private void EditEventLogEntry_Shown(object sender, EventArgs e)
        {
            txtComputer.Text = SelectedEventLogEntry.Computer;
            LoadComputerEventsLogs();
            chkInfo.Checked = SelectedEventLogEntry.TypeInfo;
            chkWarn.Checked = SelectedEventLogEntry.TypeWarn;
            chkErr.Checked = SelectedEventLogEntry.TypeErr;
            txtEventIds.Text = SelectedEventLogEntry.EventIds.ToCSVString();
            optTextContains.Checked = SelectedEventLogEntry.ContainsText;
            txtText.Text = SelectedEventLogEntry.TextFilter;
            numericUpDownWithinLastXEntries.Value = SelectedEventLogEntry.WithInLastXEntries;
            numericUpDownWithLastMinutes.Value = SelectedEventLogEntry.WithInLastXMinutes;
            numericUpDownWarning.Value = SelectedEventLogEntry.WarningValue > 0 ? SelectedEventLogEntry.WarningValue : 1;
            numericUpDownError.Value = SelectedEventLogEntry.ErrorValue > 0 ? SelectedEventLogEntry.ErrorValue : 10;
            SelectedEventLogEntry.Sources.ForEach(s => CheckSource(s));
        }        
        #endregion

        #region List view events
        private void lvwSources_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                lblSourceCount.Text = "Chk:";
                if (lvwSources.CheckedItems != null && lvwSources.CheckedItems.Count > 0)
                {
                    lblSourceCount.Text += lvwSources.CheckedItems.Count.ToString();
                }
                else
                    lblSourceCount.Text += "All";
            }
            catch
            {
                lblSourceCount.Text = "Err";
            }
        }
        private void lvwSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSourcesSelected.Enabled = false;
            timerSourcesSelected.Enabled = true;
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
            SelectedEventLogEntry.Computer = txtComputer.Text;
            SelectedEventLogEntry.EventLog = cboLog.SelectedItem.ToString();
            SelectedEventLogEntry.TypeInfo = chkInfo.Checked;
            SelectedEventLogEntry.TypeWarn = chkWarn.Checked;
            SelectedEventLogEntry.TypeErr = chkErr.Checked;
            SelectedEventLogEntry.EventIds = (from n in txtEventIds.Text.ToListFromCSVString()
                                       where n.IsInteger()
                                       orderby int.Parse(n)
                                       select int.Parse(n)).ToList();
            SelectedEventLogEntry.Sources.Clear();
            (from ListViewItem l in lvwSources.CheckedItems
             select l.Text).ToList().ForEach(s => SelectedEventLogEntry.Sources.Add(s));
            SelectedEventLogEntry.ContainsText = optTextContains.Checked;
            SelectedEventLogEntry.TextFilter = txtText.Text;
            SelectedEventLogEntry.WithInLastXEntries = (int)numericUpDownWithinLastXEntries.Value;
            SelectedEventLogEntry.WithInLastXMinutes = (int)numericUpDownWithLastMinutes.Value;
            SelectedEventLogEntry.WarningValue = (int)numericUpDownWarning.Value;
            SelectedEventLogEntry.ErrorValue = (int)numericUpDownError.Value;
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
                    return;
                if (System.Net.Dns.GetHostAddresses(txtComputer.Text).Length == 0)
                    return;

                //EventLog[] logs = EventLog.GetEventLogs(txtComputer.Text);
                //List<EventLog> sortedLogs = new List<EventLog>();
                //for (int i = 0; i < logs.Length; i++)
                //{
                //    try
                //    {
                //        EventLog log = logs[i];
                //        string s = log.LogDisplayName; //simply try to access the property will trigger the exception if not in Admin mode
                //        sortedLogs.Add(log);
                //    }
                //    catch(System.Security.SecurityException) 
                //    {
                //        //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    }
                //}
                //sortedLogs.Sort((l, l2) => l.LogDisplayName.CompareTo(l2.LogDisplayName));
                //foreach (EventLog log in sortedLogs) 
                //                            //(from l in logs
                //                            //  orderby l.LogDisplayName
                //                            //  select l))
                //    {
                //        cboLog.Items.Add(log.LogDisplayName);
                //    }

                foreach (string eventLogName in EventLogUtil.GetEventLogNames(txtComputer.Text))
                {
                    cboLog.Items.Add(eventLogName);
                }
                if (SelectedEventLogEntry.EventLog != null)
                    cboLog.SelectedItem = SelectedEventLogEntry.EventLog;
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
            if (cboLog.SelectedIndex > -1)
            {
                try
                {
                    List<ListViewItem> sources = new List<ListViewItem>();
                    lvwSources.BeginUpdate();
                    lvwSources.Items.Clear();
                    foreach (string s in EventLogUtil.GetEventSources(txtComputer.Text, cboLog.SelectedItem.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(s);
                        if (SelectedEventLogEntry.Sources.Contains(s))
                            lvi.Checked = true;
                        sources.Add(lvi);
                    }
                    lvwSources.Items.AddRange(sources.ToArray());
                }
                catch (System.Security.SecurityException)
                {
                    MessageBox.Show("This editor window requires that the application runs in Administrative mode to access all functionality!\r\nPlease restart the application in 'Administrative' mode if you need to access all functionality.", "Admin Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwSources.EndUpdate();
                }
            }
        }
        private bool CheckOkEnabled()
        {
            try
            {
                cmdOK.Enabled = false;
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
            return true;
        }
        private bool IsAdmin()
        {
            string strIdentity;
            try
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                WindowsPrincipal wp = new WindowsPrincipal(wi);
                strIdentity = wp.Identity.Name;

                if (wp.IsInRole(WindowsBuiltInRole.Administrator))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region Timer
        private void timerQuickFind_Tick(object sender, EventArgs e)
        {
            timerQuickFind.Enabled = false;
            if (txtSourceQuickFind.Text.Length > 0)
            {
                lvwSources.SelectedItems.Clear();
                List<ListViewItem> matchedItems = (from ListViewItem l in lvwSources.Items
                                                   where (containsToolStripMenuItem.Checked && l.Text.IndexOf(txtSourceQuickFind.Text, StringComparison.CurrentCultureIgnoreCase) > -1) ||
                                                         (!containsToolStripMenuItem.Checked && l.Text.StartsWith(txtSourceQuickFind.Text, StringComparison.CurrentCultureIgnoreCase))
                                                   select l).ToList();
                if (allToolStripMenuItem.Checked)
                {
                    matchedItems.ForEach(l => l.Selected = true);
                }
                else if (matchedItems.Count > 0)
                    matchedItems[0].Selected = true;
                if (lvwSources.SelectedItems.Count > 0)
                    lvwSources.SelectedItems[0].EnsureVisible();



            }
        }
        private void timerSourcesSelected_Tick(object sender, EventArgs e)
        {
            timerSourcesSelected.Enabled = false;
            try
            {
                lvwSources.BeginUpdate();
                foreach (ListViewItem lvi in lvwSources.Items)
                {
                    if (lvi.Selected)
                        lvi.Font = new Font(lvi.Font, FontStyle.Bold);
                    else
                        lvi.Font = new Font(lvi.Font, FontStyle.Regular);
                }
                lblSrcSel.Text = "Sel:";
                if (lvwSources.SelectedItems != null && lvwSources.SelectedItems.Count > 0)
                {
                    lblSrcSel.Text += lvwSources.SelectedItems.Count.ToString();
                }
                else
                    lblSrcSel.Text += "None";
            }
            catch
            {
                lblSrcSel.Text = "Err";
            }
            finally
            {
                lvwSources.EndUpdate();
            }
        } 
        #endregion

    }
}
