using System;
using System.Collections.Generic;
using System.Text;

namespace JournalWriter.Controllers
{
    public static class UserAccountController
    {
        //-------Properties-------//
        public static UserAccounts Account { get; private set; }

        //-------Constructors-------//
        static UserAccountController()
        {
            Account = new UserAccounts();
            Account.LoadUsers();
        }

        //-------Methods-------//


    }
}
