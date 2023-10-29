namespace EmployeeCrudTask.ViewModel
{
    public class EmployeeAddRequestViewModel
    {
        public EmployeeAddRequestViewModel(string name, string surname, string fatherName, string finCode, string email, string employeeImg, string employeeCode, int? departamentId)
        {
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            FinCode = finCode;
            Email = email;
            EmployeeImg = employeeImg;
            EmployeeCode = employeeCode;
            DepartamentId = departamentId;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string FinCode { get; set; }
        public string Email { get; set; }
        public string EmployeeImg { get; set; }
        public string EmployeeCode { get; set; }
        public int? DepartamentId { get; set; }
    }
}
