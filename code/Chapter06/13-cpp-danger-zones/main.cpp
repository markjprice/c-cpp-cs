#include <iostream>
#include <stdexcept>
#include <string>
#include <vector>

int main()
{
  std::cout << "Danger zone: auto can infer an integer when you expected a fraction.\n";
  auto x = 1 / 2;
  auto y = 1.0 / 2;
  std::cout << "1 / 2 -> " << x << "\n";
  std::cout << "1.0 / 2 -> " << y << "\n\n";

  std::cout << "Danger zone: vector[] does not bounds-check. Prefer at() while learning.\n";
  std::vector<int> values = {10, 20, 30};
  try
  {
    std::cout << values.at(10) << "\n";
  }
  catch (const std::out_of_range& ex)
  {
    std::cout << "values.at(10) threw std::out_of_range: " << ex.what() << "\n";
  }

  std::cout << "\nDanger zone: prefer std::string over manual char buffers.\n";
  std::string text = "This string resizes automatically.";
  std::cout << text << "\n";
}
