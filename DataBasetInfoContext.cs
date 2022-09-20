using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Magazine_KP
{
    class DataBasetInfoContext : DbContext
    {
        public DataBasetInfoContext()
            : base(@"Data Source=DESKTOP-4S910R2\SQLEXPRESS;Initial Catalog=Car_Magazine_Best;Integrated Security=True")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());
        }
        public DbSet<Loggin_User> Users { get; set; }
        public DbSet<User_Information> user_info { get; set; }
        public DbSet<Company> company { get; set; }
        public DbSet<Product> product { get; set; }
    }
}
