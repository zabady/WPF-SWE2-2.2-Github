using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWE2_Phase1.DBLayerStub
{
    public class MedicineLogic
    {
        public bool addMedicine(string name, int price, int quatity, string category, DateTime expireDate)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || quatity <= 0 ||
                string.IsNullOrEmpty(category) || expireDate == null || expireDate < DateTime.Now)
                return false;

            return true;
        }

        // A function to delete medicine
        public bool deleteMedicine(string medicineName)
        {
            if (string.IsNullOrEmpty(medicineName))
                return false;

            return true;
        }
    }
}
