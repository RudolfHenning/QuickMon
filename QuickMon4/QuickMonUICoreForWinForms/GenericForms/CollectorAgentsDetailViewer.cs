using QuickMon.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

                    DataSet agentDataSet = SelectedCollectorHost.GetAllAgentDetails();                    
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
    }
}
