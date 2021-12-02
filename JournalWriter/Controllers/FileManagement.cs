using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;

namespace JournalWriter.Controllers
{
    public static class FileManagement
    {
        //-------Properties-------//
        public static string RootPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ObjectDataFolderName { get; private set; } = "Westerveld Apps\\Journal Writer\\ObjectData";
        public static string DataPath { get; private set; } = Path.Combine(RootPath, ObjectDataFolderName, "data.bin");

        //-------Methods-------//

        public static void SaveUserData(List<User> users)
        {

            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(DataPath, FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, users);

            stream.Close();

            users = null;
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

            Directory.CreateDirectory(RootPath + @"\" + ObjectDataFolderName);
        }
        public static void Initialize(List<User> users)
        {
            CreateDirectory();

            if (!File.Exists(DataPath))
            {
                SaveUserData(users);
            }
        }

    }
}
