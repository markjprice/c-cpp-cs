#include <iostream>
#include <string>

int add(int a, int b)
{
  return a + b;
}

double add(double a, double b)
{
  return a + b;
}

void printValue(int value)
{
  std::cout << "int: " << value << "\n";
}

void printValue(double value)
{
  std::cout << "double: " << value << "\n";
}

void printValue(const std::string& value)
{
  std::cout << "string: " << value << "\n";
}

int main()
{
  std::cout << "add(2, 3): " << add(2, 3) << "\n";
  std::cout << "add(2.5, 3.1): " << add(2.5, 3.1) << "\n";

  printValue(42);
  printValue(3.14);
  printValue(std::string{"Hello"});
}
