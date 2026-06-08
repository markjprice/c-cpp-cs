Inventory inventory = new();
inventory.Add("Health Potion");
inventory.Add("Iron Key");

Weapon sword = new("Sword", 12);
Player player = new("Luna", inventory, sword);

player.ShowStatus();

IDatabase database = new InMemoryDatabase();
OrderService service = new(database);

service.SaveOrder(new Order(1001, 49.99M));

IMessageSender sender = new ConsoleMessageSender();
sender.Send("Order saved.");

class Player
{
    private readonly Inventory inventory;
    private readonly Weapon equippedWeapon;

    public string Name { get; }

    public Player(string name, Inventory inventory, Weapon equippedWeapon)
    {
        Name = name;
        this.inventory = inventory;
        this.equippedWeapon = equippedWeapon;
    }

    public void ShowStatus()
    {
        Console.WriteLine($"{Name} equipped {equippedWeapon.Name}.");
        Console.WriteLine($"Inventory: {string.Join(", ", inventory.Items)}");
    }
}

class Inventory
{
    private readonly List<string> items = new();

    public IReadOnlyList<string> Items => items;

    public void Add(string item)
    {
        items.Add(item);
    }
}

record Weapon(string Name, int Damage);

record Order(int Id, decimal Total);

interface IDatabase
{
    void Save(Order order);
}

class InMemoryDatabase : IDatabase
{
    public void Save(Order order)
    {
        Console.WriteLine($"Saved order {order.Id} with total {order.Total:C}.");
    }
}

class OrderService
{
    private readonly IDatabase database;

    public OrderService(IDatabase database)
    {
        this.database = database;
    }

    public void SaveOrder(Order order)
    {
        database.Save(order);
    }
}

interface IMessageSender
{
    void Send(string message);
}

class ConsoleMessageSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}
