namespace MainProgram.BookTask;
class Book
{
    private string? _title;
    private string? _author;

    public string? Title
    {
        get;
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Name of the book cannot be empty");
            }

            field = value;
        }
    }

    public string? Author
    {
        get;
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Author cannot be empty");
            }

            field = value;
        }
    }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"\"{Title}\" — {Author}";
    }

    public static bool operator ==(Book a, Book b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        if (a is null || b is null)
        {
            return false;
        }

        return a.Title == b.Title && a.Author == b.Author;
    }

    public static bool operator !=(Book a, Book b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        return obj is Book book && this == book;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Author);
    }
}
