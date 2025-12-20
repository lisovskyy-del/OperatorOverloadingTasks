using System.Numerics;

namespace MainProgram.JournalTask;
class Journal
{
    private int _date;
    private int _amountOfWorkers;

    private string Name
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

    private int Date
    {
        get => _date;
        set
        {
            if (value > 2025 || value <= 0)
            {
                throw new Exception("Date cannot be bigger than 2025 or less than 0!");
            }

            _date = value;
        }
    }

    private string Description { get; set; }

    private string Phone
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

    private string Email
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

    private int AmountOfWorkers
    {
        get => _amountOfWorkers;
        set
        {
            if (value < 0)
            {
                throw new Exception("Amount of workers cannot be negative.");
            }

            _amountOfWorkers = value;
        }
    }

    public Journal(string name, int date, string description, string phone, string email, int amountOfWorkers)
    {
        Name = name;
        Date = date;
        Description = description;
        Phone = phone;
        Email = email;
        AmountOfWorkers = amountOfWorkers;
    }

    public static Journal operator +(Journal journal, int value)
    {
        journal.AmountOfWorkers += value;
        return journal;
    }

    public static Journal operator -(Journal journal, int value)
    {
        journal.AmountOfWorkers -= value;
        return journal;
    }

    public static bool operator ==(Journal? journal, Journal? other)
    {
        if (ReferenceEquals(journal, other))
        {
            return true;
        }
        if (journal is null || other is null)
        {
            return false;
        }

        return journal.AmountOfWorkers == other.AmountOfWorkers;
    }

    public static bool operator !=(Journal? journal, Journal? other)
    {
        return !(journal == other);
    }

    public bool Equals(Journal? other)
    {
        return this == other;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Journal);
    }

    public static bool operator >(Journal? journal, Journal? other)
    {
        if (ReferenceEquals(journal, other))
        {
            return false;
        }

        if (journal is null || other is null)
        {
            return false;
        }

        return journal.AmountOfWorkers > other.AmountOfWorkers;
    }

    public static bool operator <(Journal? journal, Journal? other)
    {
        if (ReferenceEquals(journal, other))
        {
            return false;
        }

        if (journal is null || other is null)
        {
            return false;
        }

        return journal.AmountOfWorkers < other.AmountOfWorkers;
    }

    public string Output()
    {
        return $"Journal's name: {Name}\n" +
            $"Journal's date: {Date}\n" +
            $"Journal's description: {Description}\n" +
            $"Journal's phone number: {Phone}\n" +
            $"Journal's email: {Email}\n" +
            $"Journal's amount of workers : {AmountOfWorkers}\n";
    }
}
