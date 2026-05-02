using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickMon
{
    public static class PerformanceCounterTools
    {
        public static PerformanceCounterCategory CreatePerformanceCounterCategoryWithTimeout(string categoryName, string machineName)
        {
            Func<string, string, PerformanceCounterCategory> func = (category, machine) =>
            {
                PerformanceCounterCategory pcCat = null;
                try
                {
                    Trace.WriteLine($"CreatePerformanceCounterCategoryWithTimeout : {machine}\\{category}");
                    pcCat = new PerformanceCounterCategory(category, machine);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"CreatePerformanceCounterWithTimeout error : {ex.Message}");
                }
                return pcCat;
            };
            return MethodRunner.RunWithTimeout<string, PerformanceCounterCategory>(func, categoryName, machineName, null, 5000);
        }
        public static PerformanceCounter CreatePerformanceCounterWithTimeout(string categoryName, string counterName, string instanceName, string machineName)
        {
            Func<string, string, string, string, PerformanceCounter> func = (category, counter, instance, machine) =>
            {
                PerformanceCounter pc = null;
                try
                {
                    Trace.WriteLine($"CreatePerformanceCounterWithTimeout : {machine}\\{category}\\{counter}\\{instance}");
                    pc = new PerformanceCounter(category, counter, instance, machine);
                }
                catch(Exception ex)
                {
                    Trace.WriteLine($"CreatePerformanceCounterWithTimeout error : {ex.Message}");
                }
                return pc;
            };

            return MethodRunner.RunWithTimeout<string, PerformanceCounter>(func, categoryName, counterName, instanceName, machineName, null, 5000);
        }
    }
}
