using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class MacroVariables
    {
        public static List<string> AvailableMacros
        {
            get
            {
                List<string> list = new List<string>();
                list.Add("%LocalHost%");
                list.Add("%IPAddress%");
                list.Add("%DateTime%");
                list.Add("%Date%");
                list.Add("%Year%");
                list.Add("%Month%");
                list.Add("%Day%");
                list.Add("%Hour%");
                list.Add("%Minute%");
                list.Add("%Second%");
                list.Add("%NowToFSDate%");
                return list;
            }
        }
        public static string FormatVariables(string input)
        {
            return input.Replace("%LocalHost%", System.Net.Dns.GetHostName())
                .Replace("%IPAddress%", FormatUtils.N((from adr in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
                                                       where adr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork
                                                       select adr).FirstOrDefault(), "Err getting IP"))
                .Replace("%DateTime%", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("%Date%", DateTime.Today.ToShortDateString())
                .Replace("%Year%", DateTime.Now.Year.ToString())
                .Replace("%Month%", DateTime.Now.Month.ToString())
                .Replace("%Day%", DateTime.Now.Day.ToString())
                .Replace("%Hour%", DateTime.Now.Hour.ToString())
                .Replace("%Minute%", DateTime.Now.Minute.ToString())
                .Replace("%Second%", DateTime.Now.Second.ToString())
                .Replace("%NowToFSDate%", DateTime.Now.ToFileTime().ToString());
        }
    }
}
