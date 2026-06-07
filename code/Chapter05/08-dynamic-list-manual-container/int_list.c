#include <stdio.h>
#include <stdlib.h>
#include "int_list.h"

int intListInit(IntList* list, size_t initialCapacity)
{
  if (initialCapacity == 0) {
    initialCapacity = 4;
  }

  list->items = malloc(initialCapacity * sizeof(int));

  if (list->items == NULL) {
    list->count = 0;
    list->capacity = 0;
    return 0;
  }

  list->count = 0;
  list->capacity = initialCapacity;
  return 1;
}

int intListAdd(IntList* list, int value)
{
  if (list->count == list->capacity) {
    size_t newCapacity = list->capacity * 2;
    int* resized = realloc(list->items, newCapacity * sizeof(int));

    if (resized == NULL) {
      return 0;
    }

    list->items = resized;
    list->capacity = newCapacity;
  }

  list->items[list->count] = value;
  list->count++;
  return 1;
}

int intListGet(const IntList* list, size_t index, int* value)
{
  if (index >= list->count) {
    return 0;
  }

  *value = list->items[index];
  return 1;
}

void intListPrint(const IntList* list)
{
  printf("IntList count=%zu capacity=%zu values:", list->count, list->capacity);

  for (size_t i = 0; i < list->count; i++) {
    printf(" %d", list->items[i]);
  }

  printf("\n");
}

void intListFree(IntList* list)
{
  free(list->items);
  list->items = NULL;
  list->count = 0;
  list->capacity = 0;
}
