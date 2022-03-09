using EmployeeBenefits.Services;
using EmployeeBenifits.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenifits.Web.Pages.Employee
{
    public class ResultsModel : BaseModel
    {
        private readonly IBenefitDeductionService benefitDeductionService;
        private readonly IEmployeeService employeeService;

        public ResultsModel(IBenefitDeductionService benefitDeductionService, IEmployeeService employeeService)
        {
            this.benefitDeductionService = benefitDeductionService;
            this.employeeService = employeeService;
        }

        public void OnGet(int id)
        {
            DetailModel = this.benefitDeductionService.CalculateBenefitDeduction(id);
            DetailModel.EmployeeDetails = this.employeeService.GetEmployeeDetails(id);
        }

        [BindProperty]
        public BenefitDeductionDetailModel DetailModel { get; set; }
    }
}
