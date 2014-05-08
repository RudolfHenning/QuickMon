using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Management;

namespace QuickMon
{
	public class WMIQuery : CollectorBase
	{
		internal WMIConfig WmiIConfig = new WMIConfig();

		public override MonitorStates GetState()
		{
			MonitorStates returnState = MonitorStates.Good;
			StringBuilder plainTextDetails = new StringBuilder();
			StringBuilder htmlTextTextDetails = new StringBuilder();
			LastDetailMsg.PlainText = "Running WMI query";
			LastDetailMsg.HtmlText = "";
			int errors = 0;
			int warnings = 0;
			int success = 0;
            double totalValue = 0;
			try
			{
				plainTextDetails.AppendLine(string.Format("Running {0} WMI queries", WmiIConfig.Entries.Count));
                htmlTextTextDetails.AppendLine(string.Format("<i>Running {0} WMI queries'</i>", WmiIConfig.Entries.Count));
				htmlTextTextDetails.AppendLine("<ul>");

                foreach (WMIConfigEntry wmiConfigEntry in WmiIConfig.Entries)
                {
                    plainTextDetails.Append(string.Format("\t\t{0} - ", wmiConfigEntry.Name));
                    htmlTextTextDetails.Append(string.Format("<li>{0} - ", wmiConfigEntry.Name));

                    object val = wmiConfigEntry.RunQuery();
                    MonitorStates currentState = wmiConfigEntry.GetState(val);
                    if (currentState == MonitorStates.Error)
                    {
                        errors++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Error (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.ErrorValue));
                    }
                    else if (currentState == MonitorStates.Warning)
                    {
                        warnings++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Warning (trigger {2})", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})</li>", wmiConfigEntry.Machinename, FormatUtils.N(val, "[null]"), wmiConfigEntry.WarningValue));
                    }
                    else
                    {
                        success++;
                        plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}'", wmiConfigEntry.Machinename, val));
                        htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}'</li>", wmiConfigEntry.Machinename, val));
                    }
                    if (val != null && val.IsNumber())
                        totalValue += double.Parse(val.ToString());
                }
				
                    //object value = null;
                    //LastDetailMsg.PlainText = string.Format("Running WMI query for '{0}' - '{1}'", WmiIConfig.Machinename, WmiIConfig.StateQuery);

                    //value = WmiIConfig.RunQuery();
                    //MonitorStates currentState = WmiIConfig.GetState(value);



                    //if (currentState == MonitorStates.Error)
                    //{
                    //    errors++;
                    //    plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Error (trigger {2})", WmiIConfig.Machinename, FormatUtils.N(value, "[null]"), WmiIConfig.ErrorValue));
                    //    htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Error</b> (trigger {2})</li>", WmiIConfig.Machinename, FormatUtils.N(value, "[null]"), WmiIConfig.ErrorValue));
                    //}
                    //else if (currentState == MonitorStates.Warning)
                    //{
                    //    warnings++;
                    //    plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}' - Warning (trigger {2})", WmiIConfig.Machinename, FormatUtils.N(value, "[null]"), WmiIConfig.WarningValue));
                    //    htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}' - <b>Warning</b> (trigger {2})</li>", WmiIConfig.Machinename, FormatUtils.N(value, "[null]"), WmiIConfig.WarningValue));
                    //}
                    //else
                    //{
                    //    success++;
                    //    plainTextDetails.AppendLine(string.Format("Machine '{0}' - value '{1}'", WmiIConfig.Machinename, value));
                    //    htmlTextTextDetails.AppendLine(string.Format("<li>Machine '{0}' - Value '{1}'</li>", WmiIConfig.Machinename, value));
                    //}
				
				htmlTextTextDetails.AppendLine("</ul>");
				if (errors > 0 && warnings == 0)
					returnState = MonitorStates.Error;
				else if (warnings > 0)
					returnState = MonitorStates.Warning;
				LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
				LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
                LastDetailMsg.LastValue = totalValue;
			}
			catch (Exception ex)
			{
				LastError = 1;
				LastErrorMsg = ex.Message;
				LastDetailMsg.PlainText = string.Format("Last step: '{0}\r\n{1}", LastDetailMsg.PlainText, ex.Message);
				LastDetailMsg.HtmlText = string.Format("<blockquote>Last step: '{0}<br />{1}</blockquote>", LastDetailMsg.PlainText, ex.Message);
				returnState = MonitorStates.Error;
			}
			return returnState;
		}

		public override void ShowStatusDetails(string collectorName)
		{
			ShowDetails showDetails = new ShowDetails();
			showDetails.WmiConfig = WmiIConfig;
			showDetails.Text = "Show details - " + collectorName;
			showDetails.Show();
		}

		public override string ConfigureAgent(string config)
		{
			XmlDocument configDoc = new XmlDocument();
			if (config.Length > 0)
				configDoc.LoadXml(config);
			else
				configDoc.LoadXml(GetDefaultOrEmptyConfigString());
			ReadConfiguration(configDoc);

			EditConfig editConfig = new EditConfig();
			editConfig.WmiConfig = WmiIConfig;
			if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
			{
				config = editConfig.WmiConfig.ToConfig();
			}
			return config;
		}

		public override string GetDefaultOrEmptyConfigString()
		{
			return Properties.Resources.WMIQueryEmptyConfig;
		}

		public override void ReadConfiguration(XmlDocument configDoc)
		{
			WmiIConfig.ReadConfig(configDoc);
		}

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
