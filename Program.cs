namespace MainProgram;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose task: \n");
            Console.WriteLine("1. Journal");
            Console.WriteLine("2. Shop");
            Console.WriteLine("3. Book");
            Console.WriteLine("4. Temperature");
            Console.WriteLine("5. Fraction");
            Console.WriteLine("6. Product");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                if (userChoice == 0)
                {
                    Console.WriteLine("\nExitting...");
                    return;
                }
                else if (userChoice == 1)
                {
                    JournalTask.Menu.Run();
                }
                else if (userChoice == 2)
                {
                    ShopTask.Menu.Run();
                }
                else if (userChoice == 3)
                {
                    BookTask.Menu.Run();
                }
                else if (userChoice == 4)
                {
                    TemperatureTask.Menu.Run();
                }
                else if (userChoice == 5)
                {
                    FractionTask.Menu.Run();
                }
                else if (userChoice == 6)
                {
                    ProductTask.Menu.Run();
                }
                else
                {
                    Console.WriteLine("\nInvalid choice! Enter a number between 0-6!");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input! Enter a number!");
            }
        }
    }
}