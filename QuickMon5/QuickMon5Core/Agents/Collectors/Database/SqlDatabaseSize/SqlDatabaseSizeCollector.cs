using HenIT.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("SQL Database Size Collector"), Category("Database")]
    public class SqlDatabaseSizeCollector : CollectorAgentBase
    {
        public SqlDatabaseSizeCollector()
        {
            AgentConfig = new SqlDatabaseSizeCollectorConfig();
        }
        //public override MonitorState RefreshState()
        //{
        //    MonitorState returnState = new MonitorState();
        //    string lastAction = "";
        //    int errors = 0;
        //    int warnings = 0;
        //    int success = 0;
        //    double totalValue = 0;
        //    try
        //    {
        //        SqlDatabaseSizeCollectorConfig currentConfig = (SqlDatabaseSizeCollectorConfig)AgentConfig;

        //        returnState.RawDetails = string.Format("Running {0} queries", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>Running {0} queries</b>", currentConfig.Entries.Count);
        //        returnState.CurrentValue = 0;
        //        foreach (SqlDatabaseSizeCollectorEntry entry in currentConfig.Entries)
        //        {
        //            long size = entry.GetDBSize();
        //            CollectorState currentState = entry.GetState(size);
        //            totalValue += size;

        //            if (currentState == CollectorState.Error)
        //            {
        //                errors++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Error,
        //                        ForAgent = entry.Database,
        //                        CurrentValue = string.Format("{0} MB", size),
        //                        RawDetails = string.Format("(Trigger '{0} MB')", entry.ErrorSizeMB)
        //                    });
        //            }
        //            else if (currentState == CollectorState.Warning)
        //            {
        //                warnings++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Warning,
        //                        ForAgent = entry.Database,
        //                        CurrentValue = string.Format("{0} MB", size),
        //                        RawDetails = string.Format("(Trigger '{0} MB')", entry.WarningSizeMB)
        //                    });
        //            }
        //            else
        //            {
        //                success++;
        //                returnState.ChildStates.Add(
        //                    new MonitorState()
        //                    {
        //                        State = CollectorState.Good,
        //                        ForAgent = entry.Database,
        //                        CurrentValue = string.Format("{0} MB", size)
        //                    });
        //            }
        //        }
        //        returnState.CurrentValue = totalValue;

        //        if (errors > 0 && warnings == 0 && success == 0) // any errors
        //            returnState.State = CollectorState.Error;
        //        else if (errors > 0 || warnings > 0) //any warnings
        //            returnState.State = CollectorState.Warning;
        //        else
        //            returnState.State = CollectorState.Good;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnState.RawDetails = ex.Message;
        //        returnState.HtmlDetails = string.Format("<p><b>Last action:</b> {0}</p><blockquote>{1}</blockquote>", lastAction, ex.Message);
        //        returnState.State = CollectorState.Error;
        //    }
        //    return returnState;
        //}

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> list = new List<System.Data.DataTable>();
            SqlDatabaseSizeCollectorConfig currentConfig = (SqlDatabaseSizeCollectorConfig)AgentConfig;

            System.Data.DataTable dt = new System.Data.DataTable("Database Sizes");
            dt.Columns.Add(new System.Data.DataColumn("Database", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Size (MB)", typeof(int)));
            foreach (SqlDatabaseSizeCollectorEntry entry in currentConfig.Entries)
            {
                dt.Rows.Add(entry.Database, entry.GetDBSize());
            }
            list.Add(dt);
            return list;
        }
    }
    public class SqlDatabaseSizeCollectorConfig : ICollectorConfig
    {
        public SqlDatabaseSizeCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement databaseNode in root.SelectNodes("databases/database"))
            {
                SqlDatabaseSizeCollectorEntry databaseEntry = new SqlDatabaseSizeCollectorEntry();
                databaseEntry.Database = databaseNode.ReadXmlElementAttr("name", "");
                databaseEntry.SqlServer = databaseNode.ReadXmlElementAttr("server", "");
                databaseEntry.IntegratedSecurity = databaseNode.ReadXmlElementAttr("integratedSec", true);
                databaseEntry.UserName = databaseNode.ReadXmlElementAttr("userName", "");
                databaseEntry.Password = databaseNode.ReadXmlElementAttr("password", "");
                databaseEntry.SqlCmndTimeOutSec = databaseNode.ReadXmlElementAttr("sqlCmndTimeOutSec", 30);
                databaseEntry.WarningSizeMB = databaseNode.ReadXmlElementAttr("warningValueMB", 1024);
                databaseEntry.ErrorSizeMB = databaseNode.ReadXmlElementAttr("errorValueMB", 4096);
                databaseEntry.PrimaryUIValue = databaseNode.ReadXmlElementAttr("primaryUIValue", true);
                Entries.Add(databaseEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode dbsNode = root.SelectSingleNode("databases");
            dbsNode.InnerXml = "";

            foreach (SqlDatabaseSizeCollectorEntry entry in Entries)
            {
                XmlElement dbSizeNode = config.CreateElement("database");
                dbSizeNode.SetAttributeValue("name", entry.Database);
                dbSizeNode.SetAttributeValue("server", entry.SqlServer);
                dbSizeNode.SetAttributeValue("integratedSec", entry.IntegratedSecurity);
                dbSizeNode.SetAttributeValue("userName", entry.UserName);
                dbSizeNode.SetAttributeValue("password", entry.Password);
                dbSizeNode.SetAttributeValue("sqlCmndTimeOutSec", entry.SqlCmndTimeOutSec);
                dbSizeNode.SetAttributeValue("warningValueMB", entry.WarningSizeMB);
                dbSizeNode.SetAttributeValue("errorValueMB", entry.ErrorSizeMB);
                dbSizeNode.SetAttributeValue("primaryUIValue", entry.PrimaryUIValue);
                dbsNode.AppendChild(dbSizeNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>\r\n<databases>\r\n<!--\r\n<database server=\".\" name=\"master\" integratedSec=\"True\" userName=\"\"  password=\"\" sqlCmndTimeOutSec=\"30\" warningValueMB=\"1024\" errorValueMB=\"4096\" />\r\n-->\r\n</databases>\r\n</config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
    public class SqlDatabaseSizeCollectorEntry : ICollectorConfigEntry
    {
        public SqlDatabaseSizeCollectorEntry()
        {
            IntegratedSecurity = true;
            SqlCmndTimeOutSec = 30;
            WarningSizeMB = 1024;
            ErrorSizeMB = 4096;
        }

        #region Properties        
        public string SqlServer { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SqlCmndTimeOutSec { get; set; }
        public long WarningSizeMB { get; set; }
        public long ErrorSizeMB { get; set; }
        #endregion

        #region ICollectorConfigEntry
        public string Description
        {
            get { return string.Format("[{0}].{1}", SqlServer, Database); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}MB, Err: {1}MB", WarningSizeMB, ErrorSizeMB);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            long size = GetDBSize();
            MonitorState currentState = new MonitorState() {
                ForAgent = Description,
                State = GetState(size),
                CurrentValue = size,
                CurrentValueUnit = "MB"
            };
            if (currentState.State == CollectorState.Error)
            {
                currentState.RawDetails = string.Format("(Trigger '{0} MB')", ErrorSizeMB);                
            }
            else if (currentState.State == CollectorState.Warning)
            {
                currentState.RawDetails = string.Format("(Trigger '{0} MB')", WarningSizeMB);                
            }

            return currentState;
        }
        #endregion

        private string GetConnectionString()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = SqlServer;
            scsb.InitialCatalog = "master";
            scsb.IntegratedSecurity = IntegratedSecurity;
            if (!IntegratedSecurity)
            {
                scsb.UserID = UserName;
                scsb.Password = Password;
            }
            return scsb.ConnectionString;
        }
        public long GetDBSize()
        {
            long sizeMB = 0;
            GenericSQLServerDAL sqlDal = new GenericSQLServerDAL() { Server = SqlServer, Database = "master" };
            if (!IntegratedSecurity)
            {
                sqlDal.UserName = UserName;
                sqlDal.Password = Password;
            }
            sqlDal.SetConnection();
            DataSet ds = sqlDal.GetDataSet(Properties.Resources.SelectDatabaseSizeScript.Replace("<Database>", Database), CommandType.Text);
            if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                object tmp = ds.Tables[0].Rows[0]["Size"];
                if (tmp != null)
                    sizeMB = long.Parse(tmp.ToString());
                else
                    throw new Exception("Invalid data returned");
            }
            else
                throw new Exception("No or invalid database specified!");

            return sizeMB;
        }
        internal CollectorState GetState(long sizeMB)
        {
            CollectorState currentState = CollectorState.Good;
            if (sizeMB < WarningSizeMB)
                currentState = CollectorState.Good;
            else if (sizeMB < ErrorSizeMB)
                currentState = CollectorState.Warning;
            else
                currentState = CollectorState.Error;
            return currentState;
        }
        private string SelectDatabaseSizesScript()
        {
            return "use master\r\n" +
                "\r\n" +
                "declare @PageSize varchar(10)\r\n" +
                "select @PageSize=v.low/1024.0\r\n" +
                "from master..spt_values v\r\n" +
                "where v.number=1 and v.type='E'\r\n" +
                "\r\n" +
                "select name as DatabaseName, convert(float,null) as Size\r\n" +
                "into #tem\r\n" +
                "From sysdatabases where dbid>4 and name like '<Database>'\r\n" +
                "\r\n" +
                "declare @SQL varchar (8000)\r\n" +
                "set @SQL=''\r\n" +
                "\r\n" +
                "while exists (select * from #tem where size is null)\r\n" +
                "begin\r\n" +
                "select @SQL='update #tem set size=(select round(sum(size)*'+@PageSize+'/1024,0) From '+quotename(databasename)+'.dbo.sysfiles) where\r\n" + "databasename=''' + databasename + ''''\r\n" +
                "from #tem\r\n" +
                "where size is null\r\n" +
                "exec (@SQL)\r\n" +
                "end\r\n" +
                "\r\n" +
                "select * from #tem order by DatabaseName\r\n" +
                "drop table #tem";
        }
    }
}
