#include <iostream>
#include <string>

class User
{
private:
  std::string name;
  inline static int userCount = 0;

public:
  explicit User(std::string userName)
    : name(std::move(userName))
  {
    userCount++;
  }

  ~User()
  {
    userCount--;
  }

  void print() const
  {
    std::cout << "User: " << name << "\n";
  }

  static int getUserCount()
  {
    return userCount;
  }
};

int main()
{
  std::cout << "Users at start: " << User::getUserCount() << "\n";

  {
    User alice("Alice");
    User bob("Bob");

    alice.print();
    bob.print();

    std::cout << "Users inside block: " << User::getUserCount() << "\n";
  }

  std::cout << "Users after block: " << User::getUserCount() << "\n";

  return 0;
}
