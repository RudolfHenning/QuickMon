using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Forms
{
    public static class WinFormUtils
    {
        public static bool IsStillVisible(this Form form)
        {
            return (!(form.Disposing || form.IsDisposed)) && form.Visible;
        }
        public static void SaveValueSet(this NumericUpDown nud, decimal value)
        {
            if (value < nud.Minimum)
                nud.Value = nud.Minimum;
            else if (value > nud.Maximum)
                nud.Value = nud.Maximum;
            else
                nud.Value = value;
        }
    }
}
