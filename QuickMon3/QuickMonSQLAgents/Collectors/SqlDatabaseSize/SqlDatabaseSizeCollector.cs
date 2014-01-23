using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QuickMon.Collectors
{
    [Description("SQL Database Size Collector")]
    public class SqlDatabaseSizeCollector : CollectorBase
    {
        public SqlDatabaseSizeCollector()
        {
            AgentConfig = new SqlDatabaseSizeCollectorConfig();
        }
        public override MonitorState GetState()
        {
            MonitorState returnState = new MonitorState() { State = CollectorState.Good };
            StringBuilder plainTextDetails = new StringBuilder();
            StringBuilder htmlTextTextDetails = new StringBuilder();
            string lastAction = "";
            int errors = 0;
            int warnings = 0;
            int success = 0;
            double totalValue = 0;
            try
            {
                SqlDatabaseSizeCollectorConfig sqlDBSizeConfig = (SqlDatabaseSizeCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("Database size(s)"));
                htmlTextTextDetails.AppendLine(string.Format("Database size(s)"));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (SqlDatabaseSizeEntry sqlDBSizeEntry in sqlDBSizeConfig.Entries)
                {
                    
                    lastAction = string.Format("Getting database size for '{0}\\{1}'", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database);

                    long size = sqlDBSizeEntry.GetDBSize();                    
                    CollectorState currentstate = sqlDBSizeEntry.GetState(size);
                    totalValue += size;

                    if (currentstate == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - value '{2}' - Error (trigger {3})", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size, sqlDBSizeEntry.ErrorSizeMB));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - Value '{2}' - <b>Error</b> (trigger {3})</li>", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size, sqlDBSizeEntry.ErrorSizeMB));
                    }
                    else if (currentstate == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - value '{2}' - Warning (trigger {3})", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size, sqlDBSizeEntry.WarningSizeMB));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - Value '{2}' - <b>Warning</b> (trigger {3})</li>", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size, sqlDBSizeEntry.WarningSizeMB));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}\\{1}' - value '{2}'", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}\\{1}' - Value '{2}'</li>", sqlDBSizeEntry.SqlServer, sqlDBSizeEntry.Database, size));
                    }
                }
                htmlTextTextDetails.AppendLine("</ul>");
                if (errors > 0 && warnings == 0)
                    returnState.State = CollectorState.Error;
                else if (warnings > 0)
                    returnState.State = CollectorState.Warning;
                returnState.RawDetails = plainTextDetails.ToString().TrimEnd('\r', '\n');
                returnState.HtmlDetails = htmlTextTextDetails.ToString();
                returnState.CurrentValue = totalValue;
            }
            catch (Exception ex)
            {
                returnState.RawDetails = string.Format("Last step: '{0}\r\n{1}", lastAction, ex.Message);
                returnState.HtmlDetails = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", lastAction, ex.Message);
                returnState.State = CollectorState.Error;
            }
            return returnState;
        }
        public override ICollectorDetailView GetCollectorDetailView()
        {
            return new SqlDatabaseSizeCollectorShowDetails();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new SqlDatabaseSizeCollectorEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SqlDatabaseSizeCollectorDefaultConfig;
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new SqlDatabaseSizeCollectorEditEntry();
        }
    }
}
