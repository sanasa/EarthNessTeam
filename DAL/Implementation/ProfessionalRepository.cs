using DAL.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Implementation
{
    public class ProfessionalRepository : Repository<Professional>, IDisposable
    {
        public ProfessionalRepository(masterEntities context) : base(context)
        {
        }

        public override Professional CheckLogin(string mail, string password)
        {
            return context.Professional.Where(u => u.Password == password && u.CompanyEmail == mail).FirstOrDefault();

        }
    }
}
