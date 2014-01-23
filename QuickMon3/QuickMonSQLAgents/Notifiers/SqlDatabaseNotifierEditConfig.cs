using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.Forms;

namespace QuickMon.Notifiers
{
    public partial class SqlDatabaseNotifierEditConfig : SimpleNotifierEditConfig
    {
        public SqlDatabaseNotifierEditConfig()
        {
            InitializeComponent();
        }

        public override void LoadEditData()
        {
            SQLDatabaseNotifierConfig currentConfig = (SQLDatabaseNotifierConfig)SelectedConfig;
            txtServer.Text = currentConfig.SqlServer;
            txtDatabase.Text = currentConfig.Database;
            chkIntegratedSec.Checked = currentConfig.IntegratedSec;
            txtUserName.Text = currentConfig.UserName;
            txtPassword.Text = currentConfig.Password;
            numericUpDownCmndTimeOut.Value = currentConfig.CmndTimeOut;
            chkUseSP.Checked = currentConfig.UseSP;
            txtCmndValue.Text = currentConfig.CmndValue;
            txtAlertFieldName.Text = currentConfig.AlertFieldName;
            txtCollectorType.Text = currentConfig.CollectorTypeFieldName;
            txtCategoryFieldName.Text = currentConfig.CategoryFieldName;
            txtPreviousStateFieldName.Text = currentConfig.PreviousStateFieldName;
            txtCurrentStateFieldName.Text = currentConfig.CurrentStateFieldName;
            txtDetailsFieldName.Text = currentConfig.DetailsFieldName;
            chkUseSP2.Checked = currentConfig.UseSPForViewer;
            txtViewerName.Text = currentConfig.ViewerName;
            txtDateTimeFieldName.Text = currentConfig.DateTimeFieldName;
        }
        public override void OkClicked()
        {
            if (SelectedConfig == null)
                SelectedConfig = new SQLDatabaseNotifierConfig();
            SQLDatabaseNotifierConfig currentConfig = (SQLDatabaseNotifierConfig)SelectedConfig;

            currentConfig.SqlServer = txtServer.Text;
            currentConfig.Database = txtDatabase.Text;
            currentConfig.IntegratedSec = chkIntegratedSec.Checked;
            currentConfig.UserName = txtUserName.Text;
            currentConfig.Password = txtPassword.Text;
            currentConfig.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
            currentConfig.UseSP = chkUseSP.Checked;
            currentConfig.CmndValue = txtCmndValue.Text;
            currentConfig.AlertFieldName = txtAlertFieldName.Text;
            currentConfig.CollectorTypeFieldName = txtCollectorType.Text;
            currentConfig.CategoryFieldName = txtCategoryFieldName.Text;
            currentConfig.PreviousStateFieldName = txtPreviousStateFieldName.Text;
            currentConfig.CurrentStateFieldName = txtCurrentStateFieldName.Text;
            currentConfig.DetailsFieldName = txtDetailsFieldName.Text;
            currentConfig.UseSPForViewer = chkUseSP2.Checked;
            currentConfig.ViewerName = txtViewerName.Text;
            currentConfig.DateTimeFieldName = txtDateTimeFieldName.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        private void CheckOKEnabled()
        {
            SetOKEnabled(txtServer.Text.Trim().Length > 0 && txtDatabase.Text.Trim().Length > 0);
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string connStr = "";
            string lastStep = "";
            try
            {
                SQLDatabaseNotifierConfig tmpConfig = new SQLDatabaseNotifierConfig();
                lastStep = "Setting up connection string";
                //SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
                //scsb.DataSource = txtServer.Text;
                //scsb.InitialCatalog = txtDatabase.Text;
                //scsb.IntegratedSecurity = chkIntegratedSec.Checked;
                //if (!chkIntegratedSec.Checked)
                //{
                //    scsb.UserID = txtUserName.Text;
                //    scsb.Password = txtPassword.Text;
                //}
                tmpConfig.SqlServer = txtServer.Text;
                tmpConfig.Database = txtDatabase.Text;
                tmpConfig.IntegratedSec = chkIntegratedSec.Checked;
                tmpConfig.UserName = txtUserName.Text;
                tmpConfig.Password = txtPassword.Text;
                connStr = tmpConfig.GetConnectionString();

                lastStep = "Opening connection";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    lastStep = "Inserting test message into database";

                    string cmndName = txtCmndValue.Text.Replace("'", "''");
                    string viewerName = txtViewerName.Text.Replace("'", "''");
                    string alertParamName = txtAlertFieldName.Text.Replace("'", "''").Replace("@", "");
                    string collectorTypeParamName = txtCollectorType.Text.Replace("'", "''").Replace("@", "");
                    string categoryParamName = txtCategoryFieldName.Text.Replace("'", "''").Replace("@", "");
                    string previousStateParamName = txtPreviousStateFieldName.Text.Replace("'", "''").Replace("@", "");
                    string currentStateParamName = txtCurrentStateFieldName.Text.Replace("'", "''").Replace("@", "");
                    string detailsParamName = txtDetailsFieldName.Text.Replace("'", "''").Replace("@", "");
                    string datetimeParamName = txtDateTimeFieldName.Text.Replace("'", "''").Replace("@", "");
                    int topCount = 1;

                    string sql = chkUseSP.Checked ? cmndName :
                        string.Format("Insert {0} ({1}, {2}, {3}, {4}, {5}, {6}) values(@{1}, @{2}, @{3}, @{4}, @{5}, @{6})",
                            cmndName,
                            alertParamName,
                            collectorTypeParamName,
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
                                new SqlParameter("@" + collectorTypeParamName, "N/A"),
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
                    sql = chkUseSP2.Checked ? viewerName : GetQuery(viewerName, alertParamName, collectorTypeParamName,
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
        private string GetQuery(string viewerName, string alertParamName, string collectorTypeParamName, string categoryParamName, string previousStateParamName, string currentStateParamName, string detailsParamName, string datetimeParamName)
        {
            return string.Format("Select top (@Top) {0}, {1}, {2}, {3}, {4}, {5}, @FromDate, @ToDate, @{0}, @{1}, @{3}, @{4}, @{5} from {6} with (Readpast) order by {6} desc",
                    alertParamName, collectorTypeParamName, categoryParamName, previousStateParamName, currentStateParamName, detailsParamName,
                    viewerName, datetimeParamName);
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            CheckOKEnabled();
        }

        private void llblDBCreateScript_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(Properties.Resources.ExampleSqlDatabaseCreateScript);
        }
    }
}
