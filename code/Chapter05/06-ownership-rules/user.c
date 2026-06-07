#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "user.h"

User* createUser(int id, const char* name)
{
  User* user = malloc(sizeof(User));

  if (user == NULL) {
    return NULL;
  }

  user->id = id;
  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';

  return user;
}

void printUser(const User* user)
{
  if (user == NULL) {
    puts("User is NULL.");
    return;
  }

  printf("User ID: %d, Name: %s\n", user->id, user->name);
}

void deleteUser(User* user)
{
  free(user);
}
