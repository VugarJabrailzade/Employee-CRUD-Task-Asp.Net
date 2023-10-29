using EmployeeCrudTask.Database.DomainModels;
using Npgsql;

namespace EmployeeCrudTask.Database.Repositeries
{
    public class DepartamentRepository : IDisposable
    {
        private readonly NpgsqlConnection _npgsqlConnection;

        public DepartamentRepository()
        {
            _npgsqlConnection = new NpgsqlConnection(DatabaseConstant.Connection_String);
            _npgsqlConnection.Open();

        }

        public List<Departament> GetAll()
        {
            var selectQuery = "SELECT * FROM departament ORDER BY departament_name";

            using NpgsqlCommand command = new NpgsqlCommand(selectQuery, _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();

            List<Departament> departaments = new List<Departament>();

            while (dataReader.Read())
            {
                Departament departament = new Departament
                {
                    Id = Convert.ToInt32(dataReader["departament_id"]),
                    Name = Convert.ToString(dataReader["departament_name"]),
                };

                departaments.Add(departament);

            }
            return departaments;
        }

        public Departament GetById(int id)
        {
            using NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM departament WHERE departament_id={id}", _npgsqlConnection);
            using NpgsqlDataReader dataReader = command.ExecuteReader();

            Departament departament = null;

            while (dataReader.Read())
            {
                departament = new Departament
                {
                    Id = Convert.ToInt32(dataReader["departament_id"]),
                    Name = Convert.ToString(dataReader["departament_name"]),
                };
            }

            return departament;

        }


        public void InsertDepartament(Departament departament)
        {

            var insertQuery = $"INSERT INTO departament(departament_name)" +
                              $"VALUES ('{departament.Name}')";

            using NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, _npgsqlConnection);
            insertCommand.ExecuteNonQuery();

        }

        public void UpdateDepartament(Departament departament)
        {
            var updatequery = $"UPDATE departament " +
                              $"SET departament_name = '{departament.Name}'" +
                              $" WHERE departament_id = {departament.Id}";



            using NpgsqlCommand updateCommand = new NpgsqlCommand(updatequery, _npgsqlConnection);
            updateCommand.ExecuteNonQuery();

        }

        public void DeleteDepartament(int id)
        {
            var query = $"DELETE FROM departament WHERE departament_id = {id}";
            using NpgsqlCommand deleteCommand = new NpgsqlCommand(query, _npgsqlConnection); 
            deleteCommand.ExecuteNonQuery();
        }

        public void Dispose()
        {
            _npgsqlConnection.Dispose();
        }
    }
}
