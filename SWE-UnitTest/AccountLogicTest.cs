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
        // Get account testing
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


        // Add account testing
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
    }
}
