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
    public partial class EditSqlQueryInstance : Form
    {
        public EditSqlQueryInstance()
        {
            InitializeComponent();
        }

        public QueryInstance SelectedQueryInstance { get; set; }

        private void linkLabelQueryTips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string outputPath = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.DoNotVerify);
                outputPath = System.IO.Path.Combine(outputPath, "Hen IT\\QuickMon");
                if (!System.IO.Directory.Exists(outputPath))
                    System.IO.Directory.CreateDirectory(outputPath);
                outputPath = System.IO.Path.Combine(outputPath, "SQLQueryTips.htm");
                if (System.IO.File.Exists(outputPath))
                    System.IO.File.Delete(outputPath);
                System.IO.File.WriteAllText(outputPath, Properties.Resources.SQLQueryTips, Encoding.UTF8);
                System.Diagnostics.Process.Start(outputPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Query Tips", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void EditSqlQueryInstance_Load(object sender, EventArgs e)
        {
            if (SelectedQueryInstance == null)
                SelectedQueryInstance = new QueryInstance();
            txtName.Text = SelectedQueryInstance.Name;
            txtServer.Text = SelectedQueryInstance.SqlServer;
            txtDatabase.Text = SelectedQueryInstance.Database;
            chkIntegratedSec.Checked = SelectedQueryInstance.IntegratedSecurity;
            txtUserName.Text = SelectedQueryInstance.UserName;
            txtPassword.Text = SelectedQueryInstance.Password;
            numericUpDownCmndTimeOut.Value = SelectedQueryInstance.CmndTimeOut;
            chkUseSPForSummary.Checked = SelectedQueryInstance.UseSPForSummary;
            txtStateQuery.Text = SelectedQueryInstance.SummaryQuery;
            chkIsReturnValueInt.Checked = SelectedQueryInstance.ReturnValueIsNumber;
            chkReturnValueNotInverted.Checked = !SelectedQueryInstance.ReturnValueInverted;
            chkUseRowCountAsValue.Checked = SelectedQueryInstance.UseRowCountAsValue;
            cboSuccessValue.Text = SelectedQueryInstance.SuccessValue;
            cboWarningValue.Text = SelectedQueryInstance.WarningValue;
            cboErrorValue.Text = SelectedQueryInstance.ErrorValue;
            chkUseSPForDetail.Checked = SelectedQueryInstance.UseSPForDetail;
            txtDetailQuery.Text = SelectedQueryInstance.DetailQuery;
        }

        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        }
        private void chkIsReturnValueInt_CheckedChanged(object sender, EventArgs e)
        {
            chkReturnValueNotInverted.Enabled = chkIsReturnValueInt.Checked;
            chkUseRowCountAsValue.Enabled = chkIsReturnValueInt.Checked;
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            if (DoValidate())
            {
                string lastStep = "Initialize values";
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    QueryInstance testQueryInstance = new QueryInstance();
                    testQueryInstance.Name = txtName.Text;
                    testQueryInstance.SqlServer = txtServer.Text;
                    testQueryInstance.Database = txtDatabase.Text;
                    testQueryInstance.IntegratedSecurity = chkIntegratedSec.Checked;
                    testQueryInstance.UserName = txtUserName.Text;
                    testQueryInstance.Password = txtPassword.Text;
                    testQueryInstance.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
                    testQueryInstance.UseSPForSummary = chkUseSPForSummary.Checked;
                    testQueryInstance.SummaryQuery = txtStateQuery.Text;
                    testQueryInstance.ReturnValueIsNumber = chkIsReturnValueInt.Checked;
                    testQueryInstance.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                    testQueryInstance.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                    testQueryInstance.SuccessValue = cboSuccessValue.Text;
                    testQueryInstance.WarningValue = cboWarningValue.Text;
                    testQueryInstance.ErrorValue = cboErrorValue.Text;
                    testQueryInstance.UseSPForDetail = chkUseSPForDetail.Checked;
                    testQueryInstance.DetailQuery = txtDetailQuery.Text;

                    object returnValue = null;
                    if (testQueryInstance.UseRowCountAsValue)
                    {
                        lastStep = "Run summary query (row count as value)";
                        returnValue = testQueryInstance.RunQueryWithCountResult();
                    }
                    else
                    {
                        lastStep = "Run summary query";
                        returnValue = testQueryInstance.RunQueryWithSingleResult();
                    }
                    if (testQueryInstance.ReturnValueIsNumber)
                    {
                        lastStep = "Test return value is an Integer";
                        if (!returnValue.IsNumber())
                            throw new Exception(string.Format("Return value is not an integer!\r\nValue returned: {0}", returnValue));
                    }
                    //testing detail query
                    List<DataColumn> columns = new List<DataColumn>(); // = testQueryInstance.GetDetailQueryColumns();                    
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
                SelectedQueryInstance.Name = txtName.Text;
                SelectedQueryInstance.SqlServer = txtServer.Text;
                SelectedQueryInstance.Database = txtDatabase.Text;
                SelectedQueryInstance.IntegratedSecurity = chkIntegratedSec.Checked;
                SelectedQueryInstance.UserName = txtUserName.Text;
                SelectedQueryInstance.Password = txtPassword.Text;
                SelectedQueryInstance.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
                SelectedQueryInstance.UseSPForSummary = chkUseSPForSummary.Checked;
                SelectedQueryInstance.SummaryQuery = txtStateQuery.Text;
                SelectedQueryInstance.ReturnValueIsNumber = chkIsReturnValueInt.Checked;
                SelectedQueryInstance.ReturnValueInverted = !chkReturnValueNotInverted.Checked;
                SelectedQueryInstance.UseRowCountAsValue = chkUseRowCountAsValue.Checked;
                SelectedQueryInstance.SuccessValue = cboSuccessValue.Text;
                SelectedQueryInstance.WarningValue = cboWarningValue.Text;
                SelectedQueryInstance.ErrorValue = cboErrorValue.Text;
                SelectedQueryInstance.UseSPForDetail = chkUseSPForDetail.Checked;
                SelectedQueryInstance.DetailQuery = txtDetailQuery.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private bool DoValidate()
        {
            try
            {
                if (txtName.Text.Length == 0)
                    throw new InPutValidationException("Name must be specified!", txtName);
                if (txtServer.Text.Length == 0)
                    throw new InPutValidationException("The sql server name must be specified!", txtServer);
                if (txtDatabase.Text.Length == 0)
                    throw new InPutValidationException("The database name must be specified!", txtDatabase);
                if (!chkIntegratedSec.Checked && txtUserName.Text.Length == 0)
                    throw new InPutValidationException("The user name must be specified when not using integrated security!", txtUserName);
                if (txtStateQuery.Text.Trim().Length == 0)
                    throw new InPutValidationException("The summary query must be specified!", txtStateQuery);
                if (!TSQLValid(txtStateQuery.Text))
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
                if (txtDetailQuery.Text.Trim().Length == 0)
                    throw new InPutValidationException("The detail query must be specified!", txtDetailQuery);
                if (!TSQLValid(txtDetailQuery.Text))
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
        private bool TSQLValid(string tsql)
        {
            if (ContainSQLStatement(tsql, "DELETE") ||
                ContainSQLStatement(tsql, "UPDATE") ||
                ContainSQLStatement(tsql, "CREATE")
                )
                return false;
            else
                return true;
        }
        private bool ContainSQLStatement(string tsql, string keyword)
        {
            if (tsql.ToUpper().StartsWith(keyword + " ") ||
                tsql.ToUpper().Contains("\r\n" + keyword + " ") ||
                tsql.ToUpper().Contains("\r\n" + keyword + "\r\n") ||
                tsql.ToUpper().Contains(" " + keyword + " ") ||
                tsql.ToUpper().Contains(" " + keyword + "\r\n") ||
                tsql.ToUpper().StartsWith(" " + keyword))
                return true;
            else
                return false;
        }
    }
}
