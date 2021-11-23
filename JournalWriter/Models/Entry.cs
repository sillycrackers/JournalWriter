﻿using System;
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
    public class Entry : IDisplayElement
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

        public int Height 
        { 
            get { return _height; }
            set 
            {
                _height = value; 
            } 
        }
        public int MaxWidth 
        { 
            get { return _maxWidth; } 
            set 
            { 
                _maxWidth = value; 
            } 
        }
        public int TopPosition 
        {
            get { return _topPosition; } 
            set 
            {
                _topPosition = value; 
            } 
        } 
        public int LeftPosition { get { return _leftPosition; } set { _leftPosition = value; } } 

        private StringBuilder _entryText;
        private int _height = 0;
        private int _maxWidth = 0;
        private int _topPosition = 0;
        private int _leftPosition = 0;


        //-------Constructors-------//
        public Entry()
        {
            _entryText = new StringBuilder();
            _entryText.Append("Empty Entry");
        }



        //-------Methods-------//
        public void NewEntry(List<Entry> entries)
        {
            _entryText.Clear();

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
        public void SaveEntry(List<Entry> entries)
        {
            entries.Add(this);


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
                    _height++;
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

    }
}
