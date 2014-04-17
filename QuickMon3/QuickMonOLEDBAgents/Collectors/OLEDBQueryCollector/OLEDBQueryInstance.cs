using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using HenIT.Data.OLEDB;

namespace QuickMon.Collectors
{
    public class OLEDBQueryInstance : ICollectorConfigEntry
    {
        public OLEDBQueryInstance()
        {
            ConnectionString = "";
            //DataSource = "";
            //Provider = "";
            //UserName = "";
        }
        #region Properties
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        //public string DataSource { get; set; }
        //public string Provider { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
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
        private OleDbConnection testExecutionConn = null;
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return string.Format("{0}: {1} ({2})", Name, ConnectionString, SummaryQuery);
            }
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
            return string.Format("{0}: {1} ({2})", Name, ConnectionString, SummaryQuery);
        }

        #region Connection stuff
        private OleDbConnection GetConnection()
        {
            try
            {
                if (UsePersistentConnection)
                {
                    if (testExecutionConn == null || testExecutionConn.State == ConnectionState.Closed)
                    {
                        testExecutionConn = new OleDbConnection(ConnectionString);
                        testExecutionConn.Open();
                    }
                }
                else
                {
                    if (testExecutionConn != null)
                    {
                        CloseConnection();
                    }
                    testExecutionConn = new OleDbConnection(ConnectionString);
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
            OleDbConnection conn = GetConnection();
            try
            {
                using (OleDbCommand cmnd = new OleDbCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (OleDbDataReader r = cmnd.ExecuteReader())
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
            OleDbConnection conn = GetConnection();
            try
            {
                using (OleDbCommand cmnd = new OleDbCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (OleDbDataReader r = cmnd.ExecuteReader())
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
            OleDbConnection conn = GetConnection();
            try
            {
                using (OleDbCommand cmnd = new OleDbCommand(SummaryQuery, conn))
                {
                    cmnd.CommandType = UseSPForSummary ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    cmnd.Prepare();
                    sw.Start();
                    using (OleDbDataReader r = cmnd.ExecuteReader())
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
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                conn.Open();
                using (OleDbCommand cmnd = new OleDbCommand(DetailQuery, conn))
                {
                    cmnd.CommandType = UseSPForDetail ? CommandType.StoredProcedure : CommandType.Text;
                    cmnd.CommandTimeout = cmndTimeOut;
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmnd))
                    {
                        da.Fill(returnValues);
                    }
                }
            }
            return returnValues;
        }
    }
}
