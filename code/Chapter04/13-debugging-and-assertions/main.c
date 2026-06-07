#include <assert.h>
#include <stdio.h>
#include <stdlib.h>

int* allocateInt(int value)
{
  int* p = malloc(sizeof(int));

  if (p == NULL)
  {
    return NULL;
  }

  *p = value;
  return p;
}

void printPointerDetails(const int* p)
{
  printf("Pointer address held by p: %p\n", (void*)p);
  assert(p != NULL);
  printf("Value at p: %d\n", *p);
}

int main(void)
{
  int* value = allocateInt(123);

  if (value == NULL)
  {
    printf("Allocation failed.\n");
    return 1;
  }

  printPointerDetails(value);

  free(value);
  value = NULL;

  return 0;
}
