using System;
using System.Xml;

namespace QuickMon
{
    public static class XmlElementEx
    {
        public static string ReadXmlElementAttr(this XmlElement e, string attrName, string defaultValue = "")
        {
            try
            {
                if (e != null && e.HasAttribute(attrName))
                    return e.Attributes.GetNamedItem(attrName).Value;
            }
            catch { }
            return defaultValue;
        }
        public static string ReadXmlElementAttr(this XmlNode e, string attrName, string defaultValue = "")
        {
            if (e != null)
                return ReadXmlElementAttr((XmlElement)e, attrName, defaultValue);
            else
                return defaultValue;
        }
        public static int ReadXmlElementAttr(this XmlNode e, string attrName, int defaultValue = 0)
        {
            int returnValue = defaultValue;
            int.TryParse(ReadXmlElementAttr(e, attrName, defaultValue.ToString()), out returnValue);
            return returnValue;
        }
        public static long ReadXmlElementAttr(this XmlNode e, string attrName, long defaultValue = 0)
        {
            long returnValue = defaultValue;
            long.TryParse(ReadXmlElementAttr(e, attrName, defaultValue.ToString()), out returnValue);
            return returnValue;
        }
        public static double ReadXmlElementAttr(this XmlNode e, string attrName, double defaultValue = 0)
        {
            double returnValue = defaultValue;
            double.TryParse(ReadXmlElementAttr(e, attrName, defaultValue.ToString()), out returnValue);
            return returnValue;
        }
        public static bool ReadXmlElementAttr(this XmlNode e, string attrName, bool defaultValue = false)
        {
            bool returnValue = defaultValue;
            bool.TryParse(ReadXmlElementAttr(e, attrName, defaultValue.ToString()), out returnValue);
            return returnValue;
        }
        public static DateTime ReadXmlElementAttr(this XmlNode e, string attrName, DateTime defaultValue = new DateTime())
        {
            DateTime returnValue = defaultValue;
            DateTime.TryParse(ReadXmlElementAttr(e, attrName, defaultValue.ToString()), out returnValue);
            return returnValue;
        }
        public static XmlAttribute CreateAttributeWithValue(this XmlDocument xml, string attrName, bool value)
        {
            return xml.CreateAttributeWithValue(attrName, value.ToString());
        }
        public static XmlAttribute CreateAttributeWithValue(this XmlDocument xml, string attrName, int value)
        {
            return xml.CreateAttributeWithValue(attrName, value.ToString());
        }
        public static XmlAttribute CreateAttributeWithValue(this XmlDocument xml, string attrName, long value)
        {
            return xml.CreateAttributeWithValue(attrName, value.ToString());
        }

        public static XmlAttribute CreateAttributeWithValue(this XmlDocument xml, string attrName, string value)
        {
            XmlAttribute attr;
            attr = xml.CreateAttribute(attrName);
            attr.Value = value;
            return attr;
        }
        public static XmlAttribute SetAttributeValue(this XmlNode e, string attrName, bool value)
        {
            return SetAttributeValue((XmlElement)e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlNode e, string attrName, int value)
        {
            return SetAttributeValue((XmlElement)e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlNode e, string attrName, long value)
        {
            return SetAttributeValue((XmlElement)e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlNode e, string attrName, string value)
        {
            return SetAttributeValue((XmlElement)e, attrName, value);
        }
        public static XmlAttribute SetAttributeValue(this XmlElement e, string attrName, bool value)
        {
            return SetAttributeValue(e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlElement e, string attrName, int value)
        {
            return SetAttributeValue(e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlElement e, string attrName, long value)
        {
            return SetAttributeValue(e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlElement e, string attrName, double value)
        {
            return SetAttributeValue(e, attrName, value.ToString());
        }
        public static XmlAttribute SetAttributeValue(this XmlElement e, string attrName, string value)
        {
            if (e.HasAttribute(attrName))
                e.Attributes[attrName].Value = value;
            else
                e.Attributes.Append(CreateAttributeWithValue(e.OwnerDocument, attrName, value));
            return e.Attributes[attrName];
        }

        public static XmlElement AppendElementWithText(this XmlElement e, string elementName, string text)
        {
            XmlElement newElement = e.OwnerDocument.CreateElement(elementName);
            newElement.InnerText = text;
            e.AppendChild(newElement);
            return newElement;
        }
        public static XmlElement AppendElementWithCDATA(this XmlElement e, string elementName, string cdataText)
        {
            XmlElement newElement = e.OwnerDocument.CreateElement(elementName);
            XmlCDataSection commentNode = e.OwnerDocument.CreateCDataSection(cdataText);
            newElement.AppendChild(commentNode);
            e.AppendChild(newElement);
            return newElement;
        }
    }
}
