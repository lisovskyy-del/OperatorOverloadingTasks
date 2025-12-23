using MainProgram.JournalTask;

namespace MainProgram.ShopTask;
class Menu
{
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

    private static Shop ShopInput()
    {
        string name = StringInput("\nEnter name: ");
        string adress = StringInput("\nEnter adress: ");
        string description = StringInput("\nEnter description: ");
        string phone = StringInput("\nEnter phone (ex. +3801234567): ");
        string email = StringInput("\nEnter email (ex. lisdel@gmail.com): ");
        int storeArea = IntInput("\nEnter the store area: ");

        return new Shop(name, adress, description, phone, email, storeArea);
    }

    public static void Run()
    {
        Shop? shop = null;
        Shop? otherShop = null;

        while (true)
        {
            Console.WriteLine("\n1. Create a shop");
            Console.WriteLine("2. Create a second shop");
            Console.WriteLine("3. Increase the store area of a shop");
            Console.WriteLine("4. Decrease the store area of a shop");
            Console.WriteLine("5. Check for pair of shops");
            Console.WriteLine("6. Compare two shops");
            Console.WriteLine("7. Display shops");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();


            try
            {
                if (int.TryParse(input, out int userChoice))
                {
                    if (userChoice == 0)
                    {
                        Console.WriteLine("\nExitting..");
                        break;
                    }
                    else if (userChoice == 1)
                    {
                        shop = ShopInput();

                        if (shop != null)
                        {
                            Console.WriteLine("\nShop created!");
                        }
                        else
                        {
                            Console.WriteLine("\nWarning. Shop is empty. Some options may be locked.");
                        }
                    }
                    else if (userChoice == 2)
                    {
                        otherShop = ShopInput();

                        if (otherShop != null)
                        {
                            Console.WriteLine("\nShop created!");
                        }
                        else
                        {
                            Console.WriteLine("\nWarning. Shop is empty. Some options may be locked.");
                        }
                    }
                    else if (userChoice == 3)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n1. Increase the store area of the first shop");
                            Console.WriteLine("2. Increase the store area of the second shop");
                            Console.WriteLine("0. Exit");
                            Console.Write("Your choice: ");
                            string? storeInput = Console.ReadLine();

                            if (int.TryParse(storeInput, out int storeChoice))
                            {
                                if (storeChoice == 0)
                                {
                                    Console.WriteLine("\nExitting..");
                                    break;
                                }
                                else if (storeChoice == 1)
                                {
                                    int value = IntInput("Enter a number: ");

                                    if (shop != null && value > 0)
                                    {
                                        shop += value;
                                        Console.WriteLine($"\nIncreased store area by {value}!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nShop is null or value is less than 0! Cannot increase!");
                                    }
                                }
                                else if (storeChoice == 2)
                                {
                                    int value = IntInput("Enter a number: ");

                                    if (otherShop != null && value > 0)
                                    {
                                        otherShop += value;
                                        Console.WriteLine($"\nIncreased store area by {value}!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nShop is null or value is less than 0! Cannot increase!");
                                    }
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
                    }
                    else if (userChoice == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n1. Decrease the store area of the first shop");
                            Console.WriteLine("2. Decrease the store area of the second shop");
                            Console.WriteLine("0. Exit");
                            Console.Write("Your choice: ");
                            string? storeInput = Console.ReadLine();

                            if (int.TryParse(storeInput, out int storeChoice))
                            {
                                if (storeChoice == 0)
                                {
                                    Console.WriteLine("\nExitting..");
                                    break;
                                }
                                else if (storeChoice == 1)
                                {
                                    int value = IntInput("Enter a number: ");

                                    if (shop != null && value > 0)
                                    {
                                        shop -= value;
                                        Console.WriteLine($"\nDecreased store area by {value}!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nShop is null or value is less than 0! Cannot Decrease!");
                                    }
                                }
                                else if (storeChoice == 2)
                                {
                                    int value = IntInput("Enter a number: ");

                                    if (otherShop != null && value > 0)
                                    {
                                        otherShop -= value;
                                        Console.WriteLine($"\nDecreased store area by {value}!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nShop is null or value is less than 0! Cannot Decrease!");
                                    }
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
                    }
                    else if (userChoice == 5)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n1. Check if store area of both shops are equal");
                            Console.WriteLine("2. Check if store area of both shops are not equal");
                            Console.WriteLine("0. Exit");
                            Console.Write("Your choice: ");
                            string? storeInput = Console.ReadLine();

                            if (int.TryParse(storeInput, out int storeChoice))
                            {
                                if (storeChoice == 0)
                                {
                                    Console.WriteLine("\nExitting..");
                                    break;
                                }
                                else if (storeChoice == 1)
                                {
                                    if (shop != null && otherShop != null)
                                    {
                                        Console.Write($"\nBoth journals are equal: ");
                                        Console.WriteLine(shop == otherShop);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nOne or both shops are null! Cannot check!");
                                    }
                                }
                                else if (storeChoice == 2)
                                {
                                    if (shop != null && otherShop != null)
                                    {
                                        Console.Write($"\nBoth shops are not equal: ");
                                        Console.WriteLine(shop != otherShop);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nOne or both shops are null! Cannot check!");
                                    }
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
                    }
                    else if (userChoice == 6)
                    {
                        while (true)
                        {
                            Console.WriteLine("\n1. Compare first shop to the second");
                            Console.WriteLine("2. Compare second shop to the first");
                            Console.WriteLine("0. Exit");
                            Console.Write("Your choice: ");
                            string? storeInput = Console.ReadLine();

                            if (int.TryParse(storeInput, out int storeChoice))
                            {
                                if (storeChoice == 0)
                                {
                                    Console.WriteLine("\nExitting..");
                                    break;
                                }
                                else if (storeChoice == 1)
                                {
                                    if (shop != null && otherShop != null)
                                    {
                                        Console.Write($"\nFirst shop is bigger than second: ");
                                        Console.WriteLine(shop > otherShop);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nOne or both shops are null! Cannot check!");
                                    }
                                }
                                else if (storeChoice == 2)
                                {
                                    if (shop != null && otherShop != null)
                                    {
                                        Console.Write($"\nSecond shop is bigger than first: ");
                                        Console.WriteLine(shop < otherShop);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nOne or both shops are null! Cannot check!");
                                    }
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
                    }
                    else if (userChoice == 7)
                    {
                        if (shop != null)
                        {
                            Console.WriteLine($"\nFirst shop info:\n{shop.Output()}");
                        }
                        else
                        {
                            Console.WriteLine("\nFirst shop is null! Cannot output!");
                        }

                        if (otherShop != null)
                        {
                            Console.WriteLine($"\nSecond shop info:\n{otherShop.Output()}");
                        }
                        else
                        {
                            Console.WriteLine("\nSecond shop is null! Cannot output!");
                        }
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
