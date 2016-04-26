using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Linux
{
    public class MemInfo
    {
        public MemInfo()
        {
        }

        public long TotalKB { get; set; }
        public long AvailableKB { get; set; }
        public long FreeKB { get; set; }
        public long Buffers { get; set; }
        public long Cached { get; set; }
        public long SwapTotalKB { get; set; }
        public long SwapFreeKB { get; set; }
        public double FreePerc
        {
            get
            {
                return ((100.0 * FreeKB) / TotalKB);
            }
        }
        public double AvailablePerc
        {
            get
            {
                return ((100.0 * AvailableKB) / TotalKB);
            }
        }
        public static MemInfo FromCatProcMeminfo(Renci.SshNet.SshClient sshClient)
        {
            return FromCatProcMeminfo(sshClient.RunCommand("cat /proc/meminfo").Result);
        }

        public static MemInfo FromCatProcMeminfo(string input)
        {
            MemInfo mi = new MemInfo();
            string[] lines = input.Split(new string[] { "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length > 1)
                {
                    if (line.StartsWith("MemTotal:"))
                    {
                        mi.TotalKB = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("MemAvailable:"))
                    {
                        mi.AvailableKB = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("MemFree:"))
                    {
                        mi.FreeKB = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("Buffers:"))
                    {
                        mi.Buffers = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("Cached:"))
                    {
                        mi.Cached = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("SwapTotal:"))
                    {
                        mi.SwapTotalKB = long.Parse(values[1]);
                    }
                    else if (line.StartsWith("SwapFree:"))
                    {
                        mi.SwapFreeKB = long.Parse(values[1]);
                    }
                }
            }
            return mi;
        }
    }
}
