using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Cart_list
    {
        private string Product_Name;
        private int Count;

        public Cart_list(string name, int count)
        {
            this.Product_Name = name;
            this.Count = count;
        }

        public string Get_Product_Name()
        {
            return this.Product_Name;
        }

        public void Set_Product_Name(string name)
        {
            this.Product_Name = name;
        }

        public int Get_Count()
        {
            return this.Count;
        }
        public void Set_Count(int count)
        {
            this.Count = count;
        }
    }
}
