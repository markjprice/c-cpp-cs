Console.WriteLine($"Largest value: {FindLargest(10, 50, 20)}");
ProcessUser(new User("Ada", isActive: true, hasPermission: true));
ProcessUser(null);

Console.WriteLine($"Total: {CalculateTotal(100, 0.2)}");
Console.WriteLine($"Parsed: {TryReadInt("123")}");
Console.WriteLine($"Parsed: {TryReadInt("abc")}");

try
{
    RegisterPlayer("   ");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

static int FindLargest(int a, int b, int c)
{
    int largest = a;

    if (b > largest)
    {
        largest = b;
    }

    if (c > largest)
    {
        largest = c;
    }

    return largest;
}

static void ProcessUser(User? user)
{
    if (user == null)
    {
        Console.WriteLine("No user was supplied.");
        return;
    }

    if (!user.IsActive)
    {
        Console.WriteLine("User is not active.");
        return;
    }

    if (!user.HasPermission)
    {
        Console.WriteLine("User does not have permission.");
        return;
    }

    Console.WriteLine($"Processing {user.Name}.");
}

static double CalculateTotal(double price, double taxRate)
{
    return price + (price * taxRate);
}

static string TryReadInt(string input)
{
    if (int.TryParse(input, out int value))
    {
        return value.ToString();
    }

    return "Invalid input";
}

static void RegisterPlayer(string name)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        throw new ArgumentException("Name is required.", nameof(name));
    }

    Console.WriteLine($"Registered player: {name}");
}

record User(string Name, bool IsActive, bool HasPermission);
