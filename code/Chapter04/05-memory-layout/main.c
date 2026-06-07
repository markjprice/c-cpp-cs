#include <stdio.h>
#include <stdlib.h>

int global_var = 100;
static int file_static_var = 200;

void example(void)
{
  int local_var = 10;
  static int function_static_var = 300;
  int* heap_var = malloc(sizeof(int));

  if (heap_var == NULL)
  {
    printf("Memory allocation failed.\n");
    return;
  }

  *heap_var = 50;

  printf("Value summary: %d %d %d %d\n", global_var, file_static_var, function_static_var, *heap_var);

  printf("\nAddress summary:\n");
  printf("example function address: %p\n", (void*)example);
  printf("global_var address: %p\n", (void*)&global_var);
  printf("file_static_var address: %p\n", (void*)&file_static_var);
  printf("function_static_var address: %p\n", (void*)&function_static_var);
  printf("local_var address: %p\n", (void*)&local_var);
  printf("heap_var pointer variable address: %p\n", (void*)&heap_var);
  printf("heap memory address held by heap_var: %p\n", (void*)heap_var);

  free(heap_var);
  heap_var = NULL;
}

int main(void)
{
  example();
  return 0;
}
