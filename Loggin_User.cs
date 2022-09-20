using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Loggin_User
    {
        [Key]
        public int Id_user { get; set; }
        public string Username { get; set; }
        public string Password_u { get; set; }
        public string Access { get; set; }

        public Loggin_User() 
        { }
        public Loggin_User(int id ,string name , string  pass, string acess) 
        {
            this.Id_user = id;
            this.Username = name;
            this.Password_u = pass;
            this.Access = acess;
        }
    }
}
