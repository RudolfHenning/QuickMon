using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    public class CollectorEntryRelay : ICollectorEntryRelay
    {
        #region Static methods
        public static MonitorState GetRemoteAgentState(CollectorEntry entry)
        {
            return GetRemoteAgentState(entry, entry.RemoteAgentHostAddress, entry.RemoteAgentHostPort);
        }
        public static MonitorState GetRemoteAgentState(CollectorEntry entry, string hostAddressOverride, int portNumberOverride)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QMRemoteAgent", hostAddressOverride, portNumberOverride));
            ChannelFactory<ICollectorEntryRelay> myChannelFactory = new ChannelFactory<ICollectorEntryRelay>(myBinding, myEndpoint);
            ICollectorEntryRelay relay = myChannelFactory.CreateChannel();

            CollectorEntryRequest colReq = new CollectorEntryRequest();
            colReq.FromCollectorEntry(entry);
            colReq.ParentCollectorId = ""; //Since this mechanism do no support nested collectors
            return relay.GetState(colReq);
        }
        public static string GetRemoteAgentHostVersion(string hostAddress, int portNumber)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QMRemoteAgent", hostAddress, portNumber));
            ChannelFactory<ICollectorEntryRelay> myChannelFactory = new ChannelFactory<ICollectorEntryRelay>(myBinding, myEndpoint);
            ICollectorEntryRelay relay = myChannelFactory.CreateChannel();
            return relay.GetQuickMonCoreVersion();
        }

        public static System.Data.DataSet GetRemoteHostAgentDetails(CollectorEntry entry)
        {
            return GetRemoteHostAgentDetails(entry, entry.RemoteAgentHostAddress, entry.RemoteAgentHostPort);
        }
        public static System.Data.DataSet GetRemoteHostAgentDetails(CollectorEntry entry, string hostAddressOverride, int portNumberOverride)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QMRemoteAgent", hostAddressOverride, portNumberOverride));
            ChannelFactory<ICollectorEntryRelay> myChannelFactory = new ChannelFactory<ICollectorEntryRelay>(myBinding, myEndpoint);
            ICollectorEntryRelay relay = myChannelFactory.CreateChannel();

            CollectorEntryRequest colReq = new CollectorEntryRequest();
            colReq.FromCollectorEntry(entry);
            colReq.ParentCollectorId = ""; //Since this mechanism do no support nested collectors
            return relay.GetDetails(colReq);
        } 
        #endregion

        #region ICollectorEntryRelay Members
        public string GetQuickMonCoreVersion()
        {
            string versionInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Console.WriteLine("Version request response: {0}", versionInfo);
            return versionInfo;
        }
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

                //there is only one...Collector
                CollectorEntry ce = (from c in m.Collectors
                                     select c).FirstOrDefault();
                if (ce != null) //Just is case it is null
                {
                    plainTextDetails.AppendLine(string.Format("Collector: {0}, State: {1}", ce.Name, ce.CurrentState.State));
                    htmlTextTextDetails.AppendLine(string.Format("<p>Collector: {0}, State: {1}</p>", ce.Name, ce.CurrentState.State));
                    if (ce.CurrentState.RawDetails != null && ce.CurrentState.RawDetails.Length > 0)
                        plainTextDetails.AppendLine(string.Format(" Details: {0}", ce.CurrentState.RawDetails.Trim('\r','\n').Replace("\t", "  ")));
                    if (ce.CurrentState.HtmlDetails != null && ce.CurrentState.HtmlDetails.Length > 0)
                        htmlTextTextDetails.AppendLine(string.Format("<blockquote>Details: {0}</blockquote>", ce.CurrentState.HtmlDetails));
                }
                else
                {
                    plainTextDetails.AppendLine(string.Format("Collector: {0}, State: N/A", ce.Name));
                    htmlTextTextDetails.AppendLine(string.Format("<p><b>Collector</b>: {0}, State: N/A</p>", ce.Name));
                }
                monitorState.RawDetails = plainTextDetails.ToString();
                monitorState.HtmlDetails = htmlTextTextDetails.ToString();
                Console.WriteLine(" State   : {0}", monitorState.State);
                Console.WriteLine(" Details : {0}", monitorState.RawDetails);
            }
            catch(Exception ex)
            {
                Console.WriteLine(" Error: {0}", ex);
                monitorState.State = CollectorState.Error;
                monitorState.RawDetails = ex.ToString();
            }
            return monitorState;
        }
        public System.Data.DataSet GetDetails(CollectorEntryRequest entry)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            System.Data.DataTable dt = new System.Data.DataTable("Test");
            dt.Columns.Add(new System.Data.DataColumn("Name", typeof(string)));
            dt.Columns.Add(new System.Data.DataColumn("Value", typeof(int)));
            dt.Rows.Add("Test", 1);
            ds.Tables.Add(dt);
            Console.WriteLine("DataSet response: {0} rows", ds.Tables[0].Rows.Count);
            return ds;
        }
        #endregion
    }
}
