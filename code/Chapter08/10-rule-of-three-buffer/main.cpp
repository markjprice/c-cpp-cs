#include <algorithm>
#include <iostream>
#include <stdexcept>

class Buffer
{
private:
  int* data;
  int size;

public:
  explicit Buffer(int s) : data(new int[s]{}), size(s)
  {
    std::cout << "Buffer allocated with size " << size << "\n";
  }

  ~Buffer()
  {
    delete[] data;
    std::cout << "Buffer destroyed\n";
  }

  Buffer(const Buffer& other) : data(new int[other.size]), size(other.size)
  {
    std::copy(other.data, other.data + size, data);
    std::cout << "Buffer deep-copied\n";
  }

  Buffer& operator=(const Buffer& other)
  {
    if (this == &other)
    {
      return *this;
    }

    int* newData = new int[other.size];
    std::copy(other.data, other.data + other.size, newData);

    delete[] data;
    data = newData;
    size = other.size;
    std::cout << "Buffer copy-assigned\n";
    return *this;
  }

  void set(int index, int value)
  {
    if (index < 0 || index >= size)
    {
      throw std::out_of_range("index");
    }
    data[index] = value;
  }

  void print() const
  {
    for (int i = 0; i < size; ++i)
    {
      std::cout << data[i] << " ";
    }
    std::cout << "\n";
  }
};

int main()
{
  Buffer a(3);
  a.set(0, 10);
  a.set(1, 20);
  a.set(2, 30);

  Buffer b = a;
  b.set(0, 99);

  std::cout << "a: ";
  a.print();
  std::cout << "b: ";
  b.print();

  Buffer c(1);
  c = a;
  std::cout << "c: ";
  c.print();
}
