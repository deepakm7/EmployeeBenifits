using EmployeeBenefits.Data;
using EmployeeBenifits.Shared;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefits.Services
{
    public class DependentService : IDependentService
    {
        private readonly IDependentRepository dependentRepository;
        public DependentService(IDependentRepository dependentRepository)
        {
            this.dependentRepository = dependentRepository;
        }

        public List<DependentDetailModel> GetDependents(int employeeId)
        {
            return dependentRepository.GetDependentsByEmployee(employeeId).Select(x => new DependentDetailModel(x)).ToList();
        }

        public List<DependentTypeModel> GetDependentTypes()
        {
            return dependentRepository.GetDependentTypes().Select(l => new DependentTypeModel() { DependentTypeId = l.DependentTypeId, DependentTypeName = l.DependentTypeName }).ToList();
        }

        public int AddEmployeeDependents(int employeeId, List<DependentDetailModel> dependentDetails)
        {
            if (dependentDetails == null || dependentDetails.Count == 0)
                return 0;
            foreach (var eachDependent in dependentDetails)
            {
                dependentRepository.AddDependent(employeeId, eachDependent.FirstName, eachDependent.LastName, eachDependent.DependentTypeId ?? 0);
            }
            return employeeId;
        }
    }
}
