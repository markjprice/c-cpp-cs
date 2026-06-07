#include <iostream>
#include <string>

void incrementByValue(int value)
{
  value++;
}

void incrementByReference(int& value)
{
  value++;
}

void printByConstReference(const std::string& text)
{
  std::cout << text << "\n";
}

int main()
{
  int x = 10;

  incrementByValue(x);
  std::cout << "After incrementByValue: " << x << "\n";

  incrementByReference(x);
  std::cout << "After incrementByReference: " << x << "\n";

  std::string message = "Passing large objects by const reference avoids copying.";
  printByConstReference(message);
}
