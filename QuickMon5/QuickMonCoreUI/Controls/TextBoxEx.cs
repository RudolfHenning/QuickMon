using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    public class TextBoxEx : TextBox
    {
        public event MethodInvoker EnterAndControlKeyPressed;
        public event MethodInvoker EnterKeyPressed;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                EnterAndControlKeyPressed?.Invoke();                
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {                
                e.SuppressKeyPress = true;
                e.Handled = true;
                EnterKeyPressed?.Invoke();
            }
            else
                base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
}
