using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsPerMinute
{
    public class WPMUI
    {
        public double WordsPerMin { get { return _wordsPerMin; } }
        public TimeSpan TotalTimeTaken { get { return _totalTimeTaken; } }
        public string ChallengeText { get { return _challengeText; } set { _challengeText = value; } }

        private double _wordsPerMin;
        private TimeSpan _totalTimeTaken;
        private string _challengeText;
        private string _challengeText2;

        private int _challengeTextTopPos;
        private StringBuilder sb = new StringBuilder();
        private int index = 0;
        private int _inputTextTopPos;
        private string info = "Start typing to begin timer";
        private Timer timer = new Timer();

        public WPMUI()
        {
            _challengeTextTopPos = 2;
            _wordsPerMin = 0;
            _totalTimeTaken = new TimeSpan();

        }

        public void test()
        {
            Console.WriteLine(WPMParagraphs.LongParagraphs[4]);
        }
        public void StartChallenge(WPMParagraphs.WPMLengthSelect length)
        {
            Console.ForegroundColor = ConsoleColor.White;

            DisplayChallengeText(_challengeTextTopPos, length);

            WriteInstructions();

            _inputTextTopPos = Console.CursorTop;

            while (!Console.KeyAvailable) {}

            timer.StartTimer();

            while (sb.ToString() != _challengeText)
            { 
                ReadLine();
            }

            timer.StopTimer();
            _wordsPerMin = CaculateWPM();
            WriteResults();


        }
        public void WriteResults()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finished!");
            Console.WriteLine(timer.GetDuration().ToString("0.00") + " seconds");
            Console.WriteLine();
            Console.WriteLine($"You typed at a rate of {CaculateWPM().ToString("0.00")} words per minute");
        }
        public void WriteInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public void DisplayChallengeText(int position, WPMParagraphs.WPMLengthSelect length)
        {
            Console.SetCursorPosition(0, position);

            _challengeText = GenerateParagraph(length);

            Console.WriteLine(_challengeText);
        
        }
        public string GenerateParagraph(WPMParagraphs.WPMLengthSelect length)
        {
            var rand = new Random();
            
            switch (length)
            {
                case WPMParagraphs.WPMLengthSelect.Short:
                    return WPMParagraphs.ShortParagraphs[rand.Next(0, WPMParagraphs.ShortParagraphs.Count - 1)];

                case WPMParagraphs.WPMLengthSelect.Medium:
                    return WPMParagraphs.MediumParagraphs[rand.Next(0, WPMParagraphs.MediumParagraphs.Count - 1)];
                    
                case WPMParagraphs.WPMLengthSelect.Long:
                    return WPMParagraphs.LongParagraphs[rand.Next(0, WPMParagraphs.LongParagraphs.Count - 1)];
                    
            }
            return "";
        }
        public int CalculateNumWords(string inText)
        {
            string text = inText;
            char[] charArray = new char[text.Length];
            string[] strArray = new string[text.Split(' ').Count()];

            charArray = text.ToCharArray();
            strArray = text.Split(' ');

            return strArray.Length;

        }
        public void ReadLine()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            

                keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (index > 0)
                {
                    //Console.CursorLeft = index;

                    sb.Remove(index - 1, 1);
                    if(Console.CursorLeft == 0)
                    {
                        Console.CursorTop--;
                        Console.CursorLeft = Console.BufferWidth-1;
                        Console.Write(" ");
                        Console.CursorTop--;
                        Console.CursorLeft = Console.BufferWidth - 1;
                    }
                    else { Console.Write("\b \b"); }
                   

                    index--;
                }
            }
            else 
            {
                if (index < _challengeText.Length)
                {
                    index++;

                    sb.Append(keyInfo.KeyChar);

                    if (!VerifyCorrectChar())
                    {
                        if (sb[index - 1] == ' ')
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else { Console.ForegroundColor = ConsoleColor.Red; }

                    }
                    Console.Write(keyInfo.KeyChar);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
        public bool VerifyCorrectChar()
        {
            if(sb[index-1] == _challengeText[index - 1])
            {
                return true;
            }
            else { return false; }
        }
        private double CaculateWPM()
        {
            double result = (CalculateNumWords(_challengeText) / timer.GetDuration()) * 60;

            return result;
        }
    }
}
