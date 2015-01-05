using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class NoBorderStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //if (e.ToolStrip.GetType().Name != "MyCustomToolStrip")
            {
                //base.OnRenderToolStripBorder(e);
            }
        }
    }
    public class ToolStripEx : ToolStrip
    {
        public ToolStripEx()
        {
            Renderer = new NoBorderStripRenderer();
        }
    }
}
