using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HenIT.Data.OLEDB;
using QuickMon.Utils;

namespace QuickMon.Collectors
{

    public partial class OLEDBQueryCollectorEditEntry : Form, IEditConfigEntryWindow
    {
        public OLEDBQueryCollectorEditEntry()
        {
            InitializeComponent();
        }

        #region IEditConfigEntryWindow Members
        public ICollectorConfigEntry SelectedEntry { get; set; }
        public DialogResult ShowEditEntry()
        {
            return ShowDialog();
        }
        #endregion

        #region Form events
        private void OLEDBQueryCollectorEditEntry_Load(object sender, EventArgs e)
        {
            OLEDBQueryInstance selectedEntry;            
            selectedEntry = (OLEDBQueryInstance)SelectedEntry;            

            if (selectedEntry != null)
            {
                txtName.Text = selectedEntry.Name;
                txtConnectionString.Text = selectedEntry.ConnectionString;
                numericUpDownCmndTimeOut.Value = selectedEntry.CmndTimeOut;
                chkUseSPForSummary.Checked = selectedEntry.UseSPForSummary;

                if (!selectedEntry.ReturnValueIsNumber)
                    cboReturnType.SelectedIndex = 0;
                else if (!selectedEntry.UseRowCountAsValue && !selectedEntry.UseExecuteTimeAsValue)
                    cboReturnType.SelectedIndex = 1;
                else if (selectedEntry.UseRowCountAsValue)
                    cboReturnType.SelectedIndex = 2;
                else
                    cboReturnType.SelectedIndex = 3;

                chkReturnValueNotInverted.Checked = !selectedEntry.ReturnValueInverted;
                cboSuccessValue.Text = selectedEntry.SuccessValue;
                cboWarningValue.Text = selectedEntry.WarningValue;
                cboErrorValue.Text = selectedEntry.ErrorValue;
                chkUseSPForDetail.Checked = selectedEntry.UseSPForDetail;
                chkUsePersistentConnection.Checked = selectedEntry.UsePersistentConnection;

                txtStateQuery.Text = selectedEntry.SummaryQuery;
                txtDetailQuery.Text = selectedEntry.DetailQuery;
            }
            else
            {
                cboReturnType.SelectedIndex = 0;
            }
        }
        private void OLEDBQueryCollectorEditEntry_Shown(object sender, EventArgs e)
        {

        }
        #endregion

        #region Private methods
        private bool DoValidate()
        {
            try
            {
                if (txtName.Text.Length == 0)
                    throw new InPutValidationException("Name must be specified!", txtName);
                if (txtConnectionString.Text.Length == 0)
                    throw new InPutValidationException("Connection string must be specified!", txtConnectionString);
                if (txtStateQuery.Text.Trim().Length == 0)
                    throw new InPutValidationException("The summary query must be specified!", txtStateQuery);
                if (!SQLTools.TSQLValid(txtStateQuery.Text))
                    throw new InPutValidationException("SQL statements may not contain certain keywords (e.g. update, delete, create etc!", txtStateQuery);
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
                if (cboReturnType.SelectedIndex != 0)
                {
                    if (cboReturnType.SelectedIndex == 3)
                        chkReturnValueNotInverted.Checked = true;
                    if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" && !cboWarningValue.Text.IsLong())
                        throw new InPutValidationException("Warning value must be a valid integer!\r\n(or predefined values [any] or [null])", cboWarningValue);
                    else if (cboErrorValue.Text != "[null]" && cboErrorValue.Text != "[any]" && !cboErrorValue.Text.IsLong())
                        throw new InPutValidationException("Error value must be a valid integer!\r\n(or predefined values [any] or [null])", cboErrorValue);
                    else if (chkReturnValueNotInverted.Checked)
                    {
                        if (cboWarningValue.Text != "[null]" && cboWarningValue.Text != "[any]" &&
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
                if (txtDetailQuery.Text.Trim().Length == 0)
                    throw new InPutValidationException("The detail query must be specified!", txtDetailQuery);
                if (!SQLTools.TSQLValid(txtDetailQuery.Text))
                    throw new InPutValidationException("SQL statements may not contain certain keywords (e.g. update, delete, create etc!", txtDetailQuery);
                return true;
            }
            catch (InPutValidationException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (ex.ValidatedObject is Control)
                {
                    Control theControl = ((Control)ex.ValidatedObject);
                    if (theControl.Parent != null && theControl.Parent is TabPage)
                    {
                        tabControlConfig.SelectedTab = (TabPage)theControl.Parent;
                    }
                    ((Control)ex.ValidatedObject).Focus();
                }
                return false;
            }
        }
        private void CheckOkEnabled()
        {
            bool enabled = txtConnectionString.Text.Length > 0 && txtStateQuery.Text.Length > 0 && txtDetailQuery.Text.Length > 0;
            cmdOK.Enabled = enabled;
            cmdTest.Enabled = enabled;
        }
        #endregion

        #region Change control        
        private void cboReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkReturnValueNotInverted.Enabled = cboReturnType.SelectedIndex > 0 && cboReturnType.SelectedIndex < 3;
            cboSuccessValue.Enabled = cboReturnType.SelectedIndex == 0;
        }
        
        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtStateQuery_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            CheckOkEnabled();
        }
        private void txtDetailQuery_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            CheckOkEnabled();
        } 
        #endregion

