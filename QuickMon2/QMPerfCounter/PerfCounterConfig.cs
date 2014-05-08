using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class PerfCounterConfig
    {
        public PerfCounterConfig()
        {
            QMPerfCounters = new List<QMPerfCounterInstance>();
        }
        public List<QMPerfCounterInstance> QMPerfCounters { get; set; }

        public void ReadConfig(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            QMPerfCounters.Clear();
            foreach (XmlElement pcNode in root.SelectNodes("performanceCounters/performanceCounter"))
            {
                QMPerfCounterInstance qmPerfCounterInstance = new QMPerfCounterInstance();
                qmPerfCounterInstance.Computer = pcNode.ReadXmlElementAttr("computer", ".");
                qmPerfCounterInstance.Category = pcNode.ReadXmlElementAttr("category", "Processor");
                qmPerfCounterInstance.Counter = pcNode.ReadXmlElementAttr("counter", "% Processor Time");
                qmPerfCounterInstance.Instance = pcNode.ReadXmlElementAttr("instance", "");
                qmPerfCounterInstance.ReturnValueInverted = bool.Parse(pcNode.ReadXmlElementAttr("returnValueInverted", "False"));
                qmPerfCounterInstance.WarningValue = float.Parse(pcNode.ReadXmlElementAttr("warningValue", "80"));
                qmPerfCounterInstance.ErrorValue = float.Parse(pcNode.ReadXmlElementAttr("errorValue", "100"));
                QMPerfCounters.Add(qmPerfCounterInstance);
            }
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.PerfCounterEmptyConfig);
            XmlElement root = config.DocumentElement;
            XmlNode performanceCountersNode = root.SelectSingleNode("performanceCounters");
            performanceCountersNode.InnerXml = "";
            foreach (QMPerfCounterInstance qmPerfCounterInstance in QMPerfCounters)
            {
                XmlElement performanceCounterNode = config.CreateElement("performanceCounter");
                performanceCounterNode.SetAttributeValue("computer", qmPerfCounterInstance.Computer);
                performanceCounterNode.SetAttributeValue("category", qmPerfCounterInstance.Category);
                performanceCounterNode.SetAttributeValue("counter", qmPerfCounterInstance.Counter);
                performanceCounterNode.SetAttributeValue("instance", qmPerfCounterInstance.Instance);
                performanceCounterNode.SetAttributeValue("returnValueInverted", qmPerfCounterInstance.ReturnValueInverted);
                performanceCounterNode.SetAttributeValue("warningValue", qmPerfCounterInstance.WarningValue);
                performanceCounterNode.SetAttributeValue("errorValue", qmPerfCounterInstance.ErrorValue);
                performanceCountersNode.AppendChild(performanceCounterNode);
            }
            return config.OuterXml;
        }
    }
}
