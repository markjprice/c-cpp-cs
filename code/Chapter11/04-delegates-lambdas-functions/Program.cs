MathOperation operation = Add;
Console.WriteLine(operation(2, 3));

Func<int, int, int> multiply = (x, y) => x * y;
Console.WriteLine(multiply(4, 5));

Action<string> print = message => Console.WriteLine(message);
print("Hello from Action<T>.");

Func<int, int> square = x => x * x;
Console.WriteLine(square(6));

Func<int, int> factorial = n =>
{
  int result = 1;
  for (int i = 1; i <= n; i++) result *= i;
  return result;
};
Console.WriteLine(factorial(5));

PrintNumbers();

int result = ApplyOperation(10, 5, (a, b) => a - b);
Console.WriteLine(result);

Func<int, int> doubleValue = CreateMultiplier(2);
Console.WriteLine(doubleValue(10));

static int Add(int x, int y) => x + y;

static void PrintNumbers()
{
  void Print(int number) => Console.WriteLine(number);
  Print(1);
  Print(2);
}

static int ApplyOperation(int x, int y, Func<int, int, int> operation) => operation(x, y);

static Func<int, int> CreateMultiplier(int factor) => x => x * factor;

public delegate int MathOperation(int x, int y);
