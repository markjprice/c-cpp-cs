# Modern syntax enhancements

- [Modern syntax enhancements](#modern-syntax-enhancements)
- [Target-typed new](#target-typed-new)
- [Collection expressions](#collection-expressions)
- [Primary constructors](#primary-constructors)
- [`global using` directives](#global-using-directives)
- [File-scoped namespaces](#file-scoped-namespaces)
- [Raw string literals](#raw-string-literals)
- [Required members](#required-members)
- [Modern syntax versus readability](#modern-syntax-versus-readability)
- [Getting an AI to write modern C#](#getting-an-ai-to-write-modern-c)


This online-only section explores modern syntax enhancements and how they make contemporary C# code more concise and expressive.

Modern C# includes many syntax improvements designed to reduce boilerplate code and improve readability. Individually, some of these features may appear small, but together they significantly change the feel of contemporary C# development.

Earlier versions of C# often required:
- Repetitive type names
- Verbose object initialization
- Deeply nested namespace structures
- Awkward string escaping
- Unnecessary ceremony

Recent versions of the language focus heavily on expressing intent more directly while preserving strong typing and readability.

Many of these features are now common in professional C# codebases, so understanding them is important even when working with existing applications written by other developers.

# Target-typed new

Earlier versions of C# required type names to be repeated during object creation:
```cs
List<string> names = new List<string>();
```

Modern C# supports target-typed new, allowing the compiler to infer the type from the assignment context:
```cs
List<string> names = new();
```

This reduces redundancy while preserving static typing. Target-typed new is especially useful with generic types, long type names, and nested object initialization:
```
Dictionary<string, List<int>> data = new();
```

Without target typing, this declaration becomes much more verbose. The feature works only when the compiler can clearly determine the target type.

# Collection expressions

Modern C# introduces collection expressions for concise collection initialization:
```cs
List<int> values = [1, 2, 3, 4];
```

This replaces older syntax such as:
```cs
List<int> values = new List<int> { 1, 2, 3, 4 };
```

Collection expressions work naturally with arrays, lists, spans, and other collection-like types.

They also support spreading existing collections:
```cs
int[] first = [1, 2];

int[] second = [.. first, 3, 4];
```

This syntax is heavily influenced by modern JavaScript and functional programming languages.

# Primary constructors

Primary constructors simplify class and structure initialization by moving constructor parameters directly into the type declaration. Traditional constructor syntax:
```cs
public class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }
}
```

Modern primary constructor syntax:
```cs
public class Person(string name)
{
    public string Name { get; } = name;
}
```

Primary constructors reduce boilerplate while keeping initialization logic close to the type definition. This syntax is especially useful for lightweight data models, immutable objects, and dependency injection scenarios. Records also rely heavily on primary-constructor-style syntax.

# `global using` directives

Large C# applications often contain many repeated `using` directives:
```cs
using System;
using System.Collections.Generic;
using System.Linq;
```

Modern C# allows these directives to be declared globally:
```cs
global using System;
global using System.Collections.Generic;
global using System.Linq;
```

These global imports apply across the entire project. ASP.NET Core projects and modern templates commonly use `global using` directives automatically.

# File-scoped namespaces

Traditional namespaces required additional indentation:
```cs
namespace MyApplication.Models
{
    public class Product
    {
    }
}
```

Modern C# supports file-scoped namespaces:
```cs
namespace MyApplication.Models;

public class Product
{
}
```

This reduces nesting and improves readability in large projects. The change may seem small, but it significantly cleans up many code files.

# Raw string literals

Traditional string literals often become difficult to read when containing quotes, JSON, XML, regular expressions, and multi-line text. Older syntax required heavy escaping:
```cs
string json =
    "{ \"name\": \"Alice\" }";
```

Raw string literals simplify this dramatically:
```cs
string json = """
{
    "name": "Alice"
}
""";
```

This syntax preserves formatting, avoids escaping, and therefore improves readability.

Raw strings also support interpolation:
```cs
string name = "Alice";

string json = $$"""
{
    "name": "{{name}}"
}
""";
```

The additional $ characters allow interpolation markers to coexist naturally with embedded braces. This is extremely helpful when generating structured text formats programmatically.

# Required members

Earlier versions of C# sometimes allowed objects to be created in incomplete states:
```cs
public class Customer
{
    public string Name { get; set; }
}
```

Nothing prevented this:
```cs
Customer customer = new();
```

Modern C# introduces required members:
```cs
public class Customer
{
    public required string Name { get; init; }
}
```

Now the compiler enforces initialization:
```cs
Customer customer = new()
{
    Name = "Alice"
};
```

This improves correctness by ensuring important properties are initialized properly.

# Modern syntax versus readability

Modern syntax enhancements reduce boilerplate, but concise syntax is not automatically better syntax:
```cs
var result = items
    .Where(x => x.IsActive)
    .Select(x => new(x.Name, x.Id));
```

This may be perfectly readable to experienced developers but confusing to beginners. Good modern C# code balances conciseness, clarity, and maintainability. Overusing advanced syntax can make code harder to understand rather than easier. As with any language feature, readability should remain the primary goal.

> **Prompt**: Show examples of modern C# syntax that beginners often misuse.

> **Good practice**: Prefer expressing intent over minimizing line count. Modern C# syntax should make code clearer, not merely shorter.

# Getting an AI to write modern C#

When asking an AI chatbot or coding agent to write C# code, do not simply ask for “some C# code.” Models often default to older, safer, widely seen syntax unless you explicitly specify the language version, target framework, coding style, and design constraints.

A good reusable prompt would be:
```
Write this code for .NET 11 and C# 15.

Follow these rules:
- Enable nullable reference types and avoid nullable warnings.
- Use file-scoped namespaces.
- Use collection expressions, target-typed new, pattern matching, switch expressions, and primary constructors where they improve readability.
- Use records for immutable data models.
- Use union types when a value can be one of a closed set of valid cases.
- Use LINQ for clear sequence transformations, but avoid LINQ where a simple loop is more readable or more efficient.
- Avoid unnecessary inheritance.
- Prefer immutable design using init-only properties, readonly fields, and with-expressions.
- Do not use obsolete or pre-modern C# syntax unless there is a clear reason.
- Explain any tradeoffs, especially around allocation, deferred execution, and readability.
```

For stricter results, ask the AI to self-review:
```
After writing the code, review it against the rules above. List any places where you deliberately avoided modern C# syntax and explain why.
```

Or:
```
Act as a senior C# architect reviewing AI-generated code for modern C# 15 best practices.
```

And:
```
Generate a reusable prompt template for producing clean modern C# code with nullable analysis, records, union types, and pattern matching.
```

To make the result match the book’s guidance, the reader should also ask for a “before and after” version:
```
Show the older C# approach first, then rewrite it using modern C# 15 style. Explain why the modern version is safer or clearer.
```

That is especially useful for teaching:
- `if`/`else` chains versus pattern matching
- Status enums plus nullable properties versus `union` types
- Mutable classes versus records
- Loops versus LINQ pipelines
- Null checks versus nullable reference analysis

> **Warning!** AI-generated code should be treated like code from a junior developer who types very fast. It may compile, but still use outdated patterns, ignore nullable warnings, overuse LINQ, misuse inheritance, or invent APIs. Always build the project, run tests, inspect warnings, and ask the AI to revise the code against explicit modern C# guidelines.

Modern C# syntax enhancements collectively move the language toward a more expressive and declarative style while reducing repetitive boilerplate. Features such as collection expressions, primary constructors, raw string literals, and required members help developers communicate intent more directly with less code. However, modern abstractions also introduce new performance tradeoffs and potential pitfalls.

> **Prompt**: Which modern C# syntax improvements genuinely improve readability and which are controversial? 
