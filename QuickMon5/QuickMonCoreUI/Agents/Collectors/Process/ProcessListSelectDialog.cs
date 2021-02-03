using QuickMon.Collectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace QuickMon.UI
{
    public partial class ProcessListSelectDialog : Form
    {
        public ProcessListSelectDialog()
        {
            InitializeComponent();
        }

        public string SelectedValue { get; set; }
        public ProcessCollectorFilterType ProcessCollectorFilterType { get; set; }

        private void ProcessListSelectDialog_Load(object sender, EventArgs e)
        {
            cboFieldSelector.SelectedIndex = (int)ProcessCollectorFilterType;
        }
        private void ProcessListSelectDialog_Shown(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void llblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            lvwProcess.Items.Clear();
            lvwProcess.Items.Add("Loading...");
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            List<ListViewItem> list = new List<ListViewItem>();

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"SELECT ProcessId,Name,ExecutablePath,CommandLine FROM Win32_Process where CommandLine != null"))
            {
                using (ManagementObjectCollection results = searcher.Get())
                {
                    int nItems = results.Count;
                    if (nItems > 0)
                    {
                        foreach (ManagementObject objServiceInstance in results)
                        {
                            object pid = objServiceInstance.Properties["ProcessId"].Value;
                            object pName = objServiceInstance.Properties["Name"].Value; 
                            object exePath = objServiceInstance.Properties["ExecutablePath"].Value;
                            object cmdLine = objServiceInstance.Properties["CommandLine"].Value;
                            try
                            {
                                if (int.TryParse(pid.ToString(), out int processId))
                                {
                                    Process process = Process.GetProcessById(processId);
                                    ListViewItem lvi = new ListViewItem(processId.ToString());
                                    lvi.SubItems.Add(process.ProcessName);
                                    lvi.SubItems.Add(pName?.ToString());
                                    lvi.SubItems.Add(process.MainWindowTitle);
                                    lvi.SubItems.Add(exePath?.ToString());
                                    lvi.SubItems.Add(cmdLine?.ToString());
                                    list.Add(lvi);
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            lvwProcess.Items.Clear();
            lvwProcess.Items.AddRange((from ListViewItem i in list
                                       orderby i.SubItems[1].Text
                                       select i).ToArray());
            Cursor.Current = Cursors.Default;
        }

        private void lvwProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwProcess.SelectedItems.Count == 1;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if(lvwProcess.SelectedItems.Count == 1)
            {
                SelectedValue = lvwProcess.SelectedItems[0].SubItems[cboFieldSelector.SelectedIndex+1].Text;
                ProcessCollectorFilterType = (ProcessCollectorFilterType)cboFieldSelector.SelectedIndex;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
