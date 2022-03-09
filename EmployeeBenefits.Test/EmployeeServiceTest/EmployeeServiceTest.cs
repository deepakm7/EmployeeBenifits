using EmployeeBenefits.Data;
using EmployeeBenefits.Data.Model;
using EmployeeBenefits.Services;
using EmployeeBenifits.Shared;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeBenefits.Test
{
    [TestFixture]
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _employeeMock = new Mock<IEmployeeRepository>();

        public EmployeeServiceTest()
        {
            _employeeService = new EmployeeService(_employeeMock.Object);
        }

        [Test]
        public void EmployeeService_AddEmployee_Test()
        {
            var employeeId = 1;
            var firstName = "John";
            var lastName = "Doe";
            var salary = (decimal)1000;
            var employeeDetail = new EmployeeDetailModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            _employeeMock.Setup(x => x.AddEmployee(firstName, lastName, salary)).Returns(employeeId);

            var returnEmployeeId = _employeeService.AddEmployee(employeeDetail);

            Assert.AreEqual(employeeId, returnEmployeeId);
        }

        [Test]
        public void EmployeeService_GetEmployee_Test()
        {
            var employeeId = 2;
            var firstName = "Jane";
            var lastName = "Doe";
            var salary = (decimal)2000;
            var employeeDetail = new Employee
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            _employeeMock.Setup(x => x.GetEmployee(employeeId)).Returns(employeeDetail);

            var returnEmployeeDetails = _employeeService.GetEmployeeDetails(employeeId);

            Assert.AreEqual(firstName, returnEmployeeDetails.FirstName);
            Assert.AreEqual(lastName, returnEmployeeDetails.LastName);
            Assert.AreEqual(salary, returnEmployeeDetails.Salary);

            Assert.AreNotEqual("Baby", returnEmployeeDetails.FirstName);
            Assert.AreNotEqual("Roe", returnEmployeeDetails.LastName);
            Assert.AreNotEqual(1000, returnEmployeeDetails.Salary);
        }

        [Test]
        public void EmployeeService_GetAllEmployees_Test()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { EmployeeId = 1, FirstName = "John", LastName = "Doe", Salary = 1000 });
            empList.Add(new Employee() { EmployeeId = 2, FirstName = "Jane", LastName = "Duh", Salary = 2000 });
            empList.Add(new Employee() { EmployeeId = 3, FirstName = "Johnny", LastName = "Roe", Salary = 3000 });

            _employeeMock.Setup(x => x.GetAllEmployees()).Returns(empList);

            var returnEmployeeDetails = _employeeService.GetAllEmployeeDetails();

            Assert.AreEqual(empList.Count(), returnEmployeeDetails.Count());

        }
    }
}
