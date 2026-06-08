Person captain = CreateCaptain();
Console.WriteLine(captain.Name);

int total = Add(20, 22);
Console.WriteLine(total);

static int Add(int a, int b)
{
  int result = a + b;
  return result;
}

static Person CreateCaptain()
{
  Person captain = new("Kathryn Janeway");
  return captain;
}

public sealed record Person(string Name);
