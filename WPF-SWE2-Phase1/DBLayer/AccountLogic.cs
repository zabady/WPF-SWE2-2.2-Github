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

        // A function that adds a new account with the recieved parameters
        public static bool addAccount(string username, string password, bool role)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || role == null)
                return false;

            Account acc = new Account();
            acc.Name = username;
            acc.Password = password;
            acc.Role = role;

            try
            {
                MainWindow.db.Accounts.Add(acc);
                MainWindow.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
