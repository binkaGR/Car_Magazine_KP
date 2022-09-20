using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class UserLogin 
    {
        public List<User> users = new List<User>();
        public User user;
        int number_of_user = 0;
        public void addUsers()
        {
            DataBasetInfoContext context = new DataBasetInfoContext();
            List<Loggin_User> loggin_Users = context.Users.ToList();
            number_of_user = loggin_Users.Count();
            for (int i = 0; i < number_of_user; i++)
            {
                user = new User(loggin_Users[i].Username, loggin_Users[i].Password_u, loggin_Users[i].Access);
                users.Add(user);
            }
        }

        public string CheckUser(string username, string password)
        {
            int i = 0;
            while (true)
            {
                if (i == number_of_user)
                {
                    break;
                }
                user = users[i];
                if ((user.GetUsername() == username) && (password == user.GetPassword()))
                {
                    return user.GetReight();
                    break;
                }
                if (i == number_of_user)
                {
                    break;

                }
                else
                {
                    i++;
                }
            }
            return "Access denied!";
        }
    }
}
