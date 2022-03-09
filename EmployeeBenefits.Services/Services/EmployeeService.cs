using EmployeeBenefits.Data;
using EmployeeBenefits.Data.Model;
using EmployeeBenifits.Shared;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefits.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public int AddEmployee(EmployeeDetailModel employeeDetails)
        {
            if (employeeDetails == null)
                return 0;
            return employeeRepository.AddEmployee(employeeDetails.FirstName, employeeDetails.LastName, employeeDetails.Salary ?? 0);
        }

        public EmployeeDetailModel GetEmployeeDetails(int employeeId)
        {
            if (employeeId == 0)
                return new EmployeeDetailModel();

            Employee employee = employeeRepository.GetEmployee(employeeId);

            if (employee == null)
                return new EmployeeDetailModel();

            EmployeeDetailModel employeeDetailModel = new EmployeeDetailModel(employee);

            if (employee.Dependent.Count() > 0)
            {
                employeeDetailModel.Dependents = new List<DependentDetailModel>();

                foreach (Dependent eachDependent in employee.Dependent)
                {
                    employeeDetailModel.Dependents.Add(new DependentDetailModel(eachDependent));
                }
            }
            return employeeDetailModel;
        }

        public List<EmployeeDetailModel> GetAllEmployeeDetails()
        {
            return employeeRepository.GetAllEmployees().Select(x => new EmployeeDetailModel
            {
                EmployeeId = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Salary = x.Salary
            }).ToList();
        }
    }
}
