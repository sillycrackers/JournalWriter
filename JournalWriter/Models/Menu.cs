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

        public Cursor Cursor { get; set; }

        public List<string> Selections { get; set;}

        public Menu()
        {
            Selections = new List<string>() {"Empty Menu"};
            
        }

        public Menu(List<string> selections)
        {
            Selections = new List<string>(selections);
            Cursor = new Cursor(CalculateMenuSize());
        }

        //Checks if the string is an integer value
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
                sizes.Add(s.Length);
                i++;
            }
            return sizes;
        }

        public void DisplayMenu()
        {
            foreach (string s in Selections)
            {
                Console.WriteLine(s);
            }

            Cursor.PrintCursor();
            Console.CursorVisible = false;
        }

    }
}
