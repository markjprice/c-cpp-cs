#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void safeExample(void)
{
  int* arr = malloc(3 * sizeof(int));

  if (arr == NULL)
  {
    printf("Allocation failed.\n");
    return;
  }

  for (int i = 0; i < 3; i++)
  {
    arr[i] = i + 1;
  }

  for (int i = 0; i < 3; i++)
  {
    printf("arr[%d] = %d\n", i, arr[i]);
  }

  free(arr);
}

void deliberateLeak(void)
{
  int* p = malloc(sizeof(int));

  if (p == NULL)
  {
    return;
  }

  *p = 123;
  printf("Leaked value: %d\n", *p);

  /* Deliberately no free(p). Use a memory checker to detect this. */
}

void deliberateBufferOverflow(void)
{
  int* arr = malloc(3 * sizeof(int));

  if (arr == NULL)
  {
    return;
  }

  arr[3] = 10; /* Deliberately out of bounds. */
  printf("This line might or might not run: %d\n", arr[3]);

  free(arr);
}

void deliberateUseAfterFree(void)
{
  int* p = malloc(sizeof(int));

  if (p == NULL)
  {
    return;
  }

  *p = 99;
  free(p);

  printf("Use after free value: %d\n", *p); /* Deliberately invalid. */
}

int main(int argc, char* argv[])
{
  if (argc == 1)
  {
    printf("Running safe example.\n");
    printf("Optional unsafe modes: --leak, --overflow, --use-after-free\n\n");
    safeExample();
    return 0;
  }

  if (strcmp(argv[1], "--leak") == 0)
  {
    deliberateLeak();
    return 0;
  }

  if (strcmp(argv[1], "--overflow") == 0)
  {
    deliberateBufferOverflow();
    return 0;
  }

  if (strcmp(argv[1], "--use-after-free") == 0)
  {
    deliberateUseAfterFree();
    return 0;
  }

  printf("Unknown option.\n");
  return 1;
}
