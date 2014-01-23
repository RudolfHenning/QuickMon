using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickMon.BizTalk;
using QuickMon.Forms;

namespace QuickMon.Collectors
{
    public partial class BizTalkSuspendedCountCollectorShowDetails : MiniDetailView
    {
        private const int MAXDETAILITEMS = 100;
        public BizTalkSuspendedCountCollectorShowDetails()
        {
            InitializeComponent();
            ExportButtonVisible = false;
            splitContainerDetails.Panel2Collapsed = true;
            lvwEntries.AutoResizeColumnEnabled = true;
        }

        public override void RefreshDisplayData()
        {
            if (Collector != null)
            {
                BizTalkSuspendedCountCollectorConfig currentConfig = (BizTalkSuspendedCountCollectorConfig)Collector.AgentConfig;
                lvwEntries.Items.Clear();
                foreach (SuspendedInstance suspendedInstance in (from s in ((BizTalkSuspendedCountCollectorConfigEntry)currentConfig.Entries[0]).GetAllSuspendedInstances()
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

                    lvwEntries.Items.Add(lvi);
                }
                toolStripStatusLabelDetails.Text = lvwEntries.Items.Count.ToString() + " item(s) found";
                ExportButtonVisible = false;
            }
        }
        public override void RunExport()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (lvwEntries.SelectedItems.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(lvwEntries.Columns[0].Text);
                    for (int i = 1; i < lvwEntries.Columns.Count; i++)
                    {
                        ColumnHeader h = lvwEntries.Columns[i];
                        sb.Append("," + h.Text);
                    }
                    sb.AppendLine();
                    foreach (ListViewItem lvi in lvwEntries.Items)
                    {
                        sb.Append(string.Format("\"{0}\"", lvi.Text));
                        for (int i = 1; i < lvwEntries.Columns.Count; i++)
                        {
                            string field = lvi.SubItems[i].Text;
                            if (field.Contains(',') || field.Contains('\r'))
                                sb.Append(string.Format(",\"{0}\"", field.Replace("\"", "'")));
                            else
                                sb.Append("," + lvi.SubItems[i].Text);
                        }
                        sb.AppendLine();
                    }
                    if (saveFileDialogCSV.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(saveFileDialogCSV.FileName, sb.ToString());
                        MessageBox.Show("Export done", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
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

        private void lvwEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            timerSelectItem.Enabled = true;
            ExportButtonVisible = lvwEntries.SelectedItems.Count > 0;
        }
        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            splitContainerDetails.Panel2Collapsed = !splitContainerDetails.Panel2Collapsed;
            cmdViewDetails.Text = splitContainerDetails.Panel2Collapsed ? "ttt" : "uuu";
            splitContainerDetails.SplitterWidth = 8;
        }
        private void timerSelectItem_Tick(object sender, EventArgs e)
        {
            timerSelectItem.Enabled = false;
            DisplaySelectedItemDetails();
        }

        private void DisplaySelectedItemDetails()
        {
            int itemCount = 0;
            rtxDetails.Text = "";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (ListViewItem lvi in lvwEntries.SelectedItems)
                {
                    SuspendedInstance suspendedInstance = (SuspendedInstance)lvi.Tag;
                    rtxDetails.AppendText("Host : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.Host, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Application : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.Application, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Message type : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.MessageType, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Server : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.PublishingServer, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Time : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.SuspendTime.ToString(), FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("URI : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.Uri, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Adapter : ", FontStyle.Bold);
                    rtxDetails.AppendText(suspendedInstance.Adapter, FontStyle.Regular);
                    if (suspendedInstance.Adapter == "FILE")
                    {
                        rtxDetails.AppendText("\r\n");
                        rtxDetails.AppendText("File name : ", FontStyle.Bold);
                        rtxDetails.AppendText(suspendedInstance.MsgPath, FontStyle.Regular);
                    }
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("Additional Info : ", FontStyle.Bold);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText(suspendedInstance.AdditionalInfo, FontStyle.Regular);
                    rtxDetails.AppendText("\r\n");
                    rtxDetails.AppendText("------------------------------------------------------------------------------\r\n");
                    rtxDetails.AppendText("\r\n");
                    itemCount++;
                    if (itemCount > MAXDETAILITEMS)
                    {
                        rtxDetails.AppendText(string.Format("{0} or more items found. Only displaying first {0}", MAXDETAILITEMS));
                        break;
                    }
                }
                if (itemCount <= MAXDETAILITEMS)
                {
                    rtxDetails.AppendText(string.Format("{0} item(s)", itemCount));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.Copy();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxDetails.SelectAll();
        }
    }
}
