using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using QuickMon.Collectors;

namespace QuickMon.Collectors
{
    public class ServiceStateInfo
    {
        public string DisplayName { get; set; }
        public ServiceControllerStatus Status { get; set; }
    }

    public class ServiceStateDefinition : ICollectorConfigEntry
    {
        public ServiceStateDefinition()
        {
            //Services = new List<string>();
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0}", MachineName); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Service(s): {0}", SubItems.Count);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        #region Properties
        public string MachineName { get; set; }
        //public List<string> Services { get; set; }
        #endregion

        public List<ServiceStateInfo> GetServiceStates()
        {
            List<ServiceStateInfo> list = new List<ServiceStateInfo>();
            string lastAction = "";
            try
            {
                lastAction = "Getting service states on " + MachineName;
                ServiceController[] allServices = ServiceController.GetServices(MachineName);
                foreach (ServiceController srvc in (from s in allServices
                                                    where SubItems.Exists(sub => sub.Description == s.DisplayName) 
                                                    select s))
                {
                    lastAction = string.Format("Getting service state for {0}\\{1}", MachineName, srvc.DisplayName);
                    list.Add(new ServiceStateInfo() { DisplayName = srvc.DisplayName, Status = srvc.Status });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("GetServiceStates Error: " + ex.ToString());
                throw;
            }
            return list;
        }

        public CollectorState GetState(List<ServiceStateInfo> list)
        {
            CollectorState result = CollectorState.Good;
            int runningCount = 0;
            int notRunningCount = 0;
            foreach (var entry in list)
            {
                if (entry.Status == ServiceControllerStatus.Running)
                    runningCount++;
                else
                    notRunningCount++;
            }
            if (list.Count > 0)
            {
                if (runningCount > 0 && notRunningCount > 0)
                    result = CollectorState.Warning;
                else if (runningCount == 0 && notRunningCount > 0)
                    result = CollectorState.Error;
            }
            else
                result = CollectorState.NotAvailable;

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} service(s)", MachineName, SubItems.Count);
        }
    }
    public class ServiceStateServiceEntry : ICollectorConfigSubEntry
    {
        #region ICollectorConfigSubEntry Members
        public string Description { get; set; }
        #endregion
    }
}
