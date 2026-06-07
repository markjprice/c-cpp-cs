#include <stdio.h>

void greet(void)
{
  printf("Hello!\n");
}

void printNumber(int number)
{
  printf("Number: %d\n", number);
}

int add(int a, int b)
{
  return a + b;
}

int square(int x)
{
  return x * x;
}

void timesTable(unsigned char number, unsigned char size)
{
  printf("This is the %d times table with %d rows:\n\n", number, size);

  for (int row = 1; row <= size; row++)
  {
    printf("%d x %d = %d\n", row, number, row * number);
  }

  printf("\n");
}

int main(void)
{
  greet();
  printNumber(42);

  int sum = add(2, 3);
  printf("2 + 3 = %d\n", sum);

  int result = square(5);
  printf("5 squared = %d\n\n", result);

  timesTable(7, 12);

  return 0;
}
