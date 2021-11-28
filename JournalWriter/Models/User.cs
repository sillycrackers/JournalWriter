using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using JournalWriter;
using JournalWriter.Controllers;
using JournalWriter.Views;



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
        public double WPMRecord { get; set; } = 0;


        private byte[] _encryptedPassword;
        private byte[] _entropy = new byte[20];



        //-------Constructors-------//
        public User(string pass)
        {
            EncryptPassword(pass);
            CurrentEntry = new Entry();
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
            CurrentEntry = new Entry();
            CurrentEntry.NewEntry(Entries);
            CurrentEntry = null;
        }
        public void DisplayEntry()
        {
            Console.WriteLine("Please enter Entry number to display...");

            string input = "";

            while (true)
            {
                input = Display.ReadLineOrEscape();

                if (input == null) { return; }

                if (Display.ValidNumber(input))
                {
                    if (Convert.ToInt32(input) > Entries.Count - 1)
                    {
                        Console.WriteLine("Not that many entries, try again...");
                    }
                    else { break; }
                }
                else
                {
                    Console.WriteLine("Invalid number try again.");
                }

            }

            int inputNum = Convert.ToInt32(input);

            Console.Clear();

            Console.WriteLine(Entries[inputNum].EntryText);
        }

    }

}
