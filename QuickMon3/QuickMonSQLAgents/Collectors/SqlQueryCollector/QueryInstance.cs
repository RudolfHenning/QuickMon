using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class QueryInstance : ICollectorConfigEntry
    {
        #region Properties
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
        public bool UseExecuteTimeAsValue { get; set; }
        private SqlConnection testExecutionConn = null;
        public string ApplicationName { get; set; }
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0} - {1}\\{2}\\{3}", Name, SqlServer, Database, SummaryQuery); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Success: {0}, Warn: {1}, Err: {2}", SuccessValue, WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} - {1}\\{2}\\{3}", Name, SqlServer, Database, SummaryQuery);
        }
        public string ToServerDBName()
        {
            return string.Format("{0}\\{1}", SqlServer, Database);
        }

        #region Connection stuff
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
        #endregion

        #region RunQuery
        internal object RunQuery()
        {
            object value = null;

            if (!ReturnValueIsNumber)
                value = RunQueryWithSingleResult();
            else if (!UseRowCountAsValue && !UseExecuteTimeAsValue)
                value = RunQueryWithSingleResult();
            else if (UseRowCountAsValue)
                value = RunQueryWithCountResult();
            else
                value = RunQueryWithExecutionTimeResult();

            return value;
        }
        private int RunQueryWithCountResult()
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
        private object RunQueryWithSingleResult()
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
        private long RunQueryWithExecutionTimeResult()
        {
            long returnValue = 0;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            SqlConnection conn = GetConnection();
            try
            {
                using (SqlCommand cmnd = new SqlCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    cmnd.Prepare();
                    sw.Start();
                    using (SqlDataReader r = cmnd.ExecuteReader())
                    {
                        while (r.Read())
                        {

                        }
                    }
                    sw.Stop();
                    returnValue = sw.ElapsedMilliseconds;
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
        #endregion

        internal CollectorState GetState(object value)
        {
            CollectorState currentState = CollectorState.Good;
            if (value == DBNull.Value)
            {
                if (ErrorValue == "[null]")
                    currentState = CollectorState.Error;
                else if (WarningValue == "[null]")
                    currentState = CollectorState.Warning;
            }
            else //non null value
            {
                if (!ReturnValueIsNumber)
                {
                    if (value.ToString() == ErrorValue)
                        currentState = CollectorState.Error;
                    else if (value.ToString() == WarningValue)
                        currentState = CollectorState.Warning;
                    else if (value.ToString() == SuccessValue || SuccessValue == "[any]")
                        currentState = CollectorState.Good; //just to flag condition
                    else if (WarningValue == "[any]")
                        currentState = CollectorState.Warning;
                    else if (ErrorValue == "[any]")
                        currentState = CollectorState.Error;
                }
                else //now we know the value is not null and must be in a range
                {
                    if (!value.IsNumber()) //value must be a number!
                    {
                        currentState = CollectorState.Error;
                    }
                    else if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
                            (
                             (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(ErrorValue)) ||
                             (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(ErrorValue))
                            )
                        )
                    {
                        currentState = CollectorState.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(WarningValue)) ||
                            (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(WarningValue))
                           )
                        )
                    {
                        currentState = CollectorState.Warning;
                    }
                }
            }
            return currentState;
        }

        internal DataSet RunDetailQuery()
        {
            DataSet returnValues = new DataSet();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(DetailQuery, conn))
                {
                    cmnd.CommandType = UseSPForDetail ? CommandType.StoredProcedure : CommandType.Text;
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
