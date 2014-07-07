using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace QuickMon.Collectors
{
    public class RegistryQueryInstance : ICollectorConfigEntry
    {       
        #region ICollectorConfigEntry Members
        public string Description
        {
            get
            {
                return (UseRemoteServer ? Server + "\\" : "") + GetRegistryHiveFromString(RegistryHive.ToString()).ToString() + "\\" + Path + "\\[" + KeyName + "]";
            }
        }
        public string TriggerSummary
        {
            get
            {
                return string.Format("Success: {0}, Warn: {1}, Err: {2}", SuccessValue, WarningValue, ErrorValue);
            }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        #endregion

        #region Properties
        public string Name { get; set; }
        public bool UseRemoteServer { get; set; }
        public string Server { get; set; }
        public RegistryHive RegistryHive { get; set; }
        public string Path { get; set; }
        public string KeyName { get; set; }
        public bool ExpandEnvironmentNames { get; set; }
        public bool ReturnValueIsNumber { get; set; }
        public bool ReturnValueInARange { get; set; }
        public bool ReturnValueInverted { get; set; }
        public string SuccessValue { get; set; }
        public string WarningValue { get; set; }
        public string ErrorValue { get; set; }
        #endregion

        #region Static methods
        public static RegistryHive GetRegistryHiveFromString(string registryHiveName)
        {
            if (registryHiveName.IndexOf("LocalMachine", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_LOCAL_MACHINE", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.LocalMachine;
            }
            else if (registryHiveName.IndexOf("ClassesRoot", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CLASSES_ROOT", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.ClassesRoot;
            }
            else if (registryHiveName.IndexOf("CurrentConfig", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CURRENT_CONFIG", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.CurrentConfig;
            }
            else if (registryHiveName.IndexOf("Users", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_USERS", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.Users;
            }
            else if (registryHiveName.IndexOf("CurrentUser", StringComparison.CurrentCultureIgnoreCase) > -1 ||
                registryHiveName.IndexOf("HKEY_CURRENT_USER", StringComparison.CurrentCultureIgnoreCase) > -1)
            {
                return Microsoft.Win32.RegistryHive.CurrentUser;
            }
            else
                return Microsoft.Win32.RegistryHive.LocalMachine;
        }
        #endregion

        #region Public methods
        public CollectorState EvaluateValue(object value)
        {
            CollectorState result = CollectorState.Good;
            if (value == null || value == DBNull.Value)
            {
                if (ErrorValue == "[null]")
                    result = CollectorState.Error;
                else if (WarningValue == "[null]")
                    result = CollectorState.Warning;
                else if (SuccessValue == "[null]")
                    result = CollectorState.Good;
                else if (SuccessValue != "[any]")
                    result = CollectorState.Error;
            }
            else if (value.ToString() == "[notExists]")
            {
                if (ErrorValue == "[notExists]")
                    result = CollectorState.Error;
                else if (WarningValue == "[notExists]")
                    result = CollectorState.Warning;
                else if (SuccessValue == "[notExists]")
                    result = CollectorState.Good;
                else
                    result = CollectorState.Error;
            }
            else //non empty value but it DOES exist
            {
                if (!ReturnValueIsNumber || !ReturnValueInARange) //so it's not a number
                {
                    if (value.GetType().IsArray)
                    {
                        value = FormatUtils.FormatArrayToString(value);
                        //StringBuilder sb = new StringBuilder();
                        //if (value is Byte[]) //binary data
                        //{
                        //    Byte[] valArr = (Byte[])value;                            
                        //    for(int i = 0; i < valArr.Length; i++)
                        //    {
                        //        sb.AppendFormat("{0:x2}", valArr[i]).Append(",");
                        //    }
                        //    value = sb.ToString().Trim(',');
                        //}
                        //else if (value is string[])
                        //{
                        //    string[] valArr = (string[])value;
                        //    foreach (string line in valArr)
                        //        sb.AppendLine(line);
                        //    value = sb.ToString().TrimEnd('\r','\n');
                        //}
                    }

                    //first eliminate matching values
                    if (SuccessValue == value.ToString())
                        result = CollectorState.Good;
                    else if (value.ToString() == ErrorValue)
                        result = CollectorState.Error;
                    else if (value.ToString() == WarningValue)
                        result = CollectorState.Warning;

                    //test for [contains] <value>, [beginswith] <value> or [endswith] <value>
                    else if (SuccessValue.StartsWith("[contains]") && value.ToString().Contains(SuccessValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (SuccessValue.StartsWith("[beginswith]") && value.ToString().StartsWith(SuccessValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (SuccessValue.StartsWith("[endswith]") && value.ToString().EndsWith(SuccessValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[contains]") && value.ToString().Contains(WarningValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[beginswith]") && value.ToString().StartsWith(WarningValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (WarningValue.StartsWith("[endswith]") && value.ToString().EndsWith(WarningValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[contains]") && value.ToString().Contains(ErrorValue.Substring(("[contains]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[beginswith]") && value.ToString().StartsWith(ErrorValue.Substring(("[beginswith]").Length).Trim()))
                        result = CollectorState.Good;
                    else if (ErrorValue.StartsWith("[endswith]") && value.ToString().EndsWith(ErrorValue.Substring(("[endswith]").Length).Trim()))
                        result = CollectorState.Good;

                    //Existing tests
                    else if (ErrorValue == "[exists]")
                        result = CollectorState.Error;
                    else if (WarningValue == "[exists]")
                        result = CollectorState.Warning;
                    else if (SuccessValue == "[exists]")
                        result = CollectorState.Good;

                    //Any tests
                    else if (ErrorValue == "[any]")
                        result = CollectorState.Error;
                    else if (WarningValue == "[any]")
                        result = CollectorState.Warning;

                    //Not matching success
                    else if (SuccessValue != "[any]")
                        result = CollectorState.Warning;
                }
                else if (!value.IsNumber()) //value must be a number!
                {
                    result = CollectorState.Error;
                }
                else //so it is a number and must be inside a range
                {
                    if (ErrorValue != "[any]" && ErrorValue != "[null]" &&
                                    (
                                     (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(ErrorValue)) ||
                                     (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(ErrorValue))
                                    )
                                )
                    {
                        result = CollectorState.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(WarningValue)) ||
                            (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(WarningValue))
                           )
                        )
                    {
                        result = CollectorState.Warning;
                    }
                }
            }

            return result;
        }
        public object GetValue()
        {
            object result = null;
            RegistryKey remoteKey = null;
            if (UseRemoteServer)
            {
                remoteKey = RegistryKey.OpenRemoteBaseKey(RegistryHive, Server);
            }
            else
                remoteKey = RegistryKey.OpenBaseKey(RegistryHive, RegistryView.Default);

            if (remoteKey != null)
            {
                RegistryKey valKey = remoteKey.OpenSubKey(Path);
                if (valKey != null)
                {
                    result = valKey.GetValue(KeyName, "[notExists]", ExpandEnvironmentNames ? RegistryValueOptions.None : RegistryValueOptions.DoNotExpandEnvironmentNames);
                }
                else
                {
                    result = "[notExists]";
                }
            }
            else
            {
                result = "[notExists]";
            }
            return result;
        }
        #endregion

        public override string ToString()
        {
            return (UseRemoteServer ? Server + "\\" : "") + GetRegistryHiveFromString(RegistryHive.ToString()).ToString() + "\\" + Path;
        }
    }
}
