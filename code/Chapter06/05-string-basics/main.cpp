#include <iostream>
#include <string>

int main()
{
  std::string firstName = "Alice";
  std::string lastName = "Smith";
  std::string copy = firstName;
  std::string fullName = firstName + " " + lastName;

  std::cout << "First name: " << firstName << "\n";
  std::cout << "Copied name: " << copy << "\n";
  std::cout << "Full name: " << fullName << "\n";
  std::cout << "Length: " << fullName.length() << "\n";
  std::cout << "First five characters: " << fullName.substr(0, 5) << "\n";
}
