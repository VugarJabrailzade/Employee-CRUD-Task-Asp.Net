namespace EmployeeCrudTask.ViewModel
{
    public class EmployeePageViewModel
    {
        public EmployeePageViewModel(int id, string name, string surname, string fatherName, string emloyeeCode)
        {
            Id = id;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            EmloyeeCode = emloyeeCode;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string EmloyeeCode { get; set; }
    }
}
