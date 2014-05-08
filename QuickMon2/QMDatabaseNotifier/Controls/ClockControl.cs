using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HenIT.Controls
{
    public delegate void TimeChangedDelegate(DateTime time);
    public delegate void AMPMChangedDelegate(bool isAM);
    public class ClockControl : Control
    {
        #region private parts
        private int prevhours = -1;
        private int prevminutes = -1;
        private int hours = 0;
        public int SelectedHour
        {
            get
            {
                if (isAM)
                {
                    if ((hours % 12) == 0 && minutes == 0)
                    {
                        return 0;
                    }
                    else
                        return hours;
                }
                else
                    //return hours + 12;
                    if ((hours % 12) == 0 && minutes == 0)
                        return 12;
                    else if (hours < 12)
                        return hours + 12;
                    else
                        return hours;
            }
            set
            {
                hours = value;
                if (hours == 0 && minutes == 0)
                {
                    isAM = true;
                }
                else if (hours == 12 && minutes == 0)
                {
                    isAM = false;
                }
                else if (hours == 12 && minutes > 0)
                {
                    isAM = false;
                }
                else if (hours > 12)
                {
                    isAM = false;
                    hours = hours - 12;
                }
                else
                    isAM = true;

                RaiseAMPMChanged(isAM);
                Refresh();
            }
        }
        private int minutes = 0;
        public int SelectedMinute
        {
            get { return minutes; }
            set
            {
                minutes = value;
                Refresh();
            }
        }
        private int padding = 20;
        public int ClockPadding
        {
            get { return padding; }
            set { padding = value; }
        }
        private string fontName = "Arial Black";
        #endregion

        #region public members
        private bool isAM = true;
        public bool IsAM
        {
            get { return isAM; }
            set
            {
                isAM = value;
                RaiseTimeChanged(DateTime.Parse(GetTimeString()));
                Refresh();
            }
        }
        public TimeSpan Value;
        public event AMPMChangedDelegate AMPMChanged;
        private void RaiseAMPMChanged(bool isAM)
        {
            if (AMPMChanged != null)
            {
                AMPMChanged(isAM);
            }
        }
        public event TimeChangedDelegate TimeChanged;
        private void RaiseTimeChanged(DateTime time)
        {
            if (TimeChanged != null)
            {
                TimeChanged(time);
            }
        }
        public string TimeString
        {
            get { return GetTimeString(); }
        }
        #endregion

        #region Color properties
        private Color hourColor = Color.Black;
        public Color HourHandColor
        {
            get { return hourColor; }
            set
            {
                hourColor = value;
                hourPen.Color = hourColor;
            }
        }
        private Color minuteColor = Color.Black;
        public Color MinuteHandColor
        {
            get { return minuteColor; }
            set
            {
                minuteColor = value;
                minutePen.Color = minuteColor;
            }
        }
        private Color minuteLines = Color.Red;
        public Color MinuteLines
        {
            get { return minuteLines; }
            set { minuteLines = value; }
        }
        private Color fiveminuteLines = Color.Black;
        public Color FiveMinuteLines
        {
            get { return fiveminuteLines; }
            set
            {
                fiveminuteLines = value;
                fiveMinuteLinePen.Color = fiveminuteLines;
            }
        }
        private Color clockBorder = Color.Black;
        public Color ClockBorder
        {
            get { return clockBorder; }
            set
            {
                clockBorder = value;
                thicker.Color = clockBorder;
            }
        }
        #endregion

        #region color definitions
        Pen hourPen = new Pen(Brushes.Black, 4);
        Pen minutePen = new Pen(Brushes.Black, 2);
        Pen whitePen = new Pen(Brushes.White, 4);
        Pen thicker = new Pen(Brushes.Black, 2);
        Pen fiveMinuteLinePen = new Pen(Brushes.Black, 2);
        Brush normalBackBrush = new LinearGradientBrush(new Rectangle(0, 0, 100, 600), Color.White,
                Color.Ivory, LinearGradientMode.Vertical);
        Brush backBrush;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ClockControl()
        {
            // double buffering, etc. 
            this.SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);

            // events
            this.MouseDown += new MouseEventHandler(ClockControl_Mouse);
            this.MouseMove += new MouseEventHandler(ClockControl_Mouse);
            this.MouseUp += new MouseEventHandler(ClockControl_MouseUp);
            //this.KeyDown += new KeyEventHandler(ClockControl_KeyDown);
            //this.KeyPress += new KeyPressEventHandler(ClockControl_KeyPress);

            // init background brush
            backBrush = normalBackBrush;
        }

        public string GetTimeString()
        {
            string hourstring;
            if (isAM)
                hourstring = ((hours % 12) == 0) && (minutes == 0) ? "0" : hours.ToString();
            else
            {
                hourstring = (hours >= 12) ? "12" : (12 + hours).ToString();
            }
            hourstring += ":" + minutes.ToString().PadLeft(2, '0');
            return hourstring;
        }

        #region Paint control
        /// <summary>
        /// Here's where the magic happens.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            // make it look nice
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            // create a rectangle for the clock, just a lil smaller than the control area
            Rectangle surfaceRect = Rectangle.Inflate(ClientRectangle, -padding, -padding);

            // keep this thing square
            int rectSize = Math.Min(surfaceRect.Width, surfaceRect.Height);

            surfaceRect = new Rectangle((ClientRectangle.Width / 2) - (surfaceRect.Width / 2),
                surfaceRect.Y, rectSize, rectSize);

            // keep this thing centered
            surfaceRect.X = (ClientRectangle.Width / 2) - (surfaceRect.Width / 2);

            // create a light background shadow - nah it's ugly
            /*e.Graphics.FillEllipse(Brushes.LightGray, surfaceRect.X + 7, 
                surfaceRect.Y + 8, surfaceRect.Width, surfaceRect.Height);*/

            // don't paint if it's too small
            if (surfaceRect.Width < 20 || surfaceRect.Height < 20)
                return;

            // center point
            Point zero = new Point(surfaceRect.Left + (surfaceRect.Width / 2),
                surfaceRect.Top + (surfaceRect.Height / 2));

            // fill #1
            e.Graphics.FillEllipse(backBrush, surfaceRect);

            // border
            e.Graphics.DrawEllipse(thicker, surfaceRect);


            int tickLen = (int)(surfaceRect.Width * 0.45);
            int numLen = (int)(surfaceRect.Width * 0.35);
            int inflateSize = (int)(surfaceRect.Width * 0.07);

            // draw ticks around the clock
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 == 0)
                {
                    double currAngle = 2.0 * Math.PI * (i / 60.0);

                    Point tickPt = new Point((int)(tickLen * Math.Sin(currAngle)),
                                   (int)(-tickLen * Math.Cos(currAngle)));
                    tickPt.X += zero.X;
                    tickPt.Y += zero.Y;

                    e.Graphics.DrawLine(fiveMinuteLinePen, zero, tickPt);
                }
                else
                {
                    double currAngle = 2.0 * Math.PI * (i / 60.0);

                    Point tickPt = new Point((int)(tickLen * Math.Sin(currAngle)),
                                   (int)(-tickLen * Math.Cos(currAngle)));
                    tickPt.X += zero.X;
                    tickPt.Y += zero.Y;
                    e.Graphics.DrawLine(new Pen(minuteLines), zero, tickPt);
                }
            }

            Rectangle smallerRectangle = Rectangle.Inflate(surfaceRect,
                -inflateSize, -inflateSize);
            e.Graphics.FillEllipse(backBrush, smallerRectangle);

            inflateSize /= 4;
            smallerRectangle.Inflate(-inflateSize, -inflateSize);
            e.Graphics.FillEllipse(backBrush, smallerRectangle);

            // draw numerals
            int numeral = 12;// isAM ? 12 : 24;
            int numeralFontSize = Math.Max(1, inflateSize) * 4;
            Font numeralFont = new Font("Arial Black", numeralFontSize);
            for (int i = 0; i < 60; i += 5)
            {
                double currAngle = 2.0 * Math.PI * (i / 60.0);
                Point numeralPt = new Point((int)(numLen * Math.Sin(currAngle)),
                   (int)(-numLen * Math.Cos(currAngle)));

                numeralPt.X += zero.X;
                numeralPt.Y += zero.Y;

                StringFormat numFormat = new StringFormat();
                numFormat.Alignment = StringAlignment.Center;
                numFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(numeral.ToString(), numeralFont,
                    Brushes.Black, numeralPt, numFormat);
                if (isAM)
                    numeral = (numeral == 12) ? 1 : numeral + 1;
                else
                    numeral = (numeral == 12) ? 13 : numeral + 1;
            }

            // digital time display
            int fontSize = Math.Max(1, inflateSize + 5);
            Font f = new Font(fontName, fontSize);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(GetTimeString(), f, Brushes.Black,
                zero.X, zero.Y - (zero.Y / 2), sf);

            // draw hour/minute hands
            double hourAngle = 2.0 * Math.PI * (hours + minutes / 60.0) / 12.0;
            double minuteAngle = 2.0 * Math.PI * (minutes / 60.0);
            int hourHandLen = (int)(surfaceRect.Width * 0.33);
            int minuteHandLen = (int)(surfaceRect.Width * 0.45);
            Point hourPt = new Point((int)(hourHandLen * Math.Sin(hourAngle)),
                            (int)(-hourHandLen * Math.Cos(hourAngle)));
            Point minutePt = new Point((int)(minuteHandLen * Math.Sin(minuteAngle)),
                            (int)(-minuteHandLen * Math.Cos(minuteAngle)));

            hourPt.X += zero.X;
            hourPt.Y += zero.Y;
            minutePt.X += zero.X;
            minutePt.Y += zero.Y;

            e.Graphics.DrawLine(hourPen, zero, hourPt);
            e.Graphics.DrawLine(minutePen, zero, minutePt);

            // draw center dot
            int dotWidth = (int)(surfaceRect.Width * 0.05);
            e.Graphics.FillEllipse(Brushes.Black,
                new Rectangle(zero.X - (dotWidth / 2), zero.Y - (dotWidth / 2),
                dotWidth, dotWidth));
            e.Graphics.DrawEllipse(whitePen,
                new Rectangle(zero.X - (dotWidth / 2), zero.Y - (dotWidth / 2),
                dotWidth, dotWidth));
        }
        #endregion

        #region Set time
        private void ClockControl_Mouse(object sender, MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left))
                return;
            Value = CalculateTimeFromPoint(e.X, e.Y);
            this.Refresh();
        }

        private void ClockControl_MouseUp(object sender, MouseEventArgs e)
        {
            //TimeChosen(this, EventArgs.Empty);
            RaiseTimeChanged(DateTime.Parse(GetTimeString()));
        }

        /// <summary>
        /// Figures out what time the user clicked.
        /// </summary>
        /// <param name="x">X-Coordinate of the clicked point</param>
        /// <param name="y">Y-Coordinate of the clicked point</param>
        private TimeSpan CalculateTimeFromPoint(int x, int y)
        {
            Point mid = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            Point p2 = new Point(x, y);
            double angle = (Math.Atan2(p2.Y - mid.Y, p2.X - mid.X) * 180.0 / Math.PI);
            angle += 90;
            if (angle < 0)
                angle = 270 + (90 - Math.Abs(angle));
            double percent = angle / 720;
            TimeSpan span = TimeSpan.FromMilliseconds(86400000 * percent);
            if (span.Hours == 0)
                span.Add(TimeSpan.FromHours(11));

            hours = span.Hours;
            minutes = span.Minutes;

            if (prevhours != hours)
            {
                prevhours = hours;
                prevminutes = minutes;
                RaiseTimeChanged(DateTime.Parse(GetTimeString()));
            }
            else if (prevminutes != minutes)
            {
                prevminutes = minutes;
                RaiseTimeChanged(DateTime.Parse(GetTimeString()));
            }

            return span;
        }

        /// <summary>
        /// Calculates the angle between two points.
        /// </summary>
        protected double calcAngle(Point p1, Point p2)
        {
            double currRet = (Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * 180.0 / Math.PI);
            currRet += 90;

            if (currRet < 0)
                currRet = 270 + (90 - Math.Abs(currRet));
            return currRet;
        }
        #endregion
    }
}
