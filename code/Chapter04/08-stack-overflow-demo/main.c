#include <stdio.h>
#include <string.h>

void recurse(int depth)
{
  int localValue = depth;

  if (depth % 1000 == 0)
  {
    printf("Depth: %d, localValue address: %p\n", depth, (void*)&localValue);
  }

  recurse(depth + 1);
}

void safeRecursion(int depth, int maxDepth)
{
  int localValue = depth;
  printf("Depth: %d, localValue address: %p\n", depth, (void*)&localValue);

  if (depth >= maxDepth)
  {
    return;
  }

  safeRecursion(depth + 1, maxDepth);
}

int main(int argc, char* argv[])
{
  if (argc > 1 && strcmp(argv[1], "--unsafe") == 0)
  {
    printf("Unsafe recursion selected. This program will probably crash.\n");
    recurse(1);
    return 0;
  }

  printf("Running safe recursion demo.\n");
  printf("Pass --unsafe to deliberately trigger stack overflow.\n\n");
  safeRecursion(1, 5);

  return 0;
}
