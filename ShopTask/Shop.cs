using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainProgram.ShopTask;
class Shop
{
    private string? _name;
    private string? _adress;
    private string? _description;
    private string? _phone;
    private string? _email;
    private int? _storeArea;

    private string? Name
    {
        get;
        set
        {
            if (value == null)
            {
                throw new Exception("Name cannot be empty.");
            }

            field = value;
        }
    }

    private string? Adress
    {
        get;
        set
        {
            if (value == null)
            {
                throw new Exception("Name cannot be empty.");
            }

            field = value;
        }
    }

    private string Description { get; set; }

    private string? Phone
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Phone can't be empty.");

            if (value.StartsWith('+'))
            {
                if (!value.Substring(1).All(char.IsDigit))
                {
                    throw new Exception("Phone can only haved digits after '+'.");
                }
            }
            else
            {
                if (!value.All(char.IsDigit))
                {
                    throw new Exception("Phone can only have digits.");
                }
            }

            if (value.Length < 10 || value.Length > 13)
            {
                throw new Exception("Phone has to have from 10 to 13 digits.");
            }

            field = value;
        }
    }

    private string? Email
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Email can't be empty.");
            }

            if (value.Contains(" "))
            {
                throw new Exception("Email can't have spaces.");
            }

            int atIndex = value.IndexOf('@');

            if (atIndex <= 0 || atIndex != value.LastIndexOf('@'))
            {
                throw new Exception("Email has to have only one '@'.");
            }

            if (!value.Substring(atIndex).Contains('.'))
            {
                throw new Exception("Email has to have a dot after '@'.");
            }

            field = value;
        }
    }

    private int? StoreArea
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new Exception("Area of the store cannot be negative.");
            }

            field = value;
        }
    }

    public Shop(string? name, string? adress, string description, string? phone, string? email, int? storeArea)
    {
        Name = name;
        Adress = adress;
        Description = description;
        Phone = phone;
        Email = email;
        StoreArea = storeArea;
    }

    public static Shop operator +(Shop shop, int value)
    {
        shop.StoreArea += value;
        return shop;
    }

    public static Shop operator -(Shop shop, int value)
    {
        shop.StoreArea -= value;
        return shop;
    }

    public static bool operator ==(Shop? shop, Shop? other)
    {
        if (ReferenceEquals(shop, other))
        {
            return true;
        }
        if (shop is null || other is null)
        {
            return false;
        }

        return shop.StoreArea == shop.StoreArea;
    }

    public static bool operator !=(Shop? shop, Shop? other)
    {
        return !(shop == other);
    }

    public bool Equals(Shop? other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Shop);
    }


    public static bool operator >(Shop? shop, Shop? other)
    {
        if (ReferenceEquals(shop, other))
        {
            return false;
        }

        if (shop is null || other is null)
        {
            return false;
        }

        return shop.StoreArea > other.StoreArea;
    }

    public static bool operator <(Shop? shop, Shop? other)
    {
        if (ReferenceEquals(shop, other))
        {
            return false;
        }

        if (shop is null || other is null)
        {
            return false;
        }

        return shop.StoreArea < other.StoreArea;
    }

    public string Output()
    {
        return $"Shop's name: {Name}\n" +
            $"Shop's adress: {Adress}\n" +
            $"Shop's description: {Description}\n" +
            $"Shop's phone number: {Phone}\n" +
            $"Shop's email: {Email}\n" +
            $"Shop's store area: {StoreArea}\n";
    }
}
