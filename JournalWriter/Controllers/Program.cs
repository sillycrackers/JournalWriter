using System;
using System.Collections.Generic;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;
using WordsPerMin;

namespace JournalWriter.Controllers
{
    class Program
    {
      
        

        [STAThread]
        static void Main(string[] args)
        {
            WPMUI wpm = new WPMUI();

            //IntroAnimation.Run();

            while (true)
            {

                wpm.StartChallenge();
                //DisplayController.Run();
                Console.ReadLine();
                break;
            }
        }


    }
}
