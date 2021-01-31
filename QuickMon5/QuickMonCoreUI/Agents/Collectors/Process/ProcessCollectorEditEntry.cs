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
                chkCheckPerf.Checked = selectedEntry.CheckPerformance;
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

        private void EnableDisableControls()
        {
            if (cboTestType.SelectedIndex == 2)
            {
                nudMinInstanceCount.Enabled = true;
                nudMaxInstanceCount.Enabled = true;
                chkCheckPerf.Enabled = true;
                nudCPUWarn.Enabled = chkCheckPerf.Checked;
                nudCPUErr.Enabled = chkCheckPerf.Checked;
                nudMemWarn.Enabled = chkCheckPerf.Checked;
                nudMemErr.Enabled = chkCheckPerf.Checked;
                nudThreadCountWarn.Enabled = chkCheckPerf.Checked;
                nudThreadCountErr.Enabled = chkCheckPerf.Checked;
            }
            else
            {
                nudMinInstanceCount.Enabled = false;
                nudMaxInstanceCount.Enabled = false;
                chkCheckPerf.Enabled = false;
                nudCPUWarn.Enabled = false;
                nudCPUErr.Enabled = false;
                nudMemWarn.Enabled = false;
                nudMemErr.Enabled = false;
                nudThreadCountWarn.Enabled = false;
                nudThreadCountErr.Enabled = false;
            }
        }


    }
}
