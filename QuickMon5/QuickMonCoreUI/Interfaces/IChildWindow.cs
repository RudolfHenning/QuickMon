using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMon
{
    public interface IChildWindowIdentity
    {
        string Identifier { get; set; }
        IParentWindow ParentWindow { get; set; }
        bool AutoRefreshEnabled { get; set; }
        void RefreshDetails();
        /// <summary>
        /// Child window must remove itself from Main form reference list
        /// </summary>
        void DeRegisterChildWindow();
        void ShowChildWindow(IParentWindow parentWindow = null);
    }

    public interface IParentWindow
    {
        void RegisterChildWindow(IChildWindowIdentity childWindow);
        void RemoveChildWindow(IChildWindowIdentity childWindow);
    }
}
