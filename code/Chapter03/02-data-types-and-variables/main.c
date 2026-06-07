#include <stdio.h>
#include <string.h>

#define MAX_NAME_LENGTH 50

typedef struct
{
  int id;
  char name[MAX_NAME_LENGTH];
  int age;
} User;

int main(void)
{
  int age = 30;
  float price = 19.99f;
  double pi = 3.1415926535;
  char grade = 'A';

  printf("Primitive values:\n");
  printf("Age: %d\n", age);
  printf("Price: %.2f\n", price);
  printf("Pi: %.10f\n", pi);
  printf("Grade: %c\n\n", grade);

  char name[] = "Alice";
  printf("Original name: %s\n", name);
  name[0] = 'a';
  printf("Modified name: %s\n\n", name);

  const char* message = "Hello";
  printf("Message: %s\n\n", message);

  char destination[MAX_NAME_LENGTH];
  strncpy(destination, "Alexander", sizeof(destination) - 1);
  destination[sizeof(destination) - 1] = '\0';
  printf("Copied string: %s\n\n", destination);

  User user = {1, "", 30};
  strncpy(user.name, "Alice", sizeof(user.name) - 1);
  user.name[sizeof(user.name) - 1] = '\0';

  printf("User: ID: %d, Name: %s, Age: %d\n", user.id, user.name, user.age);

  const double taxRate = 0.20;
  unsigned int itemCount = 10;

  printf("Tax rate: %.2f\n", taxRate);
  printf("Item count: %u\n", itemCount);

  return 0;
}
