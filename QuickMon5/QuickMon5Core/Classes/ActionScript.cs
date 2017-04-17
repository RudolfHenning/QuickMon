using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class ActionScript
    {
        public ActionScript()
        {
            //Parameters = new List<ScriptParameter>();
        }
        //public class ScriptParameter
        //{
        //    public string Id { get; set; }
        //    public string DefaultValue { get; set; }
        //    public string DataType { get; set; }

        //    public string ToXml()
        //    {
        //        XmlDocument xdoc = new XmlDocument();
        //        xdoc.LoadXml("<parameter />");
        //        xdoc.DocumentElement.SetAttributeValue("id", Id);
        //        xdoc.DocumentElement.SetAttributeValue("default", DefaultValue);
        //        xdoc.DocumentElement.SetAttributeValue("type", DataType);
        //        return xdoc.DocumentElement.OuterXml;
        //    }
        //    public XmlNode ToXmlNode()
        //    {
        //        XmlDocument xdoc = new XmlDocument();
        //        xdoc.LoadXml("<parameter />");
        //        xdoc.DocumentElement.SetAttributeValue("id", Id);
        //        xdoc.DocumentElement.SetAttributeValue("default", DefaultValue);
        //        xdoc.DocumentElement.SetAttributeValue("type", DataType);
        //        return xdoc.DocumentElement;
        //    }
        //    public static List<ScriptParameter> FromXml(XmlNode parametersNode)
        //    {
        //        List<ScriptParameter> parameters = new List<ScriptParameter>();
        //        if (parametersNode.OuterXml.StartsWith("<parameters"))
        //        {
        //            ScriptParameter sp = new ScriptParameter() { Id = "" };
        //            foreach (XmlNode parameterNode in parametersNode.SelectNodes("parameter"))
        //            {
        //                sp.Id = parameterNode.ReadXmlElementAttr("id", "");
        //                sp.DefaultValue = parameterNode.ReadXmlElementAttr("default", "");
        //                sp.DataType = parameterNode.ReadXmlElementAttr("type", "string");
        //                parameters.Add(sp);
        //            }
        //        }
        //        return parameters;
        //    }
        //}
        //public string Id { get; set; }
        public string Name { get; set; }
        public ScriptType ScriptType { get; set; }
        public string Description { get; set; }
        public WindowSizeStyle WindowSizeStyle { get; set; }
        public bool RunAdminMode { get; set; }
        public string Script { get; set; }
        public bool IsErrorCorrectiveScript { get; set; }
        public bool IsWarningCorrectiveScript { get; set; }
        public bool IsRestorationScript { get; set; }
        //public List<ScriptParameter> Parameters { get; set; }

        public XmlNode ToXmlNode()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<actionScript><scriptText /></actionScript>");
            //xdoc.DocumentElement.SetAttributeValue("id", Id);
            xdoc.DocumentElement.SetAttributeValue("name", Name);
            xdoc.DocumentElement.SetAttributeValue("type", ScriptType.ToString());
            xdoc.DocumentElement.SetAttributeValue("description", Description);
            xdoc.DocumentElement.SetAttributeValue("windowStyle", WindowSizeStyle.ToString());
            xdoc.DocumentElement.SetAttributeValue("adminMode", RunAdminMode);
            xdoc.DocumentElement.SetAttributeValue("correctiveErrorScript", IsErrorCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("correctiveWarningScript", IsWarningCorrectiveScript);
            xdoc.DocumentElement.SetAttributeValue("restorationScript", IsRestorationScript);
            XmlNode scriptTextNode = xdoc.DocumentElement.SelectSingleNode("scriptText");
            scriptTextNode.InnerText = Script;
            //XmlNode parametersNode = xdoc.DocumentElement.SelectSingleNode("parameters");
            //foreach (ScriptParameter parameter in Parameters)
            //{
            //    XmlNode parameterNode = xdoc.ImportNode(parameter.ToXmlNode(), true);
            //    parametersNode.AppendChild(parameterNode);
            //}

            return xdoc.DocumentElement;
        }
        public string ToXml()
        {
            return ToXmlNode().OuterXml;
        }
        public static List<ActionScript> FromXml(XmlNode actionScriptsNode)
        {
            List<ActionScript> scripts = new List<ActionScript>();
            if (actionScriptsNode != null)
            {
                foreach (XmlNode actionScriptNode in actionScriptsNode.SelectNodes("actionScript"))
                {
                    try
                    {
                        ActionScript script = new ActionScript();
                        //script.Id = actionScriptNode.ReadXmlElementAttr("id", "");
                        script.Name = actionScriptNode.ReadXmlElementAttr("name", "");
                        script.ScriptType = ScriptTypeConverter.FromString(actionScriptNode.ReadXmlElementAttr("type", "dos"));
                        script.Description = actionScriptNode.ReadXmlElementAttr("description", "");
                        script.WindowSizeStyle = WindowSizeStyleConverter.FromString(actionScriptNode.ReadXmlElementAttr("windowStyle", "normal"));
                        script.RunAdminMode = actionScriptNode.ReadXmlElementAttr("adminMode", false);
                        script.IsErrorCorrectiveScript = actionScriptNode.ReadXmlElementAttr("correctiveErrorScript", false);
                        script.IsWarningCorrectiveScript = actionScriptNode.ReadXmlElementAttr("correctiveWarningScript", false);
                        script.IsRestorationScript = actionScriptNode.ReadXmlElementAttr("restorationScript", false);
                        //XmlNode parametersNode = actionScriptNode.SelectSingleNode("parameters");
                        //if (parametersNode != null)
                        //{
                        //    script.Parameters = ScriptParameter.FromXml(parametersNode);
                        //}

                        script.Script = actionScriptNode.InnerText;
                        scripts.Add(script);
                    }
                    catch { }
                }
            }
            return scripts;
        }

        public static List<ActionScript> FromXml(string config)
        {
            List<ActionScript> scripts = new List<ActionScript>();
            if (config != null && config.Trim().Length > 0)
            {
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(config);
                scripts = FromXml(configXml.DocumentElement);                
            }
            return scripts;
        }

        //public string Run(bool withPause = false, List<CollectorActionScript.ScriptParameter> CollectorScriptParameters = null)
        //{
        //    string runTimeScript = Script;
        //    foreach (ScriptParameter parameter in Parameters)
        //    {
        //        CollectorActionScript.ScriptParameter currentCollectorScriptParameter = null;
        //        if (CollectorScriptParameters != null)
        //        {
        //            currentCollectorScriptParameter = (from csp in CollectorScriptParameters
        //                                               where csp.Id == parameter.Id
        //                                               select csp).FirstOrDefault();
        //        }
        //        if (currentCollectorScriptParameter != null)
        //        {
        //            runTimeScript = runTimeScript.Replace(parameter.Id, currentCollectorScriptParameter.Value);
        //        }
        //        else
        //        {
        //            runTimeScript = runTimeScript.Replace(parameter.Id, parameter.DefaultValue);
        //        }
        //    }            

        //    Run(runTimeScript, withPause);
        //    return runTimeScript;
        //}
        private void Run(string runtTimeScript, bool withPause)
        {
            //Step one save script as temporary batch/ps1 file
            string safeName = "";
            string extension = "";
            for (int i = 0; i < Name.Length; i++)
            {
                if ((Name[i] >= 'a' && Name[i] <= 'z') || (Name[i] >= 'A' && Name[i] <= 'Z') || (Name[i] >= '0' && Name[i] <= '9'))
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
            string scriptToRun = runtTimeScript;
            if (withPause)
                scriptToRun = runtTimeScript + "\r\npause";
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
        public bool Run(bool withPause = false)
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
                System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\system32\\WindowsPowerShell\\v1.0\\powershell.exe");
                si.Arguments = "-File \"" + tmpfilePath + "\"";
                //si.Arguments = "-NoExit -File \"" + tmpfilePath + "\"";
                //si.UseShellExecute = false;
                //si.RedirectStandardOutput = true;
                //si.RedirectStandardError = true;
                //si.UseShellExecute = false;
                //si.CreateNoWindow = true;

                p.StartInfo = si;

                //p.StartInfo = new System.Diagnostics.ProcessStartInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\system32\\WindowsPowerShell\\v1.0\\powershell.exe");
                //p.StartInfo.Arguments = @"&'" + tmpfilePath + "'";
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.RedirectStandardOutput = true;
                //p.StartInfo.RedirectStandardError = true;
                //p.StartInfo.UseShellExecute = false;
                //p.StartInfo.CreateNoWindow = true;
            }

            if (withPause)
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            else
                p.StartInfo.WindowStyle = (System.Diagnostics.ProcessWindowStyle)WindowSizeStyle;
            
            if (RunAdminMode)
                p.StartInfo.Verb = "runas";
            if (p.Start())
            {
                return true;
            }
            else
            {
                System.Diagnostics.Trace.WriteLine(p.ExitCode);
                return false;
            }
        }
    }    
}
