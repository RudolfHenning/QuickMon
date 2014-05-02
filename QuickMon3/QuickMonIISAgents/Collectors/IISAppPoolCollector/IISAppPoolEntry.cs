using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using WebAdmin = Microsoft.Web.Administration;

namespace QuickMon.Collectors
{
    public class IISAppPoolMachine : ICollectorConfigEntry
    {
        public IISAppPoolMachine()
        {
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        public string MachineName { get; set; }
        public bool UsePerfCounter { get; set; }

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0}", MachineName); }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Application pool(s): {0}", SubItems.Count);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        //in case performance counters are used
        private List<System.Diagnostics.PerformanceCounter> pcCatCache = new List<System.Diagnostics.PerformanceCounter>();

        internal List<IISAppPoolStateInfo> GetSourceIISAppPoolStates()
        {
            List<IISAppPoolStateInfo> sourceList = new List<IISAppPoolStateInfo>();
            string lastAction = "";
            try
            {
                lastAction = "Getting app pool states on " + MachineName;
                int iisVersion = GetIISVersion(MachineName);
                if (iisVersion <= 5)
                    throw new Exception("Application pools are not available on IIS version 5 or earlier!");
                else if (iisVersion == 6)
                {
                    sourceList = AppPoolStatesIIS6(MachineName);
                }
                else if (iisVersion < 99)
                {
                    sourceList = AppPoolStatesIIS7Plus(MachineName);
                }
                else
                {
                    throw new Exception("This collector is not compatible with any IIS version later than version 8.x yet.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("GetIISAppPoolStates Error: " + ex.ToString());
                throw;
            }
            return sourceList;
        }
        public List<IISAppPoolStateInfo> GetIISAppPoolStates()
        {
            List<IISAppPoolStateInfo> sourceList = GetSourceIISAppPoolStates();
            List<IISAppPoolStateInfo> list = new List<IISAppPoolStateInfo>();
            foreach(var checkEntry in SubItems)
            {
                IISAppPoolStateInfo monitorEntryState = new IISAppPoolStateInfo() { DisplayName = checkEntry.Description };
                IISAppPoolStateInfo checkedEntryState = (from IISAppPoolStateInfo ap in sourceList
                                                          where checkEntry.Description == ap.DisplayName
                                                          select ap).FirstOrDefault();
                if (checkedEntryState != null)
                    monitorEntryState.Status = checkedEntryState.Status;
                else
                    monitorEntryState.Status = AppPoolStatus.Unknown;
                list.Add(monitorEntryState);
            }
            return list;
        }
        public CollectorState GetState(List<IISAppPoolStateInfo> list)
        {
            CollectorState result = CollectorState.Good;
            int runningCount = 0;
            int notRunningCount = 0;
            foreach (var entry in list)
            {
                if (entry.Status == AppPoolStatus.Started)
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

        #region Get IIS Pool info
        private List<IISAppPoolStateInfo> AppPoolStatesIIS7Plus(string hostName)
        {
            List<IISAppPoolStateInfo> appPools = new List<IISAppPoolStateInfo>();
            try
            {
                if (UsePerfCounter && System.Diagnostics.PerformanceCounterCategory.Exists("APP_POOL_WAS", hostName))
                {
                    //Try performance counters
                    System.Diagnostics.PerformanceCounterCategory pcCat = new System.Diagnostics.PerformanceCounterCategory("APP_POOL_WAS", hostName);
                    //getting instance names
                    string[] instances = pcCat.GetInstanceNames();
                    foreach (string instanceName in instances)
                    {
                        if (instanceName != "_Total")
                        {
                            System.Diagnostics.PerformanceCounter pc = (from pcCacheEntry in pcCatCache
                                                                        where pcCacheEntry.InstanceName == instanceName
                                                                        select pcCacheEntry).FirstOrDefault();
                            if (pc == null)
                            {
                                pc = new System.Diagnostics.PerformanceCounter("APP_POOL_WAS", "Current Application Pool State", instanceName, hostName);
                                pcCatCache.Add(pc);
                            }
                            float value = pc.NextValue();
                            IISAppPoolStateInfo appPool = new IISAppPoolStateInfo() { DisplayName = instanceName };
                            appPool.Status = ReadAppPoolStateFromPCValue(value);
                            appPools.Add(appPool);
                        }
                    }
                }
                else
                {
                    using (WebAdmin.ServerManager serverManager = WebAdmin.ServerManager.OpenRemote(hostName))
                    {
                        foreach (var pool in serverManager.ApplicationPools)
                        {
                            IISAppPoolStateInfo appPool = new IISAppPoolStateInfo() { DisplayName = pool.Name };
                            appPool.Status = (AppPoolStatus)pool.State;
                            appPools.Add(appPool);
                        }
                    }
                }
            }
            //catch (UnauthorizedAccessException unauthEx)
            //{
            //    appPools = new List<IISAppPoolStateInfo>();
            //    //Try performance counters
            //    System.Diagnostics.PerformanceCounterCategory pcCat = new System.Diagnostics.PerformanceCounterCategory("APP_POOL_WAS", hostName);
            //    //getting instance names
            //    string[] instances = pcCat.GetInstanceNames();
            //    foreach (string instanceName in instances)
            //    {
            //        System.Diagnostics.PerformanceCounter pc = new System.Diagnostics.PerformanceCounter("APP_POOL_WAS", "Current Application Pool State", instanceName, hostName);
            //        float value = pc.NextValue();
            //        IISAppPoolStateInfo appPool = new IISAppPoolStateInfo() { DisplayName = instanceName };
            //        appPool.Status = ReadAppPoolStateFromPCValue(value);
            //        appPools.Add(appPool);
            //    }
            //}
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                    throw new Exception("Using ServiceManager class on local machine requires elevated rights. Please run this collector in a process that runs in 'Admin mode'");
                else if (ex.Message.Contains("80040154"))
                    throw new Exception(string.Format("ServiceManager class not supported on {0}", hostName));
                else if (ex.Message.Contains("800706ba"))
                    throw new Exception("Firewall blocking ServiceManager call. Please add OAB exception");
                else
                    throw;
            }
            return appPools;
        }

        private AppPoolStatus ReadAppPoolStateFromPCValue(float value)
        {
            //1 - Uninitialized, 2 - Initialized, 3 - Running, 4 - Disabling, 5 - Disabled, 6 - Shutdown Pending, 7 - Delete Pending
            if (value == 3)
                return AppPoolStatus.Started;
            else if (value == 4)
                return AppPoolStatus.Stopping;
            else if (value == 5)
                return AppPoolStatus.Stopping;
            if (value == 2)
                return AppPoolStatus.Starting;
            else
                return AppPoolStatus.Unknown;
        }
        private static List<IISAppPoolStateInfo> AppPoolStatesIIS6(string hostName)
        {
            List<IISAppPoolStateInfo> states = new List<IISAppPoolStateInfo>();
            try
            {
                DirectoryEntry root = new DirectoryEntry("IIS://" + hostName + "/W3SVC/AppPools");
                foreach (DirectoryEntry e in root.Children)
                {
                    if (e.SchemaClassName == "IIsApplicationPool")
                    {
                        IISAppPoolStateInfo appPool = new IISAppPoolStateInfo() { DisplayName = e.Name };
                        appPool.Status = (AppPoolStatus)e.Properties["AppPoolState"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Class not registered"))
                    throw new Exception("Error querying IIS. On IIS 7+ please make sure IIS 6 Metabase Compatibility (Role Service) is installed/enabled");
                else
                    throw;
            }
            return states;
        }
        internal int GetIISVersion(string hostName)
        {
            string iisVersion = "0";
            using (WebClient wc = new WebClient())
            {
                wc.UseDefaultCredentials = true;
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
                using (System.IO.Stream webRequest = wc.OpenRead("http://" + hostName))
                {
                    iisVersion = wc.ResponseHeaders["Server"];
                }
            }
            if (iisVersion == "0")
                return 0;
            else if (iisVersion.StartsWith("Microsoft-IIS/5."))
                return 5;
            else if (iisVersion.StartsWith("Microsoft-IIS/6."))
                return 6;
            else if (iisVersion.StartsWith("Microsoft-IIS/7."))
                return 7;
            else if (iisVersion.StartsWith("Microsoft-IIS/8."))
                return 8;
            else
                return 99; //unknown
        } 
        #endregion
    }

    public class IISAppPoolEntry : ICollectorConfigSubEntry
    {
        #region ICollectorConfigSubEntry Members
        public string Description { get; set; }
        #endregion
    }

    public class IISAppPoolStateInfo
    {
        public string DisplayName { get; set; }
        public AppPoolStatus Status { get; set; }
    }

    public enum AppPoolStatus
    {
        Starting = 0,
        Started = 1,
        Stopping = 2,
        Stopped = 3,
        Unknown = 4
    }
}
