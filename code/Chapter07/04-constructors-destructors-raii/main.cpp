#include <cstdio>
#include <iostream>
#include <stdexcept>
#include <string>

class FileHandler
{
private:
  FILE* file = nullptr;
  std::string filename;

public:
  explicit FileHandler(const std::string& path)
    : filename(path)
  {
    file = std::fopen(filename.c_str(), "w");
    if (file == nullptr)
    {
      throw std::runtime_error("Could not open file: " + filename);
    }

    std::cout << "Opened file: " << filename << "\n";
  }

  void writeLine(const std::string& text)
  {
    if (file != nullptr)
    {
      std::fprintf(file, "%s\n", text.c_str());
    }
  }

  ~FileHandler()
  {
    if (file != nullptr)
    {
      std::fclose(file);
      std::cout << "Closed file: " << filename << "\n";
    }
  }

  FileHandler(const FileHandler&) = delete;
  FileHandler& operator=(const FileHandler&) = delete;
};

int main()
{
  try
  {
    FileHandler log("example.log");
    log.writeLine("Constructors acquire resources.");
    log.writeLine("Destructors release resources.");
  }
  catch (const std::exception& ex)
  {
    std::cerr << ex.what() << "\n";
    return 1;
  }

  std::cout << "The file was closed automatically when log went out of scope.\n";

  return 0;
}
