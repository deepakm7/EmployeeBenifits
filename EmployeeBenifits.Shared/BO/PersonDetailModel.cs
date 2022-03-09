using System.ComponentModel.DataAnnotations;

namespace EmployeeBenifits.Shared
{
    public class PersonDetailModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
