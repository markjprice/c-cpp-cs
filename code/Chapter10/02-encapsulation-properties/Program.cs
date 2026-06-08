BankAccount account = new();
account.Deposit(500);
bool success = account.Withdraw(125);

Console.WriteLine($"Withdrawal succeeded: {success}");
Console.WriteLine($"Balance: {account.Balance:C}");

Person person = new();
person.Name = "Mark";
Console.WriteLine(person.Name);

Order order = new(1234);
Console.WriteLine($"Order ID: {order.OrderId}");

Customer customer = new()
{
    Name = "Alice"
};

Console.WriteLine($"Customer: {customer.Name}");

Rectangle rectangle = new()
{
    Width = 5,
    Height = 4
};

Console.WriteLine($"Area: {rectangle.Area}");

Temperature temperature = new();
temperature.Celsius = 21.5;
Console.WriteLine($"Temperature: {temperature.Celsius}°C");

try
{
    temperature.Celsius = -300;
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

class BankAccount
{
    private decimal balance;

    public decimal Balance => balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > balance)
        {
            return false;
        }

        balance -= amount;
        return true;
    }
}

class Person
{
    private string name = "";

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be blank.");
            }

            name = value;
        }
    }
}

class Order
{
    public int OrderId { get; private set; }

    public Order(int id)
    {
        OrderId = id;
    }
}

class Customer
{
    public string Name { get; init; } = "";
}

class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double Area => Width * Height;
}

class Temperature
{
    private double celsius;

    public double Celsius
    {
        get => celsius;
        set
        {
            if (value < -273.15)
            {
                throw new ArgumentException("Temperature cannot be below absolute zero.");
            }

            celsius = value;
        }
    }
}
