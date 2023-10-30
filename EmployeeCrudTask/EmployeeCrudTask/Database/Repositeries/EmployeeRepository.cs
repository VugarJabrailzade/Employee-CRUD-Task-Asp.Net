using EmployeeCrudTask.Database.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Collections.Generic;

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
                    IsDeleted = Convert.ToBoolean(dataReader["isdeleted"])
                   
                };

                employees.Add(employe);
            }

            return employees;

        }

        public List<Employee> GetAllWithDepartaments()
        {
            var query = $"SELECT e.\"employee_id\" employeeId, e.\"name\", e.\"surname\", e.\"father_name\", e.\"fincode\", e.\"email\", e.\"employeecode\", e.\"employee_img\", e.\"departamentid\" FROM employee as e \r\nLEFT JOIN departament d ON d.\"departament_id\" = e.\"departamentid\" \r\nWHERE e.\"isdeleted\" = 'false'\r\nORDER BY e.name;";


            using NpgsqlCommand command = new NpgsqlCommand(query, _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();


            while (dataReader.Read())
            {
                Employee employe = new Employee
                {
                    EmployeeCode = Convert.ToString(dataReader["employeecode"]),
                    Name = Convert.ToString(dataReader["name"]),
                    Surname = Convert.ToString(dataReader["surname"]),
                    FatherName = Convert.ToString(dataReader["father_name"]),
                    DepartamentId = Convert.ToInt32(dataReader["departamentid"]),
                };

                employees.Add(employe);
            }

            return employees;
        }




        public Employee GetByEmployeeCode(string employeeCode)
        {
            
            var query = $"SELECT employee_id,name,surname,father_name,fincode,email,employee_img,employeecode,departamentid FROM employee\r\nWHERE employeecode = '{employeeCode}'";

            using NpgsqlCommand command = new NpgsqlCommand(query, _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();


            Employee employee = new Employee();

            while (dataReader.Read())
            {
                employee = new Employee
                {
                    Id = Convert.ToInt32(dataReader["employee_id"]),
                    Name = Convert.ToString(dataReader["name"]),
                    Surname = Convert.ToString(dataReader["surname"]),
                    FatherName = Convert.ToString(dataReader["father_name"]),
                    FinCode = Convert.ToString(dataReader["fincode"]),
                    Email = Convert.ToString(dataReader["email"]),
                    EmployeeImg = Convert.ToString(dataReader["employee_img"]),
                    EmployeeCode = Convert.ToString(dataReader["employeecode"]),
                    DepartamentId = Convert.ToInt32(dataReader["departamentid"])
                    
                    
                };
            }

            return employee;
        }
        
        public void Insert(Employee employee)
        {
            var query = $"INSERT INTO employee(name,surname,father_name,fincode,email,employeecode,employee_img,departamentid,isdeleted)\r\nVALUES " +
                $"('{employee.Name}','{employee.Surname}','{employee.FatherName}','{employee.FinCode}','{employee.Email}','{employee.EmployeeCode}','{employee.EmployeeImg}',{employee.DepartamentId},'{employee.IsDeleted}')";


            using NpgsqlCommand insertQuery = new NpgsqlCommand(query, _npgsqlConnection);
            insertQuery.ExecuteNonQuery();


        }
        public void Update(Employee employee)
        {

            var selectQuery = $"UPDATE employee\r\nSET name='{employee.Name}',surname='{employee.Surname}'," +
                                $"father_name='{employee.FatherName}',fincode='{employee.FinCode}',email='{employee.Email}'," +
                                $"employee_img='{employee.EmployeeImg}',departamentid='{employee.DepartamentId}'\r\nWHERE employeecode='{employee.EmployeeCode}'";

            using NpgsqlCommand command = new NpgsqlCommand(selectQuery, _npgsqlConnection);
            command.ExecuteNonQuery();


        }
        public void DeleteByEmployeeCode(string employeeCode)
        {
            var query = $"DELETE FROM employee WHERE employeecode = '{employeeCode}'";
            using NpgsqlCommand command = new NpgsqlCommand(query , _npgsqlConnection);
            command.ExecuteNonQuery();


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
