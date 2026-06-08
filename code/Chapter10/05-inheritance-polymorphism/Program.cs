Dog dog = new();
dog.Eat();
dog.Bark();

Warrior warrior = new();
warrior.DisplayHealth();

Console.WriteLine();

Animal animal = new Dog();
animal.Speak();

List<Animal> animals = new()
{
    new Dog(),
    new Cat()
};

foreach (Animal item in animals)
{
    item.Speak();
}

Car car = new("Ford");
Console.WriteLine(car.Brand);

class Animal
{
    public Animal()
    {
        Console.WriteLine("Animal constructor");
    }

    public void Eat()
    {
        Console.WriteLine("Eating...");
    }

    public virtual void Speak()
    {
        Console.WriteLine("Animal sound");
    }
}

class Dog : Animal
{
    public Dog()
    {
        Console.WriteLine("Dog constructor");
    }

    public void Bark()
    {
        Console.WriteLine("Woof!");
    }

    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}

class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}

class Character
{
    protected int health = 100;
}

class Warrior : Character
{
    public void DisplayHealth()
    {
        Console.WriteLine($"Warrior health: {health}");
    }
}

class Vehicle
{
    public string Brand { get; }

    public Vehicle(string brand)
    {
        Brand = brand;
    }
}

class Car : Vehicle
{
    public Car(string brand) : base(brand)
    {
    }
}

sealed class DatabaseConnection
{
}
