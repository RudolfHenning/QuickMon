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
    }
}
