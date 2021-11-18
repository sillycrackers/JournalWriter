using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Entry
    {
        public  DateTime creationDate { get; set; }
        public  string title { get; set; }

        public  StringBuilder text = new StringBuilder();

        public  void CreateEntry()
        {
            string input = "";

            Console.WriteLine("New Entry. Please type the name of the entry.");

            while (true)
            {
                input = Console.ReadLine();

                if (FileManagement.CheckForEntryFile(input))
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
        public  void WriteEntry()
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

        public  void SaveEntry()
        {
            
            FileManagement.CreateEntryFile(title, text);
            Console.Clear();
            Console.WriteLine("Entry Created");


        }




    }
}
