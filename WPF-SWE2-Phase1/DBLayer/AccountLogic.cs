using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWE2_Phase1.DBLayer
{
    public class AccountLogic
    {
        // A function that gets the account with this username and password
        public static Account getAccount(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            try
            {
                return MainWindow.db.Accounts.Single(acc => acc.Name == username && acc.Password == password);
            }
            catch
            {
                return null;
            }
        }
    }
}
