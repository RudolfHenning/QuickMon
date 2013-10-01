using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public class DatabaseSizeConfig
    {
        private string sqlServer = "";
        public string SqlServer
        {
            get { return sqlServer; }
            set { sqlServer = value; }
        }
        private bool integratedSec;
        public bool IntegratedSec
        {
            get { return integratedSec; }
            set { integratedSec = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private int cmndTimeOut = 60;
        public int CmndTimeOut
        {
            get { return cmndTimeOut; }
            set { cmndTimeOut = value; }
        }

        public List<DatabaseEntry> Databases = new List<DatabaseEntry>();

    }
}
