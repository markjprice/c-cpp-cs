int[] scores = { 90, 85, 100 };
Console.WriteLine(scores[0]);
scores[1] = 95;
Console.WriteLine(scores[1]);

int[] numbers = new int[5];
Console.WriteLine(numbers[0]);

string[] names =
{
    "Alice",
    "Bob",
    "Mark"
};
Console.WriteLine($"Names length: {names.Length}");

int[] values = { 10, 20, 30 };
Console.WriteLine("for loop over array:");
for (int i = 0; i < values.Length; i++)
{
    Console.WriteLine(values[i]);
}

Console.WriteLine("foreach over array:");
foreach (string name in names)
{
    Console.WriteLine(name);
}

int[,] grid =
{
    { 1, 2 },
    { 3, 4 }
};
Console.WriteLine($"grid[1, 0]: {grid[1, 0]}");

int[][] jaggedValues =
{
    new int[] { 1, 2, 3 },
    new int[] { 4, 5 },
    new int[] { 6 }
};
Console.WriteLine($"Jagged row length: {jaggedValues[1].Length}");

List<string> listNames = new();
listNames.Add("Alice");
listNames.Add("Bob");
listNames.Add("Mark");
Console.WriteLine(listNames[0]);
listNames.Remove("Bob");
listNames.RemoveAt(0);
Console.WriteLine($"List count: {listNames.Count}");
foreach (string name in listNames)
{
    Console.WriteLine(name);
}

List<int> listScores = new()
{
    90,
    85,
    100
};
Console.WriteLine($"List score count: {listScores.Count}");

int[] collectionExpression = [1, 2, 3];
Console.WriteLine($"Collection expression first value: {collectionExpression[0]}");

int[] first = { 1, 2, 3 };
int[] second = first;
second[0] = 99;
Console.WriteLine($"first[0]: {first[0]}");

try
{
    Console.WriteLine(scores[10]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine($"Bounds checking caught an error: {ex.GetType().Name}");
}
