using EmployeeBenifits.Shared;
using System.Collections.Generic;

namespace EmployeeBenefits.Services
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Add employee to database
        /// </summary>
        /// <param name="employeeDetails">Employee Details</param>
        /// <returns>Employee Id</returns>
        int AddEmployee(EmployeeDetailModel employeeDetails);

        /// <summary>
        /// Get employee details by employee id
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Employee Details</returns>
        EmployeeDetailModel GetEmployeeDetails(int employeeId);

        /// <summary>
        /// Get all employee details order by most recent added first
        /// </summary>
        /// <returns>List of employee details</returns>
        List<EmployeeDetailModel> GetAllEmployeeDetails();
    }
}
