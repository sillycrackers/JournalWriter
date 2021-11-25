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
            display.CurrentPage = display.Pages[0];

        }

    public static void Run()
        {
            while (true)
            {
                DrawPage();


                while (true)
                {
                    display.DisplayUserMenuSelectionValue();
                    //UserAccountController.DisplayCurrentUser(1, display.CurrentPage.CurrentMenu.MenuCount + display.CurrentPage.HeaderHeight + 3);

                    KeyInfo = Console.ReadKey(true);

                    display.CurrentPage.CurrentMenu.MenuItemSelection(KeyInfo);

                    if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        MainMenuSelectionEnter();
                        break;
                    }
                }
            }
            
        }

        public static void SetupPages()
        {
            SetupMainPage();
            SetupLoginPage();
        }
        public static void SetupMainPage()
        {
            //Setup Main page

            try
            {
                display.Pages.Add(new Page("Journal Writer", display.BufferHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }

            var MainPage = display.Pages[0];

            MainPage.MenuList.Add(new Menu("MainMenu", new List<string>() { "Login", "Create New Account", "Display Current Users", "Quit" }));
            MainPage.CurrentMenu = MainPage.MenuList[0];
            MainPage.DisplayElements.Add(MainPage.CurrentMenu);


            


        }
        public static void SetupLoginPage()
        {
            //Setup Login page

            try
            {
                display.Pages.Add(new Page("Login Page", display.BufferHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }

            var LoginPage = display.Pages[1];

            LoginPage.MenuList.Add(new Menu("LoginMenu", new List<string>() { "Write New Entry", "Display Past Entry", "Logout", "Quit" }));
            LoginPage.CurrentMenu = LoginPage.MenuList[0];
            LoginPage.DisplayElements.Add(LoginPage.CurrentMenu);

        }

        public static void SetupPastEntriesPage()
        {
            //Setup Past Entries page

            try
            {
                display.Pages.Add(new Page("Past Entries", display.BufferHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }

            var PastEntries = display.Pages[1];

            LoginPage.MenuList.Add(new Menu("LoginMenu", new List<string>() { "Write New Entry", "Display Past Entry", "Logout", "Quit" }));
            LoginPage.CurrentMenu = LoginPage.MenuList[0];
            LoginPage.DisplayElements.Add(LoginPage.CurrentMenu);

        }
        public static void DrawPage()
        {
            display.CurrentPage.DrawElements();
        }

       
        public static void MainMenuSelectionEnter()
        {
            switch (display.CurrentPage.CurrentMenu.MenuName)
            {
                case "MainMenu":
                    RunMainPage();
                    break;
                case "LoginMenu":
                    RunUserPage();
                    break;
            }
        }
        
        public static void RunMainPage()
        {
            switch (display.CurrentPage.GetMenuItemSelectedValue())
            {
                //Login
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    if (UserAccountController.Account.loggedIn)
                    {
                        display.CurrentPage = display.Pages[1];
                        Console.Clear();
                        UserAccountController.DisplayCurrentUser(1, display.CurrentPage.CurrentMenu.Height + display.CurrentPage.HeaderHeight + 3);
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
            switch (display.CurrentPage.GetMenuItemSelectedValue())
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

                    display.CurrentPage = display.Pages[0];

                    break;
                //Quit
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }


    }
}
