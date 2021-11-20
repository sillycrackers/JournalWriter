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

        public string Header { get; set; }
        public int HeaderLocation { get; set; } = 0;
        public int headerSize { get;  private set; }

        private bool hasHeader = false;



        //-------Constructors-------//

        public Display()
        {
            SetupConsoleDefaults();
        }
        public Display(string header)
        :this()
        {
            Header = header;
            hasHeader = true;
            headerSize = CalculateHeaderSize() + HeaderLocation;
        }



        //-------Methods-------//



        //-----------Action Methods-----------//
        //-----Methods that perform some sort of action------//



        private void SetupConsoleDefaults()
        {
            int windowHeight = 30;
            int windowWidth = 50;
            int bufferHeight = 30;
            int bufferWidth = 50;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(bufferWidth, bufferHeight);
            Console.SetWindowSize(windowWidth, windowHeight);


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
        public int GetMenuItemSelectedValue(Menu currentMenu)
        {
            return currentMenu.Cursor.Pos.TopPos;
        }
        private int CalculateHeaderSize()
        {
            int index = 0;
            int size = 0;

            if (hasHeader == true)
            {
                foreach (char c in Header)
                {
                    if (c == '\n')
                    {
                        size++;
                    }
                }
            }

            return size;
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
        public void MenuItemSelection(Menu currentMenu, ConsoleKeyInfo keyInfo)
        {
            currentMenu.Cursor.UpdatePosition(keyInfo);
        }



        //-----------Display Methods-----------//
        //-----Methods that just display information on Console------//


        public void DisplayMenu(Menu currentMenu)
        {
            currentMenu.DisplayMenu(HeaderLocation + headerSize);
        }
        public void DisplayUserMenuSelectionValue(Menu currentMenu)
        {
            Console.SetCursorPosition(1, headerSize + currentMenu.MenuCount + 4);

            Console.WriteLine(currentMenu.Cursor.Pos.TopPos);
        }
        public void DisplayHeader(int location)
        {
            Console.SetCursorPosition(0, location);
            Console.WriteLine(Header);
            HeaderLocation = location;
        }
    }
}
