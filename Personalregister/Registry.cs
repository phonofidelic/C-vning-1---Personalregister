namespace EmployeeRegistry
{
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
        List<Employee> Employees = [];

        public void DisplayAllEmployees()
        {
            Console.WriteLine("\nVisar all personal:");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine($"\tnr. {employee.Id}: {employee.Name} {employee.Salary:C}");
            }
        }

        public Employee GetNewEmployeeInput(AutoIncrement employeeId)
        {
            int id = employeeId.GenerateId();
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lön: ");
            string salaryString = Console.ReadLine();
            decimal salary = decimal.Parse(salaryString);

            return new Employee(id, name, salary);
        }

        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }
    }
}