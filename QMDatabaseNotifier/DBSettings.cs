using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QuickMon
{
    public class DBSettings
    {
        private string sqlServer;
        public string SqlServer { get { return sqlServer; } set { sqlServer = value; } }
        string database = "QuickMon";
        public string Database { get { return database; } set { database = value; } }
        private bool integratedSec;
        public bool IntegratedSec { get { return integratedSec; } set { integratedSec = value; } }
        private string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        private string password;
        public string Password { get { return password; } set { password = value; } }
        private int cmndTimeOut = 60;
        public int CmndTimeOut { get { return cmndTimeOut; } set { cmndTimeOut = value; } }
        private bool useSP;
        public bool UseSP { get { return useSP; } set { useSP = value; } }
        private string cmndValue;
        public string CmndValue { get { return cmndValue; } set { cmndValue = value; } }
        private string alertFieldName;
        public string AlertFieldName { get { return alertFieldName; } set { alertFieldName = value; } }
        private string collectorTypeFieldName;
        public string CollectorTypeFieldName { get { return collectorTypeFieldName; } set { collectorTypeFieldName = value; } }
        private string categoryFieldName;
        public string CategoryFieldName { get { return categoryFieldName; } set { categoryFieldName = value; } }
        private string previousStateFieldName;
        public string PreviousStateFieldName { get { return previousStateFieldName; } set { previousStateFieldName = value; } }
        private string currentStateFieldName;
        public string CurrentStateFieldName { get { return currentStateFieldName; } set { currentStateFieldName = value; } }
        private string detailsFieldName;
        public string DetailsFieldName { get { return detailsFieldName; } set { detailsFieldName = value; } }
        private bool useSPForViewer = true;
        public bool UseSPForViewer { get { return useSPForViewer; } set { useSPForViewer = value; } }
        private string viewerName;
        public string ViewerName { get { return viewerName; } set { viewerName = value; } }
        private string dateTimeFieldName;
        public string DateTimeFieldName { get { return dateTimeFieldName; } set { dateTimeFieldName = value; } }

        public string GetConnectionString()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = sqlServer;
            scsb.InitialCatalog = database;
            scsb.IntegratedSecurity = integratedSec;
            if (!integratedSec)
            {
                scsb.UserID = userName;
                scsb.Password = password;
            }
            return scsb.ConnectionString;
        }
    }
}
