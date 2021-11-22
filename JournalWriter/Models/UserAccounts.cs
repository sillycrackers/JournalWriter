﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using JournalWriter;
using JournalWriter.Views;
using JournalWriter.Models;



namespace JournalWriter.Controllers
{
    public class UserAccounts
    {
        //-------Properties-------//

        public List<User> Users { get; set; }
        public User CurrentUser { get; set; }
        public bool loggedIn { get; set; }


        //-------Constructors-------//

        public UserAccounts()
        {
            Users = new List<User>();

            CurrentUser = new User("") { Name = "DefaultUser" };

            Users.Add(CurrentUser);

            loggedIn = false;

            FileManagement.Initialize(Users);

        }


        //-------Methods-------//

        public void Login()
        {
            string input = "";
            string userName = "";
            loggedIn = false;
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            Console.WriteLine("Please enter username or press ESC to go back.");

            while (loggedIn == false)
            {
                input = ReadLineOrEscape();

                if(input == null) { break; }

                if (CheckValidNameInput(input))
                {
                    if (CheckAccountExists(input))
                    {
                        userName = input;

                        Console.WriteLine("Please Enter Password: ");

                        while (loggedIn == false)
                        {
                            input = Display.GetHiddenConsoleInput();

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

        public void LoadUsers()
        {
            this.Users = FileManagement.LoadUserData();
        }
        public bool CheckPasswordCorrect(string userName, string password)
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
        public void UserInputNewAccount()
        {
            string input;
            string name = "";
            string password;

            Console.WriteLine("Please enter user name or press Esc to go back");

            //User sets Name
            while (true)
            {
                input = ReadLineOrEscape();

                if(input == null) { break; }

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
            if (input == null) { return; }

            Console.WriteLine("Please enter password");

            //User sets password
            while (true)
            {
                input = Display.GetHiddenConsoleInput();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    password = input;

                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input, try again");
                }

            }

            //Create the account after receiving valid user name and password
            CreateUserAccount(name, password);

            Console.Clear();

            Console.WriteLine("Account created.");

            Thread.Sleep(2000);

        }
        public bool CheckValidNameInput(string s)
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
        public void CreateUserAccount(string _name, string _password)
        {
            User user = new User(_password) { Name = _name, Id = Users.Count };
            Users.Add(user);
            FileManagement.SaveUserData(Users);
        }
        public bool CheckAccountExists(string _name)
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
        public void PrintUsers()
        {
            foreach (User u in Users)
            {
                Console.WriteLine($"Name: {u.Name} ID: {u.Id}");
            }
        }

        public void DisplayCurrentUser(int leftPosition, int topPosition)
        {
            Console.SetCursorPosition(leftPosition, topPosition);
            Console.WriteLine("Logged In: " + CurrentUser.Name);

        }


        // Returns null if user pressed Escape, or the contents of the line when they pressed Enter.
        // Does not accept Spaces.
        private string ReadLineOrEscape()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            StringBuilder sb = new StringBuilder();
            int index = 0;

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return null;
                }

                if(keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index > 0)
                    {
                        Console.CursorLeft = index - 1;

                        sb.Remove(index - 1, 1);

                        Console.Write(" \b");

                        index--;
                    }
                }
                //Makes sure value is inbetween Unicode values for symbols and letters only
                if(keyInfo.KeyChar > 32 && keyInfo.KeyChar < 127)
                {
                    index++;
                    Console.Write(keyInfo.KeyChar);
                    sb.Append(keyInfo.KeyChar);
                }
            }
            Console.Write('\n');
            return sb.ToString(); ;
        }
    }
}
