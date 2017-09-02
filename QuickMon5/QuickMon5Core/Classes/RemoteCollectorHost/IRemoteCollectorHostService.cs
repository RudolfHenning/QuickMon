using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    [ServiceContract(Namespace = "http://HenIT/QuickMon")]
    public interface IRemoteCollectorHostService
    {
        [OperationContract]
        MonitorState GetState(RemoteCollectorHost entry);

        [OperationContract]
        string GetQuickMonCoreVersion();

        //[OperationContract]
        //System.Data.DataSet GetCollectorHostDetails(RemoteCollectorHost entry);

        //[OperationContract]
        //System.Data.DataSet GetAgentDetails(string collectorAgentConfig);

        [OperationContract]
        List<string> GetCurrentMonitorPacks();
    }
}
