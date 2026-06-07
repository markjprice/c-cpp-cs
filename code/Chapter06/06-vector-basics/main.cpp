#include <iostream>
#include <stdexcept>
#include <vector>

int main()
{
  std::vector<int> numbers = {1, 2, 3, 4, 5};

  numbers.push_back(6);
  numbers.push_back(7);

  std::cout << "Numbers: ";
  for (int n : numbers)
  {
    std::cout << n << " ";
  }
  std::cout << "\n";

  std::cout << "Size: " << numbers.size() << "\n";
  std::cout << "Capacity: " << numbers.capacity() << "\n";
  std::cout << "First: " << numbers.front() << "\n";
  std::cout << "Last: " << numbers.back() << "\n";
  std::cout << "Element at index 2: " << numbers.at(2) << "\n";

  try
  {
    std::cout << numbers.at(100) << "\n";
  }
  catch (const std::out_of_range& ex)
  {
    std::cout << "Caught out_of_range from at(): " << ex.what() << "\n";
  }
}
