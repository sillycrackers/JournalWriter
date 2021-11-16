using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace JournalWriter
{
    public class Entry
    {
        public static DateTime creationDate { get; set; }
        public static string title { get; set; }

        public static StringBuilder text = new StringBuilder();

        public static void CreateEntry()
        {
            string input = "";

            Console.WriteLine("New Entry. Please type the name of the entry.");

            while (true)
            {
                input = Console.ReadLine();

                if (DataManagement.CheckForEntry(input))
                {
                    Console.WriteLine("File already exists try another name...");
                }
                else
                {
                    break;
                }
            }

            title = input;

            WriteEntry();

            SaveEntry();
        }
        public static void WriteEntry()
        {
            string input = "";


            Console.WriteLine("Please create entry, type \"save\" to save and quit.");

            while (input.ToLower() != "save")
            {
                input = Console.ReadLine();

                if (input.ToLower() != "save")
                {
                    text.AppendLine(input);
                }

            }

        }

        public static void SaveEntry()
        {
            
            DataManagement.CreateEntry(title, text);
            Console.Clear();
            Console.WriteLine("Entry Created");


        }




    }
}
