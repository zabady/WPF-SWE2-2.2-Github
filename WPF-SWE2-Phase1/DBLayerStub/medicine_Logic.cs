using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SWE2_Phase1.DBLayerStub
{
    class medicine_Logic
    {
        public bool Add_Medecine_Logic(string name, int price, int quatity, string category, DateTime ExpireDate)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || quatity < 0 || price < 0 || string.IsNullOrEmpty(ExpireDate.ToString()))
                return false;
            else
                return true;
        }
    }
}
