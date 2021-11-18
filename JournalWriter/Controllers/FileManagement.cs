using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;

namespace JournalWriter.Controllers
{
    public static class FileManagement
    {

        public static string RootPath { get; private set; } = Directory.GetCurrentDirectory();
        public static string ObjectDataFolder { get; private set; } = "ObjectData";
        public static string EntryFolder { get; private set; } = "Entries";
        public static string EntryPath { get; private set; } = Path.Combine(RootPath, EntryFolder);
        public static string DataPath { get; private set; } = Path.Combine(RootPath, ObjectDataFolder, "data.bin");

        public static void SaveUserData(List<User> u)
        {

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, u);

            stream.Close();

            u = null;
        }
        public static List<User> LoadUserData()
        {

            List<User> u = new List<User>();

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(DataPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            u = (List<User>)formatter.Deserialize(stream);

            stream.Close();

            return u;

        }
        public static void CreateDirectory()
        {

            Directory.CreateDirectory(RootPath + @"\" + ObjectDataFolder);
        }
        public static void OpenBrowserSelectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

        }
        public static void Initialize()
        {
            CreateDirectory();

            if (!File.Exists(DataPath))
            {
                //SaveData(UserAccounts.Users);
            }
        }

        public static void CreateEntryFile(string name, StringBuilder sb)
        {
            string path = Path.Combine(EntryPath, name + ".txt");

            File.WriteAllText(path, sb.ToString());

        }

        public static bool CheckForEntryFile(string name)
        {
            string path = Path.Combine(EntryPath, name + ".txt");

            return File.Exists(path);

        }

    }
}
