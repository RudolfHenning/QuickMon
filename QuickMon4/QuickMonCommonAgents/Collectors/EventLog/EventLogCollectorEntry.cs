﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diag = System.Diagnostics;

namespace QuickMon.Collectors
{
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
