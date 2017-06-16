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
        public string ConnectionName { get; set; }
        public bool UseConnectionString { get; set; }
        public string ConnectionString { get; set; }
        private Renci.SshNet.SshClient currentConnection = null;

        public static string FormatSSHConnection(SSHConnectionDetails connection)
        {
            string output = "";
            if (connection.ConnectionString != null && connection.ConnectionString.Length > 0 && !connection.ConnectionString.Contains(';'))
            {
                output = connection.ConnectionString;
            }
            else
            {
                output = string.Format("Name={0};Computer={1}:{2};SecOpt={3};User={4};Pass={5};PrivateKeyFile={6};PassPhrase={7};Persistent={8}",
                        connection.ConnectionName,
                        connection.ComputerName,
                        connection.SSHPort,
                        connection.SSHSecurityOption.ToString(),
                        connection.UserName,
                        connection.Password,
                        connection.PrivateKeyFile,
                        connection.PassPhrase,
                        connection.Persistent ? "True" : "False");
            }

            //if (forDisplayOnly)
            //{
            //    if (connection.UseConnectionString && !connection.ConnectionString.Contains(';'))
            //    {
            //        output = connection.ConnectionString;
            //    }
            //    else
            //    {
            //        output = string.Format("Name={0};Computer={1}:{2};SecOpt={3};User={4};PrivateKeyFile={5};Persistent={6}",
            //            connection.ConnectionName,
            //            connection.ComputerName,
            //            connection.SSHPort,
            //            connection.SSHSecurityOption.ToString(),
            //            connection.UserName,
            //            connection.PrivateKeyFile,
            //            connection.Persistent ? "True" : "False");
            //    }
            //}
            //else
            //{
            //    if (connection.UseConnectionString)
            //    {
            //        output = connection.ConnectionString;
            //    }
            //    else
            //    {
            //        output = string.Format("Name={0};Computer={1}:{2};SecOpt={3};User={4};Pass={5};PrivateKeyFile={6};PassPhrase={7};Persistent={8}",
            //            connection.ConnectionName,
            //            connection.ComputerName,
            //            connection.SSHPort,
            //            connection.SSHSecurityOption.ToString(),
            //            connection.UserName,
            //            connection.Password,
            //            connection.PrivateKeyFile,
            //            connection.PassPhrase,
            //            connection.Persistent ? "True" : "False");
            //    }
            //}
            return output;
        }

        public static SSHConnectionDetails FromConnectionString(string connectionString)
        {
            SSHConnectionDetails conn = new SSHConnectionDetails();
            conn.ConnectionString = connectionString;
            FromConnectionString(conn);
            return conn;
        }
        public static void FromConnectionString(SSHConnectionDetails conn)
        {
            string sshConnectionString = conn.ConnectionString;
            if (sshConnectionString.Length > 0)
            {
                if (System.IO.File.Exists(sshConnectionString))
                {
                    sshConnectionString = System.IO.File.ReadAllText(sshConnectionString);
                }

                string[] pa = sshConnectionString.Split(';');
                foreach (string s in pa)
                {
                    if (s.ToLower().StartsWith("name="))
                    {
                        conn.ConnectionName = s.Substring("name=".Length);
                    }
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
        public static SSHConnectionDetails FromXmlElement(System.Xml.XmlElement node)
        {
            SSHConnectionDetails conn = new SSHConnectionDetails();
            conn.UseConnectionString = node.ReadXmlElementAttr("useConnStr", false);
            conn.ConnectionString = node.ReadXmlElementAttr("connStr", "");

            if (conn.ConnectionString.Length > 0) // conn.UseConnectionString)
            {
                //Parse ConnectionString
                FromConnectionString(conn);

                //string sshConnectionString = conn.ConnectionString;
                //if (sshConnectionString.Length > 0)                
                //{
                //    if (System.IO.File.Exists(sshConnectionString))
                //    {
                //        sshConnectionString = System.IO.File.ReadAllText(sshConnectionString);
                //    }

                //    string[] pa = sshConnectionString.Split(';');
                //    foreach (string s in pa)
                //    {
                //        if (s.ToLower().StartsWith("name="))
                //        {
                //            conn.ConnectionName = s.Substring("name=".Length);
                //        }
                //        if (s.ToLower().StartsWith("computer="))
                //        {
                //            string computerName = s.Substring("computer=".Length);
                //            int port = 22;
                //            if (computerName.Contains(':') && computerName.Split(':')[1].IsInteger())
                //            {
                //                port = int.Parse(computerName.Split(':')[1]);
                //                computerName = computerName.Split(':')[0];
                //            }
                //            conn.ComputerName = computerName;
                //            conn.SSHPort = port;
                //        }
                //        if (s.ToLower().StartsWith("secopt="))
                //        {
                //            conn.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(s.Substring("secopt=".Length));
                //        }
                //        if (s.ToLower().StartsWith("user="))
                //        {
                //            conn.UserName = s.Substring("user=".Length);
                //        }
                //        if (s.ToLower().StartsWith("pass="))
                //        {
                //            conn.Password = s.Substring("pass=".Length);
                //        }
                //        if (s.ToLower().StartsWith("privatekeyfile="))
                //        {
                //            conn.PrivateKeyFile = s.Substring("privatekeyfile=".Length);
                //        }
                //        if (s.ToLower().StartsWith("passphrase="))
                //        {
                //            conn.PassPhrase = s.Substring("passphrase=".Length);
                //        }
                //        if (s.ToLower().StartsWith("persistent="))
                //        {
                //            conn.Persistent = FormatUtils.NBool(s.Substring("persistent=".Length));
                //        }
                //    }
                //}
            }
            else
            {
                conn.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(node.ReadXmlElementAttr("sshSecOpt", "password"));
                conn.ComputerName = node.ReadXmlElementAttr("machine", ".");
                conn.SSHPort = node.ReadXmlElementAttr("sshPort", 22);
                conn.UserName = node.ReadXmlElementAttr("userName", "");
                conn.Password = node.ReadXmlElementAttr("password", "");
                conn.PrivateKeyFile = node.ReadXmlElementAttr("privateKeyFile", "");
                conn.PassPhrase = node.ReadXmlElementAttr("passPhrase", "");
                conn.Persistent = node.ReadXmlElementAttr("persistent", false);
                conn.ConnectionName = node.ReadXmlElementAttr("name", "");
                conn.ConnectionString = FormatSSHConnection(conn);
            }
            //if (!conn.UseConnectionString || conn.ConnectionString.Length == 0)
            //{
            //    conn.SSHSecurityOption = SSHSecurityOptionTypeConverter.FromString(node.ReadXmlElementAttr("sshSecOpt", "password"));
            //    conn.ComputerName = node.ReadXmlElementAttr("machine", ".");
            //    conn.SSHPort = node.ReadXmlElementAttr("sshPort", 22);
            //    conn.UserName = node.ReadXmlElementAttr("userName", "");
            //    conn.Password = node.ReadXmlElementAttr("password", "");
            //    conn.PrivateKeyFile = node.ReadXmlElementAttr("privateKeyFile", "");
            //    conn.PassPhrase = node.ReadXmlElementAttr("passPhrase", "");
            //    conn.Persistent = node.ReadXmlElementAttr("persistent", false);
            //    conn.ConnectionName = node.ReadXmlElementAttr("name", "");
            //}

            return conn;
        }

        public void SaveToXmlElementAttr(System.Xml.XmlElement node)
        {
            //node.SetAttributeValue("useConnStr", UseConnectionString);
            //if (!UseConnectionString)
            //{                
            //    node.SetAttributeValue("sshSecOpt", SSHSecurityOption.ToString());
            //    node.SetAttributeValue("machine", ComputerName);
            //    node.SetAttributeValue("sshPort", SSHPort);
            //    node.SetAttributeValue("userName", UserName);
            //    node.SetAttributeValue("password", Password);
            //    node.SetAttributeValue("privateKeyFile", PrivateKeyFile);
            //    node.SetAttributeValue("passPhrase", PassPhrase);
            //    node.SetAttributeValue("persistent", Persistent);
            //    node.SetAttributeValue("name", ConnectionName);
            //}
            //else 
            //{
                if (ConnectionString.Contains(";")) //if previous connection string contains ';'
                {
                    node.SetAttributeValue("connStr", FormatSSHConnection(this));
                }
                else
                {
                    node.SetAttributeValue("connStr", ConnectionString);
                }
            //}
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
            if (sshConnection.UseConnectionString)
            {
                SSHConnectionDetails.FromConnectionString(sshConnection);
            }
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
