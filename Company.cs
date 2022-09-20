using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Company
    {
        [Key]
        public int Id_company { get; set; }
        public string Name_Firma { get; set; }
        public string Address_Frima { get; set; }
        public string Telephone_Frima { get; set; }
    }
}
