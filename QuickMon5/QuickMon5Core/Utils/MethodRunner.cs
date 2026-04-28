using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuickMon
{
    public static class MethodRunner
    {
        public static bool RunWithTimeout(Action action, int timeoutMs)
        {
            Exception captured = null;
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    captured = ex;
                }
            });

            thread.IsBackground = true;
            thread.Start();

            bool finished = thread.Join(timeoutMs);

            if (!finished)
                return false; // timed out

            if (captured != null)
                throw captured; // rethrow exception from worker

            return true; // completed successfully
        }

    }
}
