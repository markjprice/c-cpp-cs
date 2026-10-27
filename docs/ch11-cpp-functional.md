# Chapter 11 online section - Functional programming

- [Chapter 11 online section - Functional programming](#chapter-11-online-section---functional-programming)
- [What is functional programming?](#what-is-functional-programming)
- [How C# enables functional-style programming](#how-c-enables-functional-style-programming)
- [Expression-bodied members](#expression-bodied-members)
- [Why immutability matters](#why-immutability-matters)
- [Using readonly fields, init setters, and with expressions](#using-readonly-fields-init-setters-and-with-expressions)
- [Creating and returning tuples in C#](#creating-and-returning-tuples-in-c)
- [Using anonymous types for ad-hoc data structures](#using-anonymous-types-for-ad-hoc-data-structures)
- [Pure versus impure functions](#pure-versus-impure-functions)
- [Why immutability helps concurrency](#why-immutability-helps-concurrency)
- [Composing LINQ pipelines](#composing-linq-pipelines)
- [Treating collections as immutable](#treating-collections-as-immutable)
- [Using `Select()` for transformation](#using-select-for-transformation)
- [Aggregating data with `Aggregate()`](#aggregating-data-with-aggregate)
- [Benefits of records over classes for functional programming](#benefits-of-records-over-classes-for-functional-programming)
- [Deconstruction](#deconstruction)
- [Collection expressions](#collection-expressions)
- [Implementing immutable data structures](#implementing-immutable-data-structures)
- [Closures and captured variables](#closures-and-captured-variables)
- [Deferred execution pitfalls](#deferred-execution-pitfalls)
- [LINQ multiple enumeration issues](#linq-multiple-enumeration-issues)

C# was originally designed primarily as an object-oriented language, but modern versions increasingly incorporate ideas from functional programming. These features encourage developers to write code that is:
- More predictable
- Easier to compose
- Safer to parallelize
- Simpler to reason about

Functional programming emphasizes immutability, pure transformations, minimizing side effects, and composing behavior from smaller functions. Modern C# does not force developers to use a purely functional style. Instead, it allows object-oriented, procedural, and functional techniques to coexist within the same application. Many modern C# features introduced in recent versions of the language were heavily influenced by functional programming concepts.

# What is functional programming?

Functional programming treats computation primarily as the evaluation of functions rather than the manipulation of mutable state. Traditional procedural code often focuses on:

- Changing variables
- Mutating objects
- Updating shared state step-by-step

Functional programming instead favors:
- Immutable data
- Transformations that produce new values
- Predictable behavior

For example, procedural code might modify an existing collection:
```cs
for (int i = 0; i < numbers.Count; i++)
{
    numbers[i] *= 2;
}
```

A more functional approach produces a new sequence instead:
```cs
var doubled = numbers
    .Select(n => n * 2);
```

The original sequence remains unchanged. This style often reduces bugs caused by unexpected state changes.

# How C# enables functional-style programming

Modern C# includes many features that support functional-style development:
- Lambda expressions
- LINQ
- Records
- Pattern matching
- Expression-bodied members
- Immutable collections
- Higher-order functions

These features allow developers to write concise transformation pipelines rather than deeply nested procedural logic. C# does not aim to become a purely functional language like Haskell or F#, but it increasingly supports hybrid programming styles.

# Expression-bodied members

Expression-bodied members allow methods, properties, and constructors to be written using concise expression syntax:
```cs
public int Square(int x) => x * x;
```

instead of:
```cs
public int Square(int x)
{
    return x * x;
}
```

Properties can also use expression bodies:
```cs
public string FullName =>
    $"{FirstName} {LastName}";
```

This syntax works best for short computations, derived properties, and transformation logic. Expression-bodied members encourage smaller and more declarative methods.

# Why immutability matters

Immutability is one of the central ideas in functional programming. An immutable object cannot change after creation. Mutable shared state is one of the biggest sources of software bugs because different parts of an application may modify the same object unexpectedly.

Immutable data structures help reduce accidental side effects, race conditions, threading bugs, and unpredictable state changes:
```cs
public record Person(
    string Name,
    int Age);
```

The record itself is immutable by default when using init properties or positional parameters. Instead of modifying objects directly, functional programming often creates updated copies.

# Using readonly fields, init setters, and with expressions

Modern C# supports immutable object design using readonly, init, and records:
```cs
public class Product
{
    public required string Name
    {
        get;
        init;
    }

    public decimal Price
    {
        get;
        init;
    }
}
```

The properties can be assigned during initialization but cannot be modified later. This style encourages safer object design because objects become stable after creation.

The `with` expression creates modified copies of immutable objects:
```cs
Person original = new("Alice", 30);

Person updated = original with
{
    Age = 31
};
```

Instead of mutating the original object, a new object is created with selected changes applied. This approach:
- Preserves immutability
- Simplifies reasoning about state
- Works naturally with records

`with` expressions are heavily inspired by functional programming languages.

> **Prompt**: Show how records and with-expressions encourage functional-style programming.

# Creating and returning tuples in C#

Tuples provide lightweight ways to group related values without defining custom classes:
```cs
(string Name, int Age) GetPerson()
{
    return ("Alice", 30);
}
```

Tuples work especially well in functional-style code where temporary transformation results are common.

Combined with deconstruction:
```cs
var (name, age) = GetPerson();
```
they support concise data flow through transformation pipelines.

# Using anonymous types for ad-hoc data structures

Anonymous types create temporary immutable objects without explicit class definitions:
```cs
var summaries = employees
    .Select(employee => new
    {
        employee.Name,
        employee.Department
    });
```

Anonymous types are heavily used in LINQ projections and functional-style transformations.

# Pure versus impure functions

A pure function:
- Always produces the same output for the same input
- Does not modify external state
- Has no side effects

For example:
```cs
int Add(int x, int y) => x + y;
```

This function is pure.

By contrast:
```cs
int counter = 0;

int Increment()
{
    counter++;

    return counter;
}
```

Is impure because it modifies external state.

Pure functions are easier to test, parallelize, debug, and reason about. This is one reason LINQ pipelines often favor transformation-oriented code over mutable loops.

# Why immutability helps concurrency

Concurrency becomes much safer when data cannot change unexpectedly. If multiple threads share mutable objects, synchronization mechanisms such as locks are often required. Immutable objects avoid many of these problems because their state never changes after creation. This is increasingly important in cloud applications, asynchronous systems, parallel processing, and distributed systems.

Immutability does not eliminate all concurrency problems, but it significantly reduces many common categories of bugs.

> **Prompt**: Why does immutability help concurrency and parallel programming?

# Composing LINQ pipelines

Functional programming encourages composition: building larger behavior from smaller reusable transformations. LINQ pipelines are a practical example of this idea:
```cs
var results = employees
    .Where(employee =>
        employee.Department == "Engineering")
    .OrderBy(employee => employee.Name)
    .Select(employee => employee.Name);
```

Each operation:
- Performs a single responsibility
- Transforms data predictably
- Composes naturally with the next operation

This often produces clearer code than large procedural methods.

# Treating collections as immutable

Even though collections such as List<T> are mutable, many developers using functional-style techniques treat them as immutable conceptually. Instead of modifying existing collections:
```cs
numbers.Add(10);
```

they create transformed sequences:
```cs
var updated = numbers.Append(10);
```

This style reduces unintended side effects and supports safer composition.
Prompt: Compare mutable and immutable design using practical examples.

# Using `Select()` for transformation

`Select()` is one of the most important functional transformation operators in LINQ:
```cs
var upperCase = names
    .Select(name => name.ToUpper());
```

The original collection remains unchanged while a transformed sequence is produced. This transformation-oriented mindset is central to functional programming.

# Aggregating data with `Aggregate()`

The `Aggregate()` method combines a sequence into a single value:
```cs
int total = numbers.Aggregate(
    0,
    (sum, value) => sum + value);
```

This operation:
1.	Starts with an initial value
2.	Repeatedly combines elements
3.	Produces a final result

`Aggregate()` generalizes many operations like summation, concatenation, reduction, and accumulation. Functional languages frequently rely heavily on these reduction patterns.

# Benefits of records over classes for functional programming

Records were introduced earlier in the book, but they are especially important in functional-style programming because they emphasize immutability, value-based equality, and concise data modeling:
```cs
public record Product(
    string Name,
    decimal Price);
```

Records reduce boilerplate code significantly compared to traditional classes. Records are often preferable to classes when modeling immutable data and transformation results. Unlike traditional classes, records compare values by content rather than reference identity.

For example:
```cs
Product p1 = new("Laptop", 1000);

Product p2 = new("Laptop", 1000);

Console.WriteLine(p1 == p2); // True
```

This behavior aligns naturally with functional programming principles.

# Deconstruction

Records and tuples support deconstruction:
```cs
Product product = new("Laptop", 1000);

var (name, price) = product;
```

This allows objects to participate naturally in pattern matching and functional transformations.

# Collection expressions

Modern C# supports collection expressions for concise collection creation:
```cs
List<int> values = [1, 2, 3, 4];
```

This syntax reduces boilerplate and improves readability in data-oriented code.

# Implementing immutable data structures

True functional programming often relies on immutable collections. The .NET ecosystem provides immutable collection types in `System.Collections.Immutable`.

For example:
```cs
using System.Collections.Immutable;

ImmutableList<int> values =
    ImmutableList.Create(1, 2, 3);
```

Operations return new collections instead of modifying existing ones. This improves predictability but may increase memory allocations compared to mutable collections.

# Closures and captured variables

As discussed earlier, lambdas can capture variables from surrounding scopes:
```cs
int factor = 2;

Func<int, int> multiply =
    x => x * factor;
```

Closures allow powerful composition patterns, but developers must remain aware that captured variables may outlive their original scope.

# Deferred execution pitfalls

Deferred execution can create subtle behavior in functional-style code:
```cs
var query = numbers
    .Where(n => n > 0);

numbers.Add(100);
```

The query reflects the modified sequence later because execution is deferred. This can produce surprising results if developers assume snapshot behavior.

# LINQ multiple enumeration issues

Repeated enumeration can also introduce inefficiency:
```cs
var query = numbers
    .Where(n => n > 0);

Console.WriteLine(query.Count());

Console.WriteLine(query.Sum());
```

The filtering executes twice. Materializing results can avoid repeated work:
```cs
var results = query.ToList();
```

Functional programming has influenced nearly every area of modern C#, from LINQ and records to pattern matching and immutable design. These techniques encourage developers to focus on transformations and composition rather than mutable procedural state. Alongside these larger conceptual changes, modern C# has also introduced many smaller syntax improvements that simplify everyday code and reduce boilerplate. 

> **Prompt**: Please explain functional programming concepts for an object-oriented C# developer.

The [next section](ch11-cpp-performance.md) explores where modern C# features can create hidden allocations, deferred execution issues, and other performance concerns that developers should understand when building large or high-performance applications.
