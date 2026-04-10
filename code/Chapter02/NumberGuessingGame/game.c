#include <stdio.h>
#include "game.h"
#include "input.h"

void playGame(void)
{
    const int secretNumber = 42;
    int guess = 0;
    int attempts = 0;

    printf("I am thinking of a number between 1 and 100.\n");
    printf("Try to guess it.\n\n");

    while (guess != secretNumber)
    {
        guess = readInt("Enter your guess: ");
        attempts++;

        if (guess < secretNumber)
        {
            printf("Too low.\n\n");
        }
        else if (guess > secretNumber)
        {
            printf("Too high.\n\n");
        }
        else
        {
            printf("Correct! You guessed the number in %d attempts.\n\n", attempts);
        }
    }
}
