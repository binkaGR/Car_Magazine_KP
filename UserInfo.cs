using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class UserInfo
    {
        private string First_Name;
        private string Last_Name;
        private string User_address;
        private string User_Phone;

        public UserInfo(string first_name, string last_name, string user_address, string user_Phone)
        {
            this.First_Name = first_name;
            this.Last_Name = last_name;
            this.User_address = user_address;
            this.User_Phone = user_Phone;

        }

        public string Get_FirstName()
        {
            return this.First_Name;
        }

        public void Set_FirstName( string first_name)
        {
            this.First_Name=first_name;
        }
        public string Get_Last_Name()
        {
            return this.Last_Name;
        }
        public void Set_Last_Name(string last_name)
        {
            this.Last_Name = last_name;
        }
        public string Get_User_address()
        {
            return this.User_address;
        }
        public void Set_User_address(string user_address)
        {
            this.User_address = user_address;
        }
        public string Get_User_Phone()
        {
            return this.User_Phone;
        }
        public void Set_User_Phone(string user_Phone)
        {
            this.User_Phone = user_Phone;
        }
    }
}
