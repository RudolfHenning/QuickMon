using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
   public class ComboBoxWithBorder : ComboBox
    {
        private Color _borderColor = Color.Gray;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F; 

       public ComboBoxWithBorder()
       {
           FlatStyle = System.Windows.Forms.FlatStyle.Popup;
       }

       protected override void WndProc(ref Message m)
       {
           base.WndProc(ref m);

           if (m.Msg == WM_PAINT)
           {
               Graphics g = Graphics.FromHwnd(Handle);
               Rectangle bounds = new Rectangle(0, 0, Width, Height);
               ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle);
           }
       }
       [Category("Appearance")]
       public Color BorderColor
       {
           get { return _borderColor; }
           set
           {
               _borderColor = value;
               Invalidate(); // causes control to be redrawn
           }
       }

       [Category("Appearance")]
       public ButtonBorderStyle BorderStyle
       {
           get { return _borderStyle; }
           set
           {
               _borderStyle = value;
               Invalidate();
           }
       }    
    }
}
