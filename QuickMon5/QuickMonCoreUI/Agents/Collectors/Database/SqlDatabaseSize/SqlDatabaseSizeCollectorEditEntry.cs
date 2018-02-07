using HenIT.Data.SqlClient;
using QuickMon.Collectors;
using QuickMon.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SqlDatabaseSizeCollectorEditEntry : CollectorConfigEntryEditWindowBase // Form, ICollectorConfigEntryEditWindow
    {
        public SqlDatabaseSizeCollectorEditEntry()
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
        private void SqlDatabaseSizeCollectorEditEntry_Load(object sender, EventArgs e)
        {
            SqlDatabaseSizeCollectorEntry selectedEntry;
            if (SelectedEntry == null)
                SelectedEntry = new SqlDatabaseSizeCollectorEntry() { SqlCmndTimeOutSec = 30, IntegratedSecurity = true };
            selectedEntry = (SqlDatabaseSizeCollectorEntry)SelectedEntry;
            txtServer.Text = selectedEntry.SqlServer;
            cboDatabase.Text = selectedEntry.Database;
            chkIntegratedSec.Checked = selectedEntry.IntegratedSecurity;
            txtUserName.Text = selectedEntry.UserName;
            txtPassword.Text = selectedEntry.Password;
            numericUpDownCmndTimeOut.Value = selectedEntry.SqlCmndTimeOutSec;
            warningNumericUpDown.Value = selectedEntry.WarningSizeMB;
            errorNumericUpDown.Value = selectedEntry.ErrorSizeMB;
            LoadDatabases();
            CheckOkEnabled();
        } 
        #endregion


        #region Private methods
        private void LoadDatabases()
        {
            try
            {
                string serverName = ApplyConfigVarsOnField(txtServer.Text);
                string username = ApplyConfigVarsOnField(txtUserName.Text);
                string password = ApplyConfigVarsOnField(txtPassword.Text);
                if (serverName.Trim().Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    cboDatabase.Items.Clear();
                    GenericSQLServerDAL dal = new GenericSQLServerDAL();
                    dal.Server = serverName;
                    dal.Database = "master";
                    if (!chkIntegratedSec.Checked)
                    {
                        dal.UserName = username;
                        dal.Password = password;
                    }
                    dal.SetConnection();
                    DataSet tables = dal.GetDataSet("select name as DatabaseName From sysdatabases where dbid > 4 order by name", CommandType.Text);
                    if (tables.Tables.Count > 0 && tables.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow r in tables.Tables[0].Rows)
                            cboDatabase.Items.Add(r[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CheckOkEnabled()
        {
            cmdOK.Enabled = txtServer.Text.Length > 0 && (chkIntegratedSec.Checked || txtUserName.Text.Length > 0) && cboDatabase.Text.Length > 0 && warningNumericUpDown.Value < errorNumericUpDown.Value;
            cmdTest.Enabled = txtServer.Text.Length > 0 && (chkIntegratedSec.Checked || txtUserName.Text.Length > 0) && cboDatabase.Text.Length > 0 && warningNumericUpDown.Value < errorNumericUpDown.Value;
        }
        #endregion

        #region Button events
        private void cmdLoadDBs_Click(object sender, EventArgs e)
        {
            LoadDatabases();
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDatabaseSizeCollectorEntry test = new SqlDatabaseSizeCollectorEntry();

                string serverName = ApplyConfigVarsOnField(txtServer.Text);
                string databaseName = ApplyConfigVarsOnField(cboDatabase.Text);
                string username = ApplyConfigVarsOnField(txtUserName.Text);
                string password = ApplyConfigVarsOnField(txtPassword.Text);
                
                test.SqlServer = serverName;
                test.Database = databaseName;
                test.IntegratedSecurity = chkIntegratedSec.Checked;
                test.UserName = username;
                test.Password = password;
                test.SqlCmndTimeOutSec = (int)numericUpDownCmndTimeOut.Value;
                test.WarningSizeMB = (int)warningNumericUpDown.Value;
                test.ErrorSizeMB = (int)errorNumericUpDown.Value;
                long currentSize = test.GetDBSize();
                MessageBox.Show(string.Format("Current database size: {0} MB", currentSize), "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SqlDatabaseSizeCollectorEntry selectedEntry;
            if (SelectedEntry == null)
            {
                selectedEntry = new SqlDatabaseSizeCollectorEntry();
            }

            selectedEntry = (SqlDatabaseSizeCollectorEntry)SelectedEntry;
            selectedEntry.SqlServer = txtServer.Text;
            selectedEntry.IntegratedSecurity = chkIntegratedSec.Checked;
            selectedEntry.UserName = txtUserName.Text;
            selectedEntry.Password = txtPassword.Text;
            selectedEntry.SqlCmndTimeOutSec = (int)numericUpDownCmndTimeOut.Value;
            selectedEntry.Database = cboDatabase.Text;
            selectedEntry.WarningSizeMB = (int)warningNumericUpDown.Value;
            selectedEntry.ErrorSizeMB = (int)errorNumericUpDown.Value;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        #endregion

        #region Other control events
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void warningNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void errorNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CheckOkEnabled();
        }
        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        }
        #endregion


    }
}
