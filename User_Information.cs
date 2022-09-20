using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class User_Information
    {
        [Key]
        public int Id_User { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string User_address { get; set; }
        public string User_phone { get; set; }
        public int Firma_id { get; set; }
    }
}
