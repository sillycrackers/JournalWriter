using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Menu
    {
        //-------Enums---------//
        public enum MenuNames
        {
            MainMenu = 0,
            LoginMenu = 1
        }
        //-------Properties-------//

        public static MenuNames MenuName { get; set; }
        public Cursor Cursor { get; set; }
        public List<string> Selections { get; set;}


        //-------Constructors-------//
        public Menu(ConsoleColor defaultConsoleColor, MenuNames menuName)
        {
            Selections = new List<string>() {"Empty Menu"};
            Cursor = new Cursor(CalculateMenuSize(), defaultConsoleColor);
            MenuName = menuName;
        }
        public Menu(List<string> selections, ConsoleColor defaultConsoleColor, MenuNames menuName)
            : this(defaultConsoleColor, menuName)
        {
            Selections = new List<string>(selections);
            Cursor = new Cursor(CalculateMenuSize(), defaultConsoleColor);
            MenuName = menuName;
        }

        //-------Methods-------//
        private bool ValidNumber(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            else
            {
                foreach (char c in s)
                {
                    if (c < '0' || c > '9')
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public List<int> CalculateMenuSize()
        {
            List<int> sizes = new List<int>();
            int i = 0;

            foreach (string s in Selections)
            {
                sizes.Add(s.Length + 1);
                i++;
            }
            return sizes;
        }
        public void DisplayMenu()
        {
            foreach (string s in Selections)
            {
                Console.WriteLine(" " + s);
            }

            Cursor.PrintCursor();
            Console.CursorVisible = false;
            
        }
    }
}
