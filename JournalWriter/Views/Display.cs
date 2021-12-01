using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;
using JournalWriter.Models;

namespace JournalWriter.Views
{
    public class Display
    {
        //-------Properties-------//

        public Page CurrentPage { get; set; }
        public PageQueue PagesQueue { get; set; }
        public List<Page> Pages { get; set; }
        public ConsoleColor ForegroundColor { get { return _foregroundColor; } set { _foregroundColor = value; } }

        private ConsoleColor _foregroundColor;

        //-------Constructors-------//

        public Display(ConsoleColor foregroundColor)
        {
            PagesQueue = new PageQueue();
            CurrentPage = new Page("CurrentPage", foregroundColor);
            Pages = new List<Page>();
            _foregroundColor = foregroundColor;
        } 
        //-------Methods-------//
    
        //-----------Action Methods-----------//
        //-----Methods that perform some sort of action------//


        //Method for password entry displaying only ****
        public static string GetHiddenConsoleInput()
        {
            StringBuilder input = new StringBuilder();

            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    Console.Write("\b \b");
                    input.Remove(input.Length - 1, 1);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    input.Append(key.KeyChar);
                }
            }
            return input.ToString();
        }
        public static bool ValidNumber(string s)
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
        public static void PressEnterTo(string message)
        {
            Console.WriteLine("\nPress Enter to " + message);

            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
            }
        }

        // Returns null if user pressed Escape, or the contents of the line when they pressed Enter.
        // Does not accept Spaces.
        public static string ReadLineOrEscape()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            StringBuilder sb = new StringBuilder();
            int index = 0;

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return null;
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index > 0)
                    {
                        Console.CursorLeft = index - 1;

                        sb.Remove(index - 1, 1);

                        Console.Write(" \b");

                        index--;
                    }
                }
                //Makes sure value is inbetween Unicode values for symbols and letters only
                if (keyInfo.KeyChar > 32 && keyInfo.KeyChar < 127)
                {
                    index++;
                    Console.Write(keyInfo.KeyChar);
                    sb.Append(keyInfo.KeyChar);
                }
            }
            Console.Write('\n');
            return sb.ToString(); ;
        }

        //-----------Display Methods-----------//
        //-----Methods that just display information on Console------//

        //This method just display value of current item selected for debugging purposes
        public void DisplayUserMenuSelectionValue()
        {
            Console.SetCursorPosition(1, CurrentPage.HeaderHeight + CurrentPage.CurrentMenu.MenuCount + 5);

            Console.WriteLine(CurrentPage.CurrentMenu.Cursor.TopPos);
        }
        public void DisplayCurrentUser(int leftPosition, int topPosition, UserAccounts account)
        {
            Console.SetCursorPosition(leftPosition, topPosition);
            Console.WriteLine("Logged In: " + account.CurrentUser.Name);
            Console.CursorLeft = leftPosition;
            Console.WriteLine("WPM Record: " + account.CurrentUser.WPMRecord.ToString("0.0") + " WPM");

        }
        public void DisplayAllUsers(UserAccounts account)
        {
            bool skipFirst = false;

            foreach (User u in account.Users)
            {
                if (skipFirst == true)
                {
                    Console.WriteLine(u.Name);
                }
                skipFirst = true;
            }
        }

    }
}
