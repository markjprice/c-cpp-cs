#include <iostream>
#include <string>
#include <vector>

int main()
{
  std::vector<int> numbers = {1, 2, 3, 4, 5};

  std::cout << "Copies do not modify the original values:\n";
  for (auto n : numbers)
  {
    n = 0;
  }

  for (const auto& n : numbers)
  {
    std::cout << n << " ";
  }
  std::cout << "\n";

  std::cout << "References modify the original values:\n";
  for (auto& n : numbers)
  {
    n *= 2;
  }

  for (const auto& n : numbers)
  {
    std::cout << n << " ";
  }
  std::cout << "\n";

  std::vector<std::string> names = {"Alice", "Bob", "Charlie"};
  auto it = names.begin();
  std::cout << "First name via iterator: " << *it << "\n";

  auto x = 1 / 2;
  auto y = 1.0 / 2;
  std::cout << "auto x = 1 / 2 gives " << x << "\n";
  std::cout << "auto y = 1.0 / 2 gives " << y << "\n";
}
