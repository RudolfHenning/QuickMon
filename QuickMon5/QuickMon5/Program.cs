using QuickMon.UI;
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

            if (Properties.Settings.Default.ApplicationMasterKey == null || Properties.Settings.Default.ApplicationMasterKey == "")
            {
                Properties.Settings.Default.ApplicationMasterKey = "QuickMon-" + System.Net.Dns.GetHostName();
            }
            if (Properties.Settings.Default.ApplicationUserNameCacheFilePath == null || Properties.Settings.Default.ApplicationUserNameCacheFilePath == "")
            {
                Properties.Settings.Default.ApplicationUserNameCacheFilePath = System.IO.Path.Combine(MonitorPack.GetQuickMonUserDataDirectory(), "QM5MasterKeys.qmmxml");
            }
            if (Properties.Settings.Default.ApplicationUserNameCache == null)
            {
                Properties.Settings.Default.ApplicationUserNameCache = new System.Collections.Specialized.StringCollection();
            }

            if (Properties.Settings.Default.RecentQMConfigFiles == null)
                Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.KnownRemoteHosts == null)
            {
                Properties.Settings.Default.KnownRemoteHosts = new System.Collections.Specialized.StringCollection();
            }
            if (Properties.Settings.Default.GraphLineColors == null)
                Properties.Settings.Default.GraphLineColors = new System.Collections.Specialized.StringCollection();
            if (Properties.Settings.Default.GraphLineColors.Count == 0)
            {
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Red.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Blue.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Green.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.DarkOrange.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.BlueViolet.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.DarkGoldenrod.Name);

                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Aqua.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Yellow.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.LightBlue.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.LightGreen.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.RoyalBlue.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.BlueViolet.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.White.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.LightCyan.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.LightPink.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Lime.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Olive.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.OrangeRed.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.RosyBrown.Name);
                Properties.Settings.Default.GraphLineColors.Add(System.Drawing.Color.Violet.Name);
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

            if (args.Length > 0 && args[0].ToLower().Contains(".qmp")) 
            {
                string qmpFile = args[0];
                if (System.IO.File.Exists(qmpFile))
                {
                    Properties.Settings.Default.LastMonitorPack = qmpFile;
                }
            }

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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Templates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!System.IO.Directory.Exists(Properties.Settings.Default.ScriptRepositoryDirectory))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Properties.Settings.Default.ScriptRepositoryDirectory);
                }
                catch { }
            }
            MainForm mainForm = new MainForm();
            if (args.Length > 0 && args[0].ToLower() == "-new")
            {
                mainForm.StartWithNewMonitorPack = true;
            }
            else if (args.Length > 0 && args[0].ToLower() == "-selectrecent")
            {
                mainForm.StartWithSelectRecent = true;
            }

            if (mainForm.StartWithSelectRecent)
            {
                SelectRecentMonitorPackDialog selectRecentMonitorPackDialog = new SelectRecentMonitorPackDialog();
                if (selectRecentMonitorPackDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.LastMonitorPack = selectRecentMonitorPackDialog.SelectedMonitorPack;
                }
            }

            Application.Run(mainForm);
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
