using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            bool useBackgroundPolling = false;
            bool showManagement = false;
            bool reportOnlyStates = true;
            string currentPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            string registeredAgentsFile = currentPath + @"\RegisteredAgents.qmral";
            string pingAgentAssembly = currentPath + @"\QMPing.dll";
            string fileCountAgentAssembly = currentPath + @"\QMFileCount.dll";
            string serviceStateAgentAssembly = currentPath + @"\QMServiceState.dll";
            string bizTalkSuspendedCountAgentAssembly = currentPath + @"\QMBizTalkSuspendedCount.dll";
            string logFileAgentAssembly = currentPath + @"\QMLogFile.dll";
            string configurationFile = currentPath + @"\workConfig.qmconfig";

            MonitorPack monitorPack = new MonitorPack();

            #region Agent registrations
            try
            {
                monitorPack.AgentRegistrationFile = registeredAgentsFile;
            }
            catch
            {
                monitorPack.AgentRegistrations = new List<AgentRegistration>();
                monitorPack.AgentRegistrations.AddRange(new AgentRegistration[] 
                     { 
                         new AgentRegistration()
                         {
                            Name = "Ping",
                            AssemblyPath = pingAgentAssembly,
                            ClassName = "QuickMon.Ping",
                            IsCollector = true,
                            IsNotifier = false
                         },
                         new AgentRegistration()
                         {
                            Name = "FileCount",
                            AssemblyPath = fileCountAgentAssembly,
                            ClassName = "QuickMon.FileCount",
                            IsCollector = true,
                            IsNotifier = false
                         },
                         new AgentRegistration()
                         {
                            Name = "ServiceState",
                            AssemblyPath = serviceStateAgentAssembly,
                            ClassName = "QuickMon.ServiceState",
                            IsCollector = true,
                            IsNotifier = false
                         },
                         new AgentRegistration()
                         {
                            Name = "BizTalkSuspendedCount",
                            AssemblyPath = bizTalkSuspendedCountAgentAssembly,
                            ClassName = "QuickMon.BizTalkSuspendedCount",
                            IsCollector = true,
                            IsNotifier = false
                         },                         
                         new AgentRegistration()
                         {
                            Name = "LogFile",
                            AssemblyPath = logFileAgentAssembly,
                            ClassName = "QuickMon.LogFile",
                            IsCollector = false,
                            IsNotifier = true
                         }
                     }
                    );
                SerializationUtils.SerializeXMLToFile<List<AgentRegistration>>(registeredAgentsFile, monitorPack.AgentRegistrations);
            } 
            #endregion

            
            monitorPack.Load(configurationFile);

            if (useBackgroundPolling)
            {
                //monitorPack.RaiseAlert += new RaiseAlertDelegate(monitorPack_RaiseAlert);
                monitorPack.PollingFreq = 10000;
                monitorPack.StartPolling();
                Console.WriteLine("Press any key to stop polling");
                Console.ReadKey();
                monitorPack.IsPolling = false;
                Console.WriteLine("Done");
            }
            else if (showManagement)
            {
                Management.MonitorPackManagement monitorPackManagement = new Management.MonitorPackManagement();
                monitorPackManagement.ShowMonitorPack(monitorPack);
            }
            else if (reportOnlyStates)
            {
                ConsoleKeyInfo cki = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
                monitorPack.RaiseCurrentState += new RaiseCurrentStateDelegate(monitorPack_RaiseCurrentState);
                while (cki.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine(new string('-', 79));
                    MonitorStates globalState = monitorPack.RefreshStates();
                    Console.WriteLine("Global state: {0}", globalState);
                    Console.WriteLine("Last time: {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    Console.WriteLine(new string('-', 79));
                    Console.WriteLine("Press ESC to end");
                    cki = ConsoleHelper.ReadKeyWithTimeOut(20000);
                }
            }
            else
            {
                //monitorPack.RaiseAlert += new RaiseAlertDelegate(monitorPack_RaiseAlert);
                MonitorStates globalState = monitorPack.RefreshStates();
                Console.WriteLine(new string('-', 79));
                Console.WriteLine(string.Format("Current global state: {0}", globalState));
                string level = "  ";
                foreach (CollectorEntry ce in (from c in monitorPack.Collectors
                                               where c.ParentCollectorId.Length == 0
                                               select c))
                {
                    ShowCollectorEntryStatus(monitorPack.Collectors, ce, level);
                }
                Console.WriteLine("Press any key to continue or wait 30 seconds");
                ConsoleKeyInfo cki = ConsoleHelper.ReadKeyWithTimeOut(30000);
                if (cki.Key == ConsoleKey.S)
                    monitorPack.Save(currentPath + @"\Test.qmconfig");
            }
        }

        private static void ShowCollectorEntryStatus(List<CollectorEntry> collectors, CollectorEntry ce, string level)
        {
            Console.WriteLine("{0}{1} - {2}\r\n{0}   {3}", level, ce.Name, ce.LastMonitorState, ce.LastMonitorDetails.PlainText.Replace("\r\n", "\r\n   " + level));
            foreach (CollectorEntry childCollector in (from c in collectors
                                                       where c.ParentCollectorId == ce.UniqueId
                                                       select c))
            {
                ShowCollectorEntryStatus(collectors, childCollector, level + "  ");
            }
        }

        #region monitorPack events
        static void monitorPack_RaiseAlert(AlertLevel alertLevel, string message)
        {
            if (alertLevel != AlertLevel.Debug)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("Alert raised");
                Console.WriteLine("  Level  : {0}", alertLevel);
                Console.WriteLine("  Details: {0}", message);
                Console.WriteLine(new string('-', 79));
                Console.WriteLine("Press any key to stop polling");
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                System.Diagnostics.Trace.WriteLine("Alert raised");
                System.Diagnostics.Trace.WriteLine(string.Format("  Level  : {0}", alertLevel));
                System.Diagnostics.Trace.WriteLine(string.Format("  Details: {0}", message));
            }
        }
        static void monitorPack_RaiseCurrentState(CollectorEntry collector, MonitorStates currentState)
        {
            Console.WriteLine("{0} - {1}", collector.Name, currentState);
        } 
        #endregion
    }
}
