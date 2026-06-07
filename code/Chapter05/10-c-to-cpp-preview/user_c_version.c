#include <stdio.h>
#include <string.h>

typedef struct {
  int id;
  char name[50];
  int isActive;
} User;

void initUser(User* user, int id, const char* name)
{
  user->id = id;
  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';
  user->isActive = 1;
}

void printUser(const User* user)
{
  printf("C User ID: %d, Name: %s, Active: %d\n",
    user->id, user->name, user->isActive);
}

int main(void)
{
  User user;
  initUser(&user, 1, "Alice");

  user.isActive = 42; // Still allowed.

  printUser(&user);
  return 0;
}
