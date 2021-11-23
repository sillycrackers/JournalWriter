using JournalWriter.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace JournalWriter.Views
{

    public class Page : IDrawable
    {

        public int HeaderWidth = 45;
        public List<Menu> MenuList { get; set; }
        public Menu CurrentMenu { get; set; }
        public string PageName { 
            get 
            {
                return _pageName;
            }
            set 
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
        private StringBuilder _headerBuilder;
        private int _initialBufferHeight = 0;
        private int _pageBufferHeight = 0;
        private List<IDisplayElement> _displayElements = new List<IDisplayElement>();

        //Constructor
        public Page(string pageName,int initialBufferHeight)
        {
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
        private void GenerateHeader()
        {
            _header = _pageName;
            _header = _header.PadLeft((HeaderWidth - _pageName.Length) / 2);
            _header = _header.PadRight((HeaderWidth - _pageName.Length) / 2);

            _header = "╔═══════════════════════════════════════════════╗\n" +
                      "║                                               ║\n"
                                    + "║" + _header + "║" +
                      "║                                               ║\n" +
                      "╚═══════════════════════════════════════════════╝\n\n";
        }
        private int CalculateNewBufferHeight()
        {
            int height = 0;

            foreach(IDisplayElement d in _displayElements)
            {
                height += d.Height;
            }

            return height;
        }

        public void Draw()
        {
            if(CalculateNewBufferHeight() > _initialBufferHeight)
            {
                Console.BufferHeight = CalculateNewBufferHeight();
            }

            Console.WriteLine(_header);
            CurrentMenu.TopPosition = HeaderHeight + 1;
            CurrentMenu.Draw();
        }
    }
}
