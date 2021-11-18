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
        
        public enum Menus
        {
            MainMenu,
            LoginMenu
        }

        public static Menus MenuToDisplay;     
        public static Menu CurrentMenu = new Menu();
        public static Menu MainMenu = new Menu(new List<string>() {"1 - Login","2 - Create New Account","3 - Display Current Users","4 - Quit" });
        public static Menu LoginMenu = new Menu(new List<string>() { "1 - Create Entry", "2 - Load Entry", "3 - Go To Main Menu" });
        public static UI ui = new UI();

        static DisplayController()
        {
            CurrentMenu = MainMenu;
            Display.SetupConsoleDefaults();
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
