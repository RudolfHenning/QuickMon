using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace QuickMon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (Properties.Settings.Default.NewVersion)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NewVersion = false; 
                Properties.Settings.Default.Save();
            }

            MonitorPack monitorPack = new MonitorPack();
            if (args.Length > 0 && args[0].ToLower().EndsWith(".qmconfig"))
            {
                if (File.Exists(args[0]))
                {
                    monitorPack.Load(args[0]);
                }
            }
            else
            {
                if (Properties.Settings.Default.LastMonitorPackPath != null && File.Exists(Properties.Settings.Default.LastMonitorPackPath))
                    monitorPack.Load(Properties.Settings.Default.LastMonitorPackPath);
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Management.MonitorPackManagement monitorPackManagement = new Management.MonitorPackManagement();
            if (monitorPackManagement.ShowMonitorPack(monitorPack) == DialogResult.OK)
            {
                Properties.Settings.Default.LastMonitorPackPath = monitorPackManagement.MonitorPackPath;
                Properties.Settings.Default.Save();
            }
        }
    }
}
