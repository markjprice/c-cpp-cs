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
