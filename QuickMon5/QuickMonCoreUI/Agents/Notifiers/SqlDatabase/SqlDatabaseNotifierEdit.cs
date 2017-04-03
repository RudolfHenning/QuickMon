using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;
using QuickMon.Notifiers;

namespace QuickMon.UI
{
    public partial class SqlDatabaseNotifierEdit : Form, IAgentConfigEntryEditWindow
    {
        public SqlDatabaseNotifierEdit()
        {
            InitializeComponent();
        }

        public IAgentConfig SelectedEntry { get; set; }
        public QuickMonDialogResult ShowEditEntry()
        {            
            return (QuickMonDialogResult)ShowDialog();
        }

        private void SqlDatabaseNotifierEdit_Load(object sender, EventArgs e)
        {
            LoadEditData();
        }

        #region Private methods
        public void LoadEditData()
        {
            if (SelectedEntry == null)
                SelectedEntry = new SqlDatabaseNotifierConfig();
            SqlDatabaseNotifierConfig currentConfig = (SqlDatabaseNotifierConfig)SelectedEntry;

            txtServer.Text = currentConfig.SqlServer;
            txtDatabase.Text = currentConfig.Database;
            chkIntegratedSec.Checked = currentConfig.IntegratedSec;
            txtUserName.Text = currentConfig.UserName;
            txtPassword.Text = currentConfig.Password;
            numericUpDownCmndTimeOut.SaveValueSet(currentConfig.CmndTimeOut);
            chkUseSP.Checked = currentConfig.UseSP;
            txtCmndValue.Text = currentConfig.CmndValue;
            txtAlertFieldName.Text = currentConfig.AlertFieldName;
            txtCollectorFieldName.Text = currentConfig.CollectorFieldName;
            txtPreviousStateFieldName.Text = currentConfig.PreviousStateFieldName;
            txtCurrentStateFieldName.Text = currentConfig.CurrentStateFieldName;
            txtDetailsFieldName.Text = currentConfig.DetailsFieldName;
            chkUseSP2.Checked = currentConfig.UseSPForViewer;
            txtViewerName.Text = currentConfig.ViewerName;
            txtDateTimeFieldName.Text = currentConfig.DateTimeFieldName;
        }
        private void CheckOKEnabled()
        {
            cmdOK.Enabled = txtServer.Text.Trim().Length > 0 && txtDatabase.Text.Trim().Length > 0;
        }
        private string GetQuery(string viewerName, string alertParamName, string categoryParamName, string previousStateParamName, string currentStateParamName, string detailsParamName, string datetimeParamName)
        {
            return string.Format("Select top (@Top) {0}, {1}, {2}, {3}, {4}, @FromDate, @ToDate, @{0}, @{1}, @{3}, @{4} from {5} with (Readpast) order by {6} desc",
                    alertParamName, categoryParamName, previousStateParamName, currentStateParamName, detailsParamName, viewerName, datetimeParamName);
        } 
        #endregion

