#include <stdio.h>
#include "int_list.h"

int main(void)
{
  IntList numbers;

  if (!intListInit(&numbers, 2)) {
    puts("Could not allocate list.");
    return 1;
  }

  for (int i = 1; i <= 10; i++) {
    if (!intListAdd(&numbers, i * 10)) {
      puts("Could not add value.");
      intListFree(&numbers);
      return 1;
    }
  }

  intListPrint(&numbers);

  int value;
  if (intListGet(&numbers, 3, &value)) {
    printf("Value at index 3: %d\n", value);
  }

  intListFree(&numbers);

  puts("\nC has no built-in dynamic list, so we built one manually.");
  return 0;
}
