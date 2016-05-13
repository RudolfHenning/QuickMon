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
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        public SSHConnectionDetails SSHConnection { get; set; }

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
