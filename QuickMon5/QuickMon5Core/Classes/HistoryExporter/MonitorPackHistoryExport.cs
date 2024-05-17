using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon
{
    [Serializable]
    public class MonitorPackHistoryExport
    {
        public string Name { get; set; }
        public string MonitorPackPath { get; set; }
        public List<CollectorHistoryExport> CollectorHistoryExports { get; set; }
        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<MonitorPackHistory name=\"{Name}\" path=\"{XmlFormattingUtils.EscapeXml(MonitorPackPath)}\">");
            sb.AppendLine($"<Collectors>");
            foreach (CollectorHistoryExport item in CollectorHistoryExports)
            {
                sb.AppendLine(item.ToXml());
            }
            sb.AppendLine($"</Collectors>");
            sb.AppendLine($"</MonitorPackHistory>");
            return sb.ToString();
        }
        public void FromXml(string xmlString)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            XmlElement documentElement = xmlDocument.DocumentElement;
            Name = documentElement.ReadXmlElementAttr("name", "");
            MonitorPackPath = documentElement.ReadXmlElementAttr("path", "");
            CollectorHistoryExports = new List<CollectorHistoryExport>();
            XmlNode collectors = documentElement.SelectSingleNode("Collectors");
            XmlNodeList xmlNodeList = collectors.SelectNodes("CollectorHistory");
            foreach (XmlNode item in xmlNodeList)
            {
                CollectorHistoryExport collectorHistoryExport = new CollectorHistoryExport();
                collectorHistoryExport.FromXml(item.OuterXml);
                CollectorHistoryExports.Add(collectorHistoryExport);
            }
        }
    }
}
