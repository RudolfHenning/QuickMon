using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;

namespace HenIT.ShellTools
{
    public static class Shortcuts
    {
        #region Desktop shortcut
        public static bool DesktopShortCutExists(string fileName = "")
        {
            if (fileName == null || fileName.Length == 0)
                fileName = System.Reflection.Assembly.GetEntryAssembly().Location;

            string fileNamelnk = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), System.IO.Path.GetFileNameWithoutExtension(fileName) + ".lnk");
            string fileNameurl = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), System.IO.Path.GetFileNameWithoutExtension(fileName) + ".url");

            if (System.IO.File.Exists(fileNamelnk))
                return true;
            else if (System.IO.File.Exists(fileNameurl))
                return true;
            else
                return false;
        }
        public static void CreateDesktopShortcut(string exeFileName = "", string linkName = "")
        {
            if (exeFileName == null || exeFileName.Length == 0)
                exeFileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (linkName == null || linkName.Length == 0)
                linkName = exeFileName;

            string fileNameurl = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), System.IO.Path.GetFileNameWithoutExtension(linkName) + ".url");
            using (StreamWriter writer = new StreamWriter(fileNameurl))
            {
                string app = exeFileName;
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + app);
                writer.WriteLine("IconIndex=0");
                string icon = app.Replace('\\', '/');
                writer.WriteLine("IconFile=" + icon);
                writer.Flush();
            }
        }
        public static void DeleteDesktopShortcut(string exeFileName = "", string linkName = "")
        {
            if (exeFileName == null || exeFileName.Length == 0)
                exeFileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (linkName == null || linkName.Length == 0)
                linkName = exeFileName;

            string fileNamelnk = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), System.IO.Path.GetFileNameWithoutExtension(linkName) + ".lnk");
            string fileNameurl = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), System.IO.Path.GetFileNameWithoutExtension(linkName) + ".url");

            if (System.IO.File.Exists(fileNamelnk))
                System.IO.File.Delete(fileNamelnk);
            else if (System.IO.File.Exists(fileNameurl))
                System.IO.File.Delete(fileNameurl);
        } 
        #endregion

        #region Taskbar shortcut
        public static bool TaskBarShortCutExists(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;

            string pinLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\TaskBar");
            pinLocation = System.IO.Path.Combine(pinLocation, System.IO.Path.GetFileNameWithoutExtension(exeFilePath) + ".lnk");
            return System.IO.File.Exists(pinLocation);
        }
        public static void PinToTaskBar(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            PinUnpinTaskBar(exeFilePath, true);
        }
        public static void UnPinToTaskBar(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            PinUnpinTaskBar(exeFilePath, false);
        }
        private static void PinUnpinTaskBar(string filePath, bool pin)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            // create the shell application object
            Shell shellApplication = new Shell();

            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            Folder directory = shellApplication.NameSpace(path);
            FolderItem link = directory.ParseName(fileName);

            FolderItemVerbs verbs = link.Verbs();
            for (int i = 0; i < verbs.Count; i++)
            {
                FolderItemVerb verb = verbs.Item(i);
                string verbName = verb.Name.Replace(@"&", string.Empty).ToLower();

                if ((pin && verbName.Equals("pin to taskbar")) || (!pin && verbName.Equals("unpin from taskbar")))
                {
                    verb.DoIt();
                }
            }

            shellApplication = null;
        } 
        #endregion

        #region Start Menu shortcut
        public static bool StartMenuShortCutExists(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;

            string pinLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Internet Explorer\\Quick Launch\\User Pinned\\StartMenu");
            pinLocation = System.IO.Path.Combine(pinLocation, System.IO.Path.GetFileNameWithoutExtension(exeFilePath) + ".lnk");
            return System.IO.File.Exists(pinLocation);
        }
        public static void PinToStartMenu(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            PinUnpinStartMenu(exeFilePath, true);
        }
        public static void UnPinToStartMenu(string exeFilePath = "")
        {
            if (exeFilePath == null || exeFilePath.Length == 0)
                exeFilePath = System.Reflection.Assembly.GetEntryAssembly().Location;
            PinUnpinStartMenu(exeFilePath, false);
        }
        private static void PinUnpinStartMenu(string filePath, bool pin)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            // create the shell application object
            Shell shellApplication = new Shell();

            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            Folder directory = shellApplication.NameSpace(path);
            FolderItem link = directory.ParseName(fileName);

            FolderItemVerbs verbs = link.Verbs();
            for (int i = 0; i < verbs.Count; i++)
            {
                FolderItemVerb verb = verbs.Item(i);
                string verbName = verb.Name.Replace(@"&", string.Empty).ToLower();

                if ((pin && verbName.Equals("pin to start menu")) || (!pin && verbName.Equals("unpin from start menu")))
                {
                    verb.DoIt();
                }
            }
            shellApplication = null;
        }  
        #endregion
    }
}
