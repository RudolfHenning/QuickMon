using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QuickMon.BizTalk;

namespace QuickMon.Collectors
{
    public class BizTalkSuspendedCounts : BizTalkGroupBase
    {
        #region Get Suspended Msgs
        public int GetSuspendedMsgsCount()
        {
            int suspendedMsgsCount = 0;
            foreach (string connString in GetMsgBoxConnStrs())
            {
                foreach (string suspendedQueue in GetHostInstanceSuspendedQs(connString))
                {
                    string hostName = suspendedQueue.Substring(0, suspendedQueue.Length - 11);
                    if (Hosts.Count == 0 || Hosts.Contains(hostName))
                    {
                        suspendedMsgsCount += GetHostSuspendedInstanceCount(connString, suspendedQueue);
                    }
                }
            }

            return suspendedMsgsCount;
        }
        private List<string> GetMsgBoxConnStrs()
        {
            string sql = "select DBServerName, DBName from dbo.adm_MessageBox with (NoLOCK)";
            List<string> connStrs = new List<string>();
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmnd.ExecuteReader();
                    while (dr.Read())
                    {
                        string connStr = "Server=" + dr[0].ToString() + ";Database=" + dr[1].ToString() + ";Trusted_Connection=True;";
                        connStrs.Add(connStr);
                    }
                }
                conn.Close();
            }
            return connStrs;
        }
        private List<string> GetHostInstanceSuspendedQs(string currentMsgBoxConnectionString)
        {
            string sql = "SET DEADLOCK_PRIORITY LOW\r\nselect name from sysobjects with (readpast) where name like '%_Suspended'";
            List<string> queues = new List<string>();
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(currentMsgBoxConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    SqlDataReader dr = cmnd.ExecuteReader();
                    while (dr.Read())
                    {
                        string queue = dr[0].ToString();
                        if (queue.EndsWith("_Suspended"))
                            queues.Add(queue);
                    }
                }
                conn.Close();
            }
            return queues;
        }
        private int GetHostSuspendedInstanceCount(string currentMsgBoxConnectionString, string hostInstanceSuspendedQ)
        {
            int hostSuspendedInstanceCount = 0;

            string sql = "SET DEADLOCK_PRIORITY LOW\r\n" +
                "select count(*) " +
                "from " + hostInstanceSuspendedQ + " b with (readpast) inner Join Spool s with (readpast) on b.uidMessageID = s.[uidMessageID ] " +
                  "inner join InstancesSuspended i with (readpast) on b.uidInstanceID = i.uidInstanceID inner join Services se with (readpast) on se.uidServiceID = b.uidServiceID inner join Modules m with (readpast) on m.nModuleID = se.nModuleID " +
                "where (i.nState = 4 or i.nState = 32)";
            if (Apps.Count > 0)
            {
                string appFilter = "";
                foreach (string app in Apps)
                {
                    appFilter += "'" + app + "',";
                }
                appFilter = appFilter.TrimEnd(',');
                sql += " and m.nvcName in (" + appFilter + ")";
            }

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(currentMsgBoxConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandTimeout = 60;
                    object tmp = cmnd.ExecuteScalar();
                    if (tmp != null)
                    {
                        hostSuspendedInstanceCount += (int)tmp;
                    }
                }
                conn.Close();
            }

            return hostSuspendedInstanceCount;
        }
        #endregion

        #region Get top X suspended entry details
        internal AgentMultiFormatInfoMsg GetLastXDetails()
        {
            AgentMultiFormatInfoMsg collectorMessage = new AgentMultiFormatInfoMsg();
            StringBuilder sbText = new StringBuilder();
            StringBuilder sbHtml = new StringBuilder();
            List<SuspendedInstance> suspendedInstances = new List<SuspendedInstance>();
            if (ShowLastXDetails > 0)
            {
                foreach (string connString in GetMsgBoxConnStrs())
                {
                    foreach (string suspendedQueue in GetHostInstanceSuspendedQs(connString))
                    {
                        string hostName = suspendedQueue.Substring(0, suspendedQueue.Length - 11);
                        if (Hosts.Count == 0 || Hosts.Contains(hostName))
                        {
                            suspendedInstances.AddRange(GetHostSuspendedInstancesLastX(connString, suspendedQueue));
                        }
                    }
                }
            }
            foreach (SuspendedInstance suspendedItem in (from s in suspendedInstances
                                                         orderby s.SuspendTime descending
                                                         select s).Take(ShowLastXDetails))
            {
                sbText.AppendLine(suspendedItem.ToString());
                sbHtml.AppendLine(suspendedItem.ToString(true));
            }
            collectorMessage.RawText = sbText.ToString();
            collectorMessage.HTMLText = sbHtml.ToString();
            return collectorMessage;
        }
        private IEnumerable<SuspendedInstance> GetHostSuspendedInstancesLastX(string connString, string hostInstanceSuspendedQ)
        {
            List<SuspendedInstance> suspendedInstances = new List<SuspendedInstance>();
            DataSet results = new DataSet();
            string hostName = hostInstanceSuspendedQ.Substring(0, hostInstanceSuspendedQ.Length - 11);
            string sql = "SET DEADLOCK_PRIORITY LOW\r\n" +
                "select top " + ShowLastXDetails.ToString() + " '" + hostName + "' as [Host], m.nvcName as [App], s.nvcMessageType, " +
                "s.PublishingServer, i.dtSuspendTimeStamp, i.nvcURI, i.nvcAdapter, " +
                "b.nvcAdditionalInfo, b.uidInstanceID, b.uidServiceID, s.imgContext, i.dtCreated, i.nvcErrorDescription " +
                "from " + hostInstanceSuspendedQ + " b with (readpast) inner Join Spool s with (readpast) on b.uidMessageID = s.[uidMessageID ] " +
                  "inner join InstancesSuspended i with (readpast) on b.uidInstanceID = i.uidInstanceID inner join Services se with (readpast) on se.uidServiceID = b.uidServiceID inner join Modules m with (readpast) on m.nModuleID = se.nModuleID " +
                "where (i.nState = 4 or i.nState = 32) " +
                "order by i.dtSuspendTimeStamp desc";
            if (Apps.Count > 0)
            {
                string appFilter = "";
                foreach (string app in Apps)
                {
                    appFilter += "'" + app + "',";
                }
                appFilter = appFilter.TrimEnd(',');
                sql += " and m.nvcName in (" + appFilter + ")";
            }
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandTimeout = 60;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmnd))
                    {
                        da.Fill(results);
                    }
                }
                conn.Close();
            }
            foreach (DataRow row in results.Tables[0].Rows)
            {
                SuspendedInstance suspendedInstance = new SuspendedInstance();
                suspendedInstance.Host = row[0].ToString();
                suspendedInstance.Application = row[1].ToString();
                suspendedInstance.MessageType = row[2].ToString();
                suspendedInstance.PublishingServer = row[3].ToString();

                DateTime tmpdt;
                if (DateTime.TryParse(row[4].ToString(), out tmpdt))
                {
                    suspendedInstance.SuspendTime = tmpdt;
                }
                else if (DateTime.TryParse(row[11].ToString(), out tmpdt))
                {
                    suspendedInstance.SuspendTime = tmpdt;
                }

                suspendedInstance.Uri = row[5].ToString();
                suspendedInstance.Adapter = row[6].ToString();
                if (row[7].ToString().Length > 0)
                    suspendedInstance.AdditionalInfo = row[7].ToString();
                else
                    suspendedInstance.AdditionalInfo = row[12].ToString();

                suspendedInstance.InstanceID = row[8].ToString();
                suspendedInstance.ServiceID = row[9].ToString();
                suspendedInstance.Context = (Byte[])row[10];
                suspendedInstances.Add(suspendedInstance);
            }

            return suspendedInstances;
        }
        #endregion

        #region Get All suspended entries
        internal List<SuspendedInstance> GetAllSuspendedInstances()
        {
            List<SuspendedInstance> suspendedInstances = new List<SuspendedInstance>();
            foreach (string connString in GetMsgBoxConnStrs())
            {
                foreach (string suspendedQueue in GetHostInstanceSuspendedQs(connString))
                {
                    string hostName = suspendedQueue.Substring(0, suspendedQueue.Length - 11);
                    if (Hosts.Count == 0 || Hosts.Contains(hostName))
                    {
                        suspendedInstances.AddRange(GetHostSuspendedInstances(connString, suspendedQueue));
                    }
                }
            }
            return suspendedInstances;
        }
        private IEnumerable<SuspendedInstance> GetHostSuspendedInstances(string connString, string hostInstanceSuspendedQ)
        {
            List<SuspendedInstance> suspendedInstances = new List<SuspendedInstance>();
            DataSet results = new DataSet();
            string hostName = hostInstanceSuspendedQ.Substring(0, hostInstanceSuspendedQ.Length - 11);
            string appFilter = "";
            if (Apps.Count > 0)
            {                
                foreach (string app in Apps)
                {
                    appFilter += "'" + app + "',";
                }
                appFilter = appFilter.TrimEnd(',');
                appFilter = " and m.nvcName in (" + appFilter + ") ";
            }
            string sql = "SET DEADLOCK_PRIORITY LOW\r\n" +
                "select '" + hostName + "' as [Host], m.nvcName as [App], s.nvcMessageType, " +
                "s.PublishingServer, i.dtSuspendTimeStamp, i.nvcURI, i.nvcAdapter, " +
                "b.nvcAdditionalInfo, b.uidInstanceID, b.uidServiceID, s.imgContext, i.dtCreated, i.nvcErrorDescription " +
                "from " + hostInstanceSuspendedQ + " b with (readpast) inner Join Spool s with (readpast) on b.uidMessageID = s.[uidMessageID ] " +
                  "inner join InstancesSuspended i with (readpast) on b.uidInstanceID = i.uidInstanceID inner join Services se with (readpast) on se.uidServiceID = b.uidServiceID inner join Modules m with (readpast) on m.nModuleID = se.nModuleID " +
                "where (i.nState = 4 or i.nState = 32) " + appFilter +
                "order by i.dtSuspendTimeStamp desc";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandTimeout = 60;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmnd))
                    {
                        da.Fill(results);
                    }
                }
                conn.Close();
            }
            foreach (DataRow row in results.Tables[0].Rows)
            {
                SuspendedInstance suspendedInstance = new SuspendedInstance();
                suspendedInstance.Host = row[0].ToString();
                suspendedInstance.Application = row[1].ToString();
                suspendedInstance.MessageType = row[2].ToString();
                suspendedInstance.PublishingServer = row[3].ToString();

                DateTime tmpdt = DateTime.Now;

                int gmtDiffMin = (int)tmpdt.Subtract(tmpdt.ToUniversalTime()).TotalMinutes;
                if (DateTime.TryParse(row[4].ToString(), out tmpdt))
                {
                    suspendedInstance.SuspendTime = tmpdt.AddMinutes(gmtDiffMin);
                }
                else if (DateTime.TryParse(row[11].ToString(), out tmpdt))
                {
                    suspendedInstance.SuspendTime = tmpdt.AddMinutes(gmtDiffMin);
                }
                suspendedInstance.Uri = row[5].ToString();
                suspendedInstance.Adapter = row[6].ToString();
                if (row[7].ToString().Length > 0)
                    suspendedInstance.AdditionalInfo = row[7].ToString();
                else
                    suspendedInstance.AdditionalInfo = row[12].ToString();

                suspendedInstance.InstanceID = row[8].ToString();
                suspendedInstance.ServiceID = row[9].ToString();
                suspendedInstance.Context = (Byte[])row[10];
                suspendedInstances.Add(suspendedInstance);
            }

            return suspendedInstances;
        }
        #endregion


    }
}
