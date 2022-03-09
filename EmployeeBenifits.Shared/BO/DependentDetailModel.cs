using EmployeeBenefits.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBenifits.Shared
{
    public class DependentDetailModel : PersonDetailModel
    {
        public DependentDetailModel()
        {

        }

        public DependentDetailModel(Dependent dependent)
        {
            DependentId = dependent.DependentId;            
            FirstName = dependent.FirstName;
            LastName = dependent.LastName;
            DependentType = dependent.DependentType?.DependentTypeName;
            DependentTypeId = dependent.DependentTypeId;
        }

        public int DependentId { get; set; }

        public string DependentType { get; set; }

        [Display(Name = "Dependent Type")]
        [Required(ErrorMessage = "Select dependent type")]
        public int? DependentTypeId { get; set; }
    }
}
