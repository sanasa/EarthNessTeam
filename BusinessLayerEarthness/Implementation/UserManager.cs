using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayerEarthness.Facade;
using DAL.Implementation;
using DAL.Facade;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using DAL.Models;

namespace BusinessLayerEarthness.Implementation
{
   public class UserManager : IUserManager
    {
      private  IRepository<User> repo;
        public UserManager(masterEntities context)
        {
            repo = new UserRepository(context);
        }
        public void DeleteUser(int UserID)
        {
            repo.DeleteById(UserID);
        }

        public void Dispose()
        {
            repo.Dispose();
        }

        public IEnumerable<User> GetUsers()
        {
            return repo.GetAll();
        }

        public User GetUserByID(int Id)
        {
            return repo.GetByID(Id);
        }

        public void InsertUser(User User)
        {
            repo.Insert(User);
        }

        

        public void Save()
        {
            repo.Save();
        }

        public void UpdateUser(User User)
        {
            repo.Update(User);
        }

        public User checkLogIn(string mail, string password)
        {
            return repo.CheckLogin(mail, password);
        }
    }
}
