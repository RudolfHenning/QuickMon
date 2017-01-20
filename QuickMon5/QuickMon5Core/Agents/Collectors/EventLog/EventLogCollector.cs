using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using diag = System.Diagnostics;

namespace QuickMon.Collectors
{
    [Description("Event Log Collector"), Category("General")]
    public class EventLogCollector : CollectorAgentBase
    {
        public EventLogCollector()
        {
            AgentConfig = new EventLogCollectorConfig();
        }

        //public override MonitorState RefreshState()
        //{
        //    MonitorState returnState = new MonitorState();            
        //    string lastAction = "Querying event logs";
        //    int errors = 0;
        //    int warnings = 0;
        //    int success = 0;
        //    long totalCount = 0;
        //    try
        //    {
        //        EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
        //        returnState.RawDetails = string.Format("{0} Event log(s)", currentConfig.Entries.Count);
        //        returnState.HtmlDetails = string.Format("<b>{0} Event log(s)</b>", currentConfig.Entries.Count);

        //        foreach (EventLogCollectorEntry eventLogEntry in currentConfig.Entries)
        //        {
        //            bool errorCondition = false;
        //            bool warningCondition = false;
        //            lastAction = string.Format("Querying Event log '{0}\\{1}'", eventLogEntry.Computer, eventLogEntry.EventLog);

        //            int count = eventLogEntry.GetMatchingEventLogCount();
        //            if (count >= eventLogEntry.ErrorValue)
        //                errorCondition = true;
        //            else if (count >= eventLogEntry.WarningValue)
        //                warningCondition = true;
        //            totalCount += count;

        //            if (errorCondition)
        //            {
        //                errors++;
        //                returnState.ChildStates.Add(
        //                        new MonitorState()
        //                        {
        //                            State = CollectorState.Error,
        //                            ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
        //                            CurrentValue = count,
        //                            RawDetails = string.Format("(Trigger: {0})", eventLogEntry.ErrorValue)

        //                            //RawDetails = string.Format("'{0}\\{1}' - count: '{2}' - Error (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue),
        //                            //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}' - <b>Error</b> (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.ErrorValue)
        //                        });                        
        //            }
        //            else if (warningCondition)
        //            {
        //                warnings++;
        //                returnState.ChildStates.Add(
        //                        new MonitorState()
        //                        {
        //                            State = CollectorState.Warning,
        //                            ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
        //                            CurrentValue = count,
        //                            RawDetails = string.Format("(Trigger: {0})", eventLogEntry.WarningValue)
        //                            //RawDetails = string.Format("'{0}\\{1}' - count: '{2}' - Warning (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue),
        //                            //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}' - <b>Warning</b> (trigger {3})", eventLogEntry.Computer, eventLogEntry.EventLog, count, eventLogEntry.WarningValue)
        //                        });
        //            }
        //            else
        //            {
        //                success++;
        //                returnState.ChildStates.Add(
        //                        new MonitorState()
        //                        {
        //                            State = CollectorState.Good,
        //                            ForAgent = string.Format("{0}\\{1}", eventLogEntry.Computer, eventLogEntry.EventLog),
        //                            CurrentValue = count
        //                            //,
        //                            //RawDetails = string.Format("'{0}\\{1}' - count: '{2}'", eventLogEntry.Computer, eventLogEntry.EventLog, count),
        //                            //HtmlDetails = string.Format("'{0}\\{1}' - count: '{2}'", eventLogEntry.Computer, eventLogEntry.EventLog, count)
        //                        });
        //            }
        //        }
        //        if (errors > 0 && warnings == 0 && success == 0)
        //            returnState.State = CollectorState.Error;
        //        else if (errors > 0 || warnings > 0)
        //            returnState.State = CollectorState.Warning;
        //        else
        //            returnState.State = CollectorState.Good;
        //        returnState.CurrentValue = totalCount;
        //    }
        //    catch (Exception ex)
        //    {
        //        returnState.RawDetails = string.Format("Last step: '{0}\r\n{1}", lastAction, ex.Message);
        //        returnState.HtmlDetails = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", lastAction, ex.Message);
        //        returnState.State = CollectorState.Error;
        //    }
        //    return returnState;
        //}

