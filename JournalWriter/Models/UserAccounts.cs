using System;
using System.Collections.Generic;
using System.Text;
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
        public bool LoggedIn { get; set; }

        public User DefaultUser { get; set; } = new User("") { Name = "DefaultUser" };


        //-------Constructors-------//

        public UserAccounts()
        {
            Users = new List<User>();

            CurrentUser = new User("");
            CurrentUser = DefaultUser;

            Users.Add(CurrentUser);

            LoggedIn = false;

            FileManagement.Initialize(Users);

        }


        //-------Methods-------//

        public void Login()
        {
            string input = "";
            string userName = "";
            LoggedIn = false;

            Console.WriteLine("Please enter username or press ESC to go back.");

            while (LoggedIn == false)
            {
                input = Display.ReadLineOrEscape();

                if(input == null) { break; }

                if (CheckValidNameInput(input))
                {
                    if (CheckAccountExists(input))
                    {
                        userName = input;

                        Console.WriteLine("Please Enter Password: ");

                        while (LoggedIn == false)
                        {
                            input = Display.GetHiddenConsoleInput();

                            if (CheckPasswordCorrect(userName, input))
                            {
                                Console.WriteLine("Correct!");
                                CurrentUser = Users[Users.FindIndex(x => x.Name == userName)];
                                LoggedIn = true;
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
            Users = FileManagement.LoadUserData();
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
                input = Display.ReadLineOrEscape();

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
            LoggedIn = true;
            

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





    }
}
