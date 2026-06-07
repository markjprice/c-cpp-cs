#ifndef INT_LIST_H
#define INT_LIST_H

#include <stddef.h>

typedef struct {
  int* items;
  size_t count;
  size_t capacity;
} IntList;

int intListInit(IntList* list, size_t initialCapacity);
int intListAdd(IntList* list, int value);
int intListGet(const IntList* list, size_t index, int* value);
void intListPrint(const IntList* list);
void intListFree(IntList* list);

#endif
