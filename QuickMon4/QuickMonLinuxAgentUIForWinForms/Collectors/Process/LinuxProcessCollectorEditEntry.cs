using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class LinuxProcessCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public LinuxProcessCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region ICollectorConfigEntryEditWindow
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        private QuickMon.Linux.SSHConnectionDetails sshConnectionDetails = new Linux.SSHConnectionDetails();

        private void LinuxProcessCollectorEdit_Load(object sender, EventArgs e)
        {
            LoadEntryDetails();
            lvwProcesses.AutoResizeColumnEnabled = true;
        }

        #region Private methods
        private void LoadEntryDetails()
        {
            LinuxProcessEntry currentEntry = (LinuxProcessEntry)SelectedEntry;
            if (currentEntry == null)
                currentEntry = new LinuxProcessEntry();
            sshConnectionDetails = currentEntry.SSHConnection;
            txtSSHConnection.Text = Linux.SSHConnectionDetails.FormatSSHConnection(sshConnectionDetails);

            txtName.Text = currentEntry.Name;
            cboProcessCheckOption.SelectedIndex = (int)currentEntry.ProcessCheckOption;
            topProcessCountUpDown.SaveValueSet(currentEntry.TopProcessCount);
            topXCPUPercWarnNumericUpDown.SaveValueSet(currentEntry.CPUPercWarningValue);
            topXCPUPercErrNumericUpDown.SaveValueSet(currentEntry.CPUPercErrorValue);
            topXMemPercWarnNumericUpDown.SaveValueSet(currentEntry.MemPercWarningValue);
            topXMemPercErrNumericUpDown.SaveValueSet(currentEntry.MemPercErrorValue);

            lvwProcesses.Items.Clear();
            if (currentEntry.SubItems != null && currentEntry.SubItems.Count > 0)
            {
                foreach (LinuxProcessSubEntry specific in currentEntry.SubItems)
                {
                    ListViewItem lvi = new ListViewItem(specific.ProcessName);
                    lvi.SubItems.Add(specific.CPUPercWarningValue.ToString());
                    lvi.SubItems.Add(specific.CPUPercErrorValue.ToString());
                    lvi.SubItems.Add(specific.MemPercWarningValue.ToString());
                    lvi.SubItems.Add(specific.MemPercErrorValue.ToString());
                    lvi.Tag = specific;
                    lvwProcesses.Items.Add(lvi);
                }
            }
        }
        #endregion

        private bool specificProcessUpdated = false;
        private void lvwProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProcesses.SelectedItems.Count == 1)
            {
                specificProcessUpdated = true;
                LinuxProcessSubEntry dsse = (LinuxProcessSubEntry)lvwProcesses.SelectedItems[0].Tag;
                txtProcessName.Text = dsse.ProcessName;
                cpuPercWarnNumericUpDown.SaveValueSet(dsse.CPUPercWarningValue);
                cpuPercErrNumericUpDown.SaveValueSet(dsse.CPUPercErrorValue);
                memPercWarnNumericUpDown.SaveValueSet(dsse.MemPercWarningValue);
                memPercErrNumericUpDown.SaveValueSet(dsse.MemPercErrorValue);
                specificProcessUpdated = false;
            }
            else if (lvwProcesses.SelectedItems.Count == 0)
            {
                specificProcessUpdated = true;
                txtProcessName.Text = "";
                specificProcessUpdated = false;
            }
        }

        private void txtProcessName_TextChanged(object sender, EventArgs e)
        {
            UpdateSpecificProcess();
        }

        private void cpuPercWarnNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpecificProcess();
        }

        private void cpuPercErrNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpecificProcess();
        }

        private void memPercWarnNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpecificProcess();
        }

        private void memPercErrNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateSpecificProcess();
        }

        private void UpdateSpecificProcess()
        {
            if (txtProcessName.Text.Trim().Length > 0 && !specificProcessUpdated)
            {
                if (lvwProcesses.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = lvwProcesses.SelectedItems[0];
                    LinuxProcessSubEntry dsse = (LinuxProcessSubEntry)lvwProcesses.SelectedItems[0].Tag;
                    dsse.ProcessName = txtProcessName.Text;
                    dsse.CPUPercWarningValue = (int)cpuPercWarnNumericUpDown.Value;
                    dsse.CPUPercErrorValue = (int)cpuPercErrNumericUpDown.Value;
                    dsse.MemPercWarningValue = (int)memPercWarnNumericUpDown.Value;
                    dsse.MemPercErrorValue = (int)memPercErrNumericUpDown.Value;
                    lvi.Text = txtProcessName.Text;
                    lvi.SubItems[1].Text = cpuPercWarnNumericUpDown.Value.ToString();
                    lvi.SubItems[2].Text = cpuPercErrNumericUpDown.Value.ToString();
                    lvi.SubItems[3].Text = memPercWarnNumericUpDown.Value.ToString();
                    lvi.SubItems[4].Text = memPercErrNumericUpDown.Value.ToString();
                }
                else
                {
                    LinuxProcessSubEntry dsse = new LinuxProcessSubEntry() { 
                        ProcessName = txtProcessName.Text,
                        CPUPercWarningValue = (int)cpuPercWarnNumericUpDown.Value,
                        CPUPercErrorValue = (int)cpuPercErrNumericUpDown.Value,
                        MemPercWarningValue = (int)memPercWarnNumericUpDown.Value,
                        MemPercErrorValue = (int)memPercErrNumericUpDown.Value
                    };
                    ListViewItem lvi = new ListViewItem() { Text = dsse.ProcessName };
                    lvi.SubItems.Add(dsse.CPUPercWarningValue.ToString());
                    lvi.SubItems.Add(dsse.CPUPercErrorValue.ToString());
                    lvi.SubItems.Add(dsse.MemPercWarningValue.ToString());
                    lvi.SubItems.Add(dsse.MemPercErrorValue.ToString());
                    lvi.Tag = dsse;
                    lvwProcesses.Items.Add(lvi);
                    lvwProcesses.SelectedItems.Clear();
                    lvi.Selected = true;
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LinuxProcessEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new LinuxProcessEntry();
            selectedEntry = (LinuxProcessEntry)SelectedEntry;
            selectedEntry.SSHConnection = sshConnectionDetails;
            selectedEntry.Name = txtName.Text;
            selectedEntry.ProcessCheckOption = (ProcessCheckOption)cboProcessCheckOption.SelectedIndex;
            selectedEntry.TopProcessCount = (int)topProcessCountUpDown.Value;
            selectedEntry.CPUPercWarningValue = (int)topXCPUPercWarnNumericUpDown.Value;
            selectedEntry.CPUPercErrorValue = (int)topXCPUPercErrNumericUpDown.Value;
            selectedEntry.MemPercWarningValue = (int)topXMemPercWarnNumericUpDown.Value;
            selectedEntry.MemPercErrorValue = (int)topXMemPercErrNumericUpDown.Value;
            selectedEntry.SubItems.Clear();

            foreach (ListViewItem lvi in lvwProcesses.Items)
            {
                LinuxProcessSubEntry dsse = (LinuxProcessSubEntry)lvi.Tag;
                selectedEntry.SubItems.Add(dsse);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void lblAddFileSystem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lvwProcesses.SelectedItems.Clear();
            txtProcessName.Text = "";
        }

        private void lblAutoAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinuxProcessViewer pviewer = new LinuxProcessViewer();
            pviewer.SSHConnectionDetails = sshConnectionDetails;
            if (pviewer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (Linux.ProcessInfo pi in pviewer.SelectedProcesses)
                {
                    if ((from ListViewItem l in lvwProcesses.Items
                         where l.Text.ToLower() == pi.ProcessName.ToLower()
                         select l).Count() == 0)
                    {

                        LinuxProcessSubEntry dsse = new LinuxProcessSubEntry()
                        {
                            ProcessName = pi.ProcessName,
                            CPUPercWarningValue = (int)cpuPercWarnNumericUpDown.Value,
                            CPUPercErrorValue = (int)cpuPercErrNumericUpDown.Value,
                            MemPercWarningValue = (int)memPercWarnNumericUpDown.Value,
                            MemPercErrorValue = (int)memPercErrNumericUpDown.Value
                        };
                        ListViewItem lvi = new ListViewItem() { Text = dsse.ProcessName };
                        lvi.SubItems.Add(dsse.CPUPercWarningValue.ToString());
                        lvi.SubItems.Add(dsse.CPUPercErrorValue.ToString());
                        lvi.SubItems.Add(dsse.MemPercWarningValue.ToString());
                        lvi.SubItems.Add(dsse.MemPercErrorValue.ToString());
                        lvi.Tag = dsse;
                        lvwProcesses.Items.Add(lvi);
                    }
                }
            }
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            LinuxProcessEntry testEntry = new LinuxProcessEntry();
            testEntry.SSHConnection = sshConnectionDetails;
            testEntry.Name = txtName.Text;
            testEntry.ProcessCheckOption = (ProcessCheckOption)cboProcessCheckOption.SelectedIndex;
            testEntry.TopProcessCount = (int)topProcessCountUpDown.Value;
            testEntry.CPUPercWarningValue = (int)topXCPUPercWarnNumericUpDown.Value;
            testEntry.CPUPercErrorValue = (int)topXCPUPercErrNumericUpDown.Value;
            testEntry.MemPercWarningValue = (int)topXMemPercWarnNumericUpDown.Value;
            testEntry.MemPercErrorValue = (int)topXMemPercErrNumericUpDown.Value;
            testEntry.SubItems.Clear();

            foreach (ListViewItem lvi in lvwProcesses.Items)
            {
                LinuxProcessSubEntry dsse = (LinuxProcessSubEntry)lvi.Tag;
                testEntry.SubItems.Add(dsse);
            }

            try 
            {
                List<ProcessInfoState> states = testEntry.GetStates();
                MessageBox.Show(string.Format("Test succeeded!\r\nGood: {0}\r\nWarning: {1}\r\nError: {2}", 
                       states.Count<ProcessInfoState>(s=>s.State == CollectorState.Good),
                       states.Count<ProcessInfoState>(s=>s.State == CollectorState.Warning),
                       states.Count<ProcessInfoState>(s=>s.State == CollectorState.Error)
                       )
                    , "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Test failed!\r\n" + ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvwProcesses_DeleteKeyPressed()
        {
            if (lvwProcesses.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete the selected entry(s)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem lvi in lvwProcesses.SelectedItems)
                    {
                        lvwProcesses.Items.Remove(lvi);
                    }
                }
            }
        }

    }
}
