using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;
using HenIT.RTF;
using QuickMon.Notifiers;

namespace QuickMon.UI
{
    public partial class SqlDatabaseNotifierShowViewer : NotifierViewerBase // Form, INotivierViewer, IChildWindowIdentity
    {
        public SqlDatabaseNotifierShowViewer()
        {
            InitializeComponent();
            splitContainerMain.Panel2Collapsed = true;
            cboTopCount.SelectedIndex = 2;
            cboAlertLevel.SelectedIndex = 4;
            cboState.SelectedIndex = 6;
            dateTimeChooserFrom.SelectedDateTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            dateTimeChooserTo.SelectedDateTime = DateTime.Now.AddMinutes(1);
        }

        //#region IChildWindowIdentity
        //public bool AutoRefreshEnabled { get; set; }
        //public string Identifier { get; set; }
        //public IParentWindow ParentWindow { get; set; }
        //public void RefreshDetails()
        //{
        //    if (SelectedNotifier != null)
        //    {
        //        RefreshDisplayData();
        //    }
        //}
        //public void CloseChildWindow()
        //{
        //    if (ParentWindow != null)
        //        ParentWindow.RemoveChildWindow(this);
        //}
        //public void ShowChildWindow()
        //{
        //    if (ParentWindow != null)
        //        ParentWindow.RegisterChildWindow(this);
        //    if (SelectedNotifier != null)
        //    {
        //        Text = "Sql Database Notifier Viewer - " + SelectedNotifier.Name;
        //    }
        //    if (this.WindowState == FormWindowState.Minimized)
        //        this.WindowState = FormWindowState.Normal;
        //    this.Show();
        //    this.TopMost = true;
        //    this.TopMost = false;
        //    RefreshDisplayData();
        //    //chkAutoRefresh.Checked = AutoRefreshEnabled;
        //}
        //#endregion

        //#region INotivierViewer Members
        //public INotifier SelectedNotifier { get; set; }
        //public void ShowNotifierViewer()
        //{
        //    if (SelectedNotifier != null)
        //    {
        //        Text = "Sql Database Notifier Viewer - " + SelectedNotifier.Name;
        //    }
        //    if (this.WindowState == FormWindowState.Minimized)
        //        this.WindowState = FormWindowState.Normal;
        //    this.Show();
        //    this.TopMost = true;
        //    this.TopMost = false;
        //    RefreshDisplayData();
        //}
        //public bool IsViewerStillVisible()
        //{
        //    return this.IsStillVisible();
        //}
        //public void CloseViewer()
        //{
        //    Close();
        //} 
        //#endregion



        private const int MAXPREVIEWDISPLAYCOUNT = 100;

        private void SqlDatabaseNotifierShowViewer_Load(object sender, EventArgs e)
        {
            lvwMessages.AutoResizeColumnEnabled = true;
            if (SelectedNotifier != null)
            {
                Text = "Sql Database Notifier Viewer - " + SelectedNotifier.Name;
            }
        }

