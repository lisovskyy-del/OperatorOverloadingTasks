using System.Security.Cryptography.X509Certificates;

namespace MainProgram.BookTask;
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

    static Book InputBook()
    {
        string? title = StringInput("Enter name: ");
        string? author = StringInput("Enter author: ");

        return new Book(title, author);
    }

    public static void Run()
    {
        ReadingList list = new();

        while (true)
        {
            Console.WriteLine("\n1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Check if book exists");
            Console.WriteLine("4. Show book by index");
            Console.WriteLine("5. Show all books");
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
                        Book? book = InputBook();

                        if (book != null)
                        {
                            list += book;
                        }
                        else
                        {
                            Console.WriteLine("\nBook is null. Cannot add.");
                        }
                    }
                    else if (userChoice == 2)
                    {
                        Book? book = InputBook();

                        if (book != null)
                        {
                            list -= book;
                        }
                        else
                        {
                            Console.WriteLine("\nBook is null. Cannot remove.");
                        }
                    }
                    else if (userChoice == 3)
                    {
                        Book? book = InputBook();

                        if (book != null)
                        {
                            if (list.Contains(book))
                            {
                                Console.WriteLine("\nBook exists in list.");
                            }
                            else
                            {
                                Console.WriteLine("\nBook doesnt exist in list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nBook is null. Cannot check.");
                        }
                    }
                    else if (userChoice == 4)
                    {
                        int index = IntInput("\nEnter book's index: ");
                        Console.WriteLine(list[index]);
                    }
                    else if (userChoice == 5)
                    {
                        list.Output();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice! Enter a number between 0-5!");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid input! Enter a number");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError {ex}");
                return;
            }
        }
    }
}
