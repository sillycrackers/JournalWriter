using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class CursorPos
    {
        public int TopPos { get; set; } = 0;
        public int LeftPos { get; set; }
        public int HomePos { get; set; }

        public List<int> MenuSizes;

        public CursorPos(List<int> _menuSizes)
        {
            MenuSizes = new List<int>(_menuSizes);
            HomePos = MenuSizes[0];
        }
        public void MoveDown()
        {
            if (TopPos < MenuSizes.Count - 1)
            {
                TopPos++;
                LeftPos = MenuSizes[TopPos];
            }
        }
        public void MoveUp()
        {
            if (TopPos > 0)
            {
                TopPos--;
                LeftPos = MenuSizes[TopPos];
            }
        }

    }
}
