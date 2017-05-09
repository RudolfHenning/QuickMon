using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH = System.Threading;

namespace QuickMon.NIX
{
    public class DiskIOInfo
    {
        public DiskIOInfo()
        {
            MeasurementDelayMS = 1000;
        }
        public string Name { get; set; }
        public DateTime TimeUpdated { get; set; }
        public int MajorNumber { get; set; }
        public int MinorNumber { get; set; }
        public long ReadsCompleted { get; set; }
        public long ReadsMerged { get; set; }
        public long SectorsRead { get; set; }
        public long TimeSpentReadingMS { get; set; }
        public long WritesCompleted { get; set; }
        public long WritesMerged { get; set; }
        public long SectorsWritten { get; set; }
        public long TimeSpentWritingMS { get; set; }
        public long IOsInProgress { get; set; }
        public long TimeDoingIOsMS { get; set; }
        public long WeightedTimeDoingIOsMS { get; set; }

        public long BytesReadPerSec { get { return (SectorsRead * 512000) / MeasurementDelayMS; } }
        public long BytesWritePerSec { get { return (SectorsWritten * 512000) / MeasurementDelayMS; } }
        public long BytesReadWritePerSec { get { return ((SectorsRead + SectorsWritten) * 512000) / MeasurementDelayMS; } }
        public int MeasurementDelayMS { get; set; }

        public static List<DiskIOInfo> FromProcDiskStats(Renci.SshNet.SshClient sshClient)
        {
            return FromProcDiskStats(sshClient.RunCommand("cat /proc/diskstats").Result);
        }
        public static List<DiskIOInfo> FromProcDiskStats(string input)
        {
            List<DiskIOInfo> disks = new List<DiskIOInfo>();
            string[] lines = input.Split(new string[] { "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] values = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if ((line.Contains(" hd") || line.Contains(" sd")) && values.Length >= 14)
                {
                    DiskIOInfo di = new DiskIOInfo();
                    di.MajorNumber = (int)Parsers.ParseLong(values[0]);
                    di.MinorNumber = (int)Parsers.ParseLong(values[1]);
                    di.Name = values[2];
                    di.ReadsCompleted = Parsers.ParseLong(values[3]);
                    di.ReadsMerged = Parsers.ParseLong(values[4]);
                    di.SectorsRead = Parsers.ParseLong(values[5]);
                    di.TimeSpentReadingMS = Parsers.ParseLong(values[6]);
                    di.WritesCompleted = Parsers.ParseLong(values[7]);
                    di.WritesMerged = Parsers.ParseLong(values[8]);
                    di.SectorsWritten = Parsers.ParseLong(values[9]);
                    di.TimeSpentWritingMS = Parsers.ParseLong(values[10]);
                    di.IOsInProgress = Parsers.ParseLong(values[11]);
                    di.TimeDoingIOsMS = Parsers.ParseLong(values[12]);
                    di.WeightedTimeDoingIOsMS = Parsers.ParseLong(values[13]);
                    disks.Add(di);
                }

            }
            return disks;
        }

        public static List<DiskIOInfo> GetCurrentDiskStats(Renci.SshNet.SshClient sshClient, int delayMS = 1000)
        {
            List<DiskIOInfo> diskDiffs = new List<DiskIOInfo>();


            List<DiskIOInfo> disks1 = FromProcDiskStats(sshClient.RunCommand("cat /proc/diskstats").Result);
            TH.Thread.Sleep(delayMS);
            List<DiskIOInfo> disks2 = FromProcDiskStats(sshClient.RunCommand("cat /proc/diskstats").Result);

            foreach (DiskIOInfo c1 in disks1)
            {
                DiskIOInfo c2 = disks2.FirstOrDefault(c => c.Name == c1.Name);
                if (c2 != null)
                {
                    DiskIOInfo diskUsageDiff = new DiskIOInfo();

                    diskUsageDiff.MeasurementDelayMS = delayMS;
                    diskUsageDiff.MajorNumber = c1.MajorNumber;
                    diskUsageDiff.MinorNumber = c1.MinorNumber;
                    diskUsageDiff.Name = c1.Name;
                    diskUsageDiff.ReadsCompleted = c2.ReadsCompleted - c1.ReadsCompleted;
                    diskUsageDiff.ReadsMerged = c2.ReadsMerged - c1.ReadsMerged;
                    diskUsageDiff.SectorsRead = c2.SectorsRead - c1.SectorsRead;
                    diskUsageDiff.TimeSpentReadingMS = c2.TimeSpentReadingMS - c1.TimeSpentReadingMS;
                    diskUsageDiff.WritesCompleted = c2.WritesCompleted - c1.WritesCompleted;
                    diskUsageDiff.WritesMerged = c2.WritesMerged - c1.WritesMerged;
                    diskUsageDiff.SectorsWritten = c2.SectorsWritten - c1.SectorsWritten;
                    diskUsageDiff.TimeSpentWritingMS = c2.TimeSpentWritingMS - c1.TimeSpentWritingMS;
                    diskUsageDiff.IOsInProgress = c2.IOsInProgress - c1.IOsInProgress;
                    diskUsageDiff.TimeDoingIOsMS = c2.TimeDoingIOsMS - c1.TimeDoingIOsMS;
                    diskUsageDiff.WeightedTimeDoingIOsMS = c2.WeightedTimeDoingIOsMS - c1.WeightedTimeDoingIOsMS;
                    diskDiffs.Add(diskUsageDiff);
                }
            }
            return diskDiffs;
        }
    }
}
