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
    public class DataManagement
    {

        public static string RootPath = Directory.GetCurrentDirectory();
        public static string ObjectDataFolder = "ObjectData";
        public static string EntryFolder = "Entries";
        public static string EntryPath = Path.Combine(RootPath, EntryFolder);
        public static string DataPath = Path.Combine(RootPath, ObjectDataFolder, "data.bin");

        public static void SaveData(List<User> u)
        {

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, u);

            stream.Close();

            u = null;
        }
        public static List<User> LoadData()
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
        public void OpenBrowserSelectFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();

        }
        public static void Initialize()
        {
            CreateDirectory();

            if (!File.Exists(DataPath))
            {
                SaveData(UserAccounts.Users);
            }
        }

        public static void CreateEntry(string name, StringBuilder sb)
        {
            string path = Path.Combine(EntryPath, name + ".txt");

            File.WriteAllText(path, sb.ToString());

        }

        public static bool CheckForEntry(string name)
        {
            string path = Path.Combine(EntryPath, name + ".txt");

            return File.Exists(path);

        }

    }
}
