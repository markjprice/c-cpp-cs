#include <stdio.h>

int main(void)
{
  int age = 25;
  int* p = &age;

  printf("age value: %d\n", age);
  printf("age address: %p\n", (void*)&age);
  printf("p stores address: %p\n", (void*)p);
  printf("*p reads value at address: %d\n", *p);

  *p = 26;
  printf("age after changing *p: %d\n", age);

  return 0;
}
