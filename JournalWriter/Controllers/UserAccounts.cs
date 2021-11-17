using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;



namespace JournalWriter.Controllers
{
    public static class UserAccounts
    {
        public static List<User> Users = new List<User>();
        public static User CurrentUser { get; private set; }
        public static bool loggedIn { get; set; }


        public static void Login()
        {
            string input = "";
            string userName = "";
            loggedIn = false;

            Console.WriteLine("Please enter username or press ESC to go back.");

            while (loggedIn == false )
            {
                  input = Console.ReadLine();

                if (CheckValidNameInput(input))
                {
                    if (CheckAccountExists(input))
                    {
                        userName = input;

                        Console.WriteLine("Please Enter Password: ");

                        while (loggedIn == false)
                        {

                            input = Menu.GetHiddenConsoleInput();

                            if (CheckPasswordCorrect(userName, input))
                            {
                                Console.WriteLine("Correct!");
                                CurrentUser = Users[Users.FindIndex(x => x.Name == userName)];
                                loggedIn = true;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect password, try again...");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("User name does not exist try again....");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid spelling try again...");
                }
            }
        }
        public static bool CheckPasswordCorrect(string userName, string password)
        {
            if (Users[Users.FindIndex(x => x.Name == userName)].DecryptPassword() == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void UserInputNewAccount()
        {
            string input;
            string name = "";
            string password;

            Console.WriteLine("Please enter user name...");

            //User sets Name
            while (true)
            {
                input = Console.ReadLine();

                if (CheckValidNameInput(input))
                {
                    //Check if user name already exists
                    if (CheckAccountExists(input))
                    {
                        Console.WriteLine("Username already exists, try another user name.");
                    }
                    else
                    {
                        name = input;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }

            Console.WriteLine("Please enter password");

            //User sets password
            while (true)
            {
                input = Menu.GetHiddenConsoleInput();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    password = input;

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input, type only numbers, try again");
                }

            }

            //Create the account after receiving valid user name and password
            CreateUserAccount(name, password);

            Console.Clear();

            Console.WriteLine("Account created.");

        }
        public static bool CheckValidNameInput(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void CreateUserAccount(string _name, string _password)
        {
            User user = new User(_password) { Name = _name, Id = Users.Count };
            Users.Add(user);
        }
        public static bool CheckAccountExists(string _name)
        {
            int index = Users.FindIndex(x => x.Name == _name);

            if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PrintUsers()
        {
            foreach (User u in Users)
            {
                Console.WriteLine($"Name: {u.Name} ID: {u.Id}");
            }
        }

        public static bool EscKeyPressed()
        {

            ConsoleKeyInfo key;

            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                return true;
            }
            else { return false; }

        }
    }
}
