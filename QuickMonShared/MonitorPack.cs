using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading;
using System.Diagnostics;

namespace QuickMon
{
    public delegate void RaiseCurrentStateDelegate(CollectorEntry collector, MonitorStates currentState);
    public delegate void RaiseNotifierErrorDelegare(NotifierEntry notifier, string errorMessage);
    public delegate void RaiseCollectorErrorDelegare(CollectorEntry collector, string errorMessage);
    public delegate void RaiseMonitorPackErrorDelegate(string errorMessage);
    public delegate void StateChangedDelegate(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates currentState, CollectorMessage details);

    public class MonitorPack
    {
        public MonitorPack()
        {
            Collectors = new List<CollectorEntry>();
            Notifiers = new List<NotifierEntry>();
            Enabled = true;
            PollingFreq = 1000;
            IsPolling = false;
            LastGlobalState = MonitorStates.NotAvailable;
            DefaultViewerNotifier = null;
            AgentRegistrations = new List<AgentRegistration>();
        }

        #region Events
        public event RaiseNotifierErrorDelegare RaiseNotifierError;
        private void RaiseRaiseNotifierError(NotifierEntry notifier, string errorMessage)
        {
            if (RaiseNotifierError != null)
            {
                RaiseNotifierError(notifier, errorMessage);
            }
        }
        public event RaiseCollectorErrorDelegare RaiseCollectorError;
        private void RaiseRaiseCollectorError(CollectorEntry collector, string errorMessage)
        {
            if (RaiseCollectorError != null)
            {
                RaiseCollectorError(collector, errorMessage);
            }
        }
        public event RaiseMonitorPackErrorDelegate RaiseMonitorPackError;
        private void RaiseRaiseMonitorPackError(string errorMessage)
        {
            if (RaiseMonitorPackError != null)
                RaiseMonitorPackError(errorMessage);
        }
        public event RaiseCurrentStateDelegate RaiseCurrentState;
        private void RaiseRaiseCurrentStateDelegate(CollectorEntry collector, MonitorStates currentState)
        {
            if (RaiseCurrentState != null)
                RaiseCurrentState(collector, currentState);
        }
        public event StateChangedDelegate StateChanged;
        private void RaiseStateChanged(AlertLevel alertLevel, string collectorType, string collectorName, MonitorStates oldState, MonitorStates currentState, CollectorMessage details)
        {
            if (StateChanged != null)
                StateChanged(alertLevel, collectorType, collectorName, oldState, currentState, details);
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public bool Enabled { get; set; }
        private string agentRegistrationFile;
        public string AgentRegistrationFile 
        {
            get { return agentRegistrationFile; }
            set
            {
                if (System.IO.File.Exists(value))
                {
                    agentRegistrationFile = value;
                    AgentRegistrations = SerializationUtils.DeserializeXML<List<AgentRegistration>>(System.IO.File.ReadAllText(agentRegistrationFile));
                }
            }
        }
        public List<AgentRegistration> AgentRegistrations { get; set; }
        public List<CollectorEntry> Collectors { get; private set; }
        public List<NotifierEntry> Notifiers { get; private set; }
        public NotifierEntry DefaultViewerNotifier { get; set; }
        public MonitorStates LastGlobalState { get; set; }
        public string MonitorPackPath { get; set; }

        #region Async related properties
        /// <summary>
        /// Is background polling active
        /// </summary>
        public bool IsPolling { get; set; }
        /// <summary>
        /// Polling frequency for background operations. Measured in milliseconds. Default 1 Second
        /// </summary>
        public int PollingFreq { get; set; }
        #endregion
        #endregion

        #region Refreshing states
        public MonitorStates RefreshStates()
        {
            MonitorStates globalState = MonitorStates.Good;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //First get collectors with no dependancies
            List<CollectorEntry> noDependantCollectors = (from c in Collectors
                                                          where c.ParentCollectorId.Length == 0
                                                          select c).ToList();
            //Refresh states
            foreach (CollectorEntry collector in noDependantCollectors)
            {
                RefreshCollectorState(collector);
            }
            sw.Stop();
#if DEBUG
            Trace.WriteLine(string.Format("RefreshStates - Global time: {0}ms", sw.ElapsedMilliseconds));
#endif

            //set global state
            //All disabled
            if (Collectors.Count == Collectors.Count(c => c.LastMonitorState == MonitorStates.Disabled || c.LastMonitorState == MonitorStates.Folder))
                globalState = MonitorStates.Disabled;
            //All NotAvailable
            else if (Collectors.Count == Collectors.Count(c => c.LastMonitorState == MonitorStates.NotAvailable || c.LastMonitorState == MonitorStates.Folder))
                globalState = MonitorStates.NotAvailable;
            //All good
            else if (Collectors.Count == Collectors.Count(c => c.LastMonitorState == MonitorStates.Good || c.LastMonitorState == MonitorStates.Disabled || c.LastMonitorState == MonitorStates.NotAvailable || c.LastMonitorState == MonitorStates.Folder))
                globalState = MonitorStates.Good;
            //Error state
            else if (Collectors.Count == Collectors.Count(c => c.LastMonitorState == MonitorStates.Error || c.LastMonitorState == MonitorStates.ConfigurationError || c.LastMonitorState == MonitorStates.Disabled || c.LastMonitorState == MonitorStates.Folder))
                globalState = MonitorStates.Error;
            else
                globalState = MonitorStates.Warning;

            AlertLevel globalAlertLevel = AlertLevel.Info;
            if (globalState == MonitorStates.Error || globalState == MonitorStates.ConfigurationError)
                globalAlertLevel = AlertLevel.Error;
            else if (globalState == MonitorStates.Warning)
                globalAlertLevel = AlertLevel.Warning;

            sw.Restart();
            SendNotifierAlert(globalAlertLevel, DetailLevel.Summary, "N/A", "GlobalState", MonitorStates.NotAvailable, MonitorStates.NotAvailable, new CollectorMessage());
            sw.Stop();
#if DEBUG
            Trace.WriteLine(string.Format("RefreshStates - Global notification time: {0}ms", sw.ElapsedMilliseconds));
#endif

            return globalState;
        }
        private void RefreshCollectorState(CollectorEntry collector)
        {
            MonitorStates currentState = MonitorStates.NotAvailable;
            Stopwatch sw = new Stopwatch();

            #region Getting current state
		    sw.Start();
            try
            {
                currentState = collector.GetCurrentState();
            }
            catch (Exception ex)
            {
                RaiseRaiseCollectorError(collector, ex.Message);
                currentState = MonitorStates.Error;
                collector.LastMonitorDetails = collector.Collector.LastDetailMsg;
            }
            
            sw.Stop();
#if DEBUG
            Trace.WriteLine(string.Format("RefreshCollectorState - {0}: {1}ms", collector.Name, sw.ElapsedMilliseconds));
#endif 
	#endregion

            #region Raising alerts or events
            if (!collector.IsFolder)
            {
                RaiseRaiseCurrentStateDelegate(collector, currentState);

                AlertLevel alertLevel = AlertLevel.Debug;
                if (currentState == MonitorStates.Good || currentState == MonitorStates.Disabled || currentState == MonitorStates.NotAvailable)
                    alertLevel = AlertLevel.Info;
                else if (currentState == MonitorStates.Warning)
                    alertLevel = AlertLevel.Warning;
                else if (currentState == MonitorStates.Error || currentState == MonitorStates.ConfigurationError)
                    alertLevel = AlertLevel.Error;

                if (collector.StateChanged())
                {
                    RaiseStateChanged(alertLevel, collector.CollectorRegistrationName, collector.Name, collector.LastMonitorState, currentState,
                                collector.LastMonitorDetails);
                }

                if (collector.RaiseAlert())
                {
                    SendNotifierAlert(alertLevel, DetailLevel.Detail, collector.CollectorRegistrationName, collector.Name, collector.LastMonitorState, currentState,
                            collector.LastMonitorDetails);
                    collector.LastAlertTime = DateTime.Now;
                }
                else
                {
                    RaiseStateChanged(AlertLevel.Debug, collector.CollectorRegistrationName, collector.Name, collector.LastMonitorState, currentState, new CollectorMessage());
                    SendNotifierAlert(AlertLevel.Debug, DetailLevel.Detail, collector.CollectorRegistrationName, collector.Name, collector.LastMonitorState, currentState, new CollectorMessage());
                }

                collector.LastMonitorState = currentState;
                collector.LastStateChange = DateTime.Now;
            }            
            #endregion

            #region Set or check dependants
            if (currentState == MonitorStates.Error)
            {
                SetChildCollectorStates(collector, MonitorStates.Error);
            }
            else if ((currentState == MonitorStates.Warning && !collector.CollectOnParentWarning) || currentState == MonitorStates.NotAvailable)
            {
                SetChildCollectorStates(collector, MonitorStates.NotAvailable);
            }
            else if (currentState == MonitorStates.Disabled || currentState == MonitorStates.ConfigurationError || (collector.IsFolder && !collector.Enabled))
            {
                SetChildCollectorStates(collector, MonitorStates.Disabled);
            }
            else
            {
                foreach (CollectorEntry childCollector in (from c in Collectors
                                                           where c.ParentCollectorId == collector.UniqueId
                                                           select c))
                {
                    RefreshCollectorState(childCollector);
                }
            } 
            #endregion
        }
        private void SetChildCollectorStates(CollectorEntry collector, MonitorStates childState)
        {
            foreach (CollectorEntry childCollector in (from c in Collectors
                                                       where c.ParentCollectorId == collector.UniqueId
                                                       select c))
            {
                RaiseRaiseCurrentStateDelegate(childCollector, childState);
                childCollector.LastMonitorState = childState;
                SetChildCollectorStates(childCollector, childState);
            }
        }
        private void SendNotifierAlert(AlertLevel alertLevel, DetailLevel detailLevel,
                string collectorType, string collectorName, MonitorStates oldState, MonitorStates currentState, CollectorMessage details)
        {
            foreach (NotifierEntry notifierEntry in (from n in Notifiers
                                                     where n.Enabled && (int)n.AlertLevel <= (int)alertLevel &&
                                                        (detailLevel == DetailLevel.All || detailLevel == n.DetailLevel) &&
                                                        (n.AlertForCollectors.Count == 0 || n.AlertForCollectors.Contains(collectorName))
                                                     select n))
            {
                try
                {
                    notifierEntry.Notifier.RecordMessage(alertLevel, collectorType, collectorName, oldState, currentState, details);
                }
                catch (Exception ex)
                {
                    RaiseRaiseNotifierError(notifierEntry, ex.ToString());
                }
            }
        }
        #endregion

        #region Async refreshing 
        public void StartPolling()
        {
            IsPolling = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(BackgroundPolling));
        }
        private void BackgroundPolling(object o)
        {
            while (IsPolling)
            {
                try
                {
                    LastGlobalState = RefreshStates();
                }
                catch(Exception ex)
                {
                    RaiseRaiseMonitorPackError(ex.Message);
                }
                BackgroundWaitIsPolling(PollingFreq);
            }
        }
        private void BackgroundWaitIsPolling(int nextWaitInterval)
        {
            int waitTimeRemaining;
            int decrementBy = 2000;
            if (IsPolling)
            {
                try
                {
                    if ((nextWaitInterval <= decrementBy) && (nextWaitInterval > 0))
                    {
                        Thread.Sleep(nextWaitInterval);
                    }
                    else
                    {
                        waitTimeRemaining = nextWaitInterval;
                        while (IsPolling && (waitTimeRemaining > 0))
                        {
                            if (waitTimeRemaining <= decrementBy)
                            {
                                waitTimeRemaining = 0;
                            }
                            else
                            {
                                waitTimeRemaining -= decrementBy;
                            }
                            if (decrementBy > 0)
                            {
                                Thread.Sleep(decrementBy);
                            }
                        }
                    }
                }
                catch { }
            }
        }
        #endregion

