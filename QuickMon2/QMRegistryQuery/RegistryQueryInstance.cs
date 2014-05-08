using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace QuickMon
{
    public class RegistryQueryInstance
    {
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
        public MonitorStates EvaluateValue(object value)
        {
            MonitorStates result = MonitorStates.Good;
            if (value == null || value == DBNull.Value)
            {
                if (ErrorValue == "[null]")
                    result = MonitorStates.Error;
                else if (WarningValue == "[null]")
                    result = MonitorStates.Warning;
                else if (SuccessValue == "[null]")
                    result = MonitorStates.Good;
                else if (SuccessValue != "[any]")
                    result = MonitorStates.Error;
            }
            else if (value.ToString() == "[notExists]")
            {
                if (ErrorValue == "[notExists]")
                    result = MonitorStates.Error;
                else if (WarningValue == "[notExists]")
                    result = MonitorStates.Warning;
                else if (SuccessValue == "[notExists]")
                    result = MonitorStates.Good;
                else
                    result = MonitorStates.Error;
            }
            else //non empty value but it DOES exist
            {
                if (!ReturnValueIsNumber || !ReturnValueInARange) //so it's not a number
                {
                    //first eliminate matching values
                    if (SuccessValue == value.ToString())
                        result = MonitorStates.Good;
                    else if (value.ToString() == ErrorValue)
                        result = MonitorStates.Error;
                    else if (value.ToString() == WarningValue)
                        result = MonitorStates.Warning;

                    //Existing tests
                    else if (ErrorValue == "[exists]")
                        result = MonitorStates.Error;
                    else if (WarningValue == "[exists]")
                        result = MonitorStates.Warning;
                    else if (SuccessValue == "[exists]")
                        result = MonitorStates.Good;

                    //Any tests
                    else if (ErrorValue == "[any]")
                        result = MonitorStates.Error;
                    else if (WarningValue == "[any]")
                        result = MonitorStates.Warning;

                    //Not matching success
                    else if (SuccessValue != "[any]")
                        result = MonitorStates.Warning;
                }
                else if (!value.IsNumber()) //value must be a number!
                {
                    result = MonitorStates.Error;
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
                        result = MonitorStates.Error;
                    }
                    else if (WarningValue != "[any]" && WarningValue != "[null]" &&
                           (
                            (!ReturnValueInverted && double.Parse(value.ToString()) >= double.Parse(WarningValue)) ||
                            (ReturnValueInverted && double.Parse(value.ToString()) <= double.Parse(WarningValue))
                           )
                        )
                    {
                        result = MonitorStates.Warning;
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
    }
}
