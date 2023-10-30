using EmployeeCrudTask.Database.Repositeries;

namespace EmployeeCrudTask.CheckingCode
{
    public class EmployeeCodeService
    {

        private readonly EmployeeRepository _repository;
        private const string EmployeeTrackingCode = "E";
        private const int EmployeeTracking_Min = 1000;
        private const int EmployeeTracking_Max = 1000000;

        public EmployeeCodeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public string GenerateRandomCode()
        {
            return $"{EmployeeTrackingCode}{Random.Shared.Next(EmployeeTracking_Min, EmployeeTracking_Max)}";
        }

    }
}
