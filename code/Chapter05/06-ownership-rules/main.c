#include <stdio.h>
#include "user.h"

int main(void)
{
  User* user = createUser(1, "Alice");

  if (user == NULL) {
    puts("Could not create user.");
    return 1;
  }

  printUser(user);

  /*
    This program follows the ownership rule from user.h:
    the caller received the pointer, so the caller frees it.
  */
  deleteUser(user);
  user = NULL;

  puts("User deleted safely.");
  return 0;
}
