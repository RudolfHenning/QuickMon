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
                    DataSet agentDataSet = SelectedCollectorHost.GetAllAgentDetails();
                    tabDataSetViewer.TabPages.Clear();
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
                        dtvc.RefreshData(true);
                        dtvc.ListSelectedIndexChanged += dtvc_ListSelectedIndexChanged;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
