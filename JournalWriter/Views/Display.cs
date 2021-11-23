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
        public List<Page> Pages { get; set; }

        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public int BufferHeight { get; set; }
        public int BufferWidth { get; set; }

        /*
        public int windowHeight = 30;
        public int windowWidth = 50;
        public int bufferHeight = 30;
        public int bufferWidth = 50;
        */


        //-------Constructors-------//

        public Display()
        {
            SetupConsoleDefaults();
            CurrentPage = new Page("CurrentPage");
            Pages = new List<Page>();
        }



        //-------Methods-------//

        //-----------Action Methods-----------//
        //-----Methods that perform some sort of action------//



        private void SetupConsoleDefaults()
        {
           
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(BufferWidth, BufferHeight);
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.Title = "Journal Reader";
            Console.SetWindowPosition(0, 0);
            
        }

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
        public int GetMenuItemSelectedValue()
        {
            return CurrentPage.CurrentMenu.Cursor.Pos.TopPos;
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

        public void DisplayUserMenuSelectionValue()
        {
            Console.SetCursorPosition(1, headerSize + CurrentPage.CurrentMenu.MenuCount + 4);

            Console.WriteLine(CurrentPage.CurrentMenu.Cursor.Pos.TopPos);
        }

    }
}
