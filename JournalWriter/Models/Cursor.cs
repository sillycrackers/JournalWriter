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

        private ConsoleKeyInfo keyInfo;

        public Cursor()
        {
            pos = new CursorPos();
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
        }

        public List<int> CalculateMenuSize(List<string> selections)
        {
            List<int> sizes = new List<int>();
            int i = 0;

            foreach (string s in selections)
            {
                sizes.Add(s.Length);
                Console.WriteLine(sizes[i]);
                i++;
            }
            return sizes;
        }
    }
}
