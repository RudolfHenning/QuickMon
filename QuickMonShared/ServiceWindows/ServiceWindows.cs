using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ServiceWindow
    {
        public ServiceWindow(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class ServiceWindows
    {
        private List<ServiceWindow> times = new List<ServiceWindow>();
        public List<ServiceWindow> Times { get { return times; } }
                
        public void AddTimeWindow(DateTime fromTime, DateTime toTime)
        {
            times.Add(new ServiceWindow(fromTime, toTime));
        }
        public bool IsInTimeWindow()
        {
            return IsInTimeWindow(DateTime.Now);
        }
        public bool IsInTimeWindow(DateTime nowTime)
        {
            if (times.Count == 0)
                return true;
            else
                return (from t in times
                        where t.From.TimeOfDay <= nowTime.TimeOfDay && t.To.TimeOfDay >= nowTime.TimeOfDay
                        select t).Count() > 0;
        }

        public void CreateFromConfig(string config)
        {
            if (config.Length > 0)
            {
                times.Clear();
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode windowItem in root.SelectNodes("window"))
                {
                    try
                    {
                        DateTime fromTime = DateTime.Parse(windowItem.ReadXmlElementAttr("from", "00:00:01"));
                        DateTime toTime = DateTime.Parse(windowItem.ReadXmlElementAttr("to", "23:59:59"));
                        times.Add(new ServiceWindow(fromTime, toTime));
                    }
                    catch { }
                }
            }
        }
        public string ToConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<serviceWindows>");
            if (times.Count > 0)
                foreach (ServiceWindow timeWindow in times)
                    sb.AppendLine(string.Format("<window from=\"{0}\" to=\"{1}\" />", timeWindow.From.ToString("HH:mm:ss"), timeWindow.To.ToString("HH:mm:ss")));

            sb.AppendLine("</serviceWindows>");
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (times.Count > 0)
                foreach (ServiceWindow timeWindow in times)
                    sb.Append(string.Format("{0} to {1} and ", timeWindow.From.ToString("HH:mm:ss"), timeWindow.To.ToString("HH:mm:ss")));
            else
                sb.Append("None");
            return sb.ToString().Trim(' ', 'a', 'n', 'd');
        }
    }
}
