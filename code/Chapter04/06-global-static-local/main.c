#include <stdio.h>

int globalCounter = 0;

void incrementGlobal(void)
{
  globalCounter++;
  printf("globalCounter = %d\n", globalCounter);
}

void incrementStaticLocal(void)
{
  static int count = 0;
  count++;
  printf("static local count = %d\n", count);
}

void incrementLocal(void)
{
  int x = 0;
  x++;
  printf("ordinary local x = %d\n", x);
}

int main(void)
{
  printf("Calling incrementGlobal three times:\n");
  incrementGlobal();
  incrementGlobal();
  incrementGlobal();

  printf("\nCalling incrementStaticLocal three times:\n");
  incrementStaticLocal();
  incrementStaticLocal();
  incrementStaticLocal();

  printf("\nCalling incrementLocal three times:\n");
  incrementLocal();
  incrementLocal();
  incrementLocal();

  return 0;
}
