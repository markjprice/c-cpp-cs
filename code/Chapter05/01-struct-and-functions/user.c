#include <stdio.h>
#include <string.h>
#include "user.h"

static void copyName(User* user, const char* name)
{
  strncpy(user->name, name, sizeof(user->name) - 1);
  user->name[sizeof(user->name) - 1] = '\0';
}

void initUser(User* user, int id, const char* name)
{
  user->id = id;
  copyName(user, name);
  user->isActive = 1;
}

void activateUser(User* user)
{
  user->isActive = 1;
}

void deactivateUser(User* user)
{
  user->isActive = 0;
}

int isUserActive(const User* user)
{
  return user->isActive;
}

void printUser(const User* user)
{
  printf("User ID: %d, Name: %s, Active: %d\n",
    user->id, user->name, user->isActive);
}
