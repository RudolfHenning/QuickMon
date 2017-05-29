using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickMon.SSH
{
    #region Enums
    public enum SSHSecurityOption
    {
        Password = 0,
        PrivateKey = 1,
        KeyboardInteractive = 2
    }
    public static class SSHSecurityOptionTypeConverter
    {
        public static SSHSecurityOption FromString(string typeName)
        {
            if (typeName.ToLower() == "password")
                return SSHSecurityOption.Password;
            else if (typeName.ToLower() == "privatekey")
                return SSHSecurityOption.PrivateKey;
            else
                return SSHSecurityOption.KeyboardInteractive;
        }
    }
    #endregion

    public class SSHConnectionDetails
    {
        public SSHConnectionDetails()
        {
            UseConnectionString = false;
        }
        public SSHSecurityOption SSHSecurityOption { get; set; }
        public string ComputerName { get; set; }
        public int SSHPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PrivateKeyFile { get; set; }
        public string PassPhrase { get; set; }
        public bool Persistent { get; set; }
        public bool UseConnectionString { get; set; }
        private Renci.SshNet.SshClient currentConnection = null;

        public static string FormatSSHConnection(SSHConnectionDetails connection, bool forDisplayOnly = true)
        {
            string output = "";
            if (forDisplayOnly)
                output = string.Format("Computer={0}:{1};SecOpt={2};User={3};PrivateKeyFile={4};Persistent={5}", 
                    connection.ComputerName, 
                    connection.SSHPort, 
                    connection.SSHSecurityOption == SSHSecurityOption.Password ? "Pwd" : "PrvtKey", 
                    connection.UserName, 
                    connection.PrivateKeyFile, 
                    connection.Persistent ? "Yes" : "No");
            else
                output = string.Format("Computer={0}:{1};SecOpt={2};User={3};Pass={4};PrivateKeyFile={5};PassPhrase={6};Persistent={7}", 
                    connection.ComputerName, 
                    connection.SSHPort, 
                    connection.SSHSecurityOption == SSHSecurityOption.Password ? "Pwd" : "PrvtKey", 
                    connection.UserName,
                    connection.Password,
                    connection.PrivateKeyFile,
                    connection.PassPhrase,
                    connection.Persistent ? "Yes" : "No");
            return output;
        }

        public static SSHConnectionDetails FromXmlElement(System.Xml.XmlElement node)
        {
            SSHConnectionDetails conn = new SSHConnectionDetails();
            conn.UseConnectionString = node.ReadXmlElementAttr("useConnStr", false);

            bool redConnectionString = true;
            if (conn.UseConnectionString)
            {
                //Parse ConnectionString
                string sshConnectionString = node.ReadXmlElementAttr("connStr", "");
                if (sshConnectionString.Length == 0)
                {
                    redConnectionString = false;
                }
                else
                {
                    string[] pa = sshConnectionString.Split(';');
                    foreach (string s in pa)
                    {
                        if (s.ToLower().StartsWith("computer="))
                        {
                            string computerName = s.Substring("computer=".Length);
                            int port = 22;
                            if (computerName.Contains(':') && computerName.Split(':')[1].IsInteger())
                            {
                                port = int.Parse(computerName.Split(':')[1]);
                                computerName = computerName.Split(':')[0];
                            }
                            conn.ComputerName = computerName;
                            conn.SSHPort = port;
                        }
                        if (s.ToLower().StartsWith("secopt="))
                        {
                            conn.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(s.Substring("secopt=".Length));
                        }
                        if (s.ToLower().StartsWith("user="))
                        {
                            conn.UserName = s.Substring("user=".Length);
                        }
                        if (s.ToLower().StartsWith("pass="))
                        {
                            conn.Password = s.Substring("pass=".Length);
                        }
                        if (s.ToLower().StartsWith("privatekeyfile="))
                        {
                            conn.PrivateKeyFile = s.Substring("privatekeyfile=".Length);
                        }
                        if (s.ToLower().StartsWith("passphrase="))
                        {
                            conn.PassPhrase = s.Substring("passphrase=".Length);
                        }
                        if (s.ToLower().StartsWith("persistent="))
                        {
                            conn.Persistent = FormatUtils.NBool(s.Substring("persistent=".Length));
                        }
                    }
                }
            }
            if (!conn.UseConnectionString || !redConnectionString)
            {
                conn.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(node.ReadXmlElementAttr("sshSecOpt", "password"));
                conn.ComputerName = node.ReadXmlElementAttr("machine", ".");
                conn.SSHPort = node.ReadXmlElementAttr("sshPort", 22);
                conn.UserName = node.ReadXmlElementAttr("userName", "");
                conn.Password = node.ReadXmlElementAttr("password", "");
                conn.PrivateKeyFile = node.ReadXmlElementAttr("privateKeyFile", "");
                conn.PassPhrase = node.ReadXmlElementAttr("passPhrase", "");
                conn.Persistent = node.ReadXmlElementAttr("persistent", false);
            }

            return conn;
        }

        public void SaveToXmlElementAttr(System.Xml.XmlElement node)
        {
            node.SetAttributeValue("useConnStr", UseConnectionString);
            if (!UseConnectionString)
            {                
                node.SetAttributeValue("sshSecOpt", SSHSecurityOption.ToString());
                node.SetAttributeValue("machine", ComputerName);
                node.SetAttributeValue("sshPort", SSHPort);
                node.SetAttributeValue("userName", UserName);
                node.SetAttributeValue("password", Password);
                node.SetAttributeValue("privateKeyFile", PrivateKeyFile);
                node.SetAttributeValue("passPhrase", PassPhrase);
                node.SetAttributeValue("persistent", Persistent);
            }
            else
            {
                node.SetAttributeValue("connStr", FormatSSHConnection(this, true));
            }
        }

        public Renci.SshNet.SshClient GetConnection()
        {
            try
            {
                if (!Persistent || currentConnection == null)
                {
                    currentConnection = SshClientTools.GetSSHConnection(this);
                }
                else if (!currentConnection.IsConnected)
                    currentConnection.Connect();
            }
            catch
            {
                currentConnection = SshClientTools.GetSSHConnection(this);
            }

            return currentConnection;
        }
        public void CloseConnection(bool force = false)
        {
            if (currentConnection != null && (!Persistent || force))
            {
                currentConnection.Disconnect();
                currentConnection = null;
            }
        }
    }

    public class SshClientTools
    {
        private static string keyBoardPassword = "";
        public static Renci.SshNet.SshClient GetSSHConnection(SSHConnectionDetails sshConnection)
        {
            return GetSSHConnection(sshConnection.SSHSecurityOption, sshConnection.ComputerName, sshConnection.SSHPort, sshConnection.UserName, sshConnection.Password, sshConnection.PrivateKeyFile, sshConnection.PassPhrase);
        }
        public static Renci.SshNet.SshClient GetSSHConnection(SSHSecurityOption sshSecurityOption, string machineName, int sshPort, string userName, string password, string privateKeyFile, string passCodeOrPhrase)
        {
            Renci.SshNet.SshClient sshClient;

            if (sshSecurityOption == SSHSecurityOption.Password)
            {
                byte[] b = System.Text.UTF8Encoding.UTF8.GetBytes(password.ToCharArray());
                Renci.SshNet.AuthenticationMethod am = new Renci.SshNet.PasswordAuthenticationMethod(userName, b);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, am);
                sshClient = new Renci.SshNet.SshClient(ci);
            }
            else if (sshSecurityOption == SSHSecurityOption.PrivateKey)
            {
                Renci.SshNet.PrivateKeyFile[] pkf = new Renci.SshNet.PrivateKeyFile[1];
                pkf[0] = new Renci.SshNet.PrivateKeyFile(privateKeyFile, passCodeOrPhrase);
                Renci.SshNet.PrivateKeyAuthenticationMethod pm = new Renci.SshNet.PrivateKeyAuthenticationMethod(userName, pkf);
                Renci.SshNet.ConnectionInfo ci = new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, pm);
                sshClient = new Renci.SshNet.SshClient(ci);
            }
            else
            {
                Renci.SshNet.KeyboardInteractiveAuthenticationMethod kauth = new Renci.SshNet.KeyboardInteractiveAuthenticationMethod(userName);
                Renci.SshNet.PasswordAuthenticationMethod pauth = new Renci.SshNet.PasswordAuthenticationMethod(userName, password);
                keyBoardPassword = password;
                kauth.AuthenticationPrompt += new EventHandler<Renci.SshNet.Common.AuthenticationPromptEventArgs>(HandleKeyEvent);
                sshClient = new Renci.SshNet.SshClient(new Renci.SshNet.ConnectionInfo(machineName, sshPort, userName, pauth, kauth));
            }

            sshClient.Connect();

            return sshClient;
        }

        private static void HandleKeyEvent(Object sender, Renci.SshNet.Common.AuthenticationPromptEventArgs e)
        {
            foreach (Renci.SshNet.Common.AuthenticationPrompt prompt in e.Prompts)
            {
                if (prompt.Request.IndexOf("Password:", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    prompt.Response = keyBoardPassword;
                }
            }
        }
    }
}
