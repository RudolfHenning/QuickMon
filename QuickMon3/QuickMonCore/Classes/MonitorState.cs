using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class MonitorState
    {
        public CollectorState State { get; set; }
        public object CurrentValue { get; set; }
        public string RawDetails { get; set; }
        public string HtmlDetails { get; set; }

        public MonitorState Clone()
        {
            return new MonitorState()
            {
                State = this.State,
                CurrentValue = this.CurrentValue,
                RawDetails = this.RawDetails,
                HtmlDetails = this.HtmlDetails
            };
        }

        public override string ToString()
        {
            return State.ToString();
        }
        public string ToXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<monitorState state=\"NotAvailable\" currentValue=\"\" />");
            XmlElement root = xdoc.DocumentElement;
            root.SetAttributeValue("state", State.ToString());
            if (CurrentValue != null)
                root.SetAttributeValue("currentValue", CurrentValue.ToString());
            else
                root.SetAttributeValue("currentValue", "");
            XmlElement rawDetailsNode = xdoc.CreateElement("rawDetails");
            rawDetailsNode.InnerText = RawDetails;
            root.AppendChild(rawDetailsNode);
            XmlElement htmlDetailsNode = xdoc.CreateElement("htmlDetails");
            htmlDetailsNode.InnerText = HtmlDetails;
            root.AppendChild(htmlDetailsNode);
            return xdoc.OuterXml;
        }
        public void FromXml(string content)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(content);
            XmlElement root = xdoc.DocumentElement;
            State = CollectorStateConverter.GetCollectorStateFromText(root.ReadXmlElementAttr("state", "NotAvailable"));
            CurrentValue = root.ReadXmlElementAttr("currentValue", "");
            RawDetails = root.SelectSingleNode("rawDetails").InnerText;
            HtmlDetails = root.SelectSingleNode("htmlDetails").InnerText;
        }
    }
}
