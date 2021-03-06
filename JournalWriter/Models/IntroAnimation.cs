using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Threading;
using JournalWriter.Views;


namespace JournalWriter.Models
{
    public static class IntroAnimation
    {
        

        public static string[] IntroLogo = new string[]
            {"    ____                             ",
            "   /    /| _________________________ ",
            "  /    // /|                       /|",
            " (====|/ //  Journal     _QP_     / | ",
            "  (=====|/      Writer  (  ' )   / .|",
            " (====|/                "+ @" \"+"__/   / /||",
            "/______________________________/ / ||",
            "|  __________________________  ||  ||",
            "| ||                         | ||    ",
            "| ||                         | ||    ",
            "| |                          | |     ",};

        public static void Run()
        {
            Console.CursorVisible = false;

            int y = 7;
            int x = 18;
            int delay = 17;

            Thread.Sleep(250);

            for (int z=IntroLogo.Length-1; z > -1 ;z--)
            {
                
                for(int i = 0; i < x; i++)
                {
                    
                    Console.SetCursorPosition(y,i);
                    Console.Write(IntroLogo[z]);
                    Thread.Sleep(delay);
                    if (i > 1)
                    {
                        Console.SetCursorPosition(y, i - 1);
                    }
                    ClearCurrentConsoleLine();
                    Thread.Sleep(2);


                    if (i < x-1) { }
                }
                

                x--;
               
            }

            Thread.Sleep(1500);

            Console.Clear();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


    }
}
