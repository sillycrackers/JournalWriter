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
        public static Menu.MenuNames MenuToDisplay { get; set; }
        public static Menu CurrentMenu {get; set;}
        public static List<Menu> MenuList { get; set; }
        public static Display display { get; set; }
        public static ConsoleKeyInfo KeyInfo { get; set; }
        public static ConsoleColor DefaultConsoleColor { get; set; } = ConsoleColor.Green;

        public static string MainHeader = "╔═══════════════════════════════════════════════╗\n" +
                                          "║                                               ║\n" +
                                          "║           Welcome To JournalWriter!           ║\n" +
                                          "║                                               ║\n" +
                                          "╚═══════════════════════════════════════════════╝\n\n";
        static DisplayController()
        {
            display = new Display(MainHeader);
            MenuList = new List<Menu>();
            MenuList.Add(new Menu(new List<string>() { "Login", "Create New Account", "Display Current Users", "Quit" }, Menu.MenuNames.MainMenu));
            MenuList.Add(new Menu(new List<string>() { "Create New Entry", "Load Past Entry", "Log Out", "Quit" }, Menu.MenuNames.LoginMenu));
            CurrentMenu = MenuList[0];
        }

    public static void Run()
        {
            while (true)
            {
                DisplayContents();

                while (true)
                {
                    display.DisplayUserMenuSelectionValue(CurrentMenu);
                    UserAccountController.DisplayCurrentUser(1, CurrentMenu.MenuCount + display.headerSize + 3);

                    KeyInfo = Console.ReadKey(true);

                    display.MenuItemSelection(CurrentMenu, KeyInfo);

                    if(KeyInfo.Key == ConsoleKey.Enter)
                    {
                        MainMenuSelectionEnter();
                        break;
                    }
                }
            }
        }

        public static void MainMenuSelectionEnter()
        {
            switch (CurrentMenu.MenuName)
            {
                case Menu.MenuNames.MainMenu:
                    RunMainPage();
                    break;
                case Menu.MenuNames.LoginMenu:
                    RunUserPage();
                    break;
            }
        }
        public static void RunMainPage()
        {
            switch (display.GetMenuItemSelectedValue(CurrentMenu))
            {
                //Login
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    if (UserAccountController.Account.loggedIn)
                    {
                        SwitchMenu(Menu.MenuNames.LoginMenu);
                        Console.Clear();
                        UserAccountController.DisplayCurrentUser(1, CurrentMenu.MenuCount + display.headerSize + 3);
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
            switch (display.GetMenuItemSelectedValue(CurrentMenu))
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

                    SwitchMenu(Menu.MenuNames.MainMenu);

                    UserAccountController.DisplayCurrentUser(1, CurrentMenu.MenuCount + display.headerSize + 3);

                    break;
                //Quit
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void DisplayContents()
        {
            display.DisplayHeader(0);
            display.DisplayMenu(CurrentMenu);
        }

        public static void SwitchMenu(Menu.MenuNames menu)
        {
            CurrentMenu = MenuList[MenuList.FindIndex(x => x.MenuName == menu)];
        }

    }
}
