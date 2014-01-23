using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace QuickMon
{
    public class CollectorRemoteHost
    {
        public CollectorRemoteHost()
        {
            portNumber = 8888;
        }
        public bool IsRunning { get; set; }
        public int portNumber { get; set; }

        public void StartHost()
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, "Starting QuickMon 3 Remote host process", EventLogEntryType.Information, 100);
            IsRunning = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(BackgroundPolling));
        }
        private void BackgroundPolling(object o)
        {
            try
            {
                CharonRelay charonRelay = new CharonRelay();
                charonRelay.InfoMessage += charonRelay_InfoMessage;
                charonRelay.ErrorMessage += charonRelay_ErrorMessage;
                charonRelay.DisplayMonitorPackName += charonRelay_DisplayMonitorPackName;
                string localHost = System.Net.Dns.GetHostName();
                charonRelay.StartRelay(localHost, portNumber);

                while (IsRunning)
                {
                    System.Threading.Thread.Sleep(3000);
                }
                EventLog.WriteEntry(Globals.ServiceEventSourceName, "Shutting down QuickMon 3 Remote host process", EventLogEntryType.Information, 100);
            }
            catch(Exception ex)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, ex.Message, EventLogEntryType.Error, 100);
            }
        }

        private void charonRelay_DisplayMonitorPackName(string name)
        {
            if (Properties.Settings.Default.RemoteHostDisplayExecutingPackNames)
            {
                EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("Executing the Monitor Pack '{0}'", name), EventLogEntryType.Information, 100);
            }
        }

        static void charonRelay_ErrorMessage(string message)
        {
            EventLog.WriteEntry(Globals.ServiceEventSourceName, string.Format("CollectorRemoteHost Error: '{0}", message), EventLogEntryType.Error, 100);
        }

        static void charonRelay_InfoMessage(string message)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("CollectorRemoteHost Error: '{0}", message));
        }
    }
}
