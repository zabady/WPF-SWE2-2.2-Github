using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWE2_Phase1.DBLayer
{
 public class medicine_Logic
    {
        Medicine medicine = new Medicine();
        public bool Add_Medecine_Logic(string name,int price, int quatity,string category,DateTime ExpireDate)
        {
            medicine.Name = name;
            medicine.Price = price;
                medicine.Quantity=quatity;
                medicine.Category = category;
                medicine.ExpireDate = ExpireDate;
                try
                {
                    MainWindow.db.Medicines.Add(medicine);
                    MainWindow.db.SaveChanges();
                    return true;
                }
                catch {
                    return false;
                }

                  
        }
    }
}
