namespace EmployeeRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
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
                        break;

                    default:
                        Console.WriteLine($"Valet \"{choice}\" finns tyvärr inte.");
                        break;
                }
                Console.WriteLine($"Choice: {choice}");
            } catch
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
    
}