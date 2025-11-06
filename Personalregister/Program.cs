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
                .RuleFor(u => u.Name, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(u => u.Salary, f => f.Finance.Amount(10000, 80000));
            var employees = testEmployees.Generate(3);


            Registry registry = new(employees.ToArray());

            MenuActionType? choice;

            do
            {
                registry.DisplayMenu();
                choice = registry.GetMenuInput();

                try
                {

                    switch (choice)
                    {
                        case MenuActionType.AddEmployee:
                            registry.AddEmployee(registry.GetNewEmployeeInput(employeeId));
                            break;

                        case MenuActionType.DisplayRegistry:
                            registry.DisplayAllEmployees();
                            Console.ReadKey();
                            choice = null;
                            break;

                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine($"Ett fel inträffade.");
                    Environment.Exit(0);
                }
            } while (choice == null);

        }
    }
}