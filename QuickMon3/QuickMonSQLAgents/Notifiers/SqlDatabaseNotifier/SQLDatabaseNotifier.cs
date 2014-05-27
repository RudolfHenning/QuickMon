using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon.Notifiers
{
    [Description("Sql Database Notifier")]
    public class SQLDatabaseNotifier : NotifierBase
    {
        public SQLDatabaseNotifier()
        {
            AgentConfig = new SQLDatabaseNotifierConfig();
        }

        private SqlConnection cacheConn = null;
        public override bool HasViewer { get { return true; } }
        public override AttendedOption AttendedRunOption { get { return AttendedOption.AttendedAndUnAttended; } }

        public override void RecordMessage(AlertRaised alertRaised)
        {
            string lastStep = "";
            try
            {
                SQLDatabaseNotifierConfig currentConfig = (SQLDatabaseNotifierConfig)AgentConfig;

                lastStep = "Getting or opening connection";
                lock (AgentConfig)
                {
                    if (cacheConn == null || cacheConn.State != ConnectionState.Open)
                    {
                        cacheConn = null;
                        cacheConn = new SqlConnection(currentConfig.GetConnectionString());
                        for (int i = 0; i < 3; i++)
                        {
                            try
                            {
                                cacheConn.Open();
                                break;
                            }
                            catch (System.Data.SqlClient.SqlException ex)
                            {
                                if (ex.Message.Contains("The timeout period elapsed while attempting to consume the pre-login handshake acknowledgement"))
                                {
                                    System.Threading.Thread.Sleep(3000);
                                    //try again                                
                                }
                                else
                                    throw;
                            }
                        }
                    }
                }

                //using (SqlConnection conn = new SqlConnection(currentConfig.GetConnectionString()))
                {


                    //                    conn.Open();
                    lastStep = string.Format("Inserting test message into database {0}\\{1}", currentConfig.SqlServer, currentConfig.Database);

                    string alertParamName = currentConfig.AlertFieldName.Replace("'", "''").Replace("@", "");
                    string collectorTypeParamName = currentConfig.CollectorTypeFieldName.Replace("'", "''").Replace("@", "");
                    string categoryParamName = currentConfig.CategoryFieldName.Replace("'", "''").Replace("@", "");
                    string previousStateParamName = currentConfig.PreviousStateFieldName.Replace("'", "''").Replace("@", "");
                    string currentStateParamName = currentConfig.CurrentStateFieldName.Replace("'", "''").Replace("@", "");
                    string detailsParamName = currentConfig.DetailsFieldName.Replace("'", "''").Replace("@", "");

                    string sql = currentConfig.UseSP ? currentConfig.CmndValue :
                        string.Format("Insert {0} ({1}, {2}, {3}, {4}, {5}, {6}) values(@{1}, @{2}, @{3}, @{4}, @{5}, @{6})",
                            currentConfig.CmndValue,
                            currentConfig.AlertFieldName,
                            collectorTypeParamName,
                            categoryParamName,
                            previousStateParamName,
                            currentStateParamName,
                            detailsParamName);

                    string collectorName = "QuickMon Global Alert";
                    string collectorType = "None";
                    int oldState = 0;
                    int newState = 0;
                    string detailMessage = "N/A";
                    string viaHost = "";
                    if (alertRaised.RaisedFor != null)
                    {
                        collectorName = alertRaised.RaisedFor.Name;
                        collectorType = alertRaised.RaisedFor.CollectorRegistrationName;
                        oldState = (byte)alertRaised.RaisedFor.LastMonitorState.State;
                        newState = (byte)alertRaised.RaisedFor.CurrentState.State;
                        detailMessage = FormatUtils.N(alertRaised.RaisedFor.CurrentState.RawDetails, "No details available");
                        if (alertRaised.RaisedFor.OverrideRemoteAgentHost)
                            viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.OverrideRemoteAgentHostAddress, alertRaised.RaisedFor.OverrideRemoteAgentHostPort);
                        else if (alertRaised.RaisedFor.EnableRemoteExecute)
                            viaHost = string.Format(" (via {0}:{1})", alertRaised.RaisedFor.RemoteAgentHostAddress, alertRaised.RaisedFor.RemoteAgentHostPort);
                    }

                    using (SqlCommand cmnd = new SqlCommand(sql, cacheConn))
                    {
                        SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@" + alertParamName,  (byte)alertRaised.Level),
                                new SqlParameter("@" + collectorTypeParamName,  collectorType),
                                new SqlParameter("@" + categoryParamName,  collectorName + viaHost),
                                new SqlParameter("@" + previousStateParamName,  oldState),
                                new SqlParameter("@" + currentStateParamName,  newState),
                                new SqlParameter("@" + detailsParamName, detailMessage)
                            };
                        cmnd.Parameters.AddRange(paramArr);
                        if (currentConfig.UseSP)
                            cmnd.CommandType = CommandType.StoredProcedure;
                        else
                            cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = currentConfig.CmndTimeOut;
                        cmnd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error recording message in Database notifier\r\nLast step: " + lastStep, ex);
            }
        }
        public override INotivierViewer GetNotivierViewer()
        {
            return new SqlDatabaseNotifierShowViewer();
        }
        public override IEditConfigWindow GetEditConfigWindow()
        {
            return new SqlDatabaseNotifierEditConfig();
        }
        public override string GetDefaultOrEmptyConfigString()
        {
            return Properties.Resources.SqlDatabaseNotifierDefaultConfig;
        }
        public override void SetConfigurationFromXmlString(string configurationString)
        {
            AgentConfig.ReadConfiguration(configurationString);
        }
    }
}
