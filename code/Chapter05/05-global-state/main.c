#include <stdio.h>

int currentUserId = 0;

void login(int id)
{
  currentUserId = id;
  printf("Logged in user: %d\n", currentUserId);
}

void auditAction(const char* action)
{
  printf("Audit: user %d performed %s\n", currentUserId, action);
}

void resetSession(void)
{
  currentUserId = -1;
  puts("Session reset.");
}

int main(void)
{
  login(5);
  auditAction("view-account");

  puts("\nA different function changes the global state:");
  resetSession();

  puts("\nThe audit function now sees the changed global value:");
  auditAction("make-payment");

  puts("\nThis is easy to understand here, but difficult in a large codebase.");
  return 0;
}
