using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class EditPerfCounterAlert : Form
    {
        public EditPerfCounterAlert()
        {
            InitializeComponent();
            InitialMachine = ".";
        }

        public QMPerfCounterInstance SelectedPCInstance { get; set; }
        public string InitialMachine { get; set; }

        #region Form events
        private void EditPerfCounterAlert_Shown(object sender, EventArgs e)
        {
            if (SelectedPCInstance == null) //Show add performance window.
            {
                EditPerfCounter editPerfCounter = new EditPerfCounter();
                editPerfCounter.InitialMachine = InitialMachine;
                editPerfCounter.InitialCategory = "Processor";
                editPerfCounter.InitialCounter = "% Processor Time";
                editPerfCounter.InitialInstance = "_Total";
                if (editPerfCounter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectedPCInstance = editPerfCounter.SelectedPCInstance;
                }
                else
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    Close();
                    return;
                }
            }
            txtPerfCounter.Text = SelectedPCInstance.ToString();
            invertValuesCheckBox.Checked = !SelectedPCInstance.ReturnValueInverted;
            warningNumericUpDown.Value = (decimal)SelectedPCInstance.WarningValue;
            errorNumericUpDown.Value = (decimal)SelectedPCInstance.ErrorValue;
        }        
        #endregion

        #region Button events
        private void cmdEditPerfCounter_Click(object sender, EventArgs e)
        {
            EditPerfCounter editPerfCounter = new EditPerfCounter();
            editPerfCounter.InitialMachine = SelectedPCInstance.Computer;
            editPerfCounter.InitialCategory = SelectedPCInstance.Category;
            editPerfCounter.InitialCounter = SelectedPCInstance.Counter;
            editPerfCounter.InitialInstance = SelectedPCInstance.Instance;
            if (editPerfCounter.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedPCInstance = editPerfCounter.SelectedPCInstance;
                txtPerfCounter.Text = SelectedPCInstance.ToString();
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SelectedPCInstance.ReturnValueInverted = !invertValuesCheckBox.Checked;
                SelectedPCInstance.WarningValue = (float)warningNumericUpDown.Value;
                SelectedPCInstance.ErrorValue = (float)errorNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Private methods
        private bool IsValid()
        {
            if (invertValuesCheckBox.Checked && warningNumericUpDown.Value >= errorNumericUpDown.Value)
            {
                MessageBox.Show("Warning value must be less than the error value", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!invertValuesCheckBox.Checked && warningNumericUpDown.Value <= errorNumericUpDown.Value)
            {
                MessageBox.Show("Warning value must be more than the error value", "Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        } 
        #endregion
    }
}
