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
    #endregion

    public class SshClientTools
    {
        public static Renci.SshNet.SshClient GetSSHConnection(SSHSecurityOption sshSecurityOption ,string machineName, int sshPort,  string userName, string privateKeyFile, string passCodeOrPhrase)
        {
            Renci.SshNet.SshClient sshClient;

            if (sshSecurityOption == SSHSecurityOption.Password)
            {
                byte[] b = System.Text.UTF8Encoding.UTF8.GetBytes(passCodeOrPhrase.ToCharArray());
                Renci.SshNet.AuthenticationMethod am = new Renci.SshNet.PasswordAuthenticationMethod(userName, b);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, am);
                sshClient = new Renci.SshNet.SshClient(ci);
            }
            else
            {
                Renci.SshNet.PrivateKeyFile[] pkf = new Renci.SshNet.PrivateKeyFile[1];
                pkf[0] = new Renci.SshNet.PrivateKeyFile(privateKeyFile, machineName);
                Renci.SshNet.PrivateKeyAuthenticationMethod pm = new Renci.SshNet.PrivateKeyAuthenticationMethod(userName, pkf);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, pm);
                sshClient = new Renci.SshNet.SshClient(ci);
            }

            sshClient.Connect();

            return sshClient;
        }
    }
}
