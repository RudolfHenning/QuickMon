using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HenIT.Windows.Controls.Graphing;
using HenIT.Data;

namespace QuickMon
{
    public partial class CollectorGraph :  FadeSnapForm, IChildWindowIdentity
    {
        public CollectorGraph()
        {
            InitializeComponent();
        }

        public MonitorPack HostingMonitorPack { get; set; }
        public List<CollectorHost> SelectedCollectors { get; set; } = new List<CollectorHost>();

        private List<Color> seriesColors = new List<Color>();

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
        private void CollectorGraph_Load(object sender, EventArgs e)
        {
            SnappingEnabled = true;
            splitContainer1.Panel1Collapsed = !showFiltersToolStripButton.Checked;
            fromDateTimeChooser.SelectedDateTime = DateTime.Now.AddDays(-1);
            toDateTimeChooser.SelectedDateTime = DateTime.Now;
            cboGroupBy.SelectedIndex = 0;
            lvwCollectorStates.AutoResizeColumnEnabled = true;
            toolTip1.SetToolTip(txtTextFilter, "You can use advanced filters like:\r\n\tX and Y or Z\r\n\tNot X\r\n\tmatchexactly X\r\n\tstartswith X\r\n\tendswith X");
            LoadDefaultGraphSettings();

            graphTypeToolStripMenuItem.Visible = false;
            grapthColorsToolStripMenuItem.Visible = false;
            graphVisibilityToolStripMenuItem.Visible = false;
        }
        private void CollectorGraph_Shown(object sender, EventArgs e)
        {
            LoadControls(true);
        }
        private void CollectorGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeRegisterChildWindow();
        }
        #endregion

