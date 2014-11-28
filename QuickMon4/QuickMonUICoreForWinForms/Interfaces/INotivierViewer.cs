using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public interface INotivierViewer
    {
        void ShowNotifierViewer(INotifier notifier);
        void RefreshConfig(INotifier notifier);
        bool IsStillVisible();
        void SetWindowTitle(string title);
        void CloseWindow();
        void LoadDisplayData();
        void RefreshDisplayData();
    }
}
