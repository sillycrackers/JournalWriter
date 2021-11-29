using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;
using WordsPerMinute;


namespace JournalWriter.Controllers
{
    public static class DisplayController
    {
        public static Display display;
        public static ConsoleKeyInfo KeyInfo;
        
        static DisplayController()
        {

            display = new Display();
            SetupPages();
            display.CurrentPage = display.Pages[0];
        }

    public static void Run()
        {
            while (true)
            {
                //Will display new page based on new selection
                DrawPage();

                //Loop once everytime key is pressed
                while (true)
                {
                    
                    //Display selected value
                    display.DisplayUserMenuSelectionValue();

                    KeyInfo = Console.ReadKey(true);

                    //Move cursor
                    display.CurrentPage.CurrentMenu.MenuItemSelection(KeyInfo);

                    if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        if (display.CurrentPage != display.PagesQueue.GetTop())
                        {
                            display.PagesQueue.Push(display.CurrentPage);
                        }

                        //After selecting item on menu run a program
                        MenuSelectionEnter();

                        break;
                    }else if(KeyInfo.Key == ConsoleKey.Escape)
                    {
                        if (display.CurrentPage != display.Pages[display.Pages.FindIndex(x => x.PageName == Names.MainPage)])
                        {
                            Console.Clear();
                            display.CurrentPage = display.PagesQueue.Pop();
                            break;
                        }
                    }
                }
            }
            
        }



        //Setup Pages and menus and any other elements on page
        public static void SetupPages()
        {
            SetupPageWithMenu(Names.MainPage, Names.MainMenu, Names.MainMenuItems);
            SetupPageWithMenu(Names.LoginPage, Names.LoginMenu, Names.LoginMenuItems);
            SetupPageWithMenu(Names.WPMPage, Names.WPMMenu, Names.WPMMenuItems);
            SetupPastEntriesPage();

        }

  
        public static void SetupPageWithMenu(string pageName, string menuName, List<string> menuItemNames)
        {
            //Setup new page
            if (String.IsNullOrWhiteSpace(pageName) || String.IsNullOrWhiteSpace(menuName) || menuItemNames.Count == 0)
            {
                throw new Exception("Input paramenters cannot be null or empty");
            }
            else
            {
                display.Pages.Add(new Page(pageName));

                var page = display.Pages[display.Pages.FindIndex(x => x.PageName == pageName)];

                page.MenuList.Add(new Menu(menuName, new List<string>(menuItemNames)));
                page.CurrentMenu = page.MenuList[0];
                page.DisplayElements.Add(page.CurrentMenu);
            }

        }
        public static void SetupPastEntriesPage()
        {
            //Setup Past Entries page
            try
            {
                display.Pages.Add(new Page(Names.PastEntriesPage));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }
        }
        public static void SetupPastEntriesMenu()
        {
            try
            {
                var PastEntries = display.Pages[display.Pages.FindIndex(x => x.PageName == Names.PastEntriesPage)];

                PastEntries.MenuList.Add(new Menu(Names.PastEntriesMenu, PopulatePastEntriesMenu(PastEntries)));

                PastEntries.CurrentMenu = PastEntries.MenuList[0];

                PastEntries.DisplayElements.Add(PastEntries.CurrentMenu);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                Console.ReadLine();
                throw;
            }
        }
        public static List<string> PopulatePastEntriesMenu(Page pastEntries)
        {
            List<string> s = new List<string>();

            foreach (Entry e in UserAccountController.Account.CurrentUser.Entries)
            {
                s.Add(e.Title);
            }
            return s;
        }




        //Draw out all elements of that page
        public static void DrawPage()
        {
            display.CurrentPage.DrawElements();

            display.DisplayCurrentUser(1, display.CurrentPage.CalculateElementsHeight() + display.CurrentPage.HeaderHeight + 3);
        }


        public static void MenuSelectionEnter()
        {
            switch (display.CurrentPage.CurrentMenu.MenuName)
            {
                case Names.MainMenu:
                    RunMainPage();
                    break;
                case Names.LoginMenu:
                    RunUserPage();
                    break;
                case Names.PastEntriesMenu:
                    RunPastEntriesPage();
                    break;
                case Names.WPMMenu:
                    RunWPMPage(); 
                    break;
            }
        }

