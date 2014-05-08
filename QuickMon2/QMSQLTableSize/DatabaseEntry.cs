using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QuickMon
{
    public class TableSizeInfo
    {
        public string Name { get; set; }
        public long Rows { get; set; }
    }

    public class DatabaseEntry
    {
        public DatabaseEntry()
        {
            TableSizeEntries = new List<TableSizeEntry>();
            IntegratedSecurity = true;
        }
        public string SqlServer { get; set; }
        public string Name { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<TableSizeEntry> TableSizeEntries { get; set; }

        public List<TableSizeInfo> GetTableRowCount()
        {
            List<TableSizeInfo> list = new List<TableSizeInfo>();
            string sql = "select t.name, i.[rows] from sys.sysindexes i inner join sys.tables t on t.object_id = i.id where i.indid in (0, 1, 255) order by t.name";
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = SqlServer;
            scsb.InitialCatalog = Name;
            scsb.IntegratedSecurity = IntegratedSecurity;
            scsb.UserID = UserName;
            scsb.Password = Password;
            using (SqlConnection conn = new SqlConnection(scsb.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmnd = new SqlCommand(sql, conn))
                {
                    cmnd.CommandType = CommandType.Text;
                    using (SqlDataReader r = cmnd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            TableSizeInfo tableSizeInfo = new TableSizeInfo();
                            tableSizeInfo.Name = r[0].ToString();
                            tableSizeInfo.Rows = long.Parse(r[1].ToString());
                            list.Add(tableSizeInfo);
                        }
                    }
                }
            }
            return list;
        }

        public override string ToString()
        {
            return SqlServer + " \\" + Name;
        }
    }
}
