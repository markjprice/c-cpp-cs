#include <iostream>
#include "math_utils.h"

void logMessage(const char* message, int level)
{
  std::cout << "Level " << level << ": " << message << "\n";
}

void connect(const char* host, int port)
{
  std::cout << "Connecting to " << host << ":" << port << "\n";
}
