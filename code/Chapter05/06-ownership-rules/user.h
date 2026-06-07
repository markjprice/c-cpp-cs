#ifndef USER_H
#define USER_H

typedef struct {
  int id;
  char name[50];
} User;

/*
  Ownership rule:
  createUser allocates a User on the heap.
  The caller owns the returned pointer and must call deleteUser exactly once.
*/
User* createUser(int id, const char* name);
void printUser(const User* user);
void deleteUser(User* user);

#endif