        #region Change tracking
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }
        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        } 
        #endregion

        private void llblDBCreateScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(Properties.Resources.ExampleSqlDatabaseCreateScript);
            MessageBox.Show("SQL script to create tables and stored procedures copied to clipboard memory. Use CTRL-V (paste) in query window to view/execute the script.", "Script", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Button events
        private void cmdTest_Click(object sender, EventArgs e)
        {
            string lastStep = "";
            try
            {
                SqlDatabaseNotifierConfig tmpConfig = new SqlDatabaseNotifierConfig();
                lastStep = "Setting up connection string";
                tmpConfig.SqlServer = txtServer.Text;
                tmpConfig.Database = txtDatabase.Text;
                tmpConfig.IntegratedSec = chkIntegratedSec.Checked;
                tmpConfig.UserName = txtUserName.Text;
                tmpConfig.Password = txtPassword.Text;

                using (SqlConnection conn = new SqlConnection(tmpConfig.GetConnectionString()))
                {
                    conn.Open();
                    lastStep = "Inserting test message into database";

                    string cmndName = txtCmndValue.Text.Replace("'", "''");
                    string viewerName = txtViewerName.Text.Replace("'", "''");
                    string alertParamName = txtAlertFieldName.Text.Replace("'", "''").Replace("@", "");
                    string categoryParamName = txtCollectorFieldName.Text.Replace("'", "''").Replace("@", "");
                    string previousStateParamName = txtPreviousStateFieldName.Text.Replace("'", "''").Replace("@", "");
                    string currentStateParamName = txtCurrentStateFieldName.Text.Replace("'", "''").Replace("@", "");
                    string detailsParamName = txtDetailsFieldName.Text.Replace("'", "''").Replace("@", "");
                    string datetimeParamName = txtDateTimeFieldName.Text.Replace("'", "''").Replace("@", "");
                    int topCount = 1;

                    string sql = chkUseSP.Checked ? cmndName :
                        string.Format("Insert {0} ({1}, {2}, {3}, {4}, {5}) values(@{1}, @{2}, @{3}, @{4}, @{5})",
                            cmndName,
                            alertParamName,
                            categoryParamName,
                            previousStateParamName,
                            currentStateParamName,
                            detailsParamName);

                    byte alertTypeValue = 0;
                    byte previousState = 0;
                    byte currentState = 0;

                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@" + alertParamName,  alertTypeValue),
                                new SqlParameter("@" + categoryParamName,  "Test"),
                                new SqlParameter("@" + previousStateParamName,  previousState),
                                new SqlParameter("@" + currentStateParamName,  currentState),
                                new SqlParameter("@" + detailsParamName, "Testing QuickMon database notifier insert")
                            };
                        cmnd.Parameters.AddRange(paramArr);
                        if (chkUseSP.Checked)
                            cmnd.CommandType = CommandType.StoredProcedure;
                        else
                            cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = (int)numericUpDownCmndTimeOut.Value;
                        cmnd.ExecuteNonQuery();
                    }

                    lastStep = "Retrieve message from database";
                    sql = chkUseSP2.Checked ? viewerName : GetQuery(viewerName, alertParamName,
                            categoryParamName, previousStateParamName, currentStateParamName, detailsParamName, datetimeParamName);
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@Top",  topCount),
                                new SqlParameter("@FromDate", DateTime.Now.AddDays(-1)),
                                new SqlParameter("@ToDate", DateTime.Now.AddMinutes(1)),
                                new SqlParameter("@" + alertParamName,  alertTypeValue),
                                new SqlParameter("@" + categoryParamName,  "Test"),
                                new SqlParameter("@" + currentStateParamName,  currentState),
                                new SqlParameter("@" + detailsParamName, "Testing QuickMon database notifier insert")
                            };
                        cmnd.Parameters.AddRange(paramArr);
                        if (chkUseSP2.Checked)
                            cmnd.CommandType = CommandType.StoredProcedure;
                        else
                            cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = (int)numericUpDownCmndTimeOut.Value;
                        using (SqlDataReader r = cmnd.ExecuteReader())
                        {
                            if (!r.Read())
                                throw new Exception("No data returned by server");
                        }
                    }
                }
                MessageBox.Show("Test was successful!", "Test connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Failed at step: {0}\r\nDetails: {1}", lastStep, ex.Message), "Test connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (SelectedEntry == null)
                SelectedEntry = new SqlDatabaseNotifierConfig();
            SqlDatabaseNotifierConfig currentConfig = (SqlDatabaseNotifierConfig)SelectedEntry;
            currentConfig.SqlServer = txtServer.Text;
            currentConfig.Database = txtDatabase.Text;
            currentConfig.IntegratedSec = chkIntegratedSec.Checked;
            currentConfig.UserName = txtUserName.Text;
            currentConfig.Password = txtPassword.Text;
            currentConfig.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
            currentConfig.UseSP = chkUseSP.Checked;
            currentConfig.CmndValue = txtCmndValue.Text;
            currentConfig.AlertFieldName = txtAlertFieldName.Text;
            currentConfig.CollectorFieldName = txtCollectorFieldName.Text;
            currentConfig.PreviousStateFieldName = txtPreviousStateFieldName.Text;
            currentConfig.CurrentStateFieldName = txtCurrentStateFieldName.Text;
            currentConfig.DetailsFieldName = txtDetailsFieldName.Text;
            currentConfig.UseSPForViewer = chkUseSP2.Checked;
            currentConfig.ViewerName = txtViewerName.Text;
            currentConfig.DateTimeFieldName = txtDateTimeFieldName.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        } 
        #endregion

    }
}
