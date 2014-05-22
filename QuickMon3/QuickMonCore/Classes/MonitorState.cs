using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class MonitorState
    {
        private CollectorState state = CollectorState.NotAvailable;
        public CollectorState State
        {
            get { return state; }
            set { state = value; LastStateChangeTime = DateTime.Now; }
        }
        public object CurrentValue { get; set; }
        public string RawDetails { get; set; }
        public string HtmlDetails { get; set; }
        public DateTime LastStateChangeTime { get; internal set; }
        public int CallDurationMS { get; set; }

        public MonitorState Clone()
        {
            return new MonitorState()
            {
                State = this.State,
                CurrentValue = this.CurrentValue,
                RawDetails = this.RawDetails,
                HtmlDetails = this.HtmlDetails,
                LastStateChangeTime = this.LastStateChangeTime,
                CallDurationMS = this.CallDurationMS
            };
        }

        public override string ToString()
        {
            return State.ToString();
        }
        public string ToXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<monitorState state=\"NotAvailable\" currentValue=\"\" lastStateChangeTime=\"\" />");
            XmlElement root = xdoc.DocumentElement;
            root.SetAttributeValue("state", State.ToString());
            root.SetAttributeValue("lastStateChangeTime", LastStateChangeTime.ToString("yyyy-MM-dd HH:mm:ss"));
            root.SetAttributeValue("callDurationMS", CallDurationMS.ToString());
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
            try
            {
                LastStateChangeTime = DateTime.Parse(root.ReadXmlElementAttr("lastStateChangeTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            catch { }
            try
            {
                CallDurationMS = root.ReadXmlElementAttr("callDurationMS", 0);
            }
            catch { }
            CurrentValue = root.ReadXmlElementAttr("currentValue", "");
            RawDetails = root.SelectSingleNode("rawDetails").InnerText;
            HtmlDetails = root.SelectSingleNode("htmlDetails").InnerText;
        }
    }
}
