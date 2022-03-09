using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeBenefits.Data.Model
{
    public partial class Dependent
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DependentTypeId { get; set; }

        public virtual DependentTypeLkp DependentType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
