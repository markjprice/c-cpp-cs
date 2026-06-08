using System;
using System.Collections.Generic;

SimpleObjectPool<CsvCounter> pool = new(maximumRetained: 2);

string[] lines =
[
  "Name,Department,Salary",
  "Alice,Engineering,90000",
  "Bob,Sales,70000",
  "Charlie,Engineering,95000"
];

for (int run = 1; run <= 3; run++)
{
  CsvCounter parser = pool.Get();

  try
  {
    int fieldCount = parser.CountFields(lines);
    Console.WriteLine($"Run {run}: counted {fieldCount} CSV fields.");
  }
  finally
  {
    parser.Reset();
    pool.Return(parser);
  }
}

public sealed class CsvCounter
{
  private int _linesProcessed;

  public int CountFields(IEnumerable<string> lines)
  {
    int total = 0;

    foreach (string line in lines)
    {
      _linesProcessed++;
      total += line.Split(',').Length;
    }

    Console.WriteLine($"  Parser processed {_linesProcessed} lines before reset.");
    return total;
  }

  public void Reset()
  {
    _linesProcessed = 0;
  }
}

public sealed class SimpleObjectPool<T> where T : new()
{
  private readonly Stack<T> _items = new();
  private readonly int _maximumRetained;

  public SimpleObjectPool(int maximumRetained)
  {
    _maximumRetained = maximumRetained;
  }

  public T Get()
  {
    return _items.Count > 0 ? _items.Pop() : new T();
  }

  public void Return(T item)
  {
    if (_items.Count < _maximumRetained)
    {
      _items.Push(item);
    }
  }
}
