using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //private MonitorPack monitorPack;
        private List<MonitorPack> packs = new List<MonitorPack>();
        private string serviceEventSource = "QuickMon Service";

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

            if (Properties.Settings.Default.MonitorPackPaths != null && Properties.Settings.Default.MonitorPackPaths.Count > 0)
            {
                foreach (string monitorPackPath in Properties.Settings.Default.MonitorPackPaths)
                {
                    if (System.IO.File.Exists(monitorPackPath))
                        AddAndStartMonitorPack(monitorPackPath);
                }
            }
            else
            {
                if (System.IO.File.Exists(Properties.Settings.Default.MonitorPackPath))
                    AddAndStartMonitorPack(Properties.Settings.Default.MonitorPackPath);
                else
                    throw new Exception("MonitorPack path not specified!");
            }
            EventLog.WriteEntry(serviceEventSource, string.Format("Started QuickMon monitoring and alerting service with '{0}' monitor pack(s)", packs.Count), EventLogEntryType.Information, 0);
        }

        private void AddAndStartMonitorPack(string monitorPackPath)
        {
            try
            {
                StringBuilder sbNotifiers = new StringBuilder();
                MonitorPack monitorPack = new MonitorPack();
                EventLog.WriteEntry(serviceEventSource, string.Format("Starting QuickMon MonitorPack '{0}'", monitorPackPath), EventLogEntryType.Information, 0);
                monitorPack.Load(monitorPackPath);
                if (monitorPack.Notifiers != null && monitorPack.Notifiers.Count > 0)
                {
                    foreach (var notifier in monitorPack.Notifiers)
                        sbNotifiers.AppendLine("\t" + notifier.Name);
                }
                EventLog.WriteEntry(serviceEventSource, string.Format("MonitorPack {0} has the following notifiers\r\n{1}", monitorPack.Name, sbNotifiers.ToString()), EventLogEntryType.Information, 0);
                monitorPack.RaiseNotifierError += new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                monitorPack.RaiseCollectorError += new RaiseCollectorErrorDelegare(monitorPack_RaiseCollectorError);
                monitorPack.PollingFreq = Properties.Settings.Default.PollingFreqSec * 1000;
                packs.Add(monitorPack);
                monitorPack.StartPolling();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Error loading/starting MonitorPack '{0}'\r\n{1}", monitorPackPath, ex.Message), EventLogEntryType.Error, 11);
            }
        }
        protected override void OnStop()
        {
            foreach(MonitorPack monitorPack in packs)
                monitorPack.IsPolling = false;
        }
        protected override void OnPause()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.IsPolling = false;
            base.OnPause();
        }
        protected override void OnContinue()
        {
            foreach (MonitorPack monitorPack in packs)
                monitorPack.StartPolling();
            base.OnContinue();
        }

        private void monitorPack_RaiseCollectorError(CollectorEntry collector, string errorMessage)
        {
            EventLog.WriteEntry(serviceEventSource, string.Format("Collector error\r\n" + 
                "Collector name: {0}\r\n" +
                "Last details: {1}\r\n" +
                "Error details: {2}", collector.Name, collector.LastMonitorDetails, errorMessage), EventLogEntryType.Error, 2);
        }         
        private void monitorPack_RaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            EventLog.WriteEntry(serviceEventSource, string.Format("There was a problem recording an alert with notifier {0}\r\n{1}", notifier.Name, errorMessage), EventLogEntryType.Error, 1);
        }
    }
}
