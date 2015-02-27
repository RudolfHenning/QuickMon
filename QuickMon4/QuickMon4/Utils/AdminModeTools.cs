using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using tsEngine = TaskScheduler;

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

        public static bool CheckIfAdminLaunchTaskExist(string appTaskId = "")
        {
            try
            {
                if (appTaskId == null || appTaskId.Length == 0)
                {
                    string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    appTaskId = "Run" + exeName + "InAdminMode";
                }

                tsEngine.TaskScheduler ts = new tsEngine.TaskScheduler();
                ts.Connect(null, null, null, null);
                if (ts.Connected)
                {
                    tsEngine.ITaskFolder root = ts.GetFolder("\\");
                    tsEngine.IRegisteredTask task = root.GetTask(appTaskId);
                    if (task != null)
                        return true;
                }
            }
            catch { }
            return false;
        }
        public static bool IsAdminLaunchTaskAlreadyRunning(string appTaskId = "")
        {
            try
            {
                if (appTaskId == null || appTaskId.Length == 0)
                {
                    string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    appTaskId = "Run" + exeName + "InAdminMode";
                }

                tsEngine.TaskScheduler ts = new tsEngine.TaskScheduler();
                ts.Connect(null, null, null, null);
                if (ts.Connected)
                {
                    foreach (tsEngine.IRunningTask td in ts.GetRunningTasks(0))
                    {
                        if (td.Name == appTaskId)
                            return true;
                    }
                }
            }
            catch { }
            return false;
        }
        public static void CreateAdminLaunchTask(string appTaskId = "")
        {
            if (appTaskId == null || appTaskId.Length == 0)
            {
                string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                appTaskId = "Run" + exeName + "InAdminMode";
            }
            if (IsInAdminMode())
            {
                tsEngine.TaskScheduler ts = new tsEngine.TaskScheduler();
                ts.Connect(null, null, null, null);
                if (ts.Connected)
                {
                    tsEngine.ITaskDefinition task = ts.NewTask(0);
                    task.RegistrationInfo.Author = "Mine";
                    task.RegistrationInfo.Description = appTaskId;
                    task.Principal.RunLevel = tsEngine._TASK_RUNLEVEL.TASK_RUNLEVEL_HIGHEST;
                    task.Settings.MultipleInstances = tsEngine._TASK_INSTANCES_POLICY.TASK_INSTANCES_PARALLEL;
                    tsEngine.ITimeTrigger trigger = (tsEngine.ITimeTrigger)task.Triggers.Create(tsEngine._TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
                    trigger.Id = "NoTime";
                    trigger.StartBoundary = "2000-01-01T12:00:00";
                    trigger.StartBoundary = "2000-01-01T12:00:00";
                    tsEngine.IExecAction action = (tsEngine.IExecAction)task.Actions.Create(tsEngine._TASK_ACTION_TYPE.TASK_ACTION_EXEC);
                    action.Id = "Run exe";
                    action.Path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                    action.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    tsEngine.ITaskFolder root = ts.GetFolder("\\");
                    tsEngine.IRegisteredTask regTask = root.RegisterTaskDefinition(
                        appTaskId,
                        task,
                        (int)tsEngine._TASK_CREATION.TASK_CREATE_OR_UPDATE,
                        null,
                        null,
                        tsEngine._TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN);
                }
            }
            else
            {
                throw new Exception("To create the admin mode task you must start this program in 'Admin' mode.");
            }
        }
        public static void DeleteAdminLaunchTask(string appTaskId = "")
        {
            if (appTaskId == null || appTaskId.Length == 0)
            {
                string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                appTaskId = "Run" + exeName + "InAdminMode";
            }
            if (IsInAdminMode())
            {
                if (CheckIfAdminLaunchTaskExist(appTaskId))
                {
                    tsEngine.TaskScheduler ts = new tsEngine.TaskScheduler();
                    ts.Connect(null, null, null, null);
                    if (ts.Connected)
                    {
                        tsEngine.ITaskFolder root = ts.GetFolder("\\");
                        tsEngine.IRegisteredTask task = root.GetTask(appTaskId);
                        if (task != null)
                        {
                            root.DeleteTask(appTaskId, 0);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("To delete the admin mode task you must start this program in 'Admin' mode.");
            }
        }
        public static void ReStartWithAdminModeLaunchTask(string appTaskId = "")
        {
            StartWithAdminModeLaunchTask(appTaskId);
            Application.Exit();
        }
        public static void StartWithAdminModeLaunchTask(string appTaskId = "")
        {
            if (appTaskId == null || appTaskId.Length == 0)
            {
                string exeName = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location);
                appTaskId = "Run" + exeName + "InAdminMode";
            }
            if (CheckIfAdminLaunchTaskExist(appTaskId))
            {
                //if (!IsAdminLaunchTaskAlreadyRunning())
                {
                    tsEngine.TaskScheduler ts = new tsEngine.TaskScheduler();
                    ts.Connect(null, null, null, null);
                    if (ts.Connected)
                    {
                        tsEngine.ITaskFolder root = ts.GetFolder("\\");
                        tsEngine.IRegisteredTask task = root.GetTask(appTaskId);
                        tsEngine.IRunningTask runTask = task.Run(null);
                    }
                }
                //else
                //{
                //    throw new Exception("The task is already running!");
                //}
            }
            else
            {
                throw new Exception("Admin mode Launch task does not exist yet!");
            }
        }

        public static void RestartInAdminMode()
        {
            if (!IsInAdminMode())
            {
                //Only Vista or higher
                if ((System.Environment.OSVersion.Version.Major >= 6) && CheckIfAdminLaunchTaskExist())
                {
                    ReStartWithAdminModeLaunchTask();
                }
                else
                {
                    RestartInAdminModeWithUACPrompt();
                }
            }
        }
        /// <summary>
        /// Launch in Admin mode with UAC prompt and make sure it has Focus!
        /// </summary>
        public static void RestartInAdminModeWithUACPrompt()
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
    }
}
