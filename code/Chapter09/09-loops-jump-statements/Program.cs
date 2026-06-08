Console.WriteLine("for loop:");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}

Console.WriteLine("while loop:");
int count = 0;
while (count < 3)
{
    Console.WriteLine(count);
    count++;
}

Console.WriteLine("do-while loop:");
int value = 0;
do
{
    Console.WriteLine(value);
    value++;
}
while (value < 3);

Console.WriteLine("foreach loop:");
string[] names = { "Mark", "Alice", "Bob" };
foreach (string name in names)
{
    Console.WriteLine(name);
}

Console.WriteLine("break example:");
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break;
    }
    Console.WriteLine(i);
}

Console.WriteLine("continue example:");
for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        continue;
    }
    Console.WriteLine(i);
}

Console.WriteLine("return example:");
SayHelloThenReturn();

static void SayHelloThenReturn()
{
    Console.WriteLine("Before return");
    return;
    // Unreachable code would go here.
}
