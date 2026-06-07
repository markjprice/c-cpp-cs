#include <stdio.h>
#include <stdlib.h>

int* createValue(int value)
{
  int* p = malloc(sizeof(int));

  if (p == NULL)
  {
    return NULL;
  }

  *p = value;
  return p;
}

void printAndDestroyValue(int* p)
{
  if (p == NULL)
  {
    printf("No value to print.\n");
    return;
  }

  printf("Value: %d\n", *p);
  free(p);
}

int main(void)
{
  int* value = createValue(42);

  if (value == NULL)
  {
    printf("Memory allocation failed.\n");
    return 1;
  }

  printAndDestroyValue(value);
  value = NULL;

  return 0;
}
