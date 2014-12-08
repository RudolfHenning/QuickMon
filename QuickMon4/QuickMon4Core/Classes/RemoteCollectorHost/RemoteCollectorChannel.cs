using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    public class RemoteCollectorChannel : IRemoteCollectorChannel
    {

        #region IRemoteCollectorChannel 
        public MonitorState GetState(QuickMon.RemoteCollectorHost entry)
        {
            throw new NotImplementedException();
        }
        public string GetQuickMonCoreVersion()
        {
            string versionInfo = System.Reflection.Assembly.GetAssembly(typeof(MonitorPack)).GetName().Version.ToString();
            Console.WriteLine("Version request response: {0}", versionInfo);
            return versionInfo;
        }
        public System.Data.DataSet GetDetails(QuickMon.RemoteCollectorHost entry)
        {
            throw new NotImplementedException();
        } 
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
            ChannelFactory<IRemoteCollectorChannel> myChannelFactory = new ChannelFactory<IRemoteCollectorChannel>(myBinding, myEndpoint);
            IRemoteCollectorChannel relay = myChannelFactory.CreateChannel();

            RemoteCollectorHost colReq = new RemoteCollectorHost();
            colReq.FromCollectorHost(entry);
            return relay.GetState(colReq);
        }
        #endregion
    }
}
