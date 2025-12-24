using System.Threading.Channels;

namespace MainProgram.ProductTask;
class Menu
{
    static decimal DecimalInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (decimal.TryParse(input, out decimal result))
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
    static string StringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input != null)
            {
                return input;
            }
            Console.WriteLine("\nInvalid input. Please enter a string.");
        }
    }

    static Product ProductInput(string input)
    {
        string name = StringInput($"\nEnter {input} product data: ");
        int quantity = IntInput($"\nEnter {input} quantity: ");
        decimal price = DecimalInput($"\nEnter {input} price: ");

        return new Product(name, quantity, price);
    }

    static void RequireProduct(Product? product)
    {
        if (product == null)
        {
            throw new Exception("Product is not created yet");
        }
    }

    static void RequireBoth(Product? p1, Product? p2)
    {
        if (p1 == null || p2 == null)
        {
            throw new Exception("Both products must be created first");
        }
    }

    public static void Run()
    {
        Product? p1 = null;
        Product? p2 = null;

        while (true)
        {
            Console.WriteLine("\n1. Create first product");
            Console.WriteLine("2. Create second product");
            Console.WriteLine("3. Increase product quantity");
            Console.WriteLine("4. Decrease product quantity");
            Console.WriteLine("5. Compare products by price");
            Console.WriteLine("6. Compare products by quantity (>, <)");
            Console.WriteLine("7. Show products");
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
                        p1 = ProductInput("first");
                        RequireProduct(p1);
                    }
                    else if (userChoice == 2)
                    {
                        p2 = ProductInput("second");
                        RequireProduct(p2);
                    }
                    else if (userChoice == 3)
                    {
                        RequireBoth(p1, p2);
                        Console.WriteLine("\n1. Increase quantity of first product");
                        Console.WriteLine("2. Increase quanitty of second product");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? productInput = Console.ReadLine();

                        if (int.TryParse(productInput, out int productChoice))
                        {
                            if (productChoice == 0)
                            {
                                Console.WriteLine("\nExitting...");
                                break;
                            }
                            else if (productChoice == 1)
                            {
                                int amount = IntInput("\nEnter amount: ");
                                p1 = p1 + amount;
                            }
                            else if (productChoice == 2)
                            {
                                int amount = IntInput("\nEnter amount: ");
                                p2 = p2 + amount;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice! Enter a number between 0-2!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input! Enter a number!");
                        }
                    }
                    else if (userChoice == 4)
                    {
                        RequireBoth(p1, p2);
                        Console.WriteLine("\n1. Decrease quantity of first product");
                        Console.WriteLine("2. Decrease quanitty of second product");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? productInput = Console.ReadLine();

                        if (int.TryParse(productInput, out int productChoice))
                        {
                            if (productChoice == 0)
                            {
                                Console.WriteLine("\nExitting...");
                                break;
                            }
                            else if (productChoice == 1)
                            {
                                int amount = IntInput("\nEnter amount: ");
                                p1 = p1 - amount;
                            }
                            else if (productChoice == 2)
                            {
                                int amount = IntInput("\nEnter amount: ");
                                p2 = p2 - amount;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice! Enter a number between 0-2!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input! Enter a number!");
                        }
                    }
                    else if (userChoice == 5)
                    {
                        RequireBoth(p1, p2);
                        Console.WriteLine($"\nSame price: {p1 == p2}");
                    }
                    else if (userChoice == 6)
                    {
                        RequireBoth(p1, p2);
                        Console.WriteLine($"\np1 > p2: {p1 > p2}");
                        Console.WriteLine($"\np1 < p2: {p1 < p2}");
                    }
                    else if (userChoice == 7)
                    {
                        Console.WriteLine($"\nFirst product: {p1}");
                        Console.WriteLine($"\nSecond product: {p2}");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice! Enter a number between 0-7!");
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
