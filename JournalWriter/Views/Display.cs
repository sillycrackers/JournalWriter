﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Views
{
    public static class Display
    {
        
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
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public static bool EscKeyPressed()
        {

            ConsoleKeyInfo key;

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                return true;
            }
            else { return false; }

        }
    }
}
