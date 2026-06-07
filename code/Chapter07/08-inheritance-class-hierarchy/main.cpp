#include <iostream>
#include <string>

class Vehicle
{
protected:
  int speed;

public:
  explicit Vehicle(int speedValue)
    : speed(speedValue)
  {
    std::cout << "Vehicle constructed.\n";
  }

  ~Vehicle()
  {
    std::cout << "Vehicle destroyed.\n";
  }

  void move() const
  {
    std::cout << "Vehicle moving at " << speed << " mph.\n";
  }
};

class Car : public Vehicle
{
private:
  std::string model;

public:
  Car(int speedValue, std::string modelName)
    : Vehicle(speedValue), model(std::move(modelName))
  {
    std::cout << "Car constructed.\n";
  }

  ~Car()
  {
    std::cout << "Car destroyed.\n";
  }

  void describe() const
  {
    std::cout << "Car model: " << model << "\n";
  }
};

int main()
{
  Car car(60, "Falcon");
  car.describe();
  car.move();

  return 0;
}
