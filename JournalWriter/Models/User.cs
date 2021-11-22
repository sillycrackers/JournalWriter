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
        public Entry CurrentEntry { get; set; }
        public List<Entry> Entries { get; set; }



        private byte[] _encryptedPassword;
        private byte[] _entropy = new byte[20];



        //-------Constructors-------//
        public User(string pass)
        {
            EncryptPassword(pass);
            CurrentEntry = new Entry(){};
            Entries = new List<Entry>();
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

        public void NewEntry()
        {

            CurrentEntry.NewEntry(Entries);
        }

        public void DisplayFirstEntry()
        {
            if (Entries.Count == 0)
            {
                CurrentEntry.Title = "First Entry";
                CurrentEntry.EntryText = "First Entry Default Text";
                Entries.Add(CurrentEntry);
            }
            Console.WriteLine(Entries[0].EntryText);
        }

    }

}
