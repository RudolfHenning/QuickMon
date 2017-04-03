using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface INotivierViewer
    {
        INotifier SelectedNotifier { get; set; }
        //void ShowNotifierViewer();
        //bool IsViewerStillVisible();
        //void CloseViewer();
    }
}
