using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace QuickMon.Collectors
{
    public static class EventLogUtil
    {
        public static List<string> GetEventSources(string machineName, string eventLogName)
        {
            List<string> sources = new List<string>();
            try
            {
                using (RegistryKey remoteLMKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
                {
                    using (RegistryKey eventlogKey = remoteLMKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog\\" + eventLogName))
                    {
                        sources.AddRange(eventlogKey.GetSubKeyNames());
                        sources.Sort();
                    }
                }
            }
            catch (System.Security.SecurityException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error retrieving event sources for {0} on {1}", eventLogName, machineName), ex);
            }
            return sources;
        }
        public static List<string> GetEventLogNames(string machineName)
        {
            List<string> logNames = new List<string>();
            try
            {
                using (RegistryKey remoteLMKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
                {
                    using (RegistryKey eventlogKey = remoteLMKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog"))
                    {
                        logNames.AddRange(eventlogKey.GetSubKeyNames());
                        logNames.Sort();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error retrieving event logs on {1}", machineName), ex);
            }
            return logNames;
        }
        public static List<string> GetEventSources(string eventLogName)
        {
            List<string> sources = new List<string>();
            try
            {
                using (RegistryKey eventlogKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog\\" + eventLogName, false))
                {
                    sources.AddRange(eventlogKey.GetSubKeyNames());
                    sources.Sort();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error retrieving event sources for {0}", eventLogName), ex);
            }
            return sources;
        }
        public static EventLogProperties GetEventLogProperties(string machineName, string eventLogName)
        {
            EventLogProperties elp = new EventLogProperties() { MachineName = machineName, Name = eventLogName };
            try
            {
                using (RegistryKey remoteLMKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
                {
                    using (RegistryKey eventlogKey = remoteLMKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog\\" + eventLogName, false))
                    {
                        elp.MaxSize = System.Convert.ToInt64(eventlogKey.GetValue("MaxSize", 524288));
                        elp.Retention = System.Convert.ToInt64(eventlogKey.GetValue("Retention", 0));
                        elp.AutoBackupLogFiles = System.Convert.ToInt64(eventlogKey.GetValue("AutoBackupLogFiles", 0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error retrieving event log propeties for {0}", eventLogName), ex);
            }
            return elp;
        }
        public static EventLogProperties GetEventLogProperties(string eventLogName)
        {
            EventLogProperties elp = new EventLogProperties() { MachineName = ".", Name = eventLogName };
            try
            {
                using (RegistryKey eventlogKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog\\" + eventLogName, false))
                {
                    elp.MaxSize = System.Convert.ToInt64(eventlogKey.GetValue("MaxSize", 524288));
                    elp.Retention = System.Convert.ToInt64(eventlogKey.GetValue("Retention", 0));
                    elp.AutoBackupLogFiles = System.Convert.ToInt64(eventlogKey.GetValue("AutoBackupLogFiles", 0));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error retrieving event log propeties for {0}", eventLogName), ex);
            }
            return elp;
        }
        public static void SetEventLogProperties(EventLogProperties elp)
        {
            SetEventLogProperties(elp.MachineName, elp.Name, elp.MaxSize, elp.Retention, elp.AutoBackupLogFiles);
        }
        public static void SetEventLogProperties(string machineName, string eventLogName, long maxSize, long retention, long autoBackupLogFiles)
        {
            try
            {
                using (RegistryKey remoteLMKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, machineName))
                {
                    using (RegistryKey eventlogKey = remoteLMKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Eventlog\\" + eventLogName, true))
                    {
                        eventlogKey.SetValue("MaxSize", maxSize);
                        eventlogKey.SetValue("Retention", retention);
                        if (retention == 0)
                            eventlogKey.SetValue("AutoBackupLogFiles", 0);
                        else
                            eventlogKey.SetValue("AutoBackupLogFiles", autoBackupLogFiles);
                        eventlogKey.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error saving event log propeties for {0}", eventLogName), ex);
            }
        }
    }
}
