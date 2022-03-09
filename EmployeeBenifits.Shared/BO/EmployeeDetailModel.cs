using EmployeeBenefits.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmployeeBenifits.Shared
{
    public class EmployeeDetailModel : PersonDetailModel
    {
     
        public EmployeeDetailModel() { }
        public EmployeeDetailModel(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Salary = employee.Salary;
            NumberofDependents = employee.Dependent.Count();
        }
        public int EmployeeId { get; set; }

        [Display(Name = "Number of Dependents")]
        [Required(ErrorMessage = "Select number of dependents")]
        public int? NumberofDependents { get; set; }

        [Display(Name = "Salary")]
        [Range(1, 100000, ErrorMessage = "Salary must be between 1 to 100000")]
        [Required(ErrorMessage = "Salary is required")]
        public decimal? Salary { get; set; }

        public List<DependentDetailModel> Dependents { get; set; }

    }
}
