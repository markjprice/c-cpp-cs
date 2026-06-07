#include <iostream>
#include <string>

void safeRun()
{
  int* p = new int(42);
  std::cout << "Safe value: " << *p << "\n";
  delete p;
}

void useAfterFree()
{
  int* p = new int(42);
  delete p;
  std::cout << "Use after free: " << *p << "\n";
}

void outOfBounds()
{
  int* values = new int[3]{1, 2, 3};
  values[3] = 4;
  std::cout << values[3] << "\n";
  delete[] values;
}

void leak()
{
  int* p = new int(42);
  std::cout << "Leaked value: " << *p << "\n";
}

int main(int argc, char* argv[])
{
  if (argc < 2)
  {
    safeRun();
    std::cout << "Run with: use-after-free | out-of-bounds | leak\n";
    return 0;
  }

  const std::string mode = argv[1];
  if (mode == "use-after-free") useAfterFree();
  else if (mode == "out-of-bounds") outOfBounds();
  else if (mode == "leak") leak();
  else safeRun();
}
