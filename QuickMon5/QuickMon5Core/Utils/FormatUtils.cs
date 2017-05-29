using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class FormatUtils
    {
        public static string N(object anyValue, string defaultValue = "")
        {
            if (anyValue == null)
                return defaultValue;
            else if (anyValue == DBNull.Value)
                return defaultValue;
            else
                return anyValue.ToString();
        }
        public static bool NBool(object anyVal, bool defaultValue = false)
        {
            if (anyVal == null || anyVal == DBNull.Value)
                return defaultValue;
            else if (anyVal is bool)
                return (bool)anyVal;
            else if (anyVal is int)
                return (int)anyVal != 0;
            else if (anyVal.ToString() == "0")
                return false;
            else if (anyVal.ToString() == "1")
                return true;
            else if (anyVal.ToString().ToLower() == "no")
                return false;
            else if (anyVal.ToString().ToLower() == "yes")
                return true;
            else
            {
                bool tmp;
                if (bool.TryParse(anyVal.ToString(), out tmp))
                    return tmp;
                else
                    return false;
            }
        }
        public static bool IsDouble(this string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else
            {
                double tmp = 0;
                if (double.TryParse(s, out tmp))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsInteger(this string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else
            {
                int tmp = 0;
                if (int.TryParse(s, out tmp))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsLong(this string s)
        {
            if (s == null || s.Length == 0)
                return false;
            else
            {
                long tmp = 0;
                if (long.TryParse(s, out tmp))
                    return true;
                else
                    return false;
            }
        }
        public static bool IsIntegerTypeNumber(this object o)
        {
            if (o == null)
                return false;
            else
            {
                return o.ToString().IsLong();
            }
        }
        public static bool IsNumber(this object o)
        {
            if (o == null)
                return false;
            else
            {
                return o.ToString().IsDouble();
            }
        }
        public static string FormatFileSize(long fileSize)
        {
            if (fileSize < 1024)
            {
                return fileSize.ToString() + " bytes";
            }
            else if (fileSize < 1048576)
            {
                return (fileSize / 1024).ToString() + " KB";
            }
            else if (fileSize < 1073741824)
            {
                return (fileSize / 1048576.0).ToString("0.00") + " MB";
            }
            else
            {
                return (fileSize / 1073741824.00).ToString("0.00") + " GB";
            }

        }
        public static string FormatFileSizePerSec(long fileSize)
        {
            if (fileSize < 1024)
            {
                return fileSize.ToString() + " bytes/sec";
            }
            else if (fileSize < 1048576)
            {
                return (fileSize / 1024).ToString() + " KB/sec";
            }
            else if (fileSize < 1073741824)
            {
                return (fileSize / 1048576.0).ToString("0.00") + " MB/sec";
            }
            else
            {
                return (fileSize / 1073741824.00).ToString("0.00") + " GB/sec";
            }

        }
        public static string FormatArrayToString(object value, string defaultValue = "")
        {
            if (value == null)
                return defaultValue;
            else if (value == DBNull.Value)
                return defaultValue;
            else if (value.GetType().IsArray)
            {
                StringBuilder sb = new StringBuilder();
                if (value is Byte[]) //binary data
                {
                    Byte[] valArr = (Byte[])value;
                    for (int i = 0; i < valArr.Length; i++)
                    {
                        sb.AppendFormat("{0:x2}", valArr[i]).Append(",");
                    }
                    value = sb.ToString().Trim(',');
                }
                else if (value is string[])
                {
                    string[] valArr = (string[])value;
                    foreach (string line in valArr)
                        sb.AppendLine(line);
                    value = sb.ToString().TrimEnd('\r', '\n');
                }
            }
            return value.ToString();
        }
    }
}
