Console.WriteLine("Value type copy:");
int firstInt = 10;
int secondInt = firstInt;

firstInt = 20;

Console.WriteLine($"a = {firstInt}");
Console.WriteLine($"b = {secondInt}");

Console.WriteLine();
Console.WriteLine("Array reference sharing:");
int[] firstArray = { 1, 2, 3 };
int[] secondArray = firstArray;

firstArray[0] = 99;

Console.WriteLine($"firstArray[0] = {firstArray[0]}");
Console.WriteLine($"secondArray[0] = {secondArray[0]}");

Console.WriteLine();
Console.WriteLine("The array variables refer to the same object:");
Console.WriteLine(ReferenceEquals(firstArray, secondArray));

Console.WriteLine();
Console.WriteLine("String reference with immutable replacement:");
string firstString = "Hello";
string secondString = firstString;

firstString = "Hi";

Console.WriteLine($"firstString = {firstString}");
Console.WriteLine($"secondString = {secondString}");

