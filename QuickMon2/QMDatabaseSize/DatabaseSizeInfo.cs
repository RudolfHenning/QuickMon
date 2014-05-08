using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QuickMon
{
    public class DatabaseSizeInfo
    {
        private SqlConnection conn;
        private int cmndTimeOut = 60;
        public void OpenConnection(string sqlServer, bool integratedSec, string userName, string password, int cmndTimeOut)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = sqlServer;
            scsb.InitialCatalog = "master";
            scsb.IntegratedSecurity = integratedSec;
            this.cmndTimeOut = cmndTimeOut;
            if (!integratedSec)
            {
                scsb.UserID = userName;
                scsb.Password = password;
            }
            conn = new SqlConnection(scsb.ConnectionString);
            conn.Open();
        }
        public void CloseConnection()
        {
            conn.Close();
            conn.Dispose();
        }
        public long GetDatabaseSize(string database)
        {
            long result = 0;
            string sql = Properties.Resources.SelectDatabaseSizesScript.Replace("<Database>", database);
            using (SqlCommand cmnd = new SqlCommand(sql, conn))
            {
                cmnd.CommandTimeout = cmndTimeOut;
                object tmp = cmnd.ExecuteScalar();
                result = long.Parse(tmp.ToString());
            }
            return result;
        }
        internal List<string> GetDatabaseNames()
        {
            List<string> names = new List<string>();
            string sql = "select name as DatabaseName From sysdatabases where dbid>4";
            using (SqlCommand cmnd = new SqlCommand(sql, conn))
            {
                cmnd.CommandTimeout = cmndTimeOut;
                using (SqlDataReader r = cmnd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        names.Add(r[0].ToString());
                    }
                }
            }
            return names;
        }
    }
}
