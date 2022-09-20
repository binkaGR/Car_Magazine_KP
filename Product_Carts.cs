using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Product_Carts
    {
        private string name_Product;
        private int count_Product;

        public Product_Carts(string name , int count)
        {
            this.name_Product = name;
            this.count_Product = count;
        }
        public string Get_Name_Product() 
        {
           return  this.name_Product;
        }
        public int Get_Count_Product() 
        {
            return this.count_Product;
        }

        public void Set_Name_Product(string name) 
        {
            this.name_Product = name;
        }

        public void Set_Count_Product(int count) 
        {
            this.count_Product = count;
        }
    }
}
