using EmployeeCrudTask.Database.DomainModels;
using Npgsql;

namespace EmployeeCrudTask.Database.Repositeries
{
    public class EmployeeRepository : IDisposable
    {
        private readonly NpgsqlConnection _npgsqlConnection;

        public EmployeeRepository()
        {
            _npgsqlConnection = new NpgsqlConnection(DatabaseConstant.Connection_String);
            _npgsqlConnection.Open();
        }

        public List<Employee> GetAll()
        {
            var selectQuery = "SELECT * FROM employee ORDER BY name";

            using NpgsqlCommand command = new NpgsqlCommand(selectQuery, _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();


            List<Employee> employees = new List<Employee>();

            while (dataReader.Read())
            {
                Employee employe = new Employee
                {
                    Id = Convert.ToInt32(dataReader["employee_id"]),
                    Name = Convert.ToString(dataReader["name"]),
                    Surname = Convert.ToString(dataReader["surname"]),
                    FatherName = Convert.ToString(dataReader["father_name"]),
                    FinCode = Convert.ToString(dataReader["fincode"]),
                    Email = Convert.ToString(dataReader["email"]),
                    EmployeeImg = Convert.ToString(dataReader["employeeimg"]),
                    EmployeeCode = Convert.ToString(dataReader["employee_code"]),
                    DepartamentId = Convert.ToInt32(dataReader["departamentid"])

                };

                employees.Add(employe);
            }

            return employees;

        }


        public Employee GetById(int id)
        {
            var selectQuery = $"SELECT * FROM employee WHERE employee_id={id} ORDER BY name";

            using NpgsqlCommand command = new NpgsqlCommand(selectQuery, _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();


            Employee employee = null;

            while (dataReader.Read())
            {
                Employee employe = new Employee
                {
                    Id = Convert.ToInt32(dataReader["employee_id"]),
                    Name = Convert.ToString(dataReader["name"]),
                    Surname = Convert.ToString(dataReader["surname"]),
                    FatherName = Convert.ToString(dataReader["father_name"]),
                    FinCode = Convert.ToString(dataReader["fincode"]),
                    Email = Convert.ToString(dataReader["email"]),
                    EmployeeImg = Convert.ToString(dataReader["employeeimg"]),
                    EmployeeCode = Convert.ToString(dataReader["employee_code"]),
                    DepartamentId = Convert.ToInt32(dataReader["departamentid"])

                };
            }

            return employee;
        }
        
        public void Insert(Employee employee)
        {

        }
        public void Update()
        {
            var updateQuery = $"UPDATE employee SET name=";

        }
        public void DeleteById(int id)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~EmployeeRepository()
        {
            _npgsqlConnection.Dispose();
        }
          
    }
}
