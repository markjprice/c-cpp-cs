#include <stdio.h>
#include "user.h"

int main(void)
{
  User* user = user_create(1, "Alice");

  if (user == NULL) {
    puts("Could not create user.");
    return 1;
  }

  user_print(user);

  /*
    This would not compile because the struct fields are hidden:
    user->id = -1;
  */

  if (!user_set_name(user, "")) {
    puts("Empty name rejected.");
  }

  user_set_name(user, "Alicia");
  user_print(user);

  user_destroy(user);
  user = NULL;

  puts("\nC can simulate a private boundary, but it requires a deliberate pattern.");
  return 0;
}
