using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace QuickMon
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller processInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();
        }
        public ProjectInstaller(bool useCustomInstallers)
        {

            if (useCustomInstallers)
            {
                processInstaller = new ServiceProcessInstaller();
                serviceInstaller = new System.ServiceProcess.ServiceInstaller();

                Installers.AddRange(new Installer[] {
                    processInstaller,
                    serviceInstaller});
            }
            else
            {
                InitializeComponent();
            }
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
        #endregion
    }
}
