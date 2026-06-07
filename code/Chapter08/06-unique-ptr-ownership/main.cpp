#include <iostream>
#include <memory>
#include <string>

class User
{
private:
  std::string name;

public:
  explicit User(std::string n) : name(std::move(n))
  {
    std::cout << "Creating user " << name << "\n";
  }

  ~User()
  {
    std::cout << "Destroying user " << name << "\n";
  }

  void print() const
  {
    std::cout << "User: " << name << "\n";
  }
};

std::unique_ptr<User> createUser()
{
  return std::make_unique<User>("Alice");
}

void takeOwnership(std::unique_ptr<User> user)
{
  std::cout << "Function now owns the user.\n";
  user->print();
}

int main()
{
  auto user = createUser();
  user->print();

  takeOwnership(std::move(user));

  if (!user)
  {
    std::cout << "user is empty after ownership transfer.\n";
  }
}
