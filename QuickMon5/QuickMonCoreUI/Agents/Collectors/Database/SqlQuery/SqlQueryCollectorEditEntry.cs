using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;
using QuickMon.Collectors;

namespace QuickMon.UI
{
    public partial class SqlQueryCollectorEditEntry : CollectorConfigEntryEditWindowBase // Form, ICollectorConfigEntryEditWindow
    {
        public SqlQueryCollectorEditEntry()
        {
            InitializeComponent();
        }

        //#region ICollectorConfigEntryEditWindow
        //public ICollectorConfigEntry SelectedEntry { get; set; }
        //public QuickMonDialogResult ShowEditEntry()
        //{
        //    return (QuickMonDialogResult)ShowDialog();
        //} 
        //#endregion

        #region Form events
        private void SqlQueryCollectorEditEntry_Load(object sender, EventArgs e)
        {            
            try
            {                
                SqlQueryCollectorEntry selectedEntry;
                if (SelectedEntry == null)
                    SelectedEntry = new SqlQueryCollectorEntry() { DataSourceType = Collectors.DataSourceType.SqlServer };
                selectedEntry = (SqlQueryCollectorEntry)SelectedEntry;                

                txtName.Text = selectedEntry.Name;
                optOLEDb.Checked = selectedEntry.DataSourceType == DataSourceType.OLEDB;
                optSqlServer.Checked = selectedEntry.DataSourceType == DataSourceType.SqlServer;
                txtServer.Text = selectedEntry.Server;
                txtDatabase.Text = selectedEntry.Database;
                chkIntegratedSec.Checked = selectedEntry.IntegratedSecurity;
                txtUserName.Text = selectedEntry.UserName;
                txtPassword.Text = selectedEntry.Password;

                txtConnectionString.Text = selectedEntry.ConnectionString;

                txtApplicationName.Text = selectedEntry.ApplicationName;
                numericUpDownCmndTimeOut.SaveValueSet(selectedEntry.CmndTimeOut);
                chkUsePersistentConnection.Checked = selectedEntry.UsePersistentConnection;

                chkUseSPForState.Checked = selectedEntry.UseSPForStateQuery;
                txtStateQuery.Text = selectedEntry.StateQuery;

                chkUseSPForDetail.Checked = selectedEntry.UseSPForDetailQuery;
                txtDetailQuery.Text = selectedEntry.DetailQuery;

                cboReturnCheckSequence.SelectedIndex = (int)selectedEntry.ReturnCheckSequence;                
                cboReturnType.SelectedIndex = (int)selectedEntry.ValueReturnType;
                cboSuccessMatchType.SelectedIndex = (int)selectedEntry.GoodResultMatchType;
                txtGoodValueOrMacro.Text = selectedEntry.GoodValue;
                cboWarningMatchType.SelectedIndex = (int)selectedEntry.WarningResultMatchType;
                txtWarningValueOrMacro.Text = selectedEntry.WarningValue;
                cboErrorMatchType.SelectedIndex = (int)selectedEntry.ErrorResultMatchType;
                txtErrorValueOrMacro.Text = selectedEntry.ErrorValue;

                cboOutputValueUnit.Text = selectedEntry.OutputValueUnit;

                SetDataSourceSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Control events
        private void optSqlServer_CheckedChanged(object sender, EventArgs e)
        {
            SetDataSourceSelection();
        }
        private void optOLEDb_CheckedChanged(object sender, EventArgs e)
        {
            SetDataSourceSelection();
        }
        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Enabled = !chkIntegratedSec.Checked;
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.Enabled = !chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        }
        private void cboReturnType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboReturnType.SelectedIndex > 0 && cboOutputValueUnit.Text.Trim().Length ==0)
            {
                cboOutputValueUnit.Text = cboReturnType.SelectedIndex == 1 ? "row(s)" : cboReturnType.SelectedIndex == 2 ? "ms" : "";
            }
        }
        #endregion

        #region Private methods
        private void SetDataSourceSelection()
        {
            if (optSqlServer.Checked)
            {
                OLEDBDataSourcePanel.Visible = false;
                OLEDBDataSourcePanel.Dock = DockStyle.Top;
                dataSourceExtrasPanel.Dock = DockStyle.Fill;
                sqlServerPanel.Visible = true;
            }
            else
            {
                sqlServerPanel.Visible = false;
                dataSourceExtrasPanel.Dock = DockStyle.Bottom;
                OLEDBDataSourcePanel.Dock = DockStyle.Fill;
                OLEDBDataSourcePanel.Visible = true;
            }
            CheckOKEnabled();
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtName.Text.Trim().Length > 0 &&
                txtStateQuery.Text.Trim().Length > 0 &&
                txtDetailQuery.Text.Trim().Length > 0 &&
                (
                    (optSqlServer.Checked && txtServer.Text.Trim().Length > 0 && txtDatabase.Text.Trim().Length > 0) ||
                    (optOLEDb.Checked && txtConnectionString.Text.Trim().Length > 0)
                ) &&
                txtGoodValueOrMacro.Text.Trim().Length > 0 &&
                txtWarningValueOrMacro.Text.Trim().Length > 0 &&
                txtErrorValueOrMacro.Text.Trim().Length > 0;
            cmdTest.Enabled = cmdOK.Enabled;
        }
        #endregion

