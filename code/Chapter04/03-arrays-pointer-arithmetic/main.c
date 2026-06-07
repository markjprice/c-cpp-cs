#include <stdio.h>

int main(void)
{
  int numbers[3] = {10, 20, 30};
  int count = (int)(sizeof(numbers) / sizeof(numbers[0]));

  printf("Array element count: %d\n\n", count);

  for (int i = 0; i < count; i++)
  {
    printf("numbers[%d] = %d\n", i, numbers[i]);
    printf("*(numbers + %d) = %d\n", i, *(numbers + i));
    printf("address = %p\n\n", (void*)(numbers + i));
  }

  int* p = numbers;
  printf("p points to: %p, value: %d\n", (void*)p, *p);

  p = p + 1;
  printf("After p = p + 1, p points to: %p, value: %d\n", (void*)p, *p);

  return 0;
}
