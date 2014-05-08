using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public class TreeViewEx : TreeView
    {
        public TreeViewEx()
            : base()
        {
            DoubleBuffered = true;
        }
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
    }
}
