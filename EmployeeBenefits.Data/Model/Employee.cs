using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefits.Data.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Dependent = new HashSet<Dependent>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<Dependent> Dependent { get; set; }
    }
}
