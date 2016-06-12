using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TH = System.Threading;

namespace QuickMon.Linux
{
    public class CPUInfo
    {
        public CPUInfo()
        {
            TimeUpdated = DateTime.Now;
        }

        //Alternative sommand
        //cat <(grep 'cpu ' /proc/stat) <(sleep 0.2 && grep 'cpu ' /proc/stat) | awk -v RS="" '{printf "%.2f\n", ($13-$2+$15-$4)*100/($13-$2+$15-$4+$16-$5)}'

        public DateTime TimeUpdated { get; set; }
        public bool IsTotalCPU { get; set; }
        public string Name { get; set; }
        public long User { get; set; }
        public long Nice { get; set; }
        public long System { get; set; }
        public long Idle { get; set; }
        public long IOWait { get; set; }
        public long IRQ { get; set; }
        public long SoftIRQ { get; set; }
        public long Steal { get; set; }
        public long Guest { get; set; }

        public double CPUPerc
        {
            get
            {
                long totalCPUTime = TotalCPUTime;
                if (totalCPUTime > 0)
                    return ((100.0 * (totalCPUTime - Idle)) / totalCPUTime);
                else
                    return 0;
            }
        }

        public long TotalCPUTime
        {
            get { return User + System + Idle; } // + Steal + Guest; }
        }

        public static List<CPUInfo> FromProcStat(string input)
        {
            List<CPUInfo> cpus = new List<CPUInfo>();
            string[] lines = input.Split(new string[] { "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] values = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.StartsWith("cpu") && values.Length > 7)
                {
                    CPUInfo cpu = new CPUInfo();
                    if (line.StartsWith("cpu "))
                        cpu.IsTotalCPU = true;
                    cpu.Name = values[0];
                    cpu.User = Parsers.ParseLong(values[1]);
                    cpu.Nice = Parsers.ParseLong(values[2]);
                    cpu.System = Parsers.ParseLong(values[3]);
                    cpu.Idle = Parsers.ParseLong(values[4]);
                    cpu.IOWait = Parsers.ParseLong(values[5]);
                    cpu.IRQ = Parsers.ParseLong(values[6]);
                    cpu.SoftIRQ = Parsers.ParseLong(values[7]);
                    if (values.Length > 8)
                        cpu.Steal = Parsers.ParseLong(values[8]);
                    if (values.Length > 9)
                        cpu.Guest = Parsers.ParseLong(values[9]);
                    cpus.Add(cpu);
                }
            }
            return cpus;
        }

        public static List<CPUInfo> GetCurrentCPUPerc(Renci.SshNet.SshClient sshClient, int delayMS = 1000)
        {
            List<CPUInfo> cpuDiffs = new List<CPUInfo>();

            List<CPUInfo> cpus1 = FromProcStat(sshClient.RunCommand("cat /proc/stat").Result);
            TH.Thread.Sleep(delayMS);
            List<CPUInfo> cpus2 = FromProcStat(sshClient.RunCommand("cat /proc/stat").Result);

            foreach (CPUInfo c1 in cpus1)
            {
                CPUInfo c2 = cpus2.FirstOrDefault(c => c.Name == c1.Name);
                if (c2 != null)
                {
                    CPUInfo cpuUsageDiff = new CPUInfo();
                    cpuUsageDiff.Name = c1.Name;
                    cpuUsageDiff.IsTotalCPU = c1.IsTotalCPU;
                    cpuUsageDiff.User = c2.User - c1.User;
                    cpuUsageDiff.Nice = c2.Nice - c1.Nice;
                    cpuUsageDiff.System = c2.System - c1.System;
                    cpuUsageDiff.Idle = c2.Idle - c1.Idle;
                    cpuUsageDiff.IOWait = c2.IOWait - c1.IOWait;
                    cpuUsageDiff.IRQ = c2.IRQ - c1.IRQ;
                    cpuUsageDiff.SoftIRQ = c2.SoftIRQ - c1.SoftIRQ;
                    cpuDiffs.Add(cpuUsageDiff);
                }
            }

            return cpuDiffs;
        }

        public static double GetCPUPerc(CPUInfo cpuTime1, CPUInfo cpuTime2)
        {
            TimeSpan ts = cpuTime2.TimeUpdated.Subtract(cpuTime1.TimeUpdated);
            if (ts.TotalSeconds > 0)
            {
                CPUInfo cpuUsageDiff = new CPUInfo();
                cpuUsageDiff.User = cpuTime2.User - cpuTime1.User;
                cpuUsageDiff.Nice = cpuTime2.Nice - cpuTime1.Nice;
                cpuUsageDiff.System = cpuTime2.System - cpuTime1.System;
                cpuUsageDiff.Idle = cpuTime2.Idle - cpuTime1.Idle;
                cpuUsageDiff.IOWait = cpuTime2.IOWait - cpuTime1.IOWait;
                cpuUsageDiff.IRQ = cpuTime2.IRQ - cpuTime1.IRQ;
                cpuUsageDiff.SoftIRQ = cpuTime2.SoftIRQ - cpuTime1.SoftIRQ;

                return ((100.0 * (cpuUsageDiff.TotalCPUTime - cpuUsageDiff.Idle)) / cpuUsageDiff.TotalCPUTime);
            }
            else
                return 0;
        }
    }
}
