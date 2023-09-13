using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace HenIT.Windows.Controls.Graphing
{
    public delegate void TimeValueDelegate(string seriesName, TimeValue tv);
    [Serializable]
    public partial class TimeGraphControl : Control
    {
        public TimeGraphControl()
        {
            InitializeComponent();
            //LastClickedTime = DateTime.Now.AddYears(1); //somewhere way ahead
            resizeTimer.Tick += ResizeTimer_Tick;
            InitializeStyles();
            ClosestClickedTimeValue = null;
            InitialMaxGraphValue = 100;
            DoubleBuffered = true;
            gridWidth = this.Width - LeftAxisMargin - RightAxisMargin;
            gridHeight = this.Height - legendHeight - headerHeight;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }
        #endregion

        #region Properties
        public GraphVerticalAxisType GraphVerticalAxisType { get; set; } = GraphVerticalAxisType.Standard;
        public GraphLineFormatType GraphLineFormatType { get; set; } = GraphLineFormatType.Straight;
        public Color GridColor { get; set; } = Color.DarkSlateGray;
        public Color AxisLabelColor { get; set; } = Color.White;
        public Color TimeSelectionColor { get; set; } = Color.Yellow;
        public Color BackgroundColor { get; set; } = Color.Black;
        public bool BackgroundIsGradient { get; set; } = true;
        public Color BackgroundGradientColor1 { get; set; } = Color.Black;
        public Color BackgroundGradientColor2 { get; set; } = Color.FromArgb(42, 42, 42);
        public LinearGradientMode GradientDirection { get; set; } = LinearGradientMode.Vertical;

        [Browsable(false)]
        public List<GraphSeries> Series { get; set; } = new List<GraphSeries>();
        public Font GraphTextFont { get; set; } = new Font(new FontFamily("Verdana"), 8, FontStyle.Regular);

        private DateTime startDateTime;
        private DateTime endDateTime;
        private double totalDurationInSeconds = 0;
        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; if (startDateTime < endDateTime) totalDurationInSeconds = endDateTime.Subtract(startDateTime).TotalSeconds; }
        }
        public DateTime EndDateTime { 
            get { return endDateTime; } 
            set { endDateTime = value; if (startDateTime < endDateTime) totalDurationInSeconds = endDateTime.Subtract(startDateTime).TotalSeconds; }
        }
        public long MaxGraphValue { get; set; } = 1;
        public long InitialMaxGraphValue { get; set; } = 1;
        //public long MinGraphValue { get; set; } = 0;
        public bool ShowLegendText { get; set; }
        public int LeftAxisMargin { get; set; } = 25;
        public int RightAxisMargin { get; set; } = 25;
        public TimeValue ClosestClickedTimeValue { get; private set; }
        public string ClosestClickedTimeSeriesName { get; private set; } = "";
        public ClosestClickedValueColorType ClosestClickedValueColorType { get; set; } = ClosestClickedValueColorType.SeriesColor;
        public Color ClosestClickedValueCustomColor { get; set; } = Color.White;
        public bool LastClickedTimeSelected {
            get { return clickedSelectedValueTime; }
            set { clickedSelectedValueTime = value; }
        }
        public bool ShowGraphHeader { get; set; } = false;         
        public Font GraphHeaderFont { get; set; } = new Font(new FontFamily("Verdana"), 12, FontStyle.Regular);
        public string GraphHeaderText { get; set; } = "";

        public double LastClickedValue { get; set; } = -1;
        public TimeValue LastClickedLocation { get; set; } = null;
        public bool ShowLastClickedLocation { get; set; } = false;
        public bool ShowSelectionBar { get; set; }
        public bool ShowClosestClickedValue { get; set; } = false;
        public bool HighlightClickedSeries { get; set; } = false;
        public int HighlightSeriesWidth { get; set; } = 3;
        public int NoHighlightSeriesWidth { get; set; } = 2;
        public bool ShowClickScanSearchBlock { get; set; } = false;
        public bool FillAreaBelowGraph { get; set; } = false;
        public int FillAreaBelowGraphAlpha { get; set; } = 48;
        public bool ShowVerticalGridLines { get; set; } = true;
        public bool ShowHorisontalGridlines { get; set; } = true;
        #endregion

        #region Privates
        private System.ComponentModel.IContainer components = null;
        //private long maxMinGraphValue = 0;
        //private long minMaxGraphValue = 100;
        private int legendHeight = 0;
        private int headerHeight = 0;
        private int gridWidth = 1;
        private int gridHeight = 1;
        private int minimumHeightForDetailGrid = 230;
        private int minimumHeightForExtraHorisontalLines = 300;
        private Timer resizeTimer = new Timer() { Interval = 200, Enabled = false };
        private bool clickedSelectedValueTime = false;
        private DateTime lastClickTime = DateTime.Now;
        private bool pauseUpdate = false;

        private Point selectionTopLeft;
        private Point selectionBottomRight;
        private long cookedMaxGraphValue;
        #endregion

        #region Events
        //public event Action LeftKeyPressed;
        //public event Action RightKeyPressed;
        
        public event TimeValueDelegate ClosestPointSelectedChanged;
        public event EventHandler GraphClicked;
        private void RaiseGraphClicked()
        {
            GraphClicked?.Invoke(this, null);
        }
        #endregion

        private void InitializeStyles()
        {
            /* Enable double buffering and similiar techniques to 
             * eliminate flicker */

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
        }

        #region Overrides
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Left)
            //{
            //    e.SuppressKeyPress = true;
            //    e.Handled = true;
            //    LeftKeyPressed?.Invoke();
            //    Application.DoEvents();
            //    Focus();
            //}
            //else if (e.KeyCode == Keys.Right)
            //{
            //    e.SuppressKeyPress = true;
            //    e.Handled = true;
            //    RightKeyPressed?.Invoke();
            //    Application.DoEvents();
            //    Focus();
            //}
            //else
                base.OnKeyUp(e);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataClickTest(e);
                Application.DoEvents();
                Focus();
            }
            base.OnMouseClick(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            /* We're going to need to recalculate our maximum 
             * coordinates since our graphable width changed */
            Refresh();

            base.OnSizeChanged(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsInDesignMode())
            {
                Graphics g = e.Graphics;
                //int controlWidth = this.Width;
                //int controlHeight = this.Height;
                SmoothingMode prevSmoothingMode = g.SmoothingMode;
                DrawBackground(ref g);
                g.SmoothingMode = prevSmoothingMode;
            }
            else if (!IsInDesignMode() && !pauseUpdate)
            {
                Graphics g = e.Graphics;
                SmoothingMode prevSmoothingMode = g.SmoothingMode;
                g.SmoothingMode = SmoothingMode.HighQuality;                

                DrawGraph(ref g);
                g.SmoothingMode = prevSmoothingMode;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            resizeTimer.Enabled = false;
            base.OnResize(e);
            resizeTimer.Enabled = true;
        }
        public override void Refresh()
        {
            base.Refresh();
        }
        public void RefreshGraph()
        {
            pauseUpdate = false;
            base.Refresh();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    SetPreviousFromClosestPointSelected();
                    RefreshGraph();
                    break;
                case Keys.Right:
                    SetNextFromClosestPointSelected();
                    RefreshGraph();                    
                    break;
                case Keys.Up:
                    SetPreviousSelectedSeries();
                    RefreshGraph();
                    break;
                case Keys.Down:
                    SetNextSelectedSeries();
                    RefreshGraph();
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }
        #endregion

        #region DataClickTest
        private void DataClickTest(MouseEventArgs e)
        {
            clickedSelectedValueTime = false;
            if (StartDateTime < EndDateTime && lastClickTime.AddMilliseconds(100) < DateTime.Now)
            {
                lastClickTime = DateTime.Now;

                if (ShowLegendText && e.Y > (Height - legendHeight)) //legend area
                {
                    ClosestClickedTimeValue = null;
                    foreach (GraphSeries s in Series)
                        s.Selected = false;

                    foreach (var enabledSeries in (from serie in Series
                                                   where serie.Enabled
                                                   select serie))
                    {
                        if (enabledSeries.CurrentSeriesLabelLocation.X <= e.X && enabledSeries.CurrentSeriesLabelLocation.X + enabledSeries.CurrentSeriesLabelSize.Width > e.X)
                        {
                            if (enabledSeries.CurrentSeriesLabelLocation.Y <= e.Y && enabledSeries.CurrentSeriesLabelLocation.Y + enabledSeries.CurrentSeriesLabelSize.Height > e.Y)
                            {
                                SetSelectedSeriesByName(enabledSeries.Name);
                            }
                        }
                    }
                }
                else
                {
                    LastClickedLocation = ConvertPointToTimeValue(e.X, e.Y);
                    if (LastClickedLocation != null)
                    {
                        SetClosestPointSelected();
                    }
                    else
                    {
                        ClosestClickedTimeValue = null;
                        foreach (GraphSeries s in Series)
                            s.Selected = false;
                    }
                }
                SetHightlightSeries();

                this.Invalidate();
                RaiseGraphClicked();
            }
        } 
        private List<Tuple<string, TimeValue>> GetAllEnabledSeriesValues()
        {
            List<Tuple<string, TimeValue>> allValues = new List<Tuple<string, TimeValue>>();
            foreach (GraphSeries gs in (from g in Series
                                        where g.Enabled
                                        select g))
            {
                foreach(TimeValue tv in gs.Values)
                {
                    allValues.Add(new Tuple<string, TimeValue>(gs.Name, tv));
                }
            }
            return allValues;
        }
        public Tuple<string, TimeValue> GetClosestToClickEntry()
        {
            Tuple<string, TimeValue> closesValue = null;
            if (LastClickedLocation != null)
            {
                int controlWidth = this.Width;
                int controlHeight = this.Height;
                float cookedMaxValue = cookedMaxGraphValue;
                double totalSeconds = EndDateTime.Subtract(StartDateTime).TotalSeconds;

                //loop through serieses checking for a value that is within LastClickedLocation +- range. 
                //Repeat with increase ranges until the first value is found
                var allValues = GetAllEnabledSeriesValues();

                double widthFraction = 5;
                double heightFraction = 5;
                Point lastClickedLocationPoint = ConvertTimeValueToPoint(LastClickedLocation);
                if (lastClickedLocationPoint.X >= 0 && lastClickedLocationPoint.Y >= 0)
                {
                    while (widthFraction < (controlWidth / 4))
                    {
                        TimeValue topLeft = ConvertPointToTimeValue((int)(lastClickedLocationPoint.X - widthFraction), (int)(lastClickedLocationPoint.Y - heightFraction), true);
                        TimeValue bottomRight = ConvertPointToTimeValue((int)(lastClickedLocationPoint.X + widthFraction), (int)(lastClickedLocationPoint.Y + heightFraction), true);
                        if (topLeft != null && bottomRight != null)
                        {
                            var closestPossible = (from av in allValues
                                                   orderby av.Item2.Value, av.Item2.Time
                                                   where av.Item2.Time >= topLeft.Time &&
                                                          av.Item2.Time <= bottomRight.Time &&
                                                          av.Item2.Value <= topLeft.Value &&
                                                          FloorValue(av.Item2.Value) >= bottomRight.Value
                                                   select av).FirstOrDefault();
                            if (closestPossible != null)
                            {
                                closesValue = closestPossible;
                                selectionTopLeft = ConvertTimeValueToPoint(topLeft);
                                selectionBottomRight = ConvertTimeValueToPoint(bottomRight);
                                break;
                            }
                        }

                        widthFraction = widthFraction + 10;
                        heightFraction = heightFraction + 10;
                    }
                }
            }
            return closesValue;
        }
        public GraphSeries GetSeriesByName(string name)
        {
            foreach (GraphSeries s in Series)
            {
                if (s.Name == ClosestClickedTimeSeriesName)
                    return s;                
            }
            return null;
        }
        public int GetSeriesIndexByName(string name)
        {
            for (int i = 0; i < Series.Count; i++)
            {
                if (Series[i].Name == name)
                {
                    return i;
                }
            }
            return 0;
        }
        public void SetSelectedSeriesByName(string name)
        {            
            foreach (var s in Series)
            {
                if (s.Name == name)
                {
                    s.Selected = true;
                    ClosestClickedTimeSeriesName = name;
                }
                else
                    s.Selected = false;
            }
        }
        public void SetClosestPointSelected()
        {
            if (LastClickedLocation != null)
            {
                var closetValue = GetClosestToClickEntry();
                if (closetValue != null)
                {
                    ClosestClickedTimeSeriesName = closetValue.Item1;
                    ClosestClickedTimeValue = closetValue.Item2;
                    foreach(GraphSeries s in Series)
                    {
                        if (s.Name == ClosestClickedTimeSeriesName)
                            s.Selected = true;
                        else
                            s.Selected = false;
                    }
                }
                else
                {
                    ClosestClickedTimeValue = null;
                    ClosestClickedTimeSeriesName = "";
                    foreach (GraphSeries s in Series)
                        s.Selected = false;
                }
            }
        }
        public void SetPreviousFromClosestPointSelected()
        {
            if (ClosestClickedTimeSeriesName != null && ClosestClickedTimeSeriesName != "" && ClosestClickedTimeValue != null)
            {
                GraphSeries selectedSeries = GetSeriesByName(ClosestClickedTimeSeriesName);
                TimeValue tv = (from sv in selectedSeries.Values
                                orderby sv.Time descending
                                where sv.Time < ClosestClickedTimeValue.Time
                                select sv).FirstOrDefault();
                if (tv != null)
                {
                    ClosestClickedTimeValue = tv;
                    LastClickedLocation = tv;
                    ClosestPointSelectedChanged?.Invoke(ClosestClickedTimeSeriesName, tv);
                }
            }
        }

        private TimeValue GetClosestPointForSeries(GraphSeries selectedSeries, TimeValue selectedPoint)
        {
            TimeValue tv = null;
            if (selectedPoint != null)
            {
                TimeValue tv1 = (from sv in selectedSeries.Values
                                 orderby sv.Time descending
                                 where sv.Time <= selectedPoint.Time
                                 select sv).FirstOrDefault();
                TimeValue tv2 = (from sv in selectedSeries.Values
                                 orderby sv.Time
                                 where sv.Time >= selectedPoint.Time
                                 select sv).FirstOrDefault();

                if (tv1 != null && tv2 != null)
                {
                    if (selectedPoint.Time.Subtract(tv1.Time) < tv2.Time.Subtract(selectedPoint.Time))
                    {
                        tv = tv1;
                    }
                    else
                        tv = tv2;
                }
                else if (tv1 != null)
                    tv = tv1;
                else
                    tv = tv2;
            }
            return tv;
        }
        public void SetNextFromClosestPointSelected()
        {
            if (ClosestClickedTimeSeriesName != null && ClosestClickedTimeSeriesName != "" && ClosestClickedTimeValue != null)
            {
                GraphSeries selectedSeries = GetSeriesByName(ClosestClickedTimeSeriesName);
                TimeValue tv = (from sv in selectedSeries.Values
                                orderby sv.Time
                                where sv.Time > ClosestClickedTimeValue.Time
                                select sv).FirstOrDefault();
                if (tv != null)
                {
                    ClosestClickedTimeValue = tv;
                    LastClickedLocation = tv;
                    ClosestPointSelectedChanged?.Invoke(ClosestClickedTimeSeriesName, tv);
                }
            }
        }
        public void SetNextSelectedSeries()
        {
            if (Series.Count > 0)
            {
                int selectedSeriesIndex = 0; 
                if (ClosestClickedTimeSeriesName != null && ClosestClickedTimeSeriesName != "")
                {
                    selectedSeriesIndex = GetSeriesIndexByName(ClosestClickedTimeSeriesName);
                    if (selectedSeriesIndex == Series.Count - 1)
                        selectedSeriesIndex = 0;
                    else
                        selectedSeriesIndex++;
                }
                GraphSeries selectedSeries = Series[selectedSeriesIndex];
                SetSelectedSeriesByName(selectedSeries.Name);
                
                if (ClosestClickedTimeValue != null)
                {
                    TimeValue tv = GetClosestPointForSeries(selectedSeries, ClosestClickedTimeValue);
                    if (tv != null)
                    {
                        ClosestClickedTimeValue = tv;
                        LastClickedLocation = tv;
                        ClosestPointSelectedChanged?.Invoke(ClosestClickedTimeSeriesName, tv);
                    }
                }
            }
        }
        public void SetPreviousSelectedSeries()
        {
            if (Series.Count > 0)
            {
                int selectedSeriesIndex = Series.Count - 1;
                if (ClosestClickedTimeSeriesName != null && ClosestClickedTimeSeriesName != "")
                {
                    selectedSeriesIndex = GetSeriesIndexByName(ClosestClickedTimeSeriesName);                    
                    if (selectedSeriesIndex <= 0)
                        selectedSeriesIndex = Series.Count - 1;
                    else
                        selectedSeriesIndex--;
                }
                GraphSeries selectedSeries = Series[selectedSeriesIndex];
                SetSelectedSeriesByName(selectedSeries.Name);
                if (ClosestClickedTimeValue != null)
                {
                    TimeValue tv = GetClosestPointForSeries(selectedSeries, ClosestClickedTimeValue);                   
                    if (tv != null)
                    {
                        ClosestClickedTimeValue = tv;
                        LastClickedLocation = tv;
                        ClosestPointSelectedChanged?.Invoke(ClosestClickedTimeSeriesName, tv);
                    }
                }
            }
        }
        private void SetHightlightSeries()
        {
            if (HighlightClickedSeries)
            {
                foreach (var s in Series)
                    if (s.Selected)
                        s.LineWidth = HighlightSeriesWidth;
                    else
                        s.LineWidth = NoHighlightSeriesWidth;
            }
        }
        private TimeValue ConvertPointToTimeValue(int x, int y, bool forceInBounds = false)
        {
            TimeValue timeValue = null;

            //if (ShowLegendText && y > (Height - legendHeight)) //legend area
            //{
            //    foreach (var enabledSeries in (from serie in Series
            //                                   where serie.Enabled
            //                                   select serie))
            //    {
            //        if (enabledSeries.CurrentSeriesLabelLocation.X <= x && enabledSeries.CurrentSeriesLabelLocation.X + enabledSeries.CurrentSeriesLabelSize.Width > x)
            //        {
            //            if (enabledSeries.CurrentSeriesLabelLocation.Y <= y && enabledSeries.CurrentSeriesLabelLocation.Y + enabledSeries.CurrentSeriesLabelSize.Height > y)
            //            {
            //                System.Diagnostics.Trace.WriteLine(enabledSeries.Name);
            //            }
            //        }
            //    }
            //}

            if (forceInBounds)
            {
                if (x < LeftAxisMargin)
                    x = LeftAxisMargin;
                if (x > (Width - RightAxisMargin))
                    x = (Width - RightAxisMargin);
                if (y < 0)
                    y = 0;
                if (y > (Height - legendHeight))
                    y = (Height - legendHeight);
            }
            if (x >= LeftAxisMargin && x <= (Width - RightAxisMargin) && y >= 0 && y <= (Height - legendHeight))
            {
                int graphWidth = this.Width - LeftAxisMargin - RightAxisMargin;
                int graphHeight = this.Height - legendHeight - headerHeight;
                double percX = (1.0 * (x - LeftAxisMargin)) / graphWidth;
                double totalSeconds = EndDateTime.Subtract(StartDateTime).TotalSeconds;
                double xSeconds = percX * totalSeconds;
                DateTime tm = StartDateTime.AddSeconds(xSeconds);
                if (x == (Width - RightAxisMargin))
                    tm = EndDateTime;
                double vl = 0;
                double percY = (1.0 * (y - headerHeight)) / graphHeight;
                if (y <= 0)
                    percY = 0;

                if (percY >= 0)
                {
                    percY = (1 - percY);
                    if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
                    {
                        if (percY > 0)
                            vl = Math.Pow(10, percY * cookedMaxGraphValue);
                        else
                            vl = 0;
                    }
                    else
                        vl = percY * cookedMaxGraphValue;

                    if (vl >= -1)
                    {
                        timeValue = new TimeValue() { Time = tm, Value = (float)vl };
                    }
                }
            }
            
            return timeValue;
        }
        private Point ConvertTimeValueToPoint(TimeValue tv)
        {
            Point pt = new Point(0, 0);
            if (tv != null && totalDurationInSeconds > 0)
            {
                long localCookedMaxGraphValue = cookedMaxGraphValue;
                float value = tv.Value;
                float cookedValue = value;
                if (cookedMaxGraphValue == 0)
                {
                    localCookedMaxGraphValue = 1;
                    cookedValue = cookedValue * 10;
                }
                if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
                {
                    if (cookedValue >= 0)
                    {
                        cookedValue = (float)Math.Log10(cookedValue);
                    }
                    else
                        cookedValue = 0;
                }
                else
                {
                    if (cookedValue > localCookedMaxGraphValue)
                        cookedValue = localCookedMaxGraphValue;
                }
                if (cookedValue < 0)
                    cookedValue = 0;

                int graphWidth = this.Width - LeftAxisMargin - RightAxisMargin;
                int graphHeight = this.Height - legendHeight - headerHeight;
                int x = (int)((tv.Time.Subtract(StartDateTime).TotalSeconds / totalDurationInSeconds) * graphWidth);
                int y = 0;
                if (localCookedMaxGraphValue > 0)
                    y = (int)(((cookedValue - 0) / (localCookedMaxGraphValue - 0)) * graphHeight);
                pt = new Point(LeftAxisMargin + x, graphHeight + headerHeight - y);
            }
            return pt;
        }
        private float FloorValue(float value, float floor = 0)
        {
            if (value >= floor)
                return value;
            else
                return floor;
        }
        #endregion

        #region IsInDesignMode
        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        } 
        #endregion

        #region DrawGraph
        private void DrawGraph(ref Graphics g)
        {
            if (Series == null)
                Series = new List<GraphSeries>();
            Pen marginsPen = new Pen(GridColor);
            marginsPen.Width = 1;            

            //Draw background
            DrawBackground(ref g);

            //draw and get legend size
            cookedMaxGraphValue = GetCookedMaxGraphValue();
            legendHeight = DrawLegendSection(ref g);
            headerHeight = DrawHeaderSection(ref g);
            gridWidth = this.Width - LeftAxisMargin - RightAxisMargin;
            gridHeight = this.Height - legendHeight - headerHeight;            

            g.DrawRectangle(marginsPen, LeftAxisMargin, headerHeight, this.Width - LeftAxisMargin - LeftAxisMargin, this.Height - headerHeight - legendHeight);

            DrawStartDateTime(ref g);
            DrawEndDateTime(ref g);
            DrawHorisontalGridlines(ref g);
            DrawVerticalGridlines(ref g);
            DrawClickSelection(ref g);
            DrawSeries(ref g);
            DrawMaxLabel(ref g);
            DrawMinLabel(ref g);
        }

        private long GetCookedMaxGraphValue()
        {
            long tmpMax = MaxGraphValue;
            if (MaxGraphValue == 0) // MinGraphValue == MaxGraphValue)
            {
                MaxGraphValue = 1;
                tmpMax = MaxGraphValue;
            }
            if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
            {
                if (MaxGraphValue > 1)
                {
                    long maxLogValue = 0;
                    foreach (var serie in (from s in Series
                                           where s.Enabled
                                           select s))
                    {
                        foreach (TimeValue tv in serie.Values)
                        {
                            while (tv.Value > Math.Pow(10, maxLogValue))
                                maxLogValue++;
                        }
                    }
                    tmpMax = maxLogValue;
                }
                
            }
            return tmpMax;
        }

        private void DrawBackground(ref Graphics g)
        {
            Brush backgroundBrush = Brushes.Black;
            if (BackgroundIsGradient)
            {
                RectangleF rectangleF = new RectangleF(new PointF(0, 0), new SizeF(this.Width, this.Height));
                backgroundBrush = new LinearGradientBrush(rectangleF, BackgroundGradientColor1, BackgroundGradientColor2, GradientDirection);
                //backgroundBrush = new LinearGradientBrush(new PointF(0, 0), new PointF(0, this.Height), BackgroundGradientColor1, BackgroundGradientColor2);
            }
            else
                backgroundBrush = new SolidBrush(BackgroundColor);
            g.FillRectangle(backgroundBrush, 0, 0, this.Width, this.Height);
        }
        private int DrawHeaderSection(ref Graphics g)
        {
            int headerMarginHeight = 1;
            if (ShowSelectionBar && LastClickedLocation != null) //  clickedSelectedValueTime)
            {
                SizeF clickedTimeSize = g.MeasureString(LastClickedLocation.Time.ToString("yyyy-MM-dd hh:mm"), GraphTextFont);
                headerMarginHeight = (int)(clickedTimeSize.Height + 2);
            }            
            if (ShowGraphHeader)
            {
                Brush drawBrush = new SolidBrush(AxisLabelColor);
                SizeF headerSize = g.MeasureString(GraphHeaderText, GraphHeaderFont);
                headerMarginHeight += (int)(headerSize.Height + 4);
                g.DrawString(GraphHeaderText, GraphHeaderFont, drawBrush, (this.Width - headerSize.Width) / 2, 0);
            }
            return headerMarginHeight;
        }
        private int DrawLegendSection(ref Graphics g)
        {
            int bottomMarginHeight = 0;            
            if (ShowLegendText)
            {
                int stdLineHeight = (int)(g.MeasureString("Test", GraphTextFont).Height + 3);
                int linesCountNeeded = 1;
                int bufferBetweenLabels = 10;
                int currentLineWidth = bufferBetweenLabels;

                List<Tuple<string, TimeValue>> selectedSeriesValues = null;
                selectedSeriesValues = GetSelectedValues();                

                foreach (var enabledSeries in (from serie in Series
                                               where serie.Enabled
                                               select serie))
                {
                    string currentSeriesLabel = enabledSeries.Name;
                    if (enabledSeries.Values.Count < 2)
                        currentSeriesLabel += " (Not enough data)";
                    if (LastClickedLocation != null)
                    {
                        var selValEntry = selectedSeriesValues.FirstOrDefault(se => se.Item1 == enabledSeries.Name);
                        if (selValEntry != null)
                        {
                            string valueFormatted = $"{selValEntry.Item2.Value.ToString("0.00")}";
                            if (valueFormatted.EndsWith(".00"))
                                valueFormatted = valueFormatted.Substring(0, valueFormatted.Length - 3);
                            if ($"{enabledSeries.ValueUnit}" != "")
                                valueFormatted += $" {enabledSeries.ValueUnit}";
                            currentSeriesLabel += $" ({valueFormatted})";
                        }
                    }
                    SizeF currentLabelSize = g.MeasureString(currentSeriesLabel, GraphTextFont);
                    if (currentLineWidth + currentLabelSize.Width + bufferBetweenLabels < this.Width)
                    {
                        currentLineWidth += (int)currentLabelSize.Width + bufferBetweenLabels;
                    }
                    else
                    {
                        linesCountNeeded++;
                        currentLineWidth = bufferBetweenLabels + (int)currentLabelSize.Width + bufferBetweenLabels;
                    }
                }
                bottomMarginHeight = stdLineHeight * linesCountNeeded;
                int legendYPos = this.Height - bottomMarginHeight;
                int legendXPos = bufferBetweenLabels;
                linesCountNeeded = 0;
                foreach (var enabledSeries in (from serie in Series
                                               where serie.Enabled
                                               select serie))
                {
                    string currentSeriesLabel = enabledSeries.Name;
                    if (enabledSeries.Values.Count < 2)
                        currentSeriesLabel += " (Not enough data)";
                    Font currentFont = new Font(GraphTextFont, FontStyle.Regular);
                    if (LastClickedLocation != null)
                    {
                        var selValEntry = selectedSeriesValues.FirstOrDefault(se => se.Item1 == enabledSeries.Name);
                        if (selValEntry != null)
                        {
                            string valueFormatted = $"{selValEntry.Item2.Value.ToString("0.00")}";
                            if (valueFormatted.EndsWith(".00"))
                                valueFormatted = valueFormatted.Substring(0, valueFormatted.Length - 3);
                            if ($"{enabledSeries.ValueUnit}" != "")
                                valueFormatted += $" {enabledSeries.ValueUnit}";
                            currentSeriesLabel += $" ({valueFormatted})";

                            //currentSeriesLabel += $" ({selValEntry.Item2.Value.ToString("0.00")})";
                        }
                    }
                    if (enabledSeries.Selected)
                    {
                        currentFont = new Font(GraphTextFont, FontStyle.Bold);
                    }
                    SizeF currentLabelSize = g.MeasureString(currentSeriesLabel, currentFont);
                    Brush drawBrush = new SolidBrush(enabledSeries.LineColor);

                    if (legendXPos + currentLabelSize.Width + bufferBetweenLabels < this.Width)
                    {
                        g.DrawString(currentSeriesLabel, currentFont, drawBrush, legendXPos, legendYPos);
                        enabledSeries.CurrentSeriesLabelText = currentSeriesLabel;
                        enabledSeries.CurrentSeriesLabelLocation = new Point(legendXPos, legendYPos);
                        enabledSeries.CurrentSeriesLabelSize = currentLabelSize;

                        legendXPos += (int)currentLabelSize.Width + bufferBetweenLabels;                        
                    }
                    else
                    {
                        legendYPos += stdLineHeight;
                        legendXPos = bufferBetweenLabels;
                        g.DrawString(currentSeriesLabel, currentFont, drawBrush, legendXPos, legendYPos);
                        enabledSeries.CurrentSeriesLabelText = currentSeriesLabel;
                        enabledSeries.CurrentSeriesLabelLocation = new Point(legendXPos, legendYPos);
                        enabledSeries.CurrentSeriesLabelSize = currentLabelSize;

                        legendXPos += (int)currentLabelSize.Width + bufferBetweenLabels;
                    }
                }
                bottomMarginHeight += stdLineHeight;
            }
            else
            {
                bottomMarginHeight = (int)(g.MeasureString("Test", GraphTextFont).Height + 3);
            }
            return bottomMarginHeight;
        }
        private void DrawRotatedTextAt(Graphics gr, float angle, string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
        }
        private void DrawEndDateTime(ref Graphics g)
        {
            string labelText = "";
            Font currentDrawFont;
            if (this.Height <= minimumHeightForDetailGrid)
            {
                labelText = EndDateTime.ToString("yyyy-MM-dd HH:mm");
                currentDrawFont = new Font(GraphTextFont.FontFamily, 7, FontStyle.Regular);
            }
            else
            {
                labelText = EndDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                currentDrawFont = GraphTextFont;
            }

            SizeF labelSize = g.MeasureString(labelText, currentDrawFont);
            Brush drawBrush = new SolidBrush(AxisLabelColor);

            int leftXPos = (int)(this.Width - RightAxisMargin + ((RightAxisMargin - labelSize.Height) / 2));
            int bottomYPos = (int)((this.Height - legendHeight - labelSize.Width - headerHeight) / 2);
            DrawRotatedTextAt(g, -90, labelText, leftXPos, this.Height - legendHeight - bottomYPos, currentDrawFont, drawBrush);
        }
        private void DrawStartDateTime(ref Graphics g)
        {
            string labelText = "";
            Font currentDrawFont;
            if (this.Height <= minimumHeightForDetailGrid)
            {
                labelText = StartDateTime.ToString("yyyy-MM-dd HH:mm");
                currentDrawFont = new Font(GraphTextFont.FontFamily, 7, FontStyle.Regular);
            }
            else
            {
                labelText = StartDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                currentDrawFont = GraphTextFont;
            }

            SizeF labelSize = g.MeasureString(labelText, currentDrawFont);
            Brush drawBrush = new SolidBrush(AxisLabelColor);

            int leftXPos = (int)((LeftAxisMargin - labelSize.Height) / 2);
            int bottomYPos = (int)((this.Height - legendHeight - labelSize.Width - headerHeight) / 2);
            DrawRotatedTextAt(g, -90, labelText, leftXPos, this.Height - legendHeight - bottomYPos, currentDrawFont, drawBrush);
        }
        private void DrawHorisontalGridlines(ref Graphics g)
        {
            //horisontal lines
            if (ShowHorisontalGridlines)
            {
                Pen gridPen = new Pen(GridColor);
                byte rColor = (byte)(GridColor.R + (GridColor.R < 223 ? 32 : 0));
                byte gColor = (byte)(GridColor.G + (GridColor.R < 223 ? 32 : 0));
                byte bColor = (byte)(GridColor.B + (GridColor.R < 223 ? 32 : 0));
                Pen gridPenThick = new Pen(Color.FromArgb(rColor, gColor, bColor));
                gridPen.Width = 1;
                gridPenThick.Width = 2;

                if (this.Height <= minimumHeightForDetailGrid)
                {
                    g.DrawLine(gridPen, LeftAxisMargin, headerHeight + gridHeight / 4, this.Width - RightAxisMargin, headerHeight + gridHeight / 4);
                    g.DrawLine(gridPenThick, LeftAxisMargin, headerHeight + gridHeight / 2, this.Width - RightAxisMargin, headerHeight + gridHeight / 2);
                    g.DrawLine(gridPen, LeftAxisMargin, headerHeight + (3 * gridHeight) / 4, this.Width - RightAxisMargin, headerHeight + (3 * gridHeight) / 4);
                }
                else //if (this.Height > 400)
                {
                    if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
                    {
                        double lineStep = 0;
                        for (int i = 0; i <= cookedMaxGraphValue; i++)
                        {
                            lineStep = Math.Pow(10, i);
                            Point x = ConvertTimeValueToPoint(new TimeValue() { Time = startDateTime, Value = (float)lineStep });
                            g.DrawLine(gridPenThick, LeftAxisMargin, x.Y, this.Width - RightAxisMargin, x.Y);

                            for(int q = 1; q < 4; q++)
                            {
                                float qstep = (float)((q * lineStep) / 4);
                                Point qx = ConvertTimeValueToPoint(new TimeValue() { Time = startDateTime, Value = qstep });
                                g.DrawLine(gridPen, LeftAxisMargin, qx.Y, this.Width - RightAxisMargin, qx.Y);
                            }
                        }
                        //lineStep = Math.Pow(10, cookedMaxGraphValue);
                        //for (int q = 1; q < 4; q++)
                        //{
                        //    float qstep = (float)((q * lineStep) / 4);
                        //    Point qx = ConvertTimeValueToPoint(new TimeValue() { Time = startDateTime, Value = qstep });
                        //    g.DrawLine(gridPen, LeftAxisMargin, qx.Y, this.Width - RightAxisMargin, qx.Y);
                        //}
                    }
                    else
                    {
                        if (this.Height > minimumHeightForExtraHorisontalLines)
                        {
                            for (int i = 1; i < 10; i++)
                            {
                                g.DrawLine(gridPen, LeftAxisMargin, headerHeight + (i * gridHeight) / 10, this.Width - RightAxisMargin, headerHeight + (i * gridHeight) / 10);
                            }
                        }
                        else
                        {
                            g.DrawLine(gridPen, LeftAxisMargin, headerHeight + gridHeight / 4, this.Width - RightAxisMargin, headerHeight + gridHeight / 4);
                            g.DrawLine(gridPenThick, LeftAxisMargin, headerHeight + gridHeight / 2, this.Width - RightAxisMargin, headerHeight + gridHeight / 2);
                            g.DrawLine(gridPen, LeftAxisMargin, headerHeight + (3 * gridHeight) / 4, this.Width - RightAxisMargin, headerHeight + (3 * gridHeight) / 4);
                        }
                    }
                }
            }
        }
        private void DrawVerticalGridlines(ref Graphics g)
        {
            SizeF timeUnitSize = g.MeasureString("00:00", GraphTextFont);
            SizeF dateUnitSize = g.MeasureString("9999-99-99 ", GraphTextFont); //  DateTime.Now.ToString("yyyy-MM-dd")
            TimeSpan timeDiff = EndDateTime.Subtract(StartDateTime);
            Pen gridPen = new Pen(Color.FromArgb(200, GridColor));
            byte rColor = (byte)(GridColor.R + (GridColor.R < 223 ? 32 : 0));
            byte gColor = (byte)(GridColor.G + (GridColor.R < 223 ? 32 : 0));
            byte bColor = (byte)(GridColor.B + (GridColor.R < 223 ? 32 : 0));
            Pen gridPenThick = new Pen(Color.FromArgb(rColor, gColor, bColor));
            Brush drawBrush = new SolidBrush(AxisLabelColor);
            gridPen.Width = 1;
            gridPenThick.Width = 2;
            gridPenThick.DashStyle = DashStyle.Solid;
            int y = gridHeight + headerHeight + 1;

            g.Clip = new Region(new Rectangle(LeftAxisMargin, headerHeight, gridWidth + 2, (int)(gridHeight + 3 + timeUnitSize.Height)));

            if (timeDiff.TotalHours > 36)
            {
                DateTime solidDay = StartDateTime.Date;
                int dayCount = timeDiff.Days + 1;
                int dayJumpSize = 1;
                int hourJumpSize = 3;
                while (dayJumpSize < dayCount && (dateUnitSize.Width) * (dayCount / dayJumpSize) > gridWidth)
                {
                    dayJumpSize++;
                    hourJumpSize = hourJumpSize + hourJumpSize;
                }

                if (ShowVerticalGridLines && gridWidth > dateUnitSize.Width * 4)
                {
                    DateTime solidhour = StartDateTime.Date;
                    do
                    {
                        solidhour = solidhour.AddHours(hourJumpSize);
                        TimeSpan timeToSolidDay = solidhour.Subtract(StartDateTime);
                        int x = LeftAxisMargin + (int)(gridWidth * (timeToSolidDay.TotalHours / timeDiff.TotalHours));
                        g.DrawLine(gridPen, x, headerHeight, x, gridHeight + headerHeight);
                    }
                    while (solidhour < EndDateTime);
                }

                do
                {
                    solidDay = solidDay.AddDays(dayJumpSize);
                    TimeSpan timeToSolidDay = solidDay.Subtract(StartDateTime);
                    int x = LeftAxisMargin + (int)(gridWidth * (timeToSolidDay.TotalHours / timeDiff.TotalHours));
                    if (ShowVerticalGridLines)
                        g.DrawLine(gridPenThick, x, headerHeight, x, gridHeight + headerHeight);
                    if (x + (dateUnitSize.Width / 2) < gridWidth)
                        g.DrawString(solidDay.ToString("yyyy-MM-dd"), GraphTextFont, drawBrush, x - (dateUnitSize.Width / 2), y);
                    else if (solidDay < EndDateTime)
                        g.DrawString(solidDay.ToString("yyyy-MM-dd"), GraphTextFont, drawBrush, this.Width - LeftAxisMargin - dateUnitSize.Width, y);
                } while (solidDay < EndDateTime);
            }
            else
            {
                DrawVerticalGridlineTime(ref g, timeDiff, 1, 2, timeUnitSize, y, GridColor);
                if (gridWidth >= timeUnitSize.Width * 4)
                {
                    for (int i = 1; i < 5; i = i + 2)
                    {
                        DrawVerticalGridlineTime(ref g, timeDiff, i, 4, timeUnitSize, y, GridColor);
                    }
                }
                if (gridWidth >= timeUnitSize.Width * 8)
                {
                    for (int i = 1; i < 9; i = i + 2)
                    {
                        DrawVerticalGridlineTime(ref g, timeDiff, i, 8, timeUnitSize, y, GridColor);
                    }
                }
                if (gridWidth >= timeUnitSize.Width * 16)
                {
                    for (int i = 1; i < 17; i = i + 2)
                    {
                        DrawVerticalGridlineTime(ref g, timeDiff, i, 16, timeUnitSize, y, GridColor);
                    }
                }

            }
            g.ResetClip();

        }
        private void DrawVerticalGridlineTime(ref Graphics g, TimeSpan timeDiff, int fraction, int divider, SizeF timeUnitSize, int y, Color drawcolor)
        {
            Pen gridPen = new Pen(drawcolor); // GridColor);
            Brush drawBrush = new SolidBrush(AxisLabelColor);
            DateTime midTime = StartDateTime.AddSeconds(((fraction * timeDiff.TotalSeconds) / divider));
            int x = LeftAxisMargin + ((fraction * gridWidth) / divider);
            if (ShowVerticalGridLines)
                g.DrawLine(gridPen, x, headerHeight, x, gridHeight + headerHeight);
            g.DrawString(midTime.ToString("HH:mm"), GraphTextFont, drawBrush, x - (timeUnitSize.Width / 2), y);
        }
        private void DrawSeries(ref Graphics g)
        {
            g.Clip = new Region(new Rectangle(LeftAxisMargin, headerHeight, gridWidth, gridHeight));

            //if (MaxGraphValue == 0) // MinGraphValue == MaxGraphValue)
            //{
            //    MaxGraphValue = 1;
            //}
            //if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
            //{
            //    if (MaxGraphValue > 1)
            //    {
            //        long maxLogValue = 0;
            //        foreach (var serie in (from s in Series
            //                               where s.Enabled
            //                               select s))
            //        {
            //            foreach (TimeValue tv in serie.Values)
            //            {
            //                while (tv.Value > Math.Pow(10, maxLogValue))
            //                    maxLogValue++;
            //            }
            //        }
            //        MaxGraphValue = maxLogValue;
            //    }
            //}

            double seconds = EndDateTime.Subtract(StartDateTime).TotalSeconds;
            foreach (var serie in (from s in Series
                                   where s.Enabled && ( !s.Selected || !HighlightClickedSeries)
                                   select s))
            {
                DrawSeries(ref g, serie);
            }
            foreach (var serie in (from s in Series
                                   where s.Enabled && (s.Selected && HighlightClickedSeries)
                                   select s))
            {
                DrawSeries(ref g, serie);
            }


            //if (HighlightClickedSeries && ClosestClickedSeries != null && ClosestClickedSeries.Enabled)
            //{
            //    DrawSeries(ref g, ClosestClickedSeries);
            //}

            //if (HighlightClickedSeries && ClosestClickedSeries != null && Series.Count > 0) {
            //    var selectedSeries = (from s in Series
            //                          where ClosestClickedSeries.Name == s.Name
            //                          select s).FirstOrDefault();
            //    //if (HighlightClickedSeries && ClosestClickedSeries != null && ClosestClickedSeries.Enabled)
            //    {
            //        DrawSeries(ref g, selectedSeries);
            //    }
            //}

            
            g.ResetClip();
        }
        private void DrawSeries(ref Graphics g, GraphSeries serie)
        {
            Pen graphPen = new Pen(serie.LineColor);
            graphPen.Width = serie.LineWidth;
            if (HighlightClickedSeries)
                graphPen.Width = serie.Selected ? HighlightSeriesWidth : NoHighlightSeriesWidth;
            List <Point> valuePoints = new List<Point>();
            foreach (TimeValue tv in (from sv in serie.Values
                                      orderby sv.Time
                                      select sv))
            {
                valuePoints.Add(ConvertTimeValueToPoint(tv));
            }
            if (valuePoints.Count > 1)
            {
                if (FillAreaBelowGraph)
                {
                    Brush fillBrush = new SolidBrush(Color.FromArgb(FillAreaBelowGraphAlpha, graphPen.Color)); //64
                    List<Point> fillPoints = new List<Point>();

                    fillPoints.Add(new Point(valuePoints[0].X, headerHeight + gridHeight));

                    //fillPoints.Add(new Point(LeftAxisMargin, headerHeight + gridHeight));
                    fillPoints.AddRange(valuePoints.ToArray());
                    fillPoints.Add(new Point(valuePoints[valuePoints.Count-1].X, headerHeight + gridHeight));

                    //fillPoints.Add(new Point(LeftAxisMargin + gridWidth, headerHeight + gridHeight));
                    g.FillPolygon(fillBrush, fillPoints.ToArray());
                }

                if (GraphLineFormatType == GraphLineFormatType.Straight)
                    g.DrawLines(graphPen, valuePoints.ToArray());
                else
                    g.DrawCurve(graphPen, valuePoints.ToArray(), 0.13f);
            }
            else
                System.Diagnostics.Trace.WriteLine("No values in series!");
        }
        private void DrawMaxLabel(ref Graphics g)
        {
            long cookedValue = cookedMaxGraphValue;// MaxGraphValue;
            string displayedText = cookedValue.ToString();
            string log10SubScript = "₁₀";
            string log10Digits = "⁰¹²³⁴⁵⁶⁷⁸⁹";
            Font drawfont = GraphTextFont;
            if (this.Height <= minimumHeightForDetailGrid)
            {
                drawfont = new Font(GraphTextFont.FontFamily, GraphTextFont.Size - 1, FontStyle.Regular);
            }            

            if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
            {
                
                displayedText = log10SubScript;
                if (cookedValue >= 0 && (cookedValue <= 3 && this.Height > minimumHeightForDetailGrid))
                {
                    displayedText = Math.Pow(10, cookedValue).ToString("0");
                }
                else if (cookedValue > 2 && cookedValue < 10)
                {
                    drawfont = new Font(drawfont.Name, drawfont.Size + 3);
                    displayedText += log10Digits.Substring((int)cookedValue, 1);
                }
                else if (cookedValue >= 10 && cookedValue < 20)
                {
                    drawfont = new Font(drawfont.Name, drawfont.Size + 3);

                    string cookedValueText = cookedValue.ToString();
                    for(int i = 0; i < cookedValueText.Length; i++)
                    {
                        char digit = cookedValueText[i];
                        int digitVal = int.Parse(digit.ToString());
                        displayedText += log10Digits.Substring(digitVal, 1);
                    }
                }
                else
                {
                    displayedText = Math.Pow(10, cookedValue).ToString("0");
                }
                //cookedValue = (long)Math.Pow(10, cookedValue);
            }

            SizeF labelSize = g.MeasureString(displayedText, drawfont);
            Brush drawBrush = new SolidBrush(AxisLabelColor);

            int leftXPos = (int)((LeftAxisMargin - labelSize.Height) / 2);
            int bottomYPos = (int)(labelSize.Width + 2) + headerHeight;
            DrawRotatedTextAt(g, -90, displayedText, leftXPos, bottomYPos, drawfont, drawBrush);
        }
        private void DrawMinLabel(ref Graphics g)
        {
            SizeF labelSize = g.MeasureString("0".ToString(), GraphTextFont);
            Brush drawBrush = new SolidBrush(AxisLabelColor);

            int leftXPos = (int)((LeftAxisMargin - labelSize.Height) / 2);
            //int bottomPos = this.Height;
            DrawRotatedTextAt(g, -90, "0".ToString(), leftXPos, this.Height - legendHeight, GraphTextFont, drawBrush);
        }
        private void DrawSeriesLabels(ref Graphics g)
        {
            int lineHeight = (int)(g.MeasureString("Test", GraphTextFont).Height + 3);
            int graphHeight = this.Height - legendHeight;
            var enabledSeries = (from s in Series
                                 where s.Enabled
                                 select s).ToList();
            for (int i = 0; i < enabledSeries.Count; i++)
            {
                int x = 5;
                int y = graphHeight + (i + 1) * lineHeight;
                Brush drawBrush = new SolidBrush(enabledSeries[i].LineColor);
                string seriesName = enabledSeries[i].Name;
                if (enabledSeries[i].Values.Count < 2)
                    seriesName += " (Not enough data)";
                g.DrawString(seriesName, GraphTextFont, drawBrush, x, y);
            }
        }
        private void DrawXOnGraph(ref Graphics g, TimeValue timeValue, Color drawColor)
        {
            double totalSeconds = EndDateTime.Subtract(StartDateTime).TotalSeconds;
            float cookedValue = timeValue.Value;
            double cookedTime = timeValue.Time.Subtract(StartDateTime).TotalSeconds;
            if (GraphVerticalAxisType == GraphVerticalAxisType.Logarithmic)
            {
                cookedValue = (float)Math.Log10(cookedValue);
            }
            else if (cookedValue > cookedMaxGraphValue)
            {                
                cookedValue = cookedMaxGraphValue;
            }
            if (cookedValue < 0)
                cookedValue = 0;
            int lastClickedY = headerHeight + (int)(((cookedMaxGraphValue - cookedValue) / (cookedMaxGraphValue - 0)) * gridHeight);
            int lastClickedX = LeftAxisMargin + (int)((gridWidth * cookedTime) / totalSeconds);
            if (lastClickedY < 0)
                lastClickedY = 0;

            Pen selectionPen = new Pen(drawColor);
            selectionPen.Width = 2;
            g.DrawLine(selectionPen, lastClickedX - 5, lastClickedY - 5, lastClickedX + 5, lastClickedY + 5);
            g.DrawLine(selectionPen, lastClickedX - 5, lastClickedY + 5, lastClickedX + 5, lastClickedY - 5);
        }
        private void DrawClickSelection(ref Graphics g)
        {
            if (StartDateTime < EndDateTime)
            {
                if (ShowLastClickedLocation && LastClickedLocation != null)
                {
                    DrawXOnGraph(ref g, LastClickedLocation, TimeSelectionColor);
                }
                if (ShowSelectionBar && ClosestClickedTimeValue != null) // && ClosestClickedSeries != null)
                {
                    string clickSelectedTimeStr = ClosestClickedTimeValue.Time.ToString("yyyy-MM-dd HH:mm");
                    SizeF clickSelectedTimeStrSize = g.MeasureString(clickSelectedTimeStr, GraphTextFont);
                    int textHeight = (int)(clickSelectedTimeStrSize.Height + 3);
                    int textWidth = (int)(clickSelectedTimeStrSize.Width);
                    int textHalfWidth = textWidth / 2;
                    double totalSeconds = EndDateTime.Subtract(StartDateTime).TotalSeconds;
                    double xSeconds = ClosestClickedTimeValue.Time.Subtract(StartDateTime).TotalSeconds;
                    int posX = LeftAxisMargin + (int)(gridWidth * xSeconds / totalSeconds);
                    Pen selectionPen = new Pen(TimeSelectionColor) { Width = 3 };
                    Brush drawBrush = new SolidBrush(TimeSelectionColor);

                    g.DrawLine(selectionPen, posX, headerHeight, posX, gridHeight + headerHeight);

                    if (LeftAxisMargin > posX - textHalfWidth)
                        posX = LeftAxisMargin + 1 + textHalfWidth;
                    if (LeftAxisMargin + gridWidth < posX + textHalfWidth)
                        posX = LeftAxisMargin + gridWidth - textHalfWidth - 1;
                    g.DrawString(clickSelectedTimeStr, GraphTextFont, drawBrush, posX - (textWidth / 2), headerHeight - textHeight + 2);

                    if (ShowClickScanSearchBlock)
                    {
                        double rwidth = Math.Abs(selectionBottomRight.X - selectionTopLeft.X);
                        double rhight = Math.Abs(selectionTopLeft.Y - selectionBottomRight.Y);
                        //Point center = new Point((int)(selectionTopLeft.X + (rwidth / 2)), (int)(selectionTopLeft.Y + (rhight / 2)));
                        selectionPen.Width = 1;
                        g.DrawRectangle(selectionPen, new Rectangle(selectionTopLeft, new Size((int)rwidth, (int)rhight)));
                        //g.DrawEllipse(selectionPen, new Rectangle(selectionTopLeft, new Size((int)rwidth, (int)rhight)));
                    }
                }
                if (ShowClosestClickedValue && ClosestClickedTimeValue != null && ClosestClickedTimeSeriesName != "")
                {
                    GraphSeries cs = GetSeriesByName(ClosestClickedTimeSeriesName);
                    if (cs != null)
                    {
                        if (ClosestClickedValueColorType == ClosestClickedValueColorType.SeriesColor)
                            DrawXOnGraph(ref g, ClosestClickedTimeValue, cs.LineColor);
                        else if (ClosestClickedValueColorType == ClosestClickedValueColorType.InvertedColor)
                            DrawXOnGraph(ref g, ClosestClickedTimeValue, InvertColor(cs.LineColor));
                        else
                            DrawXOnGraph(ref g, ClosestClickedTimeValue, ClosestClickedValueCustomColor);
                    }
                }
            }         
        }
        #endregion

        #region Resizing
        private void ResizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.Enabled = false;
            if (this != null && !this.IsDisposed)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        Application.DoEvents();
                        Refresh();
                    }
                    catch { }
                });
                }
                catch { }
            }
        } 
        #endregion

        #region public methods
        public void SetAutoMinMaxDateTimes(bool autoStartTime = true, bool autoEndTime = true, bool autoValues = true)
        {
            //long minGraphValue = 0;
            long maxGraphValue = long.MinValue;
            DateTime startDateTime = DateTime.Now.AddYears(100);
            DateTime endDateTime = DateTime.Now.AddYears(-100);
            if (autoStartTime)
            {

            }
            if (autoStartTime || autoEndTime)
            {
                foreach (var serie in (from s in Series
                                       where s != null && s.Enabled
                                       select s))
                {
                    TimeValue oldestTimeValue = (from TimeValue dt in serie.Values
                                                 orderby dt.Time
                                                 select dt).FirstOrDefault();
                    if (oldestTimeValue != null && startDateTime > oldestTimeValue.Time && autoStartTime)
                        startDateTime = oldestTimeValue.Time;
                    TimeValue newestTimeValue = (from TimeValue dt in serie.Values
                                                 orderby dt.Time descending
                                                 select dt).FirstOrDefault();
                    if (newestTimeValue != null && endDateTime < newestTimeValue.Time && autoEndTime)
                        endDateTime = newestTimeValue.Time;
                }
                if (autoStartTime)
                    StartDateTime = startDateTime;
                if (autoEndTime)
                    EndDateTime = endDateTime;
            }

            if (autoValues) //Auto maximum
            {
                //Get Maximum value of all values/all lines
                foreach (var serie in (from s in Series
                                       where s != null && s.Enabled
                                       select s))
                {
                    //TimeValue minValue = (from TimeValue dt in serie.Values
                    //                      where (!autoValues) || (dt.Time >= StartDateTime && dt.Time <= EndDateTime)
                    //                      orderby dt.Value
                    //                      select dt).FirstOrDefault();
                    //if (minValue != null && minGraphValue > minValue.Value)
                    //    minGraphValue = (long)minValue.Value;

                    TimeValue maxValue = (from TimeValue dt in serie.Values
                                          where (!autoValues) || (dt.Time >= StartDateTime && dt.Time <= EndDateTime)
                                          orderby dt.Value descending
                                          select dt).FirstOrDefault();
                    if (maxValue != null && maxGraphValue < maxValue.Value)
                        maxGraphValue = (long)Math.Ceiling((double)maxValue.Value);// (long)maxValue.Value;
                }                
                
                MaxGraphValue = maxGraphValue;
                //MinGraphValue = minGraphValue;
            }
            else if (maxGraphValue > MaxGraphValue)
            {
                //MaxGraphValue = maxGraphValue;
            }
            if (MaxGraphValue == long.MinValue)
                MaxGraphValue = InitialMaxGraphValue;
        }
        public void UpdateGraph()
        {
            resizeTimer.Enabled = true;
        }
        public Bitmap SaveToBitmap()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(bmp);

            int controlWidth = Width;
            int controlHeight = Height;

            DrawGraph(ref g);

            g.Dispose();
            return bmp;
        }
        public void PauseUpdates()
        {
            pauseUpdate = true;
        }
        public List<Tuple<string, TimeValue>> GetSelectedValues(int secondsRange = 1)
        {
            List<Tuple<string, TimeValue>> list = new List<Tuple<string, TimeValue>>();
            DateTime? selectedDateTime = null; // DateTime.Now.AddDays(1);
            if (ClosestClickedTimeValue != null)
            {
                selectedDateTime = ClosestClickedTimeValue.Time;
            }
            else if (LastClickedLocation != null)
            {
                selectedDateTime = LastClickedLocation.Time;
            }
            if (selectedDateTime.HasValue)
            {
                foreach (var series in (from s in Series
                                        where s.Enabled
                                        select s))
                {
                    var selectedValue = (from t in series.Values
                                         orderby t.Time
                                         where t.Time >= selectedDateTime.Value.AddSeconds(-secondsRange) &&
                                                t.Time <= selectedDateTime.Value.AddSeconds(secondsRange)
                                         select t).FirstOrDefault();
                    if (selectedValue != null)
                    {
                        list.Add(new Tuple<string, TimeValue>(series.Name, selectedValue));
                    }
                }
            }

            //if (LastClickedLocation != null) //  LastClickedTimeSelected)
            //{
            //    var closetValue = GetClosestToClickEntry();
            //    if (closetValue != null)
            //    {

            //        foreach (var series in (from s in Series
            //                                where s.Enabled
            //                                select s))
            //        {
            //            var selectedValue = (from t in series.Values
            //                                 orderby t.Time
            //                                 where t.Time >= closetValue.Item2.Time.AddSeconds(-secondsRange) &&
            //                                        t.Time <= closetValue.Item2.Time.AddSeconds(secondsRange)
            //                                 select t).FirstOrDefault();
            //            if (selectedValue != null)
            //            {
            //                list.Add(new Tuple<string, TimeValue>(series.Name, selectedValue));
            //            }
            //        }
            //    }
            //}
            return list;
        }
        #endregion

        #region Get or set settings
        public void SetFromGraphSettings(GraphSettings graphSettings)
        {
            GraphVerticalAxisType = (GraphVerticalAxisType)graphSettings.GraphType;

            //seriesColors.AddRange((from string colorName in graphSettings.SeriesColors
            //                       select HenIT.Windows.Controls.Graphing.GraphSettings.ConvertColorFromName(colorName)));

            BackgroundGradientColor1 = GraphSettings.ConvertColorFromName(graphSettings.BackgroundColor1);
            BackgroundGradientColor2 = GraphSettings.ConvertColorFromName(graphSettings.BackgroundColor2);
            GridColor = GraphSettings.ConvertColorFromName(graphSettings.GridColor);
            AxisLabelColor = GraphSettings.ConvertColorFromName(graphSettings.AxisLabelsColor);
            TimeSelectionColor = GraphSettings.ConvertColorFromName(graphSettings.SelectionBarColor);

            GradientDirection = (LinearGradientMode)graphSettings.GradientDirection;
            ClosestClickedValueColorType = (ClosestClickedValueColorType)graphSettings.ClosestClickedValueType;
            ClosestClickedValueCustomColor = GraphSettings.ConvertColorFromName(graphSettings.ClosestClickedValueColor);
            ShowGraphHeader = graphSettings.HeaderVisible;
            ShowLegendText = graphSettings.FooterVisible;
            ShowHorisontalGridlines = graphSettings.HorisontalGridLinesVisible;
            ShowVerticalGridLines = graphSettings.VerticalGridLinesVisible;
            ShowSelectionBar = graphSettings.SelectionBarVisible;
            HighlightClickedSeries = graphSettings.HighlightClickedSeriesVisible;
            FillAreaBelowGraph = graphSettings.EnableFillAreaBelowSeries;
            FillAreaBelowGraphAlpha = graphSettings.FillAreaBelowSeriesAlpha;
        }
        public GraphSettings GetGraphSettings()
        {
            GraphSettings graphSettings = new GraphSettings();
            graphSettings.SeriesColors = new List<string>();
            graphSettings.GraphType = (int)GraphVerticalAxisType;
            graphSettings.BackgroundColor1 = GraphSettings.ConvertColorToName(BackgroundGradientColor1);
            graphSettings.BackgroundColor2 = GraphSettings.ConvertColorToName(BackgroundGradientColor2);
            graphSettings.GridColor = GraphSettings.ConvertColorToName(GridColor);
            graphSettings.AxisLabelsColor = GraphSettings.ConvertColorToName(AxisLabelColor);
            graphSettings.SelectionBarColor = GraphSettings.ConvertColorToName(TimeSelectionColor);

            graphSettings.GradientDirection = (int)GradientDirection;
            graphSettings.ClosestClickedValueType = (int)ClosestClickedValueColorType;
            graphSettings.ClosestClickedValueColor = GraphSettings.ConvertColorToName(ClosestClickedValueCustomColor);
            graphSettings.HeaderVisible = ShowGraphHeader;
            graphSettings.FooterVisible = ShowLegendText;
            graphSettings.HorisontalGridLinesVisible = ShowHorisontalGridlines;
            graphSettings.VerticalGridLinesVisible = ShowVerticalGridLines;
            graphSettings.SelectionBarVisible = ShowSelectionBar;
            graphSettings.HighlightClickedSeriesVisible = HighlightClickedSeries;
            graphSettings.EnableFillAreaBelowSeries = FillAreaBelowGraph;
            graphSettings.FillAreaBelowSeriesAlpha = FillAreaBelowGraphAlpha;
            return graphSettings;
        }
        #endregion

        private Color InvertColor(Color fromColor)
        {
            Color invertedColor = Color.FromArgb(fromColor.ToArgb() ^ 0xffffff);

            if (invertedColor.R > 110 && invertedColor.R < 150 &&
                invertedColor.G > 110 && invertedColor.G < 150 &&
                invertedColor.B > 110 && invertedColor.B < 150)
            {
                int avg = (invertedColor.R + invertedColor.G + invertedColor.B) / 3;
                avg = avg > 128 ? 200 : 60;
                invertedColor = Color.FromArgb(avg, avg, avg);
            }
            return invertedColor;
        }
    }

    public enum GraphVerticalAxisType
    {
        Standard,
        Logarithmic
    }
    public enum GraphLineFormatType
    {
        Straight,
        Curve
    }
    public enum ClosestClickedValueColorType
    {
        SeriesColor,
        InvertedColor,
        CustomColor
    }
}
