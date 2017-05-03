using QuickMon.SSH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Collectors
{
    public abstract class SSHBaseConfigEntry : ICollectorConfigEntry
    {
        public SSHBaseConfigEntry()
        {
            SSHConnection = new SSHConnectionDetails() { SSHSecurityOption = SSHSecurityOption.Password, SSHPort = 22 };
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        public SSHConnectionDetails SSHConnection { get; set; }
        public string OutputValueUnit { get; set; }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }

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
        public abstract MonitorState GetCurrentState();
        #endregion
    }
}
