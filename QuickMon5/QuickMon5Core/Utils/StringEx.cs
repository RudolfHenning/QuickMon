using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenIT.Text
{
    public static class StringEx
    {
        public static string Left(this string text, int characterCount)
        {
            if (text == null || text.Length <= characterCount || characterCount <= 0)
                return text;
            else
            {
                return text.Substring(0, characterCount);
            }
        }
    }
}
