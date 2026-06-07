#include <iostream>
#include <string>

int main()
{
  std::string name;

  std::cout << "Enter your name: ";
  std::getline(std::cin, name);

  if (name.empty())
  {
    name = "reader";
  }

  std::cout << "Hello, " << name << "!\n";
}
