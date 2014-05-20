using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWE2_Phase1.DBLayer
{
    public class MedicineLogic
    {
        Medicine medicine = new Medicine();

        // A function to add medicine
        public bool addMedicine(string name, int price, int quatity, string category, DateTime expireDate)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || quatity <= 0 ||
                string.IsNullOrEmpty(category) || expireDate == null || expireDate < DateTime.Now)
                return false;

            medicine.Name = name;
            medicine.Price = price;
            medicine.Quantity = quatity;
            medicine.Category = category;
            medicine.ExpireDate = expireDate;

            try
            {
                MainWindow.db.Medicines.Add(medicine);
                MainWindow.db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // A function to delete medicine
        public bool deleteMedicine(string medicineName)
        {
            if (string.IsNullOrEmpty(medicineName))
                return false;

            medicine = MainWindow.db.Medicines.Single(c => c.Name == medicineName);
            try
            {
                MainWindow.db.Medicines.Remove(medicine);
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
