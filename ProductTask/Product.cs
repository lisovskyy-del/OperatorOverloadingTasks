namespace MainProgram.ProductTask;
class Product
{
    private int _quantity;
    private decimal _price;

    public string Name { get; set; }

    public int Quantity
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new Exception("Quantity cannot be negative");
            }    

            field = value;
        }
    }

    public decimal Price
    {
        get;
        set
        {
            if (value < 0)
            {
                throw new Exception("Price cannot be negative");
            }

            field = value;
        }
    }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public static Product operator +(Product product, int amount)
    {
        return new Product(
            product.Name,
            product.Quantity + amount,
            product.Price
        );
    }

    public static Product operator -(Product product, int amount)
    {
        return new Product(
            product.Name,
            product.Quantity - amount,
            product.Price
        );
    }
    public static bool operator ==(Product a, Product b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }

        return a.Price == b.Price;
    }

    public static bool operator !=(Product a, Product b)
    {
        return !(a == b);
    }

    public static bool operator >(Product a, Product b)
    {
        return a.Quantity > b.Quantity;
    }

    public static bool operator <(Product a, Product b)
    {
        return a.Quantity < b.Quantity;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Product other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Price);
    }

    public override string ToString()
    {
        return $"{Name} | Quantity: {Quantity} | Price: {Price:C}";
    }
}
