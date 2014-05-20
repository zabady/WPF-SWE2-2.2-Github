﻿using System;
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
    }
}
