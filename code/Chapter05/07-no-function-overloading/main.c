#include <stdio.h>

void printInt(int value)
{
  printf("int: %d\n", value);
}

void printDouble(double value)
{
  printf("double: %.2f\n", value);
}

void printString(const char* value)
{
  printf("string: %s\n", value);
}

int main(void)
{
  printInt(42);
  printDouble(19.99);
  printString("Hello");

  puts("\nIn C, each function needs a unique name.");
  puts("In C++, these could all be overloaded functions named print.");

  return 0;
}
