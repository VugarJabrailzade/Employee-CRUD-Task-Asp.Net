using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTask.ViewModel
{
    public class BaseEmployeeViewModel
    {
        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Surname.")]
        public decimal Surname { get; set; }

        [Required(ErrorMessage = "Please enter Father name.")]
        public string FatherName { get; set; }

        public string EmployeeCode { get; set; }
    }
}
