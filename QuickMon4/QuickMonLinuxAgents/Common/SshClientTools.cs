using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.Linux
{
    #region Enums
    public enum SSHSecurityOption
    {
        Password = 0,
        PrivateKey = 1
    }
    public static class SSHSecurityOptionTypeConverter
    {
        public static SSHSecurityOption FromString(string typeName)
        {
            if (typeName.ToLower() == "password")
                return SSHSecurityOption.Password;
            else
                return SSHSecurityOption.PrivateKey;
        }
    }
    #endregion

    public class SSHConnectionDetails
    {
        public SSHSecurityOption SSHSecurityOption { get; set; }
        public string ComputerName { get; set; }
        public int SSHPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrivateKeyFile { get; set; }
        public string PassPhrase { get; set; }

        public static string FormatSSHConnection(SSHConnectionDetails connection)
        {
            return string.Format("Computer={0}:{1},Sec={2},User={3},PrvtKeyFile={4}", connection.ComputerName, connection.SSHPort, connection.SSHSecurityOption == SSHSecurityOption.Password ? "Pwd" : "PrvtKey", connection.UserName, connection.PrivateKeyFile);
        }
    }

    public class SshClientTools
    {
        public static Renci.SshNet.SshClient GetSSHConnection(SSHSecurityOption sshSecurityOption ,string machineName, int sshPort,  string userName, string password, string privateKeyFile, string passCodeOrPhrase)
        {
            Renci.SshNet.SshClient sshClient;

            if (sshSecurityOption == SSHSecurityOption.Password)
            {
                byte[] b = System.Text.UTF8Encoding.UTF8.GetBytes(password.ToCharArray());
                Renci.SshNet.AuthenticationMethod am = new Renci.SshNet.PasswordAuthenticationMethod(userName, b);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, am);
                sshClient = new Renci.SshNet.SshClient(ci);
            }
            else
            {
                Renci.SshNet.PrivateKeyFile[] pkf = new Renci.SshNet.PrivateKeyFile[1];
                pkf[0] = new Renci.SshNet.PrivateKeyFile(privateKeyFile, passCodeOrPhrase);
                Renci.SshNet.PrivateKeyAuthenticationMethod pm = new Renci.SshNet.PrivateKeyAuthenticationMethod(userName, pkf);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, pm);
                sshClient = new Renci.SshNet.SshClient(ci);
            }

            sshClient.Connect();

            return sshClient;
        }
    }
}
