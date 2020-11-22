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

        #region Form events
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
        #endregion


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
                Cursor.Current = Cursors.WaitCursor;
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
                        itm.SubItems.Add(collector.PathWithoutMP);
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
                    UpdateRawView();
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private bool IsInFilter(CollectorHost collector)
        {
            bool isInFilter = false;
            bool inState = false;
            bool isNotFolderOrEmpty = includeEmptyfolderCollectorsToolStripMenuItem.Checked || (collector.CollectorAgents.Count > 0);
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
                    else if (cboStateFilter.SelectedIndex == 3 && (collector.CurrentState.State == CollectorState.Warning || collector.CurrentState.State == CollectorState.Error || collector.CurrentState.State == CollectorState.ConfigurationError))
                        inState = true;


                    if ((cboFilterType.SelectedIndex == 0 || cboFilterType.SelectedIndex == 1) && collector.DisplayName.ToLower().Contains(txtFilter.Text.ToLower()))
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

            return isNotFolderOrEmpty && isInFilter && inState;
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

        private void lvwCollectorStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRawView();
        }

        private void UpdateRawView()
        {
            try
            {
                if (lvwCollectorStates.SelectedItems.Count == 1)
                {
                    HenIT.RTF.RTFBuilder rtfBuilder = new HenIT.RTF.RTFBuilder();
                    object selectedObject = lvwCollectorStates.SelectedItems[0].Tag;
                    if (selectedObject is CollectorHost)
                    {
                        MonitorState ms = ((CollectorHost)selectedObject).CurrentState;
                        WriteMonitorState(rtfBuilder, ms);
                        string categories = "";
                        ((CollectorHost)selectedObject).Categories.ForEach(c => categories += c + ",");
                        if (categories.Trim().Length > 0)
                            rtfBuilder.FontStyle(FontStyle.Bold).Append("Categories: ").FontStyle(FontStyle.Regular).AppendLine(categories.Trim(','));
                    }
                    rtxDetails.Rtf = rtfBuilder.ToString();
                    rtxDetails.SelectionStart = 0;
                    rtxDetails.SelectionLength = 0;
                    rtxDetails.ScrollToCaret();
                }
                else
                {
                    rtxDetails.Text = "";
                }
            }
            catch(Exception ex) {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
        }
        private void WriteMonitorState(HenIT.RTF.RTFBuilder rtfBuilder, MonitorState ms)
        {
            if (ms != null)
            {
                if (FormatUtils.N(ms.ForAgent) != "")
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("For object: ").FontStyle(FontStyle.Regular).AppendLine(ms.ForAgent);
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Time: ").FontStyle(FontStyle.Regular).AppendLine(ms.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                rtfBuilder.FontStyle(FontStyle.Bold).Append("State: ").FontStyle(FontStyle.Regular).AppendLine(ms.State.ToString());
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Duration: ").FontStyle(FontStyle.Regular).AppendLine(ms.CallDurationMS.ToString() + " ms");
                if (ms.AlertsRaised != null)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).Append("Alert count: ").FontStyle(FontStyle.Regular).AppendLine(ms.AlertsRaised.Count.ToString());
                }

                rtfBuilder.FontStyle(FontStyle.Bold).Append("Executed on: ").FontStyle(FontStyle.Regular).AppendLine(FormatUtils.N(ms.ExecutedOnHostComputer));
                rtfBuilder.FontStyle(FontStyle.Bold).Append("Ran as: ").FontStyle(FontStyle.Regular).AppendLine(FormatUtils.N(ms.RanAs));
                rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Value(s): ").FontStyle(FontStyle.Regular).AppendLine(ms.ReadAgentValues());
                if (ms.State != CollectorState.Good && ms.RawDetails != null && ms.RawDetails.Length > 0)
                {
                    rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Raw details: ").FontStyle(FontStyle.Regular).AppendLine(ms.RawDetails);
                }
                if (ms.AlertsRaised != null)
                {
                    if (ms.AlertsRaised.Count > 0)
                    {
                        string alertSummary = "";
                        ms.AlertsRaised.ForEach(a => alertSummary += '\t' + a.TrimEnd('\r', '\n').Replace("\r\n", "\r\n\t") + "\r\n");
                        alertSummary = alertSummary.Trim('\r', '\n');
                        rtfBuilder.FontStyle(FontStyle.Bold).AppendLine("Alert details:").FontStyle(FontStyle.Regular).AppendLine(alertSummary.TrimEnd('\r', '\n'));
                    }
                }
            }
        }

        private void txtFilter_EnterKeyPressed()
        {
            LoadControls();
        }

        private void includeEmptyfolderCollectorsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void collectorDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParentWindow != null && ParentWindow is MainForm && lvwCollectorStates.SelectedItems.Count == 1 && lvwCollectorStates.SelectedItems[0].Tag is CollectorHost)
            {
                CollectorHost ch = (CollectorHost)lvwCollectorStates.SelectedItems[0].Tag;
                MainForm mainForm = (MainForm)ParentWindow;
                mainForm.ShowCollectorDetails(ch);
            }
        }
    }
}
