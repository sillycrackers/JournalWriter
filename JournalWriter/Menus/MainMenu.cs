using System;
using System.Collections.Generic;
using System.Text;

namespace JournalWriter.Menus
{
    public class MainMenu : Menu
    {

        public static void Open()
        {
            bool quit = false;
            int selectedNum;

            while (quit != true)
            {
                WelcomeMessage();

                selectedNum = Selection(Selections.MainMenu, 4);

                switch (selectedNum)
                {
                    case 1:
                        Console.Clear();
                        UserAccounts.Login();
                        Console.Clear();
                        quit = true;
                        break;
                    case 2:
                        Console.Clear();
                        UserAccounts.UserInputNewAccount();
                        break;
                    case 3:
                        DataManagement.SaveData(UserAccounts.Users);
                        UserAccounts.loggedIn = false;
                        quit = true;
                        break;
                    case 4:
                        Console.Clear();
                        UserAccounts.PrintUsers();
                        break;
                        
                }

            }
        }

        private static void WelcomeMessage()
        {
            string welcomeMessage = " _________________________________________________ \n" +
                                    "!                                                 !\n" +
                                    "!-----------Welcome To Journal Writer-------------!\n" +
                                    "!_________________________________________________!\n";

            Console.WriteLine(welcomeMessage);

        }



    }
}
