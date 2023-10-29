using EmployeeCrudTask.Database.DomainModels;

namespace EmployeeCrudTask.ViewModel
{
    public class DepartamentAddRequestViewModel : BaseDepartamentViewModel
    {
        public int id { get; set; }
        public List<Departament> Departaments { get; set; }
    }
}
