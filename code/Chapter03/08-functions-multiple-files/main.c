#include <stdio.h>
#include "math_utils.h"

int main(void)
{
  int sum = add(2, 3);
  int squared = square(5);

  printf("2 + 3 = %d\n", sum);
  printf("5 squared = %d\n", squared);

  return 0;
}
