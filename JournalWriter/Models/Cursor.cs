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
        public CursorPos Pos { get; private set; }
        public List<int> MenuSizes { get; private set; }

        private ConsoleKeyInfo _keyInfo;


        //-------Constructors-------//

        public Cursor(List<int> menuSizes)
        {
            Pos = new CursorPos(menuSizes);
            MoveCursorToHome();

        }


        //-------Methods-------//
        public void UpdatePosition(ConsoleKeyInfo keyInfo)
        {
            _keyInfo = keyInfo; 

            Console.SetCursorPosition(Pos.LeftPos, Pos.TopPos + Pos.HomePosTop);

            int x = 0;

            if (_keyInfo.Key == ConsoleKey.DownArrow)
            {
                Pos.MoveDown();
            }
            else if (_keyInfo.Key == ConsoleKey.UpArrow)
            {
                Pos.MoveUp();
            }

            MoveCursor();
        }
        public void MoveCursorToHome()
        {
            Pos.LeftPos = Pos.HomePosLeft;
            Pos.TopPos = Pos.HomePosTop;
            
        }
        public void MoveCursor()
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \b");
            Console.SetCursorPosition(Pos.LeftPos, Pos.TopPos + Pos.HomePosTop);
            Console.Write(Symbol);
            Console.ResetColor();
        }
        public void DisplayCursorAtHome()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Pos.HomePosLeft, Pos.HomePosTop);
            Console.Write(Symbol);
            Console.ResetColor();
        }

        public void SetCursorHomeTop(int topPos)
        {
            Pos.HomePosTop = topPos;

        }
    }
}
