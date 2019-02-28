using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Utils
{
    public static class ExceptionEx
    {
        public static string GetMessageStack(this Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            if (exception != null)
            {
                sb.AppendLine(exception.Message);
                if (exception.InnerException != null && exception.Message != exception.InnerException.Message)
                {
                    sb.AppendLine(exception.InnerException.GetMessageStack());
                }
            }
            return sb.ToString();
        }
    }
}
