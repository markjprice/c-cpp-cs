#include <iostream>

class Vector2D
{
private:
  int x;
  int y;

public:
  Vector2D(int xValue, int yValue)
    : x(xValue), y(yValue)
  {
  }

  Vector2D operator+(const Vector2D& other) const
  {
    return Vector2D(x + other.x, y + other.y);
  }

  bool operator==(const Vector2D& other) const
  {
    return x == other.x && y == other.y;
  }

  friend std::ostream& operator<<(std::ostream& os, const Vector2D& v)
  {
    os << "(" << v.x << ", " << v.y << ")";
    return os;
  }
};

int main()
{
  Vector2D v1(2, 3);
  Vector2D v2(4, 5);
  Vector2D sum = v1 + v2;

  std::cout << "v1: " << v1 << "\n";
  std::cout << "v2: " << v2 << "\n";
  std::cout << "sum: " << sum << "\n";

  std::cout << "sum == Vector2D(6, 8): "
            << (sum == Vector2D(6, 8) ? "true" : "false") << "\n";

  return 0;
}
