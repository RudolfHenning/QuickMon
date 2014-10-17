using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace QuickMon
{
    public static class HTTPActivationTest
    { 
        const int OS_ANYSERVER = 29;

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        private static extern bool IsOS(int os);
        public static bool IsWindowsServer()
        {
            return HTTPActivationTest.IsOS(HTTPActivationTest.OS_ANYSERVER);
        }
        public static bool IsWin2008OrNewer()
        {
            return System.Environment.OSVersion.Version.Major >= 6;            
        }
        public static bool IsHTTPActivationEnabled()
        {
            if (IsWindowsServer() && IsWin2008OrNewer())
            {
                string wmiQuery = "select Name from Win32_ServerFeature where Name = 'HTTP Activation'";
                ManagementScope managementScope = new ManagementScope(new ManagementPath("root\\cimv2"));
                using (ManagementObjectSearcher searcherInstance = new ManagementObjectSearcher(managementScope, new WqlObjectQuery(wmiQuery), null))
                {
                    if (searcherInstance != null)
                    {
                        using (ManagementObjectCollection results = searcherInstance.Get())
                        {
                            int nItems = results.Count;
                            return nItems > 0;
                        }
                    }
                }
                return false;
            }
            else
               return true;
        }
    }
}
