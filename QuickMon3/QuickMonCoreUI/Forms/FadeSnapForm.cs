using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public class FadeSnapForm : Form
    {
        #region Private constants Fading
        private const int AW_HIDE = 0X10000;
        private const int AW_ACTIVATE = 0X20000;
        private const int AW_BLEND = 0X80000;
        private const int FADEINTTIME = 250;
        private const int FADEOUTTIME = 200;
        #endregion

        #region Private vars snapping
        private int iScreenSnapDistance = 25;
        private System.Windows.Forms.Timer moveTimer;
        #endregion

        private bool snappingEnabled = false;
        public bool SnappingEnabled
        {
            get { return snappingEnabled; }
            set { snappingEnabled = value; CheckPosition(); }
        }
        private int fadeInTime = FADEINTTIME;
        public int FadeInTime
        {
            get { return fadeInTime; }
            set { fadeInTime = value; }
        }
        private int fadeOutTime = FADEOUTTIME;
        public int FadeOutTime
        {
            get { return fadeOutTime; }
            set { fadeOutTime = value; }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow
        (IntPtr hwand, int dwTime, int dwFlags);

        public FadeSnapForm()
        {
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 200;
            moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);

            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
        }

        #region Snapping
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            CheckPosition();
        }
        private void CheckPosition()
        {
            if (SnappingEnabled)
            {
                Rectangle rFormRect = Screen.FromControl(this).WorkingArea;

                int adjustedLeft = this.Left;
                int adjustedTop = this.Top;

                int w = this.Width;
                int h = this.Height;

                if (adjustedTop >= rFormRect.Top - iScreenSnapDistance &&
                    adjustedTop <= rFormRect.Top + iScreenSnapDistance)
                    this.Top = rFormRect.Top;
                else if (adjustedTop + h > rFormRect.Bottom - iScreenSnapDistance &&
                         adjustedTop + h < rFormRect.Bottom + iScreenSnapDistance)
                    this.Top = rFormRect.Bottom - h;
                else
                    this.Top = adjustedTop;

                if (adjustedLeft >= rFormRect.Left - iScreenSnapDistance &&
                    adjustedLeft <= rFormRect.Left + iScreenSnapDistance)
                    this.Left = rFormRect.Left;
                else if (adjustedLeft + w > rFormRect.Right - iScreenSnapDistance &&
                         adjustedLeft + w < rFormRect.Right + iScreenSnapDistance)
                    this.Left = rFormRect.Right - w;
                else
                    this.Left = adjustedLeft;

                //in case form went out of sight(of current screen)
                moveTimer.Enabled = false;
                moveTimer.Enabled = true;
            }
        }
        private void moveTimer_Tick(object sender, EventArgs e)
        {
            if (SnappingEnabled)
            {
                moveTimer.Enabled = false;
                if (this.WindowState == FormWindowState.Normal)
                {
                    Rectangle currentScreen = Screen.FromControl(this).WorkingArea;
                    if (this.Top - iScreenSnapDistance < currentScreen.Top)
                        this.Top = currentScreen.Top;
                    if (this.Left - iScreenSnapDistance < currentScreen.Left)
                        this.Left = currentScreen.Left;
                    if (this.Top + this.Height + iScreenSnapDistance > currentScreen.Top + currentScreen.Height)
                        this.Top = currentScreen.Top + currentScreen.Height - this.Height;
                    if (this.Left + this.Width + iScreenSnapDistance > currentScreen.Left + currentScreen.Width)
                        this.Left = currentScreen.Left + currentScreen.Width - this.Width;
                }
            }
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateWindow(this.Handle, fadeInTime, AW_ACTIVATE | AW_BLEND);
            this.Refresh();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged -= new EventHandler(SystemEvents_DisplaySettingsChanged);
            if (e.Cancel == false)
            {
                AnimateWindow(this.Handle, fadeOutTime, AW_HIDE | AW_BLEND);
            }
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            CheckPosition();
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            CheckPosition();
        }
        #endregion
    }
}
