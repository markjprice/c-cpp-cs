#include <stdio.h>
#include <string.h>

typedef struct
{
  int id;
  char name[50];
} User;

void printUser(const User* user)
{
  if (user == NULL)
  {
    printf("No user to print.\n");
    return;
  }

  printf("ID: %d\n", user->id);
  printf("Name: %s\n", user->name);
}

int main(void)
{
  User user1 = {1, "Alice"};
  User* p = &user1;

  user1.id = 2;
  strncpy(user1.name, "Alice Smith", sizeof(user1.name) - 1);
  user1.name[sizeof(user1.name) - 1] = '\0';

  printf("Using dot operator with a struct value:\n");
  printf("ID: %d\n", user1.id);
  printf("Name: %s\n\n", user1.name);

  p->id = 3;

  printf("Using arrow operator with a pointer to struct:\n");
  printUser(p);

  return 0;
}
