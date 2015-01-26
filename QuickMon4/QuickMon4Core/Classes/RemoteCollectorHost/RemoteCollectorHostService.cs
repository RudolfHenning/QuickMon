using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    public class RemoteCollectorHostService : IRemoteCollectorHostService
    {

        #region IRemoteCollectorHostService
        public MonitorState GetState(QuickMon.RemoteCollectorHost entry)
        {
            MonitorState monitorState = new MonitorState();
            Console.WriteLine("{0}: Running collector host: {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);
            try
            {
                string collectorHostConfig = entry.ToCollectorHostXml();
                string tempMonitorPack = "<monitorPack version=\"4.0.0.0\" name=\"\" typeName=\"\" enabled=\"True\" defaultNotifier=\"\" runCorrectiveScripts=\"False\" collectorStateHistorySize=\"1\" pollingFreqSecOverride=\"0\">" +
                        "<collectorHosts>" +
                       collectorHostConfig  +
                       "</collectorHosts>\r\n" +
                       "<notifierHosts>\r\n" +
                       "</notifierHosts>\r\n" +
                       "</monitorPack>";
                MonitorPack m = new MonitorPack();
                m.LoadXml(tempMonitorPack);
                if (m.CollectorHosts.Count == 1)
                {
                    m.RefreshStates();
                    //Since there is only one CollectorHost
                    CollectorHost ch = m.CollectorHosts[0];
                    monitorState = ch.CurrentState;                    
                }
                else
                {
                    monitorState.CurrentValue = "There was a problem loading the Collector Host config on the remote host!";
                    monitorState.RawDetails = collectorHostConfig;
                    monitorState.HtmlDetails= collectorHostConfig.EscapeXml();
                    monitorState.State = CollectorState.Error;
                }
                //If hosted in console test app
                Console.WriteLine(" State   : {0}", monitorState.State);
                Console.WriteLine(" Details : {0}", monitorState.RawDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: {0}", ex);
                monitorState.CurrentValue = ex.Message;
                monitorState.State = CollectorState.Error;
                monitorState.RawDetails = ex.ToString();
                monitorState.HtmlDetails= ex.ToString().EscapeXml();
            }
            monitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
            return monitorState;
        }
        public string GetQuickMonCoreVersion()
        {
            string versionInfo = System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString();
            Console.WriteLine("Version request response: {0}", versionInfo);
            return versionInfo;
        }
        public System.Data.DataSet GetCollectorHostDetails(QuickMon.RemoteCollectorHost entry)
        {
            System.Data.DataSet result = new System.Data.DataSet();
            try
            {
                CollectorHost ch = CollectorHost.FromXml(entry.ToCollectorHostXml());
                result = ch.GetAllAgentDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: {0}", ex);
                System.Data.DataTable dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
                result.Tables.Add(dt);                
            }
            return result;
        }
        //public System.Data.DataSet GetAgentDetails(string collectorAgentConfig)
        //{
        //    System.Data.DataSet result = new System.Data.DataSet();
        //    try
        //    {
        //        ICollector ca = CollectorHost.GetCollectorAgentFromString(collectorAgentConfig);
        //        foreach (System.Data.DataTable dt in ca.GetDetailDataTables())
        //            result.Tables.Add(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(" Error: {0}", ex);
        //        System.Data.DataTable dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //        result.Tables.Add(dt);
        //    }
        //    return result;
        //}
        #endregion

        #region Static methods
        public static MonitorState GetCollectorHostState(CollectorHost rh)
        {
            return GetCollectorHostState(rh, rh.RemoteAgentHostAddress, rh.RemoteAgentHostPort);
        }
        public static MonitorState GetCollectorHostState(CollectorHost entry, string hostAddressOverride, int portNumberOverride)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddressOverride, portNumberOverride));
            ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
            IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();

            RemoteCollectorHost colReq = new RemoteCollectorHost();
            colReq.FromCollectorHost(entry);
            return relay.GetState(colReq);
        }
        public static string GetRemoteAgentHostVersion(string hostAddress, int portNumber)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddress, portNumber));
            ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
            IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();
            return relay.GetQuickMonCoreVersion();
        }
        public static System.Data.DataSet GetRemoteHostAllAgentDetails(CollectorHost entry)
        {
            return GetRemoteHostAllAgentDetails(entry, entry.RemoteAgentHostAddress, entry.RemoteAgentHostPort);
        }
        public static System.Data.DataSet GetRemoteHostAllAgentDetails(CollectorHost entry, string hostAddressOverride, int portNumberOverride)
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddressOverride, portNumberOverride));
            ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
            IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();

            RemoteCollectorHost colReq = new RemoteCollectorHost();
            colReq.FromCollectorHost(entry);
            return relay.GetCollectorHostDetails(colReq);
        } 
        //public static System.Data.DataSet GetRemoteHostAgentDetails(string collectorAgentConfig, string hostAddressOverride, int portNumberOverride)
        //{
        //    BasicHttpBinding myBinding = new BasicHttpBinding();
        //    EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddressOverride, portNumberOverride));
        //    ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
        //    IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();
        //    return relay.GetAgentDetails(collectorAgentConfig);
        //}
        #endregion
    }
}
