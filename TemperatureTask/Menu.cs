using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainProgram.TemperatureTask;
class Menu
{
    static double DoubleInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double result))
            {
                return result;
            }
            Console.WriteLine("\nInvalid input. Please enter a number.");
        }
    }
    static int IntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            Console.WriteLine("\nInvalid input. Please enter a number.");
        }
    }

    static void SetTemperature(Temperature temps)
    {
        int day = IntInput("\nEnter the number of a day (0–6): ");
        double value = DoubleInput("\nEnter the temperature: ");

        temps[day] = value;
        Console.WriteLine("\nTemperature saved.");
    }

    static void GetTemperature(Temperature temps)
    {
        int day = IntInput("\nEnter the number of a day (0-6): ");

        Console.WriteLine($"\nTemperature: {temps[day]}");
    }

    public static void Run()
    {
        Temperature temps = new Temperature();

        while (true)
        {
            Console.WriteLine("\n1. Enter temperature for day");
            Console.WriteLine("2. Get temperature of a day");
            Console.WriteLine("3. Show all temperatures");
            Console.WriteLine("4. Average temperature");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            try
            {
                if (int.TryParse(input, out int userChoice))
                {
                    if (userChoice == 0)
                    {
                        Console.WriteLine("\nExitting...");
                        break;
                    }
                    else if (userChoice == 1)
                    {
                        SetTemperature(temps);
                    }
                    else if (userChoice == 2)
                    {
                        GetTemperature(temps);
                    }
                    else if (userChoice == 3)
                    {
                        temps.ShowAll();
                    }
                    else if (userChoice == 4)
                    {
                        Console.WriteLine($"\nAverage temprature: {temps.GetAverageTemperature()}");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice! Enter a number between 0-4!");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Enter a number!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex}");
                return;
            }
        }
    }
}
