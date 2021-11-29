using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JournalWriter
{
    public static class Names
    {

        //Page Names
        public const string MainPage = "Journal Writer";
        public const string LoginPage = "Login Page";
        public const string PastEntriesPage = "Past Entries Page";
        public const string WPMPage = "WPMPage";


        //Menu names
        public const string MainMenu = "MainMenu";
        public static readonly List<string> MainMenuItems = new List<string>{
            "Login", "Create New Account", "Display Current Users", "Save and Quit" };

        public const string LoginMenu = "LoginMenu";
        public static readonly List<string> LoginMenuItems = new List<string>{
            "Write New Entry", "Display Past Entry", "Words Per Minute Test", "Reset WPM Record","Logout", "Save and Quit" };
        public const string PastEntriesMenu = "PastEntriesMenu";
        public static readonly List<string> PastEntriesMenuItems = new List<string>{"Empty"};
        public static readonly List<string> WPMMenuItems = new List<string>(){"Short Test", "Medium Test", "Long Test"};
        public const string WPMMenu = "WPMMenu";



        ////Menu Dictionaray (MenuName, MenuItems)
        //public static Dictionary<string, List<string>> MenuNames = new Dictionary<string, List<string>>();

        //static Names()
        //{
        //    MenuNames.Add(MainMenu, MainMenuItems);
        //    MenuNames.Add(LoginMenu, LoginMenuItems);
        //    MenuNames.Add(PastEntriesMenu, PastEntriesMenuItems);
        //}

    }


    
}
