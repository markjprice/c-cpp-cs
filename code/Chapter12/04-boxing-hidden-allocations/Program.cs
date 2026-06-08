using System.Collections;

int score = 100;
object boxed = score;
int unboxed = (int)boxed;

Console.WriteLine($"Boxed value: {boxed}");
Console.WriteLine($"Unboxed value: {unboxed}");

ArrayList oldNumbers = new();
oldNumbers.Add(1);
oldNumbers.Add(2);
oldNumbers.Add(3);
Console.WriteLine($"ArrayList item type: {oldNumbers[0]!.GetType().Name}");

List<int> numbers = new();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
Console.WriteLine($"List<int> first item: {numbers[0]}");

string inefficient = "";
for (int i = 0; i < 5; i++)
{
  inefficient += i + ", ";
}
Console.WriteLine(inefficient);

int minimumRank = 5;
Func<CrewMember, bool> isSenior = member => member.Rank >= minimumRank;
Console.WriteLine(isSenior(new CrewMember("Spock", 7)));

foreach (int value in Countdown())
{
  Console.WriteLine(value);
}

static IEnumerable<int> Countdown()
{
  yield return 3;
  yield return 2;
  yield return 1;
}

public sealed record CrewMember(string Name, int Rank);
