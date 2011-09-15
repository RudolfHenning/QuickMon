using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;

namespace QuickMon
{
    public class CollectorEntry
    {
        #region Properties
        public string Name { get; set; }
        /// <summary>
        /// Any unique identifier for this collector entry. Used in collector parent-child relatioships
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        /// The parent collector entry's unique identifier
        /// </summary>
        public string ParentCollectorId { get; set; }
        /// <summary>
        /// Is this collector entry just a folder/container
        /// </summary>
        public bool IsFolder { get; set; }        
        public bool CollectOnParentWarning { get; set; }

        #region Collector agent related
        public string CollectorRegistrationName { get; set; }
        public ICollector Collector { get; set; }
        private string configuration = "";
        public string Configuration 
        {
            get { return configuration; }
            set
            {
                LastMonitorState = MonitorStates.NotAvailable;
                CurrentState = MonitorStates.NotAvailable;
                configuration = value;
            }
        } 
        #endregion

        #region Is this collector entry enabled now
        /// <summary>
        /// User/config based setting to disable this CollectorEntry
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// List if service windows when collector can operate
        /// </summary>
        public ServiceWindows ServiceWindows { get; set; } 
        #endregion

        #region Last State update details
        /// <summary>
        /// 'Current' monitor state
        /// </summary>
        public MonitorStates CurrentState { get; set; }
        /// <summary>
        /// Records the last monitor state
        /// </summary>
        public MonitorStates LastMonitorState { get; set; }
        /// <summary>
        /// Contain details of last last refresh/polling of resource
        /// </summary>
        public CollectorMessage LastMonitorDetails { get; set; }
        /// <summary>
        /// Records when the last state change was
        /// </summary>
        public DateTime LastStateChange { get; set; } 
        #endregion

        #region Alerting
        /// <summary>
        /// Repeat raising alert after X minutes if state remains in error/warning
        /// </summary>
        public int RepeatAlertInXMin { get; set; }
        /// <summary>
        /// Only raise an alert once in X minutes. Used in conjunction with LastAlertTime
        /// </summary>
        public int AlertOnceInXMin { get; set; }
        /// <summary>
        /// Record the last time an alert was raised. Used in conjunction with AlertOnceInXMin
        /// </summary>
        public DateTime LastAlertTime { get; set; }
        /// <summary>
        /// Only raise an alert if the LastMonitorState remains Error or Warning.
        /// After each alert is generated this time gets updated
        /// </summary>
        public int AlertOnlyAfterXMinutesInErrorOrWarningState { get; set; }
        /// <summary>
        /// Records when the last good state was recorded
        /// </summary>
        public DateTime LastGoodState { get; set; }
        #endregion                
        
        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }
        #endregion

