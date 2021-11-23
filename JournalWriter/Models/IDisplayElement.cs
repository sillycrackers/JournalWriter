using System;
using System.Collections.Generic;
using System.Text;

namespace JournalWriter.Models
{
    public interface IDisplayElement
    {
        int Height { get; }
        int MaxWidth { get; }
        int TopPosition { get; }
        int LeftPosition { get; }

        void Draw() 
        { 

        }

    }
}
