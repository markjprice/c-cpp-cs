#include <stdio.h>

int main(void)
{
  int a = 10;
  int b = 3;

  printf("Arithmetic operators:\n");
  printf("%d + %d = %d\n", a, b, a + b);
  printf("%d - %d = %d\n", a, b, a - b);
  printf("%d * %d = %d\n", a, b, a * b);
  printf("%d / %d = %d\n", a, b, a / b);
  printf("%d %% %d = %d\n\n", a, b, a % b);

  printf("Relational operators:\n");
  printf("a == b: %d\n", a == b);
  printf("a != b: %d\n", a != b);
  printf("a > b: %d\n", a > b);
  printf("a < b: %d\n\n", a < b);

  int age = 20;
  int hasTicket = 1;
  printf("Logical operators:\n");
  printf("age >= 18 && hasTicket: %d\n", age >= 18 && hasTicket);
  printf("age < 18 || hasTicket: %d\n", age < 18 || hasTicket);
  printf("!hasTicket: %d\n\n", !hasTicket);

  int x = 5; // 0101
  int y = 3; // 0011
  printf("Bitwise operators:\n");
  printf("x & y = %d\n", x & y);
  printf("x | y = %d\n", x | y);
  printf("x ^ y = %d\n", x ^ y);
  printf("x << 1 = %d\n", x << 1);
  printf("x >> 1 = %d\n\n", x >> 1);

  int value = 10;
  value += 5;
  value *= 2;
  printf("Compound assignment result: %d\n", value);

  int post = value++;
  int pre = ++value;
  printf("Post-increment result: %d, current value: %d\n", post, value);
  printf("Pre-increment result: %d, current value: %d\n\n", pre, value);

  const char* message = (age >= 18) ? "Adult" : "Minor";
  printf("Ternary operator result: %s\n", message);

  int precedence = 2 + (3 * 4);
  printf("2 + (3 * 4) = %d\n", precedence);

  return 0;
}
