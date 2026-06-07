#include <array>
#include <iostream>
#include <string>
#include <vector>

int main()
{
  std::string name = "Alice";
  name += " Smith";
  std::cout << "Name: " << name << " (length " << name.length() << ")\n";

  std::vector<int> scores;
  scores.reserve(5);
  scores.push_back(90);
  scores.push_back(85);
  scores.push_back(92);

  std::cout << "Scores size: " << scores.size() << "\n";
  std::cout << "Scores capacity: " << scores.capacity() << "\n";
  std::cout << "Second score with bounds checking: " << scores.at(1) << "\n";

  std::array<int, 3> fixedValues = {1, 2, 3};
  for (int value : fixedValues)
  {
    std::cout << value << " ";
  }
  std::cout << "\n";

  std::cout << "No manual delete or free was required.\n";
}
