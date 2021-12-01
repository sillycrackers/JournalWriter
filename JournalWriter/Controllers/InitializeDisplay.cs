using System;
using System.Collections.Generic;
using System.Management;
using System.Text;
using System.Windows;

namespace JournalWriter.Controllers
{
    public static class InitializeDisplay
    {
        public static ConsoleColor ForegroundColor { get; set; } = ConsoleColor.Green;

        public static void Initialize()
        {
            const int fontRatio = 49;
            const float windowHeightRatio = 0.66f;
            //0.34 seems to work best for width
            const float windowWidthRatio = 0.34f;

            int consoleMaxWidth = Console.LargestWindowWidth;
            int consoleMaxHeight = Console.LargestWindowHeight;
            int resolutionHeight = GetResolutionHeight();
            short fontSize = (short)(resolutionHeight / fontRatio);
            int windowHeight = (int)(consoleMaxHeight * windowHeightRatio);
            int windowWidth = (int)(consoleMaxWidth * windowWidthRatio);



            Console.ForegroundColor = ForegroundColor;
            
            Console.SetWindowSize(windowWidth, windowHeight);
            Console.SetBufferSize(windowWidth, windowHeight);

            //Set font size
            ConsoleHelper.SetCurrentFont("Lucida Console", fontSize);

        }
        public static int GetResolutionHeight()
        {
            int height = 0;
            ManagementObjectSearcher mydisplayResolution = new ManagementObjectSearcher("SELECT CurrentVerticalResolution FROM Win32_VideoController");
            
            
            foreach (ManagementObject record in mydisplayResolution.Get())
            {

                if (record != null)
                {
                    height = Convert.ToInt32(record["CurrentVerticalResolution"]);
                }
            }

            return height;
        }

    }
}
