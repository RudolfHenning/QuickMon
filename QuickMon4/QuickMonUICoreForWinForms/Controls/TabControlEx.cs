using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QuickMon.Controls
{
    public class TabControlEx: TabControl
    {
        public TabControlEx()
        {
            
            //BorderStyle = BorderStyle.None;
            //Renderer = new NoBorderStripRenderer();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
