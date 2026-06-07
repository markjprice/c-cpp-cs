#include <iostream>

class Box
{
private:
  int value;

public:
  explicit Box(int v)
    : value(v)
  {
  }

  friend void printBox(const Box& b);
};

void printBox(const Box& b)
{
  std::cout << "Box value: " << b.value << "\n";
}

class Car
{
private:
  int speed;

public:
  explicit Car(int s)
    : speed(s)
  {
  }

  int getSpeed() const
  {
    return speed;
  }

  friend class Engine;
};

class Engine
{
public:
  void modifySpeed(Car& c, int newSpeed) const
  {
    c.speed = newSpeed;
  }
};

int main()
{
  Box box(42);
  printBox(box);

  Car car(30);
  Engine engine;

  std::cout << "Speed before: " << car.getSpeed() << "\n";
  engine.modifySpeed(car, 100);
  std::cout << "Speed after: " << car.getSpeed() << "\n";

  return 0;
}
