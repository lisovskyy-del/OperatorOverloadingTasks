using System.Runtime.Intrinsics.X86;
using System.Xml;

namespace MainProgram.JournalTask;
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

    private static Journal JournalInput()
    {
        string name = StringInput("\nEnter name: ");
        int date = IntInput("\nEnter a date: ");
        string description = StringInput("\nEnter description: ");
        string phone = StringInput("\nEnter phone (ex. +3801234567): ");
        string email = StringInput("\nEnter email (ex. lisdel@gmail.com): ");
        int amountOfWorkers = IntInput("\nEnter the amount of workers: ");

        return new Journal(name, date, description, phone, email, amountOfWorkers);
    }

    public static void Run()
    {
        Journal? journal = null;
        Journal? otherJournal = null;

        while (true)
        {
            Console.WriteLine("\n1. Create a journal");
            Console.WriteLine("2. Create a second journal");
            Console.WriteLine("3. Add new workers to a journal");
            Console.WriteLine("4. Remove some workers from a journal");
            Console.WriteLine("5. Check for pair of journals");
            Console.WriteLine("6. Compare two journals");
            Console.WriteLine("7. Display journals");
            Console.WriteLine("0. Exit");
            Console.Write("Your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int userChoice))
            {
                if (userChoice == 0)
                {
                    Console.WriteLine("\nExitting..");
                    break;
                }
                else if (userChoice == 1)
                {
                    journal = JournalInput();

                    if (journal != null)
                    {
                        Console.WriteLine("\nJournal created!");
                    }
                    else
                    {
                        Console.WriteLine("\nWarning. Journal is empty. Some options may be locked.");
                    }
                }
                else if (userChoice == 2)
                {
                    otherJournal = JournalInput();

                    if (otherJournal != null)
                    {
                        Console.WriteLine("\nJournal created!");
                    }
                    else
                    {
                        Console.WriteLine("\nWarning. Journal is empty. Some options may be locked.");
                    }
                }
                else if (userChoice == 3)
                {
                    while (true)
                    {
                        Console.WriteLine("\n1. Add new workers to first journal");
                        Console.WriteLine("2. Add new workers to the second journal");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? WorkersInput = Console.ReadLine();

                        if (int.TryParse(WorkersInput, out int workersChoice))
                        {
                            if (workersChoice == 0)
                            {
                                Console.WriteLine("\nExitting..");
                                break;
                            }
                            else if (workersChoice == 1)
                            {
                                int value = IntInput("Enter a number: ");

                                if (journal != null && value > 0)
                                {
                                    journal += value;
                                    Console.WriteLine($"\nAdded {value} workers to first journal!");
                                }
                                else
                                {
                                    Console.WriteLine("\nJournal is null or value is less than 0! Cannot add!");
                                }
                            }
                            else if (workersChoice == 2)
                            {
                                int value = IntInput("Enter a number: ");

                                if (otherJournal != null && value > 0)
                                {
                                    otherJournal += value;
                                    Console.WriteLine($"\nAdded {value} workers to second journal!");
                                }
                                else
                                {
                                    Console.WriteLine("\nJournal is null or value is less than 0! Cannot add!");
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
                        Console.WriteLine("\n1. Remove some workers from the first journal");
                        Console.WriteLine("2. Remove some workers from the second journal");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? WorkersInput = Console.ReadLine();

                        if (int.TryParse(WorkersInput, out int workersChoice))
                        {
                            if (workersChoice == 0)
                            {
                                Console.WriteLine("\nExitting..");
                                break;
                            }
                            else if (workersChoice == 1)
                            {
                                int value = IntInput("Enter a number: ");

                                if (journal != null && value > 0)
                                {
                                    journal -= value;
                                    Console.WriteLine($"\nRemoved {value} workers from the first journal!");
                                }
                                else
                                {
                                    Console.WriteLine("\nJournal is null or value is less than 0! Cannot Remove!");
                                }
                            }
                            else if (workersChoice == 2)
                            {
                                int value = IntInput("Enter a number: ");

                                if (otherJournal != null && value > 0)
                                {
                                    otherJournal -= value;
                                    Console.WriteLine($"\nRemoved {value} workers from the second journal!");
                                }
                                else
                                {
                                    Console.WriteLine("\nJournal is null or value is less than 0! Cannot Remove!");
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
                        Console.WriteLine("\n1. Check if amount of workers of both journals are equal");
                        Console.WriteLine("2. Check if amount of workers of both journals are not equal");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? WorkersInput = Console.ReadLine();

                        if (int.TryParse(WorkersInput, out int workersChoice))
                        {
                            if (workersChoice == 0)
                            {
                                Console.WriteLine("\nExitting..");
                                break;
                            }
                            else if (workersChoice == 1)
                            {
                                if (journal != null && otherJournal != null)
                                {
                                    Console.Write($"\nBoth journals are equal: ");
                                    Console.WriteLine(journal == otherJournal);
                                }
                                else
                                {
                                    Console.WriteLine("\nOne or both journals are null! Cannot check!");
                                }
                            }
                            else if (workersChoice == 2)
                            {
                                if (journal != null && otherJournal != null)
                                {
                                    Console.Write($"\nBoth journals are not equal: ");
                                    Console.WriteLine(journal != otherJournal);
                                }
                                else
                                {
                                    Console.WriteLine("\nOne or both journals are null! Cannot check!");
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
                        Console.WriteLine("\n1. Compare first journal to the second");
                        Console.WriteLine("2. Compare second journal to the first");
                        Console.WriteLine("0. Exit");
                        Console.Write("Your choice: ");
                        string? WorkersInput = Console.ReadLine();

                        if (int.TryParse(WorkersInput, out int workersChoice))
                        {
                            if (workersChoice == 0)
                            {
                                Console.WriteLine("\nExitting..");
                                break;
                            }
                            else if (workersChoice == 1)
                            {
                                if (journal != null && otherJournal != null)
                                {
                                    Console.Write($"\nFirst journal is bigger than second: ");
                                    Console.WriteLine(journal > otherJournal);
                                }
                                else
                                {
                                    Console.WriteLine("\nOne or both journals are null! Cannot check!");
                                }
                            }
                            else if (workersChoice == 2)
                            {
                                if (journal != null && otherJournal != null)
                                {
                                    Console.Write($"\nSecond journal is bigger than first: ");
                                    Console.WriteLine(journal < otherJournal);
                                }
                                else
                                {
                                    Console.WriteLine("\nOne or both journals are null! Cannot check!");
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
                    if (journal != null)
                    {
                        Console.WriteLine($"\nFirst journal info:\n{journal.Output()}");
                    }
                    else
                    {
                        Console.WriteLine("\nFirst journal is null! Cannot output!");
                    }

                    if (otherJournal != null)
                    {
                        Console.WriteLine($"\nSecond journal info:\n{otherJournal.Output()}");
                    }
                    else
                    {
                        Console.WriteLine("\nSecond journal is null! Cannot output!");
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
    }
}
