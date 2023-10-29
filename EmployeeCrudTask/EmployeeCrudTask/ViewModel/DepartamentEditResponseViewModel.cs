using EmployeeCrudTask.Database.DomainModels;

namespace EmployeeCrudTask.ViewModel
{
    public class DepartamentEditResponseViewModel : BaseDepartamentViewModel
    {
        public int Id { get; set; }
        public List<Departament> Departament {  get; set; }
    }
}
