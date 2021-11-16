using System;
using JournalWriter.Menus;

namespace JournalWriter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DataManagement.Initialize();

            UserAccounts.Users = DataManagement.LoadData();

            while (true)
            {
                MainMenu.Open();

                if (UserAccounts.loggedIn)
                {
                    EntryMenu.Open();
                }


            }

        }
    }
}