        #region Toolbar Button events
        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            LoadControls();
        }
        private void showFiltersToolStripButton_CheckStateChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !showFiltersToolStripButton.Checked;
        }
        private void exportToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG files|*.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap exportedGraph = collectorTimeGraph.SaveToBitmap();
                exportedGraph.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                exportedGraph.Dispose();
            }
        } 
        #endregion

        private void LoadControls(bool reloadList = false)
        {
            DateTime fromTime = fromDateTimeChooser.SelectedDateTime;
            DateTime toTime = toDateTimeChooser.SelectedDateTime;
            DateTime autoStartDateTime = DateTime.Now.AddMinutes(-1);
            DateTime autoEndDateTime = DateTime.Now;

            long initialMax = (long)nudinitialMax.Value;
            long maxValue = 1;
            List<string> seriesNames = new List<string>();
            List<GraphSeries> graphSeriesList = new List<GraphSeries>();

            if (reloadList)
            {
                List<ListViewItem> list = new List<ListViewItem>();
                foreach (CollectorHost collector in SelectedCollectors)
                {
                    string itemName = $"{collector.PathWithoutMP}";
                    ListViewItem itm = new ListViewItem(itemName);
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
                }
                lvwCollectorStates.Items.Clear();
                lvwCollectorStates.Items.AddRange(list.ToArray());
            }
            else
            {
                foreach (ListViewItem lvi in lvwCollectorStates.Items)
                {
                    if (lvi.Tag is CollectorHost)
                    {
                        CollectorHost collector = (CollectorHost)lvi.Tag;
                        try
                        {
                            if (collector.CurrentState != null)
                                lvi.SubItems[1].Text = collector.CurrentState.ReadPrimaryOrFirstUIValue();
                            else
                                lvi.SubItems[1].Text = "";
                            lvi.ImageIndex = GetItemIcon(collector);
                        }
                        catch (Exception ex)
                        {
                            lvi.SubItems[1].Text = ex.Message;
                            lvi.ImageIndex = 10;
                        }
                    }
                }
            }

            //Making seriesses
            foreach (CollectorHost collector in SelectedCollectors)
            {
                Color seriesColor = seriesColors[graphSeriesList.Count % seriesColors.Count];
                GraphSeries series = SeriesFromCollector(collector, seriesColor, (int)nudLastXEntries.Value);
                if (series != null)
                {
                    if(collector.StateHistory.Count > 0)
                    {
                        MonitorState ms = (from m in collector.StateHistory
                                           where m.ReadFirstValueUnit() != ""
                                           select m).FirstOrDefault();

                        if (ms != null)
                        {
                            series.ValueUnit = ms.ReadFirstValueUnit();
                        }
                    }

                    seriesNames.Add(series.Name);
                    float val = series.Values.OrderByDescending(v => v.Value).FirstOrDefault().Value;
                    if (maxValue < val)
                        maxValue = (long)val;
                    DateTime firstTime = series.Values.OrderBy(v => v.Time).FirstOrDefault().Time;
                    if (autoStartDateTime > firstTime)
                        autoStartDateTime = firstTime;
                    graphSeriesList.Add(series);
                }
            }

            if (chkAutoFromTime.Checked)
            {
                fromTime = DateTime.Now;
                foreach (CollectorHost collector in SelectedCollectors)
                {
                    if (collector.StateHistory != null && collector.StateHistory.Count > 0)
                    {
                        MonitorState mp = collector.StateHistory.OrderBy(h => h.Timestamp).FirstOrDefault();
                        if (fromTime > mp.Timestamp)
                        {
                            fromTime = mp.Timestamp;
                        }
                    }
                }
                fromDateTimeChooser.SelectedDateTime = fromTime;
            }
            if (chkAutoToTime.Checked)
            {
                toTime = DateTime.Now;
                toDateTimeChooser.SelectedDateTime = toTime;
            }


            collectorTimeGraph.PauseUpdates();
            collectorTimeGraph.StartDateTime = fromTime;
            collectorTimeGraph.EndDateTime = toTime;
            collectorTimeGraph.MaxGraphValue = initialMax;
            collectorTimeGraph.Series = graphSeriesList;
            if (graphSeriesList == null || graphSeriesList.Count == 0)
            {
                collectorTimeGraph.GraphHeaderText = "No Series!";
                Text = $"Collector Graph";
            }
            else if (graphSeriesList.Count == 1)
            {
                collectorTimeGraph.GraphHeaderText = graphSeriesList[0].Name;
                Text = $"Collector Graph - {graphSeriesList[0].Name}";
            }
            else
            {
                collectorTimeGraph.GraphHeaderText = $"Collectors graph";
                Text = $"Collector Graph";
            }
            collectorTimeGraph.SetAutoMinMaxDateTimes(chkAutoFromTime.Checked, chkAutoToTime.Checked, chkAutoMaxValue.Checked);

            //collectorTimeGraph.BackgroundGradientColor1 = Properties.Settings.Default.GraphBackgroundColor1;
            //collectorTimeGraph.BackgroundGradientColor2 = Properties.Settings.Default.GraphBackgroundColor2;
            //collectorTimeGraph.GridColor = Properties.Settings.Default.GraphGridColor;
            //collectorTimeGraph.AxisLabelColor = Properties.Settings.Default.GraphAxisLabelsColor;
            //collectorTimeGraph.TimeSelectionColor = Properties.Settings.Default.GraphSelectionBarColor;
            ////collectorTimeGraph.GraphVerticalAxisType = (GraphVerticalAxisType)Properties.Settings.Default.GraphDefaultType;
            //collectorTimeGraph.GradientDirection = (System.Drawing.Drawing2D.LinearGradientMode)Properties.Settings.Default.GraphGradientDirection;
            //collectorTimeGraph.ClosestClickedValueColorType = (ClosestClickedValueColorType)Properties.Settings.Default.GraphClosestClickedValueType;
            //collectorTimeGraph.ClosestClickedValueCustomColor = Properties.Settings.Default.GraphClosestClickedValueColor;

            //collectorTimeGraph.ShowGraphHeader = Properties.Settings.Default.GraphHeaderVisible;
            //collectorTimeGraph.ShowLegendText = Properties.Settings.Default.GraphLegendVisible;
            //collectorTimeGraph.ShowHorisontalGridlines = Properties.Settings.Default.GraphHorisontalGridLinesVisible;
            //collectorTimeGraph.ShowVerticalGridLines = Properties.Settings.Default.GraphVerticalGridLinesVisible;
            //collectorTimeGraph.ShowSelectionBar = Properties.Settings.Default.GraphSelectionBarVisible;
            //collectorTimeGraph.HighlightClickedSeries = Properties.Settings.Default.GraphHighlightClickedSeriesVisible;
            //collectorTimeGraph.FillAreaBelowGraph = Properties.Settings.Default.GraphEnableFillAreaBelowSeries;
            //collectorTimeGraph.FillAreaBelowGraphAlpha = Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha;

            this.Invoke((MethodInvoker)delegate
            {
                collectorTimeGraph.RefreshGraph();
            });
        }
        private GraphSeries SeriesFromCollector(CollectorHost collector, Color seriesColor, int lastXEntries)
        {
            GraphSeries series = null;
            if (txtTextFilter.Text.Trim().Length < 2 || collector.PathWithoutMP.ContainEx(txtTextFilter.Text))
            //if (txtTextFilter.Text.Trim().Length < 2 || collector.PathWithoutMP.ToLower().Contains(txtTextFilter.Text.ToLower()))
            {
                string stateValue = "";
                float v = 0;
                List<TimeValue> filteredList = new List<TimeValue>();
                if (lastXEntries == 0)
                    lastXEntries = collector.StateHistory.Count;
                foreach (MonitorState agentState in (from hsm in collector.StateHistory
                                                     orderby hsm.Timestamp descending
                                                     select hsm).Take(lastXEntries))
                {
                    v = 0;
                    stateValue = agentState.ReadFirstValue(false);
                    if (stateValue != null && float.TryParse(stateValue, out v))
                    {
                        filteredList.Add(new TimeValue() { Time = agentState.Timestamp, Value = v });
                    }
                }
                //Last value
                v = 0;
                stateValue = collector.CurrentState.ReadFirstValue(false);
                if (stateValue != null && float.TryParse(stateValue, out v))
                {
                    filteredList.Add(new TimeValue() { Time = collector.CurrentState.Timestamp, Value = v });
                }

                series = new GraphSeries(collector.PathWithoutMP, seriesColor);
                if (cboGroupBy.SelectedIndex <= 0)
                {
                    series.Values.AddRange(filteredList);
                } 
                else
                {
                    int groupByMinutes = 1;
                    if (cboGroupBy.SelectedItem.IsNumber())
                    {
                        groupByMinutes = int.Parse(cboGroupBy.SelectedItem.ToString());
                    }
                    series.Values.AddRange(filteredList.GroupByMinutes(groupByMinutes));
                }


                //foreach (MonitorState agentState in (from hsm in collector.StateHistory
                //                                     orderby hsm.Timestamp descending
                //                                     select hsm).Take(lastXEntries))
                //{
                //    v = 0;
                //    stateValue = agentState.ReadFirstValue(false);
                //    if (stateValue != null && float.TryParse(stateValue, out v))
                //    {
                //        series.Values.Add(new TimeValue() { Time = agentState.Timestamp, Value = v });
                //    }
                //}
                //v = 0;
                //stateValue = collector.CurrentState.ReadFirstValue(false);
                //if (stateValue != null && float.TryParse(stateValue, out v))
                //{
                //    series.Values.Add(new TimeValue() { Time = collector.CurrentState.Timestamp, Value = v });
                //}


            }
            if (series != null && series.Values != null && series.Values.Count > 0)
                return series;
            //else if (series.Values.Count ==1)
            //{
            //    series.Name += " (Not enough data)";
            //    return series;
            //}
            else
                return null;
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
        private void LoadDefaultGraphSettings()
        {
            seriesColors = new List<Color>();
            seriesColors.AddRange((from string colorName in Properties.Settings.Default.GraphLineColors
                                   select HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorFromName(colorName)));

            collectorTimeGraph.GraphVerticalAxisType = (GraphVerticalAxisType)Properties.Settings.Default.GraphDefaultType;
            collectorTimeGraph.BackgroundGradientColor1 = Properties.Settings.Default.GraphBackgroundColor1;
            collectorTimeGraph.BackgroundGradientColor2 = Properties.Settings.Default.GraphBackgroundColor2;
            collectorTimeGraph.GridColor = Properties.Settings.Default.GraphGridColor;
            collectorTimeGraph.AxisLabelColor = Properties.Settings.Default.GraphAxisLabelsColor;
            collectorTimeGraph.TimeSelectionColor = Properties.Settings.Default.GraphSelectionBarColor;
            collectorTimeGraph.GradientDirection = (System.Drawing.Drawing2D.LinearGradientMode)Properties.Settings.Default.GraphGradientDirection;
            collectorTimeGraph.ClosestClickedValueColorType = (ClosestClickedValueColorType)Properties.Settings.Default.GraphClosestClickedValueType;
            collectorTimeGraph.ClosestClickedValueCustomColor = Properties.Settings.Default.GraphClosestClickedValueColor;
            collectorTimeGraph.ShowGraphHeader = Properties.Settings.Default.GraphHeaderVisible;
            collectorTimeGraph.ShowLegendText = Properties.Settings.Default.GraphLegendVisible;
            collectorTimeGraph.ShowHorisontalGridlines = Properties.Settings.Default.GraphHorisontalGridLinesVisible;
            collectorTimeGraph.ShowVerticalGridLines = Properties.Settings.Default.GraphVerticalGridLinesVisible;
            collectorTimeGraph.ShowSelectionBar = Properties.Settings.Default.GraphSelectionBarVisible;
            collectorTimeGraph.HighlightClickedSeries = Properties.Settings.Default.GraphHighlightClickedSeriesVisible;
            collectorTimeGraph.FillAreaBelowGraph = Properties.Settings.Default.GraphEnableFillAreaBelowSeries;
            collectorTimeGraph.FillAreaBelowGraphAlpha = Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha;
        }
        private void SetAxisType()
        {
            if (linearGraphTypeToolStripMenuItem.Checked)
            {
                collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Standard;
                collectorTimeGraph.SetAutoMinMaxDateTimes();
            }
            else
            {
                collectorTimeGraph.GraphVerticalAxisType = HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            }
            collectorTimeGraph.RefreshGraph();
        }


        #region Context menu events
        private void graphContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            linearGraphTypeToolStripMenuItem.Checked = collectorTimeGraph.GraphVerticalAxisType == HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Standard;
            logarithmicGraphTypeToolStripMenuItem.Checked = collectorTimeGraph.GraphVerticalAxisType == HenIT.Windows.Controls.Graphing.GraphVerticalAxisType.Logarithmic;
            graphHeaderVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowGraphHeader;
            legendVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowLegendText;
            graphSelectionbarVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowSelectionBar;
            graphHighlightClickedSeriesToolStripMenuItem.Checked = collectorTimeGraph.HighlightClickedSeries;
            graphFillAreaBelowSeriesEnabledToolStripMenuItem.Checked = collectorTimeGraph.FillAreaBelowGraph;
            graphHorisonalGridLinesVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowHorisontalGridlines;
            graphVerticalGridLinesVisibleToolStripMenuItem.Checked = collectorTimeGraph.ShowVerticalGridLines;
        }
        private void addCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectCollectors selectCollectors = new SelectCollectors();
            selectCollectors.HostingMonitorPack = HostingMonitorPack;
            selectCollectors.ExcludeCollectors = SelectedCollectors;
            if (selectCollectors.ShowDialog() == DialogResult.OK)
            {
                foreach(CollectorHost collector in selectCollectors.SelectedCollectors)
                {
                    SelectedCollectors.Add(collector);
                }
                LoadControls(true);
            }

        }
        private void removeCollectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<CollectorHost> collectorsToBeRemoved = new List<CollectorHost>();
            foreach(ListViewItem lvi in lvwCollectorStates.SelectedItems)
            {
                CollectorHost collector = (CollectorHost)lvi.Tag;
                SelectedCollectors.Remove(collector);
                //collectorsToBeRemoved.Add(collector);
                LoadControls(true);
            }
        }
        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showFiltersToolStripButton.Checked = !showFiltersToolStripButton.Checked;
        }
        private void linearGraphTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logarithmicGraphTypeToolStripMenuItem.Checked = !linearGraphTypeToolStripMenuItem.Checked;
            SetAxisType();
        }
        private void logarithmicGraphTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linearGraphTypeToolStripMenuItem.Checked = !logarithmicGraphTypeToolStripMenuItem.Checked;
            SetAxisType();
        }
        private void graphGradientColor1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.BackgroundGradientColor1;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.BackgroundGradientColor1 = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphGradientColor2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.BackgroundGradientColor2;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.BackgroundGradientColor2 = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void swapGraphGradientColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color backgroundGradientColor1 = collectorTimeGraph.BackgroundGradientColor1;
            Color backgroundGradientColor2 = collectorTimeGraph.BackgroundGradientColor2;
            collectorTimeGraph.BackgroundGradientColor1 = backgroundGradientColor2;
            collectorTimeGraph.BackgroundGradientColor2 = backgroundGradientColor1;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionForwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGradientDirectionBackwardDiagonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.GradientDirection = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphGridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.GridColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.GridColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphAxisLabelColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.AxisLabelColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.AxisLabelColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphSelectionBarColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color selectedColor = collectorTimeGraph.TimeSelectionColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Clipboard.SetText(colorDialog.Color.Name);
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
                collectorTimeGraph.TimeSelectionColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void graphClosestClickedColorSameAsSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.SeriesColor;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphClosestClickedColorInvertedColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.InvertedColor;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphClosestClickedColorCustomColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ClosestClickedValueColorType = HenIT.Windows.Controls.Graphing.ClosestClickedValueColorType.CustomColor;
            Color selectedColor = collectorTimeGraph.ClosestClickedValueCustomColor;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Clipboard.SetText(colorDialog.Color.Name);
                collectorTimeGraph.ClosestClickedValueCustomColor = colorDialog.Color;
                collectorTimeGraph.RefreshGraph();
            }
        }
        private void seriesColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GraphColorSettings graphColorSettings = new GraphColorSettings();
            graphColorSettings.GraphSettings = collectorTimeGraph.GetGraphSettings();
            graphColorSettings.GraphSettings.SeriesColors.AddRange((from Color s in seriesColors select GraphSettings.ConvertColorToName(s)));

            //graphColorSettings.InitializeGraphSettings();
            //graphColorSettings.GraphSettings.SeriesColors.AddRange((from string s in Properties.Settings.Default.GraphLineColors select s));
            //graphColorSettings.GraphSettings.BackgroundColor1 = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphBackgroundColor1);
            //graphColorSettings.GraphSettings.BackgroundColor2 = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphBackgroundColor2);
            //graphColorSettings.GraphSettings.GridColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphGridColor);
            //graphColorSettings.GraphSettings.AxisLabelsColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphAxisLabelsColor);
            //graphColorSettings.GraphSettings.SelectionBarColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphSelectionBarColor);
            //graphColorSettings.GraphSettings.GraphType = Properties.Settings.Default.GraphDefaultType;
            //graphColorSettings.GraphSettings.GradientDirection = Properties.Settings.Default.GraphGradientDirection;
            //graphColorSettings.GraphSettings.ClosestClickedValueType = Properties.Settings.Default.GraphClosestClickedValueType;
            //graphColorSettings.GraphSettings.ClosestClickedValueColor = GraphSettings.ConvertColorToName(Properties.Settings.Default.GraphClosestClickedValueColor);
            //graphColorSettings.GraphSettings.HeaderVisible = Properties.Settings.Default.GraphHeaderVisible;
            //graphColorSettings.GraphSettings.FooterVisible = Properties.Settings.Default.GraphLegendVisible;
            //graphColorSettings.GraphSettings.HorisontalGridLinesVisible = Properties.Settings.Default.GraphHorisontalGridLinesVisible;
            //graphColorSettings.GraphSettings.VerticalGridLinesVisible = Properties.Settings.Default.GraphVerticalGridLinesVisible;
            //graphColorSettings.GraphSettings.SelectionBarVisible = Properties.Settings.Default.GraphSelectionBarVisible;
            //graphColorSettings.GraphSettings.HighlightClickedSeriesVisible = Properties.Settings.Default.GraphHighlightClickedSeriesVisible;
            //graphColorSettings.GraphSettings.EnableFillAreaBelowSeries = Properties.Settings.Default.GraphEnableFillAreaBelowSeries;
            //graphColorSettings.GraphSettings.FillAreaBelowSeriesAlpha = Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha;

            //graphColorSettings.GraphSettings.GridColor = Properties.Settings.Default.GraphGridColor.Name;
            if (graphColorSettings.ShowDialog() == DialogResult.OK)
            {
                collectorTimeGraph.SetFromGraphSettings(graphColorSettings.GraphSettings);
                seriesColors = new List<Color>();
                seriesColors.AddRange((from string colorName in graphColorSettings.GraphSettings.SeriesColors
                                       select GraphSettings.ConvertColorFromName(colorName)));

                //Properties.Settings.Default.GraphLineColors = new System.Collections.Specialized.StringCollection();
                //Properties.Settings.Default.GraphLineColors.AddRange(graphColorSettings.GraphSettings.SeriesColors.ToArray());
                //Properties.Settings.Default.GraphBackgroundColor1 = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.BackgroundColor1);
                //Properties.Settings.Default.GraphBackgroundColor2 = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.BackgroundColor2);
                //Properties.Settings.Default.GraphGridColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.GridColor);
                //Properties.Settings.Default.GraphAxisLabelsColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.AxisLabelsColor);
                //Properties.Settings.Default.GraphDefaultType = graphColorSettings.GraphSettings.GraphType;
                //Properties.Settings.Default.GraphGradientDirection = graphColorSettings.GraphSettings.GradientDirection;
                //Properties.Settings.Default.GraphClosestClickedValueType = graphColorSettings.GraphSettings.ClosestClickedValueType;
                //Properties.Settings.Default.GraphClosestClickedValueColor = GraphSettings.ConvertColorFromName(graphColorSettings.GraphSettings.ClosestClickedValueColor);
                //Properties.Settings.Default.GraphHeaderVisible = graphColorSettings.GraphSettings.HeaderVisible;
                //Properties.Settings.Default.GraphLegendVisible = graphColorSettings.GraphSettings.FooterVisible;
                //Properties.Settings.Default.GraphHorisontalGridLinesVisible = graphColorSettings.GraphSettings.HorisontalGridLinesVisible;
                //Properties.Settings.Default.GraphVerticalGridLinesVisible = graphColorSettings.GraphSettings.VerticalGridLinesVisible;
                //Properties.Settings.Default.GraphSelectionBarVisible = graphColorSettings.GraphSettings.SelectionBarVisible;
                //Properties.Settings.Default.GraphHighlightClickedSeriesVisible = graphColorSettings.GraphSettings.HighlightClickedSeriesVisible;
                //Properties.Settings.Default.GraphEnableFillAreaBelowSeries = graphColorSettings.GraphSettings.EnableFillAreaBelowSeries;
                //Properties.Settings.Default.GraphFillAreaBelowSeriesAlpha = graphColorSettings.GraphSettings.FillAreaBelowSeriesAlpha;

                //collectorTimeGraph.GraphVerticalAxisType = (GraphVerticalAxisType)Properties.Settings.Default.GraphDefaultType;
                //LoadGraphColors();
                LoadControls(true);
            }
        }
        private void graphHeaderVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowGraphHeader = graphHeaderVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void legendVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowLegendText = legendVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphHorisonalGridLinesVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowHorisontalGridlines = graphHorisonalGridLinesVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphVerticalGridLinesVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowVerticalGridLines = graphVerticalGridLinesVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphSelectionbarVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.ShowSelectionBar = graphSelectionbarVisibleToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphHighlightClickedSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.HighlightClickedSeries = graphHighlightClickedSeriesToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaBelowSeriesEnabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraph = graphFillAreaBelowSeriesEnabledToolStripMenuItem.Checked;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 16;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 32;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha48ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 48;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha64ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 64;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha128ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 128;
            collectorTimeGraph.RefreshGraph();
        }
        private void graphFillAreaAlpha192ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collectorTimeGraph.FillAreaBelowGraphAlpha = 192;
            collectorTimeGraph.RefreshGraph();
        }
        #endregion

        private void txtTextFilter_EnterKeyPressed()
        {
            LoadControls();
        }

        private void txtTextFilter_TextChanged(object sender, EventArgs e)
        {
            lblResetText.Visible = txtTextFilter.Text != "";
        }

        private void lblResetText_Click(object sender, EventArgs e)
        {
            txtTextFilter.Text = "";
            LoadControls();
        }


    }
}
