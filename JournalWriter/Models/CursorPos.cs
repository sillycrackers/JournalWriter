using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class CursorPos
    {
        public int TopPos { get; set; }
        public int LeftPos { get; set; }
        public int HomePos { get; set; }

        public CursorPos()
        {

        }
        public void MoveDown()
        {
            TopPos--;
        }
        public void MoveUp()
        {
            TopPos++;
        }

    }
}
