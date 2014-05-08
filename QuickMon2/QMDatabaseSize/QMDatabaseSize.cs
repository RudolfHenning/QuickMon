using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace QuickMon
{
	public class DatabaseSize : CollectorBase
	{
        //private string sqlServer = "";
        //private bool integratedSec;
        //private string userName;
        //private string password;
        //private int cmndTimeOut = 60;
        internal DatabaseSizeConfig DatabaseSizeConfig = new DatabaseSizeConfig();
		//internal List<DatabaseEntry> Databases = new List<DatabaseEntry>();

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
                databaseSizeInfo.OpenConnection(DatabaseSizeConfig.SqlServer, DatabaseSizeConfig.IntegratedSec, DatabaseSizeConfig.UserName, DatabaseSizeConfig.Password, DatabaseSizeConfig.CmndTimeOut);

				htmlTextTextDetails.AppendLine("<ul>");
				foreach (DatabaseEntry dbEntry in DatabaseSizeConfig.Databases)
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
            //ShowDetails showDetails = new ShowDetails();
            //showDetails.Text = "Show details - " + collectorName;
            //showDetails.SqlServer = sqlServer;
            //showDetails.IntegratedSec = integratedSec;
            //showDetails.UserName = userName;
            //showDetails.Password = password;
            //showDetails.CmndTimeOut = cmndTimeOut;
            //showDetails.Databases = Databases;
            //showDetails.Show();
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
            editConfig.DatabaseSizeConfig = DatabaseSizeConfig;
            //editConfig.SqlServer = DatabaseSizeConfig.SqlServer;
            //editConfig.IntegratedSec = DatabaseSizeConfig.IntegratedSec;
            //editConfig.UserName = DatabaseSizeConfig.UserName;
            //editConfig.Password = DatabaseSizeConfig.Password;
            //editConfig.Databases = DatabaseSizeConfig.Databases;
            //editConfig.CmndTimeOut = DatabaseSizeConfig.CmndTimeOut;
			if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
			{
                DatabaseSizeConfig = editConfig.DatabaseSizeConfig;
                //DatabaseSizeConfig.SqlServer = editConfig.SqlServer;
                //DatabaseSizeConfig.IntegratedSec = editConfig.IntegratedSec;
                //DatabaseSizeConfig.UserName = editConfig.UserName;
                //DatabaseSizeConfig.Password = editConfig.Password;
                //DatabaseSizeConfig.Databases = editConfig.Databases;

				XmlElement root = configXml.DocumentElement;
				XmlNode connectionNode = root.SelectSingleNode("connection");
                connectionNode.SetAttributeValue("sqlServer", DatabaseSizeConfig.SqlServer);
                connectionNode.SetAttributeValue("integratedSec", DatabaseSizeConfig.IntegratedSec.ToString());
                connectionNode.SetAttributeValue("userName", DatabaseSizeConfig.UserName);
                connectionNode.SetAttributeValue("password", DatabaseSizeConfig.Password);
                connectionNode.SetAttributeValue("cmndTimeOut", DatabaseSizeConfig.CmndTimeOut.ToString());
				connectionNode.InnerXml = "";

                foreach (var database in DatabaseSizeConfig.Databases)
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
            DatabaseSizeConfig = new DatabaseSizeConfig();
            DatabaseSizeConfig.SqlServer = connectionNode.ReadXmlElementAttr("sqlServer", "");
            DatabaseSizeConfig.IntegratedSec = bool.Parse(connectionNode.ReadXmlElementAttr("integratedSec", "True"));
            DatabaseSizeConfig.UserName = connectionNode.ReadXmlElementAttr("userName", "");
            DatabaseSizeConfig.Password = connectionNode.ReadXmlElementAttr("password", "");
            DatabaseSizeConfig.CmndTimeOut = int.Parse(connectionNode.ReadXmlElementAttr("cmndTimeOut", "60"));
            DatabaseSizeConfig.Databases = new List<DatabaseEntry>();
			foreach (XmlElement databaseNode in connectionNode.SelectNodes("database"))
			{
                DatabaseSizeConfig.Databases.Add(new DatabaseEntry()
						{
							Name = databaseNode.ReadXmlElementAttr("name", ""),
							WarningSizeMB = int.Parse(databaseNode.ReadXmlElementAttr("warningSizeMB", "1024")),
							ErrorSizeMB = int.Parse(databaseNode.ReadXmlElementAttr("errorSizeMB", "4094"))
						}
					);
			}
		}

        public override ICollectorDetailView GetCollectorDetailView()
        {
            return (ICollectorDetailView)(new ShowDetails());
        }
    }
}
