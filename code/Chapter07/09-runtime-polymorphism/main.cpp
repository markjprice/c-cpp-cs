#include <iostream>
#include <memory>
#include <vector>

class Vehicle
{
public:
  virtual void move() const
  {
    std::cout << "Vehicle is moving.\n";
  }

  virtual ~Vehicle() = default;
};

class Car : public Vehicle
{
public:
  void move() const override
  {
    std::cout << "Car is driving.\n";
  }
};

class Boat : public Vehicle
{
public:
  void move() const override
  {
    std::cout << "Boat is sailing.\n";
  }
};

int main()
{
  std::vector<std::unique_ptr<Vehicle>> vehicles;
  vehicles.push_back(std::make_unique<Vehicle>());
  vehicles.push_back(std::make_unique<Car>());
  vehicles.push_back(std::make_unique<Boat>());

  for (const auto& vehicle : vehicles)
  {
    vehicle->move();
  }

  return 0;
}
