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

        public override string ToString()
        {
            return string.Format("{0} - {1}\\{2}\\{3}", Name, SqlServer, Database, SummaryQuery);
        }

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
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

        internal int RunQueryWithCountResult()
        {
            int returnValue = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
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
            }
            return returnValue;
        }

        internal object RunQueryWithSingleResult()
        {
            object returnValue = null;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
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
