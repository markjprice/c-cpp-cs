static bool ExpensiveMethod()
{
    Console.WriteLine("ExpensiveMethod was called.");
    return true;
}

int a = 10;
int b = 3;
Console.WriteLine("Arithmetic:");
Console.WriteLine(a + b);
Console.WriteLine(a - b);
Console.WriteLine(a * b);
Console.WriteLine(a / b);
Console.WriteLine(a % b);
Console.WriteLine(10.0 / 3);

int total = 10;
total += 5;
total *= 2;
Console.WriteLine($"Compound assignment result: {total}");

int counter = 5;
counter++;
counter--;
Console.WriteLine($"Counter: {counter}");

int age = 18;
Console.WriteLine($"Adult: {age >= 18}");
Console.WriteLine($"Under 21: {age < 21}");

bool hasTicket = true;
bool isAdult = true;
bool canEnter = hasTicket && isAdult;
Console.WriteLine($"Can enter: {canEnter}");

if (false && ExpensiveMethod())
{
    Console.WriteLine("This never runs.");
}
else
{
    Console.WriteLine("Short-circuiting prevented the expensive call.");
}

int bitValue = 1;
Console.WriteLine($"1 << 2 = {bitValue << 2}");

object value = "Hello";
Console.WriteLine($"value is string: {value is string}");
string? text = value as string;
Console.WriteLine($"Converted text: {text}");

string? name = null;
string displayName = name ?? "Unknown";
Console.WriteLine(displayName);
Console.WriteLine(text?.Length);
