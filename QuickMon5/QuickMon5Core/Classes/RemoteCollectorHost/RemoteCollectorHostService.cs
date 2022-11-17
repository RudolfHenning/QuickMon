using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    public class RemoteCollectorHostService : IRemoteCollectorHostService
    {
        public RemoteCollectorHostService()
        {
            BlockedCollectorAgentTypes = new List<string>();
        }
        #region Security
        //Run time setting only
        public string ApplicationUserNameCacheMasterKey { get; set; }
        public string ApplicationUserNameCacheFilePath { get; set; }
        public string ScriptsRepositoryDirectory { get; set; }
        #endregion

        #region Globally Disable/block Agent types if it is not supported for some reason
        public List<string> BlockedCollectorAgentTypes { get; set; }
        #endregion

        #region monitorPackFile
        public string MonitorPackFile { get; set; }
        #endregion

        #region IRemoteCollectorHostService
        public MonitorState GetState(QuickMon.RemoteCollectorHost entry)
        {
            
            MonitorState monitorState = new MonitorState();

            /*** For Console debugging **/
#if DEBUG
            StringBuilder consoleOutPut = new StringBuilder();
            consoleOutPut.AppendFormat("{0}: Running collector host: {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);            
            try
            {
                OperationContext context = OperationContext.Current;
                System.ServiceModel.Channels.MessageProperties messageProperties = context.IncomingMessageProperties;
                System.ServiceModel.Channels.RemoteEndpointMessageProperty endpointProperty =
                  messageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;

                consoleOutPut.AppendFormat(" Requested from {0}:{1}\r\n", endpointProperty.Address, endpointProperty.Port);
            }
            catch (Exception ex)
            {
                consoleOutPut.AppendFormat(" Error getting caller info: {0}\r\n", ex.Message);
            }
            consoleOutPut.AppendFormat("{0}\r\n", new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());
            consoleOutPut = new StringBuilder();
#endif
            /*** For Console debugging **/

            try
            {
                string collectorHostConfig = entry.ToCollectorHostXml();
                string tempMonitorPack = "<monitorPack version=\"5.0.0.0\" name=\"\" typeName=\"\" enabled=\"True\" defaultNotifier=\"\" runCorrectiveScripts=\"False\" collectorStateHistorySize=\"1\" pollingFreqSecOverride=\"0\">" +
                        "<collectorHosts>" +
                       collectorHostConfig  +
                       "</collectorHosts>\r\n" +
                       "<notifierHosts>\r\n" +
                       "</notifierHosts>\r\n" +
                       "</monitorPack>";
                MonitorPack m = new MonitorPack();                
                m.LoadXml(tempMonitorPack);
                m.ApplicationUserNameCacheMasterKey = ApplicationUserNameCacheMasterKey;
                m.ApplicationUserNameCacheFilePath = ApplicationUserNameCacheFilePath;
                m.BlockedCollectorAgentTypes.AddRange(BlockedCollectorAgentTypes.ToArray());
                m.ScriptsRepositoryDirectory = ScriptsRepositoryDirectory;
                if (m.CollectorHosts.Count == 1)
                {
                    m.RefreshStates();
                    //Since there is only one CollectorHost
                    CollectorHost ch = m.CollectorHosts[0];
                    monitorState = ch.CurrentState;
                    monitorState.RanAs = ch.CurrentState.RanAs;
                }
                else
                {
                    monitorState.CurrentValue = "There was a problem loading the Collector Host config on the remote host!";
                    monitorState.RawDetails = collectorHostConfig;
                    monitorState.HtmlDetails= collectorHostConfig.EscapeXml();
                    monitorState.State = CollectorState.Error;
                }

#if DEBUG
                //If hosted in console test app
                consoleOutPut.AppendFormat("{0}: Results for collector host: {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), entry.Name);                
                consoleOutPut.AppendFormat(" State   : {0}\r\n", monitorState.State);
                consoleOutPut.AppendFormat(" Ran as  : {0}\r\n", monitorState.RanAs);
                consoleOutPut.AppendFormat(" Details : {0}\r\n", monitorState.ReadAllRawDetails());
#endif

                m.CloseMonitorPack();
                m = null;
            }
            catch (Exception ex)
            {
#if DEBUG
                consoleOutPut.AppendFormat(" Error: {0}\r\n", ex);
#endif
                monitorState.CurrentValue = ex.Message;
                monitorState.State = CollectorState.Error;
                monitorState.RawDetails = ex.ToString();
                monitorState.HtmlDetails= ex.ToString().EscapeXml();
            }
#if DEBUG
            consoleOutPut.AppendLine(new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());
#endif
            monitorState.ExecutedOnHostComputer = System.Net.Dns.GetHostName();
            return monitorState;
        }
        public string GetQuickMonCoreVersion()
        {
            string versionInfo = System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString();
#if DEBUG
            StringBuilder consoleOutPut = new StringBuilder();
            consoleOutPut.AppendFormat("Version request response: {0}\r\n", versionInfo);

            try
            {
                OperationContext context = OperationContext.Current;
                System.ServiceModel.Channels.MessageProperties messageProperties = context.IncomingMessageProperties;
                System.ServiceModel.Channels.RemoteEndpointMessageProperty endpointProperty =
                  messageProperties[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;
                consoleOutPut.AppendFormat("Requested from {0}:{1}\r\n", endpointProperty.Address, endpointProperty.Port);
            }
            catch(Exception ex)
            {
                consoleOutPut.AppendFormat("Error getting caller info: {0}\r\n", ex.Message);
            }

            consoleOutPut.AppendLine(new string('*', 79));
            Console.WriteLine(consoleOutPut.ToString());
#endif
            return versionInfo;
        }
        public List<string> GetCurrentMonitorPacks()
        {
            List<string> list = new List<string>();
            if (MonitorPackFile != null && MonitorPackFile.Length > 0)
            {
                if (System.IO.File.Exists(MonitorPackFile))
                {
                    foreach (string monitorPackPath in System.IO.File.ReadAllLines(MonitorPackFile))
                    {
                        if (!monitorPackPath.StartsWith("#"))
                            list.Add(monitorPackPath);
                    }
                }
            }
            return list;
        }
#endregion

        #region Static methods
        public static MonitorState GetCollectorHostState(CollectorHost rh)
        {
            return GetCollectorHostState(rh, rh.RemoteAgentHostAddress, rh.RemoteAgentHostPort);
        }
        public static MonitorState GetCollectorHostState(CollectorHost entry, string hostAddressOverride, int portNumberOverride)
        {
            MonitorState monitorState = null;
            try { 
                BasicHttpBinding myBinding = new BasicHttpBinding();
                myBinding.MaxReceivedMessageSize = 2147483647;
                EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddressOverride, portNumberOverride));
                ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);            
                IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();

                RemoteCollectorHost colReq = new RemoteCollectorHost();
                colReq.FromCollectorHost(entry);
                monitorState =  relay.GetState(colReq); 

                myChannelFactory.Close();
                relay = null;
                myChannelFactory = null;
                myEndpoint = null;
                myBinding = null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed getting remote state from {hostAddressOverride}.\r\n{ex.Message}");
            }

            return monitorState;
        }
        public static string GetRemoteAgentHostVersion(string hostAddress, int portNumber)
        {
            string output = "";
            try
            {
                BasicHttpBinding myBinding = new BasicHttpBinding();
                EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddress, portNumber));
                ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
                IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();

                output = relay.GetQuickMonCoreVersion();

                myChannelFactory.Close();
                relay = null;
                myChannelFactory = null;
                myEndpoint = null;
                myBinding = null;
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            return output;
        }
        public static List<string> GetCurrentMonitorPacks(string hostAddressOverride, int portNumberOverride)
        {
            List<string> list = new List<string>();
            try
            {
                BasicHttpBinding myBinding = new BasicHttpBinding();
                myBinding.MaxReceivedMessageSize = 2147483647;
                EndpointAddress myEndpoint = new EndpointAddress(string.Format("http://{0}:{1}/QuickMonRemoteHost", hostAddressOverride, portNumberOverride));
                ChannelFactory<IRemoteCollectorHostService> myChannelFactory = new ChannelFactory<IRemoteCollectorHostService>(myBinding, myEndpoint);
                IRemoteCollectorHostService relay = myChannelFactory.CreateChannel();

                list = relay.GetCurrentMonitorPacks();

                myChannelFactory.Close();
                relay = null;
                myChannelFactory = null;
                myEndpoint = null;
                myBinding = null;                
            }
            catch (Exception ex)
            {
                list.Add($"Error:{ex.Message}");
            }
            return list;
        }
        #endregion

    }

    public class RemoteCollectorHostServiceInstanceProvider : System.ServiceModel.Description.IEndpointBehavior, System.ServiceModel.Dispatcher.IInstanceProvider
    {
        string applicationUserNameCacheMasterKey = "";
        string applicationUserNameCacheFilePath = "";
        string monitorPackFile = "";
        string scriptsRepository = @"C:\ProgramData\Hen IT\QuickMon 5";
        List<string> blockedCollectorAgentTypes = new List<string>();
        public RemoteCollectorHostServiceInstanceProvider(string applicationUserNameCacheMasterKey, string applicationUserNameCacheFilePath,
            List<string> blockedCollectorAgentTypes, string scriptsRepository, string monitorPackFile)
        {
            this.applicationUserNameCacheMasterKey = applicationUserNameCacheMasterKey;
            this.applicationUserNameCacheFilePath = applicationUserNameCacheFilePath;
            this.blockedCollectorAgentTypes.AddRange(blockedCollectorAgentTypes.ToArray());
            this.scriptsRepository = scriptsRepository;
            this.monitorPackFile = monitorPackFile;
        }

        public void AddBindingParameters(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(System.ServiceModel.Description.ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.InstanceProvider = this;
        }

        public void Validate(System.ServiceModel.Description.ServiceEndpoint endpoint)
        {

        }

        public object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return new RemoteCollectorHostService { 
                ApplicationUserNameCacheMasterKey = this.applicationUserNameCacheMasterKey, 
                ApplicationUserNameCacheFilePath = applicationUserNameCacheFilePath ,
                BlockedCollectorAgentTypes = blockedCollectorAgentTypes,
                ScriptsRepositoryDirectory = scriptsRepository,
                MonitorPackFile = monitorPackFile
            };
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return new RemoteCollectorHostService {
                ApplicationUserNameCacheMasterKey = this.applicationUserNameCacheMasterKey,
                ApplicationUserNameCacheFilePath = applicationUserNameCacheFilePath,
                ScriptsRepositoryDirectory = scriptsRepository
            };
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            try
            {
                if (instanceContext != null)
                {
                    instanceContext.ReleaseServiceInstance();
                    instanceContext.Close();
                    instanceContext = null;
                }
            }
            catch { }
            try
            {
                if (instance != null && instance is IDisposable)
                {
                    ((IDisposable)instance).Dispose();
                }
                instance = null;
            }
            catch { }
            
        }
    }
}
