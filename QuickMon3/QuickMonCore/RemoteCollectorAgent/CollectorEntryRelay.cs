using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    public class CollectorEntryRelay : ICollectorEntryRelay
    {
        public static MonitorState GetRemoteAgentState(CollectorEntry entry)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QMRemoteAgent", entry.RemoteAgentHostAddress, entry.RemoteAgentHostPort));
            ChannelFactory<ICollectorEntryRelay> myChannelFactory = new ChannelFactory<ICollectorEntryRelay>(myBinding, myEndpoint);
            ICollectorEntryRelay relay = myChannelFactory.CreateChannel();

            CollectorEntryRequest colReq = new CollectorEntryRequest();
            colReq.FromCollectorEntry(entry);
            colReq.ParentCollectorId = ""; //Since this mechanism  do no support nested collectors
            return relay.GetState(colReq);
        }
        public static MonitorState GetRemoteAgentState(CollectorEntry entry, string hostAddressOverride, int portNumberOverride)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QMRemoteAgent", hostAddressOverride, portNumberOverride));
            ChannelFactory<ICollectorEntryRelay> myChannelFactory = new ChannelFactory<ICollectorEntryRelay>(myBinding, myEndpoint);
            ICollectorEntryRelay relay = myChannelFactory.CreateChannel();

            CollectorEntryRequest colReq = new CollectorEntryRequest();
            colReq.FromCollectorEntry(entry);
            colReq.ParentCollectorId = ""; //Since this mechanism  do no support nested collectors
            return relay.GetState(colReq);
        }

        #region ICollectorEntryRelay Members
        public MonitorState GetState(CollectorEntryRequest entry)
        {
            MonitorState monitorState = new MonitorState();
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();

            Console.WriteLine("{0}: Running collector: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);
            try
            {
                string tempMonitorPack = "<monitorPack version=\"3.0.0.0\" name=\"\" enabled=\"True\" defaultViewerNotifier=\"\" runCorrectiveScripts=\"False\"><collectorEntries>" +
                                entry.ToConfig() + "</collectorEntries><notifierEntries></notifierEntries></monitorPack>";
                MonitorPack m = new MonitorPack();
                m.LoadXml(tempMonitorPack);
                monitorState.State = m.RefreshStates();
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (CollectorEntry ce in (from c in m.Collectors
                                               where c.CurrentState != null
                                               select c))
                {
                    if (ce.CurrentState == null)
                    {
                        plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: N/A", ce.Name));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: N/A</li>", ce.Name));
                    }
                    else if (ce.CurrentState.State == CollectorState.Good)
                    {
                        plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: {1}", ce.Name, ce.CurrentState.State));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: {1}</li>", ce.Name, ce.CurrentState.State));
                    }
                    else
                    {
                        plainTextDetails.AppendLine(string.Format("\tCollector: {0}, State: {1}", ce.Name, ce.CurrentState.State));
                        if (ce.CurrentState.RawDetails != null && ce.CurrentState.RawDetails.Length > 0)
                            plainTextDetails.AppendLine(string.Format("\t\tDetails: {0}", ce.CurrentState.RawDetails.Replace("\r\n", "\r\n\t\t\t")));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Collector: {0}, State: {1}</li>", ce.Name, ce.CurrentState.State));
                        if (ce.CurrentState.HtmlDetails != null && ce.CurrentState.HtmlDetails.Length > 0)
                            htmlTextTextDetails.AppendLine(string.Format("<br/>Details: {0}", ce.CurrentState.HtmlDetails));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                monitorState.RawDetails = plainTextDetails.ToString();
                monitorState.HtmlDetails = htmlTextTextDetails.ToString();
                Console.WriteLine(" State   : {0}", monitorState.State);
                Console.WriteLine("  Details: {0}", monitorState.RawDetails);
            }
            catch(Exception ex)
            {
                Console.WriteLine(" Error: {0}", ex);
                monitorState.State = CollectorState.Error;
                monitorState.RawDetails = ex.ToString();
            }

            return monitorState;
        }
        #endregion
    }
}
