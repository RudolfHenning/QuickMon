using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace QuickMon.Management
{
    public partial class ImportCollectorConfig : Form
    {
        public ImportCollectorConfig()
        {
            InitializeComponent();
        }

        public string MonitorPackPath { get; set; }
        public bool IsCollector { get; set; }
        public string AgentType { get; set; }
        public string SelectedConfig { get; set; }

        private void ImportCollectorConfig_Shown(object sender, EventArgs e)
        {
            txtMonitorPack.Text = MonitorPackPath;
            lblType.Text = AgentType;
            LoadAgents();
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (File.Exists(txtMonitorPack.Text))
            {
                openFileDialogOpen.FileName = txtMonitorPack.Text;
                openFileDialogOpen.InitialDirectory = Path.GetDirectoryName(txtMonitorPack.Text);
            }
            if (openFileDialogOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtMonitorPack.Text = openFileDialogOpen.FileName;
                LoadAgents();
            }
        }

        private void LoadAgents()
        {
            try
            {
                lvwAgents.BeginUpdate();
                if (File.Exists(txtMonitorPack.Text))
                {
                    MonitorPack monitorPack = new MonitorPack();
                    monitorPack.Load(txtMonitorPack.Text);                    
                    lvwAgents.Items.Clear();
                    if (IsCollector)
                    {
                        foreach (var item in (from c in monitorPack.Collectors
                                              where c.CollectorRegistrationName == AgentType
                                              orderby c.Name
                                              select c))
                        {

                            ListViewItem lvi = new ListViewItem(item.Name);
                            lvi.SubItems.Add(item.Configuration.Replace("\r\n", "->"));
                            lvi.Tag = item.Configuration;
                            lvwAgents.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        foreach (var item in (from c in monitorPack.Notifiers
                                              where c.NotifierRegistrationName == AgentType
                                              orderby c.Name
                                              select c))
                        {

                            ListViewItem lvi = new ListViewItem(item.Name);
                            lvi.SubItems.Add(item.Configuration.Replace("\r\n", "->"));
                            lvi.Tag = item.Configuration;
                            lvwAgents.Items.Add(lvi);
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
                lvwAgents.EndUpdate();
            }
        }

        private void lvwAgents_Resize(object sender, EventArgs e)
        {
            lvwAgents.Columns[1].Width = lvwAgents.ClientSize.Width - lvwAgents.Columns[0].Width;
        }

        private void lvwAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgents.SelectedItems.Count > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgents.SelectedItems.Count > 0)
            {
                SelectedConfig = lvwAgents.SelectedItems[0].Tag.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
