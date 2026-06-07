#include <any>
#include <array>
#include <deque>
#include <iostream>
#include <list>
#include <map>
#include <optional>
#include <set>
#include <string>
#include <tuple>
#include <variant>
#include <vector>

int main()
{
  std::string name = "Alice";
  std::vector<int> scores = {10, 20, 30};
  std::array<int, 3> fixedScores = {1, 2, 3};
  std::list<std::string> tasks = {"write", "compile", "run"};
  std::deque<int> queue = {1, 2, 3};
  std::set<std::string> uniqueNames = {"Alice", "Bob", "Alice"};
  std::map<std::string, int> ages = {{"Alice", 30}, {"Bob", 25}};
  std::pair<std::string, int> pairValue = {"level", 1};
  std::tuple<std::string, int, bool> tupleValue = {"active", 1, true};
  std::optional<int> maybeValue = 42;
  std::variant<int, std::string> variantValue = std::string{"hello"};
  std::any anyValue = 3.14;

  std::cout << "std::string: " << name << "\n";
  std::cout << "std::vector size: " << scores.size() << "\n";
  std::cout << "std::array first: " << fixedScores.at(0) << "\n";
  std::cout << "std::list size: " << tasks.size() << "\n";
  std::cout << "std::deque front: " << queue.front() << "\n";
  std::cout << "std::set size after duplicate insert: " << uniqueNames.size() << "\n";
  std::cout << "std::map Alice age: " << ages.at("Alice") << "\n";
  std::cout << "std::pair: " << pairValue.first << " = " << pairValue.second << "\n";
  std::cout << "std::tuple first: " << std::get<0>(tupleValue) << "\n";
  std::cout << "std::optional has value: " << maybeValue.has_value() << "\n";
  std::cout << "std::variant string: " << std::get<std::string>(variantValue) << "\n";
  std::cout << "std::any double: " << std::any_cast<double>(anyValue) << "\n";
}
