using QuickMon.Linux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class LinuxCPUEntry : ICollectorConfigEntry
    {
        public LinuxCPUEntry()
        {
            SSHSecurityOption = SSHSecurityOption.Password;
            SSHPort = 22;
            UseOnlyTotalCPUvalue = true;
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
        public bool UseOnlyTotalCPUvalue { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public List<Linux.CPUInfo> GetCPUInfos()
        {
            List<Linux.CPUInfo> cpus = new List<Linux.CPUInfo>();
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, Password, PrivateKeyFile, PassPhrase);

            if (sshClient.IsConnected)
            {
                foreach (Linux.CPUInfo ci in Linux.CPUInfo.GetCurrentCPUPerc(sshClient))
                {
                    if (UseOnlyTotalCPUvalue && ci.IsTotalCPU)
                        cpus.Add(ci);
                    else if (!UseOnlyTotalCPUvalue)
                        cpus.Add(ci);
                }
            }
            sshClient.Disconnect();

            return cpus;
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
                return string.Format("{0}:{1} ({2})", MachineName, SSHPort, UseOnlyTotalCPUvalue ? "Total" : "All Cores/CPUs" );
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
