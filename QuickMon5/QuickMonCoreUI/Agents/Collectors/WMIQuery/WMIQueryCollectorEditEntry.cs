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
using QuickMon.Collectors;

namespace QuickMon.UI
{
    public partial class WMIQueryCollectorEditEntry : CollectorConfigEntryEditWindowBase //Form, ICollectorConfigEntryEditWindow
    {
        public WMIQueryCollectorEditEntry()
        {
            InitializeComponent();
            SelectedEntry = new WMIQueryCollectorConfigEntry();
        }

        //#region IEditConfigEntryWindow Members
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    return (QuickMonDialogResult)ShowDialog();
        //}
        //public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        //#endregion

        #region Form events
        private void EditConfigEntry_Load(object sender, EventArgs e)
        {
            if (SelectedEntry != null)
            {
                WMIQueryCollectorConfigEntry selectedEntry = (WMIQueryCollectorConfigEntry)SelectedEntry;            
                txtName.Text = selectedEntry.Name;
                txtNamespace.Text = selectedEntry.Namespace == null ? "root\\CIMV2" : selectedEntry.Namespace;
                txtMachines.Text = selectedEntry.Machinename == null ? "." : selectedEntry.Machinename;
                txtStateQuery.Text = selectedEntry.StateQuery;
                //chkIsReturnValueInt.Checked = selectedEntry.ReturnValueIsInt;
                //chkReturnValueNotInverted.Checked = !selectedEntry.ReturnValueInverted;
                chkUseRowCountAsValue.Checked = selectedEntry.UseRowCountAsValue;

                cboReturnCheckSequence.SelectedIndex = (int)selectedEntry.ReturnCheckSequence;
                txtSuccess.Text = selectedEntry.GoodValue;
                cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
                txtWarning.Text = selectedEntry.WarningValue;
                cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
                txtError.Text = selectedEntry.ErrorValue;
                cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;

                //txtDetailQuery.Text = selectedEntry.DetailQuery;
                //txtColumnNames.Text = selectedEntry.ColumnNames.ToCSVString();
                cboOutputValueUnit.Text = selectedEntry.OutputValueUnit;
            }
        }
        private void EditConfig_Shown(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Button events
        //private void cmdEditMachineNames_Click(object sender, EventArgs e)
        //{
        //    CSVEditor csvEditor = new CSVEditor();
        //    csvEditor.Text = "Machine names";
        //    csvEditor.ItemDescription = "Machine";
        //    csvEditor.CSVData = txtMachines.Text;
        //    if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        txtMachines.Text = csvEditor.CSVData;
        //    }
        //}
        //private void cmdEditColumnNames_Click(object sender, EventArgs e)
        //{
        //    CSVEditor csvEditor = new CSVEditor();
        //    csvEditor.Text = "Column names";
        //    csvEditor.ItemDescription = "Column";
        //    csvEditor.Sorted = false;
        //    csvEditor.CSVData = txtColumnNames.Text;
        //    if (csvEditor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        txtColumnNames.Text = csvEditor.CSVData;
        //    }
        //}
        private void cmdTestDB_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string lastStep = "Initialize values";
                //string columnWarningText = "";
                try
                {
                    WMIQueryCollectorConfigEntry tmpWMIConfig = new WMIQueryCollectorConfigEntry();
                    tmpWMIConfig.Name = txtName.Text;
                    tmpWMIConfig.Namespace = txtNamespace.Text;
                    tmpWMIConfig.Machinename = txtMachines.Text;
                    tmpWMIConfig.StateQuery = txtStateQuery.Text;

                    //tmpWMIConfig.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                    //tmpWMIConfig.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    tmpWMIConfig.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                    tmpWMIConfig.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                    tmpWMIConfig.GoodValue = txtSuccess.Text;
                    tmpWMIConfig.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                    tmpWMIConfig.WarningValue = txtWarning.Text;
                    tmpWMIConfig.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                    tmpWMIConfig.ErrorValue = txtError.Text;
                    tmpWMIConfig.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;

                    //tmpWMIConfig.DetailQuery = txtDetailQuery.Text;
                    //tmpWMIConfig.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
                    tmpWMIConfig.OutputValueUnit = cboOutputValueUnit.Text;

                    //tmpWMIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;

                    lastStep = "Run GetCurrentState";
                    MonitorState testState = tmpWMIConfig.GetCurrentState();

                    //testing detail query
                    //lastStep = "Testing detail query - Getting column names";
                    //List<DataColumn> columns = tmpWMIConfig.GetDetailQueryColumns();
                    //lastStep = "Testing detail query - Custom column name sequence check";
                    //StringBuilder sbColumns = new StringBuilder();
                    //for (int i = 1; i < columns.Count; i++)
                    //    sbColumns.AppendLine(columns[i].ColumnName);
                    //foreach (string columnName in tmpWMIConfig.ColumnNames)
                    //{
                    //    if ((from c in columns
                    //         where c.ColumnName.ToUpper() == columnName.ToUpper()
                    //         select c).Count() != 1)
                    //    {
                    //        columnWarningText += columnName + ", ";
                    //    }
                    //}
                    //if (chkCopyColumnNames.Checked)
                    //{
                    //    Clipboard.SetText(sbColumns.ToString());
                    //}

                    //lastStep = "Testing detail query";
                    //DataSet ds = tmpWMIConfig.RunDetailQuery();
                    //if (columnWarningText.Length == 0)
                    //    MessageBox.Show(string.Format("{0}!\r\nSummary value return: {1}\r\nDetail row count: {2}\r\nDetail columns: {3}", testState.State, tmpWMIConfig.CurrentAgentValue, ds.Tables[0].Rows.Count, columns.ToCSVString()), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //    MessageBox.Show(string.Format("{0} (with warning)!\r\nSummary value return: {1}\r\nDetail row count: {2}\r\nDetail columns returned: {3}\r\nColumns not found: {4}", testState.State, tmpWMIConfig.CurrentAgentValue, ds.Tables[0].Rows.Count, columns.ToCSVString(), columnWarningText), "Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    MessageBox.Show(string.Format("{0}!\r\nValue return: {1}", testState.State, testState.CurrentValue), "Test", MessageBoxButtons.OK,
                        testState.State == CollectorState.Good ? MessageBoxIcon.Information : testState.State == CollectorState.Warning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);

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
                //selectedEntry.ReturnValueIsInt = chkIsReturnValueInt.Checked;
                //selectedEntry.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                selectedEntry.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                selectedEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                selectedEntry.GoodValue = txtSuccess.Text;
                selectedEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                selectedEntry.WarningValue = txtWarning.Text;
                selectedEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                selectedEntry.ErrorValue = txtError.Text;
                selectedEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                //selectedEntry.DetailQuery = txtDetailQuery.Text;
                //selectedEntry.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
                selectedEntry.OutputValueUnit = cboOutputValueUnit.Text;

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
            if (editWMIQuery.ShowDialog() == DialogResult.OK)
            {
                txtMachines.Text = editWMIQuery.MachineName;
                txtNamespace.Text = editWMIQuery.RootNameSpace;
                txtStateQuery.Text = editWMIQuery.QueryText;
            }
        }
        //private void cmdEditDetailsQuery_Click(object sender, EventArgs e)
        //{
        //    EditWMIQuery editWMIQuery = new EditWMIQuery();
        //    editWMIQuery.MachineName = txtMachines.Text;
        //    editWMIQuery.RootNameSpace = txtNamespace.Text;
        //    //editWMIQuery.QueryText = txtDetailQuery.Text;
        //    if (editWMIQuery.ShowDialog() == DialogResult.OK)
        //    {
        //        txtMachines.Text = editWMIQuery.MachineName;
        //        txtNamespace.Text = editWMIQuery.RootNameSpace;
        //        //txtDetailQuery.Text = editWMIQuery.QueryText;
        //    }
        //}
        #endregion

