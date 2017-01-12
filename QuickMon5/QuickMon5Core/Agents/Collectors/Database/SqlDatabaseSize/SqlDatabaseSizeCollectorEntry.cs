using HenIT.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
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
            if (!IntegratedSecurity){
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
