using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
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

        private MonitorPack monitorPack;
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

            monitorPack = new MonitorPack();
            if (System.IO.File.Exists(Properties.Settings.Default.MonitorPackPath))
            {
                EventLog.WriteEntry(serviceEventSource, string.Format("Starting QuickMon monitoring and alerting service using MonitorPack '{0}'", Properties.Settings.Default.MonitorPackPath), EventLogEntryType.Information, 0);
                monitorPack.Load(Properties.Settings.Default.MonitorPackPath);
                monitorPack.RaiseNotifierError += new RaiseNotifierErrorDelegare(monitorPack_RaiseNotifierError);
                monitorPack.RaiseCollectorError += new RaiseCollectorErrorDelegare(monitorPack_RaiseCollectorError);
                monitorPack.PollingFreq = Properties.Settings.Default.PollingFreqSec * 1000;
                monitorPack.StartPolling();
            }
            else
                throw new Exception("MonitorPack path not specified!");
        }
        protected override void OnStop()
        {
            monitorPack.IsPolling = false;
        }
        protected override void OnPause()
        {
            monitorPack.IsPolling = false;
            base.OnPause();
        }
        protected override void OnContinue()
        {
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