        #region Links
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
        #endregion

        #region Change tracking
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtStateQuery_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtDetailQuery_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            CheckOKEnabled();
        }     
        #endregion  

        #region Button events
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SqlQueryCollectorEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new SqlQueryCollectorEntry() { DataSourceType = Collectors.DataSourceType.SqlServer };
            selectedEntry = (SqlQueryCollectorEntry)SelectedEntry;

            selectedEntry.Name = txtName.Text;
            selectedEntry.DataSourceType = optOLEDb.Checked ? DataSourceType.OLEDB : DataSourceType.SqlServer;
            selectedEntry.Server = txtServer.Text;
            selectedEntry.Database = txtDatabase.Text;
            selectedEntry.IntegratedSecurity = chkIntegratedSec.Checked;
            selectedEntry.UserName = txtUserName.Text;
            selectedEntry.Password = txtPassword.Text;
            selectedEntry.ConnectionString = txtConnectionString.Text;

            selectedEntry.ApplicationName = txtApplicationName.Text;
            selectedEntry.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
            selectedEntry.UsePersistentConnection = chkUsePersistentConnection.Checked;

            selectedEntry.UseSPForStateQuery = chkUseSPForState.Checked;
            selectedEntry.StateQuery = txtStateQuery.Text;

            selectedEntry.UseSPForDetailQuery = chkUseSPForDetail.Checked;
            selectedEntry.DetailQuery = txtDetailQuery.Text;

            selectedEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;

            selectedEntry.ValueReturnType = (DataBaseQueryValueReturnType)cboReturnType.SelectedIndex;
            selectedEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
            selectedEntry.GoodValue = txtGoodValueOrMacro.Text;
            selectedEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
            selectedEntry.WarningValue = txtWarningValueOrMacro.Text;
            selectedEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
            selectedEntry.ErrorValue = txtErrorValueOrMacro.Text;

            selectedEntry.OutputValueUnit = cboOutputValueUnit.Text;

            SelectedEntry = selectedEntry;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            string lastStep = "Initialize values";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SqlQueryCollectorEntry testEntry = new SqlQueryCollectorEntry();
                testEntry.Name = txtName.Text;
                testEntry.DataSourceType = optOLEDb.Checked ? DataSourceType.OLEDB : DataSourceType.SqlServer;
                testEntry.Server = txtServer.Text;
                testEntry.Database = txtDatabase.Text;
                testEntry.IntegratedSecurity = chkIntegratedSec.Checked;
                testEntry.UserName = txtUserName.Text;
                testEntry.Password = txtPassword.Text;
                testEntry.ConnectionString = txtConnectionString.Text;

                testEntry.ApplicationName = txtApplicationName.Text;
                testEntry.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
                testEntry.UsePersistentConnection = chkUsePersistentConnection.Checked;

                testEntry.UseSPForStateQuery = chkUseSPForState.Checked;
                testEntry.StateQuery = txtStateQuery.Text;

                testEntry.UseSPForDetailQuery = chkUseSPForDetail.Checked;
                testEntry.DetailQuery = txtDetailQuery.Text;

                testEntry.ReturnCheckSequence = (CollectorAgentReturnValueCheckSequence)cboReturnCheckSequence.SelectedIndex;
                testEntry.ValueReturnType = (DataBaseQueryValueReturnType)cboReturnType.SelectedIndex;
                testEntry.GoodResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboSuccessMatchType.SelectedIndex;
                testEntry.GoodValue = txtGoodValueOrMacro.Text;
                testEntry.WarningResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboWarningMatchType.SelectedIndex;
                testEntry.WarningValue = txtWarningValueOrMacro.Text;
                testEntry.ErrorResultMatchType = (CollectorAgentReturnValueCompareMatchType)cboErrorMatchType.SelectedIndex;
                testEntry.ErrorValue = txtErrorValueOrMacro.Text;

                testEntry.OutputValueUnit = cboOutputValueUnit.Text;

                lastStep = "Run state query";
                CollectorState currentState = testEntry.GetCurrentState().State;

                lastStep = "Run detail query";
                DataTable dt = testEntry.GetDetailQueryDataTable();
                lastStep = "Run detail query - Getting column names";
                List<DataColumn> columns = new List<DataColumn>();
                columns.AddRange((from DataColumn c in dt.Columns
                                  select c).ToArray());

                MessageBox.Show(string.Format("{0}!\r\nState value return: {1}\r\nDetail row count: {2}\r\nDetail columns returned: {3}",
                    currentState,
                    testEntry.CurrentAgentValue, dt.Rows.Count, columns.ToCSVString()), "Test", MessageBoxButtons.OK,
                    currentState == CollectorState.Good ? MessageBoxIcon.Information : currentState == CollectorState.Warning ? MessageBoxIcon.Warning : MessageBoxIcon.Error);
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
        private void cmdBuildConnStr_Click(object sender, EventArgs e)
        {
            ConnectionStringBuilder csb = new ConnectionStringBuilder();
            csb.ConnectionString = txtConnectionString.Text;
            if (csb.ShowDialog() == DialogResult.OK)
            {
                txtConnectionString.Text = csb.ConnectionString;
            }
        }
        #endregion


    }
}
