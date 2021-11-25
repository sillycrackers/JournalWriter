using System;
using System.Collections.Generic;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;

namespace JournalWriter.Controllers
{
    class Program
    {
      

        [STAThread]
        static void Main(string[] args)
        {
            //Console.WriteLine("HI world");
            while (true)
            {
                DisplayController.Run();
                break;
            }
        }
    }
}
