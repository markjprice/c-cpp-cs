#include <iostream>
#include <string>

class User
{
private:
  std::string name;
  int age = 0;

public:
  User& setName(const std::string& name)
  {
    this->name = name;
    return *this;
  }

  User& setAge(int age)
  {
    this->age = age;
    return *this;
  }

  void print() const
  {
    std::cout << name << " (" << age << ")\n";
  }

  const User* getPointer() const
  {
    return this;
  }
};

int main()
{
  User user;

  user.setName("Alice")
      .setAge(30)
      .print();

  std::cout << "Object address through this: " << user.getPointer() << "\n";

  return 0;
}
