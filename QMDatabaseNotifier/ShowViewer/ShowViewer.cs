using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HenIT.RTF;

namespace QuickMon
{
    public partial class ShowViewer : Form
    {
        public ShowViewer()
        {
            InitializeComponent();
        }

        private string connStr;
        private const int MAXPREVIEWDISPLAYCOUNT = 100;

        #region Properties
        public DBSettings DbSettings { get; set; }   
        #endregion 

        private void ShowViewer_Load(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = true;
            cboTopCount.SelectedIndex = 2;
            cboAlertLevel.SelectedIndex = 5;
            cboState.SelectedIndex = 6;
            dateTimeChooserFrom.SelectedDateTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            dateTimeChooserTo.SelectedDateTime = DateTime.Now.AddMinutes(1);

            new System.Threading.Thread(delegate()
           {
               this.Invoke((MethodInvoker)delegate()
               {
                   RefreshList();
               }
               );
           }).Start();
        }

        private void SetConnectionString()
        {
            connStr = DbSettings.GetConnectionString();
        }

        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerMain.Panel2Collapsed ? "ttt" : "uuu";
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
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
                string viewerName = DbSettings.ViewerName.Replace("'", "''");
                string alertParamName = DbSettings.AlertFieldName.Replace("'", "''").Replace("@", "");
                string collectorTypeParamName = DbSettings.CollectorTypeFieldName.Replace("'", "''").Replace("@", "");
                string categoryParamName = DbSettings.CategoryFieldName.Replace("'", "''").Replace("@", "");
                string previousStateParamName = DbSettings.PreviousStateFieldName.Replace("'", "''").Replace("@", "");
                string currentStateParamName = DbSettings.CurrentStateFieldName.Replace("'", "''").Replace("@", "");
                string detailsParamName = DbSettings.DetailsFieldName.Replace("'", "''").Replace("@", "");
                string datetimeParamName = DbSettings.DateTimeFieldName.Replace("'", "''").Replace("@", "");
                object alertTypeValue = cboAlertLevel.SelectedIndex;
                if (cboAlertLevel.SelectedIndex == 5)
                    alertTypeValue = DBNull.Value;
                object currentStateValue = cboState.SelectedIndex;
                if (cboState.SelectedIndex == 6)
                    currentStateValue = DBNull.Value;
                object categoryValue;
                if (txtCategory.Text.Length == 0)
                    categoryValue = DBNull.Value;
                else
                    categoryValue = "%" + txtCategory.Text + "%";
                object detailsValue;
                if (txtSearchText.Text.Length == 0)
                    detailsValue = DBNull.Value;
                else
                    detailsValue = "%" + txtSearchText.Text + "%";
                object collectorTypeValue = DBNull.Value;

