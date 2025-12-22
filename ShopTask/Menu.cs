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
}
