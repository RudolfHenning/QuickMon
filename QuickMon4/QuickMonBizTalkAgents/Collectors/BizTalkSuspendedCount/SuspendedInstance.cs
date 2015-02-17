using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    public class SuspendedInstance
    {
        public string Host { get; set; }
        public string Application { get; set; }
        public string MessageType { get; set; }
        public string PublishingServer { get; set; }
        public DateTime SuspendTime { get; set; }
        public string Uri { get; set; }
        public string Adapter { get; set; }
        public string MsgPath
        {
            get
            {
                if (Adapter == "FILE")
                    return GetFileNameFromContext(Context);
                else
                    return "";
            }
        }
        public string AdditionalInfo { get; set; }
        public string InstanceID { get; set; }
        public string ServiceID { get; set; }
        public Byte[] Context { get; set; }
        public string ToString(bool useHtml = false)
        {
            string output;
            if (useHtml)
            {
                output = string.Format(
                    "<b>Host:</b> {0}<br />" +
                    "<b>Application:</b> {1}<br />" +
                    "<b>Message type:</b> {2}<br />" +
                    "<b>Server:</b> {3}<br />" +
                    "<b>Time:</b> {4}<br />" +
                    "<b>URI:</b> {5}<br />" +
                    "<b>Adapter:</b> {6}<br />",
                    Host,
                    Application,
                    MessageType,
                    PublishingServer,
                    SuspendTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Uri,
                    Adapter);
                if (Adapter == "FILE")
                    output += string.Format("<b>File name:</b> {0}<br />", MsgPath);
                output += "<b>Additional info:</b><blockquote>" + AdditionalInfo + "<hr /></blockquote>";
            }
            else
            {
                output = string.Format(
                    "Host: {0}\r\n" +
                    "Application: {1}\r\n" +
                    "Message type: {2}\r\n" +
                    "Server: {3}\r\n" +
                    "Time: {4}\r\n" +
                    "URI: {5}\r\n" +
                    "Adapter: {6}\r\n",
                    Host,
                    Application,
                    MessageType,
                    PublishingServer,
                    SuspendTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    Uri,
                    Adapter);
                if (Adapter == "FILE")
                    output += string.Format("File name: {0}\r\n", MsgPath);
                output += "Additional info: " + AdditionalInfo;
            }
            return output;
        }
        #region Private methods
        private string GetFileNameFromContext(Byte[] context)
        {
            string fileName = "";

            try
            {
                int receiveFileNameStart = SearchBytes(context, String2Bytes("ReceivedFileName"));
                receiveFileNameStart = receiveFileNameStart + 41;
                int receiveFileNameLen = (context[receiveFileNameStart] * 256) + context[receiveFileNameStart + 1];
                byte[] fileNameBytes = CopyBytes(context, receiveFileNameStart + 4, receiveFileNameLen);
                fileName = Bytes2String(fileNameBytes);
            }
            catch (Exception ex)
            {
                fileName = ex.ToString();
            }

            return fileName;
        }

        #region Bytes/string conversions
        private static int SearchBytes(byte[] sourceBytes, byte[] criteria)
        {
            bool found = false;
            for (int i = 0; i < sourceBytes.Length - criteria.Length; i++)
            {
                if (sourceBytes[i] == criteria[0]) //first byte match
                {
                    found = true;
                    for (int j = 1; j < criteria.Length; j++)
                    {
                        if (sourceBytes[i + j] != criteria[j])
                        {
                            found = false;
                            break;
                        }
                    }
                    if (found)
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
        private static byte[] CopyBytes(byte[] source, int start, int length)
        {
            byte[] destination = new byte[length];
            for (int i = 0; i < length; i++)
            {
                destination[i] = source[start + i];
            }
            return destination;
        }
        private static byte[] String2Bytes(string str)
        {
            byte[] bytes = new byte[str.Length * 2];
            for (int i = 0; i < str.Length; i++)
            {
                int tmp = char.ConvertToUtf32(str, i);
                bytes[i * 2] = 0;
                bytes[i * 2 + 1] = System.Convert.ToByte(tmp);
            }
            return bytes;
        }
        private static string Bytes2String(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length / 2; i++)
            {
                sb.Append(char.ConvertFromUtf32(bytes[i * 2] * 256 + bytes[i * 2 + 1]));
            }
            return sb.ToString().Replace("\0", "");
        }
        #endregion

        #endregion

    }
}
