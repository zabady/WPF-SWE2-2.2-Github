using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SWE2_Phase1.DBLayer;
using NUnit.Framework;

namespace SWE_UnitTest
{
    [TestFixture]
    class Medicine_Logic_Test
    {
        medicine_Logic medTest = new medicine_Logic();

        //testing on adding medicine parameters 
        [Test]
        public void addMedicine_emptyMedicineParameters()
        {
            bool actual = medTest.Add_Medecine_Logic("", 0, 0, "", new DateTime(2010, 1, 18));
            Assert.IsFalse(actual);
        }
        [Test]
        public void addMedicine_NullParameters()
        {
            bool actual = medTest.Add_Medecine_Logic(null, 45, 100, null, new DateTime(2014, 6, 5));
            Assert.AreEqual(false, actual);
        }
    }
}
