using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public abstract class LinuxBaseEntry : ICollectorConfigEntry
    {
        public LinuxBaseEntry()
        {
            SSHConnection = new SSHConnectionDetails() { SSHSecurityOption = SSHSecurityOption.Password, SSHPort = 22 };
            //SSHSecurityOption = SSHSecurityOption.Password;
            //SSHPort = 22;
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        public SSHConnectionDetails SSHConnection { get; set; }

        //public SSHSecurityOption SSHSecurityOption { get; set; }
        //public string MachineName { get; set; }
        //public int SSHPort { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string PrivateKeyFile { get; set; }
        //public string PassPhrase { get; set; }

        #region ICollectorConfigEntry Members
        public virtual string Description
        {
            get
            {
                return string.Format("{0}:{1}", SSHConnection.ComputerName, SSHConnection.SSHPort);
            }
        }
        public abstract string TriggerSummary { get; }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion
    }
}