                string sql = DbSettings.UseSPForViewer ? DbSettings.ViewerName : Properties.Resources.QueryTemplate
                    .Replace("@top", cboTopCount.SelectedItem.ToString())
                    .Replace("InsertDate", datetimeParamName)
                    .Replace("AlertLevel", alertParamName)
                    .Replace("CollectorType", collectorTypeParamName)
                    .Replace("Category", categoryParamName)
                    .Replace("PreviousState", previousStateParamName)
                    .Replace("CurrentState", currentStateParamName)
                    .Replace("Details", detailsParamName)
                    .Replace("AlertMessages", viewerName);
                SetConnectionString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlParameter[] paramArr = new SqlParameter[] 
                            { 
                                new SqlParameter("@Top",  topCount),
                                new SqlParameter("@FromDate", dateTimeChooserFrom.SelectedDateTime),
                                new SqlParameter("@ToDate", dateTimeChooserTo.SelectedDateTime),
                                new SqlParameter("@" + alertParamName,  alertTypeValue) { DbType = DbType.Byte},
                                new SqlParameter("@" + collectorTypeParamName,  collectorTypeValue),
                                new SqlParameter("@" + categoryParamName,  categoryValue),
                                new SqlParameter("@" + currentStateParamName,  currentStateValue),
                                new SqlParameter("@" + detailsParamName, detailsValue)
                            };
                    using (SqlCommand cmnd = new SqlCommand(sql, conn))
                    {
                        cmnd.Parameters.AddRange(paramArr);
                        if (DbSettings.UseSPForViewer)
                            cmnd.CommandType = CommandType.StoredProcedure;
                        else
                            cmnd.CommandType = CommandType.Text;
                        cmnd.CommandTimeout = DbSettings.CmndTimeOut;
                        using (SqlDataReader r = cmnd.ExecuteReader())
                        {
                            lvwMessages.Items.Clear();
                            List<ListViewItem> items = new List<ListViewItem>();
                            while (r.Read())
                            {
                                AlertMessage alertMessage = new AlertMessage();
                                alertMessage.InsertDate = (DateTime)r[datetimeParamName];
                                alertMessage.AlertLevel = AlertLevelConverter.GetAlertLevelFromText(r[alertParamName].ToString()); 
                                alertMessage.CollectorType = r[collectorTypeParamName].ToString();
                                alertMessage.PreviousState = MonitorStatesConverter.GetMonitorStateFromText(r[previousStateParamName].ToString());
                                alertMessage.CurrentState = MonitorStatesConverter.GetMonitorStateFromText(r[currentStateParamName].ToString());
                                alertMessage.Category = r[categoryParamName].ToString();
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
                                else if (alertMessage.AlertLevel == AlertLevel.Error || alertMessage.AlertLevel == AlertLevel.Crisis)
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
                                lvi.SubItems.Add(alertMessage.Category);
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
                countsToolStripStatusLabel.Text = counts;
                lvwMessages.EndUpdate();
            }
        }

        private void lvwMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            if (lvwMessages.SelectedItems.Count > 0)
                statusToolStripStatusLabel.Text = lvwMessages.SelectedItems.Count.ToString() + " item(s) selected";
            else
                statusToolStripStatusLabel.Text = "0 items selected";
            timerSelectItem.Enabled = true;
        }

        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails(MAXPREVIEWDISPLAYCOUNT);
        }

        private void DisplaySelectedItemDetails(int maxSelection)
        {
            string oldStatusText = statusToolStripStatusLabel.Text;
            RTFBuilder rtfBuilder = new RTFBuilder();

            //avoid cursor flickering when only a few items are selected
            if (lvwMessages.SelectedItems.Count > MAXPREVIEWDISPLAYCOUNT)
                Cursor.Current = Cursors.WaitCursor;
            //have to limit the maximum number of selected items
            foreach (ListViewItem lvi in (from ListViewItem l in lvwMessages.SelectedItems
                                          select l).Take(maxSelection))
            {
                AlertMessage entry = (AlertMessage)lvi.Tag;
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Insert time: ").AppendLine(entry.InsertDate.ToShortDateString() + " " + entry.InsertDate.ToShortTimeString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Level: ").AppendLine(entry.AlertLevel.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Collector type: ").AppendLine(entry.CollectorType);
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Category: ").AppendLine(entry.Category);
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
            statusToolStripStatusLabel.Text = oldStatusText;
        }

        #region Rich text box context menu events
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtxDetails.SelectAll();
        }
        private void showDetailsForAllSelectedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplaySelectedItemDetails(int.MaxValue);
        }
        #endregion

        private void lvwMessages_Resize(object sender, EventArgs e)
        {
            //Give all other control updating time to finish
            new System.Threading.Thread(delegate()
            {
                System.Threading.Thread.Sleep(50);
                if (this.Visible && this.WindowState != FormWindowState.Minimized)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        try
                        {
                            int leftPos = lvwMessages.Columns[0].Width + lvwMessages.Columns[1].Width + lvwMessages.Columns[2].Width +
                                    lvwMessages.Columns[3].Width;
                            lvwMessages.Columns[4].Width = lvwMessages.ClientSize.Width - leftPos;
                        }
                        catch { }
                    }
                        );
                }
            }
             ).Start();
        }
    }
}
