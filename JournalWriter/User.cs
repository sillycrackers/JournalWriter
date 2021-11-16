using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace JournalWriter
{
    [Serializable()]
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        private byte[] _encryptedPassword;
        private byte[] _entropy = new byte[20];

        public User(string pass)
        {
            EncryptPassword(pass);
        }


        private void EncryptPassword(string pass)
        {
            byte[] passwordToEncypt = Encoding.UTF8.GetBytes(pass);

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(_entropy);
            }

            _encryptedPassword = ProtectedData.Protect(passwordToEncypt, _entropy, DataProtectionScope.CurrentUser);
        }
        public string DecryptPassword()
        {
            string decryptedPassword;

            decryptedPassword = Encoding.UTF8.GetString(ProtectedData.Unprotect(_encryptedPassword, _entropy, DataProtectionScope.CurrentUser));

            return decryptedPassword;
        }

    }

}
