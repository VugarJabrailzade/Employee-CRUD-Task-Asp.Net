namespace EmployeeCrudTask.Database.DomainModels
{
    public class Departament
    {
        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Departament() { }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
