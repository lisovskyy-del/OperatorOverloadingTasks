namespace MainProgram.BookTask;
class ReadingList
{
    private List<Book> _books = new();

    public int Count => _books.Count;

    public Book this[int index]
    {
        get
        {
            if (index < 0 || index >= _books.Count)
            {
                throw new Exception("Index out of range");
            }

            return _books[index];
        }
    }

    public void Add(Book book)
    {
        if (_books.Contains(book))
        {
            Console.WriteLine("Book already exists");
        }
        else
        {
            _books.Add(book);
        }
    }

    public void Remove(Book book)
    {
        if (!_books.Remove(book))
        {
            Console.WriteLine("Book doesnt exist");
        }
        else
        {
            Console.WriteLine("Book removed.");
        }
    }
    public bool Contains(Book book)
    {
        return _books.Contains(book);
    }

    public void Output()
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        for (int i = 0; i < _books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_books[i]}");
        }
    }

    public static ReadingList operator +(ReadingList list, Book book)
    {
        list.Add(book);
        return list;
    }

    public static ReadingList operator -(ReadingList list, Book book)
    {
        list.Remove(book);
        return list;
    }
}