        #region Context menus
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "txtStateQuery")
                txtStateQuery.Cut();
            else if (this.ActiveControl.Name == "txtDetailQuery")
                txtDetailQuery.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "txtStateQuery")
                txtStateQuery.Copy();
            else if (this.ActiveControl.Name == "txtDetailQuery")
                txtDetailQuery.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "txtStateQuery")
                txtStateQuery.Paste();
            else if (this.ActiveControl.Name == "txtDetailQuery")
                txtDetailQuery.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl.Name == "txtStateQuery")
                txtStateQuery.SelectAll();
            else if (this.ActiveControl.Name == "txtDetailQuery")
                txtDetailQuery.SelectAll();
        }
        #endregion

        #region Button click events
        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string lastStep = "Initialize values";
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    OLEDBQueryInstance testQueryInstance = new OLEDBQueryInstance();
                    testQueryInstance.Name = txtName.Text;                    
                    testQueryInstance.ConnectionString = txtConnectionString.Text;
                    testQueryInstance.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
                    testQueryInstance.UseSPForSummary = chkUseSPForSummary.Checked;
                    testQueryInstance.SummaryQuery = txtStateQuery.Text;
                    if (cboReturnType.SelectedIndex == 0)
                    {
                        testQueryInstance.ReturnValueIsNumber = false;
                        testQueryInstance.UseRowCountAsValue = false;
                        testQueryInstance.UseExecuteTimeAsValue = false;
                    }
                    else
                    {
                        testQueryInstance.ReturnValueIsNumber = true;
                        if (cboReturnType.SelectedIndex == 2)
                        {
                            testQueryInstance.UseRowCountAsValue = true;
                        }
                        else if (cboReturnType.SelectedIndex == 3)
                        {
                            testQueryInstance.UseExecuteTimeAsValue = true;
                            chkReturnValueNotInverted.Checked = true;
                        }
                    }
                    testQueryInstance.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    testQueryInstance.SuccessValue = cboSuccessValue.Text;
                    testQueryInstance.WarningValue = cboWarningValue.Text;
                    testQueryInstance.ErrorValue = cboErrorValue.Text;
                    testQueryInstance.UseSPForDetail = chkUseSPForDetail.Checked;
                    testQueryInstance.DetailQuery = txtDetailQuery.Text;

                    lastStep = "Run summary query";
                    object returnValue = testQueryInstance.RunQuery();
                    if (!testQueryInstance.UseRowCountAsValue && !testQueryInstance.UseExecuteTimeAsValue && !returnValue.IsNumber())
                    {
                        throw new Exception(string.Format("Return value is not an integer!\r\nValue returned: {0}", returnValue));
                    }

                    //testing detail query
                    List<DataColumn> columns = new List<DataColumn>(); 
                    lastStep = "Testing detail query";
                    DataSet ds = testQueryInstance.RunDetailQuery();
                    lastStep = "Testing detail query - Getting column names";
                    columns.AddRange((from DataColumn c in ds.Tables[0].Columns
                                      select c).ToArray());

                    MessageBox.Show(string.Format("Success!\r\nSummary value return: {0}\r\nDetail row count: {1}\r\nDetail columns returned: {2}", returnValue, ds.Tables[0].Rows.Count, columns.ToCSVString()), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Failed!\r\nLast step: {0}\r\n{1}", lastStep, ex.Message), "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                OLEDBQueryInstance selectedEntry;
                if (SelectedEntry != null)
                    selectedEntry = (OLEDBQueryInstance)SelectedEntry;
                else
                {
                    selectedEntry = new OLEDBQueryInstance();
                    SelectedEntry = selectedEntry;
                }

                if (selectedEntry != null)
                {
                    selectedEntry.Name = txtName.Text;                    
                    selectedEntry.ConnectionString = txtConnectionString.Text;
                    selectedEntry.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
                    selectedEntry.UseSPForSummary = chkUseSPForSummary.Checked;
                    selectedEntry.SummaryQuery = txtStateQuery.Text;
                    if (cboReturnType.SelectedIndex == 0)
                    {
                        selectedEntry.ReturnValueIsNumber = false;
                        selectedEntry.UseRowCountAsValue = false;
                        selectedEntry.UseExecuteTimeAsValue = false;
                    }
                    else
                    {
                        selectedEntry.ReturnValueIsNumber = true;
                        if (cboReturnType.SelectedIndex == 2)
                        {
                            selectedEntry.UseRowCountAsValue = true;
                        }
                        else if (cboReturnType.SelectedIndex == 3)
                        {
                            selectedEntry.UseExecuteTimeAsValue = true;
                            chkReturnValueNotInverted.Checked = true;
                        }
                    }
                    selectedEntry.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    selectedEntry.SuccessValue = cboSuccessValue.Text;
                    selectedEntry.WarningValue = cboWarningValue.Text;
                    selectedEntry.ErrorValue = cboErrorValue.Text;
                    selectedEntry.UseSPForDetail = chkUseSPForDetail.Checked;
                    selectedEntry.DetailQuery = txtDetailQuery.Text;
                    selectedEntry.UsePersistentConnection = chkUsePersistentConnection.Checked;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }
        #endregion

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("http://www.connectionstrings.com/");
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelQueryTips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo("https://quickmon.codeplex.com/wikipage?title=Ole%20Db%20Query%20Collector%20query%20syntax%20Tips");
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdBuildConnStr_Click(object sender, EventArgs e)
        {
            ConnectionStringBuilderUI csb = new ConnectionStringBuilderUI();
            csb.ConnectionString = txtConnectionString.Text;
            if (csb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtConnectionString.Text = csb.ConnectionString;
            }
        }
    }
}
