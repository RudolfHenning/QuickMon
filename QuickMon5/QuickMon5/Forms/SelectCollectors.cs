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
    public partial class SelectCollectors : Form
    {
        public SelectCollectors()
        {
            InitializeComponent();
        }

        public MonitorPack HostingMonitorPack { get; set; }
        public List<CollectorHost> SelectedCollectors { get; set; } = new List<CollectorHost>();
        public List<CollectorHost> ExcludeCollectors { get; set; } = new List<CollectorHost>();

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

        private void SelectCollectors_Load(object sender, EventArgs e)
        {
            lvwCollector.AutoResizeColumnEnabled = true;
            cboFilterType.SelectedIndex = 0;
            cboStateFilter.SelectedIndex = 0;
            LoadControls();
        }

        private void LoadControls()
        {
            List<ListViewItem> list = new List<ListViewItem>();
            if (HostingMonitorPack != null) {
                foreach (CollectorHost collector in HostingMonitorPack.CollectorHosts)
                {
                    if (IsInFilter(collector)) 
                    //if (collector.CollectorAgents != null && collector.CollectorAgents.Count > 0 && !ExcludeCollectors.Contains(collector))
                    {
                        ListViewItem lvi = new ListViewItem(collector.PathWithoutMP);
                        lvi.SubItems.Add(collector.CurrentState.ReadFirstValue());
                        lvi.Tag = collector;
                        lvi.ImageIndex = GetItemIcon(collector);
                        list.Add(lvi);
                    }
                }
                lvwCollector.Items.Clear();
                lvwCollector.Items.AddRange(list.OrderBy(c => c.Text).ToArray());
            }

        }
        private bool IsInFilter(CollectorHost collector)
        {
            bool isInFilter = false;
            bool inState = false;
            bool isNotFolderOrEmpty = (collector.CollectorAgents != null && collector.CollectorAgents.Count > 0);
            if (!ExcludeCollectors.Contains(collector))
            {
                if (txtFilter.Text.Trim().Length == 0 && cboStateFilter.SelectedIndex == 0)
                {
                    isInFilter = true;
                    inState = true;
                }
                else
                {
                    if (cboStateFilter.SelectedIndex == 0)
                        inState = true;
                    if (txtFilter.Text.Trim().Length == 0)
                        isInFilter = true;
                    if (collector.CurrentState != null)
                    {
                        if (cboStateFilter.SelectedIndex == 1 && collector.CurrentState.State == CollectorState.Good)
                            inState = true;
                        else if (cboStateFilter.SelectedIndex == 2 && collector.CurrentState.State == CollectorState.Warning)
                            inState = true;
                        else if (cboStateFilter.SelectedIndex == 3 && (collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError))
                            inState = true;
                        else if (cboStateFilter.SelectedIndex == 4 && (collector.CurrentState.State == CollectorState.Warning || collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError))
                            inState = true;

                        if ((cboFilterType.SelectedIndex == 0 || cboFilterType.SelectedIndex == 1) && collector.PathWithoutMP.ToLower().Contains(txtFilter.Text.ToLower()))
                            isInFilter = true;
                        else if ((cboFilterType.SelectedIndex == 0 || cboFilterType.SelectedIndex == 2) &&
                            ((from string c in collector.Categories
                              where c.ToLower().Contains(txtFilter.Text.ToLower())
                              select c).FirstOrDefault() != null))
                        {
                            isInFilter = true;
                        }
                        else if ((cboFilterType.SelectedIndex == 0 || cboFilterType.SelectedIndex == 3) &&
                            (collector.CurrentState.ReadPrimaryOrFirstUIValue().ToLower().Contains(txtFilter.Text.ToLower())))
                        {
                            isInFilter = true;
                        }

                    }
                }
            }
            return isNotFolderOrEmpty && isInFilter && inState;
        }

        private void lvwCollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = lvwCollector.SelectedItems.Count > 0;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lvwCollector.SelectedItems.Count > 0)
            {
                SelectedCollectors = new List<CollectorHost>();
                foreach(ListViewItem lvi in lvwCollector.SelectedItems)
                {
                    SelectedCollectors.Add((CollectorHost)lvi.Tag);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
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

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            lblResetText.Visible = txtFilter.Text.Length > 0;
        }

        private void lblResetText_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
        }
    }
}
