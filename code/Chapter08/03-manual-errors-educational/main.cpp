#include <iostream>
#include <string>

void leakExample()
{
  int* p = new int(42);
  std::cout << "Leaked value: " << *p << "\n";
  // Deliberately no delete. Use a memory tool to detect this.
}

void danglingExample()
{
  int* p = new int(42);
  delete p;
  std::cout << "About to read through a dangling pointer. This is undefined behavior.\n";
  std::cout << *p << "\n";
}

void doubleDeleteExample()
{
  int* p = new int(42);
  delete p;
  std::cout << "About to delete the same pointer again. This is undefined behavior.\n";
  delete p;
}

void mismatchExample()
{
  int* values = new int[3]{1, 2, 3};
  std::cout << "About to use delete instead of delete[]. This is undefined behavior.\n";
  delete values; // wrong on purpose
}

int main(int argc, char* argv[])
{
  if (argc < 2)
  {
    std::cout << "Safe default run. No unsafe memory bug triggered.\n";
    std::cout << "Run with one argument to trigger an educational error:\n";
    std::cout << "  leak | dangling | double-delete | mismatch\n";
    return 0;
  }

  const std::string mode = argv[1];
  if (mode == "leak") leakExample();
  else if (mode == "dangling") danglingExample();
  else if (mode == "double-delete") doubleDeleteExample();
  else if (mode == "mismatch") mismatchExample();
  else std::cout << "Unknown mode.\n";
}
