#include <iostream>
#include <memory>
#include <string>

class Profile
{
private:
  std::string name;

public:
  explicit Profile(std::string n) : name(std::move(n))
  {
    std::cout << "Profile created for " << name << "\n";
  }

  ~Profile()
  {
    std::cout << "Profile destroyed for " << name << "\n";
  }

  void print() const
  {
    std::cout << "Profile: " << name << "\n";
  }
};

int main()
{
  std::weak_ptr<Profile> observer;

  {
    auto p1 = std::make_shared<Profile>("Bob");
    auto p2 = p1;
    observer = p1;

    std::cout << "use_count while p1 and p2 exist: " << p1.use_count() << "\n";

    if (auto locked = observer.lock())
    {
      locked->print();
      std::cout << "use_count while locked: " << locked.use_count() << "\n";
    }
  }

  if (observer.expired())
  {
    std::cout << "The weak_ptr can see that the object no longer exists.\n";
  }
}
