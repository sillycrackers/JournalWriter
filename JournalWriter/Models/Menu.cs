using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Menu : IDisplayElement, IDrawable
    {

        //-------Properties-------//

        public string MenuName { get; set; }
        public Cursor Cursor { get; set; }
        public List<string> Selections { get; set;}
        public int MenuCount { get; set; }

        //Display Element Props
        public int Height
        {
            get
            {
                return CalculateMenuSize().Count;
            }
            set
            {
                _height = value;
            }
        }
        public int MaxWidth {
            get
            {
                return this.CalculateMaxWidth();
            }
            set { this.MaxWidth = value; } 
        }
        public int TopPosition {
            get
            {
                return _topPosition;
            }
            set
            {
                _topPosition = value;
            } 
        }
        public int LeftPosition { get; set; } = 0;

        private int _height;
        private int _maxWidth;
        private int _topPosition;
        private int _leftPosition;


        //-------Constructors-------//

        public Menu(string menuName)
        {
            Selections = new List<string>() {"Empty Menu"};
            Cursor = new Cursor(CalculateMenuSize());
            MenuName = menuName;
            _height = CalculateMenuSize().Count;
            _maxWidth = CalculateMaxWidth();
            _topPosition = 0;

        }
        public Menu(string menuName, List<string> selections)
            : this(menuName)
        {
            Selections = new List<string>(selections);
            MenuCount = CalculateMenuSize().Count;
            Cursor = new Cursor(CalculateMenuSize());
        }
        public Menu(string menuName, List<string> selections, int leftPosition)
    : this(menuName)
        {
            Selections = new List<string>(selections);
            MenuCount = CalculateMenuSize().Count;
            Cursor = new Cursor(CalculateMenuSize());
            LeftPosition = leftPosition;
        }

        //-------Methods-------//

        //Method for calculating the size of each menu selection, in order to know where to 
        //display cursor leftPos
        public List<int> CalculateMenuSize()
        {
            List<int> sizes = new List<int>();
            int i = 0;

            foreach (string s in Selections)
            {
                sizes.Add(s.Length + 1);
                i++;
            }
            return sizes;
        }
        public int CalculateMaxWidth()
        {
            int longest = 0;

            foreach (string s in Selections)
            {
                if(s.Length > longest)
                {
                    longest = s.Length;
                }
            }

            return longest;
        }
        //Move cursor on menu
        public void MenuItemSelection(ConsoleKeyInfo keyInfo)
        {
            Cursor.UpdatePosition(keyInfo);
        }

        //Method for displaying menu in console, displays at location passed in
        //also displays cursor at first menu position
        public void DisplayMenu(int location)
        {
            Console.SetCursorPosition(0, location);

            foreach (string s in Selections)
            {
                Console.WriteLine(" " + s);
            }

            Cursor.SetCursorHomeTop(location);

            Cursor.MoveCursor();

            Console.CursorVisible = false;
        }

        public void Draw()
        {
            DisplayMenu(_topPosition);
        }
    }
}
