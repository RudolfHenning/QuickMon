using HenIT.Services;
using System;
using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;

namespace QuickMon
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (Properties.Settings.Default.NewVersion)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NewVersion = false;
                Properties.Settings.Default.Save();
            }

            if (args.Length > 0)
            {
                string serviceParameters = "";
                string serviceName = Globals.ServiceEventSourceName;
                string displayName = Globals.ServiceEventSourceName;
                string instanceName = "";
                if (args.Length > 1)
                {
                    instanceName = args[1];
                    serviceName = Globals.ServiceEventSourceName + " - " + instanceName;
                }
                if (args[0].ToUpper() == "-?" || args[0].ToUpper() == "-H" || args[0].ToUpper() == "-HELP")
                {
                    System.Windows.Forms.MessageBox.Show("Usage: QuickMonSevice.exe -[action] [Instance name] [DisplayName] [Description]\r\n"+
                        "Where [action] is one of:\r\n"+
                        " -status : Display current service status\r\n" +
                        " -start: Start service/instance\r\n" + 
                        " -stop: Stop service/instance\r\n" + 
                        " -install: install service/instance\r\n" +
                        " -uninstall: uninstall service/instance\r\n" +
                        "Note :[DisplayName] and [Description] are only used for -install option"
                    , "Command line options", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }
                if (args[0].ToUpper() == "-STATUS")
                {
                    ShowServiceStatus(serviceName);
                    return;
                }
                if (args[0].ToUpper() == "-START")
                {
                    StartService(serviceName);
                    return;
                }
                if (args[0].ToUpper() == "-STOP")
                {
                    StopService(serviceName);
                    return;
                }
                if (args[0].ToUpper() == "-RESTART")
                {
                    ReStartService(serviceName);
                    return;
                }

                if (args[0].ToUpper() == "-INSTALL")
                {                    
                    string description = Globals.ServiceDescription;
                    if (args.Length > 1)
                    {                        
                        displayName = Globals.ServiceEventSourceName + " - " + instanceName;
                        serviceParameters = "\"-Instance:" + instanceName + "\"";
                    }
                    if (args.Length > 2)
                        displayName = args[2];
                    if (args.Length > 3)
                        description = args[3];

                    ServiceRegister.InstallService(
                        System.Reflection.Assembly.GetExecutingAssembly().Location,
                        serviceName,
                        displayName,
                        description,
                        serviceParameters);
                    return;
                }
                else if (args[0].ToUpper() == "-UNINSTALL")
                {
                    ServiceRegister.UnInstallService(
                       System.Reflection.Assembly.GetExecutingAssembly().Location,
                       serviceName);
                    return;
                }
            }
            if (Properties.Settings.Default.AutoAddDefaultFireWallException)
            {
                if (!CheckQuickMonRemoteHostFirewallPort())
                {
                    AddDefaultFireWallException();
                }
            }

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new QuickMonService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
        
        private static void ShowServiceStatus(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            if (sc != null)
            {
                try
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Service: {0}\r\nCurrent Status: {1}", sc.DisplayName, sc.Status), "Status", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Service: {0}\r\nCurrent Status: {1}", serviceName, ex.Message), "Status", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Service: {0}\r\nCurrent Status: Service not found!", serviceName), "Status", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private static void ReStartService(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            if (sc != null)
            {
                try
                {
                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
                    }

                    sc.Start();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Error restarting the service {0}\r\n{1}", serviceName, ex.Message), "Restart", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
        }

        private static void StartService(string serviceName)
        {
             ServiceController sc = new ServiceController(serviceName);
             if (sc != null)
             {
                 try
                 {
                     sc.Start();
                 }
                 catch (Exception ex)
                 {
                     System.Windows.Forms.MessageBox.Show(string.Format("Error starting the service {0}\r\n{1}", serviceName, ex.Message), "Start", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                 }
             }
        }

        private static void StopService(string serviceName)
        {
            ServiceController sc = new ServiceController(serviceName);
            if (sc != null)
            {
                try
                {
                    sc.Stop();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("Error stopping the service {0}\r\n{1}", serviceName, ex.Message), "Stop", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
        }

        private static bool CheckQuickMonRemoteHostFirewallPort()
        {
            bool isFWRuleInstalled = false;
            try
            {
                Microsoft.Win32.RegistryKey fwrules = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\SharedAccess\Parameters\FirewallPolicy\FirewallRules");
                object regVal = fwrules.GetValue("{F811AB2E-286C-4DB6-8512-4C991A8A55EA}");
                if (regVal != null)
                {
                    string quickMonRule = regVal.ToString();
                    if (quickMonRule.Length > 0)
                        isFWRuleInstalled = true;
                }
            }
            catch { }
            return isFWRuleInstalled;
        }
        private static void AddDefaultFireWallException()
        {
            string regfile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "QuickMon5FirewallRule.reg");
            try
            {
                if (System.IO.File.Exists(regfile))
                    System.IO.File.Delete(regfile);
                System.IO.File.WriteAllText(regfile, Properties.Resources.FireWallRule);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new System.Diagnostics.ProcessStartInfo();
                p.StartInfo.FileName = "REGEDIT.EXE";
                p.StartInfo.Arguments = "/S " + regfile;
                p.StartInfo.Verb = "runas";
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                }
                System.Diagnostics.EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("QuickMon 5 firewall rule (QuickMon 5 Remote Host) has been added. You might have to restart the firewall service for the change to take effect"), System.Diagnostics.EventLogEntryType.Warning, 0);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Error adding default QuickMon 5 fire wall exception: {0}", ex.Message), System.Diagnostics.EventLogEntryType.Warning, 0);
            }
        }

    }
}
