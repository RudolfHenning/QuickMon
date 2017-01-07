using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon
{
    public delegate void SimpleMessageDelegate(string message);
    public delegate void CollectorHostDelegate(CollectorHost collectorHost);
    public delegate void NotifierHostDelegate(NotifierHost notifierHost);
    public delegate void CollectorHostWithMessageDelegate(CollectorHost collectorHost, string message);
    public delegate void CollectorHostWith2MessagesDelegate(CollectorHost collectorHost, string message, string message2);
    public delegate void NotifierHostWithMessageDelegate(NotifierHost notifierHost, string message);
    public delegate void CollectorHostExecutionTimeDelegate(CollectorHost collectorHost, long msTime);

}
