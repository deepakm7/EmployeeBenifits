using EmployeeBenefits.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefits.Data
{
    public class DependentRepository : IDependentRepository
    {
        private readonly Context ctx;

        public DependentRepository(Context context)
        {
            this.ctx = context;
        }

        public int AddDependent(int employeeId, string firstName, string lastName, int dependentTypeId)
        {
            Dependent dependent = new Dependent
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                DependentTypeId = dependentTypeId
            };
            ctx.Dependent.Add(dependent);
            ctx.SaveChanges();
            return dependent.DependentId;
        }

        public List<Dependent> GetDependentsByEmployee(int employeeId)
        {
            return ctx.Dependent.Include(x => x.DependentType).Where(x => x.EmployeeId == employeeId).ToList();
        }

        public List<DependentTypeLkp> GetDependentTypes()
        {
            return ctx.DependentTypeLkp.Where(x => x.Obsolete == false).ToList();
        }
    }
}
