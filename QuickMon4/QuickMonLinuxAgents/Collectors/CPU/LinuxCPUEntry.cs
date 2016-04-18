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
        public string PrivateKeyFile { get; set; }
        public string PassCodeOrPhrase { get; set; }
        public bool UseOnlyTotalCPUvalue { get; set; }
        public double WarningValue { get; set; }
        public double ErrorValue { get; set; }

        public List<Linux.CPUInfo> GetCPUInfos()
        {
            List<Linux.CPUInfo> cpus = new List<Linux.CPUInfo>();
            Renci.SshNet.SshClient sshClient = SshClientTools.GetSSHConnection(SSHSecurityOption, MachineName, SSHPort, UserName, PrivateKeyFile, PassCodeOrPhrase);

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

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { throw new NotImplementedException(); }
        }
        public string TriggerSummary
        {
            get { throw new NotImplementedException(); }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion
    }
}
