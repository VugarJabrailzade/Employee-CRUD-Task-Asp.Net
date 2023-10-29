using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTask.ViewModel
{
    public abstract class BaseDepartamentViewModel
    {
        [Required(ErrorMessage = "Please enter Name.")]
        public string Name { get; set; }
    }
}
