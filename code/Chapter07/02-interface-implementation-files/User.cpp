#include "User.hpp"

#include <iostream>

void User::setName(const std::string& newName)
{
  name = newName;
}

void User::setAge(int newAge)
{
  age = newAge;
}

void User::print() const
{
  std::cout << name << " (" << age << ")\n";
}
