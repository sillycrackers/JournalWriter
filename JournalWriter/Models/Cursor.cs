using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Cursor 
    {

        //-------Properties-------//

        public char Symbol { get; private set; } = '<';
        public int CurrentSelection { get; private set; }
        public int TopPos { get; set; }
        public int LeftPos { get; set; }
        public int HomePosLeft { get; set; }
        public int HomePosTop { get; set; }

        private ConsoleKeyInfo _keyInfo;
        private List<int> _menuSizes;


        //-------Constructors-------//

        public Cursor(List<int> menuSizes)
        {
            _menuSizes = new List<int>();
            _menuSizes = menuSizes;
            
            HomePosLeft = menuSizes[0]; 
            MoveCursorToHome();

        }


        //-------Methods-------//
        public void UpdatePosition(ConsoleKeyInfo keyInfo)
        {
            _keyInfo = keyInfo; 

            Console.SetCursorPosition(LeftPos + 1, TopPos + HomePosTop);

            if (_keyInfo.Key == ConsoleKey.DownArrow)
            {
                MoveDown();
            }
            else if (_keyInfo.Key == ConsoleKey.UpArrow)
            {
                MoveUp();
            }

            MoveCursor();
        }
        public void MoveCursorToHome()
        {
            LeftPos = HomePosLeft;
            TopPos = HomePosTop;
        }
        public void MoveCursor()
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \b");
            Console.SetCursorPosition(LeftPos + 1, TopPos + HomePosTop);
            Console.Write(Symbol);
            Console.ForegroundColor = InitializeDisplay.ForegroundColor;
        }

        public void SetCursorHomeTop(int topPos)
        {
            HomePosTop = topPos;
        }
        public void MoveDown()
        {
            if (TopPos < _menuSizes.Count - 1)
            {
                TopPos++;
                LeftPos = _menuSizes[TopPos];
            }
        }
        public void MoveUp()
        {
            if (TopPos > 0)
            {
                TopPos--;
                LeftPos = _menuSizes[TopPos];
            }
        }
    }
}
