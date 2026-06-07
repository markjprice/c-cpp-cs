#include <stdio.h>
#include <stdlib.h>

int main(void)
{
  int count = 3;
  int* numbers = calloc((size_t)count, sizeof(int));

  if (numbers == NULL)
  {
    printf("Initial allocation failed.\n");
    return 1;
  }

  printf("After calloc:\n");
  for (int i = 0; i < count; i++)
  {
    printf("numbers[%d] = %d\n", i, numbers[i]);
  }

  for (int i = 0; i < count; i++)
  {
    numbers[i] = (i + 1) * 100;
  }

  int newCount = 5;
  int* temp = realloc(numbers, (size_t)newCount * sizeof(int));

  if (temp == NULL)
  {
    printf("Reallocation failed. Original memory is still valid.\n");
    free(numbers);
    return 1;
  }

  numbers = temp;

  for (int i = count; i < newCount; i++)
  {
    numbers[i] = (i + 1) * 100;
  }

  printf("\nAfter realloc:\n");
  for (int i = 0; i < newCount; i++)
  {
    printf("numbers[%d] = %d\n", i, numbers[i]);
  }

  free(numbers);
  numbers = NULL;

  return 0;
}
