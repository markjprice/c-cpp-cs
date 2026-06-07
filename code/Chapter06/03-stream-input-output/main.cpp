#include <iostream>
#include <string>

int main()
{
  int age {};
  std::string name;

  std::cout << "Enter your age: ";
  std::cin >> age;

  std::cout << "Enter your full name: ";
  std::getline(std::cin >> std::ws, name);

  std::cout << "Name: " << name << ", Age: " << age << "\n";
  std::cout << "This line uses \\n rather than std::endl to avoid unnecessary flushing.\n";
}
