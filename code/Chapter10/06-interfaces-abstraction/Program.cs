Shape circle = new Circle(5);
Console.WriteLine($"Area: {circle.GetArea():F2}");

Duck duck = new();
duck.Fly();
duck.Swim();

List<IPlayable> players = new()
{
    new MusicPlayer(),
    new VideoPlayer()
};

foreach (IPlayable player in players)
{
    player.Play();
}

IMessageService email = new EmailService();
IMessageService sms = new SmsService();

NotificationService notifier = new(email);
notifier.Notify("Build succeeded.");

notifier = new(sms);
notifier.Notify("Server restarted.");

ILogger logger = new ConsoleLogger();
logger.Log("Default interface method can be inherited or implemented.");

abstract class Shape
{
    public abstract double GetArea();

    public void Describe()
    {
        Console.WriteLine("This is a shape.");
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

class Duck : IFlyable, ISwimmable
{
    public void Fly()
    {
        Console.WriteLine("Flying");
    }

    public void Swim()
    {
        Console.WriteLine("Swimming");
    }
}

interface IPlayable
{
    void Play();
}

class MusicPlayer : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Playing music");
    }
}

class VideoPlayer : IPlayable
{
    public void Play()
    {
        Console.WriteLine("Playing video");
    }
}

interface IMessageService
{
    void Send(string message);
}

class EmailService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

class SmsService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}

class NotificationService
{
    private readonly IMessageService messageService;

    public NotificationService(IMessageService messageService)
    {
        this.messageService = messageService;
    }

    public void Notify(string message)
    {
        messageService.Send(message);
    }
}

interface ILogger
{
    void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class ConsoleLogger : ILogger
{
}
