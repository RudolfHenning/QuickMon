using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickMon
{
    public class MonitorPackUISettings
    {
        public int LocationX { get; set; } = 0;
        public int LocationY { get; set; } = 0;
        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public void Load(string configurationFile)
        {
            XmlDocument configurationXml = new XmlDocument();
            string xmlConfig = System.IO.File.ReadAllText(configurationFile, Encoding.UTF8);
            configurationXml.LoadXml(xmlConfig);
            XmlElement root = configurationXml.DocumentElement;
            LocationX = root.ReadXmlElementAttr("locationX", 0);
            LocationY = root.ReadXmlElementAttr("locationY", 0);
            Width = root.ReadXmlElementAttr("width", 0);
            Height = root.ReadXmlElementAttr("height", 0);
        }

        public void Save(string configurationFile)
        {
            XmlDocument outDoc = new XmlDocument();
            outDoc.LoadXml("<uiSettings />");
            XmlElement root = outDoc.DocumentElement;
            root.SetAttributeValue("locationX", LocationX);
            root.SetAttributeValue("locationY", LocationY);
            root.SetAttributeValue("width", Width);
            root.SetAttributeValue("height", Height);

            outDoc.OuterXml.BeautifyXML();
            outDoc.Save(configurationFile);
        }
    }
}
