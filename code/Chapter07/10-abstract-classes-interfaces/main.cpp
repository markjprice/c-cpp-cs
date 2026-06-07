#include <cmath>
#include <iostream>
#include <memory>
#include <vector>

class Shape
{
public:
  virtual double area() const = 0;

  void describe() const
  {
    std::cout << "This is a shape with area " << area() << ".\n";
  }

  virtual ~Shape() = default;
};

class Circle : public Shape
{
private:
  double radius;

public:
  explicit Circle(double radiusValue)
    : radius(radiusValue)
  {
  }

  double area() const override
  {
    return 3.14159 * radius * radius;
  }
};

class Rectangle : public Shape
{
private:
  double width;
  double height;

public:
  Rectangle(double widthValue, double heightValue)
    : width(widthValue), height(heightValue)
  {
  }

  double area() const override
  {
    return width * height;
  }
};

class Drawable
{
public:
  virtual void draw() const = 0;
  virtual ~Drawable() = default;
};

class Icon : public Drawable
{
public:
  void draw() const override
  {
    std::cout << "Drawing an icon.\n";
  }
};

int main()
{
  std::vector<std::unique_ptr<Shape>> shapes;
  shapes.push_back(std::make_unique<Circle>(5.0));
  shapes.push_back(std::make_unique<Rectangle>(4.0, 6.0));

  for (const auto& shape : shapes)
  {
    shape->describe();
  }

  Icon icon;
  icon.draw();

  return 0;
}
