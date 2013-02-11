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
        public int OnErrorType { get; set; }
        public string ErrorCustomValue { get; set; }        
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
            if (soapWebServiceRunner == null)
            {
                soapWebServiceRunner = new SoapWebServiceRunner();
                if (!soapWebServiceRunner.SetWebServiceInstance(ServiceBaseURL, ServiceName))
                    throw new Exception(soapWebServiceRunner.LastError);
            }
            return soapWebServiceRunner.RunWSMethod(MethodName, Parameters.ToArray());
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
                int tmpErrType = 0;
                if (int.TryParse(addressNode.ReadXmlElementAttr("onErrorType"), out tmpErrType))
                {
                    webServicePingEntry.OnErrorType = tmpErrType;
                }
                webServicePingEntry.ErrorCustomValue = addressNode.ReadXmlElementAttr("errorCustomValue");
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
                webServicePingNode.SetAttributeValue("onErrorType", webServicePingEntry.OnErrorType);
                webServicePingNode.SetAttributeValue("errorCustomValue", webServicePingEntry.ErrorCustomValue);                
                addressesNode.AppendChild(webServicePingNode);
            }
            return config.OuterXml;
        }

        
    }
}
