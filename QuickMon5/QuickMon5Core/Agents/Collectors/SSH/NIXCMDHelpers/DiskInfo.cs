using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.NIX
{
    public class DiskInfo
    {
        public DiskInfo() { }

        public string Name { get; set; }

        public string FileType { get; set; }
        public long TotalSizeKB { get; set; }
        public long FreeSpaceKB { get; set; }
        public long UsedSpaceKB { get; set; }
        public string MountPoint { get; set; }
        public float FreeSpacePerc
        {
            get
            {
                if (TotalSizeKB > 0)
                {
                    return (float)((100.0F * FreeSpaceKB) / TotalSizeKB);
                }
                else
                {
                    return 0;
                }
            }
        }

        public static List<DiskInfo> FromDfTk(Renci.SshNet.SshClient sshClient)
        {
            return FromDfTk(sshClient.RunCommand("df -Tk").Result);
        }
        public static List<DiskInfo> FromDfTk(string input)
        {
            List<DiskInfo> disks = new List<DiskInfo>();
            string[] lines = input.Split(new string[] { "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.StartsWith("/dev", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] values = line.Trim().Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    DiskInfo di = new DiskInfo();
                    di.Name = values[0];
                    di.FileType = values[1];
                    di.TotalSizeKB = long.Parse(values[2]);
                    di.UsedSpaceKB = long.Parse(values[3]);
                    di.FreeSpaceKB = long.Parse(values[4]);
                    di.MountPoint = values[6];
                    if (di.FileType != "iso9660")
                    {
                        disks.Add(di);
                    }
                }
            }
            return disks;
        }
    }
}
