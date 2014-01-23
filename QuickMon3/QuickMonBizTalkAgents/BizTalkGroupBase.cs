using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.BizTalk
{
    public class BizTalkGroupBase
    {
        public BizTalkGroupBase()
        {
            AllAppsHosts = true;
            Hosts = new List<string>();
            Apps = new List<string>();
            MgmtDBName = "BizTalkMgmtDb";
        }

        #region Properties
        public string SqlServer { get; set; }
        public string MgmtDBName { get; set; }
        public int InstancesWarning { get; set; }
        public int InstancesError { get; set; }
        public List<string> Hosts { get; set; }
        public bool AllAppsHosts { get; set; }
        public List<string> Apps { get; set; }
        public int ShowLastXDetails { get; set; }
        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = SqlServer;
                sb.InitialCatalog = MgmtDBName;
                sb.IntegratedSecurity = true;
                return  sb.ConnectionString;
            }
        }
        public string LastError { get; set; }
        #endregion

        #region Test connection
        public bool TestConnection()
        {
            bool success = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                LastError = ex.ToString();
            }
            return success;
        }
        #endregion

        #region Get host and application lists
        public List<string> GetHostList()
        {
            string sql = "select Name from dbo.adm_Host with (readpast)";
            List<string> hosts = new List<string>();
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmnd.ExecuteReader();
                    while (dr.Read())
                    {
                        string queue = dr[0].ToString();
                        hosts.Add(queue);
                    }
                }
                conn.Close();
            }
            return hosts;
        }
        public List<string> GetApplicationList()
        {
            string sql = "select nvcName from dbo.bts_application with (readpast)";
            List<string> apps = new List<string>();
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmnd.ExecuteReader();
                    while (dr.Read())
                    {
                        string queue = dr[0].ToString();
                        apps.Add(queue);
                    }
                }
                conn.Close();
            }
            return apps;
        }
        #endregion
    }
}
