using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace QuickMon.Collectors
{
    public class DynamicWSCollectorConfigEntry : ICollectorConfigEntry
    {
        public DynamicWSCollectorConfigEntry()
        {
            ResultIsSuccess = true;
            Parameters = new List<string>();
        }
        #region Properties
        private string serviceBaseURL = "";
        public string ServiceBaseURL
        {
            get { return serviceBaseURL; }
            set { serviceBaseURL = value; proxy = null; }
        }
        private string serviceBindingName = "";
        public string ServiceBindingName
        {
            get { return serviceBindingName; }
            set { serviceBindingName = value; proxy = null; }
        }
        private string methodName = "";
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; proxy = null; }
        }
        public List<string> Parameters { get; set; }
        public bool ResultIsSuccess { get; set; }
        public WebServiceValueExpectedReturnTypeEnum ValueExpectedReturnType { get; set; }
        public WebServiceMacroFormatTypeEnum MacroFormatType { get; set; }
        public int CheckValueArrayIndex { get; set; }
        public int CheckValueColumnIndex { get; set; }
        public string CheckValueOrMacro { get; set; }
        public bool UseRegEx { get; set; }

        public string ToStringFromParameters()
        {
            string parameters = "";
            if (Parameters != null)
            {
                foreach (string par in Parameters)
                {
                    parameters += par + ",";
                }
                parameters = parameters.TrimEnd(',');
            }
            return parameters;
        }
        public void ParametersFromString(string parametersString)
        {
            Parameters = new List<string>();
            foreach (string par in parametersString.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (par.Trim().Length > 0)
                    Parameters.Add(par);
            }
        }
        public string LastFormattedValue { get; private set; }
        #endregion

        private DynamicProxy proxy = null;
        private List<System.Reflection.ParameterInfo> parameterTypes = new List<System.Reflection.ParameterInfo>();

        #region ICollectorConfigEntry Members
        public string Description
        {
            get { return string.Format("{0}({1}):{2}", ServiceBaseURL, ServiceBindingName, MethodName); }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public string TriggerSummary
        {
            get { return string.Format("Type:{0}{1} Format:{2} Value:{3}", (ResultIsSuccess ? "" : "!"), ValueExpectedReturnType, MacroFormatType, CheckValueOrMacro); }
        }
        #endregion

        public object RunMethod()
        {
            object obj = null;
            if (proxy == null && serviceBaseURL.Length > 0 && serviceBindingName.Length > 0)
            {
                DynamicProxyFactory factory = new DynamicProxyFactory(serviceBaseURL);
                ServiceEndpoint endpoint = (from ep in factory.Endpoints
                                            where ep.Name == serviceBindingName
                                            select ep).FirstOrDefault();
                proxy = factory.CreateProxy(endpoint.Contract.Name);
                //attempt to load data types so parameters can be formatter properly...
                parameterTypes = new List<System.Reflection.ParameterInfo>();
                OperationDescription operation = (from OperationDescription m in endpoint.Contract.Operations
                                                  where m.Name.ToLower() == methodName.ToLower()
                                                  select m).FirstOrDefault();
                if (operation != null) //get method
                {
                    Type proxyType = proxy.ProxyType;
                    System.Reflection.MethodInfo method = (from m in proxyType.GetMethods()
                                                           where m.Name == operation.Name
                                                           select m).FirstOrDefault();
                    foreach (System.Reflection.ParameterInfo parInfo in method.GetParameters())
                    {
                        parameterTypes.Add(parInfo);
                    }
                }
            }
            try
            {
                if (Parameters.Count > 0)
                {
                    List<object> runParameters = new List<object>();
                    for (int i = 0; i < Parameters.Count; i++)
                    {
                        if (i < parameterTypes.Count)
                        {
                            Type pt = parameterTypes[i].ParameterType;
                            
                            switch (pt.Name)
                            {
                                case "Object":
                                    runParameters.Add(Parameters[i]);
                                    break;
                            //    case "Int32":
                            //        runParameters.Add(int.Parse(Parameters[i]));
                            //        break;
                            //    case "Int16":
                            //        runParameters.Add(Int16.Parse(Parameters[i]));
                            //        break;
                            //    case "Double":
                            //        runParameters.Add(Double.Parse(Parameters[i]));
                            //        break;
                            //    case "Boolean":
                            //        runParameters.Add(bool.Parse(Parameters[i]));
                            //        break;
                                default:
                                    var converter = System.ComponentModel.TypeDescriptor.GetConverter(pt);
                                    runParameters.Add(converter.ConvertFrom(Parameters[i]));
                                    break;
                            }                            
                        }
                        else
                            runParameters.Add(Parameters[i]);
                    }
                    obj = proxy.CallMethod(methodName, runParameters.ToArray());
                }
                else
                    obj = proxy.CallMethod(methodName, null);
            }
            catch (Exception ex)
            {
                proxy = null; //set null so it can be retried from scratch
                if (ex.Message.Contains("There was an error downloading"))
                    throw new Exception("Specified web service invalid or not available!", ex);
                if (ex.Message.Contains("Method") && ex.Message.Contains("not found"))
                    throw new Exception("Method '" + methodName + "' not found or parameters invalid!");
                else                
                    throw;
            }
            return obj;
        }
        public CollectorState GetState(object value)
        {
            bool result = false;
            switch (ValueExpectedReturnType)
            {
                case WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly:
                    #region CheckAvailabilityOnly
                    LastFormattedValue = "[Available]";
                    result = true;
                    break; 
                    #endregion
                case WebServiceValueExpectedReturnTypeEnum.SingleValue:
                    #region SingleValue
                    if (value is System.Data.DataSet || value.GetType().IsArray)
                        throw new Exception("Returned value is an array or dataset!");
                    if (value == null)
                        LastFormattedValue = "Null";
                    else if (value.ToString().Length == 0)
                        LastFormattedValue = "Empty";
                    else
                        LastFormattedValue = value.ToString();
                    switch (MacroFormatType)
                    {
                        case WebServiceMacroFormatTypeEnum.None:
                            result = TestValueWithMacro(LastFormattedValue, CheckValueOrMacro);
                            break;
                        case WebServiceMacroFormatTypeEnum.NoValueOnly:
                            result = (value == null || value.ToString().Length == 0);
                            break;
                        case WebServiceMacroFormatTypeEnum.Length:
                            LastFormattedValue = LastFormattedValue.Length.ToString();
                            result = TestValueWithMacro(LastFormattedValue, CheckValueOrMacro);
                            break;
                        default:
                            result = TestValueWithMacro(LastFormattedValue, CheckValueOrMacro);
                            break;
                    }
                    break; 
                    #endregion
                case WebServiceValueExpectedReturnTypeEnum.Array:
                    #region Array
                    if (!value.GetType().IsArray)
                        throw new Exception("Returned value is not an array!");
                    Array arr = (Array)value;
                    switch (MacroFormatType)
                    {
                        case WebServiceMacroFormatTypeEnum.Count:
                            LastFormattedValue = arr.Length.ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.FirstValue:
                            LastFormattedValue = arr.GetValue(0).ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.LastValue:
                            LastFormattedValue = arr.GetValue(arr.Length - 1).ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.Sum:
                            double sum = 0;
                            foreach (var arrEntry in arr)
                            {
                                if (arrEntry.IsNumber())
                                    sum += double.Parse(arrEntry.ToString());
                            }
                            LastFormattedValue = sum.ToString();
                            break;
                        default:
                            if (CheckValueArrayIndex > 0 && CheckValueArrayIndex < arr.Length)
                                LastFormattedValue = arr.GetValue(CheckValueArrayIndex).ToString();
                            else
                                LastFormattedValue = arr.GetValue(0).ToString();
                            break;
                    }
                    result = TestValueWithMacro(LastFormattedValue, CheckValueOrMacro);
                    break; 
                    #endregion
                case WebServiceValueExpectedReturnTypeEnum.DataSet:
                    #region DataSet
                    if (!(value is System.Data.DataSet))
                        throw new Exception("Returned value is not a DataSet!");
                    else
                    {
                        System.Data.DataSet ds = (System.Data.DataSet)value;
                        if (ds.Tables.Count == 0)
                            throw new Exception("DataSet contains no tables!");
                        else
                        {
                            System.Data.DataTable tab = ds.Tables[0];
                            switch (MacroFormatType)
                            {
                                case WebServiceMacroFormatTypeEnum.Count:
                                    LastFormattedValue = tab.Rows.Count.ToString();
                                    break;
                                case WebServiceMacroFormatTypeEnum.FirstValue:
                                    LastFormattedValue = tab.Rows[0][0].ToString();
                                    break;
                                case WebServiceMacroFormatTypeEnum.LastValue:
                                    LastFormattedValue = tab.Rows[tab.Rows.Count - 1][tab.Columns.Count - 1].ToString();
                                    break;
                                default:
                                    if (CheckValueArrayIndex >= 0 && CheckValueArrayIndex < tab.Rows.Count && CheckValueColumnIndex >= 0 && CheckValueColumnIndex < tab.Columns.Count)
                                        LastFormattedValue = tab.Rows[CheckValueArrayIndex][CheckValueColumnIndex].ToString();
                                    else
                                        LastFormattedValue = tab.Rows[0][0].ToString();
                                    break;
                            }                            
                        }
                        result = TestValueWithMacro(LastFormattedValue, CheckValueOrMacro);
                    }
                    break;
                    #endregion
                default:
                    throw new Exception("Expected return value type not specified!");
            }
            return (ResultIsSuccess == result) ? CollectorState.Good : CollectorState.Error;
        }
        private bool TestValueWithMacro(string value, string macroOrTestValue)
        {
            bool result = false;
            if (UseRegEx)
            {
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(value, macroOrTestValue, System.Text.RegularExpressions.RegexOptions.Multiline);
                result = match.Success;
            }
            else
            {
                if (!macroOrTestValue.StartsWith("[")) //compare raw value
                {
                    result = value.ToString() == macroOrTestValue;
                }
                else if (macroOrTestValue.ToLower().StartsWith("[between]") && macroOrTestValue.ToLower().Contains("[and]"))
                {
                    string[] queryItems = macroOrTestValue.Split(' ');
                    if (value.IsNumber() && queryItems.Length == 4 && queryItems[1].IsNumber() && queryItems[3].IsNumber())
                        result = (double.Parse(queryItems[1]) < double.Parse(value.ToString()))
                            && (double.Parse(value.ToString()) < double.Parse(queryItems[3]));
                    else
                        throw new Exception("Value is not a number or macro syntax invalid!");
                }
                else if (macroOrTestValue.ToLower().StartsWith("[largerthan]"))
                {
                    string macroValue = macroOrTestValue.ToLower().Replace("[largerthan]", "").Trim();
                    if (value.IsNumber() && macroValue.IsNumber())
                        result = (double.Parse(macroValue) < double.Parse(value.ToString()));
                    else
                        throw new Exception("Value is not a number or check value contains invalid macro!");
                }
                else if (macroOrTestValue.ToLower().StartsWith("[smallerthan]"))
                {
                    string macroValue = macroOrTestValue.ToLower().Replace("[smallerthan]", "").Trim();
                    if (value.IsNumber() && macroValue.IsNumber())
                        result = (double.Parse(macroValue) > double.Parse(value.ToString()));
                    else
                        throw new Exception("Value is not a number or check value cotains invalid macro!");
                }
                else if (macroOrTestValue.ToLower().StartsWith("[contains]"))
                {
                    string macroValue = macroOrTestValue.ToLower().Replace("[contains]", "").Trim();
                    if (macroValue.StartsWith(" "))
                        macroValue = macroValue.Substring(1);
                    result = value.ToLower().Contains(macroValue);
                }
                else if (macroOrTestValue.ToLower().StartsWith("[beginswith]"))
                {
                    string macroValue = macroOrTestValue.ToLower().Replace("[beginswith]", "").Trim();
                    if (macroValue.StartsWith(" "))
                        macroValue = macroValue.Substring(1);
                    result = value.ToLower().StartsWith(macroValue);
                }
                else if (macroOrTestValue.ToLower().StartsWith("[endswith]"))
                {
                    string macroValue = macroOrTestValue.ToLower().Replace("[endswith]", "").Trim();
                    if (macroValue.StartsWith(" "))
                        macroValue = macroValue.Substring(1);
                    result = value.ToLower().EndsWith(macroValue);
                }
            }
            return result;
        }
    }
}
