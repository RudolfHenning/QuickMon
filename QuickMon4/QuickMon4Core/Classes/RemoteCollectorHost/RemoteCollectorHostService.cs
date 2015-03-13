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
            StringBuilder consoleOutPut = new StringBuilder();
            MonitorState monitorState = new MonitorState();
            Console.WriteLine("{0}: Running collector host: {1}\r\n{2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name, new string('*', 79));
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
                consoleOutPut.AppendFormat("{0}: Results for collector host: {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);
                consoleOutPut.AppendFormat(" State   : {0}\r\n", monitorState.State);
                consoleOutPut.AppendFormat(" Details : {0}\r\n", monitorState.ReadAllRawDetails());                
            }
            catch (Exception ex)
            {
                consoleOutPut.AppendFormat(" Error: {0}\r\n", ex);
                monitorState.CurrentValue = ex.Message;
                monitorState.State = CollectorState.Error;
                monitorState.RawDetails = ex.ToString();
                monitorState.HtmlDetails= ex.ToString().EscapeXml();
            }
            consoleOutPut.AppendLine(new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());

            monitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
            return monitorState;
        }
        public string GetQuickMonCoreVersion()
        {
            StringBuilder consoleOutPut = new StringBuilder();
            string versionInfo = System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString();
            consoleOutPut.AppendFormat("Version request response: {0}\r\n", versionInfo);
            consoleOutPut.AppendLine(new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());
            return versionInfo;
        }
        public System.Data.DataSet GetCollectorHostDetails(QuickMon.RemoteCollectorHost entry)
        {
            StringBuilder consoleOutPut = new StringBuilder();
            System.Data.DataSet result = new System.Data.DataSet();
            try
            {
                Console.WriteLine("{0}: Getting collector host data set: {1}\r\n{2}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name, new string('*', 79));
                CollectorHost ch = CollectorHost.FromXml(entry.ToCollectorHostXml());
                result = ch.GetAllAgentDetails();
                consoleOutPut.AppendFormat("{0}: Results for collector host: {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);
                consoleOutPut.AppendFormat("  Data set request received: {0}\r\n", entry.Name);
                if (result != null)
                {
                    consoleOutPut.AppendFormat("   Tables: {0}\r\n", result.Tables.Count);
                    for(int i = 0; i < result.Tables.Count; i++)
                    {
                        consoleOutPut.AppendFormat("    Table[{0}]: {1} row(s)\r\n", i, result.Tables[i].Rows.Count);
                    }
                }
                else
                {
                    consoleOutPut.AppendFormat("  Warning! Data set is empty!\r\n");
                }
            }
            catch (Exception ex)
            {
                consoleOutPut.AppendFormat(" Error: {0}\r\n", ex);
                System.Data.DataTable dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
                result.Tables.Add(dt);                
            }
            consoleOutPut.AppendLine(new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());
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
            myBinding.MaxReceivedMessageSize = 2147483647;
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
