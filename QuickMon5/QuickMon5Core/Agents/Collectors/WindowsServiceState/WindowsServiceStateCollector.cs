using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Windows Service State Collector"), Category("General")]
    public class WindowsServiceStateCollector : CollectorAgentBase
    {
        public WindowsServiceStateCollector()
        {
            AgentConfig = new WindowsServiceStateCollectorConfig();
        }

        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        dt.Columns.Add(new System.Data.DataColumn("Computer", typeof(string)));
        //        dt.Columns[0].ExtendedProperties.Add("groupby", "true");
        //        dt.Columns.Add(new System.Data.DataColumn("Service", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("State", typeof(string)));

        //        WindowsServiceStateCollectorConfig currentConfig = (WindowsServiceStateCollectorConfig)AgentConfig;
        //        foreach (WindowsServiceStateHostEntry host in currentConfig.Entries)
        //        {
        //            try
        //            {
        //                List<ServiceStateInfo> services = host.GetServiceStates();
        //                foreach(ServiceStateInfo service in services.OrderBy(s=>s.DisplayName))
        //                {
        //                    dt.Rows.Add(host.MachineName, service.DisplayName, service.Status.ToString());
        //                }
        //            }
        //            catch(Exception ex)
        //            {
        //                dt.Rows.Add(host.MachineName, "Error", ex.Message);
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
    public class WindowsServiceStateCollectorConfig : ICollectorConfig
    {
        public WindowsServiceStateCollectorConfig()
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
            Entries.Clear();
            XmlElement root = config.DocumentElement;
            foreach (XmlElement machine in root.SelectNodes("machine"))
            {
                WindowsServiceStateHostEntry serviceStateDefinition = new WindowsServiceStateHostEntry();
                serviceStateDefinition.MachineName = machine.ReadXmlElementAttr("name", "");
                serviceStateDefinition.PrimaryUIValue = machine.ReadXmlElementAttr("primaryUIValue", false);
                serviceStateDefinition.SubItems = new List<ICollectorConfigSubEntry>();
                foreach (XmlElement service in machine.SelectNodes("service"))
                {
                    serviceStateDefinition.SubItems.Add(new WindowsServiceStateServiceEntry() { Description = service.Attributes.GetNamedItem("name").Value });
                }
                Entries.Add(serviceStateDefinition);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlNode root = config.SelectSingleNode("config");
            foreach (WindowsServiceStateHostEntry ssd in Entries)
            {
                XmlNode machineXmlNode = config.CreateElement("machine");
                machineXmlNode.SetAttributeValue("name", ssd.MachineName);
                machineXmlNode.SetAttributeValue("primaryUIValue", ssd.PrimaryUIValue);

                foreach (WindowsServiceStateServiceEntry serviceEntry in ssd.SubItems)
                {
                    XmlNode serviceXmlNode = config.CreateElement("service");
                    XmlAttribute nameXmlAttribute = config.CreateAttribute("name");
                    nameXmlAttribute.Value = serviceEntry.Description;
                    serviceXmlNode.Attributes.Append(nameXmlAttribute);
                    machineXmlNode.AppendChild(serviceXmlNode);
                }
                root.AppendChild(machineXmlNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config></config>";
        }
        public string ConfigSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} host(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(string.Format("{0} ({1} Services), ", entry.Description, entry.SubItems.Count));
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }
    public class WindowsServiceStateHostEntry : ICollectorConfigEntry
    {
        public WindowsServiceStateHostEntry()
        {
            SubItems = new List<ICollectorConfigSubEntry>();
        }

        #region Properties
        public string MachineName { get; set; }

        #endregion

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
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            List<ServiceStateInfo> serviceStates = GetServiceStates();
            CurrentAgentValue = "";
            string machineName = MachineName;
            if (machineName == "." || machineName.ToLower() == "localhost")
                machineName = System.Net.Dns.GetHostName();
            MonitorState machineState = new MonitorState()
            {
                ForAgent = machineName,
                State = GetState(serviceStates)
            };

            foreach (ServiceStateInfo serviceEntry in serviceStates)
            {
                machineState.ChildStates.Add(
                                new MonitorState()
                                {
                                    State = (serviceEntry.Status == System.ServiceProcess.ServiceControllerStatus.Stopped ? CollectorState.Error : serviceEntry.Status == System.ServiceProcess.ServiceControllerStatus.Running ? CollectorState.Good : CollectorState.Warning),
                                    ForAgent = string.Format("{0}", serviceEntry.DisplayName),
                                    ForAgentType = "CollectorConfigSubEntry",
                                    CurrentValue = serviceEntry.Status.ToString()
                                });
            }

            int errors = machineState.ChildStates.Where(cs => cs.State == CollectorState.Error).Count();
            int warnings = machineState.ChildStates.Where(cs => cs.State == CollectorState.Warning).Count();
            int successes = machineState.ChildStates.Where(cs => cs.State == CollectorState.Good).Count();
            if (errors > 0 && warnings == 0 && successes == 0)
                machineState.CurrentValue = errors.ToString() + " stopped";
            else if (errors > 0)
                machineState.CurrentValue = errors.ToString() + " stopped," + successes.ToString() + " running";
            else
                machineState.CurrentValue = successes.ToString() + " running";
            
            return machineState;
        }
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
        private CollectorState GetState(List<ServiceStateInfo> list)
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


    }
    public class ServiceStateInfo
    {
        public string DisplayName { get; set; }
        public ServiceControllerStatus Status { get; set; }
    }
    public class WindowsServiceStateServiceEntry : ICollectorConfigSubEntry
    {
        #region ICollectorConfigSubEntry Members
        public string Description { get; set; }
        #endregion
    }
}
