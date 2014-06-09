using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HenIT.Console;

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

            if (Properties.Settings.Default.RecentQMConfigFiles == null)
                Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.KnownRemoteHosts == null)
            {
                Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            }

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Copy installed presets to user's application data directory
            try
            {
                if (!System.IO.File.Exists(MonitorPack.GetQuickMonUserDataTemplatesFile()))
                {
                    string commonAppData = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Hen IT\\QuickMon 3");
                    List<AgentPresetConfig> presets = AgentPresetConfig.ReadPresetsFromDirectory(commonAppData);
                    AgentPresetConfig.SaveAllPresetsToFile(presets);
                }

                //string commonAppData = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Hen IT\\QuickMon 3");
                //string userAppData = MonitorPack.GetQuickMonUserDataDirectory();// System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hen IT\\QuickMon 3");
                //if(System.IO.Directory.Exists(commonAppData))
                //{
                //    if (!System.IO.Directory.Exists(userAppData))
                //    {
                //        //attempt to create directory
                //        System.IO.Directory.CreateDirectory(userAppData);
                //    }

                //    //Now copy any non existing preset files
                //    if (System.IO.Directory.Exists(userAppData))
                //    {
                //        foreach(string commonPresetFilePath in System.IO.Directory.GetFiles(commonAppData, "*.qps"))
                //        {
                //            string fileNameOnly = System.IO.Path.GetFileName(commonPresetFilePath);
                //            string userPresetFilePath = System.IO.Path.Combine(userAppData, fileNameOnly);
                //            if (!System.IO.File.Exists(userPresetFilePath))
                //            {
                //                System.IO.File.Copy(commonPresetFilePath, userPresetFilePath);
                //            }
                //        }
                //    }
                //}
            }
            catch { }

            //if application is launched with qmconfig file set it as last Monitor pack
            if (args.Length > 0 && System.IO.File.Exists(args[0]) && (args[0].ToLower().EndsWith(".qmconfig") || args[0].ToLower().EndsWith(".qmp")))
                Properties.Settings.Default.LastMonitorPack = args[0];

            Application.Run(new MainForm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (MessageBox.Show("An unhandled application error occured!\r\nDo you want to close the application?\r\n" + e.Exception.ToString(), "Application error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
