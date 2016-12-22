using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace QuickMon
{
    internal class ProjectInstallerForHelper : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller processInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;

        public ProjectInstallerForHelper(bool delayedAutoStart = true)
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            serviceInstaller.DelayedAutoStart = delayedAutoStart;

            Installers.AddRange(new Installer[] {
                    processInstaller,
                    serviceInstaller});
        }

        #region Added properties
        public string ServiceName
        {
            get { return serviceInstaller.ServiceName; }
            set { serviceInstaller.ServiceName = value; }
        }
        public string DisplayName
        {
            get { return serviceInstaller.DisplayName; }
            set { serviceInstaller.DisplayName = value; }
        }
        public string Description
        {
            get { return serviceInstaller.Description; }
            set { serviceInstaller.Description = value; }
        }
        public ServiceStartMode StartType
        {
            get { return serviceInstaller.StartType; }
            set { serviceInstaller.StartType = value; }
        }
        public ServiceAccount Account
        {
            get { return processInstaller.Account; }
            set { processInstaller.Account = value; }
        }
        public string ServiceUsername
        {
            get { return processInstaller.Username; }
            set { processInstaller.Username = value; }
        }
        public string ServicePassword
        {
            get { return processInstaller.Password; }
            set { processInstaller.Password = value; }
        }
        public bool DelayedAutoStart
        {
            get { return serviceInstaller.DelayedAutoStart; }
            set { serviceInstaller.DelayedAutoStart = value; }
        }
        #endregion
    }
}
