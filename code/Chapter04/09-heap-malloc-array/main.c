#include <stdio.h>
#include <stdlib.h>

int main(void)
{
  int n = 5;
  int* arr = malloc((size_t)n * sizeof(int));

  if (arr == NULL)
  {
    printf("Memory allocation failed.\n");
    return 1;
  }

  for (int i = 0; i < n; i++)
  {
    arr[i] = (i + 1) * 10;
  }

  for (int i = 0; i < n; i++)
  {
    printf("arr[%d] = %d\n", i, arr[i]);
  }

  free(arr);
  arr = NULL;

  return 0;
}
