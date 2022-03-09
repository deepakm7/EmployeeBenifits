using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeBenefits.Services;
using EmployeeBenifits.Shared;

namespace EmployeeBenifits.Web.Pages.Employee
{
    public class EmployeeModel : BaseModel
    {
        private readonly IEmployeeService employeeService;
        private readonly IAppSettings appSettings;

        [BindProperty]
        public EmployeeDetailModel DetailModel { get; set; }
        public List<SelectListItem> DependentsCount { get; } = new List<SelectListItem>();

        public EmployeeModel(IEmployeeService employeeService, IAppSettings appSettings)
        {
            this.employeeService = employeeService;
            this.appSettings = appSettings;
        }
                
        public void OnGet(int id)
        {  
            GetDependentsListCount();
            DetailModel = new EmployeeDetailModel { EmployeeId = id, Dependents = new List<DependentDetailModel>() };
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employeeId = employeeService.AddEmployee(DetailModel);
            if (DetailModel.NumberofDependents == 0)
                return RedirectToPage("/employee/results", new { id = employeeId });

            return RedirectToPage("/employee/dependent", new { id = employeeId, dependentCount = DetailModel.NumberofDependents });
        }

        #region "Private Methods"
        private void GetDependentsListCount()
        {
            for (var i = 0; i <= appSettings.DependentsCount; i++)
            {
                DependentsCount.Add(new SelectListItem(i.ToString(), i.ToString()));
            }
        }

        #endregion


    }
}
