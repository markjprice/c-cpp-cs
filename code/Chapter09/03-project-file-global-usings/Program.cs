decimal price = 19.99M;
string formatted = price.ToString(
    "C",
    CultureInfo.GetCultureInfo("en-US"));

Console.WriteLine(formatted);
