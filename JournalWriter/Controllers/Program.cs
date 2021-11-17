using System;
using System.Collections.Generic;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;

namespace JournalWriter.Controllers
{
    class Program
    {
      

        [STAThread]
        static void Main(string[] args)
        {
            DataManagement.Initialize();

            UserAccounts.Users = DataManagement.LoadData();

            while (true)
            {
                //MainMenu.Open();

                //if (UserAccounts.loggedIn)
                //{
                //    EntryMenu.Open();
                //}

                DisplayMenu();
                

                while (true)
                {

                }

            }
           
        }

        static void DisplayMenu()
        {
            UserInterface ui = new UserInterface();

            ui.Menu.SelectionsDisplay.Add();



            foreach (string s in selections)
            {
                Console.WriteLine(s);
            }

        }




   
    }
}
