#ifndef USER_H
#define USER_H

typedef struct {
  int id;
  char name[50];
  int isActive;
} User;

void initUser(User* user, int id, const char* name);
void activateUser(User* user);
void deactivateUser(User* user);
int isUserActive(const User* user);
void printUser(const User* user);

#endif
