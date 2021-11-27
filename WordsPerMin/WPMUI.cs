using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsPerMin
{
    public class WPMUI
    {
        public void DisplayTextChallenge(string inText)
        {
            string text = inText;
            char[] charArray = new char[text.Length];
            string[] strArray = new string[text.Split(' ').Count()];

            charArray = text.ToCharArray();
            strArray = text.Split(' ');



        }
        public string ReadLine()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            StringBuilder sb = new StringBuilder();
            int index = 0;

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return null;
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index > 0)
                    {
                        Console.CursorLeft = index - 1;

                        sb.Remove(index - 1, 1);

                        Console.Write(" \b");

                        index--;
                    }
                }
                //Makes sure value is inbetween Unicode values for symbols and letters only
                if (keyInfo.KeyChar > 31 && keyInfo.KeyChar < 127)
                {
                    index++;
                    Console.Write(keyInfo.KeyChar);
                    sb.Append(keyInfo.KeyChar);
                }
            }
            Console.Write('\n');
            return sb.ToString(); ;
        }

    }
}
