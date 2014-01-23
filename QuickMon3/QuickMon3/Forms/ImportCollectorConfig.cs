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

        #region Properties
        public string MonitorPackPath { get; set; }
        public MonitorPack CurrentMonitorPack { get; set; }
        public bool IsCollector { get; set; }
        public string AgentType { get; set; }
        public string SelectedConfig { get; set; } 
        #endregion

        #region Form events
        private void ImportCollectorConfig_Shown(object sender, EventArgs e)
        {
            if (!IsCollector)
                this.Text = "Import Notifier config";
            txtMonitorPack.Text = MonitorPackPath;
            lblType.Text = AgentType;
            LoadAgents();
        } 
        #endregion

        #region Button events
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
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwAgents.SelectedItems.Count > 0)
            {
                SelectedConfig = lvwAgents.SelectedItems[0].Tag.ToString();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region ListView events
        private void lvwAgents_Resize(object sender, EventArgs e)
        {
            lvwAgents.Columns[1].Width = lvwAgents.ClientSize.Width - lvwAgents.Columns[0].Width;
        }
        private void lvwAgents_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwAgents.SelectedItems.Count > 0;
        } 
        #endregion

        #region Private methods
        private void LoadAgents()
        {
            try
            {
                lvwAgents.Items.Clear();
                lvwAgents.Items.Add("Loading...");
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                if (File.Exists(txtMonitorPack.Text))
                {

                    CurrentMonitorPack = new MonitorPack();
                    CurrentMonitorPack.Load(txtMonitorPack.Text);
                    Cursor.Current = Cursors.WaitCursor;
                    LoadAgentsForMonitorPack();
                }
                else if (CurrentMonitorPack != null)
                {
                    LoadAgentsForMonitorPack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }
        private void LoadAgentsForMonitorPack()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (IsCollector)
            {
                try
                {
                    lvwAgents.BeginUpdate();
                    lvwAgents.Items.Clear();
                    foreach (var item in (from c in CurrentMonitorPack.Collectors
                                          where c.CollectorRegistrationName == AgentType
                                          orderby c.Name
                                          select c))
                    {

                        ListViewItem lvi = new ListViewItem(item.Name);
                        lvi.SubItems.Add(item.InitialConfiguration.Replace("\r\n", "->"));
                        lvi.Tag = item.InitialConfiguration;
                        lvwAgents.Items.Add(lvi);
                    }
                }
                finally
                {
                    lvwAgents.EndUpdate();
                }
            }
            else
            {
                try
                {
                    lvwAgents.BeginUpdate();
                    lvwAgents.Items.Clear();
                    foreach (var item in (from c in CurrentMonitorPack.Notifiers
                                          where c.NotifierRegistrationName == AgentType
                                          orderby c.Name
                                          select c))
                    {
                        ListViewItem lvi = new ListViewItem(item.Name);
                        lvi.SubItems.Add(item.InitialConfiguration.Replace("\r\n", "->"));
                        lvi.Tag = item.InitialConfiguration;
                        lvwAgents.Items.Add(lvi);
                    }
                }
                finally
                {
                    lvwAgents.EndUpdate();
                }
            }
        } 
        #endregion

    }
}
