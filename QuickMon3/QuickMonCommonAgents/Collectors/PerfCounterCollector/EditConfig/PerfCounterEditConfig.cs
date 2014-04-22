using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class PerfCounterEditConfig : Form, IEditConfigWindow
    {
        public PerfCounterEditConfig()
        {
            InitializeComponent();
        }

        #region IEditConfigWindow Members
        public IAgentConfig SelectedConfig { get; set; }
        public void SetTitle(string title)
        {
            Text = title;
        }
        public QuickMonDialogResult ShowConfig()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        #region Form events
        private void PerfCounterEditConfig_Load(object sender, EventArgs e)
        {
            LoadEntries();
        }


        #endregion

        #region Toolbar and Button events
        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedConfig != null)
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                PerfCounterEditAlert editPerfCounterAlert = new PerfCounterEditAlert();
                if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentConfig.Entries.Add(editPerfCounterAlert.SelectedPCInstance);
                    ListViewItem lvi = new ListViewItem(editPerfCounterAlert.SelectedPCInstance.ToString());
                    if (editPerfCounterAlert.SelectedPCInstance.WarningValue < 9999)
                        lvi.SubItems.Add(string.Format("{0:f3}", editPerfCounterAlert.SelectedPCInstance.WarningValue));
                    else
                        lvi.SubItems.Add(string.Format("{0:f1}", editPerfCounterAlert.SelectedPCInstance.WarningValue));
                    if (editPerfCounterAlert.SelectedPCInstance.ErrorValue < 9999)
                        lvi.SubItems.Add(string.Format("{0:f3}", editPerfCounterAlert.SelectedPCInstance.ErrorValue));
                    else
                        lvi.SubItems.Add(string.Format("{0:f1}", editPerfCounterAlert.SelectedPCInstance.ErrorValue));
                    lvi.Tag = editPerfCounterAlert.SelectedPCInstance;
                    lvwPerfCounters.Items.Add(lvi);
                }
            }
        }
        private void addCloneComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedConfig != null)
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                if (lvwPerfCounters.SelectedItems.Count > 0)
                {
                    PerfCounterEditAlert editPerfCounterAlert = new PerfCounterEditAlert();
                    editPerfCounterAlert.InitialMachine = ((PerfCounterCollectorEntry)lvwPerfCounters.SelectedItems[0].Tag).Computer;
                    if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        currentConfig.Entries.Add(editPerfCounterAlert.SelectedPCInstance);
                        ListViewItem lvi = new ListViewItem(editPerfCounterAlert.SelectedPCInstance.ToString());
                        if (editPerfCounterAlert.SelectedPCInstance.WarningValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", editPerfCounterAlert.SelectedPCInstance.WarningValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", editPerfCounterAlert.SelectedPCInstance.WarningValue));
                        if (editPerfCounterAlert.SelectedPCInstance.ErrorValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", editPerfCounterAlert.SelectedPCInstance.ErrorValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", editPerfCounterAlert.SelectedPCInstance.ErrorValue));
                        lvi.Tag = editPerfCounterAlert.SelectedPCInstance;
                        lvwPerfCounters.Items.Add(lvi);
                    }
                }
            }
        }
        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedConfig != null)
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                if (lvwPerfCounters.SelectedItems.Count > 0)
                {
                    PerfCounterEditAlert editPerfCounterAlert = new PerfCounterEditAlert();
                    editPerfCounterAlert.SelectedPCInstance = (PerfCounterCollectorEntry)lvwPerfCounters.SelectedItems[0].Tag;
                    if (editPerfCounterAlert.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        lvwPerfCounters.SelectedItems[0].Tag = editPerfCounterAlert.SelectedPCInstance;
                        lvwPerfCounters.SelectedItems[0].Text = editPerfCounterAlert.SelectedPCInstance.ToString();
                        lvwPerfCounters.SelectedItems[0].SubItems[1].Text = string.Format("{0:f2}", editPerfCounterAlert.SelectedPCInstance.WarningValue);
                        lvwPerfCounters.SelectedItems[0].SubItems[2].Text = string.Format("{0:f2}", editPerfCounterAlert.SelectedPCInstance.ErrorValue);
                    }
                }
            }
        }
        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedConfig != null)
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                if (lvwPerfCounters.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to remove the selected entry(s)?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        foreach (ListViewItem lvi in lvwPerfCounters.SelectedItems)
                        {
                            PerfCounterCollectorEntry removeItem = (PerfCounterCollectorEntry)lvi.Tag;
                            currentConfig.Entries.Remove(removeItem);
                            lvwPerfCounters.Items.Remove(lvi);
                        }
                    }
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedConfig != null)
            {
                PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                currentConfig.Entries.Clear();
                foreach (ListViewItem lvi in lvwPerfCounters.Items)
                {
                    if (lvi.Tag is PerfCounterCollectorEntry)
                    {
                        currentConfig.Entries.Add((PerfCounterCollectorEntry)lvi.Tag);
                    }
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region ListView events
        private void lvwPerfCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            timerCheckButtonEnabled.Enabled = true;
        }
        private void lvwPerfCounters_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeToolStripButton_Click(null, null);
            }
        }
        private void lvwPerfCounters_Resize(object sender, EventArgs e)
        {
            ListView lvw = (ListView)sender;
            int restWidth = lvw.Columns[1].Width + lvw.Columns[2].Width;
            lvw.Columns[0].Width = lvw.ClientSize.Width - restWidth;
        }
        #endregion

        #region Private methods
        private void LoadEntries()
        {
            try
            {
                lvwPerfCounters.BeginUpdate();
                lvwPerfCounters.Items.Clear();
                if (SelectedConfig != null)
                {
                    PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                    foreach (PerfCounterCollectorEntry entry in currentConfig.Entries)
                    {
                        ListViewItem lvi = new ListViewItem(entry.ToString());
                        if (entry.WarningValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", entry.WarningValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", entry.WarningValue));
                        if (entry.ErrorValue < 9999)
                            lvi.SubItems.Add(string.Format("{0:f3}", entry.ErrorValue));
                        else
                            lvi.SubItems.Add(string.Format("{0:f1}", entry.ErrorValue));
                        lvi.Tag = entry;
                        lvwPerfCounters.Items.Add(lvi);
                    }
                }
                lvwPerfCounters_Resize(lvwPerfCounters, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lvwPerfCounters.EndUpdate();
            }
        } 
        private void CheckButtonEnabled()
        {
            editToolStripButton.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            editToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            removeToolStripButton.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            removeToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
            addCloneComputerToolStripMenuItem.Enabled = lvwPerfCounters.SelectedItems.Count > 0;
        }
        #endregion

        #region Timer events
        private void timerCheckButtonEnabled_Tick(object sender, EventArgs e)
        {
            timerCheckButtonEnabled.Enabled = false;
            this.Invoke((MethodInvoker)delegate
            {
                CheckButtonEnabled();
            });
        }
        #endregion

        private void cmdQuickConfig_Click(object sender, EventArgs e)
        {
            switch (cboQuickConfig.SelectedIndex)
            {
                case 0:
                    if (SelectedConfig != null)
                    {
                        PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                        if (currentConfig.Entries != null && currentConfig.Entries.Count > 0 && MessageBox.Show("Do you want to replace any existing config?", "Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            break;
                        }
                    }
                    SelectedConfig = new PerfCounterCollectorConfig();
                    SelectedConfig.ReadConfiguration(Properties.Resources.PerfCounterCollectorQuickConfig1);
                    LoadEntries();
                    break;
                case 1:
                    if (SelectedConfig != null)
                    {
                        PerfCounterCollectorConfig currentConfig = (PerfCounterCollectorConfig)SelectedConfig;
                        if (currentConfig.Entries != null && currentConfig.Entries.Count > 0 && MessageBox.Show("Do you want to replace any existing config?", "Config", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            break;
                        }
                    }
                    SelectedConfig = new PerfCounterCollectorConfig();
                    string customConfigString  = Properties.Resources.PerfCounterCollectorQuickConfig2;
                    string machineName = QuickMon.Forms.InputBox.Show("Specify computer name", "Computer", "");
                    if (machineName.Length > 0)
                    {
                        customConfigString = customConfigString.Replace("[machineName]", machineName);
                        SelectedConfig.ReadConfiguration(customConfigString);
                        LoadEntries();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
