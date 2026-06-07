#include <iostream>

class Engine
{
public:
  void start() const
  {
    std::cout << "Engine started.\n";
  }
};

class CarWithEngine
{
private:
  Engine engine;

public:
  void start() const
  {
    std::cout << "Car uses composition: ";
    engine.start();
  }
};

class Vehicle
{
public:
  void move() const
  {
    std::cout << "Vehicle is moving.\n";
  }
};

class Car : public Vehicle
{
public:
  void honk() const
  {
    std::cout << "Car is honking.\n";
  }
};

int main()
{
  CarWithEngine composedCar;
  composedCar.start();

  Car inheritedCar;
  inheritedCar.move();
  inheritedCar.honk();

  return 0;
}
