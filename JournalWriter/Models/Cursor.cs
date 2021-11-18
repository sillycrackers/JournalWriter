using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class Cursor 
    {
        public char Symbol { get; private set; } = '<';

        public CursorPos pos;

        public List<int> menuSizes;

        private ConsoleKeyInfo keyInfo;


        public Cursor(List<int> _menuSizes)
        {
            pos = new CursorPos(_menuSizes);
            MoveCursorToHome();
                       
        }

        public void UpdatePosition()
        {
            keyInfo = Console.ReadKey(true);
            
            if(keyInfo.Key == ConsoleKey.DownArrow)
            {
                pos.MoveDown();
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                pos.MoveUp();
            }

            PrintCursor();
        }

        public void MoveCursorToHome()
        {
            pos.LeftPos = pos.HomePos;
        }

        public void PrintCursor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\b \b");
            Console.SetCursorPosition(pos.LeftPos, pos.TopPos);
            Console.Write(Symbol);
            Console.ForegroundColor = ConsoleColor.Green;

        }
        
    }
}
