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

                    //InstallService();
                    return;
                }
                else if (args[0].ToUpper() == "-UNINSTALL")
                {
                    ServiceRegister.UnInstallService(
                       System.Reflection.Assembly.GetExecutingAssembly().Location,
                       serviceName);

                    //UnInstallService();
                    return;
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
    }
}
