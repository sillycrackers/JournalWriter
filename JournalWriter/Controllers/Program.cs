using System;
using System.Collections.Generic;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;
using WordsPerMinute;

namespace JournalWriter.Controllers
{
    class Program
    {
      
        [STAThread]
        static void Main(string[] args)
        {
            ConsoleHelper.SetCurrentFont("Lucida Console", 36);

            IntroAnimation.Run();

            while (true)
            {
                //test();
                DisplayController.Run();
                Console.ReadLine();
                break;
            }
        }




    }
}