        public override void RefreshDisplayData()
        {
            if (SelectedNotifier != null && SelectedNotifier.AgentConfig != null)
            {
                SqlDatabaseNotifierConfig dbConfig = (SqlDatabaseNotifierConfig)SelectedNotifier.AgentConfig;
                int infos = 0;
                int warns = 0;
                int errs = 0;
                int debugs = 0;
                try
                {
                    lvwMessages.BeginUpdate();
                    if (chkStayCurrent.Checked)
                        dateTimeChooserTo.SelectedDateTime = DateTime.Now.AddMinutes(1);
                    int topCount = int.MaxValue;
                    if (cboTopCount.SelectedItem.ToString() != "All")
                        topCount = int.Parse(cboTopCount.SelectedItem.ToString());
                    string viewerName = dbConfig.ViewerName.Replace("'", "''");
                    string alertParamName = dbConfig.AlertFieldName.Replace("'", "''").Replace("@", "");
                    string collectorParamName = dbConfig.CollectorFieldName.Replace("'", "''").Replace("@", "");
                    string previousStateParamName = dbConfig.PreviousStateFieldName.Replace("'", "''").Replace("@", "");
                    string currentStateParamName = dbConfig.CurrentStateFieldName.Replace("'", "''").Replace("@", "");
                    string detailsParamName = dbConfig.DetailsFieldName.Replace("'", "''").Replace("@", "");
                    string datetimeParamName = dbConfig.DateTimeFieldName.Replace("'", "''").Replace("@", "");
                    object alertTypeValue = cboAlertLevel.SelectedIndex;
                    if (cboAlertLevel.SelectedIndex == 4)
                        alertTypeValue = DBNull.Value;
                    object currentStateValue = cboState.SelectedIndex;
                    if (cboState.SelectedIndex == 6)
                        currentStateValue = DBNull.Value;
                    object categoryValue;
                    if (txtCollector.Text.Length == 0)
                        categoryValue = DBNull.Value;
                    else
                        categoryValue = "%" + txtCollector.Text + "%";
                    object detailsValue;
                    if (txtSearchText.Text.Length == 0)
                        detailsValue = DBNull.Value;
                    else
                        detailsValue = "%" + txtSearchText.Text + "%";
                    object collectorTypeValue = DBNull.Value;

                    string sql = dbConfig.UseSPForViewer ? dbConfig.ViewerName : Properties.Resources.SqlDatabaseQueryTemplate
                        .Replace("@top", cboTopCount.SelectedItem.ToString())
                        .Replace("InsertDate", datetimeParamName)
                        .Replace("AlertLevel", alertParamName)
                        .Replace("Collector", collectorParamName)
                        .Replace("PreviousState", previousStateParamName)
                        .Replace("CurrentState", currentStateParamName)
                        .Replace("Details", detailsParamName)
                        .Replace("AlertMessages", viewerName);

                    using (SqlConnection conn = new SqlConnection(dbConfig.GetConnectionString()))
                    {
                        try
                        {
                            conn.Open();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            if (ex.Message.Contains("The timeout period elapsed while attempting to consume the pre-login handshake acknowledgement"))
                            {
                                System.Threading.Thread.Sleep(3000);
                                toolStripStatusLabelDetails.Text = "Connection timed out! Retrying...";
                                Application.DoEvents();
                                //try again
                                conn.Open();
                            }
                            else
                                throw;
                        }
                        SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@Top",  topCount),
                                new SqlParameter("@FromDate", dateTimeChooserFrom.SelectedDateTime),
                                new SqlParameter("@ToDate", dateTimeChooserTo.SelectedDateTime),
                                new SqlParameter("@" + alertParamName,  alertTypeValue) { DbType = DbType.Byte},
                                new SqlParameter("@" + collectorParamName,  categoryValue),
                                new SqlParameter("@" + currentStateParamName,  currentStateValue),
                                new SqlParameter("@" + detailsParamName, detailsValue)
                            };
                        using (SqlCommand cmnd = new SqlCommand(sql, conn))
                        {
                            cmnd.Prepare();
                            cmnd.Parameters.AddRange(paramArr);
                            if (dbConfig.UseSPForViewer)
                                cmnd.CommandType = CommandType.StoredProcedure;
                            else
                                cmnd.CommandType = CommandType.Text;
                            cmnd.CommandTimeout = dbConfig.CmndTimeOut;
                            using (SqlDataReader r = cmnd.ExecuteReader())
                            {
                                lvwMessages.Items.Clear();
                                List<ListViewItem> items = new List<ListViewItem>();
                                while (r.Read())
                                {
                                    SqlDatabaseAlertMessage alertMessage = new SqlDatabaseAlertMessage();
                                    alertMessage.InsertDate = (DateTime)r[datetimeParamName];
                                    alertMessage.AlertLevel = AlertLevelConverter.GetAlertLevelFromText(r[alertParamName].ToString());
                                    alertMessage.PreviousState = CollectorStateConverter.GetCollectorStateFromText(r[previousStateParamName].ToString());
                                    alertMessage.CurrentState = CollectorStateConverter.GetCollectorStateFromText(r[currentStateParamName].ToString());
                                    alertMessage.Collector = r[collectorParamName].ToString();
                                    alertMessage.Details = r[detailsParamName].ToString();

                                    ListViewItem lvi = new ListViewItem(alertMessage.InsertDate.ToString("yyyy-MM-dd"));
                                    if (alertMessage.AlertLevel == AlertLevel.Info)// || alertMessage.AlertLevel == AlertLevel.Debug)
                                    {
                                        lvi.ImageIndex = 1;
                                        infos++;
                                    }
                                    else if (alertMessage.AlertLevel == AlertLevel.Warning)
                                    {
                                        lvi.ImageIndex = 2;
                                        warns++;
                                    }
                                    else if (alertMessage.AlertLevel == AlertLevel.Error)
                                    {
                                        lvi.ImageIndex = 3;
                                        errs++;
                                    }
                                    else
                                    {
                                        lvi.ImageIndex = 0;
                                        debugs++;
                                    }
                                    lvi.SubItems.Add(alertMessage.InsertDate.ToString("HH:mm:ss"));
                                    lvi.SubItems.Add(alertMessage.Collector);
                                    lvi.SubItems.Add(alertMessage.CurrentState.ToString());
                                    string details = alertMessage.Details;
                                    if (details.Length > 80)
                                        details = details.Substring(0, 80);
                                    lvi.SubItems.Add(details);
                                    lvi.Tag = alertMessage;
                                    items.Add(lvi);
                                }
                                lvwMessages.Items.AddRange(items.ToArray());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    string counts = string.Format("{0} item(s), Info: {1}, Warn: {2}, Err {3}",
                        lvwMessages.Items.Count, infos, warns, errs);
                    if (debugs > 0)
                        counts += " Debug: " + debugs.ToString();
                    toolStripStatusLabelDetails.Text = counts;
                    lvwMessages.EndUpdate();
                }
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshDisplayData();
        }

        #region Rich text box context menu events
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtxDetails.Focus();
            rtxDetails.SelectAll();
        }
        private void showDetailsForAllSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySelectedItemDetails(int.MaxValue);
        }
        #endregion

        private void DisplaySelectedItemDetails(int maxSelection)
        {
            string oldStatusText = toolStripStatusLabelDetails.Text;
            RTFBuilder rtfBuilder = new RTFBuilder();

            //avoid cursor flickering when only a few items are selected
            if (lvwMessages.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                Cursor.Current = Cursors.WaitCursor;
            //have to limit the maximum number of selected items
            foreach (ListViewItem lvi in (from ListViewItem l in lvwMessages.SelectedItems
                                          select l).Take(maxSelection))
            {
                SqlDatabaseAlertMessage entry = (SqlDatabaseAlertMessage)lvi.Tag;
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Insert time: ").AppendLine(entry.InsertDate.ToShortDateString() + " " + entry.InsertDate.ToShortTimeString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Level: ").AppendLine(entry.AlertLevel.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Collector: ").AppendLine(entry.Collector);
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Previous state: ").AppendLine(entry.PreviousState.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Current state: ").AppendLine(entry.CurrentState.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Details:");
                rtfBuilder.AppendPara().LineIndent(500).AppendLine(entry.Details);
                rtfBuilder.FontStyle(FontStyle.Underline).AppendLine(new String(' ', 250));
                rtfBuilder.AppendLine();
            }
            if (lvwMessages.SelectedItems.Count > maxSelection)
            {
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("Only first {0} entries shown... Use 'Show details for all selected items' to display all", maxSelection));
            }
            else if (lvwMessages.SelectedItems.Count == 0)
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("No entries selected");
            else
            {
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine(string.Format("{0} entry(s)", lvwMessages.SelectedItems.Count));
            }
            rtxDetails.Rtf = rtfBuilder.ToString();
            rtxDetails.SelectionStart = 0;
            rtxDetails.SelectionLength = 0;
            rtxDetails.ScrollToCaret();
            Cursor.Current = Cursors.Default;
            toolStripStatusLabelDetails.Text = oldStatusText;
        }

        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails(MAXPREVIEWDISPLAYCOUNT);
        }

        private void lvwMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            if (lvwMessages.SelectedItems.Count > 0)
                toolStripStatusLabelDetails.Text = lvwMessages.SelectedItems.Count.ToString() + " item(s) selected";
            else
                toolStripStatusLabelDetails.Text = "0 items selected";
            timerSelectItem.Enabled = true;
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerMain.Panel2Collapsed ? "ttt" : "uuu";
        }

        private void SqlDatabaseNotifierShowViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseChildWindow();
        }
    }
}
