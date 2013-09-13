using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public static class SQLTools
    {
        public static bool TSQLValid(string tsql)
        {
            if (ContainSQLStatement(tsql, "DELETE") ||
                ContainSQLStatement(tsql, "UPDATE") ||
                ContainSQLStatement(tsql, "CREATE") ||
                ContainSQLStatement(tsql, "SET") ||
                ContainSQLStatement(tsql, "EXEC") ||
                ContainSQLStatement(tsql, "EXECUTE")
                )
                return false;
            else
                return true;
        }
        public static bool ContainSQLStatement(string tsql, string keyword)
        {
            if (tsql.ToUpper().StartsWith(keyword + " ") ||
                tsql.ToUpper().Contains("\r\n" + keyword + " ") ||
                tsql.ToUpper().Contains("\r\n" + keyword + "\r\n") ||
                tsql.ToUpper().Contains(" " + keyword + " ") ||
                tsql.ToUpper().Contains(" " + keyword + "\r\n") ||
                tsql.ToUpper().StartsWith(" " + keyword))
                return true;
            else
                return false;
        }
    }
}
