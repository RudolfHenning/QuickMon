using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public interface ICollectorDetailView
    {
        void ShowCollectorDetails(ICollector Collector);
        void RefreshConfig(ICollector Collector);
        /// <summary>
        /// This is neede because a user can 'close' a form after opening it.
        /// There will still be a reference to 'this' class so simply refreshing the form won't work anymore
        /// </summary>
        /// <returns></returns>
        bool IsStillVisible();
    }
}
