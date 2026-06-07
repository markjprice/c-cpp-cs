#include <stdio.h>
#include <string.h>
#include "user.h"

int main(void)
{
  User user;
  initUser(&user, 1, "Alice");

  puts("Valid state after initUser:");
  printUser(&user);

  puts("\nDirect field access can bypass the rules:");
  user.id = -1;             // Invalid ID.
  strcpy(user.name, "");    // Empty name.
  user.isActive = 999;      // Meaningless active flag.

  printUser(&user);

  puts("\nThe compiler allowed the invalid state because C has no encapsulation.");
  return 0;
}
