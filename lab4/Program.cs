namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Available Commands:");
                Console.WriteLine("1. display program version and author.");
                Console.WriteLine("2. run a lab task.");
                Console.WriteLine("3. exit");

                string[] input = Console.ReadLine().Split(' ');
                string command = input[0].ToLower();

                switch (command)
                {
                    case "1":
                        DisplayVersionInfo();
                        break;
                    case "2":
                        ExecuteLabTask(input);
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"Unknown command: {command}");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DisplayVersionInfo()
        {
            Console.WriteLine("Version 1.0.0");
            Console.WriteLine("Konstantyi Rostyslav");
        }

        static void ExecuteLabTask(string[] args)
        {
            string subcommand = GetParameter(args, "run");

            if (string.IsNullOrEmpty(subcommand))
            {
                Console.WriteLine("lab1 or lab2.");
                subcommand = Console.ReadLine().ToLower();
            }

            try
            {
                switch (subcommand.ToLower())
                {
                    case "lab1":
                        library.Class1.Main();
                        break;
                    case "lab2":
                        library.Class2.ProcessStrings();
                        break;
                    default:
                        Console.WriteLine($"unknown subcommand");
                        break;
                }

                Console.WriteLine($"lab task completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"an error occurred: {ex.Message}");
            }
        }


        static string GetParameter(string[] args, string paramName)
        {
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (args[i].Equals(paramName, StringComparison.OrdinalIgnoreCase))
                {
                    return args[i + 1];
                }
            }
            return null;
        }
    }
}