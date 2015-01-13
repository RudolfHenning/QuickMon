using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;
using QuickMon.Utils;

namespace QuickMon.Collectors
{
    public partial class WMIQueryCollectorEditEntry : Form, ICollectorConfigEntryEditWindow
    {
        public WMIQueryCollectorEditEntry()
        {
            InitializeComponent();
            SelectedEntry = new WMIQueryCollectorConfigEntry();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {
            return (QuickMonDialogResult)ShowDialog();
        }
        #endregion

        #region Form events
        private void EditConfigEntry_Load(object sender, EventArgs e)
        {

        }
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            if (SelectedEntry != null)
            {
                WMIQueryCollectorConfigEntry selectedEntry = (WMIQueryCollectorConfigEntry)SelectedEntry;            
                txtName.Text = selectedEntry.Name;
                txtNamespace.Text = selectedEntry.Namespace == null ? "root\\CIMV2" : selectedEntry.Namespace;
                txtMachines.Text = selectedEntry.Machinename == null ? "." : selectedEntry.Machinename;
                txtStateQuery.Text = selectedEntry.StateQuery;
                chkIsReturnValueInt.Checked = selectedEntry.ReturnValueIsInt;
                chkReturnValueNotInverted.Checked = !selectedEntry.ReturnValueInverted;
                chkUseRowCountAsValue.Checked = selectedEntry.UseRowCountAsValue;
                cboSuccessValue.Text = selectedEntry.SuccessValue;
                cboWarningValue.Text = selectedEntry.WarningValue;
                cboErrorValue.Text = selectedEntry.ErrorValue;
                txtDetailQuery.Text = selectedEntry.DetailQuery;
                txtColumnNames.Text = selectedEntry.ColumnNames.ToCSVString();
            }
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
                    WMIQueryCollectorConfigEntry tmpWMIConfig = new WMIQueryCollectorConfigEntry();
                    tmpWMIConfig.Name = txtName.Text;
                    tmpWMIConfig.Namespace = txtNamespace.Text;
                    tmpWMIConfig.Machinename = txtMachines.Text;
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
                        returnValue = tmpWMIConfig.RunQueryWithCountResult();
                    }
                    else
                    {
                        lastStep = "Run summary query";
                        if (returnValue.IsIntegerTypeNumber())
                        {
                            object currentValue = null;
                            currentValue = tmpWMIConfig.RunQueryWithSingleResult();
                            if (currentValue.IsNumber())
                                returnValue = (decimal)currentValue;
                            else
                                throw new Exception(string.Format("Return value is not an integer!\r\nValue returned: {0}", returnValue));
                        }
                        else
                            returnValue = tmpWMIConfig.RunQueryWithSingleResult();
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
                    StringBuilder sbColumns = new StringBuilder();
                    for (int i = 1; i < columns.Count; i++)
                        sbColumns.AppendLine(columns[i].ColumnName);
                    foreach (string columnName in tmpWMIConfig.ColumnNames)
                    {
                        if ((from c in columns
                             where c.ColumnName.ToUpper() == columnName.ToUpper()
                             select c).Count() != 1)
                        {
                            columnWarningText += columnName + ", ";
                        }
                    }
                    if (chkCopyColumnNames.Checked)
                    {
                        Clipboard.SetText(sbColumns.ToString());
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
                if (SelectedEntry == null)
                    SelectedEntry = new WMIQueryCollectorConfigEntry();
                WMIQueryCollectorConfigEntry selectedEntry = (WMIQueryCollectorConfigEntry)SelectedEntry;
                
                selectedEntry.Name = txtName.Text;
                selectedEntry.Namespace = txtNamespace.Text;
                selectedEntry.Machinename = txtMachines.Text;
                selectedEntry.StateQuery = txtStateQuery.Text;
                selectedEntry.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                selectedEntry.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                selectedEntry.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                selectedEntry.SuccessValue = cboSuccessValue.Text;
                selectedEntry.WarningValue = cboWarningValue.Text;
                selectedEntry.ErrorValue = cboErrorValue.Text;
                selectedEntry.DetailQuery = txtDetailQuery.Text;
                selectedEntry.ColumnNames = txtColumnNames.Text.ToListFromCSVString();

                SelectedEntry = selectedEntry;
                //WmiIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        private void cmdEditSummaryQuery_Click(object sender, EventArgs e)
        {
            EditWMIQuery editWMIQuery = new EditWMIQuery();
            editWMIQuery.MachineName = txtMachines.Text;
            editWMIQuery.RootNameSpace = txtNamespace.Text;
            editWMIQuery.QueryText = txtStateQuery.Text;
            if (editWMIQuery.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMachines.Text = editWMIQuery.MachineName;
                txtNamespace.Text = editWMIQuery.RootNameSpace;
                txtStateQuery.Text = editWMIQuery.QueryText;
            }
        }
        private void cmdEditDetailsQuery_Click(object sender, EventArgs e)
        {
            EditWMIQuery editWMIQuery = new EditWMIQuery();
            editWMIQuery.MachineName = txtMachines.Text;
            editWMIQuery.RootNameSpace = txtNamespace.Text;
            editWMIQuery.QueryText = txtDetailQuery.Text;
            if (editWMIQuery.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMachines.Text = editWMIQuery.MachineName;
                txtNamespace.Text = editWMIQuery.RootNameSpace;
                txtDetailQuery.Text = editWMIQuery.QueryText;
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
                WMIQueryCollectorConfigEntry tmpWMIConfig = new WMIQueryCollectorConfigEntry();
                tmpWMIConfig.Name = txtName.Text;
                tmpWMIConfig.Namespace = txtNamespace.Text;
                tmpWMIConfig.Machinename = txtMachines.Text;
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
        private void CheckTestOKEnabled()
        {
            cmdOK.Enabled = txtName.Text.Length > 0 && txtNamespace.Text.Length > 0 && txtMachines.Text.Length > 0 &&
                txtStateQuery.Text.Length > 0 &&
                cboSuccessValue.Text.Length > 0 && cboWarningValue.Text.Length > 0 && cboErrorValue.Text.Length > 0 &&
                txtDetailQuery.Text.Length > 0;
            cmdTestDB.Enabled = txtName.Text.Length > 0 && txtNamespace.Text.Length > 0 && txtMachines.Text.Length > 0 &&
                txtStateQuery.Text.Length > 0 &&
                cboSuccessValue.Text.Length > 0 && cboWarningValue.Text.Length > 0 && cboErrorValue.Text.Length > 0 &&
                txtDetailQuery.Text.Length > 0;
        }
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void txtNamespace_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void txtMachines_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void txtStateQuery_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void cboErrorValue_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void cboWarningValue_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void cboSuccessValue_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }
        private void txtDetailQuery_TextChanged(object sender, EventArgs e)
        {
            CheckTestOKEnabled();
        }


    }
}
