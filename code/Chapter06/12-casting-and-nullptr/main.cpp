#include <iostream>
#include <typeinfo>

void describe(int value)
{
  std::cout << "describe(int): " << value << "\n";
}

void describe(int* value)
{
  if (value == nullptr)
  {
    std::cout << "describe(int*): null pointer\n";
  }
  else
  {
    std::cout << "describe(int*): " << *value << "\n";
  }
}

int main()
{
  double price = 19.99;
  int truncated = static_cast<int>(price);

  std::cout << "Original double: " << price << "\n";
  std::cout << "After static_cast<int>: " << truncated << "\n";

  int number = 42;
  describe(number);
  describe(&number);
  describe(nullptr);

  // Avoid calling describe(NULL) in modern C++; nullptr expresses pointer intent.
}
