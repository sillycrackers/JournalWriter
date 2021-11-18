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
        

        public static Menu.MenuNames MenuToDisplay;
        public static Menu CurrentMenu;
        public static List<Menu> MenuList;
        public static UI ui = new UI();
        public static ConsoleColor DefaultConsoleColor { get; set; } = ConsoleColor.Green;

        static DisplayController()
        {
            MenuList = new List<Menu>();
            Display.SetupConsoleDefaults();
            MenuList.Add(new Menu(new List<string>() { "Login", "Create New Account", "Display Current Users", "Quit" }, DefaultConsoleColor, Menu.MenuNames.MainMenu));
            MenuList.Add(new Menu(new List<string>() { "Create Entry", "Load Entry", "Go To Main Menu" }, DefaultConsoleColor, Menu.MenuNames.MainMenu));
            CurrentMenu = MenuList[0];
        }
        public static void DisplayMenu()
        {
            CurrentMenu.DisplayMenu();
            ui.UserMenuSelection(CurrentMenu);

        }

        public static void GetUserSelection()
        {
            ui.UserMenuSelection(CurrentMenu);
        }

    }
}
