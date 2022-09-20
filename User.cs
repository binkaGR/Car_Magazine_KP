using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class User
    {
        private string Username;
        private string Password;
        private string Reight;

        public User(string userame, string password, string reight)
        {
            this.Username = userame;
            this.Password = password;
            this.Reight = reight;
        }

        public string GetUsername()
        {
            return this.Username;
        }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }

        public string GetReight()
        {
            return this.Reight;
        }

        public void SetReight(string reight)
        {
            this.Reight = reight;
        }

    }
}
