using DAL.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using System.Data.Entity;

namespace DAL.Implementation
{
    public class UserRepository : Repository<User>, IDisposable
    {
        public UserRepository(masterEntities context) : base(context)
        {
        }

        public override User CheckLogin(string mail, string password)
        {
            return context.User.Where(u => u.Password == password && u.UserMail == mail).FirstOrDefault();

        }


    }
}
