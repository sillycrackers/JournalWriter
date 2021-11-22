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
    [Serializable()]
    public class Entry
    {

        //-------Properties-------//
        public DateTime CreationDate { get; set; }
        public  string Title { get; set; }

        public string EntryText
        {
            get
            {
                return this._entryText.ToString();
            }
            set
            {
                this._entryText.Append(value);
            }
        }

        private StringBuilder _entryText;


        //-------Constructors-------//
        public Entry()
        {
            _entryText = new StringBuilder(2000);
        }



        //-------Methods-------//
        public void NewEntry(List<Entry> entries)
        {
            string input = "";

            Console.WriteLine("New Entry. Please type the name of the entry.");

            while (true)
            {
                input = Console.ReadLine();

                if (CheckEntryExists(input, entries))
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

            SaveEntry(entries);
        }
        private void WriteEntry()
        {
            string input = "";

            Console.WriteLine("Please create entry, type \"save\" to save and quit.");

            while (input.ToLower() != "save")
            {
                input = Console.ReadLine();

                if (input.ToLower() != "save")
                {
                    _entryText.AppendLine(input);
                }
            }
        }

        private bool CheckEntryExists(string name, List<Entry> Entries)
        {
            if(Entries.Contains(Entries.Find(x=> x.Title == name)))
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        public void SaveEntry(List<Entry> entries)
        {
            entries.Add(this);

        }

    }
}
