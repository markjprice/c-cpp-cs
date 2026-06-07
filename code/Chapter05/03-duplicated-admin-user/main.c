#include <stdio.h>
#include <string.h>

typedef struct {
  int id;
  char name[50];
  int isActive;
} User;

typedef struct {
  int id;
  char name[50];
  int isActive;
  int permissionLevel;
} AdminUser;

void initUser(User* user, int id, const char* name)
{
  user->id = id;
  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';
  user->isActive = 1;
}

void initAdminUser(AdminUser* user, int id, const char* name, int permissionLevel)
{
  user->id = id;
  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';
  user->isActive = 1;
  user->permissionLevel = permissionLevel;
}

void printUser(const User* user)
{
  printf("User ID: %d, Name: %s, Active: %d\n",
    user->id, user->name, user->isActive);
}

void printAdminUser(const AdminUser* user)
{
  printf("Admin ID: %d, Name: %s, Active: %d, Permission level: %d\n",
    user->id, user->name, user->isActive, user->permissionLevel);
}

int main(void)
{
  User alice;
  AdminUser bob;

  initUser(&alice, 1, "Alice");
  initAdminUser(&bob, 2, "Bob", 5);

  printUser(&alice);
  printAdminUser(&bob);

  puts("\nMuch of the logic is duplicated because C has no inheritance or methods.");
  return 0;
}
