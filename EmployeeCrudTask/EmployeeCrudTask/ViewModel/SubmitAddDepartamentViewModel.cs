namespace EmployeeCrudTask.ViewModel
{
    public class SubmitAddDepartamentViewModel
    {

        public SubmitAddDepartamentViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public SubmitAddDepartamentViewModel() { }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
