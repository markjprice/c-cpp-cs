#include <iostream>
#include "math_utils.h"

int main()
{
  logMessage("Default level is used");
  logMessage("Explicit warning level", 2);

  connect("example.com");
  connect("example.com", 443);

  std::cout << "square(7): " << square(7) << "\n";
}