        public override List<System.Data.DataTable> GetDetailDataTables()
        {
            List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
                dt.Columns[0].ExtendedProperties.Add("groupby", "true");
                dt.Columns.Add(new System.Data.DataColumn("Log", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Level", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Source", typeof(string)));
                dt.Columns.Add(new System.Data.DataColumn("Event ID", typeof(int)));
                dt.Columns.Add(new System.Data.DataColumn("Summary", typeof(string)));

                EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
                foreach (EventLogCollectorEntry eventLog in currentConfig.Entries)
                {
                    foreach(EventLogEntryEx entry in  eventLog.GetMatchingEventLogEntries())
                    {
                        dt.Rows.Add(entry.MachineName, entry.LogName, entry.EntryType.ToString(), entry.TimeGenerated.Date.ToString("yyyy-MM-dd"), entry.TimeGenerated.ToString("HH:mm:ss"),
                            entry.Source, entry.EventId, entry.MessageSummary);
                    }
                }
            }
            catch (Exception ex)
            {
                dt = new System.Data.DataTable("Exception");
                dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
                dt.Rows.Add(ex.ToString());
            }
            tables.Add(dt);
            return tables;
        }
    }
    public class EventLogCollectorConfig : ICollectorConfig
    {
        public EventLogCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement logNode in root.SelectNodes("eventlogs/log"))
            {
                EventLogCollectorEntry eventLogEntry = new EventLogCollectorEntry();
                eventLogEntry.Computer = logNode.ReadXmlElementAttr("computer", "");
                eventLogEntry.EventLog = logNode.ReadXmlElementAttr("eventLog", "");
                eventLogEntry.TypeInfo = bool.Parse(logNode.ReadXmlElementAttr("typeInfo", "False"));
                eventLogEntry.TypeWarn = bool.Parse(logNode.ReadXmlElementAttr("typeWarn", "True"));
                eventLogEntry.TypeErr = bool.Parse(logNode.ReadXmlElementAttr("typeErr", "True"));
                eventLogEntry.ContainsText = bool.Parse(logNode.ReadXmlElementAttr("containsText", "False"));
                eventLogEntry.UseRegEx = logNode.ReadXmlElementAttr("useRegEx", false);
                eventLogEntry.TextFilter = logNode.ReadXmlElementAttr("textFilter", "");
                eventLogEntry.WithInLastXEntries = int.Parse(logNode.ReadXmlElementAttr("withInLastXEntries", "100"));
                eventLogEntry.WithInLastXMinutes = int.Parse(logNode.ReadXmlElementAttr("withInLastXMinutes", "60"));
                eventLogEntry.WarningValue = int.Parse(logNode.ReadXmlElementAttr("warningValue", "1"));
                eventLogEntry.ErrorValue = int.Parse(logNode.ReadXmlElementAttr("errorValue", "10"));
                eventLogEntry.Sources = new List<string>();

                foreach (XmlElement sourceNode in logNode.SelectNodes("sources/source"))
                {
                    eventLogEntry.Sources.Add(sourceNode.InnerText);
                }
                foreach (XmlElement eventIdNode in logNode.SelectNodes("eventIds/eventId"))
                {
                    if (eventIdNode.InnerText.IsInteger())
                        eventLogEntry.EventIds.Add(int.Parse(eventIdNode.InnerText));
                }

                Entries.Add(eventLogEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode eventLogsNode = root.SelectSingleNode("eventlogs");
            eventLogsNode.InnerXml = "";

            foreach (EventLogCollectorEntry eventLogEntry in Entries)
            {
                XmlElement logNode = config.CreateElement("log");
                logNode.SetAttributeValue("computer", eventLogEntry.Computer);
                logNode.SetAttributeValue("eventLog", eventLogEntry.EventLog);
                logNode.SetAttributeValue("typeInfo", eventLogEntry.TypeInfo);
                logNode.SetAttributeValue("typeWarn", eventLogEntry.TypeWarn);
                logNode.SetAttributeValue("typeErr", eventLogEntry.TypeErr);
                logNode.SetAttributeValue("containsText", eventLogEntry.ContainsText);
                logNode.SetAttributeValue("useRegEx", eventLogEntry.UseRegEx);
                logNode.SetAttributeValue("textFilter", eventLogEntry.TextFilter);
                logNode.SetAttributeValue("withInLastXEntries", eventLogEntry.WithInLastXEntries);
                logNode.SetAttributeValue("withInLastXMinutes", eventLogEntry.WithInLastXMinutes);
                logNode.SetAttributeValue("warningValue", eventLogEntry.WarningValue);
                logNode.SetAttributeValue("errorValue", eventLogEntry.ErrorValue);

                XmlElement sourcesNode = config.CreateElement("sources");
                foreach (string source in eventLogEntry.Sources)
                {
                    sourcesNode.AppendElementWithText("source", source);
                }
                logNode.AppendChild(sourcesNode);

                XmlElement eventIdsNode = config.CreateElement("eventIds");
                foreach (int eventId in eventLogEntry.EventIds)
                {
                    eventIdsNode.AppendElementWithText("eventId", eventId.ToString());
                }
                logNode.AppendChild(eventIdsNode);

                eventLogsNode.AppendChild(logNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config><eventlogs></eventlogs></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
    public class EventLogCollectorEntry : ICollectorConfigEntry
    {
        public EventLogCollectorEntry()
        {
            Computer = ".";
            EventLog = "Application";
            TypeInfo = false;
            TypeWarn = true;
            TypeErr = true;
            Sources = new List<string>();
            EventIds = new List<int>();
            TextFilter = "";
            WithInLastXEntries = 1000;
            WithInLastXMinutes = 60;
            WarningValue = 1;
            ErrorValue = 10;
        }

        #region Properties
        public object CurrentAgentValue { get; set; }
        public string Computer { get; set; }
        public string EventLog { get; set; }
        public bool TypeInfo { get; set; }
        public bool TypeWarn { get; set; }
        public bool TypeErr { get; set; }
        public List<string> Sources { get; set; }
        public List<int> EventIds { get; set; }
        public bool ContainsText { get; set; }
        public bool UseRegEx { get; set; }
        public string TextFilter { get; set; }
        public int WithInLastXEntries { get; set; }
        public int WithInLastXMinutes { get; set; }
        public int WarningValue { get; set; }
        public int ErrorValue { get; set; }
        public string ComputerLogName
        {
            get
            {
                return string.Format("{0}\\{1}", Computer, EventLog);
            }
        }
        public string FilterSummary
        {
            get
            {
                string typeInfo = string.Format("Types:{0}{1}{2}", TypeInfo ? "I" : "", TypeWarn ? "W" : "", TypeErr ? "E" : "");
                string within = string.Format("In:{0}#, {1}Min", WithInLastXEntries, WithInLastXMinutes);
                string sources = Sources.Count > 0 ? ", " + Sources.Count.ToString() + "Srs" : "";
                string ids = EventIds.Count > 0 ? ", " + EventIds.Count.ToString() + "Ids" : "";
                string txt = TextFilter.Length > 0 ? (", Text-" + (ContainsText ? "Contains{" + TextFilter + "}" : "StartW{" + TextFilter + "}")) : "";
                return string.Format("{0}, {1}{2}{3}{4}", typeInfo, within, sources, ids, txt);
            }
        }
        public List<EventLogEntryEx> LastEntries = new List<EventLogEntryEx>();
        #endregion

        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return string.Format("{0}", ComputerLogName);
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("{0}", FilterSummary);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public MonitorState GetCurrentState()
        {
            bool errorCondition = false;
            bool warningCondition = false;
            int count = GetMatchingEventLogCount();
            CurrentAgentValue = count;
            if (count >= ErrorValue)
                errorCondition = true;
            else if (count >= WarningValue)
                warningCondition = true;
            MonitorState currentState = new MonitorState()
            {
                ForAgent = string.Format("{0}\\{1}", Computer, EventLog),
                CurrentValue = count
            };

            if (errorCondition)
            {
                currentState.RawDetails = string.Format("(Trigger: {0})", ErrorValue);                
            }
            else if (warningCondition)
            {
                currentState.RawDetails = string.Format("(Trigger: {0})", WarningValue);                
            }           

            return currentState;
        }
        #endregion

        #region Event Log retrieval
        internal int GetMatchingEventLogCount()
        {
            int result = 0;
            LastEntries = new List<EventLogEntryEx>();
            using (diag.EventLog log = new diag.EventLog(EventLog, Computer))
            {
                DateTime currentTime = DateTime.Now;
                int counter = 0;
                int listSize = log.Entries.Count - 1;

                for (int i = listSize; i >= 0; i--)
                {
                    try
                    {
                        diag.EventLogEntry entry = log.Entries[i];

                        if (WithInLastXEntries > 0 && WithInLastXEntries <= counter)
                            break;
                        if (WithInLastXMinutes > 0 && entry.TimeGenerated.AddMinutes(WithInLastXMinutes) < currentTime)
                            break;

                        EventLogEntryEx newentry = new EventLogEntryEx();
                        newentry.Category = entry.Category;
                        newentry.EntryType = entry.EntryType;
                        newentry.EventId = (int)(entry.InstanceId & 65535);
                        newentry.MachineName = entry.MachineName;
                        newentry.LogName = EventLog;
                        newentry.Source = entry.Source;
                        newentry.Message = entry.Message;
                        newentry.MessageSummary = newentry.Message.Length > 80 ? newentry.Message.Substring(0, 80) : newentry.Message;
                        //if (TextFilter.Length > 0)
                        //    newentry.Message = entry.Message;
                        newentry.TimeGenerated = entry.TimeGenerated;
                        newentry.UserName = entry.UserName;

                        if (MatchEntry(newentry))
                        {
                            LastEntries.Add(newentry);
                            result++;
                        }
                        counter++;
                    }
                    catch (Exception ex)
                    {
                        if (!ex.ToString().Contains("is out of bounds"))
                        {
                            throw;
                        }
                    }
                }
            }
            return result;
        }
        internal List<EventLogEntryEx> GetMatchingEventLogEntries()
        {
            List<EventLogEntryEx> list = new List<EventLogEntryEx>();
            using (diag.EventLog log = new diag.EventLog(EventLog, Computer))
            {
                DateTime currentTime = DateTime.Now;
                int counter = 0;
                int listSize = log.Entries.Count - 1;

                for (int i = listSize; i >= 0; i--)
                {
                    try
                    {
                        diag.EventLogEntry entry = log.Entries[i];
                        if (WithInLastXEntries > 0 && WithInLastXEntries <= counter)
                            break;
                        if (WithInLastXMinutes > 0 && entry.TimeGenerated.AddMinutes(WithInLastXMinutes) < currentTime)
                            break;

                        EventLogEntryEx newentry = new EventLogEntryEx();
                        newentry.Category = entry.Category;
                        newentry.EntryType = entry.EntryType;
                        newentry.EventId = (int)(entry.InstanceId & 65535);
                        newentry.MachineName = entry.MachineName;
                        newentry.LogName = EventLog;
                        newentry.Message = entry.Message;
                        newentry.MessageSummary = newentry.Message.Length > 80 ? newentry.Message.Substring(0, 80) : newentry.Message;
                        newentry.Source = entry.Source;
                        newentry.TimeGenerated = entry.TimeGenerated;
                        newentry.UserName = entry.UserName;

                        if (MatchEntry(newentry))
                            list.Add(newentry);
                        counter++;
                    }
                    catch (Exception ex)
                    {
                        if (!ex.ToString().Contains("is out of bounds"))
                        {
                            throw;
                        }
                    }
                }
            }
            return list;
        }
        private bool MatchEntry(EventLogEntryEx entry)
        {
            bool match = true;
            if (!EventEntryTypeMatch(entry))
                match = false;
            else if (Sources.Count > 0 && !Sources.Contains(entry.Source))
                match = false;
            else if (EventIds.Count > 0 && !EventIds.Contains(entry.EventId))
                match = false;
            else if (TextFilter.Length > 0 && UseRegEx)
            {
                System.Text.RegularExpressions.Match regMatch = System.Text.RegularExpressions.Regex.Match(entry.Message, TextFilter, System.Text.RegularExpressions.RegexOptions.Multiline);
                match = regMatch.Success;
            }
            else if (TextFilter.Length > 0 && !ContainsText && (!entry.Message.StartsWith(TextFilter, StringComparison.CurrentCultureIgnoreCase)))
                match = false;
            else if (TextFilter.Length > 0 && ContainsText && (!entry.Message.ToLower().Contains(TextFilter.ToLower())))
                match = false;
            return match;
        }
        private bool EventEntryTypeMatch(EventLogEntryEx entry)
        {
            if (TypeInfo && TypeWarn && TypeErr)
                return true;
            else if (!TypeInfo && (entry.EntryType == diag.EventLogEntryType.Information || entry.EntryType == 0) ||
                !TypeWarn && entry.EntryType == diag.EventLogEntryType.Warning ||
                !TypeErr && entry.EntryType == diag.EventLogEntryType.Error ||
                !TypeInfo && entry.EntryType == diag.EventLogEntryType.SuccessAudit ||
                !TypeErr && entry.EntryType == diag.EventLogEntryType.FailureAudit)
                return false;
            else
                return true;
        }
        #endregion
    }
}
