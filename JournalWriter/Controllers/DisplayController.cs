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

        static DisplayController()
        {
            display = new Display();
            MenuList = new List<Menu>();
            MenuList.Add(new Menu(new List<string>() { "Login", "Create New Account", "Display Current Users", "Quit" }, DefaultConsoleColor, Menu.MenuNames.MainMenu));
            MenuList.Add(new Menu(new List<string>() { "Create Entry", "Load Entry", "Go To Main Menu" }, DefaultConsoleColor, Menu.MenuNames.LoginMenu));
            CurrentMenu = MenuList[0];
        }

    public static void Run()
        {
            display.DisplayMenu(CurrentMenu);

            while (true)
            {

                display.DisplayUserSelectionValue(CurrentMenu);

                KeyInfo = Console.ReadKey(true);

                if (display.DisplayNewScreen == true)
                {
                    CurrentMenu = MenuList[display.GetMenuItemSelected(CurrentMenu)];
                    Console.Clear();
                    display.DisplayMenu(CurrentMenu);
                    display.DisplayNewScreen = false;
                }
                display.MenuItemSelection(CurrentMenu, KeyInfo);

            }
        }
    }
}
