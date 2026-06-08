Person captain = new("Jean-Luc Picard");
Person sameCaptain = captain;

Console.WriteLine(captain.Name);
Console.WriteLine(ReferenceEquals(captain, sameCaptain));

sameCaptain.Name = "Locutus";
Console.WriteLine(captain.Name);

Console.WriteLine("The variables contain references. The object is managed by the .NET runtime.");

public sealed class Person
{
  public Person(string name) => Name = name;
  public string Name { get; set; }
}
