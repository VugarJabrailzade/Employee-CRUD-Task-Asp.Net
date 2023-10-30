using EmployeeCrudTask.Database.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTask.ViewModel
{
    public class BaseEmployeeViewModel
    {


        [StringLength(7, MinimumLength = 3)]
        [Required(ErrorMessage ="Please enter name")]
        public string Name { get; set; }

        [StringLength(7, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter Surname.")]
        public string Surname { get; set; }

        [StringLength(7, MinimumLength = 3)]
        [Required(ErrorMessage = "Please enter Father name.")]
        public string FatherName { get; set; }

        [Required]
        [Range(1, 7, ErrorMessage = "Please enter Fin Code.")]
        [RegularExpression("^([A-Z0-9]{7})$", ErrorMessage = "Invalid PhinCode")]
        public string Fincode { get; set; }

        [EmailAddress(ErrorMessage = "Please enter Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please add your Image.")]
        public string Employeeimg { get; set; }

        [Range(1,20,ErrorMessage = "Please select Departament.")]
        public int? DepartamentId { get; set; }

        public List<Departament> Departaments { get; set; }


    }
}
