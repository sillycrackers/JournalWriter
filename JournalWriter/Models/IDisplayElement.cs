using System;
using System.Collections.Generic;
using System.Text;

namespace JournalWriter.Models
{
    public interface IDisplayElement
    {
        int Height { get; set; }
        int MaxWidth { get; set; }
        int TopPosition { get; set; }
        int LeftPosition { get; set; }

        void Draw() { }

    }
}
