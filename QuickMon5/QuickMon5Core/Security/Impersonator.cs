using System;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace QuickMon.Security
{
    public static class Impersonator
    {
        /// <summary>
        /// Impersonate given logon information.
        /// </summary>
        /// <param name="logon">Windows logon name.</param>
        /// <param name="password">password</param>
        /// <param name="domain">domain name</param>
        /// <returns></returns>
        public static bool Impersonate(string logon, string password, string domain)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            if (LogonUser(logon, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {

                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    impersonationContext = tempWindowsIdentity.Impersonate();
                    if (null != impersonationContext) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Unimpersonate.
        /// </summary>
        public static void UnImpersonate()
        {
            impersonationContext.Undo();
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LogonUser(
            string lpszUserName,
            String lpszDomain,
            String lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        [DllImport("advapi32.dll",
        CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public extern static int DuplicateToken(
            IntPtr hToken,
            int impersonationLevel,
            ref IntPtr hNewToken);

        private const int LOGON32_LOGON_INTERACTIVE = 2;
        private const int LOGON32_LOGON_NETWORK_CLEARTEXT = 4;
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private static WindowsImpersonationContext impersonationContext;
    }
}
