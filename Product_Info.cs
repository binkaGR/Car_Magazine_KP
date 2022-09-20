using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Product_Info
    {
        private System.Int32 Id_Product { get; set; }
        private string Product_Name { get; set; }
        private string Product_Type { get; set; }
        private string Marka { get; set; }
        private int Product_Year { get; set; }
        private float Price { get; set; }
        private int Product_count { get; set; }
        private string Information { get; set; }

       public Product_Info(System.Int32 id, string name, string type, string marka, 
                int year, float price, int count, string info)
        {
            this.Id_Product = id;
            this.Product_Name = name;
            this.Product_Type = type;
            this.Marka = marka;
            this.Product_Year = year;
            this.Price = price;
            this.Product_count = count;
            this.Information = info;
        }

        public System.Int32 Get_Product_ID()
        {
            return this.Id_Product;
        }
        public void set_Product_ID( System.Int32 id)
        {
            this.Id_Product=id;
        }
        public string Get_Product_Name()
        {
            return this.Product_Name;
        }

        public void  Set_Product_Name(string name)
        {
           this.Product_Name=name;
        }
        public string Get_Product_Type() 
        {
            return this.Product_Type;
        }
        public void Set_Product_Type( string type)
        {
            this.Product_Type=type;
        }
        public string Get_Marka() 
        {
            return this.Marka;
        }
        public void  Get_Marka(string marka)
        {
            this.Marka=marka;
        }

        public int Get_Product_Year()
        {
            return this.Product_Year;
        }
        public void Set_Product_Year(int year)
        {
            this.Product_Year = year;
        }
        public float Get_Price()
        {
            return this.Price;
        }
        public void  Set_Price(float price)
        {
            this.Price=price;
        }
        public int Get_Count()
        {
            return this.Product_count;
        }
        public void Set_Count(int count)
        {
            this.Product_count=count;
        }
        public string Get_Information()
        {
            return this.Information;
        }
        public void Set_Information(string info)
        {
            this.Information=info;
        }
    }
}
