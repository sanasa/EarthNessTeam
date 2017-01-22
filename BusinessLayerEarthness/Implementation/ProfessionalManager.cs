using BusinessLayerEarthness.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Facade;
using DAL.Implementation;

namespace BusinessLayerEarthness.Implementation
{
public    class ProfessionalManager : IProfessionalManager
    {
        private IRepository<Professional> repo;
        public ProfessionalManager(masterEntities repo)
        {
            this.repo = new ProfessionalRepository(repo);
        }

        public Professional checkLogIn(string mail, string password)
        {
          return  repo.CheckLogin(mail, password);
        }

        public void DeleteProfessional(int ProfessionalID)
        {
            repo.DeleteById(ProfessionalID);
        }

        public Professional GetProfessionalByID(int Id)
        {
            return repo.GetByID(Id);
        }

        public IEnumerable<Professional> GetProfessionals()
        {
            return repo.GetAll();
        }

        public void InsertProfessional(Professional Professional)
        {
            repo.Insert(Professional);
        }

        public void Save()
        {
            repo.Save();
        }

        public void UpdateProfessional(Professional Professional)
        {
            repo.Update(Professional);
        }
    }
}
