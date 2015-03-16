using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

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

            try
            {
                if (HenIT.Security.AdminModeTools.IsInAdminMode())
                {
                    if (Properties.Settings.Default.DisableAutoAdminMode)
                        HenIT.Security.AdminModeTools.DeleteAdminLaunchTask(AppGlobals.AppTaskId);
                    else 
                        HenIT.Security.AdminModeTools.CreateAdminLaunchTask(AppGlobals.AppTaskId);
                }
            }
            catch { }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0 && System.IO.File.Exists(args[0]) && (args[0].ToLower().EndsWith(".qmp") || args[0].ToLower().EndsWith(".qmp4")))
                Properties.Settings.Default.LastMonitorPack = args[0];

            try
            {
                if (!System.IO.File.Exists(MonitorPack.GetQuickMonUserDataTemplatesFile()))
                {
                    try
                    {
                        QuickMonTemplate.ResetTemplates();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (MessageBox.Show("An unhandled application error occured!\r\nDo you want to close the application?\r\n" + e.ExceptionObject.ToString(), "Application error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Application.Exit();
            }
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
