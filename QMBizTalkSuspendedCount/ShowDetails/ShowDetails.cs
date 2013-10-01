using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Specialized;

namespace QuickMon
{
    public partial class ShowDetails : Form, ICollectorDetailView
    {
        public BizTalkGroup BizTalkGroup { get; set; }

        private const int MAXDETAILITEMS = 100;
        private bool selectionBusy = false;

        public ShowDetails()
        {
            InitializeComponent();
        }

        #region ICollectorDetailView Members
        public void ShowCollectorDetails(ICollector collector)
        {
            base.Show();
            BizTalkGroup = null;
            BizTalkGroup = ((BizTalkSuspendedCount)collector).BizTalkGroup;
            RefreshList();
        }
        public void RefreshConfig(ICollector collector)
        {
            BizTalkGroup = null;
            BizTalkGroup = ((BizTalkSuspendedCount)collector).BizTalkGroup;
            RefreshList();
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
        }
        public bool IsStillVisible()
        {
            return (!(this.Disposing || this.IsDisposed)) && this.Visible;
        }
        #endregion

        #region Show detail
        public void ShowDetail()
        {
            //ReadConfiguration();
            base.Show();
            RefreshList();
        }
        #endregion

        #region Form events
        private void ShowDetails_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }
        private void ShowDetails_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshList();
            }
            else if (e.KeyCode == Keys.F8)
            {
                cmdToggleHideDetails_Click(sender,e);
            }
        }
        #endregion

        #region ListView events
        private void lvwSuspMsgs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!selectionBusy)
            {
                selectionBusy = true;
                timerShowDetail.Enabled = false;
                timerShowDetail.Enabled = true;
                exportToolStripButton.Enabled = lvwSuspMsgs.SelectedItems.Count > 0;
                exportSelectedToolStripMenuItem.Enabled = lvwSuspMsgs.SelectedItems.Count > 0;
                selectionBusy = false;
            }
        }
        #endregion

        #region Timer events
        private void timerShowDetail_Tick(object sender, EventArgs e)
        {
            int itemCount = 0;
            timerShowDetail.Enabled = false;
            txtDetails.Text = "";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (ListViewItem lvi in lvwSuspMsgs.SelectedItems)
                {
                    SuspendedInstance suspendedInstance = (SuspendedInstance)lvi.Tag;
                    txtDetails.AppendText("Host : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.Host, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Application : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.Application, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Message type : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.MessageType, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Server : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.PublishingServer, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Time : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.SuspendTime.ToString(), FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("URI : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.Uri, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Adapter : ", FontStyle.Bold);
                    txtDetails.AppendText(suspendedInstance.Adapter, FontStyle.Regular);
                    if (suspendedInstance.Adapter == "FILE")
                    {
                        txtDetails.AppendText("\r\n");
                        txtDetails.AppendText("File name : ", FontStyle.Bold);
                        txtDetails.AppendText(suspendedInstance.MsgPath, FontStyle.Regular);
                    }
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("Additional Info : ", FontStyle.Bold);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText(suspendedInstance.AdditionalInfo, FontStyle.Regular);
                    txtDetails.AppendText("\r\n");
                    txtDetails.AppendText("------------------------------------------------------------------------------\r\n");
                    txtDetails.AppendText("\r\n");
                    itemCount++;
                    if (itemCount > MAXDETAILITEMS)
                    {
                        txtDetails.AppendText(string.Format("{0} or more items found. Only displaying first {0}", MAXDETAILITEMS));
                        break;
                    }
                }
                if (itemCount <= MAXDETAILITEMS)
                {
                    txtDetails.AppendText(string.Format("{0} item(s)", itemCount));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        #endregion

        #region Button events
        private void cmdToggleHideDetails_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            cmdToggleHideDetails.Text = splitContainer1.Panel2Collapsed ? "ttt" : "uuu";
            if (splitContainer1.SplitterDistance > splitContainer1.Height - 200)
                splitContainer1.SplitterDistance = splitContainer1.Height - 200;
        } 
        #endregion
        
        #region Toolbar and Context menu events
        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (lvwSuspMsgs.SelectedItems.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(lvwSuspMsgs.Columns[0].Text);
                    for (int i = 1; i < lvwSuspMsgs.Columns.Count; i++)
                    {
                        ColumnHeader h = lvwSuspMsgs.Columns[i];
                        sb.Append("," + h.Text);
                    }
                    sb.AppendLine();
                    foreach (ListViewItem lvi in lvwSuspMsgs.Items)
                    {
                        sb.Append(string.Format("\"{0}\"", lvi.Text));
                        for (int i = 1; i < lvwSuspMsgs.Columns.Count; i++)
                        {
                            string field = lvi.SubItems[i].Text;
                            if (field.Contains(',') || field.Contains('\r'))
                                sb.Append(string.Format(",\"{0}\"", field.Replace("\"","'")));
                            else
                                sb.Append("," + lvi.SubItems[i].Text);
                        }
                        sb.AppendLine();
                    }
                    if (saveFileDialogCSV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialogCSV.FileName, sb.ToString());
                    }
                    MessageBox.Show("Export done", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionBusy = true;
            foreach (ListViewItem lvi in lvwSuspMsgs.Items)
            {
                lvi.Selected = true;
            }
            selectionBusy = false;
            timerShowDetail.Enabled = false;
            timerShowDetail.Enabled = true;
            exportToolStripButton.Enabled = lvwSuspMsgs.SelectedItems.Count > 0;
            exportSelectedToolStripMenuItem.Enabled = lvwSuspMsgs.SelectedItems.Count > 0;
        }
        #endregion

        #region Private events
        private void RefreshList()
        {
            if (BizTalkGroup != null)
            {
                lvwSuspMsgs.Items.Clear();
                foreach (SuspendedInstance suspendedInstance in (from s in BizTalkGroup.GetAllSuspendedInstances()
                                                                 orderby s.SuspendTime descending
                                                                 select s))
                {
                    ListViewItem lvi = new ListViewItem(suspendedInstance.Host);
                    lvi.SubItems.Add(suspendedInstance.Application);
                    lvi.SubItems.Add(suspendedInstance.MessageType);
                    lvi.SubItems.Add(suspendedInstance.PublishingServer);
                    lvi.SubItems.Add(suspendedInstance.SuspendTime.ToString());
                    lvi.SubItems.Add(suspendedInstance.Uri);
                    lvi.SubItems.Add(suspendedInstance.Adapter);
                    lvi.SubItems.Add(suspendedInstance.AdditionalInfo);
                    lvi.Tag = suspendedInstance;

                    lvwSuspMsgs.Items.Add(lvi);
                }
                toolStripStatusLabel1.Text = lvwSuspMsgs.Items.Count.ToString() + " item(s) found";
                exportToolStripButton.Enabled = false;
            }
        }
        #endregion        
    }
}
