using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class LinkLabelEx : LinkLabel
    {
        public LinkLabelEx()
        {
            BackColorOnLeave = Color.White;
            BackColorOnEnter = Color.White;        
        }
        public Color BackColorOnLeave { get; set; }
        public Color BackColorOnEnter { get; set; }

        protected override void OnMouseEnter(EventArgs e)
        {
            BackColor = BackColorOnEnter;
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            BackColor = BackColorOnLeave;
            base.OnMouseLeave(e);
        }
    }
}
