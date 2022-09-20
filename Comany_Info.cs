using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class Comany_Info
    {
        private string name_f { get; set; }
        private string address_f { get; set; }
        private string telephone_f { get; set; }

        public Comany_Info(string name, string address, string telephone)
        {
            this.name_f = name;

            this.address_f = address;
            this.telephone_f = telephone;
        }

        public string Get_Name_f()
        {
            return this.name_f;
        }
        public void Set_Name_F(string name)
        {
            this.name_f = name;
        }
        public string Get_Address_f()
        {
            return this.address_f;
        }
        public void Set_Address_F(string address)
        {
            this.address_f = address;
        }
        public string Get_Telephone_f()
        {
            return this.telephone_f;
        }
        public void Set_Telephone_f(string phone)
        {
            this.telephone_f = phone;
        }
    }
}
