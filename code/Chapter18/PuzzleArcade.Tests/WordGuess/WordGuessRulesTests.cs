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