        public static void RunMainPage()
        {
            switch (display.CurrentPage.GetMenuItemSelectedValue())
            {
                //Login
                case 0:
                    Console.Clear();
                    UserAccountController.Account.Login();
                    if (UserAccountController.Account.loggedIn)
                    {
                        if (UserAccountController.Account.CurrentUser.Name != UserAccountController.Account.DefaultUser.Name)
                        {
                            display.CurrentPage = display.Pages[display.Pages.FindIndex(x => x.PageName == Names.LoginPage)];
                        }
                        Console.Clear();
                    }
                    break;
                //Create new account
                case 1:
                    Console.Clear();
                    UserAccountController.Account.UserInputNewAccount();
                    Console.Clear();
                    break;
                //Display current users
                case 2:
                    Console.Clear();
                    display.DisplayAllUsers();
                    Display.PressEnterTo("go back...");
                    Console.Clear();
                    break;
                //Exit application
                case 3:
                    FileManagement.SaveUserData(UserAccountController.Account.Users);
                    Environment.Exit(0);
                    break;
            }
        }
        public static void RunUserPage()
        {
            switch (display.CurrentPage.GetMenuItemSelectedValue())
            {
                //Write New Entry
                case 0:
                    Console.Clear();
                    UserAccountController.Account.CurrentUser.NewEntry();
                    FileManagement.SaveUserData(UserAccountController.Account.Users);
                    Console.Clear();
                    break;
                //Load Past Entry
                case 1:
                    Console.Clear();

                    if(UserAccountController.Account.CurrentUser.Entries.Count == 0)
                    {
                        Console.WriteLine("You have no entries yet.");
                    }
                    else
                    {
                        //Navigate to list of Past entries page
                        SetupPastEntriesMenu();
                        display.CurrentPage = display.Pages[display.Pages.FindIndex(x=> x.PageName == Names.PastEntriesPage)];
                        break;
                    }

                    Display.PressEnterTo("go back...");
                    display.CurrentPage = display.PagesQueue.Pop();
                    Console.Clear();
                    
                    break;
                //Words per minute test
                case 2:

                    display.CurrentPage = display.Pages[display.Pages.FindIndex(x => x.PageName == Names.WPMPage)];

                    //display.CurrentPage = display.PagesQueue.Pop();
                    Console.Clear();


                    break;
                //Reset WPM Record
                case 3:
                    Console.Clear();
                    UserAccountController.Account.CurrentUser.WPMRecord = 0;
                    FileManagement.SaveUserData(UserAccountController.Account.Users);
                    break;
                //Logout
                case 4:
                    Console.Clear();

                    UserAccountController.Account.CurrentUser = UserAccountController.Account.DefaultUser;

                    UserAccountController.Account.loggedIn = false;

                    display.CurrentPage = display.PagesQueue.Pop();

                    break;
                //Quit
                case 5:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void RunPastEntriesPage()
        {
            Console.Clear();

            int selectedValue;

            selectedValue = display.CurrentPage.GetMenuItemSelectedValue();

            UserAccountController.Account.CurrentUser.Entries[selectedValue].Draw();

            Display.PressEnterTo("go back...");

            Console.Clear();
        }

        public static void RunWPMPage()
        {
            switch (display.CurrentPage.GetMenuItemSelectedValue())
            {
                //Short
                case 0:
                    Console.Clear();
                    RunWPM(WPMParagraphs.WPMLengthSelect.Short);
                    break;
                //Medium
                case 1:
                    Console.Clear();
                    RunWPM(WPMParagraphs.WPMLengthSelect.Medium);
                    break;
                //Long
                case 2:
                    Console.Clear();
                    RunWPM(WPMParagraphs.WPMLengthSelect.Long);
                    break;

            }
        }


        public static void RunWPM(WPMParagraphs.WPMLengthSelect length)
        {
            WPMUI wpm = new WPMUI();

            wpm.StartChallenge(length);

            if (wpm.WordsPerMin > UserAccountController.Account.CurrentUser.WPMRecord)
            {
                Console.WriteLine("New Record!!!");
                UserAccountController.Account.CurrentUser.WPMRecord = wpm.WordsPerMin;
            }

            Display.PressEnterTo("go back...");
            //display.CurrentPage = display.PagesQueue.Pop();
            Console.Clear();
            FileManagement.SaveUserData(UserAccountController.Account.Users);
        }
    }
}
