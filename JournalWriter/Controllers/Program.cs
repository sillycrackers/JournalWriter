using System;
using System.Collections.Generic;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;

namespace JournalWriter.Controllers
{
    class Program
    {
      

        [STAThread]
        static void Main(string[] args)
        {

            DisplayController.MenuToDisplay = DisplayController.Menus.MainMenu;

            while (true)
            {
                DisplayController.DisplayMenu();
                break;
            }
        }
    }
}
