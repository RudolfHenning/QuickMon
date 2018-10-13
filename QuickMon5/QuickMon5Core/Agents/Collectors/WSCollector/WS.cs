using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace QuickMon.Collectors
{
    [Description("Web Service Collector"), Category("General")]
    public class WSCollector : CollectorAgentBase
    {
        public WSCollector()
        {
            AgentConfig = new WSCollectorConfig();
        }

        //public override List<System.Data.DataTable> GetDetailDataTables()
        //{
        //    List<System.Data.DataTable> tables = new List<System.Data.DataTable>();
        //    System.Data.DataTable dt = new System.Data.DataTable();
        //    try
        //    {
        //        dt.Columns.Add(new System.Data.DataColumn("Web service", typeof(string)));
        //        dt.Columns.Add(new System.Data.DataColumn("Response", typeof(string)));

        //        WSCollectorConfig currentConfig = (WSCollectorConfig)AgentConfig;
        //        foreach (WSCollectorConfigEntry entry in currentConfig.Entries)
        //        {
        //            object wsData = "N/A";
        //            try
        //            {
        //                wsData = entry.RunMethod();
        //            }
        //            catch (Exception ex)
        //            {
        //                wsData = ex.Message;
        //            }
        //            dt.Rows.Add(entry.Description, wsData.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dt = new System.Data.DataTable("Exception");
        //        dt.Columns.Add(new System.Data.DataColumn("Text", typeof(string)));
        //        dt.Rows.Add(ex.ToString());
        //    }
        //    tables.Add(dt);
        //    return tables;
        //}
    }

    public class WSCollectorConfig : ICollectorConfig
    {
        public WSCollectorConfig()
        {
            Entries = new List<ICollectorConfigEntry>();
        }

        #region ICollectorConfig Members
        public bool SingleEntryOnly { get { return false; } }
        public List<ICollectorConfigEntry> Entries { get; set; }
        #endregion

        #region IAgentConfig Members
        public void FromXml(string configurationString)
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(configurationString);
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("webServices/webService"))
            {
                WSCollectorConfigEntry webServicePingEntry = new WSCollectorConfigEntry();
                webServicePingEntry.ServiceBaseURL = addressNode.ReadXmlElementAttr("url", "");
                webServicePingEntry.ServiceBindingName = addressNode.ReadXmlElementAttr("serviceBindingName", "");
                webServicePingEntry.MethodName = addressNode.ReadXmlElementAttr("method");
                string parameterStr = addressNode.ReadXmlElementAttr("paramatersCSV");
                webServicePingEntry.Parameters = new List<string>();
                if (parameterStr.Trim().Length > 0)
                    webServicePingEntry.Parameters.AddRange(parameterStr.Split(','));
                //webServicePingEntry.ResultIsSuccess = addressNode.ReadXmlElementAttr("resultIsSuccess", true);
                webServicePingEntry.ValueExpectedReturnType = WebServiceValueExpectedReturnTypeConverter.FromString(addressNode.ReadXmlElementAttr("valueExpectedReturnType", ""));
                webServicePingEntry.MacroFormatType = WebServiceMacroFormatTypeConverter.FromString(addressNode.ReadXmlElementAttr("macroFormatType", ""));
                webServicePingEntry.CheckValueArrayIndex = addressNode.ReadXmlElementAttr("arrayIndex", 0);
                webServicePingEntry.CheckValueColumnIndex = addressNode.ReadXmlElementAttr("columnIndex", 0);

                if (addressNode.ReadXmlElementAttr("resultIsSuccess", true))
                    webServicePingEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;
                else
                    webServicePingEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.EWG;

                webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.Contains;
                webServicePingEntry.GoodScriptText = addressNode.ReadXmlElementAttr("valueOrMacro", "");
                if (webServicePingEntry.ValueExpectedReturnType == WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly)
                {
                    webServicePingEntry.GoodScriptText = "[Available]";
                }
                else if (addressNode.ReadXmlElementAttr("useRegEx", false))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.RegEx;
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[Between] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.Between;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[Between] ".Length);
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Replace("[and]", "and");
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[LargerThan] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.LargerThan;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[LargerThan] ".Length);
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[SmallerThan] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.SmallerThan;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[SmallerThan] ".Length);
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[Contains] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.Contains;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[Contains] ".Length);
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[BeginsWith] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.StartsWith;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[BeginsWith] ".Length);
                }
                else if (webServicePingEntry.GoodScriptText.StartsWith("[EndsWith] "))
                {
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareMatchType.EndsWith;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.GoodScriptText.Substring("[EndsWith] ".Length);
                }

                webServicePingEntry.WarningResultMatchType = CollectorAgentReturnValueCompareMatchType.Contains;
                webServicePingEntry.WarningScriptText = "[null]";

                webServicePingEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareMatchType.Contains;
                webServicePingEntry.ErrorScriptText = "[any]";

                if (webServicePingEntry.ReturnCheckSequence == CollectorAgentReturnValueCheckSequence.EWG)
                {
                    CollectorAgentReturnValueCompareMatchType tmpMT = webServicePingEntry.GoodResultMatchType;
                    string tmpTestValue = webServicePingEntry.GoodScriptText;
                    webServicePingEntry.GoodResultMatchType = webServicePingEntry.ErrorResultMatchType;
                    webServicePingEntry.GoodScriptText = webServicePingEntry.ErrorScriptText;
                    webServicePingEntry.ErrorResultMatchType = tmpMT;
                    webServicePingEntry.ErrorScriptText = tmpTestValue;
                }

                Entries.Add(webServicePingEntry);
            }
            foreach (XmlElement carvceEntryNode in root.SelectNodes("carvcesEntries/carvceEntry"))
            {
                WSCollectorConfigEntry webServicePingEntry = new WSCollectorConfigEntry();
                XmlNode dataSourceNode = carvceEntryNode.SelectSingleNode("dataSource");
                webServicePingEntry.ServiceBaseURL = dataSourceNode.ReadXmlElementAttr("url", "");
                webServicePingEntry.ServiceBindingName = dataSourceNode.ReadXmlElementAttr("serviceBindingName", "");
                webServicePingEntry.MethodName = dataSourceNode.ReadXmlElementAttr("method","");
                string parameterStr = dataSourceNode.ReadXmlElementAttr("paramatersCSV","");
                webServicePingEntry.Parameters = new List<string>();
                if (parameterStr.Trim().Length > 0)
                    webServicePingEntry.Parameters.AddRange(parameterStr.Split(','));
                webServicePingEntry.ValueExpectedReturnType = WebServiceValueExpectedReturnTypeConverter.FromString(dataSourceNode.ReadXmlElementAttr("valueExpectedReturnType", ""));
                webServicePingEntry.MacroFormatType = WebServiceMacroFormatTypeConverter.FromString(dataSourceNode.ReadXmlElementAttr("macroFormatType", ""));
                webServicePingEntry.CheckValueArrayIndex = dataSourceNode.ReadXmlElementAttr("arrayIndex", 0);
                webServicePingEntry.CheckValueColumnIndex = dataSourceNode.ReadXmlElementAttr("columnIndex", 0);
                webServicePingEntry.PrimaryUIValue = dataSourceNode.ReadXmlElementAttr("primaryUIValue", false);

                XmlNode testConditionsNode = carvceEntryNode.SelectSingleNode("testConditions");
                if (testConditionsNode != null)
                {
                    webServicePingEntry.ReturnCheckSequence = CollectorAgentReturnValueCompareEngine.CheckSequenceTypeFromString(testConditionsNode.ReadXmlElementAttr("testSequence", "gwe"));
                    XmlNode goodScriptNode = testConditionsNode.SelectSingleNode("success");
                    webServicePingEntry.GoodResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(goodScriptNode.ReadXmlElementAttr("testType", "match"));
                    webServicePingEntry.GoodScriptText = goodScriptNode.InnerText;
                    if (webServicePingEntry.ValueExpectedReturnType == WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly)
                    {
                        webServicePingEntry.GoodScriptText = "[Available]";
                    }

                    XmlNode warningScriptNode = testConditionsNode.SelectSingleNode("warning");
                    webServicePingEntry.WarningResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(warningScriptNode.ReadXmlElementAttr("testType", "match"));
                    webServicePingEntry.WarningScriptText = warningScriptNode.InnerText;

                    XmlNode errorScriptNode = testConditionsNode.SelectSingleNode("error");
                    webServicePingEntry.ErrorResultMatchType = CollectorAgentReturnValueCompareEngine.MatchTypeFromString(errorScriptNode.ReadXmlElementAttr("testType", "match"));
                    webServicePingEntry.ErrorScriptText = errorScriptNode.InnerText;
                }
                else
                    webServicePingEntry.ReturnCheckSequence = CollectorAgentReturnValueCheckSequence.GWE;

                Entries.Add(webServicePingEntry);
            }
        }
        public string ToXml()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(GetDefaultOrEmptyXml());
            XmlElement root = config.DocumentElement;
            XmlNode carvcesEntriesNode = root.SelectSingleNode("carvcesEntries");
            carvcesEntriesNode.InnerXml = "";
            foreach (WSCollectorConfigEntry webServiceEntry in Entries)
            {
                XmlElement carvceEntryNode = config.CreateElement("carvceEntry");
                XmlElement dataSourceNode = config.CreateElement("dataSource");
                dataSourceNode.SetAttributeValue("url", webServiceEntry.ServiceBaseURL);
                dataSourceNode.SetAttributeValue("serviceBindingName", webServiceEntry.ServiceBindingName);
                dataSourceNode.SetAttributeValue("method", webServiceEntry.MethodName);
                dataSourceNode.SetAttributeValue("paramatersCSV", webServiceEntry.ToStringFromParameters());
                dataSourceNode.SetAttributeValue("valueExpectedReturnType", webServiceEntry.ValueExpectedReturnType.ToString());
                dataSourceNode.SetAttributeValue("macroFormatType", webServiceEntry.MacroFormatType.ToString());
                dataSourceNode.SetAttributeValue("arrayIndex", webServiceEntry.CheckValueArrayIndex);
                dataSourceNode.SetAttributeValue("columnIndex", webServiceEntry.CheckValueColumnIndex);
                dataSourceNode.SetAttributeValue("primaryUIValue", webServiceEntry.PrimaryUIValue);

                XmlElement testConditionsNode = config.CreateElement("testConditions");
                testConditionsNode.SetAttributeValue("testSequence", webServiceEntry.ReturnCheckSequence.ToString());
                XmlElement successNode = config.CreateElement("success");
                successNode.SetAttributeValue("testType", webServiceEntry.GoodResultMatchType.ToString());
                successNode.InnerText = webServiceEntry.GoodScriptText;
                XmlElement warningNode = config.CreateElement("warning");
                warningNode.SetAttributeValue("testType", webServiceEntry.WarningResultMatchType.ToString());
                warningNode.InnerText = webServiceEntry.WarningScriptText;
                XmlElement errorNode = config.CreateElement("error");
                errorNode.SetAttributeValue("testType", webServiceEntry.ErrorResultMatchType.ToString());
                errorNode.InnerText = webServiceEntry.ErrorScriptText;

                testConditionsNode.AppendChild(successNode);
                testConditionsNode.AppendChild(warningNode);
                testConditionsNode.AppendChild(errorNode);

                carvceEntryNode.AppendChild(dataSourceNode);
                carvceEntryNode.AppendChild(testConditionsNode);
                carvcesEntriesNode.AppendChild(carvceEntryNode);

                carvcesEntriesNode.AppendChild(carvceEntryNode);
            }
            return config.OuterXml;
        }
        public string GetDefaultOrEmptyXml()
        {
            return "<config>" +
                "<carvcesEntries>" +
                "<carvceEntry name=\"\">" +
                "<dataSource></dataSource>" +
                "<testConditions testSequence=\"GWE\">" +
                "<success testType=\"match\"></success>" +
                "<warning testType=\"match\"></warning>" +
                "<error testType=\"match\"></error>" +
                "</testConditions>" +
                "</carvceEntry>" +
                "</carvcesEntries>" +
                "</config>";
            /*
            +
                "    <!--" +
                "      <webService url=\"\" serviceBindingName=\"\" method=\"\" paramatersCSV=\"\" " +
                "        resultIsSuccess=\"True\" " +
                "		valueExpectedReturnType=\"0\" macroFormatType=\"0\" arrayIndex=\"0\" columnIndex=\"0\"" +
                "		valueOrMacro=\"\" useRegEx=\"False\" />" +
                "      -->" +
                "</webServices></config>";
            */
        }
        public string ConfigSummary
        {
            get 
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("{0} entry(s): ", Entries.Count));
                if (Entries.Count == 0)
                    sb.Append("None");
                else
                {
                    foreach (ICollectorConfigEntry entry in Entries)
                    {
                        sb.Append(entry.Description + ", ");
                    }
                }
                return sb.ToString().TrimEnd(' ', ',');
            }
        }
        #endregion
    }

    public class WSCollectorConfigEntry : ICollectorConfigEntry
    {
        public WSCollectorConfigEntry()
        {
            //ResultIsSuccess = true;
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
        //public bool ResultIsSuccess { get; set; }
        public WebServiceValueExpectedReturnTypeEnum ValueExpectedReturnType { get; set; }
        public WebServiceMacroFormatTypeEnum MacroFormatType { get; set; }
        public int CheckValueArrayIndex { get; set; }
        public int CheckValueColumnIndex { get; set; }

        public CollectorAgentReturnValueCheckSequence ReturnCheckSequence { get; set; }
        public CollectorAgentReturnValueCompareMatchType GoodResultMatchType { get; set; }
        public string GoodScriptText { get; set; }
        public CollectorAgentReturnValueCompareMatchType WarningResultMatchType { get; set; }
        public string WarningScriptText { get; set; }
        public CollectorAgentReturnValueCompareMatchType ErrorResultMatchType { get; set; }
        public string ErrorScriptText { get; set; }

        //public string CheckValueOrMacro { get; set; }
        //public bool UseRegEx { get; set; }

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
        //public string LastFormattedValue { get; private set; }
        #endregion

        #region Private vars
        private DynamicProxy proxy = null;
        private List<System.Reflection.ParameterInfo> parameterTypes = new List<System.Reflection.ParameterInfo>(); 
        #endregion

        #region ICollectorConfigEntry Members

        public string Description
        {
            get { return string.Format("{0}({1}):{2}", ServiceBaseURL, ServiceBindingName, MethodName); }
        }
        public List<ICollectorConfigSubEntry> SubItems { get; set; }
        public string TriggerSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Type:{0} Format:{1} ", ValueExpectedReturnType, MacroFormatType));
                sb.Append(ReturnCheckSequence.ToString() + ": ");
                sb.Append("{G:" + GoodResultMatchType.ToString() + ": " + GoodScriptText + "}");
                sb.Append("{W:" + WarningResultMatchType.ToString() + ": " + WarningScriptText + "}");
                sb.Append("{E:" + ErrorResultMatchType.ToString() + ": " + ErrorScriptText + "}");
                
                return sb.ToString();
            }
        }
        public object CurrentAgentValue { get; set; }
        public bool PrimaryUIValue { get; set; }
        public MonitorState GetCurrentState()
        {
            MonitorState currentState = new MonitorState()
            {
                ForAgent = Description
            };

            object wsData = null;
            CollectorState agentState = CollectorState.NotAvailable;
            try
            {
                wsData = RunMethod();
                if (ValueExpectedReturnType == WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly)
                {
                    agentState = CollectorState.Good;
                }
                else
                {
                    FormatCurrentAgentValue(wsData);
                    agentState = CollectorAgentReturnValueCompareEngine.GetState(ReturnCheckSequence,
                       GoodResultMatchType, GoodScriptText,
                       WarningResultMatchType, WarningScriptText,
                       ErrorResultMatchType, ErrorScriptText,
                       CurrentAgentValue);
                }
            }
            catch (Exception wsException)
            {
                agentState = CollectorState.Error;
                if (wsException.Message.Contains("Method") && wsException.Message.Contains("not found or parameters invalid!"))
                {
                    wsData = "Invalid Method/Parameters!";
                }
                else if (wsException.Message.Contains("Object reference not set to an instance of an object"))
                {
                    wsData = "Object instance not found!";
                }
                else if (wsException.Message.Contains("There was an error downloading"))
                {
                    wsData = "WS down/Invalid URL!";
                }
                else
                {
                    wsData = "WS Error";
                }
                currentState.RawDetails = wsException.Message;
                
            }

            currentState.State = agentState;
            currentState.CurrentValue = CurrentAgentValue != null ? CurrentAgentValue : wsData == null ? "N/A" : wsData.ToString();
            return currentState;
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
                //attempt to load data types so parameters can be formatted properly...
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
            else if (proxy == null)
            {
                throw new Exception("Web service proxy could not be created! Check service URL or binding details");
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
        private object FormatCurrentAgentValue(object testValue)
        {
            switch (ValueExpectedReturnType)
            {
                case WebServiceValueExpectedReturnTypeEnum.CheckAvailabilityOnly:
                    #region CheckAvailabilityOnly
                    CurrentAgentValue = "[Available]";
                    break;
                    #endregion
                case WebServiceValueExpectedReturnTypeEnum.SingleValue:
                    #region SingleValue
                    if (testValue is System.Data.DataSet || testValue.GetType().IsArray)
                        throw new Exception("Returned value is an array or dataset!");
                    else if (testValue == null)
                        CurrentAgentValue = null;
                    else if (testValue.ToString().Length == 0)
                        CurrentAgentValue = testValue;
                    else
                        CurrentAgentValue = testValue;
                    switch (MacroFormatType)
                    {
                        case WebServiceMacroFormatTypeEnum.None:
                            break;
                        case WebServiceMacroFormatTypeEnum.NoValueOnly:
                            CurrentAgentValue = (testValue == null || testValue.ToString().Length == 0);
                            break;
                        case WebServiceMacroFormatTypeEnum.Length:
                            CurrentAgentValue = testValue.ToString().Length.ToString();
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion
                case WebServiceValueExpectedReturnTypeEnum.Array:
                    #region Array
                    if (!testValue.GetType().IsArray)
                        throw new Exception("Returned value is not an array!");
                    Array arr = (Array)testValue;
                    switch (MacroFormatType)
                    {
                        case WebServiceMacroFormatTypeEnum.Count:
                            CurrentAgentValue = arr.Length.ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.FirstValue:
                            CurrentAgentValue = arr.GetValue(0).ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.LastValue:
                            CurrentAgentValue = arr.GetValue(arr.Length - 1).ToString();
                            break;
                        case WebServiceMacroFormatTypeEnum.Sum:
                            double sum = 0;
                            foreach (var arrEntry in arr)
                            {
                                if (arrEntry.IsNumber())
                                    sum += double.Parse(arrEntry.ToString());
                            }
                            CurrentAgentValue = sum.ToString();
                            break;
                        default:
                            if (CheckValueArrayIndex > 0 && CheckValueArrayIndex < arr.Length)
                                CurrentAgentValue = arr.GetValue(CheckValueArrayIndex).ToString();
                            else
                                CurrentAgentValue = arr.GetValue(0).ToString();
                            break;
                    }
                    break;
                #endregion
                case WebServiceValueExpectedReturnTypeEnum.DataSet:
                    #region DataSet
                    if (!(testValue is System.Data.DataSet))
                        throw new Exception("Returned value is not a DataSet!");
                    else
                    {
                        System.Data.DataSet ds = (System.Data.DataSet)testValue;
                        if (ds.Tables.Count == 0)
                            throw new Exception("DataSet contains no tables!");
                        else
                        {
                            System.Data.DataTable tab = ds.Tables[0];
                            switch (MacroFormatType)
                            {
                                case WebServiceMacroFormatTypeEnum.Count:
                                    CurrentAgentValue = tab.Rows.Count.ToString();
                                    break;
                                case WebServiceMacroFormatTypeEnum.FirstValue:
                                    CurrentAgentValue = tab.Rows[0][0].ToString();
                                    break;
                                case WebServiceMacroFormatTypeEnum.LastValue:
                                    CurrentAgentValue = tab.Rows[tab.Rows.Count - 1][tab.Columns.Count - 1].ToString();
                                    break;
                                default:
                                    if (CheckValueArrayIndex >= 0 && CheckValueArrayIndex < tab.Rows.Count && CheckValueColumnIndex >= 0 && CheckValueColumnIndex < tab.Columns.Count)
                                        CurrentAgentValue = tab.Rows[CheckValueArrayIndex][CheckValueColumnIndex].ToString();
                                    else
                                        CurrentAgentValue = tab.Rows[0][0].ToString();
                                    break;
                            }
                        }
                    }
                    break;
                    #endregion
            }
            return CurrentAgentValue;
        }
    }
}
