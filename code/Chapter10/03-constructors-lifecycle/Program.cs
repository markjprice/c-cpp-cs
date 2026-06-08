Player player = new();
Console.WriteLine(player.Name);

Character hero = new("Aria");
Console.WriteLine(hero.Name);

Enemy defaultEnemy = new();
Enemy boss = new("Dragon", 500);
Console.WriteLine($"{defaultEnemy.Name}: {defaultEnemy.Health}");
Console.WriteLine($"{boss.Name}: {boss.Health}");

Weapon defaultWeapon = new();
Weapon axe = new("Axe", 25);
Console.WriteLine($"{defaultWeapon.Name}: {defaultWeapon.Damage}");
Console.WriteLine($"{axe.Name}: {axe.Damage}");

ModernPlayer modern = new("Mark");
Console.WriteLine(modern.Name);

GameCharacter gameHero = new()
{
    Name = "Luna",
    Level = 5
};
Console.WriteLine($"{gameHero.Name}: Level {gameHero.Level}");

List<string> names = new()
{
    "Alice",
    "Bob",
    "Charlie"
};

Console.WriteLine(string.Join(", ", names));
Console.WriteLine(GameSettings.Version);

static class Output
{
    public static void Section(string title) => Console.WriteLine($"\n--- {title} ---");
}

class Player
{
    public string Name;

    public Player()
    {
        Name = "Unknown";
    }
}

class Character
{
    public string Name { get; set; }

    public Character(string name)
    {
        Name = name;
    }
}

class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Enemy()
    {
        Name = "Unknown";
        Health = 100;
    }

    public Enemy(string name, int health)
    {
        Name = name;
        Health = health;
    }
}

class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }

    public Weapon() : this("Sword", 10)
    {
    }

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}

class ModernPlayer(string name)
{
    public string Name { get; set; } = name;
}

class GameCharacter
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
}

class GameSettings
{
    public static string Version;

    static GameSettings()
    {
        Version = "1.0";
    }
}

class ResourceTracker
{
    ~ResourceTracker()
    {
        Console.WriteLine("Object finalized.");
    }
}
