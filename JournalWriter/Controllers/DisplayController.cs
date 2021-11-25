using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;
using JournalWriter.Structs;


namespace JournalWriter.Controllers
{
    public static class DisplayController
    {
        public static Display display { get; set; }
        public static ConsoleKeyInfo KeyInfo { get; set; }
        public static PageNames pageNames { get; set; }
        public static MenuNames menuNames { get; set; }

        static DisplayController()
        {

            SetupPageNames();
            SetupMenuNames();


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
                    UserAccountController.DisplayCurrentUser(1, display.CurrentPage.CurrentMenu.MenuCount + display.CurrentPage.HeaderHeight + 3);

                    KeyInfo = Console.ReadKey(true);

                    display.CurrentPage.CurrentMenu.MenuItemSelection(KeyInfo);

                    if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        display.PreviousPage = display.CurrentPage;
                        MenuSelectionEnter();
                        break;
                    }else if(KeyInfo.Key == ConsoleKey.Escape)
                    {
                        if(display.CurrentPage != display.Pages[display.Pages.FindIndex(x => x.PageName == pageNames.MainPage)])
                        Console.Clear();
                        display.CurrentPage = display.PreviousPage;
                        break;
                    }
                }
            }
            
        }


        //-----------Setup Pages and Menus---------------//
        private static void SetupPageNames()
        {
            pageNames = new PageNames()
            {
                MainPage = "Journal Writer",
                LoginPage = "Login Page",
                PastEntriesPage = "Past Entries"
            };
        }
        private static void SetupMenuNames()
        {
            menuNames = new MenuNames()
            {
                MainMenu = "MainMenu",
                LoginMenu = "LoginMenu",
                PastEntriesMenu = "PastEntriesMenu"
            };
        }
        public static void SetupPages()
        {
            SetupMainPage();
            SetupLoginPage();
            SetupPastEntriesPage();
        }
        public static void SetupMainPage()
        {
            //Setup Main page

            try
            {
                display.Pages.Add(new Page(pageNames.MainPage, display.BufferHeight));
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
                display.Pages.Add(new Page(pageNames.PastEntriesPage, display.BufferHeight));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }
        }
        public static void SetupPastEntriesMenu()
        {
            var PastEntries = display.Pages[2];

            PastEntries.MenuList.Add(new Menu("PastEntriesMenu", PopulatePastEntriesMenu(PastEntries)));

            PastEntries.CurrentMenu = PastEntries.MenuList[0];

            PastEntries.DisplayElements.Add(PastEntries.CurrentMenu);

            
        }
        public static List<string> PopulatePastEntriesMenu(Page pastEntries)
        {
            List<string> s = new List<string>();

            foreach (Entry e in UserAccountController.Account.CurrentUser.Entries)
            {
                s.Add(e.Title);
            }
            return s;
        }

        //Draw out all elements of that page
        public static void DrawPage()
        {
            display.CurrentPage.DrawElements();
        }
        public static void MenuSelectionEnter()
        {
            switch (display.CurrentPage.CurrentMenu.MenuName)
            {
                case "MainMenu":
                    RunMainPage();
                    break;
                case "LoginMenu":
                    RunUserPage();
                    break;
                case "PastEntriesMenu":
                    RunPastEntriesPage();
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

                    if(UserAccountController.Account.CurrentUser.Entries.Count == 0)
                    {
                        Console.WriteLine("You have no entries yet.");
                    }
                    else
                    {
                        SetupPastEntriesMenu();
                        display.CurrentPage = display.Pages[display.Pages.FindIndex(x=> x.PageName == "Past Entries")];
                        break;
                    }

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
        public static void RunPastEntriesPage()
        {
            Console.Clear();

            int selectedValue;

            selectedValue = display.CurrentPage.GetMenuItemSelectedValue();

            UserAccountController.Account.CurrentUser.Entries[selectedValue].Draw();

            Display.PressEnterTo("go back...");

            Console.Clear();
        }
    }
}
