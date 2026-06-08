string path = Path.Combine(AppContext.BaseDirectory, "captains.txt");

using (StreamWriter writer = new(path))
{
  writer.WriteLine("James T. Kirk");
  writer.WriteLine("Jean-Luc Picard");
  writer.WriteLine("Benjamin Sisko");
  writer.WriteLine("Kathryn Janeway");
}

using StreamReader reader = File.OpenText(path);
string contents = reader.ReadToEnd();
Console.WriteLine(contents);

Console.WriteLine("The writer and reader were disposed automatically.");
