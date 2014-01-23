using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public class ListViewEx : ListView
    {
        public ListViewEx()
            : base()
        {
            DoubleBuffered = true;
            View = View.Details;
            resizeTimer.Tick +=  resizeTimer_Tick;
        }

        [Description("Use one column to auto resize in detail view")]
        public bool AutoResizeColumnEnabled { get; set; }
        [Description("Column index of auto resize column")]
        public int AutoResizeColumnIndex { get; set; }
        public event MethodInvoker EnterKeyPressed;
        public event MethodInvoker DeleteKeyPressed;
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                if (EnterKeyPressed != null)
                {
                    EnterKeyPressed();
                    e.Handled = true;
                }
            base.OnKeyPress(e);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (DeleteKeyPressed != null)
                {
                    DeleteKeyPressed();
                    e.Handled = true;
                }
            base.OnKeyDown(e);
        }

        private Timer resizeTimer = new Timer() { Interval = 50, Enabled = false };
        private void resizeTimer_Tick(object sender, EventArgs e)
        {
            resizeTimer.Enabled = false;
            try
            {
                if (AutoResizeColumnEnabled && View == System.Windows.Forms.View.Details &&
                    AutoResizeColumnIndex > -1 && this.Columns.Count > AutoResizeColumnIndex)
                {
                    int columnsWidth = 0;
                    Application.DoEvents();
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        if (i != AutoResizeColumnIndex)
                            columnsWidth += this.Columns[i].Width;
                    }
                    this.Columns[AutoResizeColumnIndex].Width = this.ClientSize.Width - columnsWidth - 2;
                }
            }
            catch { }
        }
        protected override void OnResize(EventArgs e)
        {
            resizeTimer.Enabled = false;
            resizeTimer.Enabled = true;
            base.OnResize(e);
        }
    }
}
