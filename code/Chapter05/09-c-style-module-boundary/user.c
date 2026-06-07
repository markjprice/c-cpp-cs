#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "user.h"

struct User {
  int id;
  char name[50];
};

User* user_create(int id, const char* name)
{
  if (id <= 0 || name == NULL || name[0] == '\0') {
    return NULL;
  }

  User* user = malloc(sizeof(User));

  if (user == NULL) {
    return NULL;
  }

  user->id = id;

  if (!user_set_name(user, name)) {
    free(user);
    return NULL;
  }

  return user;
}

void user_print(const User* user)
{
  if (user != NULL) {
    printf("User ID: %d, Name: %s\n", user->id, user->name);
  }
}

int user_get_id(const User* user)
{
  return user == NULL ? 0 : user->id;
}

int user_set_name(User* user, const char* name)
{
  if (user == NULL || name == NULL || name[0] == '\0') {
    return 0;
  }

  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';
  return 1;
}

void user_destroy(User* user)
{
  free(user);
}
