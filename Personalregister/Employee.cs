
namespace EmployeeRegistry
{
    class Employee
    {
        public Employee()
        {
            
        }
        public Employee(int id, string name, decimal salary = 0)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"\t#{Id}: {Name} {Salary:C}";
        }
    }
}