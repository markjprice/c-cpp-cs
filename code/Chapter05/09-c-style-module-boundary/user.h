#ifndef USER_H
#define USER_H

typedef struct User User;

User* user_create(int id, const char* name);
void user_print(const User* user);
int user_get_id(const User* user);
int user_set_name(User* user, const char* name);
void user_destroy(User* user);

#endif
