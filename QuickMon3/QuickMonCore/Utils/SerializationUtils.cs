using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace HenIT.Serialization
{
    public static class SerializationUtils
    {
        #region Serialize
        /// <summary>
        /// Serialize class into an XML string
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="classToSerialize">Class to serialize</param>
        /// <returns>The serialised string</returns>
        public static string SerializeToXML<T>(T classToSerialize) where T : class
        {
            XmlSerializer ser = new XmlSerializer(classToSerialize.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, classToSerialize);
            return sb.ToString();
        }
        /// <summary>
        /// Serialize class directly to file
        /// </summary>
        /// <typeparam name="T">Type of the class</typeparam>
        /// <param name="fileName">File name and path</param>
        /// <param name="classToSerialize">Class to serialize</param>
        public static void SerializeXMLToFile<T>(string fileName, T classToSerialize) where T : class
        {
            using (StreamWriter output2 = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                output2.Write(SerializeToXML<T>(classToSerialize));
                output2.Flush();
                output2.Close();
            }
        }
        #endregion

        #region Deserialize
        /// <summary>
        /// Deserialize class
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="serializedObject">Serialized xml string</param>
        /// <returns>Deserialized class</returns>
        public static T DeserializeXML<T>(string serializedObject) where T : class //, System.Type typeOfObject)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            MemoryStream input = null;
            T result = null;
            input = new MemoryStream(System.Text.Encoding.Unicode.GetBytes(serializedObject));
            input.Position = 0;
            result = (T)ser.Deserialize(input);
            return result;
        }
        /// <summary>
        /// Deserialize class from file
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        /// <param name="filePath">File name and path</param>
        /// <returns>Deserialized class</returns>
        public static T DeserializeXMLFile<T>(string filePath) where T : class
        {
            T result = null;
            if (File.Exists(filePath))
            {
                string fileContents = System.IO.File.ReadAllText(filePath);
                if (fileContents.Length > 0)
                {
                    result = DeserializeXML<T>(fileContents);
                }
            }
            return result;
        }
        #endregion
    }
}
