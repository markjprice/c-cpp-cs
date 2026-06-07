#include <algorithm>
#include <iostream>
#include <utility>

class Buffer
{
private:
  int* data = nullptr;
  int size = 0;

public:
  explicit Buffer(int s) : data(new int[s]{}), size(s)
  {
    std::cout << "Allocated size " << size << "\n";
  }

  ~Buffer()
  {
    delete[] data;
    std::cout << "Destroyed size " << size << "\n";
  }

  Buffer(const Buffer& other) : data(new int[other.size]), size(other.size)
  {
    std::copy(other.data, other.data + size, data);
    std::cout << "Copied size " << size << "\n";
  }

  Buffer& operator=(const Buffer& other)
  {
    if (this == &other) return *this;
    Buffer temp(other);
    swap(temp);
    std::cout << "Copy-assigned\n";
    return *this;
  }

  Buffer(Buffer&& other) noexcept : data(other.data), size(other.size)
  {
    other.data = nullptr;
    other.size = 0;
    std::cout << "Moved constructor\n";
  }

  Buffer& operator=(Buffer&& other) noexcept
  {
    if (this == &other) return *this;
    delete[] data;
    data = other.data;
    size = other.size;
    other.data = nullptr;
    other.size = 0;
    std::cout << "Move-assigned\n";
    return *this;
  }

  void swap(Buffer& other) noexcept
  {
    std::swap(data, other.data);
    std::swap(size, other.size);
  }

  int length() const
  {
    return size;
  }
};

Buffer createBuffer()
{
  Buffer temp(5);
  return temp;
}

int main()
{
  Buffer a(3);
  Buffer b = a;
  Buffer c = createBuffer();
  Buffer d(1);
  d = std::move(c);

  std::cout << "a length: " << a.length() << "\n";
  std::cout << "b length: " << b.length() << "\n";
  std::cout << "c length after move: " << c.length() << "\n";
  std::cout << "d length: " << d.length() << "\n";
}
