using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

/*
 * Days of the week and Holidays additions thanks to Paul (unclepaul84@gmail.com)
 * */

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
        public HashSet<DayOfWeek> DaysOfWeek { get { return daysOfWeek; } }
        public HashSet<DateTime> Holidays { get { return holidays; } }

        public void AddTimeWindow(DateTime fromTime, DateTime toTime)
        {
            times.Add(new ServiceWindow(fromTime, toTime));
        }

        private HashSet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>();
        private HashSet<DateTime> holidays = new HashSet<DateTime>();

        public bool IsInTimeWindow()
        {
            return IsInTimeWindow(DateTime.Now);
        }

        public bool IsInTimeWindow(DateTime nowTime)
        {
            if (!DaysOfWeek.Contains(nowTime.DayOfWeek))
                return false;

            if (Holidays.Contains(nowTime.Date))
                return false;

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

                var daysOfWeekNode = root.SelectSingleNode("daysOfWeek");
                var dayOfWeekStr = daysOfWeekNode.ReadXmlElementAttr("days", ""); // "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday");

                if (!string.IsNullOrEmpty(dayOfWeekStr))
                {
                    var daysOfweekEnum = dayOfWeekStr.Split(',').Select(s => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), s));
                    daysOfWeek = new HashSet<DayOfWeek>(daysOfweekEnum);
                }
                else
                {
                    daysOfWeek.Add(DayOfWeek.Sunday);
                    daysOfWeek.Add(DayOfWeek.Monday);
                    daysOfWeek.Add(DayOfWeek.Tuesday);
                    daysOfWeek.Add(DayOfWeek.Wednesday);
                    daysOfWeek.Add(DayOfWeek.Thursday);
                    daysOfWeek.Add(DayOfWeek.Friday);
                    daysOfWeek.Add(DayOfWeek.Saturday);

                }
                foreach (XmlNode holiday in root.SelectNodes("holiday"))
                {
                    var dateStr = holiday.ReadXmlElementAttr("date", DateTime.Now.ToShortDateString());
                    DateTime dt;

                    if (DateTime.TryParse(dateStr, out dt))
                        holidays.Add(dt.Date);
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

            if (daysOfWeek.Count > 0 && daysOfWeek.Count < 7)
                sb.AppendLine(string.Format("<daysOfWeek days=\"{0}\" />", string.Join(",", daysOfWeek.Select(d => d.ToString()))));

            foreach (var holiday in (from h in holidays
                                     orderby h
                                     select h))
            {
                sb.AppendLine(string.Format("<holiday date=\"{0}\" />", holiday.ToShortDateString()));
            }

            sb.AppendLine("</serviceWindows>");

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (times.Count == 0 && holidays.Count == 0 && (daysOfWeek.Count == 0 || daysOfWeek.Count >= 7))
            {
                sb.Append("None");
            }
            else 
            {
                foreach (ServiceWindow timeWindow in times)
                    sb.Append(string.Format(" and {0} to {1} ", timeWindow.From.ToString("HH:mm:ss"), timeWindow.To.ToString("HH:mm:ss")));
                if (daysOfWeek.Count > 0 && daysOfWeek.Count < 7)
                {
                    foreach (var day in (from d in daysOfWeek
                                         orderby (int)d
                                         select d))
                    {
                        sb.Append(day.ToString() + ",");
                    }
                }
                if (holidays.Count > 0)
                {
                    sb.Append(" Excl. ");
                    foreach (var holiday in (from h in holidays
                                             orderby h
                                             select h))
                    {
                        sb.Append(holiday.ToString("yyyy-MM-dd") + ",");
                    }
                }
            }
            return sb.ToString().Trim(' ', 'a', 'n', 'd', ',');
        }
    }
}
