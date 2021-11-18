using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using JournalWriter;
using JournalWriter.Controllers;


namespace JournalWriter.Models
{
    [Serializable()]
    public class User
    {

        //-------Properties-------//
        public string Name { get; set; }
        public int Id { get; set; }

        private byte[] _encryptedPassword;
        private byte[] _entropy = new byte[20];



        //-------Constructors-------//
        public User(string pass)
        {
            EncryptPassword(pass);
        }


        //-------Methods-------//
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
