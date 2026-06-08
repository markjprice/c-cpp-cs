Console.WriteLine("Value type copy:");
int a = 10;
int b = a;
b = 20;
Console.WriteLine($"a = {a}");
Console.WriteLine($"b = {b}");

Console.WriteLine();
Console.WriteLine("String reference with immutable replacement:");
string first = "Hello";
string second = first;
second = "World";
Console.WriteLine($"first = {first}");
Console.WriteLine($"second = {second}");

Console.WriteLine();
Console.WriteLine("Array reference sharing:");
int[] original = { 1, 2, 3 };
int[] alias = original;
alias[0] = 99;
Console.WriteLine($"original[0] = {original[0]}");
Console.WriteLine($"alias[0] = {alias[0]}");

Console.WriteLine();
Console.WriteLine("The array variables refer to the same object:");
Console.WriteLine(ReferenceEquals(original, alias));
