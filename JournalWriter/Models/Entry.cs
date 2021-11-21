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

        //-------Properties-------//
        public DateTime CreationDate { get; set; }
        public  string Title { get; set; }

        public  StringBuilder EntryText; 


        //-------Constructors-------//
        public Entry()
        {
            EntryText = new StringBuilder();
        }



        //-------Methods-------//
        public void CreateEntry()
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

            Title = input;

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
                    EntryText.AppendLine(input);
                }

            }

        }

        public  void SaveEntry()
        {
            
            FileManagement.CreateEntryFile(Title, EntryText);
            Console.Clear();
            Console.WriteLine("Entry Created");


        }




    }
}
