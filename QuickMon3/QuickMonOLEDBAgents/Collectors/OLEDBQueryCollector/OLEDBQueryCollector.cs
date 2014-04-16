using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Collectors
{
    [Description("OLEDB Query Collector"), Category("OLEDB")]
    public class OLEDBQueryCollector : CollectorBase
    {
        public OLEDBQueryCollector()
        {
            AgentConfig = new OLEDBQueryCollectorConfig();
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
                OLEDBQueryCollectorConfig sqlQueryConfig = (OLEDBQueryCollectorConfig)AgentConfig;
                plainTextDetails.AppendLine(string.Format("SQL Queries"));
                htmlTextTextDetails.AppendLine(string.Format("SQL Queries"));
                htmlTextTextDetails.AppendLine("<ul>");
                foreach (OLEDBQueryInstance queryInstance in sqlQueryConfig.Entries)
                {
                    object value = null;
                    lastAction = string.Format("Running SQL query '{0}' ('{1}')", queryInstance.Name, queryInstance.GetConnectionString());

                    value = queryInstance.RunQuery();
                    CollectorState currentstate = queryInstance.GetState(value);
                    if (value != DBNull.Value && value.IsNumber())
                        totalValue += double.Parse(value.ToString());

                    if (currentstate == CollectorState.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Error (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.ErrorValue));
                    }
                    else if (currentstate == CollectorState.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}' - Warning (trigger {2})", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.WarningValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - Value '{1}' - <b>Warning</b> (trigger {2})</li>", queryInstance.Name, FormatUtils.N(value, "[null]"), queryInstance.WarningValue));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("\t'{0}' - value '{1}'", queryInstance.Name, value));
                        htmlTextTextDetails.AppendLine(string.Format("<li>'{0}' - Value '{1}'</li>", queryInstance.Name, value));
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
            throw new NotImplementedException();
        }

        public override IEditConfigEntryWindow GetEditConfigEntryWindow()
        {
            return new OLEDBQueryCollectorEditEntry();
        }

        public override IEditConfigWindow GetEditConfigWindow()
        {
            throw new NotImplementedException();
        }

        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.OLEDBQueryCollectorDefaultConfig;
        }
    }
}
