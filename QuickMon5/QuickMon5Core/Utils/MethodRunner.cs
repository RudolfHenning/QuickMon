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

        public static TOutput RunWithTimeout<T, TOutput>(Func<T, TOutput> action, T input, TOutput defaultReturn, int timeoutMs)
        {
            try
            {
                TOutput output = defaultReturn;
                Exception captured = null;
                var thread = new Thread(() =>
                {
                    try
                    {
                        output = action(input);
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
                    return defaultReturn; // timed out

                if (captured != null)
                    throw captured; // rethrow exception from worker


                return output;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"RunWithTimeout error : {ex.Message}");
                return defaultReturn;
            }
        }
        public static TOutput RunWithTimeout<T, TOutput>(Func<T, T, TOutput> action, T par1, T par2, TOutput defaultReturn, int timeoutMs)
        {
            try
            {
                TOutput output = defaultReturn;
                Exception captured = null;
                var thread = new Thread(() =>
                {
                    try
                    {
                        output = action(par1, par2);
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
                    return defaultReturn; // timed out

                if (captured != null)
                    throw captured; // rethrow exception from worker
                if (thread != null)
                {
                    try
                    {
                        thread.Abort();
                        thread = null;

                    }
                    catch { }
                }

                return output;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"RunWithTimeout error : {ex.Message}");
                return defaultReturn;
            }
        }
        public static TOutput RunWithTimeout<T, TOutput>(Func<T,T,T,T, TOutput> action, T par1, T par2, T par3, T par4, TOutput defaultReturn, int timeoutMs)
        {
            try
            {
                TOutput output = defaultReturn;
                Exception captured = null;
                var thread = new Thread(() =>
                {
                    try
                    {
                        output = action(par1, par2, par3, par4);
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
                    return defaultReturn; // timed out

                if (captured != null)
                    throw captured; // rethrow exception from worker
                if (thread != null)
                {
                    try
                    {
                        thread.Abort();
                        thread = null;

                    }
                    catch { }
                }

                return output;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine($"RunWithTimeout error : {ex.Message}");
                return defaultReturn;
            }
        }
    }
}
