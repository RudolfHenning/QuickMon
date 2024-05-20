using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace QuickMon
{
    public static class MHIHandler
    {
        private static string locker = "";
        public static string GetMonitorPackMHIFile(MonitorPack monitorPack)
        {
            string commonpath = GetFolderPath(SpecialFolder.CommonApplicationData);
            var path = Path.Combine(commonpath, "Hen IT\\QuickMon 5");
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string monitorPackFilter = System.IO.Path.GetFileNameWithoutExtension(monitorPack.MonitorPackPath);
            string monitorPackMHIFile = "";
            foreach (string mhifile in System.IO.Directory.GetFiles(path, $"{monitorPackFilter}*.mhi"))
            {
                QuickMon.MonitorPackHistoryExport monitorPackHistoryExport = new QuickMon.MonitorPackHistoryExport();
                monitorPackHistoryExport.FromXml(System.IO.File.ReadAllText(mhifile));
                if (monitorPackHistoryExport.MonitorPackPath == monitorPack.MonitorPackPath)
                {
                    monitorPackMHIFile = mhifile;
                    break;
                }
            }
            if (monitorPackMHIFile == "") //new entry
            {
                monitorPackMHIFile = Path.Combine(path, monitorPackFilter + ".mhi");
                if (System.IO.File.Exists(monitorPackMHIFile)) //if a file with this name still exists add a number
                {
                    int number = 1;
                    while (System.IO.File.Exists(Path.Combine(path, monitorPackFilter + $"{number}.mhi")))
                    {
                        number++;
                    }
                    monitorPackMHIFile = Path.Combine(path, monitorPackFilter + $"{number}.mhi");
                }
            }
            return monitorPackMHIFile;
        }
        public static void LoadMonitorPackHistory(MonitorPack monitorPack, bool addHistory = false)
        {
            if (monitorPack != null)
            {
                //make sure polling is done.
                monitorPack.WaitWhileStillPolling();
                string inputPath = GetMonitorPackMHIFile(monitorPack);
                if (System.IO.File.Exists(inputPath))
                {
                    lock (locker)
                    {
                        int collectorsLoaded = 0;
                        int monitorStatesLoaded = 0;

                        MonitorPackHistoryExport monitorPackHistoryExport = new MonitorPackHistoryExport();
                        monitorPackHistoryExport.FromXml(System.IO.File.ReadAllText(inputPath));

                        foreach (CollectorHistoryExport collectorHistoryExport in monitorPackHistoryExport.CollectorHistoryExports)
                        {
                            CollectorHost ch = monitorPack.CollectorHosts.FirstOrDefault(c => c.UniqueId == collectorHistoryExport.CollectorUniqueId);
                            if (ch != null)
                            {
                                collectorsLoaded++;
                                if (!addHistory)
                                    ch.StateHistory.Clear();
                                foreach (string hi in collectorHistoryExport.States)
                                {
                                    try
                                    {
                                        MonitorState ms = new MonitorState();
                                        ms.FromCXml(hi);
                                        ch.StateHistory.Add(ms);
                                        monitorStatesLoaded++;
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SaveMonitorPackHistory(MonitorPack monitorPack)
        {
            if (monitorPack != null)
            {
                monitorPack.WaitWhileStillPolling();
                int statesSaved = 0;
                lock (locker)
                {
                    MonitorPackHistoryExport monitorPackHistoryExport = new MonitorPackHistoryExport();
                    monitorPackHistoryExport.Name = monitorPack.Name;
                    monitorPackHistoryExport.MonitorPackPath = monitorPack.MonitorPackPath;
                    monitorPackHistoryExport.CollectorHistoryExports = new List<QuickMon.CollectorHistoryExport>();
                    foreach (CollectorHost ch in monitorPack.CollectorHosts)
                    {
                        QuickMon.CollectorHistoryExport collectorHistoryExport = new QuickMon.CollectorHistoryExport();
                        collectorHistoryExport.CollectorName = ch.Name;
                        collectorHistoryExport.PathWithoutMP = ch.PathWithoutMP;
                        collectorHistoryExport.CollectorUniqueId = ch.UniqueId;

                        collectorHistoryExport.StateHistoryXML = new List<string>();
                        collectorHistoryExport.States = new List<string>();
                        foreach (MonitorState item in ch.StateHistory)
                        {
                            collectorHistoryExport.States.Add(item.ToCXml());
                            statesSaved++;
                        }

                        monitorPackHistoryExport.CollectorHistoryExports.Add(collectorHistoryExport);
                    }
                    string mpser = monitorPackHistoryExport.ToXml();

                    string outputPath = GetMonitorPackMHIFile(monitorPack);
                    System.IO.File.WriteAllText(outputPath, mpser, Encoding.UTF8);
                }
            }
        }
    }
}
