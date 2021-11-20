﻿using System;
using System.Collections.Generic;
using System.Text;
using JournalWriter;
using JournalWriter.Controllers;

namespace JournalWriter.Models
{
    public class CursorPos
    {

        //-------Properties-------//
        public int TopPos { get; set; }
        public int LeftPos { get; set; }
        public int HomePosLeft { get; set; }
        public int HomePosTop { get; set; }

        private List<int> _menuSizes;


        //-------Constructors-------//
        public CursorPos(List<int> menuSizes)
        {
            this._menuSizes = new List<int>(menuSizes);
            HomePosLeft = _menuSizes[0];
        }



        //-------Methods-------//
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
