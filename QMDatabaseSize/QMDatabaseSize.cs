using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
	public class DatabaseSize : CollectorBase
	{
		private string sqlServer = "";
		private bool integratedSec;
		private string userName;
		private string password;
		private int cmndTimeOut = 60;
		private List<DatabaseEntry> databases = new List<DatabaseEntry>();

		public override MonitorStates GetState()
		{
			MonitorStates returnState = MonitorStates.Good;
			StringBuilder plainTextDetails = new StringBuilder();
			StringBuilder htmlTextTextDetails = new StringBuilder();
			LastDetailMsg.PlainText = "";
			LastDetailMsg.HtmlText = "";

			LastError = 0;
			LastErrorMsg = "";
			int errorCount = 0;
			int warningCount = 0;
			int okCount = 0;
            long totalSize = 0;
			try
			{
				DatabaseSizeInfo databaseSizeInfo = new DatabaseSizeInfo();
				databaseSizeInfo.OpenConnection(sqlServer, integratedSec, userName, password, cmndTimeOut);

				htmlTextTextDetails.AppendLine("<ul>");
				foreach (DatabaseEntry dbEntry in databases)
				{
					long size = databaseSizeInfo.GetDatabaseSize(dbEntry.Name);
					totalSize += size;
					if (size >= (long)dbEntry.ErrorSizeMB)
					{
						errorCount++;
						plainTextDetails.AppendLine(string.Format("Database {0} - Size {1}MB - Error (trigger {2}MB)", dbEntry.Name, size, dbEntry.ErrorSizeMB));
						htmlTextTextDetails.AppendLine(string.Format("<li>Database {0} - Size {1}MB - <b>Error</b> (trigger {2}MB)</li>", dbEntry.Name, size, dbEntry.ErrorSizeMB));
					}
					else if (size >= (long)dbEntry.WarningSizeMB)
					{
						warningCount++;
						plainTextDetails.AppendLine(string.Format("Database {0} - Size {1}MB - Warning (trigger {2}MB", dbEntry.Name, size, dbEntry.WarningSizeMB));
						htmlTextTextDetails.AppendLine(string.Format("<li>Database {0} - Size {1}MB - <b>Warning</b> (trigger {2}MB)</li>", dbEntry.Name, size, dbEntry.WarningSizeMB));
					}
					else
					{
						okCount++;
						plainTextDetails.AppendLine(string.Format("Database {0} - Size {1}MB", dbEntry.Name, size));
						htmlTextTextDetails.AppendLine(string.Format("<li>Database {0} - Size {1}MB</li>", dbEntry.Name, size));
					}
				}
				LastDetailMsg.LastValue = totalSize;
				htmlTextTextDetails.AppendLine("</ul>");

				databaseSizeInfo.CloseConnection();

				if (errorCount > 0)
					returnState = MonitorStates.Error;
				else if (warningCount > 0)
					returnState = MonitorStates.Warning;
				else
					returnState = MonitorStates.Good;
				LastDetailMsg.PlainText = plainTextDetails.ToString().TrimEnd('\r', '\n');
				LastDetailMsg.HtmlText = htmlTextTextDetails.ToString();
			}
			catch (Exception ex)
			{
				LastError = 1;
				LastErrorMsg = ex.Message;
				LastDetailMsg.PlainText = ex.Message;
				LastDetailMsg.HtmlText = string.Format("<blockquote>{0}</blockquote>", ex.Message);

				returnState = MonitorStates.Error;
			}

			return returnState;
		}

		public override void ShowStatusDetails(string collectorName)
		{
			ShowDetails showDetails = new ShowDetails();
			showDetails.Text = "Show details - " + collectorName;
			showDetails.SqlServer = sqlServer;
			showDetails.IntegratedSec = integratedSec;
			showDetails.UserName = userName;
			showDetails.Password = password;
			showDetails.CmndTimeOut = cmndTimeOut;
			showDetails.Databases = databases;
			showDetails.Show();
		}

		public override string ConfigureAgent(string config)
		{
			XmlDocument configXml = new XmlDocument();
			if (config.Length > 0)
				configXml.LoadXml(config);
			else
				configXml.LoadXml(GetDefaultOrEmptyConfigString());
			ReadConfiguration(configXml);

			EditConfig editConfig = new EditConfig();
			editConfig.SqlServer = sqlServer;
			editConfig.IntegratedSec = integratedSec;
			editConfig.UserName = userName;
			editConfig.Password = password;
			editConfig.Databases = databases;
			editConfig.CmndTimeOut = cmndTimeOut;
			if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
			{
				sqlServer = editConfig.SqlServer;
				integratedSec = editConfig.IntegratedSec;
				userName = editConfig.UserName;
				password = editConfig.Password;
				databases = editConfig.Databases;

				XmlElement root = configXml.DocumentElement;
				XmlNode connectionNode = root.SelectSingleNode("connection");
				connectionNode.SetAttributeValue("sqlServer", editConfig.SqlServer);
				connectionNode.SetAttributeValue("integratedSec", editConfig.IntegratedSec.ToString());
				connectionNode.SetAttributeValue("userName", userName);
				connectionNode.SetAttributeValue("password", password);
				connectionNode.SetAttributeValue("cmndTimeOut", cmndTimeOut.ToString());
				connectionNode.InnerXml = "";

				foreach (var database in databases)
				{
					XmlElement databaseNode = configXml.CreateElement("database");
					databaseNode.SetAttributeValue("name", database.Name);
					databaseNode.SetAttributeValue("warningSizeMB", database.WarningSizeMB.ToString());
					databaseNode.SetAttributeValue("errorSizeMB", database.ErrorSizeMB.ToString());

					connectionNode.AppendChild(databaseNode);
				}
				config = configXml.OuterXml;
			}
			return config;
		}

		public override string GetDefaultOrEmptyConfigString()
		{
			return Properties.Resources.DatabaseSizeEmptyConfig_xml;
		}

		public override void ReadConfiguration(XmlDocument config)
		{
			XmlElement root = config.DocumentElement;
			XmlNode connectionNode = root.SelectSingleNode("connection");
			sqlServer = connectionNode.ReadXmlElementAttr("sqlServer", "");
			integratedSec = bool.Parse(connectionNode.ReadXmlElementAttr("integratedSec", "True"));
			userName = connectionNode.ReadXmlElementAttr("userName", "");
			password = connectionNode.ReadXmlElementAttr("password", "");
			cmndTimeOut = int.Parse(connectionNode.ReadXmlElementAttr("cmndTimeOut", "60"));
			databases = new List<DatabaseEntry>();
			foreach (XmlElement databaseNode in connectionNode.SelectNodes("database"))
			{
				databases.Add(new DatabaseEntry()
						{
							Name = databaseNode.ReadXmlElementAttr("name", ""),
							WarningSizeMB = int.Parse(databaseNode.ReadXmlElementAttr("warningSizeMB", "1024")),
							ErrorSizeMB = int.Parse(databaseNode.ReadXmlElementAttr("errorSizeMB", "4094"))
						}
					);
			}
		}
	}
}
