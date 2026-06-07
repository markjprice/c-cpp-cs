#include <iostream>

class Printer
{
public:
  void print() const
  {
    std::cout << "Printing...\n";
  }
};

class Scanner
{
public:
  void scan() const
  {
    std::cout << "Scanning...\n";
  }
};

class AllInOne : public Printer, public Scanner
{
};

class Animal
{
public:
  void eat() const
  {
    std::cout << "Animal is eating.\n";
  }
};

class Mammal : public virtual Animal
{
};

class Bird : public virtual Animal
{
};

class Bat : public Mammal, public Bird
{
};

int main()
{
  AllInOne device;
  device.print();
  device.scan();

  Bat bat;
  bat.eat();

  std::cout << "Virtual inheritance gives Bat one shared Animal base.\n";

  return 0;
}
