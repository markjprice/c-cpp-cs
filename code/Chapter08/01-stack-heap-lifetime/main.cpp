#include <iostream>
#include <memory>

class Tracer
{
private:
  std::string name;

public:
  explicit Tracer(std::string n) : name(std::move(n))
  {
    std::cout << "Constructing " << name << "\n";
  }

  ~Tracer()
  {
    std::cout << "Destroying " << name << "\n";
  }

  void sayHello() const
  {
    std::cout << "Hello from " << name << "\n";
  }
};

void stackExample()
{
  std::cout << "Entering stackExample\n";
  Tracer local("stack object");
  local.sayHello();
  std::cout << "Leaving stackExample\n";
}

void heapExample()
{
  std::cout << "Entering heapExample\n";
  auto owned = std::make_unique<Tracer>("heap object owned by unique_ptr");
  owned->sayHello();
  std::cout << "Leaving heapExample\n";
}

int main()
{
  stackExample();
  std::cout << "---\n";
  heapExample();
  std::cout << "Program ending\n";
}
