using DAL.Facade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Implementation
{
   public class Repository<T> : IRepository<T> where T: class,IDisposable
    {
        protected masterEntities context;
        public Repository(masterEntities context)
        {
            this.context = context;
        }
        public void DeleteById(int ID)
        {
            T t = context.Set<T>().Find(ID);
            context.Set<T>().Remove(t);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetByID(int Id)
        {
            return context.Set<T>().Find(Id);
        }

        public virtual void Insert(T T)
        {
            context.Set<T>().Add(T);
        }

        
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
        }

        public virtual T CheckLogin(string mail, string password)
        {
            return null;
        }
    }
}
