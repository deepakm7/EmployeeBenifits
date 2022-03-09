using EmployeeBenefits.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefits.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context ctx;

        public EmployeeRepository(Context context)
        {
            this.ctx = context;
        }

        public int AddEmployee(string firstName, string lastName, decimal salary)
        {
            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };
            ctx.Employee.Add(employee);
            ctx.SaveChanges();
            return employee.EmployeeId;
        }

        public List<Employee> GetAllEmployees()
        {
            return ctx.Employee.OrderByDescending(x => x.EmployeeId).Take(100).ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            return ctx.Employee.Include(x => x.Dependent).ThenInclude(y => y.DependentType).FirstOrDefault(x => x.EmployeeId == employeeId);
        }
    }
}
