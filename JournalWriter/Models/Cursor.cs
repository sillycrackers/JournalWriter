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
        public CursorPos LastPos { get; private set; }
        public List<int> MenuSizes { get; private set; }

        private ConsoleKeyInfo _keyInfo;
        private ConsoleColor _defaultConsoleColor;


        //-------Constructors-------//

        public Cursor(List<int> menuSizes, ConsoleColor defaultConsoleColor)
        {
            Pos = new CursorPos(menuSizes);
            LastPos = new CursorPos(menuSizes);

            _defaultConsoleColor = defaultConsoleColor;
            MoveCursorToHome();
        }


        //-------Methods-------//
        public void UpdatePosition(ConsoleKeyInfo keyInfo)
        {
            _keyInfo = keyInfo; 


            Console.SetCursorPosition(Pos.LeftPos , Pos.TopPos);

            if (_keyInfo.Key == ConsoleKey.DownArrow)
            {
                Pos.MoveDown();
            }
            else if (_keyInfo.Key == ConsoleKey.UpArrow)
            {
                Pos.MoveUp();
            }

            PrintCursor();
        }
        public void MoveCursorToHome()
        {
            Pos.LeftPos = Pos.HomePos;
        }

        public void PrintCursor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \b");
            Console.SetCursorPosition(Pos.LeftPos, Pos.TopPos);
            Console.Write(Symbol);
            Console.ForegroundColor = _defaultConsoleColor;
        }
    }
}
