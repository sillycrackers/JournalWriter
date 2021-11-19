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
        public bool DisplayNewScreen = false;
 

        public Display()
        {
            SetupConsoleDefaults();
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

        public static void SetupConsoleDefaults()
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



        public void DisplayMenu(Menu currentMenu)
        {
            currentMenu.DisplayMenu();
        }

        public void MenuItemSelection(Menu currentMenu, ConsoleKeyInfo keyInfo)
        {
            currentMenu.Cursor.UpdatePosition(keyInfo);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                DisplayNewScreen = true;
            }
        }

        public int GetMenuItemSelected(Menu currentMenu)
        {
            return currentMenu.Cursor.Pos.TopPos;
        }
        public void DisplayUserSelectionValue(Menu currentMenu)
        {
            Console.SetCursorPosition(1, 8);

            Console.WriteLine(currentMenu.Cursor.Pos.TopPos);

            
        }
    }
}
