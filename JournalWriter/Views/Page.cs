using JournalWriter.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace JournalWriter.Views
{

    public class Page
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
            }
        }



        private string _pageName;
        private string _header;
        private StringBuilder _headerBuilder;



        //Constructor
        public Page(string pageName)
        {
            PageName = pageName;
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

            _header.PadLeft((HeaderWidth - PageName.Length) / 2);
            _header.PadRight((HeaderWidth - PageName.Length) / 2);

            _header = "╔═══════════════════════════════════════════════╗\n" +
                      "║                                               ║\n"
                                    + "║" + _header + "║" +
                      "║                                               ║\n" +
                      "╚═══════════════════════════════════════════════╝\n\n";
        }

    }
}
