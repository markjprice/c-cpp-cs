int day = 3;

Console.WriteLine("switch statement:");
switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;
    case 2:
        Console.WriteLine("Tuesday");
        break;
    default:
        Console.WriteLine("Other day");
        break;
}

Console.WriteLine("switch expression:");
string result = day switch
{
    1 => "Monday",
    2 => "Tuesday",
    _ => "Other day"
};
Console.WriteLine(result);

Console.WriteLine("pattern matching:");
foreach (object? value in new object?[] { 42, -10, "hello", null, 3.14 })
{
    string description = value switch
    {
        int number when number > 0 => "Positive integer",
        int => "Integer",
        string => "Text",
        null => "No value",
        _ => "Unknown"
    };

    Console.WriteLine($"{value ?? "<null>"}: {description}");
}
