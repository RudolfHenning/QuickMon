using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ServiceWindow
    {
        public ServiceWindow()
        {
            Days = new List<DayOfWeek>();
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool AllWeekDays { get; set; }
        public List<DayOfWeek> Days { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} to {1} ", From.ToString("HH:mm:ss"), To.ToString("HH:mm:ss")));
            if (AllWeekDays)
                sb.Append("(All days)");
            else
            {
                string days = "";
                Days.ForEach(d => days += d.ToString().Substring(0, 2).ToLower() + ",");
                sb.Append("(" + days.Trim(',') + ")");
            }
            return sb.ToString();
        }
    }

    public class ServiceWindows
    {
        public ServiceWindows()
        {
            Entries = new List<ServiceWindow>();
            Holidays = new HashSet<DateTime>();
        }
        public List<ServiceWindow> Entries { get; private set; }
        /// <summary>
        /// Holidays are non-repeating whole days where no 'service window' works
        /// </summary>
        public HashSet<DateTime> Holidays { get; private set; }

        public void AddEntry(DateTime fromTime, DateTime toTime)
        {
            ServiceWindow newEntry = new ServiceWindow();
            newEntry.AllWeekDays = true;
            newEntry.From = fromTime;
            newEntry.To = toTime;
            Entries.Add(newEntry);
        }
        public void AddEntry(DateTime fromTime, DateTime toTime,
            bool sunday, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday)
        {
            ServiceWindow newEntry = new ServiceWindow();
            newEntry.AllWeekDays = true;
            newEntry.From = fromTime;
            newEntry.To = toTime;
            if (sunday) newEntry.Days.Add(DayOfWeek.Sunday);
            if (monday) newEntry.Days.Add(DayOfWeek.Monday);
            if (tuesday) newEntry.Days.Add(DayOfWeek.Tuesday);
            if (wednesday) newEntry.Days.Add(DayOfWeek.Wednesday);
            if (thursday) newEntry.Days.Add(DayOfWeek.Thursday);
            if (friday) newEntry.Days.Add(DayOfWeek.Friday);
            if (saturday) newEntry.Days.Add(DayOfWeek.Saturday);
            newEntry.AllWeekDays = (sunday && monday && tuesday && wednesday && thursday && friday && saturday) ||
                                    !(sunday || monday || tuesday || wednesday || thursday || friday || saturday);
            Entries.Add(newEntry);
        }

        public bool IsInTimeWindow()
        {
            return IsInTimeWindow(DateTime.Now);
        }

        /// <summary>
        /// returns true if not in Service Window (aka Enabled)
        /// </summary>
        /// <param name="nowTime"></param>
        /// <returns></returns>
        public bool IsInTimeWindow(DateTime nowTime)
        {
            if (Holidays.Contains(nowTime.Date))
                return false;

            if (Entries.Count == 0)
                return true;

            foreach (ServiceWindow sw in Entries)
            {
                if (sw.From.TimeOfDay <= nowTime.TimeOfDay && sw.To.TimeOfDay >= nowTime.TimeOfDay)
                {
                    if (sw.AllWeekDays)
                        return true;
                    else if (sw.Days.Contains(nowTime.DayOfWeek))
                        return true;
                }
            }
            return false;
        }

        public void CreateFromConfig(string config)
        {
            if (config.Length > 0)
            {
                Entries.Clear();
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode windowItem in root.SelectNodes("window"))
                {
                    try
                    {
                        DateTime fromTime = DateTime.Parse(windowItem.ReadXmlElementAttr("from", "00:00:01"));
                        DateTime toTime = DateTime.Parse(windowItem.ReadXmlElementAttr("to", "23:59:59"));
                        string days = windowItem.ReadXmlElementAttr("days", "all"); //su,mo,tu,we,th,fr,sa
                        if (days.ToLower() == "all")
                            AddEntry(fromTime, toTime);
                        else
                            AddEntry(fromTime, toTime,
                                days.ToLower().Contains("su"),
                                days.ToLower().Contains("mo"),
                                days.ToLower().Contains("tu"),
                                days.ToLower().Contains("we"),
                                days.ToLower().Contains("th"),
                                days.ToLower().Contains("fr"),
                                days.ToLower().Contains("sa")
                                );
                    }
                    catch { }
                }
                foreach (XmlNode holiday in root.SelectNodes("holiday"))
                {
                    var dateStr = holiday.ReadXmlElementAttr("date", DateTime.Now.ToShortDateString());
                    DateTime dt;

                    if (DateTime.TryParse(dateStr, out dt))
                        Holidays.Add(dt.Date);
                }
            }
        }
        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<serviceWindows>");
            if (Entries.Count > 0)
                foreach (ServiceWindow timeWindow in Entries)
                {
                    string days = "";
                    if (timeWindow.AllWeekDays)
                        days = "all";
                    else
                    {
                        timeWindow.Days.ForEach(d => days += d.ToString().Substring(0, 2).ToLower() + ",");
                    }
                    sb.AppendLine(string.Format("<window from=\"{0}\" to=\"{1}\" days=\"{2}\" />",
                        timeWindow.From.ToString("HH:mm:ss"),
                        timeWindow.To.ToString("HH:mm:ss"),
                        days.Trim(',')));
                }
            foreach (var holiday in (from h in Holidays
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
            if (Entries.Count == 0 && Holidays.Count == 0)
            {
                sb.Append("None");
            }
            else
            {
                foreach (ServiceWindow timeWindow in Entries)
                    sb.Append(string.Format(" and {0} ", timeWindow.ToString()));

                if (Holidays.Count > 0)
                {
                    sb.Append(" Excl. ");
                    foreach (var holiday in (from h in Holidays
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
