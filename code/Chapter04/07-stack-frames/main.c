#include <stdio.h>

void func3(void)
{
  int local3 = 3;
  printf("func3 local3 address: %p\n", (void*)&local3);
}

void func2(void)
{
  int local2 = 2;
  printf("func2 local2 address: %p\n", (void*)&local2);
  func3();
}

void func1(void)
{
  int local1 = 1;
  printf("func1 local1 address: %p\n", (void*)&local1);
  func2();
}

int main(void)
{
  int mainLocal = 0;
  printf("main mainLocal address: %p\n", (void*)&mainLocal);
  func1();
  return 0;
}
