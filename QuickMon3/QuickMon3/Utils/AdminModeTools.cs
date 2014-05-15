using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Diagnostics;
using System.Windows.Forms;

namespace HenIT.Security
{
    public static class AdminModeTools
    {
        #region External calls
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        #endregion

        /// <summary>
        /// Launch in Admin mode and make sure it has Focus!
        /// </summary>
        public static void RestartInAdminMode()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
                System.Threading.Thread.Sleep(1000);
                ShowWindow(p.MainWindowHandle, 5);
                p.WaitForInputIdle(); //this is the key!!
                System.Threading.Thread.Sleep(500);
                SetForegroundWindow(p.MainWindowHandle);
            }
            catch (System.ComponentModel.Win32Exception) // ex)
            {
                return;
            }

            Application.Exit();
        }

        public static void RestartInAdminMode(bool noprompt)
        {            
            if (noprompt || MessageBox.Show("Restart application in Administrative mode?", "Admin mode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;

                startInfo.Verb = "runas";
                try
                {
                    Process p = Process.Start(startInfo);
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.ToString());
                    return;
                }
                Application.Exit();
            }
        }
        public static bool IsInAdminMode()
        {
            string strIdentity;
            try
            {
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                WindowsPrincipal wp = new WindowsPrincipal(wi);
                strIdentity = wp.Identity.Name;

                if (wp.IsInRole(WindowsBuiltInRole.Administrator))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
