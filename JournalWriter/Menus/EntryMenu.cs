using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;

namespace JournalWriter.Menus
{
    public class EntryMenu : Menu
    {
        public static void Open()
        {
            bool quit = false;
            int selectedNum;

            while (quit != true)
            {
                WelcomeMessage();

                selectedNum = Selection(Selections.AccountMenu, 3);

                switch (selectedNum)
                {
                    case 1:
                        Console.Clear();
                        Entry.CreateEntry();
                        
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Option not available yet!");
                        break;
                    case 3:
                        
                        quit = true;
                        break;


                }

            }
        }
        private static void WelcomeMessage()
        {
            string welcomeMessage = "\n" + $"!-----------Hi {UserAccounts.CurrentUser.Name} !---------!\n" + "\n";

            Console.WriteLine(welcomeMessage);

        }

    }
}
