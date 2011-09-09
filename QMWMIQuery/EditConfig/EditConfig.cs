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
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
            WmiIConfig = new WMIConfig();
        }

        public WMIConfig WmiIConfig { get; set; }

        public DialogResult ShowConfig()
        {
            return ShowDialog();
        }

        #region Form events
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            txtNamespace.Text = WmiIConfig.Namespace;
            txtMachines.Text = WmiIConfig.Machines.ToCSVString();
            txtStateQuery.Text = WmiIConfig.StateQuery;
            chkIsReturnValueInt.Checked = WmiIConfig.ReturnValueIsInt;
            chkReturnValueNotInverted.Checked = !WmiIConfig.ReturnValueInverted;
            chkUseRowCountAsValue.Checked = WmiIConfig.UseRowCountAsValue;
            cboSuccessValue.Text = WmiIConfig.SuccessValue;
            cboWarningValue.Text = WmiIConfig.WarningValue;
            cboErrorValue.Text = WmiIConfig.ErrorValue;
            txtDetailQuery.Text = WmiIConfig.DetailQuery;
            txtColumnNames.Text = WmiIConfig.ColumnNames.ToCSVString();
            //keyColumnNumericUpDown.Value = WmiIConfig.KeyColumn;
        } 
        #endregion

        #region Button events
        private void cmdEditMachineNames_Click(object sender, EventArgs e)
        {
            CSVEditor csvEditor = new CSVEditor();
            csvEditor.Text = "Machine names";
            csvEditor.ItemDescription = "Machine";
            csvEditor.CSVData = txtMachines.Text;
            if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMachines.Text = csvEditor.CSVData;
            }
        }
        private void cmdEditColumnNames_Click(object sender, EventArgs e)
        {
            CSVEditor csvEditor = new CSVEditor();
            csvEditor.Text = "Column names";
            csvEditor.ItemDescription = "Column";
            csvEditor.Sorted = false;
            csvEditor.CSVData = txtColumnNames.Text;
            if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtColumnNames.Text = csvEditor.CSVData;
            }
        }
        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string lastStep = "Initialize values";
                string columnWarningText = "";
                try
                {
                    WMIConfig tmpWMIConfig = new WMIConfig();
                    tmpWMIConfig.Namespace = txtNamespace.Text;
                    tmpWMIConfig.Machines = txtMachines.Text.ToListFromCSVString(true);
                    tmpWMIConfig.StateQuery = txtStateQuery.Text;
                    tmpWMIConfig.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                    tmpWMIConfig.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    tmpWMIConfig.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                    tmpWMIConfig.SuccessValue = cboSuccessValue.Text;
                    tmpWMIConfig.WarningValue = cboWarningValue.Text;
                    tmpWMIConfig.ErrorValue = cboErrorValue.Text;
                    tmpWMIConfig.DetailQuery = txtDetailQuery.Text;
                    tmpWMIConfig.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
                    //tmpWMIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;

                    object returnValue = null;
                    if (tmpWMIConfig.UseRowCountAsValue)
                    {
                        lastStep = "Run summary query (row count as value)";
                        returnValue = tmpWMIConfig.RunQueryWithCountResult(tmpWMIConfig.Machines[0]);
                    }
                    else
                    {
                        lastStep = "Run summary query";
                        returnValue = tmpWMIConfig.RunQueryWithSingleResult(tmpWMIConfig.Machines[0]);
                    }

                    if (tmpWMIConfig.ReturnValueIsInt)
                    {
                        lastStep = "Test return value is an Integer";
                        if (!returnValue.IsIntegerTypeNumber())
                            throw new Exception(string.Format("Return value is not an integer!\r\nValue returned: {0}", returnValue));
                    }
                    //testing detail query
                    lastStep = "Testing detail query - Getting column names";
                    List<DataColumn> columns = tmpWMIConfig.GetDetailQueryColumns();
                    lastStep = "Testing detail query - Custom column name sequence check";
                    foreach (string columnName in tmpWMIConfig.ColumnNames)
                    {
                        if ((from c in columns
                             where c.ColumnName.ToUpper() == columnName.ToUpper()
                             select c).Count() != 1)
                        {
                            columnWarningText += columnName + ", ";
                        }
                    }

                    lastStep = "Testing detail query";
                    DataSet ds = tmpWMIConfig.RunDetailQuery();
                    if (columnWarningText.Length == 0)
                        MessageBox.Show(string.Format("Success!\r\nSummary value return: {0}\r\nDetail row count: {1}\r\nDetail columns: {2}", returnValue, ds.Tables[0].Rows.Count, columns.ToCSVString()), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(string.Format("Success (with warning)!\r\nSummary value return: {0}\r\nDetail row count: {1}\r\nDetail columns returned: {2}\r\nColumns not found: {3}", returnValue, ds.Tables[0].Rows.Count, columns.ToCSVString(), columnWarningText), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Failed!\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                WmiIConfig.Namespace = txtNamespace.Text;
                WmiIConfig.Machines = txtMachines.Text.ToListFromCSVString(true);
                WmiIConfig.StateQuery = txtStateQuery.Text;
                WmiIConfig.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                WmiIConfig.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                WmiIConfig.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                WmiIConfig.SuccessValue = cboSuccessValue.Text;
                WmiIConfig.WarningValue = cboWarningValue.Text;
                WmiIConfig.ErrorValue = cboErrorValue.Text;
                WmiIConfig.DetailQuery = txtDetailQuery.Text;
                WmiIConfig.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
                //WmiIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region Other control events
        private void chkIsReturnValueInt_CheckedChanged(object sender, EventArgs e)
        {
            chkReturnValueNotInverted.Enabled = chkIsReturnValueInt.Checked;
            chkUseRowCountAsValue.Enabled = chkIsReturnValueInt.Checked;
        }
        private void lblColumnNameSequence_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                WMIConfig tmpWMIConfig = new WMIConfig();
                tmpWMIConfig.Namespace = txtNamespace.Text;
                tmpWMIConfig.Machines = txtMachines.Text.ToListFromCSVString(true);
                tmpWMIConfig.StateQuery = txtStateQuery.Text;
                tmpWMIConfig.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                tmpWMIConfig.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                tmpWMIConfig.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                tmpWMIConfig.SuccessValue = cboSuccessValue.Text;
                tmpWMIConfig.WarningValue = cboWarningValue.Text;
                tmpWMIConfig.ErrorValue = cboErrorValue.Text;
                tmpWMIConfig.DetailQuery = txtDetailQuery.Text;
                tmpWMIConfig.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
               // tmpWMIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;

                List<DataColumn> columns = tmpWMIConfig.GetDetailQueryColumns();
                txtColumnNames.Text = "";
                columns.ForEach(c => txtColumnNames.Text += c.ColumnName + ", ");
                txtColumnNames.Text = txtColumnNames.Text.TrimEnd(' ', ',');
            }
            catch { }
        }
        #endregion

        #region Private events
        private bool DoValidate()
        {
            try
            {
                if (txtNamespace.Text.Length == 0)
                    throw new InPutValidationException("Namespace must be specified!", txtNamespace);
                if (txtMachines.Text.Length == 0 || txtMachines.Text.ToListFromCSVString(true).Count == 0)
                    throw new InPutValidationException("There must be at least one machine name!", txtMachines);
                if ((cboSuccessValue.Text == "[null]" && cboWarningValue.Text == "[null]") ||
                    (cboSuccessValue.Text == "[null]" && cboErrorValue.Text == "[null]") ||
                    (cboWarningValue.Text == "[null]" && cboErrorValue.Text == "[null]"))
                {
                    throw new InPutValidationException("Only one value can be [null]!", cboSuccessValue);
                }
                if ((cboSuccessValue.Text == "[any]" && cboWarningValue.Text == "[any]") ||
                    (cboSuccessValue.Text == "[any]" && cboErrorValue.Text == "[any]") ||
                    (cboWarningValue.Text == "[any]" && cboErrorValue.Text == "[any]"))
                {
                    throw new InPutValidationException("Only one value can be [any]!", cboSuccessValue);
                }
                if (chkIsReturnValueInt.Checked)
                {
                    if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" && !cboSuccessValue.Text.IsLong())
                        throw new InPutValidationException("Success value must be a valid integer!\r\n(or predefined values [any] or [null])", cboSuccessValue);
                    else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" && !cboWarningValue.Text.IsLong())
                        throw new InPutValidationException("Warning value must be a valid integer!\r\n(or predefined values [any] or [null])", cboWarningValue);
                    else if (cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" && !cboErrorValue.Text.IsLong())
                        throw new InPutValidationException("Error value must be a valid integer!\r\n(or predefined values [any] or [null])", cboErrorValue);
                    else if (chkReturnValueNotInverted.Checked)
                    {
                        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            long.Parse(cboSuccessValue.Text) >= long.Parse(cboWarningValue.Text))
                            throw new InPutValidationException("Success value must smaller than Warning value", cboSuccessValue);
                        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                            int.Parse(cboWarningValue.Text) >= long.Parse(cboErrorValue.Text))
                            throw new InPutValidationException("Warning value must smaller than Error value", cboWarningValue);
                    }
                    else if (!chkReturnValueNotInverted.Checked)
                    {
                        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            long.Parse(cboSuccessValue.Text) <= long.Parse(cboWarningValue.Text))
                            throw new InPutValidationException("Success value must bigger than Warning value", cboSuccessValue);
                        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                            long.Parse(cboWarningValue.Text) <= long.Parse(cboErrorValue.Text))
                            throw new InPutValidationException("Warning value must bigger than Error value", cboWarningValue);
                    }
                }
                return true;
            }
            catch (InPutValidationException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (ex.ValidatedObject is Control)
                    ((Control)ex.ValidatedObject).Focus();
                return false;
            }
        } 
        #endregion

    }    
}
