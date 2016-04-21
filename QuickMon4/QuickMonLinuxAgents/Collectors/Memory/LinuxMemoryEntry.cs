using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxMemoryEntry : ICollectorConfigEntry
    {
        public LinuxMemoryEntry()
        {
            SSHSecurityOption = SSHSecurityOption.Password;
            SSHPort = 22;
            WarningValue = 80;
            ErrorValue = 99;
        }
        public SSHSecurityOption SSHSecurityOption { get; set; }
        public string MachineName { get; set; }
        public int SSHPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrivateKeyFile { get; set; }
        public string PassPhrase { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public MemInfo GetMemoryInfo()
        {
            MemInfo mi = new MemInfo();
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, PrivateKeyFile, PassPhrase);

            if (sshClient.IsConnected)
            {
                mi = MemInfo.FromCatProcMeminfo(sshClient);                
            }
            sshClient.Disconnect();

            return mi;
        }
        public CollectorState GetState(double value)
        {
            CollectorState state = CollectorState.Good;
            if (WarningValue < ErrorValue)
            {
                if (ErrorValue <= value)
                    state = CollectorState.Error;
                else if (WarningValue <= value)
                    state = CollectorState.Warning;
            }
            else
            {
                if (ErrorValue >= value)
                    state = CollectorState.Error;
                else if (WarningValue >= value)
                    state = CollectorState.Warning;
            }
            return state;
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return string.Format("{0}:{1}", MachineName, SSHPort);
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Warn: {0}%, Err: {1}%", WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion
    }
}
