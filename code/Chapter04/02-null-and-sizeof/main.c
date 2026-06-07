#include <stdio.h>
#include <stdlib.h>

int main(void)
{
  int* p = NULL;

  if (p == NULL)
  {
    printf("p does not currently point to valid memory.\n");
  }

  p = malloc(sizeof(int));

  if (p == NULL)
  {
    printf("Memory allocation failed.\n");
    return 1;
  }

  *p = 42;

  printf("*p = %d\n", *p);
  printf("sizeof(char) = %zu byte(s)\n", sizeof(char));
  printf("sizeof(int) = %zu byte(s)\n", sizeof(int));
  printf("sizeof(double) = %zu byte(s)\n", sizeof(double));
  printf("sizeof(p) = %zu byte(s)\n", sizeof(p));
  printf("sizeof(*p) = %zu byte(s)\n", sizeof(*p));

  free(p);
  p = NULL;

  return 0;
}
