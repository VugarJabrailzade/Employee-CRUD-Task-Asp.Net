using EmployeeCrudTask.Database.DomainModels;

namespace EmployeeCrudTask.ViewModel
{
    public class EmployeeAddResponseViewModel : BaseEmployeeViewModel
    {
        public List<Departament> Departament {  get; set; }
    }
}
