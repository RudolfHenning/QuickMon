using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public partial class CollectorFilterView : Form, IChildWindowIdentity
    {
        public CollectorFilterView()
        {
            InitializeComponent();
        }
        public MonitorPack HostingMonitorPack { get; set; }

        #region TreeNodeImage contants
        private readonly int collectorFolderImage = 0;
        private readonly int collectorNAstateImage = 1;
        private readonly int collectorGoodStateImage1 = 2;
        private readonly int collectorGoodStateImage2 = 5;
        private readonly int collectorWarningStateImage1 = 3;
        private readonly int collectorWarningStateImage2 = 6;
        private readonly int collectorErrorStateImage1 = 4;
        private readonly int collectorErrorStateImage2 = 7;
        private readonly int collectorDisabled = 8;
        private readonly int collectorOutOfServiceWindowstateImage = 9;
        #endregion

        #region IChildWindowIdentity
        /// <summary>
        /// reference to MainForm for bidirectional updating
        /// </summary>
        public IParentWindow ParentWindow { get; set; }
        /// <summary>
        /// If set to true the main window refresh cycle will also trigger a refresh of this window's details (the states/current value/history etc)
        /// </summary>
        public bool AutoRefreshEnabled { get; set; }
        public string Identifier { get; set; }
        public void RefreshDetails()
        {
            if (HostingMonitorPack != null)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    LoadControls();
                });
            }
        }
        public void DeRegisterChildWindow()
        {
            if (ParentWindow != null)
                ParentWindow.RemoveChildWindow(this);
        }
        public void ShowChildWindow(IParentWindow parentWindow = null)
        {
            if (parentWindow != null)
                ParentWindow = parentWindow;
            if (ParentWindow != null)
                ParentWindow.RegisterChildWindow(this);
            Show();
        }
        #endregion


        private void CollectorFilterView_Load(object sender, EventArgs e)
        {
            cboFilterType.SelectedIndex = 0;
            cboStateFilter.SelectedIndex = 0;
            agentStateSplitContainer.Panel2Collapsed = true;
            lvwCollectorStates.AutoResizeColumnEnabled = true;
        }
        private void CollectorFilterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        }
        private void CollectorFilterView_Shown(object sender, EventArgs e)
        {
            LoadControls();
        }


        private void cmdViewDetails_Click(object sender, EventArgs e)
        {
            agentStateSplitContainer.Panel2Collapsed = !agentStateSplitContainer.Panel2Collapsed;
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void LoadControls()
        {
            if (HostingMonitorPack != null)
            {
                string selectedCollectorUniqueId = "";
                if (lvwCollectorStates.SelectedItems.Count > 0 && lvwCollectorStates.SelectedItems[0].Tag is CollectorHost)
                {
                    selectedCollectorUniqueId = ((CollectorHost)lvwCollectorStates.SelectedItems[0].Tag).UniqueId;
                }

                List<ListViewItem> list = new List<ListViewItem>();
                foreach (var collector in HostingMonitorPack.CollectorHosts)
                {
                    if (IsInFilter(collector))
                    {
                        
                        ListViewItem itm = new ListViewItem(collector.DisplayName);
                        itm.SubItems.Add(collector.Path);
                        itm.Tag = collector;
                        try
                        {
                            if (collector.CurrentState != null)
                                itm.SubItems.Add(collector.CurrentState.ReadPrimaryOrFirstUIValue());
                            else
                                itm.SubItems.Add("");
                            itm.ImageIndex = GetItemIcon(collector);
                        }
                        catch (Exception ex)
                        {
                            itm.SubItems.Add(ex.Message);
                            itm.ImageIndex = 10;
                        }
                        list.Add(itm);
                        if (selectedCollectorUniqueId != "" && selectedCollectorUniqueId == collector.UniqueId)
                            itm.Selected = true;
                    }
                }
                lvwCollectorStates.Items.Clear();
                lvwCollectorStates.Items.AddRange(list.ToArray());
                if (lvwCollectorStates.SelectedItems.Count > 0)
                {
                    lvwCollectorStates.SelectedItems[0].EnsureVisible();
                }
            }
        }

        private bool IsInFilter(CollectorHost collector)
        {
            bool isInFilter = false;
            if(txtFilter.Text.Trim().Length == 0 && cboStateFilter.SelectedIndex == 0)
            {
                isInFilter = true;
            }
            else if (txtFilter.Text.Trim().Length == 0)
            {
                if (collector.CurrentState != null)
                {
                    if (cboStateFilter.SelectedIndex == 1 && collector.CurrentState.State == CollectorState.Good)
                    {
                        isInFilter = true;
                    }
                    else if (cboStateFilter.SelectedIndex == 2 && collector.CurrentState.State == CollectorState.Warning)
                    {
                        isInFilter = true;
                    }
                    else if (cboStateFilter.SelectedIndex == 3 && (collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError))
                    {
                        isInFilter = true;
                    }
                    else if (cboStateFilter.SelectedIndex == 3 && (collector.CurrentState.State == CollectorState.Warning || collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError))
                    {
                        isInFilter = true;
                    }
                }
            }
            else
            {

                if (collector.CurrentState != null)
                {
                    if (collector.DisplayName.ToLower().Contains(txtFilter.Text.ToLower()))
                        isInFilter = true;

                }
            }

            return isInFilter;
        }

        private int GetItemIcon(CollectorHost collector)
        {
            int imageIndex = collectorNAstateImage;

            if (collector.CollectorAgents.Count == 0 || collector.CurrentState.State == CollectorState.None)
            {
                imageIndex = collectorFolderImage;
            }
            else if (!collector.Enabled || collector.CurrentState.State == CollectorState.Disabled)
            {
                imageIndex = collectorDisabled;
            }
            else if (collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError)
            {
                imageIndex = collectorErrorStateImage1;
            }
            else if (collector.CurrentState.State == CollectorState.Warning)
            {
                imageIndex = collectorWarningStateImage1;
            }
            else if (collector.CurrentState.State == CollectorState.Good)
            {
                imageIndex = collectorGoodStateImage1;
            }
            else if (collector.CurrentState.State == CollectorState.NotInServiceWindow)
            {             
                imageIndex = collectorOutOfServiceWindowstateImage;
            }
            return imageIndex;
        }
    }
}
