using Bogus;
using Newtonsoft.Json;

namespace EmployeeRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoIncrement employeeId = new();
            // Set up initial state
            var testEmployees = new Faker<Employee>()
                .RuleFor(u => u.Id, f => employeeId.GenerateId())
                .RuleFor(u => u.Name, f => f.Person.Name)
                .RuleFor(u => u.Salary, f => f.Finance.Amount(10000, 80000));
            var employees = testEmployees.Generate(3);
            
            foreach(var employee in employees)
            {
                Console.WriteLine($"Employe #{employee.Id}: {employee.Name}");
            }
            Registry registry = new(employees.ToArray());

            Console.WriteLine("Välkommen till personalregistret. Välj en funktion från menyn:\n");
            Console.WriteLine("\t1) Lägg till ny personal");
            Console.WriteLine("\t2) Visa registret");
            var rawChoice = Console.ReadLine();
            if (rawChoice?.Length < 1)
            {
                Console.WriteLine("Inget val lästes in. Avslutar...");
                Environment.Exit(0);
            }

            ActionType choice;
            try
            {
                choice = Enum.Parse<ActionType>(rawChoice);
                switch (choice)
                {
                    case ActionType.AddEmployee:
                        break;

                    case ActionType.DisplayRegistry:
                        registry.DisplayAllEmployees();
                        break;

                    default:
                        Console.WriteLine($"Valet \"{choice}\" finns tyvärr inte.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine($"Ett fel inträffade.");
                Environment.Exit(0);
            }
        }
    }

    enum ActionType
    {
        AddEmployee = 1,
        DisplayRegistry = 2
    }

    class Registry
    {
        public Registry()
        {
            
        }
        public Registry(Employee[] initialEmployees)
        {
            foreach (var employee in initialEmployees)
            {
                Employees.Add(new Employee(
                    employee.Id,

                    employee.Name,

                    employee.Salary
                ));
            }
        }
        List<Employee> Employees = [new Employee(1, "John Doe", 35000)];

        public void DisplayAllEmployees()
        {
            Console.WriteLine("\nVisar all personal:");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine($"\tnr. {employee.Id}: {employee.Name}");
            }
        }
    }

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
    }

    public class AutoIncrement
    {
        private int Id;
        public AutoIncrement()
        {
            Id = 1;
        }
        public AutoIncrement(int initialValue)
        {
            Id = initialValue;
        }
        public int GenerateId()
        {
            return Id++;
        }
    }
}