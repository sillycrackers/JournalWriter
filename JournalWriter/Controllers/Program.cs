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

            WPMUI wpm = new WPMUI();

            InitializeDisplay.Initialize();

            IntroAnimation.Run();

            while (true)
            {
                //wpm.test();
                DisplayController.Run();
                Console.ReadLine();
                break;
            }
        }




    }
}
