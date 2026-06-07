#ifndef MATH_UTILS_H
#define MATH_UTILS_H

inline int square(int x)
{
  return x * x;
}

void logMessage(const char* message, int level = 1);
void connect(const char* host, int port = 80);

#endif
