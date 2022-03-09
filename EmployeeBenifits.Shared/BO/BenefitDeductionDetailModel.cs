using System.ComponentModel.DataAnnotations;

namespace EmployeeBenifits.Shared
{
    public class BenefitDeductionDetailModel
    {

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalSalaryPerPayCheckBeforeBenifit { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EmployeeBenifitPerPaycheck { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalDependentsBenifitPerPayCheck { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalSalaryPerPayCheckAfterBenifit { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EmployeeBenifitPerYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalDependentsBenifitPerYear { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalSalaryPerYearAfterBenifit { get; set; }

        public EmployeeDetailModel EmployeeDetails { get; set; }
    }
}
