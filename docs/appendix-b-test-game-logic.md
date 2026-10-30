# Appendix B online section - Testing game logic separately from the UI

- [Appendix B online section - Testing game logic separately from the UI](#appendix-b-online-section---testing-game-logic-separately-from-the-ui)
- [What to test](#what-to-test)
- [Creating a test project](#creating-a-test-project)
- [Testing Word Guess rules](#testing-word-guess-rules)
- [Testing Number Logic clues](#testing-number-logic-clues)
- [Testing Grid Puzzle board behavior](#testing-grid-puzzle-board-behavior)
- [Running the tests](#running-the-tests)
- [Testing with known models instead of random starts](#testing-with-known-models-instead-of-random-starts)
- [Deciding how many tests to write](#deciding-how-many-tests-to-write)
- [Using AI to generate test cases](#using-ai-to-generate-test-cases)
- [Why this proves the design](#why-this-proves-the-design)

Puzzle Arcade now has three playable games and several optional variations. You can test those games manually by opening the Blazor app in a browser, clicking buttons, submitting guesses, and checking the result. That kind of testing is useful, but it should not be the only way to check the game logic.

The most important rules in this chapter are ordinary C# code. The word game rules are in WordGuessRules. The number game rules are in `NumberLogicRules`. The grid puzzle rules are in `GridPuzzleRules`, `GridBoard`, and `GridPosition`. Those types do not need a browser to run.

That is the payoff for separating game logic from UI. If the rules lived inside `.razor` event handlers, testing them would be awkward. Because the rules are in ordinary C# files, we can test them directly.

> **Prompt**: Please explain why code that is buried inside .razor event handlers is harder to test than ordinary C# rule methods.

In this section, you will create a test project for Puzzle Arcade and write unit tests for the game rules. We will not to test every possible move. We just want to prove that the state-and-action design can be verified without clicking through the UI.

# What to test

A good test checks a small piece of behavior with a clear expected result. For Puzzle Arcade, useful tests include:

**Word Guess**:
- Invalid guesses do not consume attempts.
- A correct guess moves the game to Won.

**Number Logic**:
- Exact and misplaced matches are counted correctly.
- Number Logic.
- Repeated digits are rejected.

**Grid Puzzle**:
- Selecting a tile changes the board.
- A solved board moves the game to Won.

These tests focus on rules, not markup. They do not check whether a button has a particular CSS class or whether a page title is rendered. Those are UI concerns. Here, we want to test whether the game logic updates the model correctly.

A useful way to think about each test is:
```
Given this model,
when this action happens,
then the returned model should have these values.
```

That maps directly to the pattern used throughout the chapter:
```
State + Action -> Rules -> New State
```

> **Good practice**: Use AI to generate test ideas before test code. Ask for a checklist of useful test cases first. Then choose the tests that matter. Generated tests still need human review.

# Creating a test project

Now we can add a test project to the solution:
1.	In the solution that contains the `PuzzleArcade` project, add a new **xUnit Test Project** named `PuzzleArcade.Tests` using Visual Studio, or create an xUnit test project at the terminal or command prompt and then add the project to the solution:
```shell
dotnet new xunit -n PuzzleArcade.Tests
dotnet sln add PuzzleArcade.Tests.csproj
```
2.	Add a reference from the test project to the Blazor project. To use the terminal or command prompt:
```shell
dotnet add PuzzleArcade.Tests/PuzzleArcade.Tests.csproj reference PuzzleArcade/PuzzleArcade.csproj
```
3.	In the `PuzzleArcade.Tests.csproj` project file, confirm the reference has been added:
```xml
<ItemGroup>
  <ProjectReference Include="..\PuzzleArcade\PuzzleArcade.csproj" />
</ItemGroup>
```
The exact package versions in the generated test project depend on your installed SDK and template version. The important structure is that the test project references the application project, so the tests can use the game model and rule types.

# Testing Word Guess rules

Let’s create some tests:
1.	In the test project, delete the file named `UnitTest1.cs`.
2.	In the test project, create a new folder named `WordGuess`. 
3.	In the `WordGuess` folder, create a class file named `WordGuessRulesTests.cs`:
```cs
namespace PuzzleArcade.Tests.WordGuess;

using PuzzleArcade.Games.Shared;
using PuzzleArcade.Games.WordGuess;

public sealed class WordGuessRulesTests
{
    [Fact]
    public void BlankGuessDoesNotConsumeAttempt()
    {
        WordGuessModel model = CreatePlayingModel(answer: "apple");

        WordGuessModel updated =
            WordGuessRules.Update(model, new MakeGuess(""));

        Assert.Empty(updated.Attempts);
        Assert.IsType<Playing>(updated.State.Value);
        Assert.Contains("Enter a word", updated.Message);
    }

    [Fact]
    public void CorrectGuessWinsGame()
    {
        WordGuessModel model = CreatePlayingModel(answer: "apple");

        WordGuessModel updated =
            WordGuessRules.Update(model, new MakeGuess("apple"));

        Assert.Single(updated.Attempts);
        Assert.IsType<Won>(updated.State.Value);
        Assert.Contains("Correct", updated.Message);
    }

    private static WordGuessModel CreatePlayingModel(string answer) =>
        new(
            State: new Playing(TurnsTaken: 0),
            Answer: answer,
            Attempts: [],
            MaxGuesses: 6,
            HintsUsed: 0,
            Message: "Test game.");
}
```

These tests create a model with a known answer. That avoids depending on the random word chosen by `StartGame`. A unit test should usually control its inputs. If the answer is random, the test result becomes harder to predict.

> **Good practice**: Random answers are good for gameplay and awkward for unit tests. Create models with known answers, secrets, or boards so the expected result is clear.

> **Prompt**: Please explain why unit tests should create known models instead of depending on random answers chosen by StartGame. Then explain the “Given this model, when this action happens, then the returned model should have these values” testing style.

The first test sends a blank guess. The expected result is that no attempt is recorded, the state remains Playing, and the message explains the problem.
The second test sends the exact answer. The expected result is that one attempt is recorded and the state becomes `Won`.

The tests use `Assert.IsType<T>` to check the case stored inside the `GameState` union:
```cs
Assert.IsType<Won>(updated.State.Value);
```

C# 15 union values expose the underlying case value through `Value`. That lets a test check which case is currently stored. In ordinary application code, pattern matching is usually nicer. In tests, directly checking the case type can make the assertion clear.

If your generated union type exposes the underlying value differently in the SDK version you are using, adjust the assertion to match the final C# 15 implementation. For example, you could use pattern matching instead:
```cs
Assert.True(updated.State is Won);
```

Run the two tests either using Visual Studio by navigating to **Test** | **Run All Tests**, as shown in *Figure 18.1*, or at the terminal or command prompt with the following command:
```shell
dotnet test PuzzleArcadeSolution.sln
```

![]()
*Figure 18.1: Running tests in Visual Studio*

# Testing Number Logic clues

Now we can create tests for the Number Logic game:
1.	In the test project, create a folder named `NumberLogic`.
2.	In the `NumberLogic` folder, add a file named `NumberLogicRulesTests.cs`:
```cs
namespace PuzzleArcade.Tests.NumberLogic;

using PuzzleArcade.Games.NumberLogic;
using PuzzleArcade.Games.Shared;

public sealed class NumberLogicRulesTests
{
    [Fact]
    public void GuessWithExactAndMisplacedDigitsRecordsExpectedClue()
    {
        NumberLogicModel model = CreatePlayingModel(secret: "4279");

        NumberLogicModel updated =
            NumberLogicRules.Update(model, new MakeGuess("9247"));

        NumberLogicAttempt attempt = Assert.Single(updated.Attempts);

        Assert.Equal(1, attempt.Clue.ExactMatches);
        Assert.Equal(3, attempt.Clue.MisplacedMatches);
        Assert.IsType<Playing>(updated.State.Value);
    }

    [Fact]
    public void RepeatedDigitsAreRejected()
    {
        NumberLogicModel model = CreatePlayingModel(secret: "4279");

        NumberLogicModel updated =
            NumberLogicRules.Update(model, new MakeGuess("1123"));

        Assert.Empty(updated.Attempts);
        Assert.IsType<Playing>(updated.State.Value);
        Assert.Contains("repeat", updated.Message, StringComparison.OrdinalIgnoreCase);
    }

    private static NumberLogicModel CreatePlayingModel(string secret) =>
        new(
            State: new Playing(TurnsTaken: 0),
            Difficulty: DifficultyLevel.Normal,
            Secret: secret,
            SecretLength: secret.Length,
            Attempts: [],
            MaxGuesses: 8,
            Message: "Test game.");
}
```

3.	Run the tests.

The first test uses a known secret and a known guess. If the secret is `4279` and the guess is `9247`, one of the correct digits is in the correct position, and all four digits are present. The expected clue is therefore one exact match and three misplaced matches.

The second test checks validation. A guess with repeated digits should be rejected. Rejected guesses should not be added to the attempt list.
These tests are better than manual browser testing for this specific behavior because they are precise. A manual test can show that the game seems to work. A unit test can state exactly which clue counts are expected.

# Testing Grid Puzzle board behavior

The grid puzzle is a board game, so useful tests should check board transformations.
1.	In the test project, create a folder named `GridPuzzle`. 
2.	Add a file named `GridBoardTests.cs`:
```cs
namespace PuzzleArcade.Tests.GridPuzzle;

using PuzzleArcade.Games.GridPuzzle;

public sealed class GridBoardTests
{
    [Fact]
    public void TogglePatternChangesSelectedTile()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "000",
            "000");

        GridBoard updated =
            board.TogglePattern(new GridPosition(Row: 1, Column: 1));

        Assert.Equal(
            TileState.On,
            updated.GetState(new GridPosition(Row: 1, Column: 1)));
    }

    [Fact]
    public void EmptyBoardIsSolved()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "000",
            "000");

        Assert.True(board.IsSolved);
    }

    [Fact]
    public void BoardWithOnTileIsNotSolved()
    {
        GridBoard board = GridBoard.FromRows(
            "000",
            "010",
            "000");

        Assert.False(board.IsSolved);
    }
}
```

These tests check the board type directly. They do not need `GridPuzzleModel`, `GridPuzzleRules`, or the Blazor page. That is useful because `GridBoard` now owns board behavior. The tests can go straight to the type responsible for the behavior being checked.

3.	Add another file named `GridPuzzleRulesTests.cs`:
```cs
namespace PuzzleArcade.Tests.GridPuzzle;

using PuzzleArcade.Games.GridPuzzle;
using PuzzleArcade.Games.Shared;

public sealed class GridPuzzleRulesTests
{
    [Fact]
    public void SelectingTileWhileNotStartedDoesNotChangeBoard()
    {
        GridPuzzleModel model = GridPuzzleRules.CreateInitial();

        GridPuzzleModel updated =
            GridPuzzleRules.Update(model, new SelectCell(Row: 1, Column: 1));

        Assert.IsType<NotStarted>(updated.State.Value);
        Assert.Contains("Start", updated.Message);
    }

    [Fact]
    public void ResetReturnsToNotStarted()
    {
        GridPuzzleModel model =
            GridPuzzleRules.Update(
                GridPuzzleRules.CreateInitial(),
                new StartGame());

        GridPuzzleModel updated =
            GridPuzzleRules.Update(model, new ResetGame());

        Assert.IsType<NotStarted>(updated.State.Value);
        Assert.Equal(0, updated.MovesTaken);
    }
}
```

These tests check the rule class. The first test confirms that selecting a tile before the game starts does not accidentally play the game. The second confirms that reset returns to a clean not-started state.

> **Prompt**: Please explain why testing `GridBoard` directly is better than trying to test its behavior through the Blazor page.

# Running the tests

Run all tests, as shown in *Figure 18.2*:
```shell
dotnet test PuzzleArcadeSolution.sln
```

![]()
*Figure 18.2: Running all the game tests*

The output should show that the test project built and the tests passed. The exact output will vary by SDK and test runner version, but a successful run should report no failed tests.

You can also run the tests from inside the test project folder:
```
cd PuzzleArcade.Tests
dotnet test
```

If a test fails, read the failure message carefully. A failing test is not automatically bad. It might mean the test expectation is wrong, or it might mean the game logic has a bug. The point of a test is to make that disagreement visible.

# Testing with known models instead of random starts

Several tests created models directly instead of dispatching `StartGame`. That was intentional.

`StartGame` chooses a random answer or secret. Randomness is good for gameplay, but it is awkward for unit tests. A test should usually know the exact input and expected output.

This is why the Word Guess test used:
```cs
CreatePlayingModel(answer: "apple")
```
and the Number Logic test used:
```
CreatePlayingModel(secret: "4279")
```

Those helper methods create a controlled game state. The tests can then check exact outcomes.

You can still write tests for `StartGame`, but those tests should check general facts rather than exact answers. For example, a Number Logic `StartGame` test could check that the secret has the expected length and contains no repeated digits. It should not expect the secret to be a particular value.

# Deciding how many tests to write

This section only adds a handful of tests. The aim was to demonstrate the technique, not to exhaustively test every rule in every game. For a larger project, you could add more tests:

**Word Guess**:
- Repeated guesses do not consume attempts.
- Hints do not consume attempts.
- Loss occurs after the maximum number of accepted guesses.

**Number Logic**:
- Easy, normal, and hard difficulties use the correct lengths.
- Winning occurs when every digit is exact.

**Grid Puzzle**
- Center, edge, and corner tiles affect the expected neighbors.
- Reset clears move count.

A useful rule is to test behavior that would be annoying to check manually or easy to break during refactoring. The number clue comparison is a good example. It is easy to make an off-by-one mistake or mix up exact and misplaced counts. A unit test catches that quickly.

# Using AI to generate test cases

AI can be helpful for test ideas, especially when the rule is easy to state.
For Number Logic, you could ask:
```
Generate test cases for NumberLogicRules using a fixed secret of 4279.
Include valid guesses, repeated-digit guesses, wrong-length guesses, winning guesses, and guesses with exact and misplaced matches. Return the cases in a table with expected outcomes.
```

For Grid Puzzle, you could ask:
```
Generate manual and unit test ideas for a 3x3 grid puzzle where selecting a tile toggles the selected tile and its neighbors. Include center, edge, and corner selections.
```

For Word Guess, you could ask:
```
Generate xUnit test ideas for WordGuessRules. Focus on invalid guesses, repeated guesses, correct guesses, losing after the maximum number of attempts, and hints. Do not write code yet. Return the ideas as a checklist.
```

Ask for test ideas before asking for test code. That gives you a chance to choose the tests that matter. When you do ask for code, include the model and rule class signatures so the generated tests fit your project.

As always, review generated tests carefully. A bad test can be worse than no test because it gives false confidence.

# Why this proves the design

The tests in this section are possible because of the design choices made earlier.
- The UI does not contain the main game rules.
- Player actions are represented as typed values.
- Models are ordinary C# records and classes.
- Rule classes return updated models.
- Game state uses named cases instead of scattered flags.

That combination makes the game logic testable. The tests do not need to know how Blazor renders a component. They do not need to simulate a browser click. They can call the same rule methods that the UI calls.

This is one of the strongest arguments for the architecture used in Puzzle Arcade. It is not only tidy. It is verifiable.

Manual browser testing still matters because it checks the whole user experience. Unit tests do not prove that the page is attractive, accessible, or easy to use. But unit tests do prove that the underlying rules behave as expected.

> **Good practice**: Manual browser testing checks the user experience. Unit tests check the rules directly. Both matter, but rule tests are faster and more precise.

> **Prompt**: Please explain the difference between manual browser testing and unit testing. Use Puzzle Arcade as the example.
