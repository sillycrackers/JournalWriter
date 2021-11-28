using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordsPerMinute
{
    public static class WPMParagraphs
    {
        public static List<string> ShortParagraphs = new List<string>();
        public static List<string> MediumParagraphs = new List<string>();
        public static List<string> LongParagraphs = new List<string>();

        public static string RootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ObjectDataFolderName = "JournalWriter\\Paragraphs";
        public static string ShortParaPath = Path.Combine(RootPath, ObjectDataFolderName, "ShortParagraphs.csv");
        public static string MediumParaPath = Path.Combine(RootPath, ObjectDataFolderName, "MediumParagraphs.csv");
        public static string LongParaPath = Path.Combine(RootPath, ObjectDataFolderName, "LongParagraphs.csv");
        public static List<string> Paths = new List<string>();

        public enum WPMLengthSelect
        {
            Short,
            Medium,
            Long
        }

        static WPMParagraphs()
        {
            Paths.Add(ShortParaPath);
            Paths.Add(MediumParaPath);
            Paths.Add(LongParaPath);

            Directory.CreateDirectory(RootPath + @"\" + ObjectDataFolderName);

            Initialize();

            LoadParagraphs();
        }

        public static void LoadParagraphs()
        {
            ShortParagraphs.AddRange(File.ReadLines(ShortParaPath));
            MediumParagraphs.AddRange(File.ReadLines(MediumParaPath));
            LongParagraphs.AddRange(File.ReadLines(LongParaPath));
        }
        public static void Initialize()
        {
            foreach(string s in Paths){

                if (!File.Exists(s))
                {
                    File.WriteAllText(s, "Empty");
                }
            }
        }
    }
}
