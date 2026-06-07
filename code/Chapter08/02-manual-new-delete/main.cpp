#include <iostream>

int main()
{
  int* p = new int(42); // legacy style: not recommended in modern C++
  std::cout << "Value: " << *p << "\n";
  delete p;
  p = nullptr;

  int* numbers = new int[5]{1, 2, 3, 4, 5}; // legacy style: not recommended
  for (int i = 0; i < 5; ++i)
  {
    std::cout << numbers[i] << " ";
  }
  std::cout << "\n";
  delete[] numbers;
  numbers = nullptr;

  std::cout << "Manual cleanup completed. Prefer RAII and smart pointers in modern C++.\n";
}
