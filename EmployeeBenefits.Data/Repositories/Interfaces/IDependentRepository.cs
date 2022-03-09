using EmployeeBenefits.Data.Model;
using System.Collections.Generic;

namespace EmployeeBenefits.Data
{
    public interface IDependentRepository
    {
        /// <summary>
        /// Get all dependents for employee
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>List of dependents</returns>
        List<Dependent> GetDependentsByEmployee(int employeeId);

        /// <summary>
        /// Get all dependent types
        /// </summary>
        /// <returns>List of dependent types</returns>
        List<DependentTypeLkp> GetDependentTypes();

        /// <summary>
        /// Add dependent information to database
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="dependentTypeId">Dependent Type Id</param>
        /// <returns>Integer</returns>
        int AddDependent(int employeeId, string firstName, string lastName, int dependentTypeId);
    }
}
