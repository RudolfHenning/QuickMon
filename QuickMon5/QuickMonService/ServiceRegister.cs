using HenIT.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace QuickMon
{
    public static class ServiceRegister
    {
        public static bool InstallService(string serviceExePath,
                string serviceName,
                string displayName,
                string description,
                string serviceParameters)
        {
            bool success = false;
            try
            {
                string workingPath = System.IO.Path.GetDirectoryName(serviceExePath);
                string logPath = System.IO.Path.Combine(workingPath, "Install.log");
                ServiceStartMode startmode = ServiceStartMode.Automatic;
                ServiceAccount account = ServiceAccount.LocalService;
                string username = "";
                string password = "";
                bool delayedStart = true;

                InstallerForm installerForm = new InstallerForm();
                installerForm.StartType = ServiceStartMode.Automatic;
                installerForm.AccountType = ServiceAccount.User;
                installerForm.BringToFront();
                installerForm.TopMost = true;
                if (installerForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    startmode = installerForm.StartType;
                    account = installerForm.AccountType;
                    delayedStart = installerForm.DelayedStart;
                    if (installerForm.AccountType == ServiceAccount.User)
                    {
                        username = installerForm.UserName;
                        password = installerForm.Password;
                    }


                    Hashtable savedState = new Hashtable();
                    ProjectInstallerForHelper myProjectInstaller = new ProjectInstallerForHelper(delayedStart);
                    InstallContext myInstallContext = new InstallContext(logPath, new string[] { });
                    myProjectInstaller.Context = myInstallContext;
                    myProjectInstaller.ServiceName = serviceName;
                    myProjectInstaller.DisplayName = displayName;
                    myProjectInstaller.Description = description;
                    myProjectInstaller.StartType = startmode;
                    myProjectInstaller.Account = account;
                    myProjectInstaller.DelayedAutoStart = installerForm.DelayedStart;
                    if (account == ServiceAccount.User)
                    {
                        myProjectInstaller.ServiceUsername = username;
                        myProjectInstaller.ServicePassword = password;
                    }
                    myProjectInstaller.Context.Parameters["AssemblyPath"] = serviceExePath + " " + serviceParameters;

                    myProjectInstaller.Install(savedState);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Install service", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return success;
        }
        public static bool UnInstallService(string serviceExePath, string serviceName)
        {
            bool success = false;
            try
            {
                ServiceController sc = new ServiceController(serviceName);
                if (sc == null)
                {
                    System.Windows.Forms.MessageBox.Show("Service not installed or accessible!", "Stopping service", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    return true;
                }
                if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.Paused)
                {
                    sc.Stop();
                }
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("was not found on computer"))
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Stopping service", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                    return true;
            }
            try
            {
                string workingPath = System.IO.Path.GetDirectoryName(serviceExePath);
                string logPath = System.IO.Path.Combine(workingPath, "Install.log");

                ServiceInstaller myServiceInstaller = new ServiceInstaller();
                InstallContext Context = new InstallContext(logPath, null);
                myServiceInstaller.Context = Context;
                myServiceInstaller.ServiceName = serviceName;
                myServiceInstaller.Uninstall(null);
                success = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Uninstall service", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return success;
        }

    }
}
