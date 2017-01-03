using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ActionScript
    {
        public string Name { get; set; }
        public bool IsErrorCorrectiveScript { get; set; }
        public bool IsWarningCorrectiveScript { get; set; }
        public bool IsRestorationScript { get; set; }
        public ScriptType ScriptType { get; set; }
        public string Description { get; set; }
        public string Script { get; set; }
        public WindowSizeStyle WindowSizeStyle { get; set; }
        public bool RunAdminMode { get; set; }

        public string ToXml()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<script />");
            xdoc.DocumentElement.SetAttributeValue("name", Name);
            xdoc.DocumentElement.SetAttributeValue("type", ScriptType.ToString());
            xdoc.DocumentElement.SetAttributeValue("description", Description);
            xdoc.DocumentElement.SetAttributeValue("windowStyle", WindowSizeStyle.ToString());
            xdoc.DocumentElement.SetAttributeValue("adminMode", RunAdminMode);
            xdoc.DocumentElement.SetAttributeValue("correctiveErrorScript", IsErrorCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("correctiveWarningScript", IsWarningCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("restorationScript", IsRestorationScript);

            xdoc.DocumentElement.InnerText = Script;

            return xdoc.DocumentElement.OuterXml;
        }
        public static List<ActionScript> FromXml(string config)
        {
            List<ActionScript> scripts = new List<ActionScript>();
            if (config != null && config.Trim().Length > 0)
            {
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                XmlElement root = configXml.DocumentElement;
                foreach (XmlNode scriptItem in root.SelectNodes("script"))
                {
                    try
                    {
                        ActionScript script = new ActionScript();
                        script.Name = scriptItem.ReadXmlElementAttr("name", "");
                        script.ScriptType = ScriptTypeConverter.FromString(scriptItem.ReadXmlElementAttr("type", "dos"));
                        script.Description = scriptItem.ReadXmlElementAttr("description", "");
                        script.WindowSizeStyle = WindowSizeStyleConverter.FromString(scriptItem.ReadXmlElementAttr("windowStyle", "normal"));
                        script.RunAdminMode = scriptItem.ReadXmlElementAttr("adminMode", false);
                        script.IsErrorCorrectiveScript = scriptItem.ReadXmlElementAttr("correctiveErrorScript", false);
                        script.IsWarningCorrectiveScript = scriptItem.ReadXmlElementAttr("correctiveWarningScript", false);
                        script.IsRestorationScript = scriptItem.ReadXmlElementAttr("restorationScript", false);

                        script.Script = scriptItem.InnerText;
                        scripts.Add(script);
                    }
                    catch { }
                }
            }
            return scripts;
        }

        public void Run(bool withPause = false)
        {
            //Script
            //Step one save script as temporary batch/ps1 file
            string safeName = "";            
            string extension = "";
            for(int i=0; i< Name.Length; i++)
            {
                if ( (Name[i] >= 'a' && Name[i] <= 'z') || (Name[i] >= 'A' && Name[i] <= 'Z') || (Name[i] >= '0' && Name[i] <= '9') )
                {
                    safeName += Name[i].ToString();
                }
            }
            if (ScriptType == QuickMon.ScriptType.DOS)
                extension = ".cmd";
            else 
                extension = ".ps1";

            string tmpdirPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Hen IT", "QuickMon 5");
            if (!System.IO.Directory.Exists(tmpdirPath))
                System.IO.Directory.CreateDirectory(tmpdirPath);
            string tmpfilePath = System.IO.Path.Combine(tmpdirPath, safeName + extension);
            string scriptToRun = Script;
            if (withPause)
                scriptToRun = Script + "\r\npause";
            System.IO.File.WriteAllText(tmpfilePath, scriptToRun);

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            if (ScriptType == QuickMon.ScriptType.DOS)
            {
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(tmpfilePath);                
            }
            else
            {
                p.StartInfo = new System.Diagnostics.ProcessStartInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\system32\\WindowsPowerShell\\v1.0\\powershell.exe");
                p.StartInfo.Arguments = "-File \"" + tmpfilePath + "\"";
            }

            if (withPause)
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            else
                p.StartInfo.WindowStyle = (System.Diagnostics.ProcessWindowStyle)WindowSizeStyle;
            
            if (RunAdminMode)
                p.StartInfo.Verb = "runas";
            p.Start();
        }
    }    
}
