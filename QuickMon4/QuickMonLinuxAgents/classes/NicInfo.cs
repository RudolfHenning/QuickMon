using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH = System.Threading;

namespace QuickMon.Linux
{
    public class NicInfo
    {
        public NicInfo() { TimeUpdated = DateTime.Now; LocalLoopback = false; }

        public string Name { get; set; }
        public DateTime TimeUpdated { get; set; }
        public bool LocalLoopback { get; set; }
        public string IpV4 { get; set; }
        public string IpV6 { get; set; }
        public string HWAddress { get; set; }
        public long RxBytes { get; set; }
        public long TxBytes { get; set; }

        /// <summary>
        /// Parsing output of ifconfig
        /// </summary>
        /// <param name="input">output of ifconfig</param>
        /// <returns></returns>
        public static List<NicInfo> FromIfconfig(string input)
        {
            List<NicInfo> nics = new List<NicInfo>();
            string[] lines = input.Split(new string[] { "\n", "\r" }, StringSplitOptions.None);
            NicInfo nextNic = new NicInfo();
            foreach (string line in lines)
            {
                if (line.Trim().Length == 0)
                {
                }
                else
                {
                    if (line.StartsWith(" "))
                    {
                        if (line.Contains("inet addr:"))
                        {
                            string[] values = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (values.Length > 1 && values[1].Contains("addr:") && values[1].Length > 5)
                            {
                                nextNic.IpV4 = values[1].Substring(5);
                            }
                        }
                        else if (line.Contains("inet6 addr:"))
                        {
                            string[] values = line.Replace("inet6 addr:", "").Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (values.Length > 0 && values[0].Length > 5)
                            {
                                nextNic.IpV6 = values[0];
                            }
                        }
                        else if (line.Contains("RX bytes:"))
                        {
                            string[] values = line.Trim().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                            nextNic.RxBytes = long.Parse(values[2]);
                            nextNic.TxBytes = long.Parse(values[7]);
                            nics.Add(nextNic);
                        }
                    }
                    else
                    { //Start of next nic info
                        nextNic = new NicInfo();

                        string[] values = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        nextNic.Name = values[0];
                        if (line.Contains("Local Loopback"))
                        {
                            nextNic.LocalLoopback = true;
                            nextNic.HWAddress = "N/A";
                        }
                        else
                        {
                            nextNic.HWAddress = values[values.Length - 1];
                        }

                    }
                }
            }
            return nics;
        }

        public static List<NicInfo> GetCurrentNicStats(Renci.SshNet.SshClient sshClient, int delayMS = 1000)
        {
            List<NicInfo> nicDiffs = new List<NicInfo>();

            List<NicInfo> nics1 = FromIfconfig(sshClient.RunCommand("ifconfig").Result);
            TH.Thread.Sleep(delayMS);
            List<NicInfo> nics2 = FromIfconfig(sshClient.RunCommand("ifconfig").Result);

            foreach (NicInfo c1 in nics1)
            {
                NicInfo c2 = nics2.FirstOrDefault(c => c.Name == c1.Name);
                if (c2 != null)
                {
                    NicInfo nicUsageDiff = new NicInfo();
                    nicUsageDiff.Name = c1.Name;
                    nicUsageDiff.LocalLoopback = c1.LocalLoopback;
                    nicUsageDiff.IpV4 = c1.IpV4;
                    nicUsageDiff.IpV6 = c1.IpV6;
                    nicUsageDiff.HWAddress = c1.HWAddress;
                    nicUsageDiff.RxBytes = c2.RxBytes - c1.RxBytes;
                    nicUsageDiff.TxBytes = c2.TxBytes - c1.TxBytes;

                    nicDiffs.Add(nicUsageDiff);
                }
            }
            return nicDiffs;
        }
    }
}
