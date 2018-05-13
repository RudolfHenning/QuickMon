using QuickMon.Collectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.UI
{
    public partial class SelectEventSources : Form
    {
        public SelectEventSources()
        {
            InitializeComponent();
        }

        public string ComputerName
        {
            get { return txtComputer.Text; }
            set { txtComputer.Text = value; }
        }
        public string LogName { get; set; }
        public List<ConfigVariable> ConfigVariables { get; set; } = new List<ConfigVariable>();
        public List<string> SelectedSources { get; set; } = new List<string>();

        private void SelectEventSources_Load(object sender, EventArgs e)
        {
            if (ComputerName.Length == 0)
                ComputerName = ".";
            LoadComputerEventsLogs();
        }

        private void LoadComputerEventsLogs()
        {
            try
            {
                cboLog.Items.Clear();
                if (txtComputer.Text.Trim().Length == 0)
                {
                    txtComputer.Text = System.Net.Dns.GetHostName();
                }
                string hostName = txtComputer.Text;
                if (hostName == ".")
                {
                    hostName = System.Net.Dns.GetHostName();
                }
                hostName = ApplyConfigVarsOnField(hostName);

                if (System.Net.Dns.GetHostAddresses(hostName).Length == 0)
                    return;

                foreach (string eventLogName in EventLogUtil.GetEventLogNames(hostName))
                {
                    cboLog.Items.Add(eventLogName);
                }                

                if (LogName != null)
                    cboLog.SelectedItem = LogName;
                else
                    cboLog.SelectedItem = "Application";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Event logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckOkEnabled();
        }

        public string ApplyConfigVarsOnField(string field)
        {
            if (ConfigVariables == null)
                ConfigVariables = new List<ConfigVariable>();
            return ConfigVariables.ApplyOn(field);          
        }
        private bool CheckOkEnabled()
        {
            try
            {
                cmdOK.Enabled = false;
                if (txtComputer.Text.Trim().Length == 0)
                    return false;
                if (cboLog.SelectedIndex == -1)
                    return false;                
            }
            catch { return false; }
            cmdOK.Enabled = true;
            return true;
        }

        private void cboLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSources();
        }
        private void LoadSources()
        {
            if (cboLog.SelectedIndex > -1)
            {
                try
                {
                    string hostName = txtComputer.Text;
                    if (hostName == ".")
                    {
                        hostName = System.Net.Dns.GetHostName();
                    }
                    hostName = ApplyConfigVarsOnField(hostName);

                    List<ListViewItem> sources = new List<ListViewItem>();
                    List<ListViewItem> sourcesSelected = new List<ListViewItem>();
                    lvwSources.BeginUpdate();
                    lvwSources.Items.Clear();
                    lvwSourcesSelected.Items.Clear();
                    foreach (string s in EventLogUtil.GetEventSources(hostName, cboLog.SelectedItem.ToString()))
                    {
                        ListViewItem lvi = new ListViewItem(s);
                        if (SelectedSources.Contains(s))
                            sourcesSelected.Add(lvi);
                        else
                        {
                            if (txtQuickFilter.Text.Trim().Length < 2 || s.ToLower().Contains(txtQuickFilter.Text))
                                sources.Add(lvi);
                        }
                    }
                    lvwSources.Items.AddRange(sources.ToArray());
                    lvwSourcesSelected.Items.AddRange(sourcesSelected.ToArray());
                }
                catch (System.Security.SecurityException)
                {
                    MessageBox.Show("This editor window requires that the application runs in Administrative mode to access all functionality!\r\nPlease restart the application in 'Administrative' mode if you need to access all functionality.", "Admin Access", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    lvwSources.EndUpdate();
                }
            }
        }

        private void cmdLoadEventLogs_Click(object sender, EventArgs e)
        {
            if (ComputerName.Length == 0)
                ComputerName = ".";
            LoadComputerEventsLogs();
        }

        private void cmdAddSource_Click(object sender, EventArgs e)
        {
            int startIndex = -1;
            if (lvwSources.SelectedItems.Count > 0)
                startIndex = lvwSources.SelectedItems[0].Index;
            foreach (ListViewItem lvi in lvwSources.SelectedItems)
            {
                SelectedSources.Add(lvi.Text);
            }
            LoadSources();
            if (startIndex > -1 && startIndex < lvwSources.Items.Count)
            {
                lvwSources.Items[startIndex].Selected = true;
                lvwSources.Items[startIndex].EnsureVisible();
            }

        }

        private void cmdRemoveSource_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwSourcesSelected.SelectedItems)
            {
                if (SelectedSources.Contains(lvi.Text))
                    SelectedSources.Remove(lvi.Text);
            }
            LoadSources();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            LogName = cboLog.Text;
            SelectedSources.Clear();
            foreach(ListViewItem lvi in lvwSourcesSelected.Items)
            {
                SelectedSources.Add(lvi.Text);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtQuickFilter_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdApplyFilter_Click(object sender, EventArgs e)
        {
            LoadSources();            
        }

        private void txtQuickFilter_EnterKeyPressed()
        {
            LoadSources();
        }
    }
}
