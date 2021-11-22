using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Menu : IDisplayElement
    {
        //-------Enums---------//
        public enum MenuNames
        {
            MainMenu = 0,
            LoginMenu = 1
        }
        //-------Properties-------//

        public MenuNames MenuName { get; set; }
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
                this.Height = value;
            }
        }
        public int MaxWidth {
            get
            {
                return this.CalculateMaxWidth();
            }
            set { this.MaxWidth = value; } 
        }
        public int TopPosition { get; set; } = 0;
        public int LeftPosition { get; set; } = 0;


        //-------Constructors-------//

        //Default constructor, which sets menu to Empty Menu if no menu selections are passed in
        public Menu(MenuNames menuName, int topPosition)
        {
            Selections = new List<string>() {"Empty Menu"};
            Cursor = new Cursor(CalculateMenuSize());
            MenuName = menuName;

            TopPosition = topPosition;

        }
        /*Default constructor, which recieves the list of strings of menu selections, the default 
            console font color for setting the font color back to what it was after setting cursor color,
            and the enum of menu name, so we now which menu we are working with.
        */
        public Menu(List<string> selections,MenuNames menuName, int topPosition)
            : this(menuName, topPosition)
        {
            Selections = new List<string>(selections);
            MenuCount = CalculateMenuSize().Count;
            Cursor = new Cursor(CalculateMenuSize());
        }

        public Menu(List<string> selections, MenuNames menuName, int topPosition, int leftPosition)
    : this(menuName, topPosition)
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
                if(Convert.ToInt32(s) > longest)
                {
                    longest = Convert.ToInt32(s);
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

            this.Cursor.SetCursorHomeTop(location);

            this.Cursor.MoveCursor();

            Console.CursorVisible = false;

        }

        public void Draw()
        {
            DisplayMenu(TopPosition);
        }
    }
}
