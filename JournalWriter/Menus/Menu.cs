using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JournalWriter.Menus
{
    public class Menu
    {
        //Takes a string of selections and the number of selections and returns the number selected
        public static int Selection(string selects, int numSel)
        {
            Console.WriteLine(selects);

            while (true)
            {
                string input = Console.ReadLine();

                if (ValidSelection(input, numSel))
                {

                    return Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Invalid Selection try again.");
                }
            }
        }

        //Verifies if the user input valid number which is in the range of displayed selections
        public static bool ValidSelection(string input, int numOfSelections)
        {

            if (ValidNumber(input))
            {
                int inputNum = Convert.ToInt32(input);

                if (inputNum <= numOfSelections && inputNum > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        //Checks if the string is an integer value
        private static bool ValidNumber(string s)
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

        //Password entry displaying only ****
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

    }
}
