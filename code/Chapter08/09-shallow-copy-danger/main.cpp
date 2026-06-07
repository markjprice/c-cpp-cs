#include <iostream>
#include <memory>

class UnsafeBuffer
{
private:
  int* data;
  int size;
  bool owner;

public:
  explicit UnsafeBuffer(int s) : data(new int[s]{}), size(s), owner(true)
  {
    std::cout << "Allocated buffer\n";
  }

  // Deliberately shallow-copying constructor for educational purposes.
  UnsafeBuffer(const UnsafeBuffer& other) : data(other.data), size(other.size), owner(false)
  {
    std::cout << "Shallow copy created. Both objects point at the same memory.\n";
  }

  ~UnsafeBuffer()
  {
    if (owner)
    {
      delete[] data;
      std::cout << "Owner freed buffer\n";
    }
    else
    {
      std::cout << "Non-owner did not free buffer to keep this demonstration safe.\n";
    }
  }

  void set(int index, int value)
  {
    data[index] = value;
  }

  void printFirst() const
  {
    std::cout << "First value: " << data[0] << ", size: " << size << "\n";
  }
};

int main()
{
  UnsafeBuffer a(3);
  a.set(0, 42);

  UnsafeBuffer b = a; // shallow copy: dangerous pattern
  b.printFirst();

  std::cout << "This project avoids crashing, but the design is intentionally wrong.\n";
  std::cout << "The correct solution is shown in the Rule of Three project.\n";
}
