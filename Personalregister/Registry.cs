namespace EmployeeRegistry
{
    class Registry
    {
        public Registry() {}
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

        private string? ErrorMessage = null;
        private readonly List<Employee> Employees = [];

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\nVälkommen till personalregistret. Välj en funktion från menyn:\n");
            Console.WriteLine("\t1) Lägg till ny personal");
            Console.WriteLine("\t2) Visa registret");
            Console.WriteLine("\n\t\"Q\" för att avsluta.");
            if (ErrorMessage != null)
                DisplayErrorMessage(ErrorMessage);
        }

        public MenuActionType? GetMenuInput()
        {
            SetErrorMessage();
            var rawInput = Console.ReadKey(true).KeyChar.ToString();
            if (rawInput == "q")
            {
                Environment.Exit(0);
            }
            MenuActionType action;

            try
            {
                action = ParseMenuInput(rawInput ?? "");
                return action;
            }
            catch
            {
                // TODO: add error logging
                SetErrorMessage($"\n\"{rawInput}\" är inte ett giltigt val. \nFörsök igen, eller avsluta med \"Q\"\n");
            }

            return null;
        }

        private MenuActionType ParseMenuInput(string input)
        {
            bool isValidInput = ValidateMenuInput(input);
            if (!isValidInput)
                throw new Exception("Invalid input");

            return Enum.Parse<MenuActionType>(input);
        }

        private static bool ValidateMenuInput(string input)
        {
            if (input == null)
                return false;

            if (input.Length != 1)
                return false;

            if (int.Parse(input) > Enum.GetValues<MenuActionType>().Length)
                return false;

            return Enum.TryParse<MenuActionType>(input, true, out _);
        }

        private static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
            
        }

        private void SetErrorMessage()
        {
            ErrorMessage = null;
        }
        private void SetErrorMessage(string message)
        {
            ErrorMessage = message;
        }

        public void DisplayAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("\nVisar all personal:\n");
            var employees = GetEmployees();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine("");
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn");
        }

        private IEnumerable<Employee> GetEmployees()
        {
            return Employees;
        }

        public Employee GetNewEmployeeInput(AutoIncrement employeeId)
        {
            int id = employeeId.GenerateId();
            Console.Write("Namn: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Lön: ");
            string salaryString = Console.ReadLine() ?? "";
            decimal salary = decimal.Parse(salaryString);

            return new Employee(id, name, salary);
        }

        public void AddEmployee(Employee newEmployee)
        {
            try
            {
                Console.Clear();
                Employees.Add(newEmployee);
                Console.WriteLine($"{newEmployee.Name} är nu med i registret.");
                Console.WriteLine("Tryck valfri tangent för att återgå till huvudmenyn.");
                Console.ReadLine();
                DisplayMenu();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine($"Det gick inte att lägga till {newEmployee.Name}.");
                Console.WriteLine("Tryck valfri tangent för att återgå till huvudmenyn.");
                Console.ReadLine();
                DisplayMenu();
            }
        }

    }

    enum MenuActionType
    {
        AddEmployee = 1,
        DisplayRegistry = 2
    }
}