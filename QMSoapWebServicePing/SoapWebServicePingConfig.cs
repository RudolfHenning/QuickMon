using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public class SoapWebServicePingConfigEntry
    {
        private string serviceBaseURL = "";
        public string ServiceBaseURL
        {
            get { return serviceBaseURL; }
            set { serviceBaseURL = value; soapWebServiceRunner = null; }
        }
        public string ServiceName { get; set; }
        private string methodName = "";
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; soapWebServiceRunner = null; }
        }
        public List<string> Parameters { get; set; }

        public SoapWebServicePingCheckType CheckType { get; set; }
        public SoapWebServicePingResultEnum ResultType { get; set; }
        public string CustomValue1 { get; set; }
        public string CustomValue2 { get; set; }        
        public string LastError
        {
            get
            {
                if (soapWebServiceRunner != null)
                    return soapWebServiceRunner.LastError;
                else
                    return "";
            }
        }

        private SoapWebServiceRunner soapWebServiceRunner = null;

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

        internal object ExecuteMethod()
        {
            object obj = null;
            if (soapWebServiceRunner == null)
            {
                soapWebServiceRunner = new SoapWebServiceRunner();
                if (!soapWebServiceRunner.SetWebServiceInstance(ServiceBaseURL, ServiceName))
                {
                    string lastErr = soapWebServiceRunner.LastError;
                    soapWebServiceRunner = null;
                    throw new Exception(lastErr);
                }
            }
            try
            {
                obj = soapWebServiceRunner.RunWSMethod(MethodName, Parameters.ToArray());
            }
            catch
            {
                soapWebServiceRunner = null; //set null so it can be retried from scratch
                throw;
            }
            return obj;
        }

        public bool CheckResultMatch(object val, SoapWebServicePingResultEnum resultType,
            string fromVal, string toVal, out string formattedVal)
        {
            bool result = false;
            formattedVal = "";
            if (resultType == SoapWebServicePingResultEnum.CheckAvailabilityOnly)
            {
                result = true;
                formattedVal = "[Success]";
            }
            else if (resultType == SoapWebServicePingResultEnum.NoValueOnly)
            {
                result = (val == null) || (val.ToString() == "");
                formattedVal = val.ToString();
            }
            else if (resultType == SoapWebServicePingResultEnum.SpecifiedValue)
            {
                if (val == null)
                {
                    result = fromVal == "";
                    formattedVal = "Null";
                }
                else if (val is System.Data.DataSet)
                    throw new Exception("Returned value is a DataSet!");
                else if (val is string[])
                    throw new Exception("Returned value is an array!");
                else
                {
                    result = val.ToString().ToLower() == fromVal.ToLower();
                    formattedVal = val.ToString();
                }
            }
            else if (resultType == SoapWebServicePingResultEnum.InValueRange)
            {
                if (fromVal.IsNumber() && toVal.IsNumber() && (val != null) && val.IsNumber())
                {
                    result = (double.Parse(fromVal) <= double.Parse(val.ToString()))
                            && (double.Parse(val.ToString()) <= double.Parse(toVal));
                    formattedVal = val.ToString();
                }
                else //test as strings
                {
                    throw new Exception(string.Format("Returned value must be a number! ({0})", val));
                }
            }
            else if (resultType == SoapWebServicePingResultEnum.DataSet)
            {
                if (!(val is System.Data.DataSet))
                    throw new Exception("Returned value is not a DataSet!");
                else
                {
                    System.Data.DataSet ds = (System.Data.DataSet)val;
                    if (ds.Tables.Count == 0)
                        throw new Exception("DataSet contains no tables!");
                    else
                    {
                        System.Data.DataTable tab = ds.Tables[0];
                        if ((tab.Rows.Count == 0 && fromVal != "[Count]") || tab.Columns.Count == 0)
                            throw new Exception("DataSet contains no rows or columns!");
                        else
                        {
                            if (fromVal == "[Count]")
                            {
                                if (toVal.IsNumber())
                                {
                                    result = tab.Rows.Count == double.Parse(toVal);
                                    formattedVal = tab.Rows.Count.ToString() + " row(s)";
                                }
                                else
                                    throw new Exception("Second custom value must be a number!");
                            }
                            else if (fromVal == "[LastValue]")
                            {
                                result = tab.Rows[tab.Rows.Count - 1][tab.Columns.Count - 1].ToString().ToLower() == toVal.ToLower();
                                formattedVal = tab.Rows[tab.Rows.Count - 1][tab.Columns.Count - 1].ToString();
                            }
                            else if (fromVal == "[FirstValue]")
                            {
                                result = tab.Rows[0][0].ToString().ToLower() == toVal.ToLower();
                                formattedVal = tab.Rows[0][0].ToString();
                            }
                            else
                            {
                                result = tab.Rows[0][0].ToString().ToLower() == fromVal.ToLower();
                                formattedVal = tab.Rows[0][0].ToString();
                            }
                        }
                    }
                }
            }
            else// if (resultType == SoapWebServicePingResultEnum.StringArray)
            {
                if (!(val is string[]))
                    throw new Exception("Returned value is not a string array!");
                else
                {
                    string[] sa = (string[])val;
                    if (sa.Length == 0 && fromVal != "[Count]")
                        throw new Exception("String array is empty!");
                    else if (fromVal == "[Count]")
                    {
                        if (toVal.IsNumber())
                        {
                            result = sa.Length == double.Parse(toVal);
                            formattedVal = sa.Length.ToString() + " row(s)";
                        }
                        else
                            throw new Exception("Second custom value must be a number!");
                    }
                    else if (fromVal == "[LastValue]")
                    {
                        result = sa[sa.Length - 1].ToLower() == toVal.ToLower();
                        formattedVal = sa[sa.Length - 1];
                    }
                    else if (fromVal == "[FirstValue]")
                    {
                        result = sa[0].ToLower() == toVal.ToLower();
                        formattedVal = sa[0];
                    }
                    else
                    {
                        result = sa[0].ToLower() == fromVal.ToLower();
                        formattedVal = sa[0];
                    }
                }
            }
            return result;
        }
    }

    public class SoapWebServicePingConfig
    {
        public SoapWebServicePingConfig()
        {
            Entries = new List<SoapWebServicePingConfigEntry>();
        }

        public List<SoapWebServicePingConfigEntry> Entries { get; set; }

        public void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            Entries.Clear();
            foreach (XmlElement addressNode in root.SelectNodes("webServices/webService"))
            {
                SoapWebServicePingConfigEntry webServicePingEntry = new SoapWebServicePingConfigEntry();
                webServicePingEntry.ServiceBaseURL = addressNode.ReadXmlElementAttr("url", "");
                webServicePingEntry.ServiceName = addressNode.ReadXmlElementAttr("name", "");
                webServicePingEntry.MethodName = addressNode.ReadXmlElementAttr("method");
                string parameterStr = addressNode.ReadXmlElementAttr("paramatersCSV");
                webServicePingEntry.Parameters = new List<string>();
                if (parameterStr.Trim().Length > 0)
                    webServicePingEntry.Parameters.AddRange(parameterStr.Split(','));

                if (addressNode.ReadXmlElementAttr("checkType") == "0")
                    webServicePingEntry.CheckType = SoapWebServicePingCheckType.Success;
                else
                    webServicePingEntry.CheckType = SoapWebServicePingCheckType.Failure;

                int tmpResultType = 0;
                if (int.TryParse(addressNode.ReadXmlElementAttr("resultType"), out tmpResultType))
                {
                    webServicePingEntry.ResultType = (SoapWebServicePingResultEnum)tmpResultType;
                }
                else
                {
                    webServicePingEntry.ResultType = SoapWebServicePingResultEnum.CheckAvailabilityOnly;
                }
                webServicePingEntry.CustomValue1 = addressNode.ReadXmlElementAttr("checkValue1");
                webServicePingEntry.CustomValue2 = addressNode.ReadXmlElementAttr("checkValue2");
                Entries.Add(webServicePingEntry);
            }
        }

        public string ToConfig()
        {
            XmlDocument config = new XmlDocument();
            config.LoadXml(Properties.Resources.SoapWebServiceConfig);
            XmlElement root = config.DocumentElement;
            XmlNode addressesNode = root.SelectSingleNode("webServices");
            addressesNode.InnerXml = "";

            foreach (SoapWebServicePingConfigEntry webServicePingEntry in Entries)
            {
                XmlElement webServicePingNode = config.CreateElement("webService");
                webServicePingNode.SetAttributeValue("url", webServicePingEntry.ServiceBaseURL);
                webServicePingNode.SetAttributeValue("name", webServicePingEntry.ServiceName);
                webServicePingNode.SetAttributeValue("method", webServicePingEntry.MethodName);
                webServicePingNode.SetAttributeValue("paramatersCSV", webServicePingEntry.ToStringFromParameters());
                webServicePingNode.SetAttributeValue("checkType", (int)webServicePingEntry.CheckType);
                webServicePingNode.SetAttributeValue("resultType", (int)webServicePingEntry.ResultType);
                webServicePingNode.SetAttributeValue("checkValue1", webServicePingEntry.CustomValue1);
                webServicePingNode.SetAttributeValue("checkValue2", webServicePingEntry.CustomValue2);
                addressesNode.AppendChild(webServicePingNode);
            }
            return config.OuterXml;
        }

        
    }
}
