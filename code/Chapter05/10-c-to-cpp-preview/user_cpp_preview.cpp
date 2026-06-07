#include <iostream>
#include <string>

class User {
private:
  int id;
  std::string name;
  bool active;

public:
  User(int id, std::string name)
    : id(id), name(std::move(name)), active(true)
  {
  }

  void deactivate()
  {
    active = false;
  }

  void print() const
  {
    std::cout << "C++ User ID: " << id
              << ", Name: " << name
              << ", Active: " << std::boolalpha << active << '\n';
  }
};

int main()
{
  User user(1, "Alice");

  // user.active = 42; // This would not compile because active is private.

  user.deactivate();
  user.print();

  return 0;
}
