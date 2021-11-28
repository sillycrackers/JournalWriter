using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JournalWriter.Structs
{
    public struct MenuNames
    {
        public const string MainMenu = "MainMenu";

        public static readonly IList<string> MainMenuItems = new ReadOnlyCollection<string>(new List<string> {
            "Login", "Create New Account", "Display Current Users", "Save and Quit" });

        public const string LoginMenu = "LoginMenu";

        public static readonly IList<string> LoginMenuItems = new ReadOnlyCollection<string>(new List<string> {
            "Write New Entry", "Display Past Entry", "Words Per Minute Test", "Reset WPM Record","Logout", "Save and Quit" });

        public const string PastEntriesMenu = "PastEntriesMenu";

        public static readonly IList<string> WPMMenuItems = new ReadOnlyCollection<string>(new List<string> {
            "Short Test", "Medium Test", "Long Test"});

        public const string WPMMenu = "PastEntriesMenu";

    }
}
