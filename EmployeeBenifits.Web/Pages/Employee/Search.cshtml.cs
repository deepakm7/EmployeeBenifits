using EmployeeBenefits.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeBenifits.Web.Pages.Employee
{
    public class SearchModel : PageModel
    {
        private readonly IEmployeeService employeeService;

        public SearchModel(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public void OnGet()
        {
        }
       
        public JsonResult OnGetList()
        {
            return new JsonResult(employeeService.GetAllEmployeeDetails());
        }
    }
}