        #region Loading and saving configuration
        /// <summary>
        /// Loading QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile">Serialzed monitor pack file</param>
        public void Load(string configurationFile)
        {
            XmlDocument configurationXml = new XmlDocument();
            configurationXml.LoadXml(System.IO.File.ReadAllText(configurationFile, Encoding.UTF8));
            XmlElement root = configurationXml.DocumentElement;
            Name = root.Attributes.GetNamedItem("name").Value;
            Enabled = bool.Parse(root.Attributes.GetNamedItem("enabled").Value);
            AgentRegistrationFile = root.ReadXmlElementAttr("agentRegistrationFile");
            string defaultViewerNotifierName = root.ReadXmlElementAttr("defaultViewerNotifier");
            foreach (XmlElement xmlCollectorEntry in root.SelectNodes("collectorEntries/collectorEntry"))
            {
                CollectorEntry newCollectorEntry = CollectorEntry.FromConfig(xmlCollectorEntry);
                AgentRegistration currentCollector = null;
                if (newCollectorEntry.IsFolder)
                {
                    newCollectorEntry.Collector = null;
                }
                else
                {
                    if (AgentRegistrations != null)
                        currentCollector = (from o in AgentRegistrations
                                            where o.IsCollector && o.Name == newCollectorEntry.CollectorRegistrationName
                                            select o).FirstOrDefault();
                    if (currentCollector != null)
                    {
                        newCollectorEntry.Collector = CollectorEntry.CreateCollectorEntry(currentCollector.AssemblyPath, currentCollector.ClassName);
                        XmlDocument configDoc = new XmlDocument();
                        configDoc.LoadXml(newCollectorEntry.Configuration);
                        try
                        {
                            newCollectorEntry.Collector.ReadConfiguration(configDoc);
                        }
                        catch (Exception ex)
                        {
                            newCollectorEntry.LastMonitorState = MonitorStates.ConfigurationError;
                            newCollectorEntry.Enabled = false;
                            newCollectorEntry.LastMonitorDetails.PlainText = ex.Message;
                        }
                    }
                    else
                    {
                        newCollectorEntry.LastMonitorState = MonitorStates.ConfigurationError;
                        newCollectorEntry.Enabled = false;
                        newCollectorEntry.LastMonitorDetails.PlainText = string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", newCollectorEntry.Name, newCollectorEntry.CollectorRegistrationName);
                        RaiseRaiseMonitorPackError(string.Format("Collector '{0}' cannot be loaded as the type '{1}' is not registered!", newCollectorEntry.Name, newCollectorEntry.CollectorRegistrationName));
                    }
                }
                Collectors.Add(newCollectorEntry);
            }
            foreach (XmlElement xmlNotifierEntry in root.SelectNodes("notifierEntries/notifierEntry"))
            {
                NotifierEntry newNotifierEntry = NotifierEntry.FromConfig(xmlNotifierEntry);
                AgentRegistration currentNotifier = null;
                if (AgentRegistrations != null)
                    currentNotifier = (from o in AgentRegistrations
                                       where o.IsNotifier && o.Name == newNotifierEntry.NotifierRegistrationName
                                       select o).FirstOrDefault();
                if (currentNotifier != null)
                {
                    newNotifierEntry.Notifier = NotifierEntry.CreateNotifierEntry(currentNotifier.AssemblyPath, currentNotifier.ClassName);
                    XmlDocument configDoc = new XmlDocument();
                    configDoc.LoadXml(newNotifierEntry.Configuration);
                    try
                    {
                        newNotifierEntry.Notifier.ReadConfiguration(configDoc);
                    }
                    catch // (Exception ex)
                    {
                        newNotifierEntry.Enabled = false;
                    }
                }
                else
                {
                    newNotifierEntry.Enabled = false;
                }
                Notifiers.Add(newNotifierEntry);
                if (newNotifierEntry.Name.ToUpper() == defaultViewerNotifierName.ToUpper())
                    DefaultViewerNotifier = newNotifierEntry;
            }
            MonitorPackPath = configurationFile;
            if (Properties.Settings.Default.recentMonitorPacks == null)
                Properties.Settings.Default.recentMonitorPacks = new System.Collections.Specialized.StringCollection();
            if (!Properties.Settings.Default.recentMonitorPacks.Contains(configurationFile))
            {
                Properties.Settings.Default.recentMonitorPacks.Add(configurationFile);
                Properties.Settings.Default.Save();
            }
        }
        public bool Save()
        {
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(MonitorPackPath)))
            {
                Save(MonitorPackPath);
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Saving QuickMon monitor pack file
        /// </summary>
        /// <param name="configurationFile"></param>
        public void Save(string configurationFile)
        {
            string defaultViewerNotifier = "";
            if (DefaultViewerNotifier != null)
                defaultViewerNotifier = DefaultViewerNotifier.Name;
            string outputXml = string.Format(Properties.Resources.MonitorPackXml,
                Name, Enabled, AgentRegistrationFile, defaultViewerNotifier,
                GetConfigForCollectors(),
                GetConfigForNotifiers());
            XmlDocument outputDoc = new XmlDocument();
            outputDoc.LoadXml(outputXml);
            outputDoc.PreserveWhitespace = false;
            outputDoc.Normalize();
            outputDoc.Save(configurationFile);

            MonitorPackPath = configurationFile;
            if (Properties.Settings.Default.recentMonitorPacks == null)
                Properties.Settings.Default.recentMonitorPacks = new System.Collections.Specialized.StringCollection();
            if (!Properties.Settings.Default.recentMonitorPacks.Contains(configurationFile))
            {
                Properties.Settings.Default.recentMonitorPacks.Add(configurationFile);
                Properties.Settings.Default.Save();
            }
        }

        private string GetConfigForNotifiers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (NotifierEntry notifierEntry in Notifiers)
            {
                sb.AppendLine(notifierEntry.ToConfig());
            }
            return sb.ToString();
        }
        private string GetConfigForCollectors()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CollectorEntry collectorEntry in Collectors)
            {
                sb.AppendLine(collectorEntry.ToConfig());
            }
            return sb.ToString();
        } 
        #endregion        

        #region Sorting/Swapping
        internal void SwapCollectorEntries(CollectorEntry c1, CollectorEntry c2)
        {
            int index1 = Collectors.FindIndex(c => c.UniqueId == c1.UniqueId);
            int index2 = Collectors.FindIndex(c => c.UniqueId == c2.UniqueId);

            if (index1 < index2)
            {
                int tmp = index1;
                index1 = index2;
                index2 = tmp;
            }

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {
                
                Collectors.RemoveAt(index1);
                Collectors.RemoveAt(index2);
                Collectors.Insert(index2, c1);
                Collectors.Insert(index1, c2);
            }
        }
        internal void SwapNotifierEntries(NotifierEntry n1, NotifierEntry n2)
        {
            int index1 = Notifiers.FindIndex(c => c.Name == n1.Name);
            int index2 = Notifiers.FindIndex(c => c.Name == n2.Name);

            if (index1 > -1 && index2 > -1 && index1 != index2)
            {
                Notifiers.RemoveAt(index1);
                Notifiers.RemoveAt(index2);
                Notifiers.Insert(index2, n1);
                Notifiers.Insert(index1, n2);
            }
        } 
        #endregion
    }
}