        #region Other control events
        //private void chkIsReturnValueInt_CheckedChanged(object sender, EventArgs e)
        //{
        //    //chkReturnValueNotInverted.Enabled = chkIsReturnValueInt.Checked;
        //    //chkUseRowCountAsValue.Enabled = chkIsReturnValueInt.Checked;
        //}
        //private void lblColumnNameSequence_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        WMIQueryCollectorConfigEntry tmpWMIConfig = new WMIQueryCollectorConfigEntry();
        //        tmpWMIConfig.Name = txtName.Text;
        //        tmpWMIConfig.Namespace = txtNamespace.Text;
        //        tmpWMIConfig.Machinename = txtMachines.Text;
        //        tmpWMIConfig.StateQuery = txtStateQuery.Text;
        //        //tmpWMIConfig.ReturnValueIsInt = chkIsReturnValueInt.Checked;
        //        //tmpWMIConfig.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
        //        tmpWMIConfig.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
        //        tmpWMIConfig.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
        //        tmpWMIConfig.GoodValue = txtSuccess.Text;
        //        tmpWMIConfig.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
        //        tmpWMIConfig.WarningValue = txtWarning.Text;
        //        tmpWMIConfig.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
        //        tmpWMIConfig.ErrorValue = txtError.Text;
        //        tmpWMIConfig.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
        //        //tmpWMIConfig.DetailQuery = txtDetailQuery.Text;
        //        //tmpWMIConfig.ColumnNames = txtColumnNames.Text.ToListFromCSVString();
        //        // tmpWMIConfig.KeyColumn = (int)keyColumnNumericUpDown.Value;

