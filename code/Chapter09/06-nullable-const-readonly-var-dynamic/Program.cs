Demo demo = new();
demo.Run();

class Demo
{
    private const double Pi = 3.14159;
    private readonly DateTime createdAt = DateTime.Now;

    public void Run()
    {
        Console.WriteLine($"Pi: {Pi}");
        Console.WriteLine($"Created at: {createdAt:O}");

        int? score = null;
        int finalScore = score ?? 0;
        Console.WriteLine($"Final score: {finalScore}");

        score = 42;
        if (score.HasValue)
        {
            Console.WriteLine($"Score now has a value: {score.Value}");
        }

        var message = "Hello";
        var count = 10;
        var price = 19.99;
        Console.WriteLine($"{message}, count {count}, price {price}");

        dynamic value = 10;
        Console.WriteLine($"dynamic as int: {value}");
        value = "C#";
        Console.WriteLine($"dynamic as string upper-case: {value.ToUpper()}");

        // The next line would fail at runtime because dynamic calls are checked at runtime.
        // Console.WriteLine(value.DoesNotExist());
    }
}
