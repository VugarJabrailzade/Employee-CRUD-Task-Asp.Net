namespace EmployeeCrudTask.Database.DomainModels
{
    public class Employee
    {

        public Employee()
            : this(default, default, default, default, default, default, default, default, default,default)
        {

        }

        

        public Employee(int id, string name, string surname, string fatherName, string finCode, string email, string employeeImg, string employeeCode, int? departamentId, bool isDeleted)
        {
            Id = id;
            Name = name;
            Surname = surname;
            FatherName = fatherName;
            FinCode = finCode;
            Email = email;
            EmployeeImg = employeeImg;
            EmployeeCode = employeeCode;
            DepartamentId = departamentId;
            IsDeleted = isDeleted;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string FinCode { get; set; }
        public string Email { get; set;}
        public string EmployeeImg {  get; set; }
        public string? EmployeeCode { get; set; }
        public int? DepartamentId {  get; set; } 

        public bool IsDeleted { get; set; }


       
    }
}
