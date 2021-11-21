using System;
using System.Collections.Generic;
using System.Text;
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
            MenuList.Add(new Menu(new List<string>() { "Create Entry", "Load Entry", "Go To Main Menu" }, Menu.MenuNames.LoginMenu));
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

                    UserAccountController.DisplayCurrentUser(1, 13);

                    KeyInfo = Console.ReadKey(true);

                    display.MenuItemSelection(CurrentMenu, KeyInfo);

                    if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        MainMenuSelectionEnter();
                        break;
                    }
                }
            }
        }

        public static void MainMenuSelectionEnter()
        {
            switch (display.GetMenuItemSelectedValue(CurrentMenu))
            {
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    Console.Clear();
                    break;
                case 1:
                    Console.Clear();
                    UserAccountController.Account.UserInputNewAccount();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    UserAccountController.Account.PrintUsers();
                    break;
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
    }
}
