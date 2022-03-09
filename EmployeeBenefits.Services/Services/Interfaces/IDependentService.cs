using EmployeeBenifits.Shared;
using System.Collections.Generic;

namespace EmployeeBenefits.Services
{
    public interface IDependentService
    {
        /// <summary>
        /// Get all dependent types
        /// </summary>
        /// <returns>List of dependent types</returns>
        List<DependentTypeModel> GetDependentTypes();

        /// <summary>
        /// Add dependent information to database
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <param name="dependentDetails">Dependent Details</param>
        /// <returns>Employee Id</returns>
        int AddEmployeeDependents(int employeeId, List<DependentDetailModel> dependentDetails);

        /// <summary>
        /// Get each employee dependent information
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>List of dependent details</returns>
        List<DependentDetailModel> GetDependents(int employeeId);
    }
}
