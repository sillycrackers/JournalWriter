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
            Menu menu = new Menu(_menu.Selections);

            ConsoleKeyInfo key = new ConsoleKeyInfo();

            List<int> menuSizes = new List<int>(_menu.CalculateMenuSize());

            while (true)
            {
                menu.cursor.UpdatePosition();
            }
        }
    }
}
