using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class CollectorEntry
    {
        public CollectorEntry()
        {
            ServiceWindows = new ServiceWindows();
            ServiceWindows.CreateFromConfig("<serviceWindows/>");
            Name = "";
            Enabled = true;
            UniqueId = Guid.NewGuid().ToString();
            RemoteAgentHostPort = 8181;
        }
        #region Private vars
        private bool waitAlertTimeErrWarnInMinFlagged = false;
        private DateTime delayErrWarnAlertTime = new DateTime(2000, 1, 1);
        #endregion

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

        public bool CorrectiveScriptDisabled { get; set; }
        public string CorrectiveScriptOnWarningPath { get; set; }
        public string CorrectiveScriptOnErrorPath { get; set; }
        public string RestorationScriptPath { get; set; }
        public bool CorrectiveScriptsOnlyOnStateChange { get; set; }

        #region Collector agent related
        public string CollectorRegistrationName { get; set; }
        public string CollectorRegistrationDisplayName { get; set; }
        public ICollector Collector { get; set; }
        private string initialConfiguration = "";
        public string InitialConfiguration
        {
            get { return initialConfiguration; }
            set
            {
                LastMonitorState = new MonitorState() { State = CollectorState.NotAvailable };
                CurrentState = new MonitorState() { State = CollectorState.NotAvailable };
                initialConfiguration = value;
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
        public MonitorState CurrentState { get; set; }
        /// <summary>
        /// Records the last monitor state
        /// </summary>
        public MonitorState LastMonitorState { get; set; }

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
        public int DelayErrWarnAlertForXSec { get; set; }
        /// <summary>
        /// Records when the last good state was recorded
        /// </summary>
        public DateTime LastGoodState { get; set; }
        #endregion

        /// <summary>
        /// Any object you wish to link with this instance
        /// </summary>
        public object Tag { get; set; }

        #region Remote Execution
        public bool EnableRemoteExecute { get; set; }
        public string RemoteAgentHostAddress { get; set; }
        public int RemoteAgentHostPort { get; set; }
        #endregion
        #endregion

        #region Refreshing state and getting alerts
        public MonitorState GetCurrentState()
        {
            if (LastMonitorState.State != CollectorState.ConfigurationError)
            {
                if (CurrentState == null)
                    CurrentState = new MonitorState() { State = CollectorState.NotAvailable };
                if (IsFolder)
                {
                    LastMonitorState = CurrentState;
                    if (Enabled && ServiceWindows.IsInTimeWindow())
                        CurrentState.State = CollectorState.Folder;
                    else
                        CurrentState.State = CollectorState.Disabled;
                }
                else
                {
                    if (Enabled && ServiceWindows.IsInTimeWindow())
                    {
                        //*********** Call actual collector GetState **********
                        LastMonitorState = CurrentState;

                        if (EnableRemoteExecute)
                        {
                            try
                            {
                                CurrentState = CollectorEntryRelay.GetRemoteAgentState(this);
                            }
                            catch(Exception ex)
                            {
                                CurrentState.State = CollectorState.Error;
                                CurrentState.RawDetails = ex.ToString();
                            }
                        }
                        else
                            CurrentState = Collector.GetState();
                        if (CurrentState.State == CollectorState.Good)
                            LastGoodState = DateTime.Now;
                    }
                    else
                        CurrentState.State = CollectorState.Disabled;
                }
            }
            else
            {
                CurrentState.State = CollectorState.ConfigurationError;
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
                stateChanged = (LastMonitorState.State != CurrentState.State);
                if (stateChanged)
                    LastStateChange = DateTime.Now; //reset time
            }
            return stateChanged;
        }
        public bool RaiseAlert()
        {
            bool raiseAlert = false;
            if (IsFolder || !Enabled || //don't bother raising events for folders, disabled, N/A or collectors
                //CurrentState.State == CollectorState.Good || //No alerts for Good state
                CurrentState.State == CollectorState.NotAvailable ||
                CurrentState.State == CollectorState.Disabled)
            {
                raiseAlert = false;
                LastStateChange = DateTime.Now;
                waitAlertTimeErrWarnInMinFlagged = false;
            }
            else
            {
                bool stateChanged = (LastMonitorState.State != CurrentState.State);

                if (stateChanged)
                {
                    if (DelayErrWarnAlertForXSec > 0) // alert should be delayed
                    {
                        delayErrWarnAlertTime = DateTime.Now.AddSeconds(DelayErrWarnAlertForXSec);
                        waitAlertTimeErrWarnInMinFlagged = true;
                    }
                    else
                    {
                        raiseAlert = true;
                    }
                }
                else
                {
                    if (waitAlertTimeErrWarnInMinFlagged) //waiting for delayed alert
                    {
                        if (DateTime.Now > delayErrWarnAlertTime)
                        {
                            raiseAlert = true;
                            waitAlertTimeErrWarnInMinFlagged = false;
                            //handle further alerts as if it changed now again
                            LastStateChange = DateTime.Now;
                        }
                        else
                        {
                            raiseAlert = false;
                        }
                    }
                    else
                    {
                        if (RepeatAlertInXMin > 0)
                        {
                            if (LastStateChange.AddMinutes(RepeatAlertInXMin) < DateTime.Now)
                            {
                                raiseAlert = true;
                                //handle further alerts as if it changed now again
                                LastStateChange = DateTime.Now;
                            }
                            else
                            {
                                raiseAlert = false;
                            }
                        }
                        else
                        {
                            raiseAlert = false;
                        }
                    }
                }
                if (raiseAlert)
                {
                    //only allow repeat alert after specified minutes
                    if (AlertOnceInXMin > 0 && LastAlertTime.AddMinutes(AlertOnceInXMin) > DateTime.Now)
                    {
                        raiseAlert = false; //cancel alert
                    }
                }
                if (raiseAlert)
                    LastAlertTime = DateTime.Now; //reset alert time
            }
            return raiseAlert;
        }
        #endregion

        #region Get/Set configuration
        public static ICollector CreateCollectorEntry(RegisteredAgent ra)
        {
            if (ra != null)
            {
                return CreateCollectorEntry(ra.AssemblyPath, ra.ClassName);
            }
            else
                return null;
        }
        //public static ICollector CreateCollectorEntry(string className)
        //{
        //    RegisteredAgent ra = (from r in RegisteredAgentCache.Agents
        //                          where r.IsCollector &&  (r.ClassName == className || r.ClassName.EndsWith("." + className))
        //                          select r).FirstOrDefault();
        //    if (ra != null)
        //    {
        //        return CreateCollectorEntry(ra.AssemblyPath, ra.ClassName);
        //    }
        //    else
        //        return null;
        //}
        private static ICollector CreateCollectorEntry(string assemblyPath, string className)
        {
            Assembly collectorEntryAssembly = Assembly.LoadFile(assemblyPath);
            ICollector newCollectorEntry = (ICollector)collectorEntryAssembly.CreateInstance(className);
            newCollectorEntry.Name = className.Replace("QuickMon.Collectors.","");
            return newCollectorEntry;
        }
        public static CollectorEntry FromConfig(string stringCollectorEntry)
        {
            XmlDocument xmlCollectorEntry = new XmlDocument();
            xmlCollectorEntry.LoadXml(stringCollectorEntry);
            return FromConfig(xmlCollectorEntry.DocumentElement);
        }
        public static CollectorEntry FromConfig(XmlElement xmlCollectorEntry)
        {
            CollectorEntry collectorEntry = new CollectorEntry();
            collectorEntry.LastStateChange = DateTime.Now;
            collectorEntry.Name = xmlCollectorEntry.ReadXmlElementAttr("name", "").Trim();
            collectorEntry.UniqueId = xmlCollectorEntry.ReadXmlElementAttr("uniqueID", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            collectorEntry.Enabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enabled", "True"));
            collectorEntry.IsFolder = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("isFolder", "False"));
            collectorEntry.ParentCollectorId = xmlCollectorEntry.ReadXmlElementAttr("dependOnParent");
            collectorEntry.CorrectiveScriptDisabled = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptDisabled", "False"));
            collectorEntry.CorrectiveScriptOnWarningPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnWarningPath");
            collectorEntry.CorrectiveScriptOnErrorPath = xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptOnErrorPath");
            collectorEntry.RestorationScriptPath = xmlCollectorEntry.ReadXmlElementAttr("restorationScriptPath");
            collectorEntry.CorrectiveScriptsOnlyOnStateChange = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("correctiveScriptsOnlyOnStateChange", "False"));
            collectorEntry.EnableRemoteExecute = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("enableRemoteExecute", "False"));
            collectorEntry.RemoteAgentHostAddress = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostAddress");
            collectorEntry.RemoteAgentHostPort = xmlCollectorEntry.ReadXmlElementAttr("remoteAgentHostPort", 8181);

            //Service windows config
            collectorEntry.ServiceWindows = new ServiceWindows();
            XmlNode serviceWindowsNode = xmlCollectorEntry.SelectSingleNode("serviceWindows");
            if (serviceWindowsNode != null) //Load service windows info
                collectorEntry.ServiceWindows.CreateFromConfig(serviceWindowsNode.OuterXml);
            else
            {
                collectorEntry.ServiceWindows.CreateFromConfig("<serviceWindows />");
            }

            if (!collectorEntry.IsFolder)
            {
                collectorEntry.CollectorRegistrationName = xmlCollectorEntry.ReadXmlElementAttr("collector", "No collector");
                collectorEntry.CollectOnParentWarning = bool.Parse(xmlCollectorEntry.ReadXmlElementAttr("collectOnParentWarning", "False"));
                collectorEntry.RepeatAlertInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("repeatAlertInXMin", "0"));
                collectorEntry.AlertOnceInXMin = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("alertOnceInXMin", "0"));
                collectorEntry.DelayErrWarnAlertForXSec = int.Parse(xmlCollectorEntry.ReadXmlElementAttr("delayErrWarnAlertForXSec", "0"));
                collectorEntry.LastAlertTime = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastGoodState = new DateTime(2000, 1, 1); //long ago
                collectorEntry.LastMonitorState = new MonitorState() { State = CollectorState.NotAvailable, CurrentValue = null, RawDetails = "", HtmlDetails = "" };
                XmlNode configNode = xmlCollectorEntry.SelectSingleNode("config");
                if (configNode != null)
                {
                    collectorEntry.InitialConfiguration = configNode.OuterXml;
                }
                else
                {
                    collectorEntry.LastMonitorState.State = CollectorState.ConfigurationError;
                    collectorEntry.InitialConfiguration = "";
                }
            }
            else
            {
                collectorEntry.CollectorRegistrationName = "Folder";
                collectorEntry.CollectorRegistrationDisplayName = "Folder";
                collectorEntry.InitialConfiguration = "";
                collectorEntry.LastMonitorState.State = CollectorState.Folder;
            }
            return collectorEntry;
        }
        public string ToConfig()
        {
            //remeber to update CollectorEntryRequest version as well
            string collectorConfig = "";
            if (Collector != null)
                collectorConfig = Collector.AgentConfig.ToConfig();
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
                DelayErrWarnAlertForXSec,
                CorrectiveScriptDisabled,
                CorrectiveScriptOnWarningPath,
                CorrectiveScriptOnErrorPath,
                RestorationScriptPath,
                CorrectiveScriptsOnlyOnStateChange,
                EnableRemoteExecute.ToString(),
                RemoteAgentHostAddress,
                RemoteAgentHostPort,
                collectorConfig,
                ServiceWindows.ToConfig());
            return config;
        }
        #endregion

        #region Viewing details
        private ICollectorDetailView collectorDetailView = null;
        public void ShowDetails()
        {
            if (Collector != null)
            {
                if (collectorDetailView == null || (!collectorDetailView.IsStillVisible()))
                {
                    collectorDetailView = Collector.GetCollectorDetailView();
                    if (collectorDetailView != null)
                    {
                        collectorDetailView.SetWindowTitle(Name + " (" + this.CollectorRegistrationDisplayName + ")");
                        collectorDetailView.ShowCollectorDetails(Collector);
                    }
                }
                else
                {
                    collectorDetailView.RefreshConfig(Collector);
                }
            }
        }
        public bool ShowEditConfigEntry(ref ICollectorConfigEntry entry)
        {
            bool changed = false;
            if (Collector != null)
            {
                changed = Collector.ShowEditEntry(ref entry);
            }
            return changed;
        }
        public void RefreshDetailsIfOpen()
        {
            if (Collector != null)
            {
                if (collectorDetailView != null && (collectorDetailView.IsStillVisible()))
                {
                    collectorDetailView.SetWindowTitle(Name + " (" + this.CollectorRegistrationName + ")");
                    collectorDetailView.RefreshConfig(Collector);
                }
            }
        }
        public void CloseDetails()
        {
            if (Collector != null)
            {
                if (collectorDetailView != null && (collectorDetailView.IsStillVisible()))
                {
                    try
                    {
                        collectorDetailView.CloseWindow();
                    }
                    catch { }
                }
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, CollectorRegistrationName);
        }
        public CollectorEntry Clone()
        {
            CollectorEntry clone = FromConfig(ToConfig());
            clone.CollectorRegistrationDisplayName = this.CollectorRegistrationDisplayName;
            return clone;
        }
        //public CollectorEntry Clone()
        //{
        //    CollectorEntry clone = new CollectorEntry();
        //    clone.Name = Name;
        //    clone.UniqueId = UniqueId;
        //    clone.ParentCollectorId = ParentCollectorId;
        //    clone.IsFolder = IsFolder;
        //    clone.CollectOnParentWarning = CollectOnParentWarning;
        //    clone.CollectorRegistrationName = CollectorRegistrationName;
        //    clone.Collector =  Collector;
        //    clone.InitialConfiguration = InitialConfiguration;
        //    clone.Enabled = Enabled;
        //    clone.ServiceWindows = ServiceWindows;
        //    clone.CorrectiveScriptDisabled = CorrectiveScriptDisabled;
        //    clone.CorrectiveScriptOnWarningPath = CorrectiveScriptOnWarningPath;
        //    clone.CorrectiveScriptOnErrorPath = CorrectiveScriptOnErrorPath;
        //    clone.Tag = Tag;
        //    return clone;
        //}
    }
}
