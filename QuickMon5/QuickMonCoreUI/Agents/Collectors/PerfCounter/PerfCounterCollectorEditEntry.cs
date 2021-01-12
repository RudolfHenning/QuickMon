using QuickMon.Collectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class PerfCounterCollectorEditEntry : CollectorConfigEntryEditWindowBase// Form, ICollectorConfigEntryEditWindow
    {
        public PerfCounterCollectorEditEntry()
        {
            InitializeComponent();
            commonEntries.Add("Processor\\% Processor Time\\_Total");
            commonEntries.Add("LogicalDisk\\% Disk Time\\_Total");
            commonEntries.Add("LogicalDisk\\% Disk Time\\C:");
            commonEntries.Add("LogicalDisk\\% Free Space\\_Total");
            commonEntries.Add("LogicalDisk\\% Free Space\\C:");
            commonEntries.Add("LogicalDisk\\Current Disk Queue Length\\_Total");
            commonEntries.Add("LogicalDisk\\Current Disk Queue Length\\C:");
            commonEntries.Add("Memory\\% Committed Bytes In Use\\");
            commonEntries.Add("Paging File\\% Usage\\_Total");
            commonEntries.Add("Process\\% Processor Time\\explorer");
            commonEntries.Add("Process\\Thread Count\\explorer");
        }

        private List<string> commonEntries = new List<string>();

        //#region IEditConfigEntryWindow Members
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    return (QuickMonDialogResult)ShowDialog();
        //}
        //public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        //#endregion

        #region Form events
        private void PerfCounterCollectorEditEntry_Load(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = PerfCounterCollectorEntry.FromStringDefinition(".\\Processor\\% Processor Time\\_Total");
            cboPerformanceCounter.Items.Clear();
            cboPerformanceCounter.Items.AddRange(commonEntries.ToArray());

            LoadEntryDetails();
        }
        #endregion

        #region Private methods
        private void LoadEntryDetails()
        {
            optCustom.Checked = true;
            PerfCounterCollectorEntry currentEntry = (PerfCounterCollectorEntry)SelectedEntry;
            txtComputerName.Text = currentEntry.Computer;
            string pcNameWithoutMachineName = currentEntry.PCNameWithoutComputerName;
            foreach (var commonItem in cboPerformanceCounter.Items)
            {
                if (commonItem.ToString().ToLower() == pcNameWithoutMachineName.ToLower())
                {
                    cboPerformanceCounter.SelectedItem = commonItem;
                    optCommon.Checked = true;
                }
            }
            txtPerfCounter.Text = currentEntry.Description;

            warningNumericUpDown.Value = (decimal)currentEntry.WarningValue;
            errorNumericUpDown.Value = (decimal)currentEntry.ErrorValue;
            nudValueScale.Value = currentEntry.OutputValueScaleFactor;
            chkInverseScale.Checked = currentEntry.OutputValueScaleFactorInverse;

            nudNumberOfSamplesPerRefresh.SaveValueSet((decimal)currentEntry.NumberOfSamplesPerRefresh);
            nudMultiSampleWaitMS.SaveValueSet((decimal)currentEntry.MultiSampleWaitMS);
            cboOutputValueUnit.Text = currentEntry.OutputValueUnit;
            cboInstanceValueAggregation.SelectedIndex = (int)currentEntry.InstanceValueAggregationStyle;
            CheckOkEnabled();
        }
        private bool IsValid(bool showPrompt = false)
        {
            bool success = false;
            try
            {
                if (warningNumericUpDown.Value == errorNumericUpDown.Value)
                {
                    if (showPrompt)
                        MessageBox.Show("Warning and Error values vannot be the same!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    success = false;
                }
                else if (warningNumericUpDown.Value < errorNumericUpDown.Value && warningNumericUpDown.Value == 0)
                {
                    if (showPrompt)
                        MessageBox.Show("Warning value cannot be 0 if it is less than the Error value!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    success = false;
                }
                else
                {
                    PerfCounterCollectorEntry currentEntry = null;
                    string computerName = ApplyConfigVarsOnField(txtComputerName.Text);
                    string perfCounterText = ApplyConfigVarsOnField(txtPerfCounter.Text);
                    if (optCommon.Checked)
                    {
                        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(computerName + "\\" + cboPerformanceCounter.Text);
                    }
                    else
                    {
                        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(perfCounterText);
                    }
                    if (currentEntry == null || currentEntry.Computer.Length == 0)
                    {
                        if (showPrompt)
                            MessageBox.Show("Performance counter definition could not be created!", "Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        success = false;
                    }
                    else
                    {
                        success = true;
                        currentEntry.WarningValue = (float)warningNumericUpDown.Value;
                        currentEntry.ErrorValue = (float)errorNumericUpDown.Value;
                        currentEntry.OutputValueScaleFactor = (int)nudValueScale.Value;
                        currentEntry.OutputValueScaleFactorInverse = chkInverseScale.Checked;
                        currentEntry.NumberOfSamplesPerRefresh = (int)nudNumberOfSamplesPerRefresh.Value;
                        currentEntry.MultiSampleWaitMS = (int)nudMultiSampleWaitMS.Value;
                        currentEntry.OutputValueUnit = cboOutputValueUnit.Text;
                        currentEntry.InstanceValueAggregationStyle = (AggregationStyle)cboInstanceValueAggregation.SelectedIndex;

                        MonitorState currentState = currentEntry.GetCurrentState();
                        float val = float.Parse(currentState.CurrentValue.ToString());// currentEntry.GetNextValue();

                        if (showPrompt)
                            MessageBox.Show(string.Format("Test was successful\r\n{0}", currentState.ReadAllRawDetails()), "Performance counter test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                if (showPrompt)
                    MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                success = false;
            }
            return success;
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = (optCommon.Checked && txtComputerName.Text.Length > 0 && cboPerformanceCounter.SelectedIndex > -1) ||
                    (optCustom.Checked && txtPerfCounter.Text.Length > 0);
        }
        #endregion

        #region Control events
        private void optCommon_CheckedChanged(object sender, EventArgs e)
        {
            txtComputerName.Enabled = optCommon.Checked;
            cboPerformanceCounter.Enabled = optCommon.Checked;
            txtPerfCounter.Enabled = optCustom.Checked;
            cmdEditPerfCounter.Enabled = optCustom.Checked;
        }
        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
        {
            try
            {
                PerfCounterCollectorEntry thisEntry = PerfCounterCollectorEntry.FromStringDefinition(txtPerfCounter.Text);

                PerfCounterEdit editPerfCounter = new PerfCounterEdit();
                editPerfCounter.InitialMachine = thisEntry.Computer;
                editPerfCounter.InitialCategory = thisEntry.Category;
                editPerfCounter.InitialCounter = thisEntry.Counter;
                editPerfCounter.InitialInstance = thisEntry.Instance;
                editPerfCounter.ConfigVariables = ConfigVariables;
                if (editPerfCounter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedEntry = editPerfCounter.SelectedPCInstance;
                    txtPerfCounter.Text = editPerfCounter.SelectedPCInstance.Description;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtComputerName_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cboPerformanceCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtPerfCounter_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chkVerifyOnOK.Checked || IsValid())
                {
                    PerfCounterCollectorEntry currentEntry = null;
                    if (optCommon.Checked)
                    {
                        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(txtComputerName.Text + "\\" + cboPerformanceCounter.Text);
                    }
                    else
                    {
                        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(txtPerfCounter.Text);
                    }
                    if (currentEntry == null || currentEntry.Computer.Length == 0)
                        MessageBox.Show("Performance counter definition could not be created!", "Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                    {
                        currentEntry.WarningValue = (float)warningNumericUpDown.Value;
                        currentEntry.ErrorValue = (float)errorNumericUpDown.Value;
                        currentEntry.OutputValueScaleFactor = (int)nudValueScale.Value;
                        currentEntry.OutputValueScaleFactorInverse = chkInverseScale.Checked;
                        currentEntry.NumberOfSamplesPerRefresh = (int)nudNumberOfSamplesPerRefresh.Value;
                        currentEntry.MultiSampleWaitMS = (int)nudMultiSampleWaitMS.Value;
                        currentEntry.OutputValueUnit = cboOutputValueUnit.Text;
                        currentEntry.InstanceValueAggregationStyle = (AggregationStyle)cboInstanceValueAggregation.SelectedIndex;
                        SelectedEntry = currentEntry;
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdSample_Click(object sender, EventArgs e)
        {
            IsValid(true);
            //try
            //{
            //    PerfCounterCollectorEntry currentEntry = null;
            //    string computerName = ApplyConfigVarsOnField(txtComputerName.Text);
            //    string perfCounterText = ApplyConfigVarsOnField(txtPerfCounter.Text);
            //    if (optCommon.Checked)
            //    {
            //        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(computerName + "\\" + cboPerformanceCounter.Text);
            //    }
            //    else
            //    {
            //        currentEntry = PerfCounterCollectorEntry.FromStringDefinition(perfCounterText);
            //    }
            //    if (currentEntry == null || currentEntry.Computer.Length == 0)
            //        MessageBox.Show("Performance counter definition could not be created!", "Definition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    else
            //    {
            //        float val = currentEntry.GetNextValue();
            //        Clipboard.SetText(val.ToString("F4"));
            //        MessageBox.Show(string.Format("Current value: {0}", val.ToString("F4")), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        
        #endregion

    }
}
