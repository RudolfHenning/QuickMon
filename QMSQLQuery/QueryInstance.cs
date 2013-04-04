using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace QuickMon
{
    public class QueryInstance
    {
        public string Name { get; set; }
        public string SqlServer { get; set; }
        public string Database { get; set; }
        private bool integratedSecurity = true;
        public bool IntegratedSecurity { get { return integratedSecurity; } set { integratedSecurity = value; } }
        public string UserName { get; set; }
        public string Password { get; set; }
        private int cmndTimeOut = 60;
        public int CmndTimeOut { get { return cmndTimeOut; } set { cmndTimeOut = value; } }
        public bool UseSPForSummary { get; set; }
        public bool UseSPForDetail { get; set; }
        public string SummaryQuery { get; set; }
        public string DetailQuery { get; set; }
        private bool returnValueIsNumber = true;
        public bool ReturnValueIsNumber { get { return returnValueIsNumber; } set { returnValueIsNumber = value; } }
        public bool ReturnValueInverted { get; set; }
        private string warningValue = "1";
        public string WarningValue { get { return warningValue; } set { warningValue = value; } }
        private string errorValue = "2";
        public string ErrorValue { get { return errorValue; } set { errorValue = value; } }
        private string successValue = "[any]";
        public string SuccessValue { get { return successValue; } set { successValue = value; } }
        public bool UseRowCountAsValue { get; set; }
        public bool UsePersistentConnection { get; set; }
        private SqlConnection testExecutionConn = null;
        public string ApplicationName { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0} - {1}\\{2}\\{3}", Name, SqlServer, Database, SummaryQuery);
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.ApplicationName = ApplicationName;
            sb.DataSource = SqlServer;
            sb.InitialCatalog = Database;
            sb.IntegratedSecurity = IntegratedSecurity;
            if (!IntegratedSecurity)
            {
                sb.UserID = UserName;
                sb.Password = Password;
            }
            return sb.ConnectionString;
        }
        private SqlConnection GetConnection()
        {
            try
            {
                if (UsePersistentConnection)
                {
                    if (testExecutionConn == null || testExecutionConn.State == ConnectionState.Closed)
                    {
                        testExecutionConn = new SqlConnection(GetConnectionString());
                        testExecutionConn.Open();
                    }
                }
                else
                {
                    if (testExecutionConn != null)
                    {
                        CloseConnection();
                    }
                    testExecutionConn = new SqlConnection(GetConnectionString());
                    testExecutionConn.Open();
                }
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return testExecutionConn;
        }
        private void CloseConnection(bool closeNonPersistent = false)
        {
            try
            {
                if (closeNonPersistent && UsePersistentConnection)
                {
                    testExecutionConn.Close();
                    testExecutionConn = null;
                }
            }
            catch { }
        }

        internal int RunQueryWithCountResult()
        {
            int returnValue = 0;
            SqlConnection conn = GetConnection();
            try
            {
                using (SqlCommand cmnd = new SqlCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (SqlDataReader r = cmnd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            returnValue++;
                        }
                    }
                }
                CloseConnection();
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return returnValue;
        }

        internal object RunQueryWithSingleResult()
        {
            object returnValue = null;
            SqlConnection conn = GetConnection();
            try
            {
                using (SqlCommand cmnd = new SqlCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (SqlDataReader r = cmnd.ExecuteReader())
                    {
                        if (r.Read())
                            returnValue = r[0];
                    }
                }
                CloseConnection();
            }
            catch
            {
                CloseConnection(true);
                throw;
            }
            return returnValue;
        }

        internal DataSet RunDetailQuery()
        {
            DataSet returnValues = new DataSet();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(DetailQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmnd))
                    {
                        da.Fill(returnValues);
                    }
                }
            }
            return returnValues;
        }
    }
}
