using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuickMon
{
    public partial class EditConfig : Form
    {
        public EditConfig()
        {
            InitializeComponent();
        }

        #region Properties
        public DBSettings DbSettings { get; set; }
        //public string SqlServer { get { return txtServer.Text; } set { txtServer.Text = value; } }
        //public string Database { get { return txtDatabase.Text; } set { txtDatabase.Text = value; } }
        //public bool IntegratedSec { get { return chkIntegratedSec.Checked; } set { chkIntegratedSec.Checked = value; } }
        //public string UserName { get { return txtUserName.Text; } set { txtUserName.Text = value; } }
        //public string Password { get { return txtPassword.Text; } set { txtPassword.Text = value; } }
        //public int CmndTimeOut { get { return (int)numericUpDownCmndTimeOut.Value; } set { numericUpDownCmndTimeOut.Value = value; } }
        //public bool UseSP { get { return chkUseSP.Checked; } set { chkUseSP.Checked = value; } }
        //public string CmndValue { get { return txtCmndValue.Text; } set { txtCmndValue.Text = value; } }
        //public string AlertFieldName
        //{
        //    get { return txtAlertFieldName.Text; }
        //    set { txtAlertFieldName.Text = value; }
        //}
        //public string CategoryFieldName
        //{
        //    get { return txtCategoryFieldName.Text; }
        //    set { txtCategoryFieldName.Text = value; }
        //}
        //public string PreviousStateFieldName
        //{
        //    get { return txtPreviousStateFieldName.Text; }
        //    set { txtPreviousStateFieldName.Text = value; }
        //}
        //public string CurrentStateFieldName
        //{
        //    get { return txtCurrentStateFieldName.Text; }
        //    set { txtCurrentStateFieldName.Text = value; }
        //}
        //public string DetailsFieldName
        //{
        //    get { return txtDetailsFieldName.Text; }
        //    set { txtDetailsFieldName.Text = value; }
        //}
        //public bool UseSPForViewer { get { return chkUseSP2.Checked; } set { chkUseSP2.Checked = value; } }
        //public string ViewerName { get { return txtViewerName.Text; } set { txtViewerName.Text = value; } }
        #endregion

        private void chkIntegratedSec_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.ReadOnly = chkIntegratedSec.Checked;
            txtPassword.ReadOnly = chkIntegratedSec.Checked;
        }

        public DialogResult ShowConfig()
        {
            txtServer.Text = DbSettings.SqlServer;
            txtDatabase.Text = DbSettings.Database;
            chkIntegratedSec.Checked = DbSettings.IntegratedSec;
            txtUserName.Text = DbSettings.UserName;
            txtPassword.Text = DbSettings.Password;
            numericUpDownCmndTimeOut.Value = DbSettings.CmndTimeOut;
            chkUseSP.Checked = DbSettings.UseSP;
            txtCmndValue.Text = DbSettings.CmndValue;
            txtAlertFieldName.Text = DbSettings.AlertFieldName;
            txtCollectorType.Text = DbSettings.CollectorTypeFieldName;
            txtCategoryFieldName.Text = DbSettings.CategoryFieldName;
            txtPreviousStateFieldName.Text = DbSettings.PreviousStateFieldName;
            txtCurrentStateFieldName.Text = DbSettings.CurrentStateFieldName;
            txtDetailsFieldName.Text = DbSettings.DetailsFieldName;
            chkUseSP2.Checked = DbSettings.UseSPForViewer;
            txtViewerName.Text = DbSettings.ViewerName;
            txtDateTimeFieldName.Text = DbSettings.DateTimeFieldName;
            return ShowDialog();
        }

        private void cmdTest_Click(object sender, EventArgs e)
        {
            string connStr = "";
            string lastStep = "";
            try
            {
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
                DbSettings.SqlServer = txtServer.Text;
                DbSettings.Database = txtDatabase.Text;
                DbSettings.IntegratedSec = chkIntegratedSec.Checked;
                DbSettings.UserName = txtUserName.Text;
                DbSettings.Password = txtPassword.Text;
                connStr = DbSettings.GetConnectionString();

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

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DbSettings.SqlServer = txtServer.Text;
            DbSettings.Database = txtDatabase.Text;
            DbSettings.IntegratedSec = chkIntegratedSec.Checked;
            DbSettings.UserName = txtUserName.Text;
            DbSettings.Password = txtPassword.Text;
            DbSettings.CmndTimeOut = (int)numericUpDownCmndTimeOut.Value;
            DbSettings.UseSP = chkUseSP.Checked;
            DbSettings.CmndValue = txtCmndValue.Text;
            DbSettings.AlertFieldName = txtAlertFieldName.Text;
            DbSettings.CollectorTypeFieldName = txtCollectorType.Text;
            DbSettings.CategoryFieldName = txtCategoryFieldName.Text;
            DbSettings.PreviousStateFieldName = txtPreviousStateFieldName.Text;
            DbSettings.CurrentStateFieldName = txtCurrentStateFieldName.Text;
            DbSettings.DetailsFieldName = txtDetailsFieldName.Text;
            DbSettings.UseSPForViewer = chkUseSP2.Checked;
            DbSettings.ViewerName = txtViewerName.Text;
            DbSettings.DateTimeFieldName = txtDateTimeFieldName.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
