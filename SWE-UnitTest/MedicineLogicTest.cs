﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SWE2_Phase1.DBLayerStub;
using NUnit.Framework;

namespace SWE_UnitTest
{
    [TestFixture]
    class MedicineLogicTest
    {
        MedicineLogic medicineLogic = new MedicineLogic();

        //////////////////////////////////////////////// Testing adding new medicine
        // Testing normal values
        [Test]
        public void addMedicine_normalValue()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 10, 10, "Not Empty", new DateTime(2015, 1, 1));
            Assert.IsTrue(actual, "Test failed with normal values.");
        }

        // Testing empty medicine name
        [Test]
        public void addMedicine_emptyName()
        {
            bool actual = medicineLogic.addMedicine("", 10, 10, "Not Empty", new DateTime(2015, 1, 1));
            Assert.IsFalse(actual, "Test failed with empty medicine name.");
        }

        // Testing out boundry price
        [Test]
        public void addMedicine_outBoundryPrice()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 0, 10, "Not Empty", new DateTime(2015, 1, 1));
            Assert.IsFalse(actual, "Test failed with out boundry price.");
        }

        // Testing out boundry quantity
        [Test]
        public void addMedicine_outBoundryQuantity()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 10, 0, "Not Empty", new DateTime(2015, 1, 1));
            Assert.IsFalse(actual, "Test failed with out boundry quantity.");
        }

        // Testing empty category name
        [Test]
        public void addMedicine_emptyCategoryName()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 10, 10, "", new DateTime(2015, 1, 1));
            Assert.IsFalse(actual, "Test failed with empty category name.");
        }

        // Testing not initialized expired date
        [Test]
        public void addMedicine_notInitializedExpiredDate()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 10, 10, "Not Empty", new DateTime());
            Assert.IsFalse(actual, "Test failed with empty date.");
        }

        // Testing previous expired date
        [Test]
        public void addMedicine_outBoundryExpiredDate()
        {
            bool actual = medicineLogic.addMedicine("Not Empty", 10, 10, "Not Empty", new DateTime(2010, 1, 1));
            Assert.IsFalse(actual, "Test failed with out boundry expired date.");
        }

        //////////////////////////////////////////////// Testing deleting medicine
        // Testing normal values
        [Test]
        public void deleteMedicine_normalValues()
        {
            bool actual = medicineLogic.deleteMedicine("Not Empty");
            Assert.IsTrue(actual, "Test failed with normal values.");
        }

        // Testing empty medicine name
        [Test]
        public void deleteMedicine_emptyMedicineName()
        {
            bool actual = medicineLogic.deleteMedicine("");
            Assert.IsFalse(actual, "Test failed with empty medicine name.");
        }
    }
}
