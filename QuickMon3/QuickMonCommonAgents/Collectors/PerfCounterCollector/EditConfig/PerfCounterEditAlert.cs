using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class PerfCounterEditAlert : Form, IEditConfigEntryWindow
    {
        public PerfCounterEditAlert()
        {
            InitializeComponent();
            InitialMachine = ".";
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public DialogResult ShowEditEntry()
        {
            return ShowDialog();
        }
        #endregion

        PerfCounterCollectorEntry currentEntry = null;

        public PerfCounterCollectorEntry SelectedPCInstance { get; set; }
        public string InitialMachine { get; set; }

        #region Form events
        private void PerfCounterEditAlert_Shown(object sender, EventArgs e)
        {
            currentEntry = new PerfCounterCollectorEntry();
            if (SelectedEntry != null)
            {
                currentEntry = ((PerfCounterCollectorEntry)SelectedEntry).Clone();                
            }
            else //Show add performance window.
            {
                PerfCounterEdit editPerfCounter = new PerfCounterEdit();
                
                editPerfCounter.InitialMachine = InitialMachine;
                editPerfCounter.InitialCategory = "Processor";
                editPerfCounter.InitialCounter = "% Processor Time";
                editPerfCounter.InitialInstance = "_Total";
                if (editPerfCounter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    currentEntry = editPerfCounter.SelectedPCInstance;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    Close();
                    return;
                }
            }
            txtPerfCounter.Text = currentEntry.ToString();
            warningNumericUpDown.Value = (decimal)currentEntry.WarningValue;
            errorNumericUpDown.Value = (decimal)currentEntry.ErrorValue;
        }
        #endregion

        #region Button events
        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
        {
            PerfCounterCollectorEntry thisEntry = (PerfCounterCollectorEntry)currentEntry;
            PerfCounterEdit editPerfCounter = new PerfCounterEdit();
            editPerfCounter.InitialMachine = thisEntry.Computer;
            editPerfCounter.InitialCategory = thisEntry.Category;
            editPerfCounter.InitialCounter = thisEntry.Counter;
            editPerfCounter.InitialInstance = thisEntry.Instance;
            if (editPerfCounter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentEntry = editPerfCounter.SelectedPCInstance;
                txtPerfCounter.Text = currentEntry.ToString();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (SelectedEntry == null)
                    SelectedEntry = new PerfCounterCollectorEntry();

                ((PerfCounterCollectorEntry)SelectedEntry).Computer = currentEntry.Computer;
                ((PerfCounterCollectorEntry)SelectedEntry).Category = currentEntry.Category;
                ((PerfCounterCollectorEntry)SelectedEntry).Counter = currentEntry.Counter;
                ((PerfCounterCollectorEntry)SelectedEntry).Instance = currentEntry.Instance;
                ((PerfCounterCollectorEntry)SelectedEntry).ReturnValueInverted = (warningNumericUpDown.Value > errorNumericUpDown.Value);
                ((PerfCounterCollectorEntry)SelectedEntry).WarningValue = (float)warningNumericUpDown.Value;
                ((PerfCounterCollectorEntry)SelectedEntry).ErrorValue = (float)errorNumericUpDown.Value;
                //SelectedEntry = currentEntry;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private bool IsValid()
        {
            if (warningNumericUpDown.Value == errorNumericUpDown.Value)
            {
                MessageBox.Show("Warning and Error values vannot be the same!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (warningNumericUpDown.Value < errorNumericUpDown.Value && warningNumericUpDown.Value == 0)
            {
                MessageBox.Show("Warning value cannot be 0 if it is less than the Error value!", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }            
            return true;
        }
        #endregion

        private void cmdSample_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentEntry != null)
                {
                    float val = currentEntry.GetNextValue();
                    Clipboard.SetText(val.ToString("F4"));
                    MessageBox.Show(string.Format("Current value: {0}", val.ToString("F4")), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
