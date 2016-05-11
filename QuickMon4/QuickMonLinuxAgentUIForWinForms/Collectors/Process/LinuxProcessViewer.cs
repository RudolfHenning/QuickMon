using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Collectors
{
    public partial class LinuxProcessViewer : Form
    {
        public LinuxProcessViewer()
        {
            InitializeComponent();
        }

        public QuickMon.Linux.SSHConnectionDetails SSHConnectionDetails { get; set; }
        public List<QuickMon.Linux.ProcessInfo> SelectedProcesses { get; private set; }

        private void LinuxProcessViewer_Load(object sender, EventArgs e)
        {
            
        }
        private void LinuxProcessViewer_Shown(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void cmdReload_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                cmdOK.Enabled = false;
                Renci.SshNet.SshClient sshClient = QuickMon.Linux.SshClientTools.GetSSHConnection(SSHConnectionDetails);
                lvwProcesses.Items.Clear();
                
                foreach(QuickMon.Linux.ProcessInfo process in QuickMon.Linux.ProcessInfo.FromPsAux(sshClient).OrderBy(p => p.ProcessName))
                {
                    if (txtFilter.Text.Trim().Length == 0 || process.ProcessName.ToLower().Contains(txtFilter.Text.ToLower()))
                    {
                        ListViewItem lvi = new ListViewItem(process.ProcessName);
                        lvi.SubItems.Add(process.percCPU.ToString("0.0"));
                        lvi.SubItems.Add(process.percMEM.ToString("0.0"));
                        lvi.Tag = process;
                        lvwProcesses.Items.Add(lvi);
                    }
                }
                cmdOK.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwProcesses.CheckedItems.Count == 0)
            {
                MessageBox.Show("You must select(check) some proceses to continue.", "Select", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SelectedProcesses = new List<Linux.ProcessInfo>();
                foreach(ListViewItem lvi in lvwProcesses.CheckedItems)
                {
                    Linux.ProcessInfo p = (Linux.ProcessInfo)lvi.Tag;
                    SelectedProcesses.Add(p);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
