using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsPerMin
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

            _challengeText = "This is a test";

            _challengeText2 = "This is the first challenge. I would like you to type " + 
                            "out these words. This will be fun just type them okay?";
        }

        public void StartChallenge()
        {
            
            SetupColors();

            WriteInstructions();

            _inputTextTopPos = Console.CursorTop;

            while (!Console.KeyAvailable) { }

            timer.StartTimer();

            while (sb.ToString() != _challengeText)
            { 
                ReadLine();
            }

            timer.StopTimer();
            _wordsPerMin = CaculateWPM();
            WriteResults();

            Console.ReadLine();

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
            DisplayChallengeText(_challengeTextTopPos);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(info);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public void SetupColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void DisplayChallengeText(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine(ChallengeText);
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
                index++;

                sb.Append(keyInfo.KeyChar);

                if (!VerifyCorrectChar())
                {
                    if(sb[index-1] == ' ')
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
