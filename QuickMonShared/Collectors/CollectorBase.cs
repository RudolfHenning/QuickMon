using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
    public abstract class CollectorBase : ICollector
    {
        public CollectorBase()
        {
            LastError = 0;
            LastErrorMsg = "";
        }

        #region ICollector Members
        public abstract MonitorStates GetState();
        public abstract void ShowStatusDetails();
        #endregion

        #region IAgent Members
        public string Name { get; set; }
        public int LastError { get; set; }
        public string LastErrorMsg { get; set; }
        public CollectorMessage LastDetailMsg { get; set; }
        public abstract string ConfigureAgent(string config);
        public abstract string GetDefaultOrEmptyConfigString();
        public abstract void ReadConfiguration(XmlDocument configDoc);
        #endregion   
     
        #region ReadXmlElementAttr
        public string ReadXmlElementAttr(XmlNode e, string attrName, string defaultValue = "")
        {
            return ReadXmlElementAttr((XmlElement)e, attrName, defaultValue);
        }
        public string ReadXmlElementAttr(XmlElement e, string attrName, string defaultValue = "")
        {
            try
            {
                if (e.HasAttribute(attrName))
                    return e.Attributes.GetNamedItem(attrName).Value;
            }
            catch { }
            return defaultValue;
        } 
        #endregion
    }
}
