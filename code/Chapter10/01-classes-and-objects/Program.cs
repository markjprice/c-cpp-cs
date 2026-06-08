Car myCar = new();
myCar.Brand = "Ford";
myCar.Year = 2024;
Console.WriteLine($"{myCar.Brand} ({myCar.Year})");

Car car1 = new();
Car car2 = new();

car1.Brand = "Tesla";
car2.Brand = "Toyota";

Console.WriteLine(car1.Brand);
Console.WriteLine(car2.Brand);

Dog dog = new();
dog.Name = "Max";
dog.Bark();

Player player = new("Mark");
player.DisplayName();

User user = new()
{
    Username = "mark"
};

Console.WriteLine($"Required username: {user.Username}");

Counter first = new();
first.Value = 10;

Counter second = first;
second.Value = 99;

Console.WriteLine($"first.Value: {first.Value}");
Console.WriteLine($"second.Value: {second.Value}");

class Car
{
    public string Brand = "";
    public int Year;
}

class Dog
{
    public string Name = "";

    public void Bark()
    {
        Console.WriteLine($"{Name} says woof!");
    }
}

class Player
{
    public string Name = "";

    public Player(string name)
    {
        this.Name = name;
    }

    public void DisplayName()
    {
        Console.WriteLine(this.Name);
    }
}

class User
{
    public required string Username { get; set; }
}

class Counter
{
    public int Value;
}
