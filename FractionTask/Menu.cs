using System.Runtime.CompilerServices;

namespace MainProgram.FractionTask;
class Menu
{
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

    static Fraction FractionInput(string name)
    {
        Console.WriteLine($"\nEnter {name} fraction:");
        int num = IntInput("\nEnter numerator: ");
        int den = IntInput("\nEnter denominator: ");

        return new Fraction(num, den);
    }

    static void CheckFractions(Fraction? f1, Fraction? f2)
    {
        if (f1 == null || f2 == null)
            throw new Exception("Both fractions must be created first");
    }


    public static void Run()
    {
        Fraction? f1 = null;
        Fraction? f2 = null;

        while (true)
        {
            Console.WriteLine("\n1. Create first fraction");
            Console.WriteLine("2. Create second fraction");
            Console.WriteLine("3. Add fractions");
            Console.WriteLine("4. Subtract fractions");
            Console.WriteLine("5. Multiply fractions");
            Console.WriteLine("6. Divide fractions");
            Console.WriteLine("7. Compare fractions");
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
                        f1 = FractionInput("first");

                        if (f1 != null)
                        {
                            Console.WriteLine("\nSuccesfully created fraction");
                        }
                        else
                        {
                            Console.WriteLine("\nError! Fraction is null! Some options may be locked");
                        }
                    }
                    else if (userChoice == 2)
                    {
                        f2 = FractionInput("second");

                        if (f2 != null)
                        {
                            Console.WriteLine("\nSuccesfully created fraction");
                        }
                        else
                        {
                            Console.WriteLine("\nError! Fraction is null! Some options may be locked");
                        }
                    }
                    else if (userChoice == 3)
                    {
                        CheckFractions(f1, f2);
                        Console.WriteLine($"Result: {f1! + f2!}");
                    }
                    else if (userChoice == 4)
                    {
                        CheckFractions(f1, f2);
                        Console.WriteLine($"Result: {f1! - f2!}");
                    }
                    else if (userChoice == 5)
                    {
                        CheckFractions(f1, f2);
                        Console.WriteLine($"Result: {f1! * f2!}");
                    }
                    else if (userChoice == 6)
                    {
                        CheckFractions(f1, f2);
                        Console.WriteLine($"Result: {f1! / f2!}");
                    }
                    else if (userChoice == 7)
                    {
                        CheckFractions(f1, f2);
                        Console.WriteLine($"Equal: {f1! == f2!}");
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
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex}");
                return;
            }
        }
    }
}
