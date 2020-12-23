using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenIT.Data
{
    public static class StringCompareUtils
    {
        public static bool ContainEx(this string source, string findText, bool caseSensitive = false)
        {
            bool found = false;
            string lowerCasefindText = findText.ToLower();
            if (!caseSensitive)
            {
                source = source.ToLower();
                findText = findText.ToLower();
            }
            if (findText.Trim().Length == 0)
            {
                found = true;
            }
            else if (lowerCasefindText.Contains(" and "))
            {
                string[] parts = findText.Split(new string[] { " and ", " AND " }, StringSplitOptions.RemoveEmptyEntries);
                found = true;
                foreach (string part in parts)
                {
                    if (!ContainEx(source, part))
                    {
                        found = false;
                        break;
                    }
                }
            }
            else if (lowerCasefindText.Contains(" or "))
            {
                string[] parts = findText.Split(new string[] { " or ", " OR " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    if (ContainEx(source, part))
                    {
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                if (lowerCasefindText.TrimStart().StartsWith("not "))
                {
                    found = !source.ContainEx2(findText.TrimStart().Substring(4), caseSensitive);
                }
                else
                    found = source.ContainEx2(findText, caseSensitive);
            }
            return found;
        }
        private static bool ContainEx2(this string text, string findText, bool caseSensitive = false)
        {
            string matchText = caseSensitive ? text : text.ToLower();
            string matchFindText = caseSensitive ? findText : findText.ToLower();
            if (matchFindText.ToLower().StartsWith("matchexactly "))
            {
                return text == findText.Substring("matchexactly ".Length);
            }
            else if (findText.ToLower().StartsWith("startswith "))
            {
                return text.StartsWith(findText.Substring("startswith ".Length));
            }
            else if (findText.ToLower().StartsWith("endswith "))
            {
                return text.EndsWith(findText.Substring("endswith ".Length));
            }
            else
            {
                return text.Contains(findText);
            }
        }
        public static bool MatchFilter(string filter, string[] values)
        {
            bool match = false;
            if (filter.Trim().Length == 0)
                return true;
            string valueToSearch = "";
            for (int i = 0; i < values.Length; i++)
            {
                valueToSearch += values[i] + " ";
            }
            if (ContainEx(valueToSearch.TrimEnd().ToLower(), filter.ToLower()))
            {
                match = true;
            }
            return match;
        }
    }
}
