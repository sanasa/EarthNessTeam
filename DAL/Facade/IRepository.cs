using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Facade
{
  public  interface IRepository<T> where T : class ,IDisposable
    {
        IEnumerable<T> GetAll();
        T GetByID(int Id);
        void Insert(T T);
        void DeleteById(int ID);
        void Update(T t);
        T CheckLogin(string mail, string password);
        void Dispose();
        void Save();
    }
}
