using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuickMon
{
    public static class Serializer
    {
        static public string SerializeXML(object classToSerialize)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer ser = new XmlSerializer(classToSerialize.GetType());
            ser.Serialize(ms, classToSerialize);
            return System.Text.Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
        }
        static public object DeserializeXML(string serializedObject, System.Type typeOfObject)
        {
            XmlSerializer ser = new XmlSerializer(typeOfObject);
            MemoryStream input = new MemoryStream(System.Text.Encoding.Unicode.GetBytes(serializedObject));
            input.Position = 0;
            return ser.Deserialize(input);
        }
    }
}
