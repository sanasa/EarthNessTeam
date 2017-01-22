
using System.Collections.Generic;

using DAL.Models;

namespace BusinessLayerEarthness.Facade
{
   public interface IProfessionalManager
    {
        IEnumerable<Professional> GetProfessionals();
        Professional GetProfessionalByID(int Id);
        void InsertProfessional(Professional Professional);
        void DeleteProfessional(int ProfessionalID);
        void UpdateProfessional(Professional Professional);
        Professional checkLogIn(string mail, string password);
        void Save();
    }
}
