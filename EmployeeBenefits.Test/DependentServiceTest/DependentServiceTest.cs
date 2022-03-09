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
    public class DependentServiceTest
    {
        private readonly DependentService _dependentService;
        private readonly Mock<IDependentRepository> _dependentMock = new Mock<IDependentRepository>();

        public DependentServiceTest()
        {
            _dependentService = new DependentService(_dependentMock.Object);
        }

        [Test]
        public void DependentService_AddDependent_Test()
        {
            var employeeId = 1;
            var dependentfirstName = "Jane";
            var dependentlastName = "Doe";
            var dependentTypeId = 1;
            var dependentId = 1;

            List<DependentDetailModel> dependentDetails = new List<DependentDetailModel>();
            dependentDetails.Add(new DependentDetailModel(new Dependent() { DependentId = dependentId, EmployeeId = employeeId, FirstName = dependentfirstName, LastName = dependentlastName, DependentTypeId = dependentTypeId }));

            _dependentMock.Setup(x => x.AddDependent(employeeId, dependentfirstName, dependentlastName, dependentTypeId)).Returns(dependentId);

            var returnDependentDetails = _dependentService.AddEmployeeDependents(employeeId, dependentDetails);

            Assert.AreEqual(returnDependentDetails, employeeId);
        }

        [Test]
        public void DependentService_GetDependentTypes_Test()
        {

            List<DependentTypeLkp> dependentTypes = new List<DependentTypeLkp>();
            dependentTypes.Add(new DependentTypeLkp() { DependentTypeId = 1, DependentTypeName = "Child", Obsolete = false });
            dependentTypes.Add(new DependentTypeLkp() { DependentTypeId = 2, DependentTypeName = "Spouse", Obsolete = false });

            _dependentMock.Setup(x => x.GetDependentTypes()).Returns(dependentTypes);

            var returnDependentTypes = _dependentService.GetDependentTypes();

            Assert.AreEqual(dependentTypes.Count(), returnDependentTypes.Count());
        }

        [Test]
        public void DependentService_GetDependent_Test()
        {
            DependentTypeLkp dependentType = new DependentTypeLkp();
            dependentType.DependentTypeId = 1;
            dependentType.DependentTypeName = "Child";
            dependentType.Obsolete = false;
            Employee emp = new Employee();
            emp.EmployeeId = 1;
            emp.FirstName = "John";
            emp.LastName = "Doe";
            emp.Salary = (decimal)1000;


            List<Dependent> dependents = new List<Dependent>();
            Dependent newDependent = new Dependent();
            newDependent.DependentId = 1;
            newDependent.DependentType = dependentType;
            newDependent.Employee = emp;
            newDependent.FirstName = "Baby";
            newDependent.LastName = "Doe";
            dependents.Add(newDependent);

            _dependentMock.Setup(x => x.GetDependentsByEmployee(emp.EmployeeId)).Returns(dependents);

            var returnDependentTypes = _dependentService.GetDependents(emp.EmployeeId);

            Assert.AreEqual(returnDependentTypes.Count(), dependents.Count());


        }
    }
}
