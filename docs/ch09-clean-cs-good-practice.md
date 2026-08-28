# Good practices for writing clean C#

- [Good practices for writing clean C#](#good-practices-for-writing-clean-c)
- [Prefer clarity over cleverness](#prefer-clarity-over-cleverness)
- [Use meaningful names](#use-meaningful-names)
- [Avoid deeply nested code](#avoid-deeply-nested-code)
- [Avoid duplicated code](#avoid-duplicated-code)
- [Use exceptions appropriately](#use-exceptions-appropriately)
- [Use var thoughtfully](#use-var-thoughtfully)
- [Write defensive code](#write-defensive-code)
- [Use consistent formatting](#use-consistent-formatting)
- [Comment why, not what](#comment-why-not-what)
- [Keep learning modern language features](#keep-learning-modern-language-features)
- [Writing code for humans](#writing-code-for-humans)

This online-only section focuses on practical development habits and coding practices that help developers write cleaner, safer, and more maintainable C# applications. Learning syntax and language features is only part of becoming an effective developer. Professional software development also requires writing code that other people can understand, maintain, test, and extend over time. Clean code reduces bugs, simplifies debugging, improves collaboration, and makes applications easier to evolve as requirements change.

One of the reasons C# became so successful in enterprise development is that the language encourages structured, maintainable design. Features such as properties, strong typing, generics, interfaces, nullable analysis, and modern tooling all support cleaner coding practices. However, no language feature can automatically guarantee readable or maintainable software. Good habits still matter enormously.

This section introduces practical guidelines for writing clean and maintainable C# code. These recommendations are not rigid laws, but they reflect widely accepted conventions and lessons learned from decades of software development.

# Prefer clarity over cleverness

Readable code is usually more valuable than clever code. For example, this expression is technically concise:
```cs
return x > y ? x : y;
```

But excessive nesting quickly becomes difficult to understand:
```cs
return a > b ? (a > c ? a : c)
             : (b > c ? b : c);
```

Clearer code is often preferable:
```cs
int largest = a;

if (b > largest)
{
    largest = b;
}

if (c > largest)
{
    largest = c;
}

return largest;
```

Code is read far more often than it is written. Optimizing for readability usually improves long-term maintainability.

> **Prompt**: Show examples where clever code becomes difficult to maintain.

# Use meaningful names

Good naming is one of the simplest and most powerful ways to improve code quality.

Poor naming:
```cs
int x;
```

Better naming:
```cs
int playerScore;
```

Good names should:
- Describe intent clearly
- Avoid ambiguity
- Reflect business meaning
- Remain consistent

Class names should usually be nouns:
```cs
class Customer
{
}
```

Method names should usually describe actions:

```cs
SaveOrder();
CalculateTotal();
LoadPlayerData();
```

Poor naming forces readers to mentally decode the program constantly.

# Avoid deeply nested code

Excessive nesting reduces readability quickly.

Poor example:
```cs
if (user != null)
{
    if (user.IsActive)
    {
        if (user.HasPermission)
        {
            ProcessUser(user);
        }
    }
}
```

Cleaner approach:
```cs
if (user == null)
{
    return;
}

if (!user.IsActive)
{
    return;
}

if (!user.HasPermission)
{
    return;
}

ProcessUser(user);
```

Early returns often simplify control flow dramatically.

# Avoid duplicated code

Duplicate logic creates maintenance problems. If the same logic appears in multiple places, bugs and updates often require repeated fixes. Example of duplication:
```cs
double total = price + (price * taxRate);
```

Repeated many times throughout an application.

Better approach:
```cs
double CalculateTotal(double price)
{
    return price + (price * taxRate);
}
```

Centralized logic improves consistency and maintainability.

# Use exceptions appropriately

Exceptions should represent unexpected failures, not normal program flow.

Poor practice:

```cs
try
{
    int value = int.Parse(input);
}
catch
{
}
```

Better approach:
```cs
if (int.TryParse(input, out int value))
{
    Console.WriteLine(value);
}
```

Exceptions are expensive and can obscure program behavior if overused. Good applications combine validation, defensive coding, and targeted exception handling.

# Use var thoughtfully

The `var` keyword reduces repetitive type declarations:
```cs
var players = new List<string>();
```

This is usually clear and readable. However, avoid var when the type becomes unclear:
```cs
var result = ProcessData();
```

The reader cannot easily determine the type. Good C# developers balance conciseness with readability.

> **Prompt**: Please show me some examples where overusing var makes code harder to read.

# Write defensive code

Applications should anticipate invalid input and unexpected situations:
```cs
if (string.IsNullOrWhiteSpace(name))
{
    throw new ArgumentException(
        "Name is required.");
}
```

Defensive programming improves reliability and reduces difficult runtime bugs. Modern C# nullable reference analysis also helps identify many potential problems during compilation.

> **Good practice**: Prefer nullable-aware operators such as ?., ??, and ??= over deeply nested null checks. They usually produce cleaner and safer code.

# Use consistent formatting

Consistent formatting improves readability enormously. Modern C# projects usually rely on automatic formatting tools, analyzers, .editorconfig settings, and IDE formatting rules. Consistency matters more than personal stylistic preferences.

Most professional teams adopt shared formatting standards to reduce unnecessary debate and improve collaboration.

# Comment why, not what

Good code often explains itself through clear naming and structure.

Poor comment:
```cs
// Increment i
i++;
```

Better comment:
```cs
// Retry failed requests up to three times
```

Comments are most valuable when explaining intent, business rules, non-obvious decisions, and unusual constraints. Over-commenting obvious code can actually reduce readability, especially if they become out-of-date.

# Keep learning modern language features

C# evolves continuously. Modern features often improve safety, readability, maintainability, and especially performance. However, developers should adopt new features thoughtfully rather than using them simply because they are new. Good developers learn when features help and when simpler approaches remain clearer.
The best code is not necessarily the most advanced code. It is the code that other developers can understand and maintain confidently.

# Writing code for humans

One of the most important lessons in software development is that programs should be written for people as much as for computers. Compilers only require syntactically valid code. Humans require:
- Clarity
- Consistency
- Organization
- Understandable intent

Clean code reduces cognitive load and makes systems easier to evolve over time. This becomes increasingly important as applications grow from a few hundred lines into tens or hundreds of thousands of lines of code.

This is especially important now that more and more code is written by AIs. You need to be able to read that code, properly understand, and direct the AI to do better if it writes poorly structured code.

> **Prompt**: Please explain why AI-generated code sometimes becomes difficult to maintain.
