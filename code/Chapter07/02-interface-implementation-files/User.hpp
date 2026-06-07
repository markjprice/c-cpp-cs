#pragma once

#include <string>

class User
{
public:
  void setName(const std::string& newName);
  void setAge(int newAge);
  void print() const;

private:
  std::string name;
  int age = 0;
};
