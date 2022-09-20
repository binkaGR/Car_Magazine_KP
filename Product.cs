using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Product
    {
        [Key]
        public int  Id_Product { get; set; }
        public string Product_Name { get; set; }
        public string Product_Type { get; set; }
        public string Marka { get; set; }
        public int Product_Year { get; set; }
        public float Price { get; set; }
        public int Product_count { get; set; }
        public string Information { get; set; }
        public int id_f { get; set; }
    }
}
