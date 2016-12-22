using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml;

namespace QuickMon.Security
{
    public class CredentialManager
    {
        public CredentialManager()
        {
            aditionalEntropy = System.Text.UTF8Encoding.UTF8.GetBytes(masterKey.ToCharArray());
        }

        public class Account
        {
            public int UserNameHash { get; set; }
            public string EncryptedPwd { get; set; }
        }

        #region Properties
        private string masterKey = @"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz~{};:,.?/\[]!@#$%^*()-_=+";
        public string MasterKey
        {
            get { return masterKey; }
            set
            {
                masterKey = value;
                aditionalEntropy = System.Text.UTF8Encoding.UTF8.GetBytes(masterKey.ToCharArray());
            }
        }
        public string PersistedStorageLocation { get; set; }
        #endregion

        #region Private vars
        private byte[] aditionalEntropy;
        private List<Account> accountCache = new List<Account>();
        #endregion

        #region Static
        public static bool IsAccountPersisted(string persistedStorageLocation, string masterKey, string username)
        {
            bool found = false;
            try
            {
                CredentialManager credMan = new CredentialManager();
                credMan.MasterKey = masterKey;
                credMan.OpenCache(persistedStorageLocation);
                found = credMan.IsAccountPersisted(username);
            }
            catch { }
            return found;
        }
        public static bool IsAccountDecryptable(string persistedStorageLocation, string masterKey, string username)
        {
            bool found = false;
            try
            {
                CredentialManager credMan = new CredentialManager();
                credMan.MasterKey = masterKey;
                credMan.OpenCache(persistedStorageLocation);
                found = credMan.IsAccountDecryptable(username);
            }
            catch { }
            return found;
        }
        public static string GetAccountPassword(string persistedStorageLocation, string masterKey, string username)
        {
            string password = "";
            try
            {
                CredentialManager credMan = new CredentialManager();
                credMan.MasterKey = masterKey;
                credMan.OpenCache(persistedStorageLocation);
                password = credMan.GetAccountPassword(username);
            }
            catch { }
            return password;
        }

        #endregion

        #region IO
        public void OpenCache()
        {
            if (PersistedStorageLocation != null && PersistedStorageLocation.Length > 0 && System.IO.File.Exists(PersistedStorageLocation))
            {
                OpenCache(PersistedStorageLocation);
            }
            else
                throw new Exception("Persisted storage location not set!");
        }
        public void OpenCache(string persistedStorageLocation)
        {
            if (System.IO.File.Exists(persistedStorageLocation))
            {
                accountCache = new List<Account>();
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(persistedStorageLocation);
                foreach (XmlNode node in xdoc.SelectNodes("accounts/account"))
                {
                    Account account = new Account();
                    account.UserNameHash = node.ReadXmlElementAttr("user", 0);
                    account.EncryptedPwd = node.ReadXmlElementAttr("pwd", "");
                    if (account.UserNameHash != 0 && account.EncryptedPwd.Length > 0)
                        accountCache.Add(account);
                }
            }
        }
        public void SaveCache()
        {
            if (PersistedStorageLocation != null && PersistedStorageLocation.Length > 0 && System.IO.File.Exists(PersistedStorageLocation))
            {
                SaveCache(PersistedStorageLocation);
            }
            else
                throw new Exception("Persisted storage location not set!");
        }
        public void SaveCache(string persistedStorageLocation)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml("<accounts />");
            XmlElement root = xdoc.DocumentElement;
            foreach (Account account in accountCache)
            {
                XmlNode hostXmlNode = xdoc.CreateElement("account");
                hostXmlNode.SetAttributeValue("user", account.UserNameHash);
                hostXmlNode.SetAttributeValue("pwd", account.EncryptedPwd);
                root.AppendChild(hostXmlNode);
            }
            xdoc.Save(persistedStorageLocation);
        }
        #endregion

        #region Account interactions
        public void SetAccount(string username, string password)
        {
            int userNameHash = username.ToLower().GetHashCode();
            Account account = accountCache.FirstOrDefault(a => a.UserNameHash == userNameHash);
            if (account == null)
            {
                account = new Account() { UserNameHash = userNameHash };
                accountCache.Add(account);
            }
            account.EncryptedPwd = Protect(password);
        }
        public bool IsAccountPersisted(string username)
        {
            int userNameHash = username.ToLower().GetHashCode();
            Account account = accountCache.FirstOrDefault(a => a.UserNameHash == userNameHash);
            return account != null;
        }
        public bool IsAccountDecryptable(string username)
        {
            int userNameHash = username.ToLower().GetHashCode();
            Account account = accountCache.FirstOrDefault(a => a.UserNameHash == userNameHash);
            if (account != null)
            {
                try
                {
                    Unprotect(account.EncryptedPwd);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }
        public string GetAccountPassword(string username)
        {
            int userNameHash = username.ToLower().GetHashCode();
            Account account = accountCache.FirstOrDefault(a => a.UserNameHash == userNameHash);
            if (account != null)
            {
                return Unprotect(account.EncryptedPwd);
            }
            else
            {
                throw new Exception(string.Format("Specified account {0} was not found in the credential cache!", username));
            }
        }
        public void RemoveAccount(string username)
        {
            int userNameHash = username.ToLower().GetHashCode();
            Account account = accountCache.FirstOrDefault(a => a.UserNameHash == userNameHash);
            if (account != null)
            {
                accountCache.Remove(account);
            }
        }
        #endregion

        #region Encryption
        public string Protect(string data)
        {
            return Convert.ToBase64String(Protect(System.Text.UTF8Encoding.UTF8.GetBytes(data.ToCharArray())));
        }
        public byte[] Protect(byte[] data)
        {
            try
            {
                return ProtectedData.Protect(data, aditionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Data was not encrypted. An error occurred.\r\n{0}", e));
                throw;
            }
        }
        public string Unprotect(string dataB64str)
        {
            return System.Text.UTF8Encoding.UTF8.GetString(Unprotect(Convert.FromBase64String(dataB64str)));
        }
        public byte[] Unprotect(byte[] data)
        {
            try
            {
                return ProtectedData.Unprotect(data, aditionalEntropy, DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException e)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Data was not decrypted. An error occurred.\r\n{0}", e));
                throw;
            }
        }
        #endregion
    }
}
