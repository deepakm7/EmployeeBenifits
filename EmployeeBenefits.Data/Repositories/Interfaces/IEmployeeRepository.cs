using EmployeeBenefits.Data.Model;
using System.Collections.Generic;

namespace EmployeeBenefits.Data
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Add employee information to database
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="salary">Salary</param>
        /// <returns>Integer</returns>
        int AddEmployee(string firstName, string lastName, decimal salary);

        /// <summary>
        /// Get employee information by employee id
        /// </summary>
        /// <param name="employeeId">Employee Id</param>
        /// <returns>Employee information</returns>
        Employee GetEmployee(int employeeId);

        /// <summary>
        /// Get all employees information
        /// </summary>
        /// <returns>Get first 100 employees from database order by most recent first</returns>
        List<Employee> GetAllEmployees();
    }
}
