using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SWE2_Phase1;
using NUnit.Framework;
using WPF_SWE2_Phase1.DBLayerStub;

namespace SWE_UnitTest
{
    [TestFixture]
    class AccountLogicTest
    {
        private Account testAccount = new Account();

        //////////////////////////////////////////////// Testing get account
        [Test]
        public void getAccount_normalValue()
        {
            Account actual = AccountLogic.getAccount("Not Empty", "Not empty");
            Assert.NotNull(actual, "Test failed on not empty username and password");
        }

        [Test]
        public void getAccount_emptUsername()
        {
            Account actual = AccountLogic.getAccount("", "Not Empty");
            Assert.IsNull(actual, "Test failed on empty username and not empty password");
        }

        [Test]
        public void getAccount_emptPassword()
        {
            Account actual = AccountLogic.getAccount("Not Empty", "");
            Assert.IsNull(actual, "Test failed on not empty username and empty password");
        }

        [Test]
        public void getAccount_emptUsernameAndPassword()
        {
            Account actual = AccountLogic.getAccount("", "");
            Assert.IsNull(actual, "Test failed on empty username and empty password");
        }


        //////////////////////////////////////////////// Testing add account
        [Test]
        public void addAccount_normalAdminValues()
        {
            bool actual = AccountLogic.addAccount("Not Empty", "Not Empty", true);
            Assert.IsTrue(actual, "Test failed on not empty username and password with role equale to true");
        }

        [Test]
        public void addAccount_normalUserValues()
        {
            bool actual = AccountLogic.addAccount("Not Empty", "Not Empty", false);
            Assert.IsTrue(actual, "Test failed on not empty username and password with role equale to user");
        }

        [Test]
        public void addAccount_emptyUsernameAdminValues()
        {
            bool actual = AccountLogic.addAccount("", "Not Empty", true);
            Assert.IsFalse(actual, "Test failed on empty username and not empty password with role equale to true");
        }

        [Test]
        public void addAccount_emptyUsernameUserValues()
        {
            bool actual = AccountLogic.addAccount("", "Not Empty", false);
            Assert.IsFalse(actual, "Test failed on empty username and not empty password with role equale to user");
        }

        [Test]
        public void addAccount_emptyPasswordAdminValues()
        {
            bool actual = AccountLogic.addAccount("Not Empty", "", true);
            Assert.IsFalse(actual, "Test failed on not empty username and empty password with role equale to true");
        }

        [Test]
        public void addAccount_emptyPasswordUserValues()
        {
            bool actual = AccountLogic.addAccount("Not Empty", "", false);
            Assert.IsFalse(actual, "Test failed on not empty username and empty password with role equale to user");
        }

        //////////////////////////////////////////////// Testing edit account
        [Test]
        public void editAccount_normalValues()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Test", "Test");
            Assert.IsTrue(actual, "Test failed with normal values.");
        }

        [Test]
        public void editAccount_nullAccount()
        {
            bool actual = AccountLogic.editAccount(null, "Test", "Test");
            Assert.IsFalse(actual, "Test failed with null account.");
        }

        [Test]
        public void editAccount_emptyAccount()
        {
            bool actual = AccountLogic.editAccount(testAccount, "Test", "Test");
            Assert.IsFalse(actual, "Test failed with empty account.");
        }

        [Test]
        public void editAccount_emptyUsername()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "", "Test");
            Assert.IsTrue(actual, "Test failed with empty username.");
        }

        [Test]
        public void editAccount_emptyPassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Test", "");
            Assert.IsTrue(actual, "Test failed with empty password.");
        }

        [Test]
        public void editAccount_emptyUsernameAndPassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "", "");
            Assert.IsFalse(actual, "Test failed with empty username and empty password.");
        }

        [Test]
        public void editAccount_sameUsernameAndNewPassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Not Empty", "Test");
            Assert.IsTrue(actual, "Test failed with same username and new password.");
        }

        [Test]
        public void editAccount_newUsernameAndSamePassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Test", "Not Empty");
            Assert.IsTrue(actual, "Test failed with new username and same password.");
        }

        [Test]
        public void editAccount_sameUsernameAndSamePassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Not Empty", "Not Empty");
            Assert.IsFalse(actual, "Test failed with same username and same password.");
        }

        [Test]
        public void editAccount_newUsernameAndEmptyPassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "Test", "");
            Assert.IsTrue(actual, "Test failed with new username and empty password.");
        }

        [Test]
        public void editAccount_emptyUsernameAndNewPassword()
        {
            testAccount.id = 1;
            testAccount.Name = "Not Empty";
            testAccount.Password = "Not Empty";

            bool actual = AccountLogic.editAccount(testAccount, "", "Test");
            Assert.IsTrue(actual, "Test failed with empty username and new password.");
        }
    }
}
