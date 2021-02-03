using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuickMon.Collectors;

namespace QuickMon.UI
{
    public partial class ProcessCollectorEditEntry : CollectorConfigEntryEditWindowBase
    {
        public ProcessCollectorEditEntry()
        {
            InitializeComponent();
        }

        private void ProcessCollectorEditEntry_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessCollectorConfigEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new ProcessCollectorConfigEntry();
                selectedEntry = (ProcessCollectorConfigEntry)SelectedEntry;

                txtName.Text = selectedEntry.Name;
                cboFilterType.SelectedIndex = (int)selectedEntry.ProcessFilterType;
                txtFilter.Text = selectedEntry.ProcessFilter;
                cboTestType.SelectedIndex = (int)selectedEntry.ProcessCollectorTestType;
                nudMinInstanceCount.Value = selectedEntry.MinimumRunningInstanceCount;
                nudMaxInstanceCount.Value = selectedEntry.MaximumRunningInstanceCount;
                nudCPUWarn.Value = selectedEntry.ProcessorPercWarningTrigger;
                nudCPUErr.Value = selectedEntry.ProcessorPercErrorTrigger;
                nudMemWarn.Value = selectedEntry.MemoryKBWarningTrigger;
                nudMemErr.Value = selectedEntry.MemoryKBErrorTrigger;
                nudThreadCountWarn.Value = selectedEntry.ThreadCountWarningTrigger;
                nudThreadCountErr.Value = selectedEntry.ThreadCountErrorTrigger;
                EnableDisableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }
        private void chkCheckPerf_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }
        private void cmdBrowseProcesses_Click(object sender, EventArgs e)
        {
            ProcessListSelectDialog processListSelectDialog = new ProcessListSelectDialog();
            processListSelectDialog.ProcessCollectorFilterType = (ProcessCollectorFilterType)cboFilterType.SelectedIndex;
            if (processListSelectDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilter.Text = processListSelectDialog.SelectedValue;
                cboFilterType.SelectedIndex = (int)processListSelectDialog.ProcessCollectorFilterType;
            }            
        }

        private void nudMemWarn_ValueChanged(object sender, EventArgs e)
        {
            lblMemWarningFormatted.Text = FormatUtils.FormatFileSize((long)nudMemWarn.Value * 1024);
        }

        private void nudMemErr_ValueChanged(object sender, EventArgs e)
        {
            lblMemErrorFormatted.Text = FormatUtils.FormatFileSize((long)nudMemErr.Value * 1024);
        }


        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (CheckControls(true))
            {
                ProcessCollectorConfigEntry testEntry = new ProcessCollectorConfigEntry()
                {
                    Name = txtName.Text,
                    ProcessFilterType = (ProcessCollectorFilterType)cboFilterType.SelectedIndex,
                    ProcessFilter = txtFilter.Text,
                    ProcessCollectorTestType = (ProcessCollectorTestType)cboTestType.SelectedIndex,
                    MinimumRunningInstanceCount = (int)nudMinInstanceCount.Value,
                    MaximumRunningInstanceCount = (int)nudMaxInstanceCount.Value,
                    ProcessorPercWarningTrigger = (int)nudCPUWarn.Value,
                    ProcessorPercErrorTrigger = (int)nudCPUErr.Value,
                    MemoryKBWarningTrigger = (int)nudMemWarn.Value,
                    MemoryKBErrorTrigger = (int)nudMemErr.Value,
                    ThreadCountWarningTrigger = (int)nudThreadCountWarn.Value,
                    ThreadCountErrorTrigger = (int)nudThreadCountErr.Value
                };
                MonitorState testState = testEntry.GetCurrentState();
                string value = testState.ReadFirstValue(true);
                string rawDetails = testState.ReadAllRawDetails();

                Forms.ShowTextDialog td = new Forms.ShowTextDialog();
                td.Height = 300;
                td.ShowText("Test results", string.Format($"State: {testState.State}\r\n\r\nValue: {value}\r\nDetails: {rawDetails}"), true);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CheckControls(true))
            {
                if (SelectedEntry == null)
                    SelectedEntry = new ProcessCollectorConfigEntry();
                ProcessCollectorConfigEntry selectedEntry = (ProcessCollectorConfigEntry)SelectedEntry;
                selectedEntry.Name = txtName.Text;
                selectedEntry.ProcessFilterType = (ProcessCollectorFilterType)cboFilterType.SelectedIndex;
                selectedEntry.ProcessFilter = txtFilter.Text;
                selectedEntry.ProcessCollectorTestType = (ProcessCollectorTestType)cboTestType.SelectedIndex;
                selectedEntry.MinimumRunningInstanceCount = (int)nudMinInstanceCount.Value;
                selectedEntry.MaximumRunningInstanceCount = (int)nudMaxInstanceCount.Value;
                selectedEntry.ProcessorPercWarningTrigger = (int)nudCPUWarn.Value;
                selectedEntry.ProcessorPercErrorTrigger = (int)nudCPUErr.Value;
                selectedEntry.MemoryKBWarningTrigger = (int)nudMemWarn.Value;
                selectedEntry.MemoryKBErrorTrigger = (int)nudMemErr.Value;
                selectedEntry.ThreadCountWarningTrigger = (int)nudThreadCountWarn.Value;
                selectedEntry.ThreadCountErrorTrigger = (int)nudThreadCountErr.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void EnableDisableControls()
        {
            if (cboFilterType.SelectedIndex == -1)
                cboFilterType.SelectedIndex = 0;
            if (cboTestType.SelectedIndex == -1)
                cboTestType.SelectedIndex = 0;
            if (cboTestType.SelectedIndex == 0 || cboTestType.SelectedIndex == 1)
            {
                nudMinInstanceCount.Enabled = false;
                nudMaxInstanceCount.Enabled = false;
                nudCPUWarn.Enabled = false;
                nudCPUErr.Enabled = false;
                nudMemWarn.Enabled = false;
                nudMemErr.Enabled = false;
                nudThreadCountWarn.Enabled = false;
                nudThreadCountErr.Enabled = false;
            }
            else if (cboTestType.SelectedIndex == 2)
            {
                nudMinInstanceCount.Enabled = true;
                nudMaxInstanceCount.Enabled = true;
                nudCPUWarn.Enabled = false;
                nudCPUErr.Enabled = false;
                nudMemWarn.Enabled = false;
                nudMemErr.Enabled = false;
                nudThreadCountWarn.Enabled = false;
                nudThreadCountErr.Enabled = false;
            }
            else if (cboTestType.SelectedIndex == 3)
            {
                nudMinInstanceCount.Enabled = false;
                nudMaxInstanceCount.Enabled = false;
                nudCPUWarn.Enabled = false;
                nudCPUErr.Enabled = false;
                nudMemWarn.Enabled = false;
                nudMemErr.Enabled = false;
                nudThreadCountWarn.Enabled = true;
                nudThreadCountErr.Enabled = true;
            }
            else
            {
                nudMinInstanceCount.Enabled = false;
                nudMaxInstanceCount.Enabled = false;
                nudCPUWarn.Enabled = true;
                nudCPUErr.Enabled = true;
                nudMemWarn.Enabled = true;
                nudMemErr.Enabled = true;
                nudThreadCountWarn.Enabled = false;
                nudThreadCountErr.Enabled = false;
            }
            
        }
        private bool CheckControls(bool warningPrompt = false)
        {
            bool success = false;
            if (txtName.Text.Length < 3)
            {
                if (warningPrompt)
                {
                    MessageBox.Show("You must specify a name for the entry!", "Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                }
            }
            else if (txtFilter.Text.Length < 3)
            {
                if (warningPrompt)
                {
                    MessageBox.Show("You must specify a filter to find the process!", "Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFilter.Focus();
                }
            }
            else if (cboTestType.SelectedIndex == 2 && nudMinInstanceCount.Value > nudMaxInstanceCount.Value)
            {
                MessageBox.Show("The minimum instance count must be less than the maximum!", "Instance count", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMinInstanceCount.Focus();
            }
            else if (cboTestType.SelectedIndex == 3 && nudThreadCountWarn.Value > nudThreadCountErr.Value)
            {
                MessageBox.Show("The thread warning value must be less than the error value!", "Threads", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMemWarn.Focus();
            }
            else if (cboTestType.SelectedIndex == 4 && nudCPUWarn.Value > nudCPUErr.Value)
            {
                MessageBox.Show("The CPU warning value must be less than the error value!", "CPU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCPUWarn.Focus();
            }
            else if (cboTestType.SelectedIndex == 4 && nudMemWarn.Value > nudMemErr.Value)
            {
                MessageBox.Show("The memory warning value must be less than the error value!", "Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudMemWarn.Focus();
            }
            else
            {
                success = true;
            }           

            return success;
        }

    }
}
