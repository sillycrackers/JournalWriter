using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;


namespace JournalWriter.Controllers
{
    public static class DisplayController
    {
        public static Display display { get; set; }
        public static ConsoleKeyInfo KeyInfo { get; set; }

        static DisplayController()
        {
            display = new Display();
            SetupPages();

        }

    public static void Run()
        {
            DrawPages();
            Console.ReadLine();
            while (true)
            {
                /*
                while (true)
                {
                    //display.DisplayUserMenuSelectionValue();
                    //UserAccountController.DisplayCurrentUser(1, display.CurrentPage.CurrentMenu.MenuCount + display.CurrentPage.HeaderHeight + 3);

                    KeyInfo = Console.ReadKey(true);

                    display.CurrentPage.CurrentMenu.MenuItemSelection(KeyInfo);

                    if(KeyInfo.Key == ConsoleKey.Enter)
                    {
                        MainMenuSelectionEnter();
                        break;
                    }
                }
                */
            }
        }

        public static void SetupPages()
        {

            SetupMainPage();
        }

        public static void SetupMainPage()
        {
            //Setup Main page
            display.Pages.Add(new Page("MainPage", display.BufferHeight));

            var MainPage = display.Pages[0];

            MainPage.MenuList.Add(new Menu("MainMenu", new List<string>() { "Login", "Create New Account", "Display Current Users", "Quit" }));
            MainPage.CurrentMenu = MainPage.MenuList[0];
            MainPage.DisplayElements.Add(MainPage.CurrentMenu);


            display.CurrentPage = display.Pages[0];

            //var MainMenu = MainPage.MenuList[0];

        }
        public static void DrawPages()
        {
            display.CurrentPage.DrawElements();
        }

        /*
        public static void MainMenuSelectionEnter()
        {
            switch (display.CurrentPage.CurrentMenu.MenuName)
            {
                case Menu.MenuNames.MainMenu:
                    RunMainPage();
                    break;
                case Menu.MenuNames.LoginMenu:
                    RunUserPage();
                    break;
            }
        }
        */
        public static void RunMainPage()
        {
            switch (display.GetMenuItemSelectedValue())
            {
                //Login
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    if (UserAccountController.Account.loggedIn)
                    {
                        //SwitchMenu(Menu.MenuNames.LoginMenu);
                        Console.Clear();
                        //UserAccountController.DisplayCurrentUser(1, display.CurrentPage.CurrentMenu.Height + display.headerSize + 3);
                    }
                    break;
                //Create new account
                case 1:
                    Console.Clear();
                    UserAccountController.Account.UserInputNewAccount();
                    Console.Clear();
                    break;
                //Display current users
                case 2:
                    Console.Clear();
                    UserAccountController.Account.PrintUsers();
                    Display.PressEnterTo("go back...");
                    Console.Clear();
                    break;
                //Exit application
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void RunUserPage()
        {
            switch (display.GetMenuItemSelectedValue())
            {
                //Write New Entry
                case 0:
                    Console.Clear();
                    UserAccountController.Account.CurrentUser.NewEntry();
                    FileManagement.SaveUserData(UserAccountController.Account.Users);
                    Console.Clear();
                    break;
                //Load Past Entry
                case 1:
                    Console.Clear();
                    UserAccountController.Account.CurrentUser.DisplayEntry();
                    Display.PressEnterTo("go back...");
                    Console.Clear();
                    break;
                //Logout
                case 2:
                    Console.Clear();

                    UserAccountController.Account.CurrentUser = UserAccountController.Account.DefaultUser;

                    UserAccountController.Account.loggedIn = false;

                    //SwitchMenu(Menu.MenuNames.MainMenu);

                    //UserAccountController.DisplayCurrentUser(1, CurrentMenu.MenuCount + display.headerSize + 3);

                    break;
                //Quit
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }


    }
}
