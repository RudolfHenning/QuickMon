using System;
using System.Collections.Generic;
using System.Linq;
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
            if (Properties.Settings.Default.NewVersion)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.NewVersion = false;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.RecentQMConfigFiles == null)
                Properties.Settings.Default.RecentQMConfigFiles = new System.Collections.Specialized.StringCollection();

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainForm = new MainForm();
            foreach (string arg in args)
            {
                if (arg.ToUpper().EndsWith(".QMCONFIG") && System.IO.File.Exists(arg))
                    Properties.Settings.Default.LastMonitorPack = arg;
            }
            Application.Run(mainForm);
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
