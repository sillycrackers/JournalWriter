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

        public static string JournalEntryMainHeader = "╔═══════════════════════════════════════════════╗\n" +
                                                      "║                                               ║\n" +
                                                      "║           Welcome To JournalWriter!           ║\n" +
                                                      "║                                               ║\n" +
                                                      "╚═══════════════════════════════════════════════╝\n\n";
        static DisplayController()
        {
            display = new Display(JournalEntryMainHeader);
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
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    if (UserAccountController.Account.loggedIn)
                    {
                        CurrentMenu = MenuList[MenuList.FindIndex(x => x.MenuName == Menu.MenuNames.LoginMenu)];
                        Console.Clear();
                        UserAccountController.DisplayCurrentUser(1, CurrentMenu.MenuCount + display.headerSize + 3);
                    }
                    break;
                case 1:
                    Console.Clear();
                    UserAccountController.Account.UserInputNewAccount();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    UserAccountController.Account.PrintUsers();
                    PressEnterTo("go back...");
                    Console.Clear();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void RunUserPage()
        {
            switch (display.GetMenuItemSelectedValue(CurrentMenu))
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        public static void DisplayContents()
        {
            display.DisplayHeader(0);
            display.DisplayMenu(CurrentMenu);
        }

        public static void PressEnterTo(string message)
        {
            Console.WriteLine("\nPress Enter to " + message);

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
            }
        }
    }
}
