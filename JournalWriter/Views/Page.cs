using JournalWriter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace JournalWriter.Views
{

    public class Page
    {

        public int HeaderWidth = 46;
        public List<Menu> MenuList { get; set; }
        public Menu CurrentMenu { get; set; }
        public List<IDisplayElement> DisplayElements{ get; set; }
        public string PageName { 
            get 
            {
                return _pageName;
            }
            private set 
            {
                if(value.Length > HeaderWidth)
                {
                    throw new ArgumentOutOfRangeException("Value must be less than " + HeaderWidth);
                }
                else
                {
                    _pageName = value;
                }
            }
        }
        public int HeaderHeight;

        private string _pageName;
        private string _header;
        private string _headerSubstring1;
        private string _headerSubstring2;
        private StringBuilder _headerBuilder;
        private int _initialBufferHeight = 0;
        private int _pageBufferHeight = 0;


        //Constructor
        public Page(string pageName,int initialBufferHeight)
        {
            DisplayElements = new List<IDisplayElement>();

            CurrentMenu = new Menu("Default Menu");
            MenuList = new List<Menu>();
            _initialBufferHeight = initialBufferHeight;
            PageName = pageName;
            GenerateHeader();
            HeaderHeight = CalculateHeaderSize();

        }

        //Methods
        
        private int CalculateHeaderSize()
        {
            int index = 0;
            int size = 0;

                foreach (char c in _header)
                {
                    if (c == '\n')
                    {
                        size++;
                    }
                }
            return size;
        }
        public int GetMenuItemSelectedValue()
        {
            return CurrentMenu.Cursor.TopPos;
        }

        private void GenerateHeader()
        {
            _header = _pageName;
            int originalLength = _header.Length;
            int leftPadNum = (HeaderWidth / 2) + originalLength / 2;

            _header = _header.PadLeft(leftPadNum);
            _header = _header.PadRight(HeaderWidth);

            _header = "╔══════════════════════════════════════════════╗\n" +
                      "║                                              ║\n"
                                    + "║" + _header + "║\n" +
                      "║                                              ║\n" +
                      "╚══════════════════════════════════════════════╝\n\n";
        }
        private int CalculateNewBufferHeight()
        {
            int height = 0;

            foreach(IDisplayElement d in DisplayElements)
            {
                height += d.Height;
            }

            return height;
        }

        public void DrawElements()
        {
            if(CalculateNewBufferHeight() > _initialBufferHeight)
            {
                Console.BufferHeight = CalculateNewBufferHeight();
            }

            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(_header);

            Console.ResetColor();

            DisplayElements[0].TopPosition = HeaderHeight + 1;

            foreach (IDrawable d in DisplayElements)
            {
                d.Draw();
            }
        }
    }
}
