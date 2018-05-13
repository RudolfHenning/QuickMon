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

        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
        //        dt.Columns[0].ExtendedProperties.Add("groupby", "true");
        //        dt.Columns.Add(new System.Data.DataColumn("Log", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Level", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Date", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Time", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Source", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Event ID", typeof(int)));
        //        dt.Columns.Add(new System.Data.DataColumn("Summary", typeof(string)));

        //        EventLogCollectorConfig currentConfig = (EventLogCollectorConfig)AgentConfig;
        //        foreach (EventLogCollectorEntry eventLog in currentConfig.Entries)
        //        {
        //            foreach(EventLogEntryEx entry in  eventLog.GetMatchingEventLogEntries())
        //            {
        //                dt.Rows.Add(entry.MachineName, entry.LogName, entry.EntryType.ToString(), entry.TimeGenerated.Date.ToString("yyyy-MM-dd"), entry.TimeGenerated.ToString("HH:mm:ss"),
        //                    entry.Source, entry.EventId, entry.MessageSummary);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //    }
        //    tables.Add(dt);
        //    return tables;
        //}
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
                eventLogEntry.PrimaryUIValue = logNode.ReadXmlElementAttr("primaryUIValue", false);
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
                logNode.SetAttributeValue("primaryUIValue", eventLogEntry.PrimaryUIValue);

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
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = string.Format("{0}\\{1}", Computer, EventLog)
            };

            try
            {
                int count = GetMatchingEventLogCount();
                CurrentAgentValue = count;
                currentState.CurrentValue = count;
                if (count >= ErrorValue)
                {
                    currentState.State = CollectorState.Error;
                    currentState.RawDetails = string.Format("(Trigger: {0})", ErrorValue);
                }
                else if (count >= WarningValue)
                {
                    currentState.State = CollectorState.Warning;
                    currentState.RawDetails = string.Format("(Trigger: {0})", WarningValue);
                }
                else
                {
                    currentState.State = CollectorState.Good;
                }                
            }
            catch(Exception ex)
            {
                currentState.State = CollectorState.Error;
                if (ex.Message.Contains("The event log") && ex.Message.Contains("on computer") && ex.Message.Contains("does not exist"))
                {
                    currentState.CurrentValue = "Log not found!";
                }
                currentState.RawDetails = ex.Message;
                
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
                        string errStr = ex.ToString();
                        if (!(errStr.Contains("is out of bounds") || errStr.Contains("outside the bounds")))
                        {
                            throw;
                        }
                    }
                }
            }
            return result;
        }
        //internal List<EventLogEntryEx> GetMatchingEventLogEntries()
        //{
        //    List<EventLogEntryEx> list = new List<EventLogEntryEx>();
        //    using (diag.EventLog log = new diag.EventLog(EventLog, Computer))
        //    {
        //        DateTime currentTime = DateTime.Now;
        //        int counter = 0;
        //        int listSize = log.Entries.Count - 1;

        //        for (int i = listSize; i >= 0; i--)
        //        {
        //            try
        //            {
        //                diag.EventLogEntry entry = log.Entries[i];
        //                if (WithInLastXEntries > 0 && WithInLastXEntries <= counter)
        //                    break;
        //                if (WithInLastXMinutes > 0 && entry.TimeGenerated.AddMinutes(WithInLastXMinutes) < currentTime)
        //                    break;

        //                EventLogEntryEx newentry = new EventLogEntryEx();
        //                newentry.Category = entry.Category;
        //                newentry.EntryType = entry.EntryType;
        //                newentry.EventId = (int)(entry.InstanceId & 65535);
        //                newentry.MachineName = entry.MachineName;
        //                newentry.LogName = EventLog;
        //                newentry.Message = entry.Message;
        //                newentry.MessageSummary = newentry.Message.Length > 80 ? newentry.Message.Substring(0, 80) : newentry.Message;
        //                newentry.Source = entry.Source;
        //                newentry.TimeGenerated = entry.TimeGenerated;
        //                newentry.UserName = entry.UserName;

        //                if (MatchEntry(newentry))
        //                    list.Add(newentry);
        //                counter++;
        //            }
        //            catch (Exception ex)
        //            {
        //                if (!ex.ToString().Contains("is out of bounds"))
        //                {
        //                    throw;
        //                }
        //            }
        //        }
        //    }
        //    return list;
        //}
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
