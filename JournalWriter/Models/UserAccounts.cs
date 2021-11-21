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
                keyInfo = Console.ReadKey(true);

                if(keyInfo.Key == ConsoleKey.Escape) { break; }

                input = Console.ReadLine();

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
                input = Display.GetHiddenConsoleInput();

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
    }
}
