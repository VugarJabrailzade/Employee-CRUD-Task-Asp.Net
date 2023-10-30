namespace EmployeeCrudTask.ViewModel
{
    public class EmployeePageViewModel
    {
        public EmployeePageViewModel()
        {
        }

        public EmployeePageViewModel( string name, string surname, string fatherName, string emloyeeCode, int? departamentId)
        {
            
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            EmloyeeCode = emloyeeCode;
            DepartamentId = departamentId;
        }

        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string EmloyeeCode { get; set; }
        public int? DepartamentId { get; set; }
    }
}
