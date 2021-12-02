using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using JournalWriter;
using JournalWriter.Controllers;


namespace JournalWriter.Models
{
    [Serializable()]
    public class Entry : IDisplayElement, IDrawable
    {

        //-------Properties-------//
        public DateTime CreationDate { get; set; }
        public  string Title { get; set; }
        public string EntryText
        {
            get
            {
                return _entryText.ToString();
            }
            set{}
        }

        public int Height 
        { 
            get { return CalculateHeight(); }
            set{ Height = value; } 
        }
        public int MaxWidth 
        { 
            get { return _maxWidth; } 
            set{} 
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
            Console.CursorVisible = true;

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

            CreationDate = DateTime.Now;

            SaveEntry(entries);

          }
        public void SaveEntry(List<Entry> entries)
        {
            entries.Add(this);
        }
        private void WriteEntry()
        {
            string input = "";
            int bufferHeight = Console.BufferHeight;

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
        private int CalculateHeight()
        {
            int newHeight = 0;
            int bufferWidth = Console.BufferWidth;
            int entryLength = _entryText.ToString().Length;

            if (bufferWidth > 0)
            {
                newHeight = entryLength / bufferWidth;
            }

            return newHeight;
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

        public void Draw()
        {
            if (Height > Console.BufferHeight)
            {
                Console.BufferHeight = Height + 3;
            }
            Console.WriteLine(_entryText);
        }


    }
}
