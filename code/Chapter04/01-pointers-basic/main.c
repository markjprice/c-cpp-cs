#include <stdio.h>

int main(void)
{
  int x = 10;
  int* p = &x;

  printf("x stores the value: %d\n", x);
  printf("&x is the address of x: %p\n", (void*)&x);
  printf("p stores the same address: %p\n", (void*)p);
  printf("*p is the value at that address: %d\n", *p);

  *p = 20;
  printf("After *p = 20, x is now: %d\n", x);

  return 0;
}
