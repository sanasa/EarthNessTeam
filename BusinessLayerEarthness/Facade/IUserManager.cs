
using System.Collections.Generic;

using DAL.Models;

namespace BusinessLayerEarthness.Facade
{
  public  interface IUserManager 
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int Id);
        void InsertUser(User User);
        void DeleteUser(int UserID);
        void UpdateUser(User User);

        User checkLogIn(string mail, string password);
        void Save();
    }
}
