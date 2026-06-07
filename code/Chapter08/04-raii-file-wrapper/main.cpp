#include <cstdio>
#include <iostream>
#include <stdexcept>

class File
{
private:
  std::FILE* file = nullptr;

public:
  explicit File(const char* filename)
  {
    file = std::fopen(filename, "w");
    if (file == nullptr)
    {
      throw std::runtime_error("Could not open file.");
    }
    std::cout << "File opened.\n";
  }

  ~File()
  {
    if (file != nullptr)
    {
      std::fclose(file);
      std::cout << "File closed automatically.\n";
    }
  }

  void writeLine(const char* text)
  {
    std::fprintf(file, "%s\n", text);
  }

  File(const File&) = delete;
  File& operator=(const File&) = delete;
};

void process(bool stopEarly)
{
  File file("raii-output.txt");
  file.writeLine("This file is managed by an RAII wrapper.");
  if (stopEarly)
  {
    std::cout << "Returning early. Destructor will still run.\n";
    return;
  }
  file.writeLine("Normal completion.");
}

int main()
{
  process(true);
  std::cout << "Check raii-output.txt.\n";
}
