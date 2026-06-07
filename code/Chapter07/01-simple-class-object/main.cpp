#include <iostream>
#include <string>

class User
{
public:
  std::string name;
  int age;

  void print() const
  {
    std::cout << name << " (" << age << ")\n";
  }
};

int main()
{
  User user1;
  user1.name = "Alice";
  user1.age = 30;

  User user2;
  user2.name = "Bob";
  user2.age = 25;

  user1.print();
  user2.print();

  return 0;
}