        #region Get/Set configuration
        public static CollectorEntry FromConfig(XmlElement xmlCollectorEntry)
        {
            CollectorEntry collectorEntry = new CollectorEntry();
            collectorEntry.LastStateChange = DateTime.Now;
            collectorEntry.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            collectorEntry.UniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueID", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            collectorEntry.Enabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enabled", "True"));
            collectorEntry.IsFolder = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("isFolder", "False"));
            collectorEntry.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParent");            

            //Service windows config
            collectorEntry.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                collectorEntry.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);

            if (!collectorEntry.IsFolder)
            {
                collectorEntry.CollectorRegistrationName = xmlCollectorEntry.ReadXmlElementAttr("collector", "No collector");
                collectorEntry.CollectOnParentWarning = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("collectOnParentWarning", "False"));
                collectorEntry.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                collectorEntry.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
                collectorEntry.AlertOnlyAfterXMinutesInErrorOrWarningState = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("waitAlertTimeErrWarnInMin", "0"));
                collectorEntry.LastAlertTime = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastGoodState = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastMonitorState = MonitorStates.NotAvailable;
                XmlNode configNode = xmlCollectorEntry.SelectSingleNode("config");
                if (configNode != null)
                    collectorEntry.Configuration = configNode.OuterXml;
                else
                {
                    collectorEntry.LastMonitorState = MonitorStates.ConfigurationError;
                    collectorEntry.Configuration = "";
                }                
            }
            else
            {
                collectorEntry.CollectorRegistrationName = "Folder";
                collectorEntry.Configuration = "";
                collectorEntry.LastMonitorState = MonitorStates.Folder;
            }
            
            collectorEntry.LastMonitorDetails = new CollectorMessage();
            
            return collectorEntry;
        }
        public string ToConfig()
        {
            string config = string.Format(Properties.Resources.CollectorEntryXml,
                UniqueId,
                Name.EscapeXml(),
                Enabled,
                IsFolder,
                CollectorRegistrationName,
                ParentCollectorId,
                CollectOnParentWarning,                
                RepeatAlertInXMin,
                AlertOnceInXMin,
                AlertOnlyAfterXMinutesInErrorOrWarningState,
                Configuration,
                ServiceWindows.ToConfig());
            return config;
        }
        #endregion

        public static ICollector CreateCollectorEntry(string assemblyPath, string className)
        {
            Assembly collectorEntryAssembly = Assembly.LoadFile(assemblyPath);
            ICollector newCollectorEntry = (ICollector)collectorEntryAssembly.CreateInstance(className);
            newCollectorEntry.LastDetailMsg = new CollectorMessage("");
            return newCollectorEntry;
        }

        public void ShowStatusDetails()
        {
            Collector.ShowStatusDetails();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, CollectorRegistrationName);
        }

        public MonitorStates GetCurrentState()
        {
            if (LastMonitorState != MonitorStates.ConfigurationError)
            {
                if (IsFolder)
                {
                    if (Enabled && ServiceWindows.IsInTimeWindow())
                        CurrentState = MonitorStates.Folder;
                    else
                        CurrentState = MonitorStates.Disabled;
                }
                else
                {
                    if (Enabled && ServiceWindows.IsInTimeWindow())
                    {
                        //*********** Call actual collector GetState **********
                        CurrentState = Collector.GetState();
                        LastMonitorDetails = Collector.LastDetailMsg;
                        if (CurrentState == MonitorStates.Good)
                            LastGoodState = DateTime.Now;
                    }
                    else
                        CurrentState = MonitorStates.Disabled;
                }
            }
            else
            {
                CurrentState = MonitorStates.ConfigurationError;
            }
            
            return CurrentState;
        }
        public bool StateChanged()
        {
            bool stateChanged = false;
            if (IsFolder) //don't bother raising events for folders
                stateChanged = false;
            else
            {
                stateChanged = (LastMonitorState != CurrentState);
            }
            return stateChanged;
        }
        private bool waitAlertTimeErrWarnInMinFlagged = false;
        public bool RaiseAlert()
        {
            bool raiseAlert = false;
            if (IsFolder) //don't bother raising events for folders
                raiseAlert = false;
            else
            {
                bool errorWarningTimeOut = false;
                bool repeatAlert = false;
                bool stateChanged = (LastMonitorState != CurrentState) && AlertOnlyAfterXMinutesInErrorOrWarningState == 0;
                if (LastMonitorState == MonitorStates.Good && (CurrentState == MonitorStates.Error || CurrentState == MonitorStates.Warning))
                    waitAlertTimeErrWarnInMinFlagged = true;

                //Has the state be in error or warning longer than specified minutes
                if (waitAlertTimeErrWarnInMinFlagged && AlertOnlyAfterXMinutesInErrorOrWarningState > 0 &&
                     LastGoodState.AddMinutes(AlertOnlyAfterXMinutesInErrorOrWarningState) < DateTime.Now &&
                        (CurrentState == MonitorStates.Error || CurrentState == MonitorStates.Warning))
                {
                    errorWarningTimeOut = true;
                    waitAlertTimeErrWarnInMinFlagged = false;
                }
                //Should the alert be repeated
                if ((RepeatAlertInXMin > 0) &&
                        (LastStateChange.AddMinutes(RepeatAlertInXMin) < DateTime.Now) &&
                        (CurrentState == MonitorStates.Error || CurrentState == MonitorStates.Warning))
                {
                    repeatAlert = true;
                }

                if (stateChanged || errorWarningTimeOut || repeatAlert)
                {
                    //only allow repeat alert after specified minutes
                    if (AlertOnceInXMin == 0 || LastAlertTime.AddMinutes(AlertOnceInXMin) < DateTime.Now)
                    {
                        raiseAlert = true;
                    }
                }             
            }

            return raiseAlert;
        }
    }
}