        //        //List<DataColumn> columns = tmpWMIConfig.GetDetailQueryColumns();
        //        //txtColumnNames.Text = "";
        //        //columns.ForEach(c => txtColumnNames.Text += c.ColumnName + ", ");
        //        //txtColumnNames.Text = txtColumnNames.Text.TrimEnd(' ', ',');
        //    }
        //    catch { }
        //}
        #endregion

        #region Private events
        private void CheckTestOKEnabled()
        {
            cmdOK.Enabled = txtName.Text.Length > 0 && txtNamespace.Text.Length > 0 && txtMachines.Text.Length > 0 &&
                txtStateQuery.Text.Length > 0 &&
                txtSuccess.Text.Length > 0 && txtWarning.Text.Length > 0 && txtError.Text.Length > 0;
            cmdTestDB.Enabled = txtName.Text.Length > 0 && txtNamespace.Text.Length > 0 && txtMachines.Text.Length > 0 &&
                txtStateQuery.Text.Length > 0 &&
                txtSuccess.Text.Length > 0 && txtWarning.Text.Length > 0 && txtError.Text.Length > 0;
        }
        private bool DoValidate()
        {
            try
            {
                if (txtNamespace.Text.Length == 0)
                    throw new InPutValidationException("Namespace must be specified!", txtNamespace);
                if (txtMachines.Text.Length == 0 || txtMachines.Text.ToListFromCSVString(true).Count == 0)
                    throw new InPutValidationException("There must be at least one machine name!", txtMachines);
                if ((txtSuccess.Text == "[null]" && txtWarning.Text == "[null]") ||
                    (txtSuccess.Text == "[null]" && txtError.Text == "[null]") ||
                    (txtWarning.Text == "[null]" && txtError.Text == "[null]"))
                {
                    throw new InPutValidationException("Only one value can be [null]!", txtSuccess);
                }
                if ((txtSuccess.Text == "[any]" && txtWarning.Text == "[any]") ||
                    (txtSuccess.Text == "[any]" && txtError.Text == "[any]") ||
                    (txtWarning.Text == "[any]" && txtError.Text == "[any]"))
                {
                    throw new InPutValidationException("Only one value can be [any]!", txtSuccess);
                }
                //if (chkIsReturnValueInt.Checked)
                //{
                //    if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" && !cboSuccessValue.Text.IsLong())
                //        throw new InPutValidationException("Success value must be a valid integer!\r\n(or predefined values [any] or [null])", cboSuccessValue);
                //    else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" && !cboWarningValue.Text.IsLong())
                //        throw new InPutValidationException("Warning value must be a valid integer!\r\n(or predefined values [any] or [null])", cboWarningValue);
                //    else if (cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" && !cboErrorValue.Text.IsLong())
                //        throw new InPutValidationException("Error value must be a valid integer!\r\n(or predefined values [any] or [null])", cboErrorValue);
                //    else if (chkReturnValueNotInverted.Checked)
                //    {
                //        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                //            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                //            long.Parse(cboSuccessValue.Text) >= long.Parse(cboWarningValue.Text))
                //            throw new InPutValidationException("Success value must smaller than Warning value", cboSuccessValue);
                //        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                //            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                //            int.Parse(cboWarningValue.Text) >= long.Parse(cboErrorValue.Text))
                //            throw new InPutValidationException("Warning value must smaller than Error value", cboWarningValue);
                //    }
                //    else if (!chkReturnValueNotInverted.Checked)
                //    {
                //        if (cboSuccessValue.Text != "[null]" && cboSuccessValue.Text != "[any]" &&
                //            cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                //            long.Parse(cboSuccessValue.Text) <= long.Parse(cboWarningValue.Text))
                //            throw new InPutValidationException("Success value must bigger than Warning value", cboSuccessValue);
                //        else if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
                //            cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" &&
                //            long.Parse(cboWarningValue.Text) <= long.Parse(cboErrorValue.Text))
                //            throw new InPutValidationException("Warning value must bigger than Error value", cboWarningValue);
                //    }
                //}
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

        #region Change control
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
        #endregion


    }
}
