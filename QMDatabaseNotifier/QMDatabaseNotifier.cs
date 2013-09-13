using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;
using System.Data;

namespace QuickMon
{
    public class DatabaseNotifier : NotifierBase
    {
        #region Private variables
        private DBSettings dbSettings = new DBSettings();
        private string connStr = "";
        //private Mutex sqlWriteMutex = new Mutex(); 
        #endregion

        public override void RecordMessage(AlertLevel alertLevel, string collectorType, string category, MonitorStates oldState, MonitorStates newState, CollectorMessage collectorMessage)
        {
            string lastStep = "";
            try
            {
                //sqlWriteMutex.WaitOne();
                if (connStr.Length == 0)
                {
                    lastStep = "Setting up connection string";
                    connStr = dbSettings.GetConnectionString();
                }
                lastStep = "Opening connection";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    lastStep = "Inserting test message into database";

                    string alertParamName = dbSettings.AlertFieldName.Replace("'", "''").Replace("@", "");
                    string collectorTypeParamName = dbSettings.CollectorTypeFieldName.Replace("'", "''").Replace("@", "");
                    string categoryParamName = dbSettings.CategoryFieldName.Replace("'", "''").Replace("@", "");
                    string previousStateParamName = dbSettings.PreviousStateFieldName.Replace("'", "''").Replace("@", "");
                    string currentStateParamName = dbSettings.CurrentStateFieldName.Replace("'", "''").Replace("@", "");
                    string detailsParamName = dbSettings.DetailsFieldName.Replace("'", "''").Replace("@", "");

                    string sql = dbSettings.UseSP ? dbSettings.CmndValue :
                        string.Format("Insert {0} ({1}, {2}, {3}, {4}, {5}, {6}) values(@{1}, @{2}, @{3}, @{4}, @{5}, @{6})",
                            dbSettings.CmndValue,
                            dbSettings.AlertFieldName,
                            collectorTypeParamName,
                            categoryParamName,
                            previousStateParamName,
                            currentStateParamName,
                            detailsParamName);
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@" + alertParamName,  (byte)alertLevel),
                                new SqlParameter("@" + collectorTypeParamName,  collectorType),
                                new SqlParameter("@" + categoryParamName,  category),
                                new SqlParameter("@" + previousStateParamName,  (byte)oldState),
                                new SqlParameter("@" + currentStateParamName,  (byte)newState),
                                new SqlParameter("@" + detailsParamName, FormatUtils.N(collectorMessage.PlainText, "No details available"))
                            };
                        cmnd.Parameters.AddRange(paramArr);
                        if (dbSettings.UseSP)
                            cmnd.CommandType = CommandType.StoredProcedure;
                        else
                            cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = dbSettings.CmndTimeOut;
                        cmnd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex) 
            {
                throw new Exception("Error recording message in Database notifier\r\nLast step: " + lastStep, ex);
            }
            finally
            {
                //sqlWriteMutex.ReleaseMutex();
            }
        }
        public override bool HasViewer { get { return true; } }
        public override void OpenViewer(string notifierName)
        {
            ShowViewer showViewer = new ShowViewer();
            showViewer.DbSettings = dbSettings;
            showViewer.Text = "QuickMon Database Notifier Viewer - " + notifierName;
            showViewer.Show();
        }
        public override string ConfigureAgent(string config)
        {
            XmlDocument configXml = new XmlDocument();
            EditConfig editConfig = new EditConfig();
            if (config.Length > 0)
            {
                try
                {
                    configXml.LoadXml(config);
                }
                catch
                {                    
                    configXml.LoadXml(Properties.Resources.DatabaseNotifierEmptyConfig_xml);
                }
            }
            else
            {
                configXml.LoadXml(Properties.Resources.DatabaseNotifierEmptyConfig_xml);
            }

            ReadConfiguration(configXml);
            editConfig.DbSettings = dbSettings;

            if (editConfig.ShowConfig() == System.Windows.Forms.DialogResult.OK)
            {
                dbSettings = editConfig.DbSettings;
                XmlElement root = configXml.DocumentElement;
                XmlNode connectionNode = root.SelectSingleNode("connection");
                connectionNode.SetAttributeValue("sqlServer", dbSettings.SqlServer);
                connectionNode.SetAttributeValue("database", dbSettings.Database);
                connectionNode.SetAttributeValue("integratedSec", dbSettings.IntegratedSec.ToString());
                connectionNode.SetAttributeValue("userName", dbSettings.UserName);
                connectionNode.SetAttributeValue("password", dbSettings.Password);
                XmlNode cmndNode = connectionNode.SelectSingleNode("command");
                cmndNode.SetAttributeValue("cmndTimeOut", dbSettings.CmndTimeOut.ToString());
                cmndNode.SetAttributeValue("useSP", dbSettings.UseSP.ToString());
                cmndNode.SetAttributeValue("value", dbSettings.CmndValue);
                cmndNode.SetAttributeValue("alertFieldName", dbSettings.AlertFieldName);
                cmndNode.SetAttributeValue("collectorTypeFieldName", dbSettings.CollectorTypeFieldName);
                cmndNode.SetAttributeValue("categoryFieldName", dbSettings.CategoryFieldName);
                cmndNode.SetAttributeValue("previousStateFieldName", dbSettings.PreviousStateFieldName);
                cmndNode.SetAttributeValue("currentStateFieldName", dbSettings.CurrentStateFieldName);
                cmndNode.SetAttributeValue("detailsFieldName", dbSettings.DetailsFieldName);
                cmndNode.SetAttributeValue("useSPForViewer", dbSettings.UseSPForViewer.ToString());
                cmndNode.SetAttributeValue("viewer", dbSettings.ViewerName);
                cmndNode.SetAttributeValue("dateTimeFieldName", dbSettings.DateTimeFieldName);
                config = configXml.OuterXml;
            }
            return config;
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.DatabaseNotifierEmptyConfig_xml;
        }
        public override void ReadConfiguration(XmlDocument config)
        {
            XmlElement root = config.DocumentElement;
            XmlNode connectionNode = root.SelectSingleNode("connection");
            dbSettings.SqlServer = connectionNode.ReadXmlElementAttr("sqlServer", "");
            dbSettings.Database = connectionNode.ReadXmlElementAttr("database", "");
            dbSettings.IntegratedSec = bool.Parse(connectionNode.ReadXmlElementAttr("integratedSec", "True"));
            dbSettings.UserName = connectionNode.ReadXmlElementAttr("userName", "");
            dbSettings.Password = connectionNode.ReadXmlElementAttr("password", "");
            XmlNode cmndNode = connectionNode.SelectSingleNode("command");
            dbSettings.CmndTimeOut = int.Parse(cmndNode.ReadXmlElementAttr("cmndTimeOut", ""));
            dbSettings.UseSP = bool.Parse(cmndNode.ReadXmlElementAttr("useSP", "True"));
            dbSettings.CmndValue = cmndNode.ReadXmlElementAttr("value", "InsertMessage");
            dbSettings.AlertFieldName = cmndNode.ReadXmlElementAttr("alertFieldName", "AlertLevel");
            dbSettings.CollectorTypeFieldName = cmndNode.ReadXmlElementAttr("collectorTypeFieldName", "CollectorType");
            dbSettings.CategoryFieldName = cmndNode.ReadXmlElementAttr("categoryFieldName", "Category");
            dbSettings.PreviousStateFieldName = cmndNode.ReadXmlElementAttr("previousStateFieldName", "PreviousState");
            dbSettings.CurrentStateFieldName = cmndNode.ReadXmlElementAttr("currentStateFieldName", "CurrentState");
            dbSettings.DetailsFieldName = cmndNode.ReadXmlElementAttr("detailsFieldName", "Details");
            dbSettings.UseSPForViewer = bool.Parse(cmndNode.ReadXmlElementAttr("useSPForViewer", "True"));
            dbSettings.ViewerName = cmndNode.ReadXmlElementAttr("viewer", "QueryMessages");
            dbSettings.DateTimeFieldName = cmndNode.ReadXmlElementAttr("dateTimeFieldName", "InsertDate");
        }        
    }
}
