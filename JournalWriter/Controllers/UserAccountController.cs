using System;
using System.Collections.Generic;
using System.Text;

namespace JournalWriter.Controllers
{
    public static class UserAccountController
    {
        public static UserAccounts Account { get; private set; }
        

        static UserAccountController()
        {
            Account = new UserAccounts();
            
        }

        public static void Run()
        {
            Account.DisplayCurrentUser();
        }

        
    }
}
