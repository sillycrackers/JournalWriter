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

            DisplayController.MenuToDisplay = Menu.MenuNames.MainMenu;

            while (true)
            {
                DisplayController.Run();
                break;
            }
        }
    }
}
