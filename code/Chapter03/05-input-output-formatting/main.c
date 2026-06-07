#include <stdio.h>

int main(void)
{
  int count = 5;
  double price = 9.99;
  char grade = 'A';
  char name[] = "Alice";

  printf("Formatted output:\n");
  printf("Name: %s\n", name);
  printf("Count: %d\n", count);
  printf("Price: %.2f\n", price);
  printf("Grade: %c\n", grade);
  printf("Discount: 10%%\n\n");

  printf("Aligned output:\n");
  printf("%-10s %8s\n", "Item", "Price");
  printf("%-10s %8.2f\n", "Pen", 1.50);
  printf("%-10s %8.2f\n\n", "Notebook", 4.99);

  printf("Escape sequences:\n");
  printf("Hello\nWorld\n");
  printf("Name\tAge\n");
  printf("Alice\t30\n");
  printf("This is a backslash: \\\n");
  printf("She said: \"Hello\"\n\n");

  int age;
  float temperature;
  char letter;
  char firstName[50];

  printf("Enter your age: ");
  scanf("%d", &age);

  printf("Enter today\'s temperature: ");
  scanf("%f", &temperature);

  printf("Enter one letter grade: ");
  scanf(" %c", &letter);

  printf("Enter your first name: ");
  scanf("%49s", firstName);

  printf("\nYou entered:\n");
  printf("Age: %d\n", age);
  printf("Temperature: %.1f\n", temperature);
  printf("Letter: %c\n", letter);
  printf("First name: %s\n", firstName);

  return 0;
}
