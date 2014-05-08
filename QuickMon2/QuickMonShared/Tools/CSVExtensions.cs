using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class CSVExtensions
    {
        public static string ToCSVString<T>(this List<T> l)
        {
            StringBuilder sb = new StringBuilder();
            if (l != null)
            {
                l.ForEach(li =>
                {
                    if (li != null)
                        sb.Append(li.ToString().Trim() + ", ");
                });
            }
            return sb.ToString().Trim(' ', ',');
        }
        /// <summary>
        /// Converts a csv string into a List&lt;string&gt;
        /// </summary>
        /// <param name="s">Input string</param>
        /// <param name="ordered">If True then items will be added to the list alphabetically</param>
        /// <returns>Genric List with strings</returns>
        public static List<string> ToListFromCSVString(this string s, bool ordered = false)
        {
            List<string> list = new List<string>();
            if (s != null && s.Trim().Length > 0)
            {
                if (ordered)
                    list.AddRange((from sitem in s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   orderby sitem
                                   select sitem.Trim()).ToArray());
                else
                    list.AddRange((from sitem in s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                   select sitem.Trim()).ToArray());
            }
            return list;
        }
    }
}
