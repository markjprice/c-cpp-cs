DisplayGreeting();

int result = AddNumbers(5, 3);
Console.WriteLine($"AddNumbers: {result}");

GreetUser("Mark");
Console.WriteLine($"Multiply: {Multiply(4, 5)}");

int number = 10;
Increment(number);
Console.WriteLine($"After pass by value: {number}");
Increment(ref number);
Console.WriteLine($"After ref: {number}");

GetCoordinates(out int x, out int y);
Console.WriteLine($"Coordinates: {x}, {y}");

PrintMessage();
PrintMessage("Welcome");
CreateUser(age: 25, isAdmin: true, name: "Mark");

Console.WriteLine($"Add int: {Add(2, 3)}");
Console.WriteLine($"Add double: {Add(2.5, 3.5)}");
Console.WriteLine($"Square: {Square(6)}");

Countdown(5);

static void DisplayGreeting()
{
    Console.WriteLine("Welcome to C#!");
}

static int AddNumbers(int a, int b)
{
    return a + b;
}

static void GreetUser(string name)
{
    Console.WriteLine($"Hello, {name}");
}

static int Multiply(int x, int y)
{
    return x * y;
}

static void Increment(int value)
{
    value++;
}

static void Increment(ref int value)
{
    value++;
}

static void GetCoordinates(out int x, out int y)
{
    x = 10;
    y = 20;
}

static void PrintMessage(string message = "Hello")
{
    Console.WriteLine(message);
}

static void CreateUser(string name, int age, bool isAdmin)
{
    Console.WriteLine($"{name}, {age}, {isAdmin}");
}

static int Add(int a, int b)
{
    return a + b;
}

static double Add(double a, double b)
{
    return a + b;
}

static int Square(int value) => value * value;

/// <summary>
/// Displays numbers counting down to one.
/// </summary>
static void Countdown(int value)
{
    if (value <= 0)
    {
        return;
    }

    Console.WriteLine(value);
    Countdown(value - 1);
}
