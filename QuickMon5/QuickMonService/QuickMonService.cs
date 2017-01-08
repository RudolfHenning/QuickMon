using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace QuickMon
{
    public partial class QuickMonService : ServiceBase
    {
        public QuickMonService()
        {
            InitializeComponent();
        }

        private List<MonitorPack> packs = new List<MonitorPack>();
        public ServiceHost wcfServiceHost = null;
        private Uri baseAddress = new Uri(Properties.Settings.Default.WcfServiceURL);
        private int concurrencyLevel = 10;

        #region Performance Counter Vars
        private PerformanceCounter monitorPacksLoaded = null;
        private PerformanceCounter collectionExecutionTimePerSec = null;
        #endregion

        #region Service events
        protected override void OnStart(string[] args)
        {
            #region Provide way to attach debugger by Waiting for specified time
#if DEBUG
            //The following code is simply to ease attaching the debugger to the service to debug the startup routine
            DateTime startTime = DateTime.Now;
            while ((!Debugger.IsAttached) && ((TimeSpan)DateTime.Now.Subtract(startTime)).TotalSeconds < 20)  // Waiting until debugger is attached
            {
                RequestAdditionalTime(1000);  // Prevents the service from timeout
                Thread.Sleep(1000);           // Gives you time to attach the debugger   
            }
            // increase as needed to prevent timeouts
            RequestAdditionalTime(5000);     // for Debugging the OnStart method,     
#endif
            #endregion

            InitializeGlobalPerformanceCounters();
            concurrencyLevel = Properties.Settings.Default.ParralelThreads;
            int monitorPacksLoaded = 0;
            string monitorPackFile = "";


            //New way is to list them in an external file
            if (Properties.Settings.Default.MonitorPackFile != null && Properties.Settings.Default.MonitorPackFile.Length > 0)
            {
                monitorPackFile = Properties.Settings.Default.MonitorPackFile;
                if (!monitorPackFile.Contains("\\"))
                    monitorPackFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), monitorPackFile);
                if (System.IO.File.Exists(monitorPackFile))
                {
                    foreach(string monitorPackPath in System.IO.File.ReadAllLines(monitorPackFile))
                    {
                        if (System.IO.File.Exists(monitorPackPath))
                        {
                            AddAndStartMonitorPack(monitorPackPath);
                            monitorPacksLoaded++;
                        }
                    }
                }
            }
            if (monitorPacksLoaded == 0)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, "No (valid) monitor pack specified in service config! This service will only operate as a Remote Agent. To hide this warning please add some MonitorPacks in MonitorPackList.txt (default)",
                    EventLogEntryType.Warning, 0);
            }
            else
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Started QuickMon Service with {0} monitor pack(s).",
                    packs.Count), EventLogEntryType.Information, (int)QuickMonServiceEventIDs.General);
            }

            EventLog.WriteEntry(Globals.ServiceEventSourceName,
                string.Format("Started QuickMon monitoring and alerting service.\r\nService version: {0}\r\nShared components version: {1}\r\nConcurrency level: {2}",
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                    System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString(),
                    concurrencyLevel
                    ),
                EventLogEntryType.Information, (int)QuickMonServiceEventIDs.General);

            if (Properties.Settings.Default.EnableRemoteHost)
            {
                if (wcfServiceHost != null)
                {
                    wcfServiceHost.Close();
                }
                
                if (Properties.Settings.Default.WcfRenameLocalHostNameToRealHost)
                {
                    if (Properties.Settings.Default.WcfServiceURL.Contains("localhost"))
                        baseAddress = new Uri(Properties.Settings.Default.WcfServiceURL.Replace("localhost", System.Net.Dns.GetHostName()));
                }
                EventLog.WriteEntry(Globals.ServiceEventSourceName, "Starting Remote Collector Host service for : " + baseAddress.OriginalString, EventLogEntryType.Information, (int)QuickMonServiceEventIDs.General);
                wcfServiceHost = new ServiceHost(typeof(RemoteCollectorHostService), baseAddress);
                if (Properties.Settings.Default.WcfEnableMetadata)
                {
                    // Enable metadata publishing.
                    System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = System.ServiceModel.Description.PolicyVersion.Policy15;
                    wcfServiceHost.Description.Behaviors.Add(smb);
                }
                System.ServiceModel.Description.ServiceEndpoint endpoint = wcfServiceHost.AddServiceEndpoint(typeof(IRemoteCollectorHostService), new BasicHttpBinding(), baseAddress);
                List<string> blockedCollectorAgentTypes = new List<string>();
                if (Properties.Settings.Default.BlockedCollectorAgentTypes != null)
                {
                    foreach (string s in Properties.Settings.Default.BlockedCollectorAgentTypes)
                        blockedCollectorAgentTypes.Add(s);
                }                
                endpoint.Behaviors.Add(
                    new RemoteCollectorHostServiceInstanceProvider(
                        Properties.Settings.Default.ApplicationMasterKey, 
                        Properties.Settings.Default.ApplicationUserNameCacheFilePath,
                        blockedCollectorAgentTypes,
                        monitorPackFile)
                );
                wcfServiceHost.Open();
            }
        }
        protected override void OnStop()
        {
            foreach (MonitorPack monitorPack in packs)
            {
                monitorPack.IsPollingEnabled = false;
                monitorPack.CloseMonitorPack();
            }
            if (wcfServiceHost != null)
            {
                wcfServiceHost.Close();
            }
            ClosePerformanceCounters();
        }
        protected override void OnPause()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.IsPollingEnabled = false;
            if (wcfServiceHost != null)
            {
                wcfServiceHost.Close();
            }
            base.OnPause();
        }
        protected override void OnContinue()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.StartPolling();
            if (Properties.Settings.Default.EnableRemoteHost)
            {
                if (wcfServiceHost != null)
                {
                    wcfServiceHost.Close();
                }
                wcfServiceHost = new ServiceHost(typeof(RemoteCollectorHostService), baseAddress);
                if (Properties.Settings.Default.WcfEnableMetadata)
                {
                    // Enable metadata publishing.
                    System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = System.ServiceModel.Description.PolicyVersion.Policy15;
                    wcfServiceHost.Description.Behaviors.Add(smb);
                    wcfServiceHost.AddServiceEndpoint(typeof(IRemoteCollectorHostService), new BasicHttpBinding(), baseAddress);
                }
                wcfServiceHost.Open();
            }
            base.OnContinue();
        } 
        #endregion

        #region Private methods
        private void AddAndStartMonitorPack(string monitorPackPath)
        {
            try
            {
                StringBuilder sbNotifiers = new StringBuilder();
                MonitorPack monitorPack = new MonitorPack();
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Starting QuickMon MonitorPack '{0}'", monitorPackPath), EventLogEntryType.Information, (int)QuickMonServiceEventIDs.MonitorPack);
                monitorPack.Load(monitorPackPath);
                monitorPack.ApplicationUserNameCacheMasterKey = Properties.Settings.Default.ApplicationMasterKey;
                monitorPack.ApplicationUserNameCacheFilePath = Properties.Settings.Default.ApplicationUserNameCacheFilePath;
                monitorPack.CollectorStateHistorySize = 0; //For service history is always disabled!!
                if (monitorPack.NotifierHosts != null && monitorPack.NotifierHosts.Count > 0)
                {
                    foreach (var notifier in monitorPack.NotifierHosts)
                        sbNotifiers.AppendLine("\t" + notifier.Name);
                }
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("MonitorPack '{0}' has the following notifiers\r\n{1}", monitorPack.Name, sbNotifiers.ToString()), EventLogEntryType.Information, (int)QuickMonServiceEventIDs.MonitorPack);
                monitorPack.OnNotifierError += new NotifierHostWithMessageDelegate(monitorPack_NotifierError);
                monitorPack.OnCollectorError += new CollectorHostWithMessageDelegate(monitorPack_RaiseCollectorError);
                monitorPack.CollectorHostAllAgentsExecutionTime += new CollectorHostExecutionTimeDelegate(monitorPack_CollectorHostAllAgentsExecutionTime);
                monitorPack.CollectorHostRestorationScriptExecuted += MonitorPack_CollectorHostRestorationScriptExecuted;
                monitorPack.CollectorHostRestorationScriptFailed += MonitorPack_CollectorHostRestorationScriptFailed;
                monitorPack.CollectorHostWarningCorrectiveScriptExecuted += MonitorPack_CollectorHostWarningCorrectiveScriptExecuted;
                monitorPack.CollectorHostWarningCorrectiveScriptFailed += MonitorPack_CollectorHostWarningCorrectiveScriptFailed;
                monitorPack.CollectorHostErrorCorrectiveScriptExecuted += MonitorPack_CollectorHostErrorCorrectiveScriptExecuted;
                monitorPack.CollectorHostErrorCorrectiveScriptFailed += MonitorPack_CollectorHostErrorCorrectiveScriptFailed;
                monitorPack.MonitorPackEventReported += monitorPack_MonitorPackEventReported;
                monitorPack.PollingFreq = Properties.Settings.Default.PollingFreqSec * 1000;
                monitorPack.ConcurrencyLevel = concurrencyLevel;
                monitorPack.RunningAttended = AttendedOption.OnlyUnAttended;
                packs.Add(monitorPack);
                monitorPack.StartPolling();
                PCSetMonitorPacksLoaded(packs.Count);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Error loading/starting MonitorPack '{0}'\r\n{1}", monitorPackPath, ex.Message), EventLogEntryType.Error, (int)QuickMonServiceEventIDs.MonitorPack);
            }
        }
        #endregion

        #region Monitor pack events
        private void monitorPack_RaiseCollectorError(CollectorHost collectorHost, string errorMessage)
        {
            string lastCollectorDetails = "N/A";
            if (collectorHost != null && collectorHost.CurrentState != null)
                lastCollectorDetails = collectorHost.CurrentState.ReadAllRawDetails();

            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Collector error\r\n" +
                "Collector name: {0}\r\n" +
                "Last details: {1}\r\n" +
                "Error details: {2}", collectorHost.Name, lastCollectorDetails, errorMessage), EventLogEntryType.Error, 2);
        }
        private void monitorPack_NotifierError(NotifierHost notifier, string errorMessage)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("There was a problem recording an alert with notifier {0}\r\n{1}", notifier.Name, errorMessage), EventLogEntryType.Error, 1);
        }
        private void monitorPack_CollectorHostAllAgentsExecutionTime(CollectorHost collectorHost, long msTime)
        {
            PCRaiseCollectorExecutionTime(msTime);
        }
        private void MonitorPack_CollectorHostRestorationScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("The restoration script '{0}' for collector '{1}' ran successfully.", scriptName, collectorHost.Name)
                        , EventLogEntryType.Information, (int)QuickMonServiceEventIDs.RestorationScript);
        }
        private void MonitorPack_CollectorHostRestorationScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Restoration script '{0}' for collector '{1}' failed to run!: {2}", scriptName, collectorHost.Name, errorMsg)
                        , EventLogEntryType.Error, (int)QuickMonServiceEventIDs.RestorationScript);
        }
        private void MonitorPack_CollectorHostWarningCorrectiveScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("The (Warning) corrective script '{0}' for collector '{1}' ran successfully.", scriptName, collectorHost.Name)
                        , EventLogEntryType.Information, (int)QuickMonServiceEventIDs.WarningCorrectiveScript);
        }
        private void MonitorPack_CollectorHostWarningCorrectiveScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("The (Warning) corrective script '{0}' for collector '{1}' failed to run!: {2}", scriptName, collectorHost.Name, errorMsg)
                        , EventLogEntryType.Error, (int)QuickMonServiceEventIDs.WarningCorrectiveScript);
        }
        private void MonitorPack_CollectorHostErrorCorrectiveScriptExecuted(CollectorHost collectorHost, string scriptName)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("The (Error) corrective script '{0}' for collector '{1}' ran successfully.", scriptName, collectorHost.Name)
                        , EventLogEntryType.Information, (int)QuickMonServiceEventIDs.ErrorCorrectiveScript);
        }
        private void MonitorPack_CollectorHostErrorCorrectiveScriptFailed(CollectorHost collectorHost, string scriptName, string errorMsg)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("The (Error) corrective script '{0}' for collector '{1}' failed to run!: {2}", scriptName, collectorHost.Name, errorMsg)
                   , EventLogEntryType.Error, (int)QuickMonServiceEventIDs.ErrorCorrectiveScript);
        }
        //private void monitorPack_RunCollectorCorrectiveWarningScript(CollectorHost collector)
        //{
        //    try
        //    {
        //        if (collector != null &&
        //            System.IO.File.Exists(collector.CorrectiveScriptOnWarningPath))
        //        {
        //            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Running the corrective script '{0}' for collector '{1}'", collector.CorrectiveScriptOnWarningPath, collector.Name)
        //                , EventLogEntryType.Information, 21);
        //            RunCorrectiveScript(collector.CorrectiveScriptOnWarningPath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(Globals.ServiceEventSourceName, "Corrective script error(Warning):" + ex.Message, EventLogEntryType.Error, 23);
        //    }
        //}
        //private void monitorPack_RunCollectorCorrectiveErrorScript(CollectorHost collector)
        //{
        //    try
        //    {
        //        if (collector != null &&
        //            System.IO.File.Exists(collector.CorrectiveScriptOnErrorPath))
        //        {
        //            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Running the corrective script '{0}' for collector '{1}'", collector.CorrectiveScriptOnWarningPath, collector.Name)
        //                , EventLogEntryType.Information, 22);
        //            RunCorrectiveScript(collector.CorrectiveScriptOnErrorPath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(Globals.ServiceEventSourceName, "Corrective script error:" + ex.Message, EventLogEntryType.Error, 24);
        //    }
        //}
        //private void monitorPack_RunRestorationScript(CollectorHost collector)
        //{
        //    try
        //    {
        //        if (collector != null &&
        //            System.IO.File.Exists(collector.RestorationScriptPath))
        //        {
        //            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Running the restoration script '{0}' for collector '{1}'", collector.RestorationScriptPath, collector.Name)
        //                , EventLogEntryType.Information, 22);
        //            RunCorrectiveScript(collector.RestorationScriptPath);                    
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLog.WriteEntry(Globals.ServiceEventSourceName, "Corrective script error:" + ex.Message, EventLogEntryType.Error, 24);
        //    }
        //}
        //private void RunCorrectiveScript(string scriptPath)
        //{
        //    try
        //    {
        //        if (scriptPath.Contains("%"))
        //        {
        //            scriptPath = Environment.ExpandEnvironmentVariables(scriptPath);
        //        }
        //        if (scriptPath.ToLower().Contains(".ps1"))
        //        {
        //            RunPSScript(scriptPath);
        //        }
        //        else
        //        {
        //            string commandStr = scriptPath;
        //            string parameters = "";
        //            Process p = new Process();

        //            if (!System.IO.File.Exists(scriptPath) && scriptPath.Contains(" "))
        //            {
        //                if (scriptPath.StartsWith("\"") && scriptPath.Substring(1).Contains("\""))
        //                {
        //                    commandStr = scriptPath.Substring(1, scriptPath.IndexOf('"', 1) - 1);
        //                    parameters = scriptPath.Substring(scriptPath.IndexOf('"', 1) + 1).Trim();
        //                }
        //                else
        //                {
        //                    commandStr = scriptPath.Substring(0, scriptPath.IndexOf(' '));
        //                    parameters = scriptPath.Substring(scriptPath.IndexOf(' ') + 1).Trim();
        //                }
        //            }

        //            p.StartInfo = new ProcessStartInfo(commandStr, parameters);
        //            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        //            p.Start();
        //        }
        //    }
        //    catch (Exception ex)
        //    {            
        //        EventLog.WriteEntry(Globals.ServiceEventSourceName, "Corrective script error:" + ex.Message, EventLogEntryType.Error, 24);
        //    }
        //}
        private void monitorPack_MonitorPackEventReported(string message)
        {
            try
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, message, EventLogEntryType.Information, 5);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, "Event Reported error:" + ex.Message, EventLogEntryType.Error, 24);
            }
        }

        #region PowerShell Runner
        /// <summary>
        /// Run PowerShell script. Cannot use System.Management.Automation as it may not be installed on older systems.
        /// </summary>
        /// <param name="testScript"></param>
        /// <returns></returns>
        private void RunPSScript(string testScript)
        {
            string psExe = System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\system32\\WindowsPowerShell\\v1.0\\powershell.exe";
            if (System.IO.File.Exists(psExe))
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(psExe);
                p.StartInfo.Arguments = testScript;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
            else
            {
                throw new Exception("PowerShell not found! It may not be installed on this computer.");
            }
        }
        #endregion
        #endregion

        #region Performance counters
        private void InitializeGlobalPerformanceCounters()
        {
            try
            {
                CounterCreationData[] quickMonCreationData = new CounterCreationData[]
                    {
                        new CounterCreationData("Monitor Packs Loaded", "Monitor Packs Loaded", PerformanceCounterType.NumberOfItems32),
                        new CounterCreationData("Collector execution time/Sec", "Collector executiontime per second", PerformanceCounterType.RateOfCountsPerSecond32)
                    };

                if (PerformanceCounterCategory.Exists(Globals.ServiceEventSourceName))
                {
                    PerformanceCounterCategory pcC = new PerformanceCounterCategory(Globals.ServiceEventSourceName);
                    if (pcC.GetCounters().Length != quickMonCreationData.Length)
                    {
                        PerformanceCounterCategory.Delete(Globals.ServiceEventSourceName);
                    }
                }

                if (!PerformanceCounterCategory.Exists(Globals.ServiceEventSourceName))
                {
                    PerformanceCounterCategory.Create(Globals.ServiceEventSourceName, Globals.ServiceEventSourceName, PerformanceCounterCategoryType.SingleInstance, new CounterCreationDataCollection(quickMonCreationData));
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Create global performance counters category error!: {0}", ex.Message), EventLogEntryType.Error, 10);
            }
            try
            {
                monitorPacksLoaded = InitializePerfCounterInstance(Globals.ServiceEventSourceName, "Monitor Packs Loaded");
                collectionExecutionTimePerSec = InitializePerfCounterInstance(Globals.ServiceEventSourceName, "Collector execution time/Sec");
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Initialize global performance counters error!: {0}", ex.Message), EventLogEntryType.Error, 10);
            }
        }
        public void ClosePerformanceCounters()
        {
            PCSetMonitorPacksLoaded(0);
            SetCounterValue(collectionExecutionTimePerSec, 0, "Collector execution time/Sec");
        }
        private PerformanceCounter InitializePerfCounterInstance(string categoryName, string counterName)
        {
            PerformanceCounter counter = new PerformanceCounter(categoryName, counterName, false);
            counter.BeginInit();
            counter.RawValue = 0;
            counter.EndInit();
            return counter;
        }
        private void SetCounterValue(PerformanceCounter counter, long value, string description)
        {
            try
            {
                if (counter == null)
                {
                    EventLog.WriteEntry(Globals.ServiceEventSourceName, "Performance counter not set up or installed! : " + description, EventLogEntryType.Warning, 11);
                }
                else
                {
                    counter.RawValue = value;
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()), EventLogEntryType.Error, 11);
            }
        }
        private void IncrementCounter(PerformanceCounter counter, string description, long incrementBy = 1)
        {
            try
            {
                if (counter == null)
                {
                    EventLog.WriteEntry(Globals.ServiceEventSourceName, "Performance counter not set up or installed! : " + description, EventLogEntryType.Warning, 11);
                }
                else
                {
                    counter.IncrementBy(incrementBy);
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Increment performance counter error! : {0}\r\n{1}", description, ex.ToString()), EventLogEntryType.Error, 11);
            }
        }

        private void PCSetMonitorPacksLoaded(long count)
        {
            SetCounterValue(monitorPacksLoaded, count, "Monitor Packs Loaded");
        }
        private void PCRaiseCollectorExecutionTime(long time)
        {
            IncrementCounter(collectionExecutionTimePerSec, "Collector successful states per second", time);
        }
        #endregion
    }
}
