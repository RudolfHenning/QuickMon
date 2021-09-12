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
        public string ComputerName { get; set; } = ".";
        public ProcessCollectorFilterType ProcessCollectorFilterType { get; set; }

        private void ProcessListSelectDialog_Load(object sender, EventArgs e)
        {
            cboFieldSelector.SelectedIndex = (int)ProcessCollectorFilterType;
            txtComputer.Text = ComputerName;
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
            lvwProcess.AutoResizeColumnEnabled = false;
            lvwProcess.Items.Clear();
            lvwProcess.Items.Add("Loading...");
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            string computerName = txtComputer.Text;
            if (computerName == "" || computerName == ".")
                computerName = System.Environment.MachineName;

            List<ListViewItem> list = new List<ListViewItem>();
            string filter = txtFilter.Text.ToLower();
            try
            {
                ManagementScope managementScope = new ManagementScope(new ManagementPath("root\\cimv2") { Server = computerName });
                managementScope.Options.Timeout = new TimeSpan(0, 0, 15);

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(managementScope, new WqlObjectQuery($"SELECT ProcessId,Name,ExecutablePath,CommandLine FROM Win32_Process where CommandLine != null")))
                {
                    using (ManagementObjectCollection results = searcher.Get())
                    {
                        int nItems = results.Count;
                        if (nItems > 0)
                        {
                            foreach (ManagementObject objServiceInstance in results)
                            {
                                try { 
                                    object pid = objServiceInstance.Properties["ProcessId"].Value;
                                    string pName = objServiceInstance.Properties["Name"].Value?.ToString();
                                    string exePath = objServiceInstance.Properties["ExecutablePath"].Value.ToString();
                                    string cmdLine = objServiceInstance.Properties["CommandLine"].Value.ToString();
                                    if (filter.Trim().Length < 1 || pName.ToLower().Contains(filter) || exePath.ToLower().Contains(filter) || exePath.ToLower().Contains(cmdLine))
                                        if (int.TryParse(pid.ToString(), out int processId))
                                        {
                                            string processName = "";
                                            string windowTitle = "";
                                            try
                                            {
                                                Process process = Process.GetProcessById(processId, computerName);
                                                processName = process.ProcessName;
                                                if (System.Environment.MachineName == computerName)
                                                    windowTitle = process.MainWindowTitle;
                                            }
                                            catch (Exception ex)
                                            {
                                                System.Diagnostics.Trace.WriteLine(ex.Message);
                                            }

                                            ListViewItem lvi = new ListViewItem(processId.ToString());
                                            lvi.SubItems.Add(processName);
                                            lvi.SubItems.Add(pName?.ToString());
                                            lvi.SubItems.Add(windowTitle);
                                            lvi.SubItems.Add(exePath?.ToString());
                                            lvi.SubItems.Add(cmdLine?.ToString());
                                            list.Add(lvi);
                                        }
                                }
                                catch(Exception ex) {
                                    System.Diagnostics.Trace.WriteLine(ex.Message);
                                }
                            }
                        }
                    }
                }
                lvwProcess.AutoResizeColumnIndex = 4;
                lvwProcess.AutoResizeColumnEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ComputerName = txtComputer.Text;
                SelectedValue = lvwProcess.SelectedItems[0].SubItems[cboFieldSelector.SelectedIndex+1].Text;
                ProcessCollectorFilterType = (ProcessCollectorFilterType)cboFieldSelector.SelectedIndex;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtComputer_EnterKeyPressed()
        {
            RefreshProcessList();
        }

        private void txtFilter_EnterKeyPressed()
        {
            this.Invoke((MethodInvoker)delegate
            {
                RefreshProcessList();
            });
        }
    }
}
