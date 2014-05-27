using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuickMon
{
    [ServiceContract(Namespace = "http://HenIT/QuickMon")]
    public interface ICollectorEntryRelay
    {
        [OperationContract]
        MonitorState GetState(CollectorEntryRequest entry);

        [OperationContract]
        string GetQuickMonCoreVersion();

        [OperationContract]
        System.Data.DataSet GetDetails(CollectorEntryRequest entry);
    }
}
