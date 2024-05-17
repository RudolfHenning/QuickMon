using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon
{
    [Serializable]
    public class CollectorHistoryExport
    {
        public string CollectorUniqueId { get; set; }
        public string CollectorName { get; set; }
        public string PathWithoutMP { get; set; }
        public List<string> StateHistoryXML { get; set; }
        public List<string> States { get; set; }

        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<CollectorHistory uniqueId=\"{CollectorUniqueId}\" name=\"{CollectorName}\" pathWithoutMP=\"{XmlFormattingUtils.EscapeXml(PathWithoutMP)}\">");
            sb.AppendLine($"<h>");
            foreach (string item in States)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine($"</h>");
            sb.AppendLine($"</CollectorHistory>");
            return sb.ToString();
        }
        public void FromXml(string xmlString)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);
            XmlElement documentElement = xmlDocument.DocumentElement;
            CollectorUniqueId = documentElement.ReadXmlElementAttr("uniqueId", Guid.NewGuid().ToString());
            CollectorName = documentElement.ReadXmlElementAttr("name", "");
            PathWithoutMP = documentElement.ReadXmlElementAttr("pathWithoutMP", "");
            StateHistoryXML = new List<string>();
            States = new List<string>();
            XmlNode stateshistory = documentElement.SelectSingleNode("h");
            if (stateshistory != null)
            {
                foreach (XmlNode item in stateshistory.ChildNodes)
                {
                    States.Add(item.OuterXml);
                }
            }
        }
    }
}
