using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class XmlFormattingUtils
    {
        public static string EscapeXml(this string s)
        {
            if (s == null)
                s = "";
            return s.Replace("&", "&amp;")
                .Replace("\"", "&quot;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;");
        }
        public static string UnEscapeXml(this string s)
        {
            if (s == null)
                s = "";
            return s.Replace("&amp;", "&")
                .Replace("&quot;", "\"")
                .Replace("&lt;", "<")
                .Replace("&gt;", ">");
        }

        public static string BeautifyXML(this string unformattedXML)
        {
            string formattedStr = "";
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(unformattedXML);
                //StringBuilder sb = new StringBuilder();
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "  ",
                    NewLineChars = "\r\n",
                    NewLineHandling = System.Xml.NewLineHandling.Replace,
                    Encoding = new UTF8Encoding(false)
                    //,                    ConformanceLevel = System.Xml.ConformanceLevel.Document
                };
                using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(memoryStream, settings))
                {
                    doc.Save(writer);
                }
                formattedStr = Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                //formattedStr = sb.ToString();
            }
            catch { formattedStr = unformattedXML; }
            return formattedStr;
        }
        public static string NormalizeXML(string unformattedXML)
        {
            string formattedXml = "";
            try
            {
                for (int i = 1; i < 10; i++)
                {
                    unformattedXML = unformattedXML.Replace(">" + new string(' ', i) + "<", "><");
                    unformattedXML = unformattedXML.Replace(">" + new string('\t', i) + "<", "><");
                }

                string[] lines = unformattedXML.Replace("><", ">\r\n<").Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder sb = new StringBuilder();
                int indentation = 0;
                foreach (string originalLine in lines)
                {
                    string line = originalLine;
                    if (line.TrimStart(' ', '\t').StartsWith("<"))
                        line = line.TrimStart(' ', '\t');
                    if (line.TrimEnd(' ').EndsWith("/>"))
                        line = line.TrimEnd(' ');

                    if (line.StartsWith("<"))
                    {
                        if (line.StartsWith("<?"))
                        {
                            if (indentation > 0)
                                indentation--;
                        }
                        else if (line.StartsWith("</"))
                        {
                            if (indentation > 0)
                                indentation--;
                        }
                        sb.AppendLine((new string('\t', indentation)) + line); //sb.AppendLine((new string('\t', indentation * 2)) + line);

                        if (!(line.Contains("</")
                                || line.StartsWith("<?")
                                || line.EndsWith("?>")
                                || line.EndsWith("/>")
                                || line.StartsWith("<!--")
                                || line.EndsWith("-->")
                                || line.StartsWith("<![")
                                || line.EndsWith("]>")
                                ))
                            indentation++;
                    }
                    else if (line.Trim(' ', '\t').Length > 0)
                        sb.AppendLine(line);
                }
                formattedXml = sb.ToString();
            }
            catch
            {
                formattedXml = unformattedXML.Replace("><", ">\r\n<");
            }
            return formattedXml;
        }
    }
}
