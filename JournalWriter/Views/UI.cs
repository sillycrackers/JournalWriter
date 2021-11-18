using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;
using JournalWriter.Models;



namespace JournalWriter.Views
{
    public class UI
    {
        public void UserMenuSelection(Menu _menu)
        {

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (true)
            {
                DisplayController.CurrentMenu.Cursor.UpdatePosition();
            }
        }
    }
}
