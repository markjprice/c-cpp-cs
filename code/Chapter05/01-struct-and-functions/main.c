#include "user.h"

int main(void)
{
  User user;

  initUser(&user, 1, "Alice");
  printUser(&user);

  deactivateUser(&user);
  printUser(&user);

  activateUser(&user);
  printUser(&user);

  return 0;
}
