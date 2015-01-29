using QuickMon.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using QuickMon.Forms;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class CollectorAgentsDetailViewer : Form
    {
        public CollectorAgentsDetailViewer()
        {
            InitializeComponent();
        }

        public CollectorHost SelectedCollectorHost { get; set; }

        public void RefreshViewer()
        {
            if (SelectedCollectorHost != null)
            {
                Text = "Collector Agents Detail Viewer - " + SelectedCollectorHost.Name;
                try
                {
                    int previousTabIndex = -1;
                    if (tabDataSetViewer.TabPages.Count > 0)
                        previousTabIndex = tabDataSetViewer.SelectedIndex;                    
                    tabDataSetViewer.TabPages.Clear();
                    Application.DoEvents();
                    Cursor.Current = Cursors.WaitCursor;

                    DataSet agentDataSet;
                    if (chkRemoteAgentEnabled.Checked)
                    {
                        try
                        {
                            agentDataSet = SelectedCollectorHost.GetAllAgentDetailsRemote(txtRemoteAgentServer.Text, (int)remoteportNumericUpDown.Value);
                        }
                        catch (Exception remEx)
                        {
                            if (remEx.Message.Contains("There was no endpoint listening"))
                            {
                                if (MessageBox.Show("Connection to the remote host failed! Do you want to try and run the agents locally?", "Remote host", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                                    agentDataSet = SelectedCollectorHost.GetAllAgentDetails();
                                else
                                    return;
                            }
                            else
                                throw;
                        }
                    }
                    else
                        agentDataSet = SelectedCollectorHost.GetAllAgentDetails();
                    foreach (DataTable dtab in agentDataSet.Tables)
                    {
                        string tabName = "Details";
                        if (dtab.TableName != "Table")
                            tabName = dtab.TableName;
                        TabPage tabPage = new TabPage(tabName);
                        DataTableViewerControl dtvc = new DataTableViewerControl();
                        dtvc.SelectedData = dtab;
                        dtvc.Dock = DockStyle.Fill;
                        tabPage.Controls.Add(dtvc);
                        tabDataSetViewer.TabPages.Add(tabPage);
                        dtvc.LoadColumns();
                        dtvc.AutoResizeColumnIndex = dtvc.SelectedData.Columns.Count - 1;
                        dtvc.RefreshData(true);
                        dtvc.ListSelectedIndexChanged += dtvc_ListSelectedIndexChanged;
                        dtvc.ListContextMenu = agentsContextMenuStrip;
                    }
                    if (previousTabIndex > -1 && tabDataSetViewer.TabPages.Count > previousTabIndex)
                        tabDataSetViewer.SelectedIndex = previousTabIndex;
                    summaryToolStripStatusLabel.Text = "Last updated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Application.DoEvents();
                    Cursor.Current = Cursors.Default;
                }
            }
        }
        private void dtvc_ListSelectedIndexChanged(object sender, EventArgs e)
        {
            //detailsToolStripMenuItem.Enabled = ((ListView)sender).SelectedItems.Count > 0;
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            RefreshViewer();
        }

        private void CollectorAgentsDetailViewer_Load(object sender, EventArgs e)
        {
            if (SelectedCollectorHost != null)
            {
                chkRemoteAgentEnabled.Checked = SelectedCollectorHost.EnableRemoteExecute;
                txtRemoteAgentServer.Text = SelectedCollectorHost.RemoteAgentHostAddress;
                remoteportNumericUpDown.SaveValueSet(SelectedCollectorHost.RemoteAgentHostPort);
            }                
        }

        private void chkRemoteAgentEnabled_CheckedChanged(object sender, EventArgs e)
        {
            txtRemoteAgentServer.Enabled = chkRemoteAgentEnabled.Checked;
            remoteportNumericUpDown.Enabled = chkRemoteAgentEnabled.Checked;
        }
    }
}
