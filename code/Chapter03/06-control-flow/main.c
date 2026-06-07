#include <stdio.h>

int main(void)
{
  int age = 20;

  if (age >= 18)
  {
    printf("You are an adult.\n");
  }
  else
  {
    printf("You are a minor.\n");
  }

  int score = 85;

  if (score >= 90)
  {
    printf("Grade A\n");
  }
  else if (score >= 75)
  {
    printf("Grade B\n");
  }
  else
  {
    printf("Grade C\n");
  }

  int day = 3;

  switch (day)
  {
    case 1:
      printf("Monday\n");
      break;
    case 2:
      printf("Tuesday\n");
      break;
    case 3:
      printf("Wednesday\n");
      break;
    default:
      printf("Invalid day\n");
      break;
  }

  printf("\nfor loop:\n");
  for (int i = 0; i < 5; i++)
  {
    printf("i = %d\n", i);
  }

  printf("\nwhile loop:\n");
  int i = 0;
  while (i < 5)
  {
    printf("i = %d\n", i);
    i++;
  }

  printf("\ndo-while loop:\n");
  int j = 0;
  do
  {
    printf("j = %d\n", j);
    j++;
  } while (j < 5);

  printf("\nbreak and continue:\n");
  for (int n = 0; n < 10; n++)
  {
    if (n == 2)
    {
      continue;
    }

    if (n == 5)
    {
      break;
    }

    printf("n = %d\n", n);
  }

  printf("\ngoto label example:\n");
  int count = 0;

start:
  printf("count = %d\n", count);
  count++;

  if (count < 3)
  {
    goto start;
  }

  return 0;
}
