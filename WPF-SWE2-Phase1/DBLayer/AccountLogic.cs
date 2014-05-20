using System;
using System.Collections.Generic;
using System.Data;
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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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

        // A function that edits an account
        // Username or password can have null value, we edit at least one of them
        public static bool editAccount(Account accountToBeEdited, string username, string password)
        {
            if (accountToBeEdited == null)
                return false;

            // Both of them are empty
            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
                return false;

            // It means no change happened
            bool noChanges = true;
            if (accountToBeEdited.Name != username)
                noChanges = false;
            if (accountToBeEdited.Password != password)
                noChanges = false;

            if (noChanges) return false;


            // Checks what field has changes
            if (!string.IsNullOrEmpty(username)) accountToBeEdited.Name = username;
            if (!string.IsNullOrEmpty(password)) accountToBeEdited.Password = password;

            try
            {
                MainWindow.db.Entry(accountToBeEdited).State = EntityState.Modified;
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
