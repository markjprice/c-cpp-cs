#include <iostream>
#include <vector>

int globalValue = 10;

int& getGlobal()
{
  return globalValue;
}

int& firstElement(std::vector<int>& values)
{
  return values.at(0);
}

// This is intentionally commented out because it returns a reference to a
// local variable that is destroyed when the function ends.
//
// int& badFunction()
// {
//   int x = 10;
//   return x;
// }

int main()
{
  getGlobal() = 42;
  std::cout << "Global value: " << globalValue << "\n";

  std::vector<int> scores = {10, 20, 30};
  firstElement(scores) = 99;

  std::cout << "Scores: ";
  for (int score : scores)
  {
    std::cout << score << " ";
  }
  std::cout << "\n";
}
