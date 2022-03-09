using System.Collections.Generic;
using EmployeeBenefits.Services;
using EmployeeBenifits.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeBenifits.Web.Pages.Employee
{
    public class DependentModel : PageModel
    {
        private readonly IDependentService dependentService;
        public List<SelectListItem> DependentTypeList { get; } = new List<SelectListItem>();

        [BindProperty]
        public List<DependentDetailModel> DetailModel { get; set; }

        [BindProperty]
        public int EmployeeId { get; set; }

        public DependentModel(IDependentService dependentService)
        {
            this.dependentService = dependentService;
        }

        public void OnGet(int id, int dependentCount)
        {
            DetailModel = new List<DependentDetailModel>();
            EmployeeId = id;
            PopulateDependentTypes();

            for (int i = 0; i <= dependentCount - 1; i++)
            {
                DetailModel.Add(new DependentDetailModel());
            }
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            dependentService.AddEmployeeDependents(EmployeeId, DetailModel);
            return RedirectToPage("/employee/results", new { id = EmployeeId });
        }

        #region "Private Methods"
        private void PopulateDependentTypes()
        {
            List<DependentTypeModel> dependentTypes = this.dependentService.GetDependentTypes();
            foreach (var value in dependentTypes)
            {
                DependentTypeList.Add(new SelectListItem(value.DependentTypeName, value.DependentTypeId.ToString()));
            }
        }
        #endregion
    }
}
