#include <stdio.h>
#include "input.h"

int readInt(const char* prompt)
{
    int value;

    printf("%s", prompt);
    scanf("%d", &value);

    return value;
}
