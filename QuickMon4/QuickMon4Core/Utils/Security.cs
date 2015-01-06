using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace QuickMon
{
    public static class Security
    {
        #region External calls
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        #endregion

        public static bool IsInAdminMode()
        {
            string strIdentity;
            try
            {
                if (System.Environment.OSVersion.Version.Major < 6) //Windows XP or earlier
                    return true;
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
        /// <summary>
        /// Launch in Admin mode and make sure it has Focus!
        /// </summary>
        public static void RestartInAdminMode(string appPath, bool closeCurrentProcess = true)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = appPath;
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
            if (closeCurrentProcess)
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();    
        }
    }
}
