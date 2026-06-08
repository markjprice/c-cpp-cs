int age = 25;
long population = 9_000_000_000L;
float singlePrecision = 3.14F;
double temperature = 72.5;
decimal price = 19.99M;
char grade = 'A';
bool isLoggedIn = true;
string name = "Mark";

Console.WriteLine($"Name: {name}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Population: {population}");
Console.WriteLine($"Float: {singlePrecision}");
Console.WriteLine($"Temperature: {temperature}");
Console.WriteLine($"Price: {price:C}");
Console.WriteLine($"Grade: {grade}");
Console.WriteLine($"Logged in: {isLoggedIn}");

// Uncommenting the next line causes a compilation error because C# is strongly typed.
// int score = "100";
