using System;
using System.Collections.Generic;
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
            SetupIntroConsole();

            int y = 7;
            int x = 18;
            int delay = 20;

            Thread.Sleep(500);

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

                    
                    if (i < x-1) { }
                }

                x--;
               
            }

            Thread.Sleep(2500);

            //Console.ReadLine();

            Console.Clear();
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void SetupIntroConsole()
        {

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(50, 30);
            Console.SetWindowSize(50, 30);
            Console.Title = "Journal Reader";
            Console.SetWindowPosition(0, 0);

        }
    }
}
