namespace GameEngine.Graphics;

public class Sprite
{
    public string Name { get; }

    public Sprite(string name)
    {
        Name = name;
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing sprite: {Name}");
    }
}
